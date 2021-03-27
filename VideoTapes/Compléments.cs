using DirectShowLib.DES;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Compléments aux classes d'accès à la base de données
/// </summary>
namespace VideoTapes
{
    public partial class Videos
    {
        //public static Shots GetShot(Videos currentVideotape, int Largeur, int Hauteur, string f, out string fichierImage)
        //{
        //    fichierImage = currentVideotape.Directory.Replace(@"H:\Vidéos\HDWRITER", @"E:\VideoThumbs") + @"\" + Path.GetFileNameWithoutExtension(f) + ".jpg";
        //    FileInfo fi = new FileInfo(f);
        //    MediaDet mdt = new MediaDet
        //    {
        //        Filename = f
        //    };
        //    int fcount = (int)(mdt.StreamLength * 25);
        //    return new Shots
        //    {
        //        Videos = currentVideotape,
        //        Codec = currentVideotape.Mode,
        //        Fichier = f,
        //        FichierImage = fichierImage,
        //        StartFrame = 0,
        //        EndFrame = fcount,
        //        FrameCount = fcount,
        //        DateShot = fi.LastWriteTime,
        //        Largeur = Largeur,
        //        Hauteur = Hauteur
        //    };
        //}
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
        public static string DuréeShot(int frameCount)
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
            //TimeSpan ts = new TimeSpan(0, 0, min, sec);
            if (j > 0)
                return j.ToString() + jour + h.ToString() + heure + min.ToString() + " mn " + sec.ToString() + " s " + ((int)(nbfr)).ToString() + " F";
            else if (h > 0)
                return h.ToString() + heure + min.ToString() + " mn " + sec.ToString() + " s " + ((int)(nbfr)).ToString() + " F";
            else if (min > 0)
                return min.ToString() + " mn " + sec.ToString() + " s " + ((int)(nbfr)).ToString() + " F";
            else
                return sec.ToString() + " s " + ((int)(nbfr)).ToString() + " F";
        }
        public int Frames { get { return Shots.Sum(s => s.FrameCount).Value; } }
        public string Durée
        {
            get
            {
                int frCount = Shots.Sum(s => s.FrameCount).Value;
                return DuréeClip(frCount).ToString();
            }
        }
        public override string ToString()
        {
             return Ordre.ToString("D3")+ " : " + Titre /*+ nbShots.ToString() + " " + durée*/;
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
        public int FrameCount
        {
            get
            {
                return SequenceScene.Sum(c => c.Shots.FrameCount).Value;
            }
        }
        public override string ToString()
        {
            return FrameCount.ToString() + " "+ this.Commentaire + " "+StartFrame.ToString()+" "+EndFrame.ToString()+ " " +(EndFrame-StartFrame).ToString();
        }
        public DateTime Début { get { return (DateTime) SequenceScene.First().Shots.DateShot; } }
        #region Sequence
        public void AddShotToScene(Shots s)
        {
            SequenceScene sq = new SequenceScene { Shots = s, Scenes = this };
            if(SequenceScene.Where(c => c.Shots == s).Count()==0)
                SequenceScene.Add(sq);
        }
        #endregion
        #region Personnes
        public void AddPersonToScene(Personne p) {
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
        public void AddKeywordToScene(Keywords k) {
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
        public override string ToString()
        {
            return StartFrame.ToString() + " " + EndFrame.ToString()+" "+ " "+ Fichier;
        }
        public void Dessine(Graphics g, RectangleF rect)
        {
            float imageRatio = (float)(16 / 9);
            if (Codec == "dvsd")
                imageRatio = (float)(4 / 3);
            RectangleF r = new RectangleF(rect.Left, rect.Top, Math.Min(rect.Width, rect.Height * imageRatio), rect.Height);
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
