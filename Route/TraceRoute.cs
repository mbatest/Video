using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route
{
    public partial class TraceRoute : UserControl
    {
        List<RouteStep> listeEtapes;
        public string ImPath;
        public string vidPath;
        public int zoomFactor;
        public float vStretchFactor = 1;
        public float hStretchFactor = 1;
        public float vertCorrect = 1;
        public float hortCorrect = 1;
        public string videoName = "";
        bool moving = false;
        // Vidéo format Pal
        int vidWidth = 720;
        int vidHeight = 576;
        // Longueur de la vidéo générée en secondes
        int vidLength = 100;
        int currentWidth = 2;
        int movLength = 4;
        RouteStep curEt = null;
        public TraceRoute()
        {
            InitializeComponent();
            ShowControls(false);
            if (HDVideo)
            {
                vidHeight = 1080;
                vidWidth = 1920;
            }
        }

        void tfn_ValueChanged(object sender, EventArgs e)
        {
            vidLength = (int)tfn.Value;
        }

        void tn_ValueChanged(object source, EventArgs e)
        {
            currentWidth = (int)tn.Value;
            if (curEt != null)
            {
                curEt.LineWidth = (int)tn.Value;
                PaintImage();
            }
        }
        private void Etiq_TextChanged(object sender, EventArgs e)
        {
            if (curEt != null)
            {
                curEt.Text = Etiq.Text;
                PaintImage();
            }
        }
        public TraceRoute(string im, string vP, int vW, int vH)
        {
            ImPath = im;
            vidPath = vP;
            vidWidth = vW;
            vidHeight = vH;
            listeEtapes = new List<RouteStep>();
            InitializeComponent();
            pBox.Image = Image.FromFile(ImPath);
            hStretchFactor = (float)pBox.Image.Width / (float)vidWidth;
            vStretchFactor = (float)pBox.Image.Height / (float)vidHeight;
            zoomFactor = 1;
            pBox.Width = vidWidth / zoomFactor;
            pBox.Height = vidHeight / zoomFactor;
            hortCorrect = hStretchFactor * zoomFactor;
            vertCorrect = vStretchFactor * zoomFactor;
            movLength = vidLength / 25;
        }
        private void pBox_MouseDown(object sender, MouseEventArgs e)
        {
            moving = false;
            curEt = FindStep(e);

            Point pt = ScreenToPoint(e.Location);
            if (e.Button == MouseButtons.Left)
            {
                if (curEt == null)
                {
                    moving = false;
                    ShowControls(false);
                    RouteStep et = new RouteStep(pt);
                    listeEtapes.Add(et);
                    if (listeEtapes.Count > 1)
                    {
                        PaintImage();
                    }
                }
                else
                {
                    ShowControls(true);
                    moving = true;
                    labelColor.BackColor = curEt.Color;
                    Etiq.Text = curEt.Text;
                    tn.Value = curEt.LineWidth;
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
            PaintImage();
        }
        void m_Click(object sender, EventArgs e)
        {
            if (curEt != null)
            {
                listeEtapes.Remove(curEt);
                PaintImage();
            }
        }
        private Point ScreenToPoint(Point pt)
        {
            return new Point((int)(pt.X * hortCorrect), (int)(pt.Y * vertCorrect));
        }
        private Point PtToScreen(Point pt)
        {
            return new Point((int)(pt.X / hortCorrect), (int)(pt.Y / vertCorrect));
        }
        private void pBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = ScreenToPoint(e.Location);
            if ((curEt != null) && moving)
            {
                curEt.Move(pt);
                PaintImage();
            }
        }
        private void pBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                //  curEt = null;
                moving = false;
                PaintImage();
            }
        }
        private RouteStep FindStep(MouseEventArgs e)
        {
            foreach (RouteStep ext in listeEtapes)
                ext.isSelected = false;
            RouteStep cet = null;
            int acc = 10;
            Rectangle rect = new Rectangle((int)(e.X * hortCorrect) - acc, (int)(e.Y * vertCorrect) - acc, 2 * acc, 2 * acc);
            foreach (RouteStep et in listeEtapes)
            {
                if (rect.Contains(et.Location))
                {
                    cet = et;
                    et.isSelected = true;
                    break;
                }
            }
            return cet;
        }
        private void Ok_Click_1(object sender, EventArgs e)
        {
            if (curEt != null)
            {
                curEt.Text = Etiq.Text;
                curEt.LineWidth = (int)currentWidth;
                PaintImage();
            }
            foreach (RouteStep et in listeEtapes)
            {
                if (et.isSelected)
                {
                    et.Text = Etiq.Text;
                    et.LineWidth = (int)currentWidth;
                }
            }
            PaintImage();
        }
        private void PaintImage()
        {
            pBox.Image = Image.FromFile(ImPath);
            Graphics gr = Graphics.FromImage(pBox.Image);
            RouteStep init = (RouteStep)listeEtapes[0];
            DrawStep(gr, init);
            RouteStep fin = null;
            Pen p = new Pen(init.Color, init.LineWidth);
            for (int i = 1; i < listeEtapes.Count; i++)
            {
                fin = (RouteStep)listeEtapes[i];

                Rectangle rect = new Rectangle(init.Location.X - 5, init.Location.Y - 5, 10, 10);
                gr.DrawLine(p, init.Location, fin.Location);
                init = fin;
                DrawStep(gr, init);
                p.Dispose();
                p = new Pen(init.Color, init.LineWidth);
            }
            pBox.Refresh();
        }
        private static void DrawStep(Graphics gr, RouteStep init)
        {
            Pen pRect = new Pen(Color.Red, 2);
            if (init.isSelected)
            {
                pRect = new Pen(Color.White, 2);
            }
            gr.DrawRectangle(pRect, init.Location.X - 5, init.Location.Y - 5, 10, 10);
            if (init.Text != "")
                gr.DrawString(init.Text, init.Font, init.FontBrush, new Point(init.Location.X + 2, init.Location.Y));
        }
        private void Generate(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Film.avi";
            saveFileDialog1.Filter = "Fichier video (*.avi)|*.avi";
            if (listeEtapes.Count > 1)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fichier = saveFileDialog1.FileName;
                    videoName = fichier;
                    AviReaderWriter aw = new AviReaderWriter();
                    try
                    {
                        uint framePerSecond = 25;
                        Bitmap bmp = aw.Open(fichier, framePerSecond, vidWidth, vidHeight);
                        // image de base
                        pBox.Image = Image.FromFile(ImPath);
                        Bitmap bp = new Bitmap(pBox.Image, vidWidth, vidHeight);
                        bp.RotateFlip(RotateFlipType.Rotate180FlipX);
                        aw.AddFrame(bp);
                        bp.Dispose();
                        Graphics gr = Graphics.FromImage(pBox.Image);
                        // calcul longueur totale du chemin
                        long longTot = 0;
                        RouteStep s = (RouteStep)listeEtapes[0];
                        for (int i = 1; i < listeEtapes.Count; i++)
                        {
                            RouteStep f = (RouteStep)listeEtapes[i];
                            longTot = longTot + StepLength(s, f);
                            s = f;
                        }
                        RouteStep init = (RouteStep)listeEtapes[0];
                        Pen p = new Pen(init.Color, init.LineWidth);
                        for (int i = 1; i < listeEtapes.Count; i++)
                        {
                            RouteStep fin = (RouteStep)listeEtapes[i];
                            long wdEt = (long)(fin.Location.X - init.Location.X) * (fin.Location.X - init.Location.X);
                            long htEt = (long)(fin.Location.Y - init.Location.Y) * (fin.Location.Y - init.Location.Y);
                            long lgEt = (long)Math.Sqrt(wdEt + htEt) * (long)vidLength / longTot;
                            if (lgEt < 1)
                                lgEt = 5;
                            int d = (int)lgEt; // nombre d'images pour une étape
                                               //                                Trace.WriteLine(d);
                            float x = fin.Location.X - init.Location.X;
                            float y = fin.Location.Y - init.Location.Y;
                            float slope = y / x;
                            for (int j = 1; j <= d; j++)
                            {
                                long step = (long)x * j / d;
                                long hstep = (long)(step * slope);
                                gr.DrawLine(p, init.Location.X, init.Location.Y, init.Location.X + step, init.Location.Y + hstep);
                                if (init.Text != "")
                                    gr.DrawString(init.Text, new Font("Times New Roman", 20), Brushes.White, new Point(init.Location.X + 2, init.Location.Y));
                                pBox.Refresh();
                                bp = new Bitmap(pBox.Image, vidWidth, vidHeight);
                                bp.RotateFlip(RotateFlipType.Rotate180FlipX);
                                aw.AddFrame(bp);
                                bp.Dispose();
                            }
                            init = fin;
                            p.Dispose();
                            p = new Pen(init.Color, init.LineWidth);
                        }
                        if (init.Text != "")
                            gr.DrawString(init.Text, init.Font, Brushes.White, new Point(init.Location.X + 2, init.Location.Y));
                        for (int uu = 0; uu < 10; uu++)
                        {
                            bp = new Bitmap(pBox.Image, vidWidth, vidHeight);
                            bp.RotateFlip(RotateFlipType.Rotate180FlipX);
                            aw.AddFrame(bp);
                        }
                        bp.Dispose();

                        //                       aw.Close();

                    }
                    catch (AviException ex)
                    {
                        MessageBox.Show("AVI Exception in: " + ex.ToString());
                        //                       aw.Close();
                    }
                    finally
                    {
                        aw.Close();
                    }
                }
            }
        }
        private static long StepLength(RouteStep start, RouteStep end)
        {
            return (long)Math.Sqrt((end.Location.X - start.Location.X) * (end.Location.X - start.Location.X)
                + (end.Location.Y - start.Location.Y) * (end.Location.Y - start.Location.Y));
        }
        private void labelColor_Click(object sender, EventArgs e)
        {
            if (curEt == null) return;
            ColorDialog colorDial = new ColorDialog();
            colorDial.Color = curEt.Color;
            if (colorDial.ShowDialog() == DialogResult.OK)
            {
                curEt.Color = colorDial.Color;
                labelColor.BackColor = curEt.Color;
                PaintImage();
            }
        }
        private void labFont_Click(object sender, EventArgs e)
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
                PaintImage();
            }
        }
        private void ShowControls(bool vis)
        {
            toolStripSeparator2.Visible = vis;
            tn.Visible = vis;
            sLength.Visible = vis;
            Etiq.Visible = vis;
            toolStripLabel1.Visible = vis;
            lb.Visible = vis;
            labelColor.Visible = vis;
            labFont.Visible = vis;
        }
        private void Zoom_Click(object sender, EventArgs e)
        {
            SetZoom();
        }

        private void SetZoom()
        {
            if (zoomFactor == 2)
            {
                Width += pBox.Width;
                Height += pBox.Height;
                pBox.Height *= zoomFactor;
                pBox.Width *= zoomFactor;
                zoomFactor = 1;
            }
            else
            {
                zoomFactor = 2;
                pBox.Height /= zoomFactor;
                pBox.Width /= zoomFactor;
                Width -= pBox.Width;
                Height -= pBox.Height;
            }
            hortCorrect = hStretchFactor * zoomFactor;
            vertCorrect = vStretchFactor * zoomFactor;
        }
        private void movLength_ValueChanged(object sender, EventArgs e)
        {
            vidLength = (int)movLength * 25;
        }
        private void sLength_Click(object sender, EventArgs e)
        {
            if (curEt != null)
            {
                curEt.stepLength = sLength.Value;
            }
        }
        bool HDVideo = true;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HDVideo = !HDVideo;
        }
    }
    //public class ToolStripSlider : ToolStripControlHost
    //{
    //    public ToolStripSlider() : base(new NumericUpDown()) { }
    //    public NumericUpDown NumUp
    //    {
    //        get
    //        {
    //            return Control as NumericUpDown;
    //        }
    //    }

    //    public decimal Value
    //    {
    //        get
    //        {
    //            return NumUp.Value;
    //        }
    //        set { NumUp.Value = value; }
    //    }
    //    public decimal Maximum
    //    {
    //        get
    //        {
    //            return NumUp.Maximum;
    //        }
    //        set { NumUp.Maximum = value; }
    //    }

    //    // Subscribe and unsubscribe the control events you wish to expose.
    //    protected override void OnSubscribeControlEvents(Control c)
    //    {
    //        // Call the base so the base events are connected.
    //        base.OnSubscribeControlEvents(c);

    //        // Cast the control to a MonthCalendar control.
    //        NumericUpDown NumUp = (NumericUpDown)c;

    //        // Add the event.
    //        NumUp.ValueChanged += new EventHandler(NumUp_ValueChanged);
    //    }

    //    void NumUp_ValueChanged(object sender, EventArgs e)
    //    {
    //        if (ValueChanged != null)
    //            ValueChanged(this, e);
    //    }
    //    protected override void OnUnsubscribeControlEvents(Control c)
    //    {
    //        // Call the base method so the basic events are unsubscribed.
    //        base.OnUnsubscribeControlEvents(c);
    //        NumericUpDown NumUp = (NumericUpDown)c;
    //        // Remove the event.
    //        NumUp.ValueChanged -= new EventHandler(NumUp_ValueChanged);
    //    }
    //    public event EventHandler ValueChanged;
    //}
    //class RouteStep
    //{
    //    public Point Location
    //    {
    //        get
    //        {
    //            return new Point(x, y);
    //        }
    //        set
    //        {
    //            x = value.X;
    //            y = value.Y;
    //        }
    //    }
    //    private int x;
    //    private int y;
    //    public string Text;
    //    public int LineWidth;
    //    public decimal stepLength;
    //    public Color Color;
    //    public Font Font;
    //    public Brush FontBrush;
    //    public Color FontColor;
    //    public bool isSelected = false;
    //    public RouteStep(Point pt)
    //    {
    //        x = pt.X;
    //        y = pt.Y;
    //        LineWidth = 3;
    //        Color = Color.Red;
    //        Text = "";
    //        Font = new Font("Times New Roman", 20);
    //        FontColor = Color.White;
    //        FontBrush = Brushes.White;
    //    }
    //    public void Move(Point pt)
    //    {
    //        x = pt.X;
    //        y = pt.Y;
    //    }
    //}
}