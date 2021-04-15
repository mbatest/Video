using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace VideoTapes
{
    public partial class TimeLine : UserControl
    {
        public event ShotSelectedHandler ShotSelected;
        public event PlayerHandler Pause;
        public event PlayerHandler Stop;

        Scenes currentScene;
        List<Shots> shots;
        float débutDessin;
        #region Paramètres dessin
        int trackHeight = 90;
        int mn = 15;
        int sec = 8;
        float pixelsParSecondes;
        int topTrack;
        int ligneGraduation;
        int LongueurTimeline;
        List<float> shotsWidth;
        public int CurrentPosition { get; set; }
        public int CurrentTime { get; set; }
        Videos currentVideo;
        #endregion
        public TimeLine()
        {
            InitializeComponent();
            topTrack = toolStrip.Height + 2;
            MouseWheel += TimeLine_MouseWheel;
            zoomIn.Click += ZoomIn_Click;
            zoomOut.Click += ZoomOut_Click;
        }
        public void Init(Videos video)
        {
            trackHeight = 90;
            currentVideo = video;
            pixelsParSecondes = 5; // 1 pixel pour 5 frames, soit 5 pixels pour 1 seconde
            shots = video.Shots/*.OrderBy(s => s.DateShot)               .ThenBy(s => s.StartFrame)*/.ToList();
            shotsWidth = new List<float>();
            int frameStart = 0;
            shots.ForEach(s =>
            {
                shotsWidth.Add((int)s.FrameCount / pixelsParSecondes);
                s.FrameStart = frameStart;
                frameStart += (int)s.FrameCount;
            });
            LongueurTimeline = video.Frames;
            topTrack = toolStrip.Height + 2;
            ligneGraduation = topTrack + trackHeight + 25;
            débutDessin = 0;
            hScrollBar.Maximum = (int)(LongueurTimeline / pixelsParSecondes);
            toolStripStatusLabel1.Text = "";
            CurrentTime = 0;
            CurrentPosition = 0;
            currentScene = video.Scenes.OrderBy(c => c.StartFrame).First();
            débutDessin = 0;
            SetStart(currentScene);
            Refresh();
        }
        public void SetStart(Scenes scene)
        {
            currentScene = scene;
            if (scene.SequenceScene.Count > 0)
            {
                Shots shot = scene.SequenceScene.First().Shots;
                float début = 0;
                foreach (Shots s in shots)
                {
                    if (s == shot)
                    {
                        débutDessin = +(int)shot.StartFrame;
                        break;
                    }
                    début += (int)s.FrameCount / pixelsParSecondes;
                }
                Refresh();
            }
        }
        public void SetStart(Shots shot)
        {
            if (shot.Current)
            {
                débutDessin = -shot.FrameStart / pixelsParSecondes; ;
            }
            Refresh();
        }
        private void TimeLine_MouseWheel(object sender, MouseEventArgs e)
        {
            débutDessin -= (float)e.Delta * 2;
            if (débutDessin > 0)
                débutDessin = 0;
            if (débutDessin > (int)(LongueurTimeline / pixelsParSecondes) - Width)
                débutDessin = (int)(LongueurTimeline / pixelsParSecondes) - Width;
            if (!(-débutDessin > hScrollBar.Maximum))
                hScrollBar.Value = -(int)débutDessin;
            Refresh();
        }
        private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            débutDessin = -e.NewValue * 3;
            Refresh();
        }
        private void TimeLine_Paint(object sender, PaintEventArgs e)
        {
            if (shots == null)
                return;
            PointF débutVignette = new PointF(débutDessin, topTrack);
            #region Encadrement
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, topTrack, Width, trackHeight));
            #endregion
            int totalFrame = 0;
            #region Affichage shots
            foreach (Shots s in shots.OrderBy(c=>c.Fichier))
            {
                float largeurClipCourant = (int)s.FrameCount / pixelsParSecondes;
                RectangleF rect = new RectangleF(débutVignette, new System.Drawing.SizeF(largeurClipCourant, trackHeight));
                if (rect.Contains(new PointF(débutVignette.X + 1, topTrack + 5)))
                {
                    s.Dessine(e.Graphics, rect);
                    if (s.Current)
                    {
                        toolStripStatusLabel1.Text = s.Fichier + " " + s.DateShot.ToString() + " " + Videos.DuréeClip((int)s.FrameCount) + " " + s.FrameCount.ToString();
                    }
                    débutVignette.X += largeurClipCourant;
                    if (débutVignette.X > Width /*LongueurTimeline / pixelsParSecondes*/)
                        break;
                }
                totalFrame += (int)s.FrameCount;
            }
            #endregion
            #region Affiche le curseur
            e.Graphics.DrawLine(Pens.Black, new PointF(CurrentPosition * pixelsParSecondes, topTrack), new PointF(CurrentPosition * pixelsParSecondes, topTrack + trackHeight + 35));
            string temps = (CurrentTime / 60).ToString("d2") + ":" + (CurrentTime % 60).ToString("d2");
            e.Graphics.DrawString(temps, new Font("Arial", 8), Brushes.Black, new PointF(CurrentPosition * pixelsParSecondes, topTrack + trackHeight + 35));
            #endregion
            #region Graduation
            ligneGraduation = topTrack + trackHeight + 35;
            e.Graphics.DrawLine(Pens.Black, 0, ligneGraduation, Width, ligneGraduation);
            int x = 0;
            int heures = 0;
            int minutes = 0;
            int dizaines = 0;
            TimeSpan ts = Videos.DuréeClip(LongueurTimeline);
            //while (x < LongueurTimeline)
            //{
            //    int j = (x + (int)débutDessin);
            //    if (x % (int)(60 * pixelsParSecondes) == 0) //minutes
            //    {
            //        e.Graphics.DrawLine(Pens.Black, j, ligneGraduation, j, ligneGraduation - mn);
            //        e.Graphics.DrawString(minutes.ToString() + " '", new Font("Arial", 8), Brushes.Blue, new Point(j - 4, ligneGraduation - 20 - 10));
            //        minutes++;
            //        dizaines = 0;
            //    }
            //    else if (x % (int)(10 * pixelsParSecondes) == 0) // dizaines de secondes
            //    {
            //        dizaines += 10;
            //        e.Graphics.DrawLine(Pens.Black, j, ligneGraduation, j, ligneGraduation - sec);
            //        e.Graphics.DrawString(dizaines.ToString() + " \"", new Font("Arial", 6), Brushes.Red, new Point(j - 4, ligneGraduation - sec - 10));
            //    }
            //    else
            //        e.Graphics.DrawLine(Pens.Black, j, ligneGraduation, j, ligneGraduation - sec);
            //    x += (int)(10 * pixelsParSecondes);
            //    if ((x + (int)débutDessin) > Width)
            //        break;
            //    if (heures > ts.Hours)
            //        return;
            //    if ((minutes - 1) * 60 + dizaines > ts.TotalSeconds)
            //        return;
            //}
            while (x < LongueurTimeline)
            {
                int j = (int)((x * 25) / pixelsParSecondes) + (int)débutDessin;
                if (x % 60 == 0) //minutes
                {
                    e.Graphics.DrawLine(Pens.Black, j, ligneGraduation, j, ligneGraduation - mn);
                    e.Graphics.DrawString(minutes.ToString() + " '", new Font("Arial", 8), Brushes.Blue, new Point(j - 4, ligneGraduation - 20 - 10));
                    minutes++;
                    dizaines = 0;
                }
                else if (x % 10 == 0) // dizaines de secondes
                {
                    dizaines += 10;
                    e.Graphics.DrawLine(Pens.Black, j, ligneGraduation, j, ligneGraduation - sec);
                    e.Graphics.DrawString(dizaines.ToString() + " \"", new Font("Arial", 6), Brushes.Red, new Point(j - 4, ligneGraduation - sec - 10));
                }
                else
                    e.Graphics.DrawLine(Pens.Black, j, ligneGraduation, j, ligneGraduation - sec);
                x += 10;
                if ((x + (int)débutDessin) > Width)
                    break;
                if (heures > ts.Hours)
                    return;
                if ((minutes - 1) * 60 + dizaines > ts.TotalSeconds)
                    return;
            }
            #endregion
        }
        private void TimeLine_MouseDown(object sender, MouseEventArgs e)
        {
            if (shots == null)
                return;
            PointF startPoint = new PointF(débutDessin, topTrack);
            shots.ForEach(s => { s.Selected = false; s.Current = false; });
            Refresh();
            List<Shots> sh = new List<Shots>();
            if (currentScene == null)
                return;
            currentScene.SequenceScene.ToList().ForEach(c => sh.Add(c.Shots));
            for (int i = 0; i < shotsWidth.Count; i++)
            {
                RectangleF rect = new RectangleF(startPoint, new SizeF(shotsWidth[i], trackHeight));
                if (rect.Contains(e.Location))
                {
                    Shots s = shots[i];
                    s.Selected = true;
                    Refresh();
                    ShotSelected?.Invoke(this, new ShotSelectedArgs { Shot = s });
                    break;
                }
                startPoint.X += shotsWidth[i];
            }
        }
        private void TimeLine_MouseMove(object sender, MouseEventArgs e)
        {
            if (shots == null)
                return;
            //PointF startPoint = new PointF(startPaint, topTrack);
            //shots.ForEach(s => s.Selected = false);
            //for (int i = 0; i < shotsWidth.Count; i++)
            //{
            //    RectangleF rect = new RectangleF(startPoint, new SizeF(shotsWidth[i], trackHeight));
            //    if (rect.Contains(e.Location))
            //    {
            //        Shots s = shots[i];
            //        s.Selected = true;
            //        toolStripStatusLabel1.Text = s.Fichier + " " + s.DateShot.ToString() + " " + Videos.DuréeClip((int)s.FrameCount) +" "+ s.FrameCount.ToString() ;
            //        Refresh();
            //        break;
            //    }
            //    startPoint.X += shotsWidth[i];
            //}
        }
        private void Bigger_Click(object sender, EventArgs e)
        {
            pixelsParSecondes *= 1.4f;
            shotsWidth.Clear();
            shots.ForEach(s => shotsWidth.Add((int)s.FrameCount / pixelsParSecondes));
            Refresh();
        }
        private void Smaller_Click(object sender, EventArgs e)
        {
            pixelsParSecondes /= 1.4f;
            shotsWidth.Clear();
            shots.ForEach(s => shotsWidth.Add((int)s.FrameCount / pixelsParSecondes));
            Refresh();
        }
        private void ZoomOut_Click(object sender, EventArgs e)
        {
            trackHeight -= 5;
            pixelsParSecondes *= 2f;
            shotsWidth.Clear();
            shots.ForEach(s => shotsWidth.Add((int)s.FrameCount / pixelsParSecondes));
            Refresh();
        }
        private void ZoomIn_Click(object sender, EventArgs e)
        {
            trackHeight += 5;
            pixelsParSecondes /= 2f;
            shotsWidth.Clear();
            shots.ForEach(s => shotsWidth.Add((int)s.FrameCount / pixelsParSecondes));
            Refresh();
        }
        private void Play_Click(object sender, EventArgs e)
        {
            List<Shots> sh = new List<Shots>();
            CurrentPosition = 0;
            CurrentTime = 0;
            débutDessin = 0;
            if (currentScene != null)
            {
                currentScene.SequenceScene.OrderBy(c=>c.Shots.Fichier).ToList().ForEach(c => sh.Add(c.Shots));
                CurrentPosition = (int) sh.OrderBy(c => c.StartFrame).First().StartFrame/25;
                ShotSelected?.Invoke(this, new ShotSelectedArgs { Shots = sh });
            }
            else
            {
                ShotSelected?.Invoke(this, new ShotSelectedArgs { Shots = currentVideo.Shots.ToList() });
            }
        }
        private void Pause_Click(object sender, EventArgs e)
        {
            Pause?.Invoke(this, new PlayerArgs { Pause = true, Stop = false });
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            Stop?.Invoke(this, new PlayerArgs { Pause = false, Stop = true });
        }
        private void CouperToolStripButton_Click(object sender, EventArgs e)
        {

        }
        private void Export_Click(object sender, EventArgs e)
        {
            string description = "";
            if (DisplayScenesPanel.clé != "")
                description = DisplayScenesPanel.clé;
            List<Shots> shotsSD = shots.Where(c => c.Codec == "dvsd").ToList() ;
            if (shotsSD.Count > 0)
            {
                string fileExport = @"D:\Shots SD avec " + description + ".txt";
                StreamWriter sw = new StreamWriter(fileExport);
                foreach (Shots u in shotsSD)
                {
                    sw.Write(@"H:\Vidéos\DVRender\" + u.Fichier.Replace("avi", "mpg"));
                    if (u.Lieux != null)
                    {
                        sw.Write(";" + u.Lieux.Lieu);
                        sw.Write(";" + u.Lieux.CommentaireLieu);
                        sw.Write(";" + u.Lieux.Villes.Nom);
                        sw.Write(";" + u.Lieux.Villes.Nom_Chinois);
                    }
                    else sw.Write(";;;;");
                    sw.WriteLine(";" + u.Commentaire);
                }
                sw.Close();
            }
            List<Shots> shotsHD = shots.Where(c => c.Codec == "AVCHD").ToList();
            if (shotsHD.Count > 0)
            {
                string fileExportHD = @"D:\Shots HD avec " + description + ".txt";
                StreamWriter swhd = new StreamWriter(fileExportHD);
                foreach (Shots u in shotsHD)
                {
                    //if (!u.Fichier.Contains("HDWRITER"))
                    //    u.Fichier = @"H:\Vidéos\HDWRITER\" + u.Fichier;
                    swhd.Write(u.Fichier.Replace("G:", "H:"));
                    if (u.Lieux != null)
                    {
                        swhd.Write(";" + u.Lieux.Lieu);
                        swhd.Write(";" + u.Lieux.CommentaireLieu);
                        swhd.Write(";" + u.Lieux.Villes.Nom);
                        swhd.Write(";" + u.Lieux.Villes.Nom_Chinois);
                    }
                    else swhd.Write(";;;;");
                    swhd.WriteLine(";" + u.Commentaire);

                }
                swhd.Close();
            }
        }

        private void PlayAll_Click(object sender, EventArgs e)
        {
            ShotSelected?.Invoke(this, new ShotSelectedArgs { Shots = currentVideo.Shots.ToList() });
        }
    }
}
