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
        public static bool Détails { get; set; }
        public int Facteur { get; set; }
        public double ImageZoomFactor { get; set; }
        private int imagesPerRow;
        private int départImage = 0;
        private int size = 10;
        private Videos currentTape;
        public static string clé = "";
        private List<Scenes> selectedScenes;
        private List<Scenes> scenes;
        public DisplayScenesPanel()
        {
            InitializeComponent();
            MouseWheel += DisplayPanel_MouseWheel;
            Facteur = 3;
            ImageZoomFactor = 1;
            DoubleBuffered = true;
        }
        public void Init(Videos video, string clef = "")
        {
            clé = clef;
            currentTape = video;
            if (video.Scenes.Count == 0)
            {
                Refresh();
                return;
            }
            SetCodec(video);
            scenes = video.Scenes.OrderBy(c=>c.StartFrame).ToList();
            départImage = 0;
            //         if (scenes[0] != null) SceneSelected?.Invoke(this, new SceneSelectedArgs { scene = scenes[0] });
            Refresh();
        }
        public void Init(List<Scenes> scenes, string clef = "")
        {
            clé = clef;
            this.scenes = scenes;
            SetCodec(this.scenes[0].Videos);
            Refresh();
        }
        private void SetCodec(Videos currentVideo)
        {
            switch (currentVideo.Codec)
            {
                case "AVCHD":
                    size = 16;
                    Facteur = 10;
                    break;
                case "dvsd":
                    size = 12;
                    Facteur = 8;
                    break;
            }
            selectedScenes = new List<Scenes>();
            ImageZoomFactor = 1;
        }
        private void DisplayPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (scenes != null)
            {
                Scenes sceneCourante = TrouveScène(e);// Trouve(e);
                if (sceneCourante != null) SceneSelected?.Invoke(this, new SceneSelectedArgs { scene = sceneCourante });
                if (e.Button == MouseButtons.Left)
                {
                    if (((ModifierKeys & Keys.Control) == Keys.Control))
                    { }
                    else
                    {
                        scenes.ForEach(s => s.Selected = false);
                        if (sceneCourante != null) sceneCourante.Selected = true;
                        if (selectedScenes != null)
                            selectedScenes.Clear();
                        Refresh();
                    }
                     selectedScenes.Add(sceneCourante);
                    if (sceneCourante != null) SceneSelected?.Invoke(this, new SceneSelectedArgs { scene = sceneCourante });
                }
                else if (e.Button == MouseButtons.Right)
                {
                    #region Menu contextuel
                    ContextMenuStrip mnu = new ContextMenuStrip();
                    ToolStripMenuItem contextMenu = null;
                    switch (selectedScenes.Count)
                    {
                        case 0:
                            return;
                        case 1:
                            contextMenu = new ToolStripMenuItem("Split scene");
                            //Scenes sceneCourante =sc;
                           if (sceneCourante.Lieux!=null)     mnu.Items.Add(sceneCourante.Lieux.ToString());
                            //mnu.Items.Add(sceneCourante.Titre);
                            //mnu.Items.Add(sceneCourante.Commentaire);
                            //mnu.Items.Add("-");
                            sceneCourante.textes.ForEach(c => mnu.Items.Add(c));
                            mnu.Items.Add("-");
                            foreach (PrésenceScène pr in sceneCourante.PrésenceScène)
                            {
                                mnu.Items.Add(pr.Personnes.Prénom + " " + pr.Personnes.Nom);
                            }
                            if (sceneCourante.PrésenceScène.Count > 0) mnu.Items.Add("-");
                            foreach (KeywordScene pr in sceneCourante.KeywordScene)
                            {
                                mnu.Items.Add(pr.Keywords.Keyword);
                            }
                            if (sceneCourante.KeywordScene.Count > 0) mnu.Items.Add("-");
                            break;
                        default:
                            contextMenu = new ToolStripMenuItem("Fuse scenes");
                            break;
                    }
                    contextMenu.Click += new EventHandler(ContextMenu_Click);
                    mnu.Items.Add(contextMenu);
                    string[] Menus = new string[] { "Liste", "Liste détaillée", "Liste scène sélectionnée", "Liste détaillée scène sélectionnée", "-", "Play" };
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
        private void DisplayPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (scenes == null)
                return;     
            scenes.ForEach(s => s.Selected = false);
            départImage += (e.Delta / 5);
            scrollPictures.Refresh();
            if(départImage >=scrollPictures.Maximum)
            {
                return;
            }
            if (départImage < - scrollPictures.Maximum)
                return;
      //      scrollPictures.Value =  départImage;
            Refresh();
        }
        private void ScrollPictures_Scroll(object sender, ScrollEventArgs e)
        {
            if ((e.NewValue > scrollPictures.Maximum) | (e.NewValue < scrollPictures.Minimum)) return;
            départImage += scrollPictures.Value;//(e.NewValue - e.OldValue);// * imagesPerRow;
       //     scrollPictures.Value += (e.NewValue - e.OldValue);
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
                        if (currentTape.Codec == "AVCHD")
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
                        if (currentTape.Codec == "AVCHD")
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
                                if (currentTape.Codec == "AVCHD")
                                    file = file.Replace("avi", "mpg");
                                else
                                    file = @"H:\Vidéos\DVRender\" + file.Replace("avi", "mpg");
  //                              file = ses.Shots.Nom();
                                sw.WriteLine(" " + file);
                            }
                        }
                    }
                    sw.Close();
                    break;
                case "Play":
                    break;
            }
            MultiSceneSelected?.Invoke(this, new MultiSceneSelectedArgs { scenes = selectedScenes, type = ((ToolStripMenuItem)sender).Text });
        }
        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            if ((scenes == null) || (scenes.Count == 0))
                return;
            int largeur = (int)(scenes[0].Videos.Largeur * ImageZoomFactor) / Facteur;
            int hauteur = (int)(scenes[0].Videos.Hauteur * ImageZoomFactor) / Facteur;
            size = 6;
            int fontSize = (int)(size * ImageZoomFactor);
            int interval = (int)(2 * size * ImageZoomFactor);
            Font f = new Font("Times New Roman", fontSize);
            imagesPerRow = Math.Max(1, Width / largeur);
            scrollPictures.Maximum =( (scenes.Count / imagesPerRow))*hauteur;
   //         scrollPictures.Value = startImage / imagesPerRow;
            int x = 0;
            int y = départImage;
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].ShowImage(e, ref x, ref y, largeur, hauteur, interval, f, Width);
                if (y > Height)
                    return;
            }
        }
        private Scenes TrouveScène(MouseEventArgs e)
        {
            Scenes s = null;
            int largeur = (int)(scenes[0].Videos.Largeur * ImageZoomFactor) / Facteur;
            int hauteur = (int)(scenes[0].Videos.Hauteur * ImageZoomFactor) / Facteur;
            int interval = (int)(2 * size * ImageZoomFactor);
            int x = 0;
            int y = départImage;
            for (int i = 0; i < scenes.Count; i++)
            {
                Rectangle r = new Rectangle(x, y, largeur, hauteur);
                if (r.Contains(e.Location))
                    return scenes[i];
                //            ShowImage(e, ref x, ref y, largeur, hauteur, interval, f, i);
                x += largeur;
                if (x > Width - largeur)
                {
                    x = 0;
                    y += hauteur;
                    if (Détails) y += scenes[i].textes.Count/* nombreLignes*/ * interval;
                }
                if (y > Height)
                    return s;
            }
            return s;
        }
        private void scrollPictures_ValueChanged(object sender, EventArgs e)
        {
          //  Console.WriteLine(scrollPictures.Value);
        }
    }
}
