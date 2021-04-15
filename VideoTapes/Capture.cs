using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VideoTapes
{
    /// <summary>
    /// DV video capture and analysis class
    /// Provides analysis coming either from an avi file 
    /// </summary>
    public class DVCapture 
    {
        private DateTime currentTimeCode;
        private int currentFrameNumber = 0;
        #region Public properties
        public DateTime CurrentFrameDate { get; set; }
        #endregion
        #region Public functions
        /// Contructor for fast file access mode
        /// </summary>
        public DVCapture(string FileName)
        {
            fileName = FileName;
        }
        #region Open and close Files
        public bool OpenAviFile(out DVVideoTape crMf)
        {
            try
            {
                aviFile = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                ReadAviHeaders();
                crMf = new DVVideoTape(fileName)
                {
                    VideoSize = new Size((int)fileHdr.width, (int)fileHdr.height),
                    FrameCount = (int)fileHdr.nbTotalFrames,
                    Codec = fileStruc[0].fccHandler,
                    MicroSecPerFrame = fileHdr.microSecPerFrame
                };
                return true;
            }
            catch
            {
                crMf = null;
                return false;
            }
        }
        public void CloseAviFile()
        {
            if (aviFile != null) aviFile.Close();
        }
        #endregion
        const int WM_FINISH = 0x8000 + 100;
        #region File analysis
        /// <summary>
        ///<frame>
        /// Frame size 144000 for PAL + 4 byte code 00dc
        /// + 4 byte code for length 0x23280
        /// One audio bloc every 25 images of size 192000 or 128000
        /// starting with 01wb
        /// Some empty frames sometimes
        /// </frame> 
        ///<timecode>
        /// time code is in the  block starting with 0x3F 0x07 0x00 (normally at offset 0x54)
        /// in a five bytes field starting with 0x13 at offset 114 (0x72).
        /// </timecode>
        /// <datetime>
        /// date and time are in the  block starting with 0x5F 0x07 0x02 (normally at offset 0x194)
        /// in  five bytes fields starting with 0x62 and 0x63 at offset 462 and 467 (01cE and 0x1D3).
        /// </datetime>
        ///<splitting>
        ///Sequence is split according to the date/time and frame number.
        ///If date/time differs by more than one second sequence is split (works 
        ///for original DV Frames)
        ///if date/time n/a then frame number is used (works for generated frames)
        /// </splitting>
        /// </summary>
        /// <param name="startFrame"></param>
        /// <param name="endFrame"></param>
        public void Analyse()
        {
            FrameAnalysis();
        }
        private void FrameAnalysis()
        {
            int frameSequenceLength = 0;
            int sequenceNumber = 1;
            DateTime startComp = DateTime.Now;
            byte[] vauxdata;
            if (indexFrame.Count > 0)
            {

                #region Best case : Frame index is available
                int numIndex = 0;
                int firstFrameInIndex = 0;
                #region Reads first video frame
                IndexData inx = (IndexData)indexFrameStart[0];
                UInt64 movieOffset = inx.startOffset;
                aviFile.Seek((long)inx.startOffset, SeekOrigin.Begin);
                buf = (int)fileStruc[0].dwSuggestedBufferSize;
                vauxdata = new byte[buf];
                currentFrameNumber = 0;
                FrameData fr = (FrameData)indexFrame[currentFrameNumber];
                long currentFrameOffset = (long)movieOffset + fr.offset;
                aviFile.Seek(currentFrameOffset - 8, SeekOrigin.Begin);
                #endregion
                if (fr.size <= buf)
                {
                    #region   First frame handling. Fournit le time code de départ
                    aviFile.Read(vauxdata, 0, 1000);
                    int start = 0x1D2;
                    if (vauxdata[start] == 0x62)
                    {
                        DateTime[] timeData = Utils.ComputeCodeAndStampFrame(vauxdata, start);
                        CurrentFrameDate = timeData[0];
                        currentTimeCode = timeData[1];
                        sequenceNumber += 1;
                    }
                    #endregion
                }
                DateTime oldFrame = fr.FrameDateTime;
                currentFrameNumber += 1;
                #region General treatment
                while (currentFrameNumber < fileHdr.nbTotalFrames)
                {
                    int lastFrameInIndex = (int)Math.Min(firstFrameInIndex + entriesInUse, fileHdr.nbTotalFrames);
                    while ((currentFrameNumber < fileHdr.nbTotalFrames) & (currentFrameNumber < lastFrameInIndex - 1))
                    {
                        #region Read a frame
                        if (stop)
                            return;
                        fr = (FrameData)indexFrame[currentFrameNumber];
                        currentFrameOffset = (long)movieOffset + fr.offset;
                        aviFile.Seek(currentFrameOffset - 8, SeekOrigin.Begin);
                        if (fr.size <= buf)
                        {
                            aviFile.Read(vauxdata, 0, 1000);
                            int start = 0x1D2;
                            if (vauxdata[start] == 0x62)
                            {
                                DateTime[] timeData = Utils.ComputeCodeAndStampFrame(vauxdata, start);
                                CurrentFrameDate = timeData[0];
                                currentTimeCode = timeData[1];
                                //Test : la première vérification évite des choses étranges
                                // et repose sur l'hypothèse raisonnable de séquences d'au moins 5 frames, ie 1/5 de secondes
                                if ((frameSequenceLength > 5) && (CurrentFrameDate != oldFrame) && ((CurrentFrameDate > oldFrame.Add(new TimeSpan(0, 0, 1))) || CurrentFrameDate < oldFrame))
                                {
                                    sequenceNumber += 1;
                                    frameSequenceLength = 0;
                                }
                                oldFrame = CurrentFrameDate;
                            }
                        }
                        frameList.Add(currentFrameNumber, new FrameData(currentFrameNumber, CurrentFrameDate, currentTimeCode, sequenceNumber));
                        currentFrameNumber += 1;
                        frameSequenceLength += 1;
                        #endregion
                    }
                    if (currentFrameNumber == fileHdr.nbTotalFrames - 1)
                    {
                        DateTime endComp = DateTime.Now;
                        TimeSpan ts = endComp - startComp;
                        int sec = ts.Minutes * 60 + ts.Seconds;
        //                int speed = (int)fileHdr.nbTotalFrames / sec;
                        return;
                    }
                    #region Updates frame index 
                    while ((ch != "ix00") && (aviFile.Position < aviFile.Length))
                    {
                        #region Recherche l'index suivant
                        aviFile.Read(ckid, 0, len);
                        ch = Utils.ByteToString(ckid);
                        #endregion
                    }
                    entriesInUse = UpdateIndex();
                    if (entriesInUse < 4000)
                    {
                        fileHdr.nbTotalFrames = currentFrameNumber + entriesInUse;
                    }
                    firstFrameInIndex += inx.startFrame;
                    numIndex += 1;
                    inx = (IndexData)indexFrameStart[numIndex];
                    movieOffset = inx.startOffset;
                    ch = "";
                    #endregion
                }
                #endregion
                #endregion
            }
            else
            {
                FrameAnalysisAlter();
            }
        }
        public DateTime FirstSequence()
        {
            CurrentFrameDate = DateTime.MinValue;
            try
            {
                aviFile = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                ReadAviHeaders();
                int sequenceNumber = 1;
                DateTime startComp = DateTime.Now;
                byte[] vauxdata;
                if (indexFrame.Count > 0)
                {
                    #region Best case : Frame index is available
                    DateTime oldFrame = DateTime.MinValue;
                    DateTime newFrame = DateTime.MinValue;
                    #region Reads first video frame
                    IndexData inx = (IndexData)indexFrameStart[0];
                    UInt64 movieOffset = inx.startOffset;
                    aviFile.Seek((long)inx.startOffset, SeekOrigin.Begin);
                    buf = (int)fileStruc[0].dwSuggestedBufferSize;
                    vauxdata = new byte[buf];
                    currentFrameNumber = 0;
                    FrameData fr = (FrameData)indexFrame[currentFrameNumber];
                    long currentFrameOffset = (long)movieOffset + fr.offset;
                    aviFile.Seek(currentFrameOffset - 8, SeekOrigin.Begin);
                    #endregion
                    if (fr.size <= buf)
                    {
                        #region   First frame handling
                        aviFile.Read(vauxdata, 0, 1000);
                        int start = 0x1D2;
                        if (vauxdata[start] == 0x62)
                        {
                            DateTime[] timeData = Utils.ComputeCodeAndStampFrame(vauxdata, start);
                            CurrentFrameDate = timeData[0];
                            currentTimeCode = timeData[1];
                            sequenceNumber += 1;
                        }
                        #endregion
                    }
                    oldFrame = fr.FrameDateTime;
                    currentFrameNumber += 1;
                    #endregion
                }
            }
            catch { }
            return CurrentFrameDate;
        }
        /// <summary>
        /// Reads all indexes at once
        /// </summary>
        public void GetFrameIndexes()
        {
            IndexData inx = (IndexData)indexFrameStart[0];
            UInt64 movieOffset = inx.startOffset;
            long offSet = 0;
            while (currentFrameNumber < fileHdr.nbTotalFrames)
            {
                FrameData fr = (FrameData)indexFrame[indexFrame.Count - 1];
                offSet = (long)movieOffset + fr.offset;
                aviFile.Seek(offSet - 8 + fileHdr.suggestedBufferSize, SeekOrigin.Begin);
                Byte[] vauxdata = new byte[1000];
                while (ch != "ix00")
                {
                    aviFile.Read(ckid, 0, len);
                    ch = Utils.ByteToString(ckid);
                }
                GetLong("Index Size");
                GetShort("LongPerEntry");
                GetByte("SubType");
                GetByte("Type");
                long entryInUse = GetLong("Entries in use");
                vidstr = GetString("dwChunkid");
                UInt32 q1 = (UInt32)GetLong("quad1");
                UInt32 q2 = (UInt32)GetLong("quad2");
                GetLong("dwReserved");
                for (int u = 0; u < entryInUse; u++)
                {
                    aviFile.Read(ckid, 0, len);
                    long off = (int)Utils.ByteToInt(ckid);
                    aviFile.Read(ckid, 0, len);
                    long dwSize = Utils.ByteToInt(ckid);
                    FrameData fri = new FrameData(off, dwSize);
                    if (ch == "ix00")
                    {
                        indexFrame.Add(fri);
                    }
                    if (indexFrame.Count == fileHdr.nbTotalFrames)
                        return;
                }
                IndexData ix = new IndexData((int)entryInUse, q1, q2);
                indexFrameStart.Add(ix);
                ch = "";
                movieOffset = ix.startOffset;
            }
        }
        #endregion
        #endregion
        #region Direct file access
        #region Private variables for file access
        private string fileName;
        private List<Shot> sequences;
        private AVISTREAMINFO[] fileStruc;
        private AVIHEADER fileHdr;
        private FileStream aviFile;
        private int buf = 144004;
        private string vidstr = "00dc";//"00db"
        private int len = 4;
        private byte[] ckid = new byte[4];
        private string ch = "";
        private long entriesInUse;
        List<FrameData> indexFrame = new List<FrameData>();
        List<IndexData> indexFrameStart = new List<IndexData>();
        private bool stop = false;
        /// <summary>
        /// Analyse list contains descripive data about the video file
        /// </summary>
        private List<string> analyseList;
        public System.Collections.SortedList frameList = new System.Collections.SortedList();
        #endregion
        #region Find headers
        private void ReadAviHeaders()
        {
            analyseList = new List<string>();
            #region Reading aviHeader
            fileHdr.riff = AddString("Header");
            fileHdr.fileSize = AddLong("Size");
            fileHdr.fType = AddString("Type");
            fileHdr.list = AddString("Structure");
            fileHdr.lstSize = AddLong("Size");
            fileHdr.headerL = AddString("Header");
            fileHdr.av = AddString("MainAviHeader");
            //
            fileHdr.sSize = AddLong("Size");
            fileHdr.microSecPerFrame = AddLong("MicroSecPerFrame");
            fileHdr.maxBytesperSec = AddLong("MaxBytesperSec");
            fileHdr.granularity = AddLong("Granularity");
            fileHdr.flags = AddLong("Flags");
            fileHdr.nbTotalFrames = AddLong("TotalFrames");
            fileHdr.initialFrame = AddLong("InitialFrame");
            fileHdr.nbStreams = AddLong("Streams");
            fileHdr.suggestedBufferSize = AddLong("Suggested Buffer Size");
            fileHdr.width = AddLong("Width");
            fileHdr.height = AddLong("Height");
            fileHdr.scale = AddLong("R");
            fileHdr.rate = AddLong("R");
            fileHdr.start = AddLong("R");
            fileHdr.length = AddLong("R");
            #endregion
            #region Reading streams data
            ///<summary>
            ///Stream list
            ///<summary>
            string dm = AddString("List start");
            long nbTot = AddLong("Size");
            fileStruc = new AVISTREAMINFO[fileHdr.nbStreams];
            int streamNumber = 0;
            while (streamNumber < fileHdr.nbStreams)
            {
                while (ch != "movi")
                {
                    aviFile.Read(ckid, 0, len);
                    ch = Utils.ByteToString(ckid);
                    streamNumber = ReadStreamData(streamNumber);
                    if (streamNumber == fileHdr.nbStreams) break;
                }
            }
            while (ch != "movi")
            {
                aviFile.Read(ckid, 0, len);
                ch = Utils.ByteToString(ckid);
                ReadStreamData(0);
            }
            #endregion
            analyseList.Add(aviFile.Position.ToString("x8") + " List " + ch);
            if (fileStruc[0].fccType == "iavs")
            {
                //Dans le cas d'un fichier 'iavs' il y a d'autres informations
                //avant un second 'movi'
                while (ch != vidstr)
                {
                    aviFile.Read(ckid, 0, len);
                    ch = Utils.ByteToString(ckid);
                    ReadStreamData(0);
                }
            }
            else
            {
                //On recherche le premier frame qui commence
                //par l'indicateur vidstr
                do
                {
                    aviFile.Read(ckid, 0, len);
                    ch = Utils.ByteToString(ckid);
                    //May read first part of indexes
                    ReadStreamData(0);
                }
                while (ch != vidstr);
            }
        }
        private int ReadStreamData(int streamNumber)
        {
            long stSize = 0;
            switch (ch)
            {
                case "ix00":
                    entriesInUse = UpdateIndex();
                    break;
                case "ix01":
                    UpdateIndexAud();
                    break;
                case "01wb":
                    aviFile.Read(ckid, 0, len);
                    long u = Utils.ByteToInt(ckid);
                    aviFile.Seek(u, SeekOrigin.Current);
                    break;
                case "JUNK":
                    aviFile.Read(ckid, 0, len);
                    long lh = Utils.ByteToInt(ckid);
                    analyseList.Add(aviFile.Position.ToString("x8") + ch + " " + lh.ToString());
                    aviFile.Seek((int)lh, SeekOrigin.Current);
                    break;
                case "LIST":
                    analyseList.Add(aviFile.Position.ToString("x8") + " List : " + ch);
                    AddLong("Size");
                    break;
                case "vprp":
                    break;
                case "dmlh":
                    analyseList.Add(aviFile.Position.ToString("x8") + ch);
                    break;
                case "strl":
                    analyseList.Add(aviFile.Position.ToString("x8") + " Flux n° " + streamNumber.ToString() + " " + ch);
                    break;
                case "strh":
                    analyseList.Add(aviFile.Position.ToString("x8") + " Header : " + ch);
                    stSize = AddLong("Size");
                    fileStruc[streamNumber].fccType = AddString("Type de flux"); stSize -= 4;
                    fileStruc[streamNumber].fccHandler = AddString("Gestionnaire"); stSize -= 4;
                    if (fileStruc[streamNumber].fccHandler == "RLE ") vidstr = "00db";
                    fileStruc[streamNumber].dwFlags = AddLong("Flags"); stSize -= 4;
                    fileStruc[streamNumber].wPriority = AddShort("Priority"); stSize -= 2;
                    fileStruc[streamNumber].wLanguage = AddShort("Language"); stSize -= 2;
                    fileStruc[streamNumber].dwInitialFrames = AddLong("Initial Frame"); stSize -= 4;
                    fileStruc[streamNumber].dwScale = AddLong("Scale"); stSize -= 4;
                    fileStruc[streamNumber].dwRate = AddLong("Rate"); stSize -= 4;
                    fileStruc[streamNumber].dwStart = AddLong("Start"); stSize -= 4;
                    fileStruc[streamNumber].dwLength = AddLong("Length"); stSize -= 4;
                    fileStruc[streamNumber].dwSuggestedBufferSize = AddLong("Suggested Buffer Size"); stSize -= 4;
                    if (fileStruc[streamNumber].fccType == "vids") buf = (int)fileStruc[streamNumber].dwSuggestedBufferSize;
                    fileStruc[streamNumber].dwQuality = AddLong("Quality"); stSize -= 4;
                    fileStruc[streamNumber].dwSampleSize = AddLong("Sample Size"); stSize -= 4;
                    AddShort("Left"); stSize -= 2;
                    AddShort("Top"); stSize -= 2;
                    AddShort("Right"); stSize -= 2;
                    AddShort("Bottom"); stSize -= 2;
                    break;
                case "strf":
                    analyseList.Add(aviFile.Position.ToString("x8") + "Format " + ch);
                    AddLong("Taille");
                    switch (fileStruc[streamNumber].fccType)
                    {
                        case "iavs":
                            AddLong("DVAAuxSrc");
                            AddLong("DVAAuxCtl");
                            AddLong("DVAAuxSrc1");
                            AddLong("DVAAuxCtl1");
                            AddLong("DVVAuxSrc");
                            AddLong("DVVAuxCtl");
                            AddLong("Reserved");
                            AddLong("Reserved");
                            break;
                        case "vids":
                            stSize = AddLong("Size");
                            AddLong("Width"); stSize -= 4;
                            AddLong("Height"); stSize -= 4;
                            AddShort("Planes"); stSize -= 2;
                            AddShort("BitCount"); stSize -= 2;
                            AddString("Compression"); stSize -= 4;
                            int buf2 = (int)AddLong("ImageSize"); stSize -= 4;
                            if ((buf2 < buf) && (fileStruc[streamNumber].fccType == "vids")) buf = buf2;
                            AddLong("xPelsPerMeter"); stSize -= 4;
                            AddLong("yPelsPerMeter"); stSize -= 4;
                            AddLong("Colors"); stSize -= 4;
                            AddLong("Important Colors"); stSize -= 4;
                            streamNumber++;
                            break;
                        case "auds":
                            AddShort("Format"); stSize -= 2;
                            AddShort("nChannels"); stSize -= 2;
                            AddLong("SamplesPerRec"); stSize -= 4;
                            AddLong("AvgBytesPerRec"); stSize -= 4;
                            AddShort("BlockAlign"); stSize -= 2;
                            AddShort("BitsPerSample"); stSize -= 2;
                            streamNumber++;
                            break;
                    }
                    break;
                case "strd":
                    long a = AddLong("");
                    for (int uu = 0; uu < (a / 4); uu++) AddLong("");
                    break;
                case "odml":
                    analyseList.Add(aviFile.Position.ToString("x8") + " Open DML List " + ch);
                    AddString("");
                    long length = AddLong("Length");
                    long dw = AddLong("Real Frame Number"); length -= 4;
                    aviFile.Seek(length, SeekOrigin.Current);
                    break;
                case "indx":
                    //Type 1 DV dv file
                    analyseList.Add(aviFile.Position.ToString("x8") + " " + ch);
                    long lhn = AddLong("Size");
                    aviFile.Seek(lhn, SeekOrigin.Current);
                    break;
                default:
                    break;
            }
            return streamNumber;
        }
        #endregion
        #region Search for sequences
        private long UpdateIndex()
        {
            analyseList.Add(ch);
            AddLong("Index Size");
            AddShort("LongPerEntry");
            AddByte("SubType");
            AddByte("Type");
            long entryInUse = AddLong("Entries in use");
            vidstr = AddString("dwChunkid");
            UInt32 q1 = (UInt32)AddLong("quad1");
            UInt32 q2 = (UInt32)AddLong("quad2");
            AddLong("dwReserved");
            for (int u = 0; u < entryInUse; u++)
            {
                aviFile.Read(ckid, 0, len);
                long off = (int)Utils.ByteToInt(ckid);
                aviFile.Read(ckid, 0, len);
                long dwSize = Utils.ByteToInt(ckid);
                FrameData fr = new FrameData(off, dwSize);
                if (ch == "ix00")
                {
                    indexFrame.Add(fr);
                }
            }
            IndexData ix = new IndexData((int)entryInUse, q1, q2);
            indexFrameStart.Add(ix);
            return entryInUse;
        }
        private void UpdateIndexAud()
        {
            analyseList.Add(ch);
            long lg = AddLong("Index Size");
            long deb = aviFile.Position;
            AddShort("LongPerEntry");
            AddByte("SubType");
            AddByte("Type");
            long entryInUse = AddLong("Entries in use");
            AddString("dwChunkid");
            UInt32 q1 = (UInt32)AddLong("quad1");
            UInt32 q2 = (UInt32)AddLong("quad2");
            AddLong("dwReserved");
            for (int u = 0; u < entryInUse; u++)
            {
                aviFile.Read(ckid, 0, len);
                long off = (int)Utils.ByteToInt(ckid);
                aviFile.Read(ckid, 0, len);
                long dwSize = Utils.ByteToInt(ckid);
            }
            lg = (lg + deb) - aviFile.Position;
            aviFile.Seek(lg, SeekOrigin.Current);
        }
        /// <summary>
        /// Alternate scanning method when index are not available
        /// This method scans the video file, lists all frames and 
        /// compute all sequence starts.
        /// Corrections are brought when timecode is incorrect
        /// Dans certains cas :
        /// Le film est organisé en blocs (de deux gigas ?), précédé par la séquence RIFF AVIX
        /// et clos par un index. Cas de Shanghai Février.avi Dans ce cas le nombre de frames
        /// indiquées est normalement celui du premier RIFF. Pas le cas pour ce film
        /// <validity>
        /// This method is used for movies without indexes ix00
        /// </validity>
        /// </summary>
        private void FrameAnalysisAlter()
        {
            //This function reads sequentially all the video frames in a buffer
            buf = 144000;
            byte[] vauxdata = new byte[buf];
            int frameSequence = 0;
            int numSequence = 1;
            sequences = new List<Shot>();
            //These variable are used for sequence splitting
            DateTime frameLoc = DateTime.MinValue;
            DateTime oldFrameLoc = DateTime.MinValue;
            DateTime beforeFrame = DateTime.MinValue;
            DateTime oldFrame = DateTime.MinValue;
            DateTime newFrame = DateTime.MinValue;
            currentFrameNumber = 0;
            int frameStart = currentFrameNumber;
            int prevFrame = 0;
            Shot s = new Shot
            {
                SeqNumber = 1,
                StartFrame = 0
            };
            bool correct = true;
            long numtr = 0;
            int framCount = 0;
            TimeSpan delay = new TimeSpan(0, 0, 0);
            do
            {
                long startNewFrame;
                while (ch != vidstr)
                {
                    if (numtr >= fileHdr.nbTotalFrames) break;
                    if (ch == "01wb")
                    {
                        aviFile.Read(ckid, 0, len);
                        long audLen = Utils.ByteToInt(ckid);
                        aviFile.Seek(audLen, SeekOrigin.Current); startNewFrame = aviFile.Position;
                        if ((framCount < 24) && (numtr > 24))
                        {
                            // utile dans un cas : yunnan2.avi, problème frame 15067 au lieu de 15064
                            // manque trois frames entre deux audios au frame 15046
                            numtr += (25 - framCount);
                        }
                        framCount = 0;
                    }
                    if (ch == "RIFF")
                    {
                    }
                    if ((ch == "ix00") || (ch == "ix01") || (ch == "00ix") || (ch == "01ix") || (ch == "idx1") || (ch == "idx0"))
                    {
                        //skipping index data
                        aviFile.Read(ckid, 0, len);
                        long indLen = Utils.ByteToInt(ckid);
                        aviFile.Seek(indLen, SeekOrigin.Current);
                        startNewFrame = aviFile.Position;
                    }
                    if (aviFile.Read(ckid, 0, len) < 0) return;
                    ch = Utils.ByteToString(ckid);
                    if (aviFile.Position >= aviFile.Length) break;
                }
                startNewFrame = aviFile.Position;
                ch = "";
                //One more frame has been found and can be analyzed
           //     sizeFrame = startNewFrame - startOldFrame;
                aviFile.Read(ckid, 0, len);
                int vidLen = (int)Utils.ByteToInt(ckid);
                if (vidLen == 144000)
                {
                    aviFile.Read(vauxdata, 0, 500);
                    if (vauxdata[0x1CA] == 0x62)
                    {
                        DateTime[] timeData = Utils.ComputeCodeAndStampFrame(vauxdata, 0x1CA);
                        newFrame = timeData[0];
                        frameLoc = timeData[1];
                        // Criterion : timestamp has changed, for more than one second 
                        if ((currentFrameNumber > 1) && (newFrame != beforeFrame) && (newFrame != oldFrame) && ((newFrame > oldFrame.Add(new TimeSpan(0, 0, 1))) || newFrame < oldFrame) && (currentFrameNumber >= prevFrame + 5))
                        {
                            int secd = frameSequence / 25;
                            int mn = secd / 60;
                            secd = frameSequence / 25 - 60 * mn;
                            int fr = frameSequence - 25 * secd;
                            ///Saving the current sequence
                            s.EndFrame = (int)numtr - 1;
                            sequences.Add(s);
                            //new sequence
                            numSequence += 1;
                            s = new Shot
                            {
                                SeqNumber = numSequence,
                                StartFrame = (int)numtr,
                                TimeStamp = (correct ? newFrame : DateTime.MaxValue)
                            };
                            prevFrame = currentFrameNumber;
                            frameSequence = 0;
                        }
                        frameList.Add(currentFrameNumber, new FrameData(currentFrameNumber, newFrame, frameLoc, numSequence));
                        frameSequence += 1;
                        beforeFrame = oldFrame;
                        oldFrame = newFrame;
                        oldFrameLoc = frameLoc;

                        currentFrameNumber += 1;
                        // Correction
                    }
                    // Jump to next candidate frame
                    aviFile.Seek(buf - 500, SeekOrigin.Current);
                    frameStart += 1;
                    framCount += 1;
                    numtr++;
                }
                // Prepare next frame
                if (aviFile.Read(ckid, 0, len) < 0) return;
                ch = Utils.ByteToString(ckid);
            }
            while (numtr < fileHdr.nbTotalFrames);
            // Handling the last one
            int secda = frameSequence / 25;
            int mna = secda / 60;
            secda = frameSequence / 25 - 60 * mna;
            //int fra = frameSequence - 25 * secda;
            s.EndFrame = currentFrameNumber - 1;
            numSequence += 1;
            s.SeqNumber = numSequence;
            if (correct)
            {
                s.TimeStamp = newFrame;
            }
            else
            {
                s.TimeStamp = DateTime.MaxValue;
            }
            sequences.Add(s);
        }
        #endregion
        #endregion
        #region Utility functions
        private string AddString(string comment)
        {
            aviFile.Read(ckid, 0, 4);
            string tmp = Utils.ByteToString(ckid);
            analyseList.Add(comment + " " + tmp);
            return tmp;
        }
        private long AddLong(string comment)
        {
            aviFile.Read(ckid, 0, 4);
            long tmp = Utils.ByteToInt(ckid);
            analyseList.Add(comment + " " + tmp);
            return tmp;
        }
        private short AddShort(string comment)
        {
            aviFile.Read(ckid, 0, 2);
            short tmp = (short)Utils.ByteToInt(ckid);
            analyseList.Add(comment + " " + tmp);
            return tmp;
        }
        private int AddByte(string comment)
        {
            aviFile.Read(ckid, 0, 1);
            int tmp = (int)Utils.ByteToInt(ckid);
            analyseList.Add(comment + " " + tmp);
            return tmp;
        }
        private string GetString(string comment)
        {
            aviFile.Read(ckid, 0, 4);
            return Utils.ByteToString(ckid);
        }
        private long GetLong(string comment)
        {
            aviFile.Read(ckid, 0, 4);
            return Utils.ByteToInt(ckid);
        }
        private short GetShort(string comment)
        {
            aviFile.Read(ckid, 0, 2);
            return (short)Utils.ByteToInt(ckid);
        }
        private int GetByte(string comment)
        {
            aviFile.Read(ckid, 0, 1);
            return (int)Utils.ByteToInt(ckid);
        }
        #endregion
    }
    public class Analyse
    {
        private DVVideoTape currentMediaFile;
        public int imWidth;
        public int imHeight;
        public double AvgTimePerFrame;
        public Analyse()
        {
            FolderBrowserDialog opfd = new FolderBrowserDialog();
            if (opfd.ShowDialog() == DialogResult.OK)
            {
                string Dir = opfd.SelectedPath;
                string[] files = Directory.GetFiles(Dir, "*.avi");
                foreach (string file in files)
                {
                    ChercheTimeCode(file);
                }
            }
        }
        public Analyse(string Dir)
        {
            string[] files = Directory.GetFiles(Dir, "*.avi");
            foreach (string file in files)
            {
                ChercheTimeCode(file);
            }
        }
        public Analyse(Videos vid)
        {
            foreach (Shots shot in vid.Shots)
            {
                ChercheTimeCode(shot);
            }
        }
        public void ChercheTimeCode (string file)
        {
            DVCapture cam = new DVCapture(file);
            if (!cam.OpenAviFile(out currentMediaFile))
                return;
            imWidth = (int)currentMediaFile.VideoSize.Width;
            imHeight = (int)currentMediaFile.VideoSize.Height;
            AvgTimePerFrame = (double)currentMediaFile.MicroSecPerFrame / (double)1000000;
            cam.Analyse();
            Console.Write(file + ": ");
            Console.WriteLine(cam.frameList.GetByIndex(1));
        }
        public void ChercheTimeCode(Shots shot)
        {
            //Fichiers DV sous J:\DVVideo
            DVCapture cam = new DVCapture(@"J:\DVVideo\" + shot.Fichier.Replace("mps", "avi"));
            if (!cam.OpenAviFile(out currentMediaFile))
                return;
            imWidth = (int)currentMediaFile.VideoSize.Width;
            imHeight = (int)currentMediaFile.VideoSize.Height;
            AvgTimePerFrame = (double)currentMediaFile.MicroSecPerFrame / (double)1000000;
            cam.Analyse();
            FrameData x = (FrameData)cam.frameList.GetByIndex(1);
            shot.DateShot = x.FrameDateTime;
            shot.FrameCount = (int)x.FrameNumber;
        }
    }
}
