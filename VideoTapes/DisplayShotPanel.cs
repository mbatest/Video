using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace VideoTapes
{
    public partial class DisplayShotsPanel : UserControl
    {
        public event ShotSelectedHandler ShotSelected;
        public bool Détails { get; set; }
        public int Facteur { get; set; }
        private List<Shots> media;
        public double ImageZoomFactor { get; set; }
        int imagesPerRow;
        int startImage;
        int size = 10;

        public DisplayShotsPanel()
        {
            InitializeComponent();
            MouseWheel += DisplayPanel_MouseWheel;
            Facteur = 3;
            ImageZoomFactor = 1;
        }
        public void Init(Videos video)
        {
            this.media = video.Shots.OrderBy(s => s.Fichier)
                .ThenBy(s => s.DateShot).ToList(); 
            Videos currentVideo = media[0].Videos;
            switch (currentVideo.Mode)
            {
                case "AVC":
                    size = 16;
                    Facteur = 6;
                    break;
                case "dvsd":
                    size = 12;
                    Facteur = 3;
                    break;
            }
            startImage = 0;
            ImageZoomFactor = 1;
            Refresh();
        }
        private void DisplayPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Trouve(e);
        }
        private void Trouve(MouseEventArgs e)
        {
            if (media == null)
                return;
            int x = 0;
            int y = 0;
            int w = (int)(media[0].Largeur * ImageZoomFactor) / Facteur;
            int h = (int)(media[0].Hauteur * ImageZoomFactor) / Facteur;
            int interval = (int)(2 * size * ImageZoomFactor);
            media.ForEach(s => s.Selected = false);
            Refresh();
            for (int i = startImage; i < media.Count; i++)
            {
                Rectangle rec = new Rectangle(x, y, w, h);
                if (rec.Contains(e.Location))
                {
                    Shots s = media[i];
                    s.Selected = true;
                    Refresh();
                    if (ShotSelected != null)
                        ShotSelected(this, new ShotSelectedArgs { Shot = s });
                    Trace.WriteLine(s.Fichier);
                    return;
                }
                x += w + 10;
                if (x > Width - w)
                {
                    x = 0;
                    y += h;
                    if (Détails) y += 4 * interval;
                }
                if (y > Height)
                {
                    return;
                }
            }
        }
        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            if (media == null)
                return;
            int x = 0;
            int y = 0;
            int w = (int)(media[0].Largeur * ImageZoomFactor) / Facteur;
            int h = (int)(media[0].Hauteur * ImageZoomFactor) / Facteur;
            int fontSize = (int)(size * ImageZoomFactor);
            int interval = (int)(2 * size * ImageZoomFactor);
            Font f = new Font("Times New Roman", fontSize);
            imagesPerRow = Math.Max(1, Width / w);
            scrollPictures.Maximum = 10;
            scrollPictures.Maximum = media.Count;
            scrollPictures.Value = startImage / imagesPerRow;
            x = 0; y = 0;
            Shots s = media.FirstOrDefault(m => m.Selected);
            if (s != null)
                startImage = media.IndexOf(s);
            for (int i = startImage; i < media.Count; i++)
            {
                try
                {
                    #region Show image Data
                    scrollPictures.Value = startImage;
                    Shots clip = media[i];
                    if (clip.Selected)
                    {
                        Pen p = new Pen(new SolidBrush(Color.Red), 3);

                        e.Graphics.DrawRectangle(p, new Rectangle(x, y, w, h));
                    }
                    if (clip.Image != null)
                    {
                        MemoryStream mi = new MemoryStream(clip.Image);
                        Image imi = Image.FromStream(mi);
                        e.Graphics.DrawImage(imi, new Rectangle(x, y, w, h));
                        imi.Dispose();
                    }
                    //else
                    //{
                    //    string d = Path.GetDirectoryName(clip.FichierImage);
                    //    int ix = d.LastIndexOf(@"\");
                    //    string c = d.Substring(ix);
                    //    string fi = Path.GetFileNameWithoutExtension(clip.FichierImage);
                    //    Image im = Image.FromFile(@"E:\VideoThumbs\" + c + "\\" + fi + ".jpg");
                    //    e.Graphics.DrawImage(im, x, y, w, h);
                    //    e.Graphics.DrawRectangle(Pens.Red, x, y, w, h);
                    //}
                    if (Détails)
                    {
                        List<String> textes = new List<string>();
                        string longueur = Videos.DuréeShot((int)clip.FrameCount);
                        textes.Add(clip.DateShot?.ToLongDateString() + " " + clip.DateShot?.ToLongTimeString());
                        textes.Add(clip.FrameCount.ToString() + " Frames soit " + longueur);
                        textes.Add("Tape " + clip.Code_Bande.ToString() + " Shot : " + Path.GetFileNameWithoutExtension(clip.Fichier));
                        textes.Add(clip.Commentaire + " " + clip.Lieux?.Lieu);
                        if (clip.Largeur == 1980)
                            size = 14;
                        e.Graphics.DrawString(clip.DateShot?.ToLongDateString() + " " + clip.DateShot?.ToLongTimeString(), f, Brushes.Black, new Point(x, y + h));
                        e.Graphics.DrawString(clip.FrameCount.ToString() + " Frames soit " + longueur, f, Brushes.Black, new Point(x, y + h + interval));
                        e.Graphics.DrawString("Tape " + clip.Code_Bande.ToString() + " Shot : " + Path.GetFileNameWithoutExtension(clip.Fichier), f, Brushes.Black, new Point(x, y + h + 2 * interval));
                        e.Graphics.DrawString(clip.Commentaire + " " + clip.Lieux?.Lieu, f, Brushes.Black, new Point(x, y + h + 3 * interval));
                    }
                    x += w + 10;
                    if (x > Width - w)
                    {
                        x = 0;
                        y += h;
                        if (Détails) y += 4 * interval;
                    }
                    #endregion
                    if (y > Height)
                        return;
                }
                catch (Exception ex) { System.Diagnostics.Trace.WriteLine(ex.Message); }
            }

        }
        private void scrollPictures_Scroll(object sender, ScrollEventArgs e)
        {
            startImage = scrollPictures.Value * imagesPerRow;
            Refresh();
        }
        private void DisplayPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            media.ForEach(s => s.Selected = false);
            startImage -= (e.Delta / 120) * imagesPerRow;
            if (startImage < 0)
                startImage = 0;
            if (startImage > media.Count)
                startImage = media.Count - imagesPerRow;
            Refresh();
        }
    }
}
