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

namespace VideoTapes
{
    public partial class DisplayScenesPanel : UserControl
    {
        public event SceneSelectedHandler SceneSelected;
        public event MultiSceneSelectedHandler MultiSceneSelected;
        private List<Scenes> selectedScenes;
        public bool Détails { get; set; }
        public int Facteur { get; set; }
        private List<Scenes> scenes;
        public double ImageZoomFactor { get; set; }
        int imagesPerRow;
        int startImage;
        int nombreLignes;
        int size = 10;
        Videos currentTape;
        public static string clé = "";

        public DisplayScenesPanel()
        {
            InitializeComponent();
            MouseWheel += DisplayPanel_MouseWheel;
            Facteur = 3;
            nombreLignes = 3;
            ImageZoomFactor = 1;
        }
        public void Init(Videos video, string clef = "")
        {
            currentTape = video;
            clé = clef;
            this.scenes = video.Scenes.OrderBy(s => s.Code_Scene).ToList();
            if (scenes.Count == 0)
            {
                Refresh();
                return;
            }
            Videos currentVideo = scenes[0].Videos;
            switch (currentVideo.Mode)
            {
                case "AVC":
                    size = 16;
                    Facteur = 10;
                    break;
                case "dvsd":
                    size = 12;
                    Facteur = 8;
                    break;
            }
            selectedScenes = new List<Scenes>();
   //         if (scenes[0] != null) SceneSelected?.Invoke(this, new SceneSelectedArgs { scene = scenes[0] });

            startImage = 0;
            ImageZoomFactor = 1;
            Refresh();
        }
        public void Init(List<Scenes> scenes, string clef = "")
        {
            clé = clef;
            this.scenes = scenes;
            {
                if(scenes[0].Videos==null)
                {

                }
                Videos currentVideo = this.scenes[0].Videos;
                switch (currentVideo.Mode)
                {
                    case "AVC":
                        size = 16;
                        Facteur = 10;
                        break;
                    case "dvsd":
                        size = 12;
                        Facteur = 8;
                        break;
                }
            }
            selectedScenes = new List<Scenes>();
            startImage = 0;
            ImageZoomFactor = 1;
            Refresh();
        }
        private void DisplayPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (((ModifierKeys & Keys.Control) == Keys.Control))
            {
                if (e.Button == MouseButtons.Left)
                {                   
                    selectedScenes.Add(Trouve(e));
                }
                else if (e.Button == MouseButtons.Right)
                {
                    #region Menu contextuel
                    if (selectedScenes.Count > 0)
                    {
                        ContextMenuStrip mnu = new ContextMenuStrip();
                        ToolStripMenuItem contextMenu = null; //new ToolStripMenuItem("Split scene");
                        switch (selectedScenes.Count)
                        {
                            case 0:
                                return;
                            case 1:
                                contextMenu = new ToolStripMenuItem("Split scene");
                                break;
                            default:
                                contextMenu = new ToolStripMenuItem("Fuse scenes");
                                break;
                        }
                        contextMenu.Click += new EventHandler(ContextMenu_Click);
                        mnu.Items.Add(contextMenu);
                        string[] Menus = new string[] { "Liste", "Liste détaillée", "Liste scène sélectionnée", "Liste détaillée scène sélectionnée", "Lieu", "Titre", "Commentaire", "Mots Clés", "Personne", "Play" };

                        foreach (string s in Menus)
                        {
                            contextMenu = new ToolStripMenuItem(s);
                            contextMenu.Click += new EventHandler(ContextMenu_Click);
                            mnu.Items.Add(contextMenu);
                        }
                        mnu.Show((Control)sender, e.Location, ToolStripDropDownDirection.BelowRight);

                    }
                    #endregion
                }
            }
            else
            {
                if ((scenes != null)|(scenes.Count==0))
                {
                    scenes.ForEach(s => s.Selected = false);
                    Refresh();
                    if (selectedScenes != null)
                        selectedScenes.Clear();
                    Scenes sc = Trouve(e);
                    if (sc != null) SceneSelected?.Invoke(this, new SceneSelectedArgs { scene = sc });
                }
            }
            
        }
        private void DisplayPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (scenes == null)
                return;
            scenes.ForEach(s => s.Selected = false);
            startImage -= (e.Delta / 120) * imagesPerRow;
            if (startImage < 0)
                startImage = 0;
            if (startImage > scenes.Count)
                startImage = scenes.Count - imagesPerRow;
            Refresh();
        }
        private void ContextMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tm = (ToolStripMenuItem)sender;
            switch (tm.Text)
            {
                case "Liste":
                    StreamWriter sw = new StreamWriter(@"D:\" + currentTape.Titre + ".txt");
                    foreach (Scenes sc in scenes)
                    {
                        sw.WriteLine(sc.DateDebut + " " + sc.SequenceScene.Count + " " + sc.SequenceScene.First().ToString() + " " + sc.StartFrame + " " + sc.EndFrame + " " + sc.Titre + " " + sc.Lieux);
                    }
                    sw.Close();
                    break;
                case "Liste détaillée":
                    if (clé != "")
                        sw = new StreamWriter(@"D:\" + tm.Text + " " + "Scènes_" + clé + "_.txt");
                    else sw = new StreamWriter(@"D:\" + tm.Text + " " + currentTape.Titre + "_Selection.txt");
                    foreach (Scenes sc in scenes)
                    {
                        string file;
                        file = Tapes.md.Videos.Single(c => c.Code_Bande == sc.Code_Bande).Directory;
                        if (currentTape.Mode == "AVCHD")
                            file = file.Replace("avi", "mpg");
                        else
                            file = @"H:\Vidéos\DVRender\" + file;
                        sw.Write(file);

                        if (sc.Lieux != null)
                        {
                            sw.Write(";" + sc.Lieux.Lieu);
                            sw.Write(";" + sc.Lieux.CommentaireLieu);
                            sw.Write(";" + sc.Lieux.Villes.Nom);
                            sw.Write(";" + sc.Lieux.Villes.Nom_Chinois);

                        }
                        foreach (PrésenceScène pres in sc.PrésenceScène)
                        {
                            sw.Write(pres.Personnes.Prénom + " " + pres.Personnes.Nom + ";");
                        }
                        sw.WriteLine(";" + sc.Commentaire);
                    }
                    sw.Close();
                    break;
                case "Liste scène sélectionnée":
                case "Liste détaillée scène sélectionnée":
                    if (clé != "")
                        sw = new StreamWriter(@"D:\"+tm.Text+" " + "Scènes_" + clé + "_.txt");
                    else sw = new StreamWriter(@"D:\" + tm.Text + " " + currentTape.Titre + "_Selection.txt");
                    foreach (Scenes sc in selectedScenes)
                    {
                        string file;
                        file = Tapes.md.Videos.Single(c => c.Code_Bande == sc.Code_Bande).Directory;
                        if (currentTape.Mode == "AVCHD")
                            file = file.Replace("avi", "mpg");
                        else
                            file = @"H:\Vidéos\DVRender\" + file;
                        sw.Write(file);

                        if (sc.Lieux != null)
                        {
                            sw.Write(";" + sc.Lieux.Lieu);
                            sw.Write(";" + sc.Lieux.CommentaireLieu);
                            sw.Write(";" + sc.Lieux.Villes.Nom);
                            sw.Write(";" + sc.Lieux.Villes.Nom_Chinois);
                        }
                        foreach (PrésenceScène pres in sc.PrésenceScène)
                        {
                            sw.Write(pres.Personnes.Prénom + " " + pres.Personnes.Nom + ";");
                        }
                        sw.WriteLine(";" + sc.Commentaire);
                        if(tm.Text.Contains("détaillée"))
                        {
                            foreach (SequenceScene ses in sc.SequenceScene)
                            {
                                file = ses.Shots.Fichier;
                                if (currentTape.Mode == "AVCHD")
                                    file = file.Replace("avi", "mpg");
                                else
                                    file = @"H:\Vidéos\DVRender\" + file.Replace("avi", "mpg");

                                sw.WriteLine(" " + file);
                            }
                        }
                    }
                    sw.Close();
                    break;
                case "Lieu":
                    break;
                case "Personne":
                    break;
                case "Play":
                    break;
            }
            MultiSceneSelected?.Invoke(this, new MultiSceneSelectedArgs { scenes = selectedScenes, type = ((ToolStripMenuItem)sender).Text });
        }

        private Scenes Trouve(MouseEventArgs e)
        {

            if ((scenes == null)|(scenes.Count==0))
                return null;
            int x = 0;
            int y = 0;
            int w = (int)(scenes[0].Videos.Largeur * ImageZoomFactor) / Facteur;
            int h = (int)(scenes[0].Videos.Hauteur * ImageZoomFactor) / Facteur;
            int interval = (int)(2 * size * ImageZoomFactor);
            for (int i = startImage; i < scenes.Count; i++)
            {
                Rectangle rec = new Rectangle(x, y, w, h);
                if (rec.Contains(e.Location))
                {
                    Scenes s = scenes[i];
                    s.Selected = true;
                    Refresh();
                    return s;
                }
                x += w ;
                if (x > Width - w)
                {
                    x = 0;
                    y += h;
                    if (Détails) y += nombreLignes * interval;
                }
                if (y > Height)
                {
                    return null;
                }
            }
            return null;
        }
        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            if ((scenes == null) || (scenes.Count == 0))
                return;
            int x = 0;
            int y = 0;
            int largeur = (int)(scenes[0].Videos.Largeur * ImageZoomFactor) / Facteur;
            int hauteur = (int)(scenes[0].Videos.Hauteur * ImageZoomFactor) / Facteur;
            size = 6;
            int fontSize = (int)(size * ImageZoomFactor);
            int interval = (int)(2 * size * ImageZoomFactor);
            Font f = new Font("Times New Roman", fontSize);
            imagesPerRow = Math.Max(1, Width / largeur);
            scrollPictures.Maximum = scenes.Count;
            scrollPictures.Value = startImage / imagesPerRow;
            x = 0; y = 0;
            //Scenes s = scenes.FirstOrDefault(m => m.Selected);
            //if (s != null)
            //    startImage = scenes.IndexOf(s);
            for (int i = startImage; i < scenes.Count; i++)
            {
                try
                {
                    #region Show image Data
                    scrollPictures.Value = startImage;
                    Scenes scene = scenes[i];
                    if (scene.Selected)
                    {
                        Pen p = new Pen(new SolidBrush(Color.Red), 3);
                        e.Graphics.DrawRectangle(p, new Rectangle(x, y, largeur, hauteur));
                    }
                    if (scene.Image != null)
                    {
                        MemoryStream mi = new MemoryStream(scene.Image);
                        Image imi = Image.FromStream(mi);
                        e.Graphics.DrawImage(imi, new Rectangle(x, y, largeur, hauteur));
                        imi.Dispose();
                        GC.Collect();
                    }
                    else
                    {
                        if (scene.SequenceScene.Count > 0)
                        {
                            MemoryStream mi = new MemoryStream(scene.SequenceScene.First().Shots.Image);
                            Image imi = Image.FromStream(mi);
                            e.Graphics.DrawImage(imi, new Rectangle(x, y, largeur, hauteur));
                            imi.Dispose();
                            GC.Collect();
                        }
                    }
                    Détails = true;
                    List<string> textes = new List<string>
                    {
                        scene.FrameCount.ToString() + " Frames soit " + Videos.DuréeShot((int)scene.FrameCount),
                        scene.Titre + " ",
                        scene.Lieux?.Villes.Nom + " " + scene.Lieux?.Lieu
                    };
                    string deb = scene.SequenceScene.FirstOrDefault().Shots.DateShot.Value.ToShortDateString();
                    if(scene.SequenceScene.First().Shots.Fichier.Contains("Clip"))
                    {
                        string s = Path.GetFileNameWithoutExtension(scene.SequenceScene.First().Shots.Fichier);
                        int ind = s.IndexOf("Clip ") + 4;
                        s = s.Substring(ind, s.Length-ind);
                        string ll = Path.GetFileNameWithoutExtension(scene.SequenceScene.Last().Shots.Fichier);
                        ind = ll.IndexOf("Clip ") + 4;
                        ll = ll.Substring(ind, ll.Length - ind);
                        textes.Add(deb+ " " + scene.SequenceScene.Count.ToString() + " clips " + s + "-" + ll);
                    }
                    else
                    {
                        string s = Path.GetFileNameWithoutExtension(scene.SequenceScene.First().Shots.Fichier);
                        string ll = Path.GetFileNameWithoutExtension(scene.SequenceScene.Last().Shots.Fichier);
                        textes.Add(deb + " " + scene.SequenceScene.Count.ToString() + " clips " + s + "-" + ll);
                    }
                    nombreLignes = 0; ;
                    if (Détails)
                    {
                        foreach(string s in textes)
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
                        if (Détails) y += nombreLignes * interval;
                    }
                    #endregion
                    if (y > Height)
                        return;
                }
                catch (Exception ex) { System.Diagnostics.Trace.WriteLine(ex.Message); }
            }
        }
        private void ScrollPictures_Scroll(object sender, ScrollEventArgs e)
        {
            startImage = scrollPictures.Value * imagesPerRow;
            Refresh();
        }
    }
}
