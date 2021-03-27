using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route
{
    public partial class DrawRoute : Form
    {
        List<RouteStep> listeEtapes = new List<RouteStep>();
        public string ImPath;
        public string vidPath;
        public float zoomFactor = 1F;
        public float vStretchFactor = 1;
        public float hStretchFactor = 1;
        public float vertCorrect = 1;
        public float hortCorrect = 1;
        public string videoName = "";
        bool moving = false;
        Point topPaint = new Point(0, 0);
        Size videoSize;
        // Longueur de la vidéo générée en frames
        int vidLength = 100;
        int currentWidth = 2;
        int movLength = 4;
        RouteStep curEt = null;
        Size DVD = new Size(720, 576);
        Size FullHD = new Size(1920, 1080);
        Size HalfHD = new Size(1488, 720);
        Image curMap;
        Image curImage;
        Image curShow;
        Image curIcone;
        Bitmap ico;
        float angle = 0;
        float zoomChange = 1.2F;
        bool isRecording = false;
        string currentFile = "";
        AxWMPLib.AxWindowsMediaPlayer mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
        public DrawRoute()
        {
            InitializeComponent();
            
            //labFont.Visible = true;
            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
            videoSize = DVD;
            dVD720X576ToolStripMenuItem.Checked = true;
            aVCHD1488XToolStripMenuItem.Checked = false;
            aVCHD1920X1080ToolStripMenuItem.Checked = false;
            movieType.Text =dVD720X576ToolStripMenuItem.Text;
            movieLength.Value = movLength;
            System.Resources.ResourceManager rm = Properties.Resources.ResourceManager;
            ico = (Bitmap)Properties.Resources.Voiture46108;
            mediaPlayer.Visible = false;
            //ShowControls(false);
            drawRecord.Controls.Add(mediaPlayer);
            mediaPlayer.Dock = DockStyle.Fill;
        }
        #region Painting panels
        private void DrawRecord_Paint(object sender, PaintEventArgs e)
        {
            Size DrawSize = new Size((int)(videoSize.Width * zoomFactor), (int)(videoSize.Height * zoomFactor));
            if (isRecording)
            {
                e.Graphics.DrawImage(curShow, 0, 0, DrawSize.Width, DrawSize.Height);
            }
        }
        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Size DrawSize = new Size((int)(videoSize.Width * zoomFactor), (int)(videoSize.Height * zoomFactor));
            if (curMap != null)
            {
                e.Graphics.DrawImage(curMap, topPaint.X, topPaint.Y, DrawSize.Width, DrawSize.Height);
                if (listeEtapes.Count > 0)
                {
                    RouteStep init = PtToScreen((RouteStep)listeEtapes[0]);
                    //                   DrawStep(e.Graphics, init);
                    DrawIcon(e.Graphics, init);
                    RouteStep fin = null;
                    Pen p = new Pen(init.Color, init.LineWidth);
                    for (int i = 1; i < listeEtapes.Count; i++)
                    {
                        fin = PtToScreen((RouteStep)listeEtapes[i]);
                        Rectangle rect = new Rectangle(init.Location.X - 5, init.Location.Y - 5, 10, 10);
                        e.Graphics.DrawLine(p, init.Location, fin.Location);
                        DrawIcon(e.Graphics, init, fin);
                        init = fin;
                        //                     DrawStep(e.Graphics, init);
                        p.Dispose();
                        p = new Pen(init.Color, init.LineWidth);
                    }
                }
            }
        }
        private void DrawIcon(Graphics gr, RouteStep init)
        {
            float x = init.Location.X;
            float y = init.Location.Y;
            float slope = (float)(Math.Atan(y / x) * (180 / Math.PI));
            //     if (x < 0)                            slope += 180;
            Image nico2 = RotateImage(ico, slope + angle);
            int xx = init.Location.X - nico2.Width / 2;
            int yy = init.Location.Y - nico2.Height / 2;
            if (x < 0)
            {
                nico2.RotateFlip(RotateFlipType.RotateNoneFlipXY);

            }
    //        gr.DrawString(init.ToString(), new Font("Arial", 8), Brushes.Black, xx, yy);
            gr.DrawImage(nico2, xx, yy);
        }
        private void DrawIcon(Graphics gr, RouteStep init, int width, int height)
        {
            float x = init.Location.X;
            float y = init.Location.Y;
            float slope = (float)(Math.Atan(y / x) * (180 / Math.PI));
            //     if (x < 0)                            slope += 180;
            Image nico2 = RotateImage(ico, slope + angle);
            int xx = init.Location.X - width / 2;
            int yy = init.Location.Y - height / 2;
            if (x < 0)
            {
                nico2.RotateFlip(RotateFlipType.RotateNoneFlipXY);

            }
            //        gr.DrawString(init.ToString(), new Font("Arial", 8), Brushes.Black, xx, yy);
            gr.DrawImage(nico2, xx, yy, width, height);
        }
        private void DrawIcon(Graphics gr, RouteStep init, RouteStep fin)
        {
            float x = fin.Location.X - init.Location.X;
            float y = fin.Location.Y - init.Location.Y;
            float slope = (float)(Math.Atan(y / x) * (180 / Math.PI));
            //     if (x < 0)                            slope += 180;
            Image nico2 = RotateImage(ico, slope + angle);
            int xx = fin.Location.X - nico2.Width / 2;
            int yy = fin.Location.Y - nico2.Height / 2;
            if (x < 0)
            {
                nico2.RotateFlip(RotateFlipType.RotateNoneFlipXY);

            }
            //     gr.DrawString(init.ToString(), new Font("Arial", 8), Brushes.Black, xx, yy);
            gr.DrawImage(nico2, xx, yy);
        }
        private Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);
            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            //now rotate the image
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));
            //dispose of our Graphics object
            gfx.Dispose();
            //return the image
            return bmp;
        }
        #endregion
        private void DrawStep(Graphics gr, RouteStep init)
        {
            Pen pRect = new Pen(Color.Red, 2);
            if (init.isSelected)
            {
                pRect = new Pen(Color.White, 2);
            }
            Point pt = new Point(init.Location.X - 5, init.Location.Y - 5);
            gr.DrawRectangle(pRect, pt.X, pt.Y, 10, 10);
            if (init.Text != "")
                gr.DrawString(init.Text, init.Font, init.FontBrush, new Point(init.Location.X + 2, init.Location.Y));
        }
        private static long StepLength(RouteStep start, RouteStep end)
        {
            return (long)Math.Sqrt((end.Location.X - start.Location.X) * (end.Location.X - start.Location.X)
                + (end.Location.Y - start.Location.Y) * (end.Location.Y - start.Location.Y));
        }
        #region Menu items
        private void ZoomOut_Click(object sender, EventArgs e)
        {
            zoomFactor /= zoomChange;
            hortCorrect = hStretchFactor * zoomFactor;
            vertCorrect = vStretchFactor * zoomFactor;
            hScrollBar1.Maximum = (int)(curMap.Width * hortCorrect);
            vScrollBar1.Maximum = (int)(curMap.Height * vertCorrect);
            Refresh();
        }
        private void ZoomIn_Click(object sender, EventArgs e)
        {
            zoomFactor *= zoomChange;
            hortCorrect = hStretchFactor * zoomFactor;
            vertCorrect = vStretchFactor * zoomFactor;
            hScrollBar1.Maximum = (int)(curMap.Width * hortCorrect);
            vScrollBar1.Maximum = (int)(curMap.Height * vertCorrect);
            Refresh();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        #endregion
        #region Formats
        private void dVD720X576ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoSize = DVD;
            dVD720X576ToolStripMenuItem.Checked = true;
            aVCHD1488XToolStripMenuItem.Checked = false;
            aVCHD1920X1080ToolStripMenuItem.Checked = false; Refresh();
            movieType.Text = dVD720X576ToolStripMenuItem.Text;
        }
        private void aVCHD1488XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoSize = HalfHD;
            dVD720X576ToolStripMenuItem.Checked = false;
            aVCHD1488XToolStripMenuItem.Checked = true;
            aVCHD1920X1080ToolStripMenuItem.Checked = false;
            movieType.Text = aVCHD1488XToolStripMenuItem.Text;
            Refresh();
        }
        private void aVCHD1920X1080ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoSize = FullHD;
            dVD720X576ToolStripMenuItem.Checked = false;
            aVCHD1488XToolStripMenuItem.Checked = false;
            aVCHD1920X1080ToolStripMenuItem.Checked = true;
            movieType.Text = aVCHD1920X1080ToolStripMenuItem.Text;
            Refresh();
        }
        #endregion
        #region Aspect
        private void LabelColor_Click(object sender, EventArgs e)
        {
            if (curEt == null) return;
            ColorDialog colorDial = new ColorDialog();
            colorDial.Color = curEt.Color;
            if (colorDial.ShowDialog() == DialogResult.OK)
            {
                curEt.Color = colorDial.Color;
                labelColor.BackColor = curEt.Color;
                Refresh();
            }
        }
        private void LabFont_Click(object sender, EventArgs e)
        {
            if (curEt == null) return;
            FontDialog fontDial = new FontDialog();
            fontDial.Font = curEt.Font;
            fontDial.Color = curEt.FontColor;
            fontDial.ShowColor = true;
            if (fontDial.ShowDialog() == DialogResult.OK)
            {
                curEt.Font = fontDial.Font;
                curEt.FontColor = fontDial.Color;
                curEt.FontBrush = new System.Drawing.SolidBrush(curEt.FontColor);
                labFont.Font = curEt.Font;
                labFont.ForeColor = curEt.FontColor;
                Refresh();
            }
        }
        #endregion
        #region Transport
        private void busToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ico = (Bitmap)Properties.Resources.Autobus_50;
            vehicleStripDropDownButton.Image = ico;
            angle = 0;
            Refresh();
        }
        private void carToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ico = (Bitmap)Properties.Resources.Voiture46108;
            vehicleStripDropDownButton.Image = ico;
            angle = 0;
            Refresh();
        }
        private void planeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ico = (Bitmap)Properties.Resources.avion_50;
            vehicleStripDropDownButton.Image = ico;
            angle = -20;
            Refresh();
        }
        private void trainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ico = (Bitmap)Properties.Resources.Train_50;
            vehicleStripDropDownButton.Image = ico;
            angle = 0;
            Refresh();
        }
        #endregion
        private void ouvrirToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "Images (*.jpg)|*.jpg|All Files (*.*)|*.*";
            opfd.FilterIndex = 1;
            if (opfd.ShowDialog() == DialogResult.OK)
            {
                ImPath = opfd.FileName;
                curMap = Image.FromFile(ImPath);
                hStretchFactor = (float)curMap.Width / (float)videoSize.Width;
                vStretchFactor = (float)curMap.Height / (float)videoSize.Height;
      //          zoomFactor = 0.5F;
                hortCorrect = hStretchFactor * zoomFactor;
                vertCorrect = vStretchFactor * zoomFactor;
                movLength = vidLength / 25;
                listeEtapes = new List<RouteStep>();
                topPaint = new Point(0, 0);
                hScrollBar1.Maximum = (int)(curMap.Width * hortCorrect);
                vScrollBar1.Maximum = (int)(curMap.Height * vertCorrect);
                Refresh();
            }

        }
        private void Record_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = @"D:\Documents",
                FileName = "Film.avi",
                Filter = "Fichier video (*.avi)|*.avi"
            };
    //        if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                mediaPlayer.Visible = false;
                mediaPlayer.Ctlcontrols.stop();
                mediaPlayer.close();
            }
            splitContainer1.Panel2Collapsed = false;
            curImage = Image.FromFile(ImPath);
            curShow = (Image)curImage.Clone();
            isRecording = true;
            Refresh();
            int imageNumber = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFile = saveFileDialog1.FileName;
                if (listeEtapes.Count > 1)
                {
                    #region Calcul longueur totale du chemin
                    long longTot = 0;
                    RouteStep init = PtToScreen(listeEtapes[0]);
                    for (int i = 1; i < listeEtapes.Count; i++)
                    {
                        RouteStep end = PtToScreen(listeEtapes[i]);
                        longTot = longTot + StepLength(init, end);
                        init = end;
                    }
                    #endregion
                    uint framePerSecond = 25;
                    string fichier = saveFileDialog1.FileName;
                    AviReaderWriter aviWriter = new AviReaderWriter();
                    try
                    {
                        aviWriter.Open(fichier, framePerSecond, videoSize.Width, videoSize.Height);
                        // image de base
                        Bitmap bp = new Bitmap(curImage, videoSize.Width, videoSize.Height);
                        bp.RotateFlip(RotateFlipType.Rotate180FlipX);
                        aviWriter.AddFrame(bp);
                        bp.Dispose();
                        Graphics gr = Graphics.FromImage(curImage);
                        init = PtToScreen(listeEtapes[0]);
                        Pen p = new Pen(init.Color, init.LineWidth);
                        for (int i = 1; i < listeEtapes.Count; i++)
                        {
                            #region One line
                            RouteStep fin = PtToScreen(listeEtapes[i]);
                            float x = fin.Location.X - init.Location.X;
                            float y = fin.Location.Y - init.Location.Y;
                            //long largeurEtape = (long)(x * x);
                            //long hauteurEtape = (long)(y * y);
                            long longEtape = (long)Math.Sqrt((long)(x * x) + (long)(y * y)) * (long)vidLength / longTot;
                            if (longEtape < 1)
                                longEtape = 5;
                            int d = (int)longEtape; 
                            float slope = y / x;
                            for (int j = 1; j <= d; j++)
                            {
                                #region One step
                                gr = Graphics.FromImage(curImage);
                                long step = (long)x * j / d;
                                long hstep = (long)(step * slope);
                                if (init.Text != "")
                                    gr.DrawString(init.Text, new Font("Times New Roman", 20), Brushes.White, new Point(init.Location.X + 2, init.Location.Y));
                                RouteStep place = PtToScreen(new RouteStep(new Point((int)(init.Location.X + step), (int)(init.Location.Y + hstep))));
                                gr.DrawLine(p, place.Location.X, place.Location.Y, place.Location.X + 2, place.Location.Y + 2);
                                curShow.Dispose();
                                curShow = (Image)curImage.Clone();
                                curIcone = (Image)curShow.Clone();
                                gr = Graphics.FromImage(curIcone);
                                DrawIcon(gr, place, 20, 20);
                                imageNumber += 1;
                                nombreImages.Text = imageNumber.ToString() + " image";
                                if (imageNumber > 1)
                                    nombreImages.Text += "s";
                                AddImageToFilm(aviWriter, curShow);
                                AddImageToFilm(aviWriter, curIcone);
                                //curIcone.Dispose();
                                Refresh();
                                #endregion
                            }
                            init = fin;
                            p.Dispose();
                            p = new Pen(init.Color, init.LineWidth);
                            #endregion
                        }
                        if (init.Text != "")
                            gr.DrawString(init.Text, init.Font, Brushes.White, new Point(init.Location.X + 2, init.Location.Y));
                        curShow.Dispose();
                        curShow = (Image)curImage.Clone();
                        gr = Graphics.FromImage(curShow);
                        DrawIcon(gr, init);

                        for (int uu = 0; uu < 10; uu++)
                        {
                            AddImageToFilm(aviWriter, curIcone);
                        }
                    }
                    catch (AviException ex)
                    {
                        MessageBox.Show("AVI Exception in: " + ex.ToString());
                    }
                    finally
                    {
                        aviWriter.Close();
                    }
                }
            }
            isRecording = false;
            //splitContainer1.Panel2Collapsed = true;
        }
        private void AddImageToFilm(AviReaderWriter aviWriter, Image im)
        {
            Bitmap bp = new Bitmap(im, videoSize.Width, videoSize.Height);
            bp.RotateFlip(RotateFlipType.Rotate180FlipX);
            aviWriter.AddFrame(bp);
            bp.Dispose();
        }
        void m_Click(object sender, EventArgs e)
        {
            if (curEt != null)
            {
                listeEtapes.Remove(curEt);
                Refresh();
            }
        }
        #region Interface events handling
        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = ScreenToPoint(e.Location);
            if ((curEt != null) && moving)
            {
                curEt.Move(pt);
                Refresh();
            }
        }
        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                //  curEt = null;
                moving = false;
                Refresh();
            }
        }
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            moving = false;
            curEt = FindStep(e);
            Point pt = ScreenToPoint(e.Location);
            //     pt = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                if (curEt == null)
                {
                    moving = false;
                    //ShowControls(false);
                    RouteStep et = new RouteStep(pt);
                    listeEtapes.Add(et);
                    if (listeEtapes.Count > 1)
                    {
                        Refresh();
                    }
                }
                else
                {
                    moving = true;
                    //ShowControls(true);
                    labelColor.BackColor = curEt.Color;
                    Etiq.Text = curEt.Text;
                    lineWidth.Value = curEt.LineWidth;
                    labFont.Font = curEt.Font;
                    labFont.ForeColor = curEt.FontColor;
                }
            }
            else
            {
                ContextMenuStrip c = new ContextMenuStrip();
                ToolStripMenuItem m = new ToolStripMenuItem("Delete");
                m.Click += new EventHandler(m_Click);
                c.Items.Add(m);
                c.Show(this, e.Location);
            }
            Refresh();
        }
        //private void ShowControls(bool vis)
        //{
        //    toolStripSeparator3.Visible = vis;
        //    lineWidth.Visible = vis;
        //    //     sLength.Visible = vis;
        //    Etiq.Visible = vis;
        //    toolStripLabel1.Visible = vis;
        //    lb.Visible = vis;
        //    labelColor.Visible = vis;
        //    labFont.Visible = vis;
        //}
        private Point ScreenToPoint(Point pt)
        {
            //            return pt;
            return new Point((int)((pt.X - topPaint.X) / hortCorrect), (int)((pt.Y - topPaint.Y) / vertCorrect));
        }
        private RouteStep PtToScreen(RouteStep rs)
        {
            RouteStep rst = new RouteStep(new Point((int)(rs.Location.X * hortCorrect) + topPaint.X, (int)(rs.Location.Y * vertCorrect + topPaint.Y)));
            rst.Text = rs.Text;
            rst.LineWidth = rs.LineWidth;
            rst.Font = rs.Font;
            rst.FontBrush = rs.FontBrush;
            rst.FontColor = rs.FontColor;
            rst.Color = rs.Color;
            rst.isSelected = rs.isSelected;
            return rst;
        }
        private RouteStep FindStep(MouseEventArgs e)
        {
            foreach (RouteStep ext in listeEtapes)
                ext.isSelected = false;
            RouteStep cet = null;
            int acc = 10;
            Rectangle rect = new Rectangle((int)((e.X - topPaint.X) / hortCorrect) - acc, (int)((e.Y - topPaint.Y) / vertCorrect) - acc, 2 * acc, 2 * acc);
            foreach (RouteStep et in listeEtapes)
            {
                RouteStep etCor = PtToScreen(et);
                if (rect.Contains(et.Location))
                {
                    cet = et;
                    et.isSelected = true;
                    break;
                }
            }
            return cet;
        }
        private void MovieLength_ValueChanged(object sender, EventArgs e)
        {
            movLength = (int)movieLength.Value;
            vidLength = movLength * 25;
        }
        private void Etiq_TextChanged(object sender, EventArgs e)
        {
            if (curEt != null)
            {
                curEt.Text = Etiq.Text;
                Refresh();
            }
        }
        private void lineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentWidth = (int)lineWidth.Value;
            if (curEt != null)
            {
                curEt.LineWidth = (int)lineWidth.Value;
                Refresh();
            }

        }
        #endregion

        private void play_Click(object sender, EventArgs e)
        {
            mediaPlayer.Visible = true;
            mediaPlayer.Dock = DockStyle.Fill;
            mediaPlayer.URL = currentFile;
            mediaPlayer.Ctlcontrols.play();
            Refresh();
        }
    }
    class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            // Set the value of the double-buffering style bits to true. 
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
    }
    public class ToolStripSlider : ToolStripControlHost
    {
        public ToolStripSlider() : base(new NumericUpDown()) { }
        public NumericUpDown NumUp
        {
            get
            {
                return Control as NumericUpDown;
            }
        }

        public decimal Value
        {
            get
            {
                return NumUp.Value;
            }
            set { NumUp.Value = value; }
        }
        public decimal Maximum
        {
            get
            {
                return NumUp.Maximum;
            }
            set { NumUp.Maximum = value; }
        }

        // Subscribe and unsubscribe the control events you wish to expose.
        protected override void OnSubscribeControlEvents(Control c)
        {
            // Call the base so the base events are connected.
            base.OnSubscribeControlEvents(c);

            // Cast the control to a MonthCalendar control.
            NumericUpDown NumUp = (NumericUpDown)c;

            // Add the event.
            NumUp.ValueChanged += new EventHandler(NumUp_ValueChanged);
        }

        void NumUp_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
        protected override void OnUnsubscribeControlEvents(Control c)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(c);
            NumericUpDown NumUp = (NumericUpDown)c;
            // Remove the event.
            NumUp.ValueChanged -= new EventHandler(NumUp_ValueChanged);
        }
        public event EventHandler ValueChanged;
    }
    class RouteStep
    {
        public Point Location
        {
            get
            {
                return new Point(x, y);
            }
            set
            {
                x = value.X;
                y = value.Y;
            }
        }
        private int x;
        private int y;
        public string Text;
        public int LineWidth;
        public Color Color;
        public Font Font;
        public Brush FontBrush;
        public Color FontColor;
        public bool isSelected = false;
        public RouteStep(Point pt)
        {
            x = pt.X;
            y = pt.Y;
            LineWidth = 3;
            Color = Color.Red;
            Text = "";
            Font = new Font("Times New Roman", 20);
            FontColor = Color.White;
            FontBrush = Brushes.White;
        }
        public void Move(Point pt)
        {
            x = pt.X;
            y = pt.Y;
        }
        public override string ToString()
        {
            return x + "," + y;
        }
    }
}
