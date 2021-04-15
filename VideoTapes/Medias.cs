using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace VideoTapes
{
    public class MediaItem
    {
        #region Public members
        public string Comment = "";
        public static bool updated = false;
        public Shots MediaFile
        {
            get { return (Shots)mediaFile; }
        }
        public Segment PositionOnTrack
        {
            get
            {
                return new Segment(startOnTrack, endOnTrack);
            }
            set
            {
                startOnTrack = value.Start;
                endOnTrack = value.End;
            }
        }
        public Segment PositionInMedia
        {
            get
            {
                return new Segment(startInMedia, endInMedia);
            }
            set
            {
                startInMedia = value.Start;
                endInMedia = value.End;
            }
        }
        public MediaItemState State
        {
            get
            {
                return mediaState;
            }
            set
            {
                mediaState = value;
            }
        }
        public bool IsSelected
        {
            get
            {
                if (mediaState == MediaItemState.Selected)
                    return true;
                else
                    return false;
            }
        }
        public MediaItemType ItemType
        {
            get
            {
                return mediaType;
            }
        }
        public long LengthOnTrack
        {
            get
            {
                return endOnTrack - startOnTrack;
            }
        }
        public long LengthInMedia
        {
            get { return endInMedia - startInMedia; }
        }
        public string TimeOnTrack
        {
            get { return Utils.ToTime(endOnTrack - startOnTrack); }
        }
        public string TimeInMedia
        {
            get { return Utils.ToTime(endInMedia - startInMedia); }
        }
        /// <summary>
        /// If audio and video clips are linked
        /// this field contains the value of the linked clip.
        /// null otherwise
        /// </summary>
        public MediaItem LinkedClip { get; set; }
        public Rectangle DrawnRectangle
        {
            get { return drawingRectangle; }
        }
        #endregion
        #region Public methods
        public virtual void Paint(Graphics g, int leftDrawingStart, int topDrawingStart, long height, float framePixelsSize, Point originDraw)
        {
            drawingRectangle = DrawingRectangle(leftDrawingStart, topDrawingStart - originDraw.Y, (int)height, framePixelsSize, originDraw.X);
            Rectangle inRect = new Rectangle(drawingRectangle.Left + 2, drawingRectangle.Top + 2, drawingRectangle.Width - 4, drawingRectangle.Height - 4);
            switch (mediaType)
            {
                case MediaItemType.Empty:
                    g.DrawRectangle(Pens.Brown, inRect);
                    break;
                case MediaItemType.Video:
                case MediaItemType.Audio:
                    switch (mediaType)
                    {
                        case MediaItemType.Audio:
                            SolidBrush brush = new SolidBrush(Utils.aud_color);
                            g.FillRectangle(brush, drawingRectangle);
                            break;
                        case MediaItemType.Video:
                            brush = new SolidBrush(Utils.vid_color);
                            g.FillRectangle(brush, drawingRectangle);
                            #region Draw thumbs
                            int w = 90;
                            int h = 72;
                            float reduc = (float)h / (float)inRect.Height;
                            string bs = Utils.ThumbsDirectory + ShortName;
                            if (!Directory.Exists(bs))
                                Directory.CreateDirectory(bs);
                            string fn = bs + @"\" + ShortName + "im" + PositionInMedia.Start.ToString() + ".bmp";
                            try
                            {
                                if (!File.Exists(fn))
                                {
                                    long place = PositionInMedia.Start;
                                    CreateThumb(w, h, fn, place);
                                }
                                g.DrawImage(Image.FromFile(fn), inRect.Left, inRect.Top, Math.Min(w / reduc, inRect.Width), h / reduc);
                            }
                            catch { }
                            if (inRect.Width > (int)(2 * w / reduc))
                            {
                                try
                                {
                                    fn = bs + @"\" + ShortName + "im" + PositionInMedia.End.ToString() + ".bmp";
                                    if (!File.Exists(fn))
                                    {
                                        long place = PositionInMedia.End;
                                        CreateThumb(w, h, fn, place);
                                    }
                                    int leftIm = (int)(inRect.Right - w / reduc);
                                    g.DrawImage(Image.FromFile(fn), leftIm, inRect.Top, w / reduc, h / reduc);
                                }
                                catch { }
                            }

                            #endregion
                            #region Draw text
                            string s = Comment;
                            if (s == "")
                                s = ShortName;
                            // Adapts the length of the string
                            Font ft = new Font("Arial", 8);
                            SizeF sz = g.MeasureString(s, ft);
                            float avail = drawingRectangle.Width - 2 * w / 3;
                            if (sz.Width > avail)
                            {
                                if ((int)(s.Length * avail / sz.Width) > 1)
                                    s = s.Substring(0, (int)(s.Length * avail / sz.Width));
                                else
                                    s = "";
                            }
                            g.DrawString(s, ft, Brushes.Black, drawingRectangle.Left + w / reduc + 3, drawingRectangle.Top + 3);
                            #endregion
                            break;
                    }
                    Pen pa = new Pen(Color.Bisque, 2);
                    g.DrawRectangle(pa, inRect);
                    #region Handles selection
                    if ((IsSelected) || ((LinkedClip != null) && LinkedClip.IsSelected))
                    {

                        Pen p = new Pen(Brushes.Red, 1);
                        p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        g.DrawRectangle(Pens.Red, drawingRectangle);
                    }
                    else
                    {
                        if (State == MediaItemState.Hovered)
                        {
                            Pen ph = new Pen(Brushes.Green, 5);
                            g.DrawRectangle(ph, drawingRectangle);
                        }
                        else
                            g.DrawRectangle(Pens.Black, drawingRectangle);
                    }
                    #endregion
                    break;
                case MediaItemType.Transition:
                    #region Draw transition
                    if (endOnTrack > originDraw.X)
                    {
                        drawingRectangle = DrawingRectangle(leftDrawingStart, topDrawingStart - originDraw.Y, (int)height, framePixelsSize, originDraw.X);
                        SolidBrush brush = new SolidBrush(Utils.trans_color);
                        g.FillRectangle(brush, drawingRectangle);
                        if (IsSelected)
                            g.DrawRectangle(Pens.Red, drawingRectangle);
                        else
                            g.DrawRectangle(Pens.Black, drawingRectangle);
                    }
                    if (startOnTrack > originDraw.Y)
                    {
                        topDrawingStart -= originDraw.Y;
                        int mid = (int)((endOnTrack + startOnTrack) / 2 - originDraw.X);
                        Point[] pts = new Point[4];
                        int mil = leftDrawingStart + (int)(mid * framePixelsSize);
                        Rectangle rec = new Rectangle(mil - 1, topDrawingStart + 4, 3, 5);
                        pts[0] = new Point(mil - 3, topDrawingStart + 4);
                        pts[1] = new Point(mil + 3, topDrawingStart + 4);
                        pts[2] = new Point(mil, topDrawingStart);
                        pts[3] = pts[0];
                        if (!invert)
                        {
                            rec = new Rectangle(mil - 1, topDrawingStart + 2, 3, 5);
                            pts[0] = new Point(mil - 3, topDrawingStart + 7);
                            pts[1] = new Point(mil + 3, topDrawingStart + 7);
                            pts[2] = new Point(mil, topDrawingStart + 11);
                            pts[3] = pts[0];
                        }
                        g.FillRectangle(Brushes.White, rec);
                        g.FillPolygon(Brushes.White, pts);
                    }
                    #endregion
                    break;
            }
        }
        public void Select(bool sel)
        {
            if (sel)
                mediaState = MediaItemState.Selected;
            else
                mediaState = MediaItemState.Unselected;
        }
        public bool Contains(Point pt)
        {
            //           if (CurDrawingRectangle.Contains(pt))
            if ((pt.X > startOnTrack) & (pt.X < endOnTrack))
                return true;
            return false;
        }
        public bool IsOnBorder(Point pt, out bool begin, int frSize)
        {
            begin = false;
            if ((pt.X > drawingRectangle.Left - frSize) && (pt.X < drawingRectangle.Left + frSize))
            {
                begin = true;
                return true;
            }
            if ((pt.X > drawingRectangle.Right - frSize) && (pt.X < drawingRectangle.Right + frSize))
            {
                begin = false;
                return true;
            }
            return false;
        }
        public void ShiftClipSimple(int shift)
        {
            if (startOnTrack + shift < 0)
                return;
            startOnTrack += shift;
            endOnTrack += shift;
        }
        public void ShiftClip(int shift)
        {
            if (startOnTrack + shift < 0)
                return;
            startOnTrack += shift;
            endOnTrack += shift;
            PositionOnTrack = new Segment(startOnTrack, endOnTrack);
            if (LinkedClip != null) LinkedClip.PositionOnTrack = PositionOnTrack;
        }
        public void ExtendClip(int extend, bool extendClipStart)
        {
            if (extend < 0)
            {
            }
            if (extendClipStart)
            {
                if ((extend > 0) && (endOnTrack - startOnTrack + extend) < 5)
                    return;
                if (startOnTrack + extend < 0)
                    return;
                if (startInMedia + extend < 0)
                    return;
                startOnTrack += extend;
                startInMedia += extend;
            }
            else
            {
                if ((extend < 0) && (endOnTrack - startOnTrack - extend) < 5)
                    return;
                endOnTrack += extend;
                endInMedia += extend;
            }
            if ((LinkedClip != null) && !LinkedClip.IsSelected)
            {
                LinkedClip.PositionOnTrack = PositionOnTrack;
                LinkedClip.PositionInMedia = PositionInMedia;
            }
        }
        public bool Intersects(MediaItem b)
        {
            if ((b == null) || (b == this))
                return false;
            Rectangle rectB = new Rectangle((int)b.PositionOnTrack.Start, 10, (int)(b.PositionOnTrack.End - b.PositionOnTrack.Start), 10);
            Rectangle rectThis = new Rectangle((int)startOnTrack, 10, (int)(endOnTrack - startOnTrack), 10);
            return rectThis.IntersectsWith(rectB);
        }
        public bool Intersects(List<MediaItem> m, int top, int height, int direction)
        {
            if (m == null)
                return false;
            bool inters = false;
            foreach (MediaItem b in m)
            {
                if (direction < 0)
                {
                    // Move to left
                    if ((b != this) && (b.PositionOnTrack.Start < startOnTrack))
                    {
                        Rectangle rectB = new Rectangle((int)b.PositionOnTrack.Start, top, (int)(b.PositionOnTrack.End - b.PositionOnTrack.Start) + 1, height);
                        Rectangle rectThis = new Rectangle((int)startOnTrack, top, (int)(endOnTrack - startOnTrack), height);
                        inters = rectThis.IntersectsWith(rectB);
                        if (inters)
                        {
                            long w = endOnTrack - startOnTrack;
                            startOnTrack = b.PositionOnTrack.End + 1;
                            endOnTrack = startOnTrack + w;
                            if (LinkedClip != null)
                            {
                                LinkedClip.PositionOnTrack = new Segment(startOnTrack, endOnTrack);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    if ((b != this) && (endOnTrack < b.PositionOnTrack.End))
                    {
                        Rectangle rectB = new Rectangle((int)b.PositionOnTrack.Start, top, (int)(b.PositionOnTrack.End - b.PositionOnTrack.Start), height);
                        Rectangle rectThis = new Rectangle((int)startOnTrack, top, (int)(endOnTrack - startOnTrack) + 1, height);
                        inters = rectThis.IntersectsWith(rectB);
                        if (inters)
                        {
                            long w = endOnTrack - startOnTrack;
                            endOnTrack = b.PositionOnTrack.Start - 1;
                            startOnTrack = endOnTrack - w;
                            if (LinkedClip != null)
                            {
                                LinkedClip.PositionOnTrack = new Segment(startOnTrack, endOnTrack);
                            }
                            break;
                        }
                    }
                }
            }
            return inters;
        }
        override public string ToString()
        {
            string sV;
            string e;

            if (mediaFileName != null && mediaFileName.Length > 0)
            {
                FileInfo fV = new FileInfo(mediaFileName);
                sV = fV.Name;
            }
            else
            {
                sV = "<null>";
            }
            if (endInMedia > 0)
            {
                e = ((float)endInMedia / Utils.UNITS).ToString("###0.0");
                e = e.PadLeft(6, ' ');
            }
            else
            {
                e = "   -1  ";
            }

            string s = ((float)(startInMedia / Utils.UNITS)).ToString("###0.0");
            s = s.PadLeft(6, ' ');

            return string.Format("{0, -16} {2} ", sV, s, e);
        }
        public string ToString2()
        {
            string sV;
            string e;
            if (mediaFileName != null && mediaFileName.Length > 0)
            {
                FileInfo fV = new FileInfo(mediaFileName);
                sV = fV.Name;
            }
            else
            {
                sV = "<null>";
            }
            if (endInMedia > 0)
            {
                e = ((float)endInMedia / Utils.UNITS).ToString("###0.0");
                e = e.PadLeft(6, ' ');
            }
            else
            {
                e = "   -1  ";
            }
            string s = ((float)(startInMedia / Utils.UNITS)).ToString("###0.0");
            s = s.PadLeft(6, ' ');

            return string.Format("{0, -16} {2} ", sV, startOnTrack.ToString(), endOnTrack.ToString());
        }
        #endregion
        #region Constructors
        public MediaItem()
        { }
        public MediaItem(Shots mdf, Segment onTrack, Segment inMedia)
        {
            mediaFile = mdf;
            startInMedia = inMedia.Start;
            endInMedia = inMedia.End;
            startOnTrack = onTrack.Start;
            endOnTrack = onTrack.End;
            //   mediaType = mdf.MediaType;
        }
        /// <summary>
        /// Creates a mediaItem of a specific type
        /// </summary>
        /// <param name="c"></param>
        /// <param name="mdType"></param>
        public MediaItem(MediaItem c, MediaItemType mdType)
        {
            mediaFile = c.mediaFile;
            startInMedia = c.startInMedia;
            endInMedia = c.endInMedia;
            startOnTrack = c.startOnTrack;
            endOnTrack = c.endOnTrack;
            mediaType = mdType;
            Comment = c.Comment;
        }
        public MediaItem(DragDropItem b)
        {
            endInMedia = b.EndInMedia;
            startInMedia = b.StartInMedia;
            endOnTrack = b.EndOnTrack;
            startOnTrack = b.StartOnTrack;
            mediaFile = b.mediaFile;
            mediaType = b.mediaType;
        }
        #endregion
        #region Private or protected members
        private Rectangle drawingRectangle = Rectangle.Empty;
        protected string mediaFileName;
        private string ShortName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(mediaFile.Fichier);
            }
        }
        protected long startInMedia;
        protected long endInMedia;
        protected long startOnTrack;
        protected long endOnTrack;
        protected Shots mediaFile;
        protected MediaItemType mediaType = MediaItemType.AudioVideo;
        protected MediaItemState mediaState;
        protected bool invert = false;
        #endregion
        private void CreateThumb(int w, int h, string fn, long place)
        {
            DirectShowLib.DES.IMediaDet mm = new DirectShowLib.DES.MediaDet() as DirectShowLib.DES.IMediaDet;
            mm.put_Filename(mediaFileName);
            mm.put_CurrentStream(0);
            double pVal, pFr;
            mm.get_StreamLength(out pVal);
            mm.get_FrameRate(out pFr);
            double x = pVal * pFr;
            mm.WriteBitmapBits((pVal * place) / x, w, h, fn);
            /*
            int bufSize;
            IntPtr buffer = IntPtr.Zero; ;
            mm.GetBitmapBits((pVal * 10) / 1, out bufSize, buffer, 720, 576);
            buffer = Marshal.AllocHGlobal(bufSize);
            Bitmap b = new Bitmap(width, height, width * 3, PixelFormat.Format24bppRgb, new IntPtr((int)buffer + 40));*/

        }
        private Rectangle DrawingRectangle(int leftDrawingStart, int topDrawingStart, int trackHeight, float scale, int stFrame)
        {
            int start = Math.Max(leftDrawingStart + (int)((startOnTrack - stFrame) * scale), leftDrawingStart);
            int width = (int)((endOnTrack + 1 - startOnTrack) * scale) - 1;
            if (startOnTrack < stFrame)
                width += (int)((startOnTrack - stFrame) * scale);
            drawingRectangle = new Rectangle(start, topDrawingStart + 1, width, trackHeight - 2);
            return drawingRectangle;
        }
    }
    public struct Segment
    {
        #region Private
        private long start;
        private long end;
        private bool Contains(long pt)
        {
            if ((pt >= start) && (pt <= end))
                return true;
            return false;
        }
        private bool Contains(Segment seg)
        {
            if ((start <= seg.start) && (end >= seg.end))
                return true;
            return false;
        }
        #endregion
        #region Public
        public long Start
        {
            get { return start; }
        }
        public long End
        {
            get { return end; }
        }
        public Segment(long stSeg, long endSeg)
        {
            start = stSeg;
            end = endSeg;
        }
        public bool Equals(Segment seg)
        {
            if ((seg.start == start) && (seg.end == end))
                return true;
            return false;
        }
        public bool Intersects(Segment seg)
        {
            if (Contains(seg) || Contains(seg.start) || Contains(seg.end)
                || seg.Contains(new Segment(start, end)) || seg.Contains(start) || seg.Contains(end))
                return true;
            return false;
        }
        public new string ToString()
        {
            return start.ToString() + " - " + end.ToString();
        }
        #endregion
    }
    ///  Simple class to handle video shot dropping on the timeline
    /// </summary>
    public class DragDropItem
    {
        public bool isScene = false;
        public Shots mediaFile;
        public long StartInMedia;
        public long EndInMedia;
        public long StartOnTrack;
        public long EndOnTrack;
        public MediaItemType mediaType;
        public List<Shots> Clips;
        public DragDropItem()
        {
        }
        public DragDropItem(Shots mdf, Segment onTrack, Segment inMedia)
        {
            mediaFile = mdf;
            StartInMedia = inMedia.Start;
            EndInMedia = inMedia.End;
            StartOnTrack = onTrack.Start;
            EndOnTrack = onTrack.End;
        }
        public DragDropItem(Scenes s)
        {
            isScene = true;
            //            mediaFile =  s.mediaFile;
            StartInMedia = (int)s.StartFrame;
            EndInMedia = (int)s.EndFrame;
        }
        public bool isEmpty()
        {
            return (mediaFile == null);
        }
    }
    public enum MediaItemType { Empty, Audio, Video, AudioVideo, Transition, Effect, Unknown }
    public enum MediaItemState { Unselected, Selected, Hovered }

}
