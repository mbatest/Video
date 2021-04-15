using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
/// <summary>
/// Compléments aux classes d'accès à la base de données
/// </summary>
namespace VideoTapes
{
    public partial class Videos
    {
        public static TimeSpan DuréeClip(int frameCount)
        {
            double length = frameCount / 25;
            int sec = (int)length;
            int min = sec / 60;
            int h = min / 60;
            min = min % 60;
            sec = sec % 60;
            int nbfr = frameCount % 25;
            int j = h / 24;
            h = h % 24;
            return new TimeSpan(j, h, min, sec);
        }
        public static string DuréeClipString(int frameCount)
        {
            double length = frameCount / 25;
            int sec = (int)length;
            int min = sec / 60;
            int h = min / 60;
            min = min % 60;
            sec = sec % 60;
            int nbfr = frameCount % 25;
            int j = h / 24;
            h = h % 24;
            string jour = " jour";
            if (j > 1) jour += "s "; else jour += " ";
            string heure = " heure";
            if (h > 1) heure += "s "; else heure += " ";
            if (j > 0)
                return j.ToString() + jour + h.ToString() + heure + min.ToString() + " mn " + sec.ToString() + " s " + ((int)(nbfr)).ToString() + " F";
            else if (h > 0)
                return h.ToString() + heure + min.ToString() + " mn " + sec.ToString() + " s " + ((int)(nbfr)).ToString() + " F";
            else if (min > 0)
                return min.ToString() + " mn " + sec.ToString() + " s " + ((int)(nbfr)).ToString() + " F";
            else
                return sec.ToString() + " s " + ((int)(nbfr)).ToString() + " F";
        }
        public int Frames => Shots.Sum(s => s.FrameCount).Value;
        public string Durée => DuréeClip(Shots.Sum(s => s.FrameCount).Value).ToString();
        public override string ToString()
        {
             return Ordre.ToString("D3")+ " : " + Titre /*+ nbShots.ToString() + " " + durée*/;
        }
        public string BasePath()
        {
            string basePath="";
            switch (Codec)
            {
                case "dvsd":
                    basePath = Tapes.Disque + @"\Vidéos\DVRender\";
                    break;
                case "AVCHD":
                    basePath = Tapes.Disque + @"\Vidéos\HDWRITER\";
                    break;
            }
            return basePath;
        }
    }
    public partial class Pays
    {
        public override string ToString()
        {
            return Nom_Pays;
        }
    }
    public partial class Villes
    {
        public override string ToString()
        {
            return Nom + " " + Pays.Nom_Pays;
        }
    }
    public partial class Lieux
    {
        public override string ToString()
        {
            return Villes.Nom + " " + Lieu;
        }
    }
    public partial class Keywords
    {
        public override string ToString()
        {
            return Keyword;
        }
    }
    public partial class Personne
    {
        public override string ToString()
        {
            return Prénom + " " + Nom;    
        }
    }
    public partial class Scenes
    {
        [NotMapped]
        public bool Selected { get; set; }
        public int FrameCount => SequenceScene.Sum(c => c.Shots.FrameCount).Value;
        public int Start => (int)SequenceScene.OrderBy(c => c.Shots.StartFrame).First().Shots.StartFrame;
        public int End => (int)SequenceScene.OrderBy(c => c.Shots.StartFrame).Last().Shots.EndFrame;
        public List<string> textes;
        public override string ToString()
        {
            return FrameCount.ToString() + " " + this.Commentaire + " " + StartFrame.ToString() + " " + EndFrame.ToString() + " " + (EndFrame - StartFrame).ToString();
        } 
        public void ShowImage(PaintEventArgs e, ref int x, ref int y, int largeur, int hauteur, int interval, Font f, int Width)
        {
            #region Show image Data
            if (Selected)
            {
                Pen p = new Pen(new SolidBrush(Color.Red), 3);
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, largeur, hauteur));
            }
            if (Image != null)
            {
                MemoryStream mi = new MemoryStream(Image);
                Image imi = System.Drawing.Image.FromStream(mi);
                e.Graphics.DrawImage(imi, new Rectangle(x, y, largeur, hauteur));
                imi.Dispose();
                GC.Collect();
            }
            else
            {
                if (SequenceScene.Count > 0)
                {
                    MemoryStream mi = new MemoryStream(SequenceScene.OrderBy(c => c.Code_Shot_Scene).First().Shots.Image);
                    Image imi = System.Drawing.Image.FromStream(mi);
                    e.Graphics.DrawImage(imi, new Rectangle(x, y, largeur, hauteur));
                    imi.Dispose();
                    GC.Collect();
                }
            }
            #region Crée le texte des détails
            textes = new List<string>
                    {
                        Titre,
                        Commentaire,
                        Lieux?.Villes.Nom + " " + Lieux?.Lieu,
                        " Début scène : " + Videos.DuréeClipString((int)StartFrame),
                        FrameCount.ToString() + " Frames, ",
                        "soit " + Videos.DuréeClipString(FrameCount)
            };
            if (SequenceScene.Count > 0)
            {
                string deb = SequenceScene.FirstOrDefault().Shots.DateShot.Value.ToShortDateString();
                string s = SequenceScene.OrderBy(c => c.Shots.Fichier).First().Shots.NuméroClip();
                string ll = SequenceScene.OrderBy(c => c.Shots.Fichier).Last().Shots.NuméroClip();
                textes.Insert(1,(deb + " " + SequenceScene.Count.ToString() + " clips " + s + "-" + ll));
            }
            #endregion
            int nombreLignes = 0; 
            if (DisplayScenesPanel.Détails)
            {
                foreach (string s in textes)
                {
                    e.Graphics.DrawString(s, f, Brushes.Black, new Point(x, y + hauteur + nombreLignes * interval));
                    nombreLignes++;
                }
            }
            x += largeur;
            if (x > Width - largeur)
            {
                x = 0;
                y += hauteur;
                if (DisplayScenesPanel.Détails) y += textes.Count * interval;
            }
            #endregion
        }
        public DateTime Début { get { return (DateTime) SequenceScene.First().Shots.DateShot; } }
        #region Sequence
        public void AddShot(Shots s)
        {
            SequenceScene sq = new SequenceScene { Shots = s, Scenes = this };
            if(SequenceScene.Where(c => c.Shots == s).Count()==0)
                SequenceScene.Add(sq);
        }
        #endregion
        #region Personnes
        public void AddPerson(Personne p) {
            if (PrésenceScène == null)
                PrésenceScène = new List<PrésenceScène>();
            PrésenceScène ps = new PrésenceScène { Scenes = this, Personnes = p };
            if (PrésenceScène.Where(pz=>pz.Personnes==p).Count()==0)
                PrésenceScène.Add(ps);
        }
        public void DeletePersonne(Personne p)
        {
            PrésenceScène.ToList().RemoveAll(ps => ps.Personnes == p);
        }
        #endregion
        #region Mots-clés
        public void AddKeyword(Keywords k) {
            if (KeywordScene == null)
                KeywordScene = new List<KeywordScene>();
            KeywordScene kw = new KeywordScene { Scenes = this, Keywords = k };
            if (KeywordScene.Where(kz => kz.Keywords == k).Count() == 0)
                KeywordScene.Add(kw);
        }
        public void DeleteKeyword(Keywords kw)
        {
            KeywordScene.ToList().RemoveAll(ks => ks.Keywords == kw);
        }
        #endregion
    }
    public partial class Shots
    {
        [NotMapped]
        public bool Selected { get; set; }
        [NotMapped]
        public bool Current { get; set; }
        [NotMapped]
        public int FrameStart { get; set; }

        private float GetImageRatio()
        {
            if (Codec == "dvsd")
                return (float)(4 / 3);
            else return (float)(16 / 9);
        }
        public override string ToString()
        {
            return StartFrame.ToString() + " " + EndFrame.ToString()+" "+ " "+ Fichier;
        }
        //public string Nom()
        //{
        //    string file;
        //    if (Videos.Codec == "AVCHD")
        //        file = Fichier;
        //    else
        //        file = @"H:\Vidéos\DVRender\" + Fichier;
        //    return file;
        //}
        public string NuméroClip()
        {
            string n = "";
            if (Fichier.Contains("Clip")) // Clips dvsd
            {
                n = Path.GetFileNameWithoutExtension(Fichier);
                n = n.Substring(n.Length - 3);
            }
            else // Clips AVCHD
                n = Path.GetFileNameWithoutExtension(SequenceScene.OrderBy(c => c.Code_Shot_Scene).First().Shots.Fichier);
           return n;
        }
        public void Dessine(Graphics g, RectangleF rect)
        {
            //float imageRatio = (float)(16 / 9);
            //if (Codec == "dvsd")
            //    imageRatio = (float)(4 / 3);
            RectangleF r = new RectangleF(rect.Left, rect.Top, Math.Min(rect.Width, rect.Height * GetImageRatio()), rect.Height);
            using (MemoryStream mes = new MemoryStream(Image))
            {
                Image image = System.Drawing.Image.FromStream(mes);
                g.DrawImage(image, r);
                image.Dispose();
            }
            float x = rect.Left;
            float y = rect.Top;
            float w = rect.Width;
            float h = rect.Height;
            if (Selected)
            {
                g.DrawRectangle(new Pen(Brushes.Red, 1), x, y, w, h);
            }
            else
                g.DrawRectangle(Pens.Black, x, y, w, h);
            if (Current)
            {
                g.DrawRectangle(new Pen(Brushes.Red, 5), x, y, w - 2, h);
            }
            g.DrawString(Videos.DuréeClip((int)EndFrame).ToString(), new Font("Arial", 5), Brushes.Orange, x + w, y + h);
        }
    }
    public partial class SequenceScene
    {
        public override string ToString()
        {
            return Shots.Fichier+ " " + Scenes.Commentaire;
        }
    }
 }
