using DirectShowLib.DES;
using Route;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

namespace VideoTapes
{
    public partial class Tapes : Form
    {
        public static Modèle md;
        string BasePath = @"H:\Vidéos\DVRender";
        string Disque;
        Videos currentVideotape;
        Videos currentSelection;
        List<Shots> shotsToPlay;
        int cutDelay;
        Timer time = new Timer();
        Timer frameTimer = new Timer();
        Scenes currentScene;
        List<Videos> nouvelles;
        int current = 0;
        List<string> fichiers = new List<string>();
        int curPos;
        int curTime;
        public static List<Shots> nsh;
        /// <summary>
        /// Constructeur
        /// </summary>
        public Tapes()
        {
            Disque = @"H:";
            nouvelles = new List<Videos>();
            nsh = new List<Shots>();
            if (!Directory.Exists(Disque))
            {
                FolderBrowserDialog fdb = new FolderBrowserDialog();
                fdb.Description = "Sélectionnez le disque";
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    BasePath = BasePath.Replace(Disque, fdb.SelectedPath);
                    Disque = fdb.SelectedPath;
                }
                else return;
            }
            md = new Modèle();
            InitializeComponent();
            cutDelay = 2;
            time.Interval = 1000;
            time.Tick += Time_Tick;
            frameTimer.Tick += FrameTimer_Tick;
            int frtotal = md.Shots.Sum(s => s.FrameCount).Value;
            global.Text = Videos.DuréeShot(frtotal);
            sceneIndexControl.Init(md);
            dataSelector.Init(md);
            shotsToPlay = new List<Shots>();
        }
        private void Tapes_Load(object sender, EventArgs e)
        {
            videos.DataSource = md.Videos.OrderBy(c => c.Ordre).ToList();
            if (!Directory.Exists(Disque))
            {
                FolderBrowserDialog fdg = new FolderBrowserDialog();
                if (fdg.ShowDialog() == DialogResult.OK)
                {
                    BasePath = fdg.SelectedPath;
                }
            }
        }
        private void Analyse(Videos video, string videoName)
        {
            string[] files = Directory.GetFiles(videoName + @"\PRIVATE\AVCHDL\BDMV\STREAM", "*.m2ts");
            foreach (string f in files)
            {
                Shots s = ShotFromFile(f, video);
                string thumb = f.Replace(@"H:\Vidéos\HDWRITER", @"D:\VideoThumbs\").Replace(@"\PRIVATE\AVCHDL\BDMV\STREAM", "")
                .Replace("m2ts", "jpg");
                Image im = Image.FromFile(thumb);
                s.FichierImage = thumb;
                using (var ms = new MemoryStream())
                {
                    im.Save(ms, im.RawFormat);
                    s.Image = ms.GetBuffer();
                }
                im.Dispose();
                md.Shots.Add(s);
            }
            md.SaveChanges();
        }
        private Shots ShotFromFile(string f, Videos item)
        {
            FileInfo ff = new FileInfo(f);
            IMediaDet md = (IMediaDet)new MediaDet();
            md.put_Filename(f);
            md.get_StreamLength(out double x);
            md.get_FrameRate(out double frRate);
            var frameCount = (int)(x * 25);
            return new Shots { Videos = item, Fichier = f, StartFrame = 0, Codec = "AVC", DateShot = ff.LastWriteTime, EndFrame = frameCount, FrameCount = frameCount };
        }
        private void CutIntoScenes(Videos currentVideoTape)
        {
            currentVideoTape.Scenes.Clear();
            List<Shots> sceneShots = currentVideotape.Shots.OrderBy(s => s.Fichier).ThenBy(s => s.DateShot).ToList();
            DateTime t = sceneShots[0].DateShot.Value;
            int numScène = 1;
            Scenes currentScene = new Scenes
            {
                Code_Bande = currentVideotape.Code_Bande,
                Videos = currentVideotape,
                Titre = currentVideoTape.Titre + " Scene " + numScène.ToString() + sceneShots[0].Lieux?.Lieu,
                Lieux = sceneShots[0].Lieux,
                Image = sceneShots[0].Image,
                StartFrame = sceneShots[0].StartFrame,
                DateDebut = sceneShots[0].DateShot
            };
            currentVideotape.Scenes.Add(currentScene);
            cutDelay = 4;
            for (int i = 0; i < sceneShots.Count; i++)
            {
                try
                {
                    TimeSpan ts = sceneShots[i].DateShot.Value - t;
                    if ((ts.TotalMinutes > cutDelay) || (sceneShots[i].DateShot.Value < t))
                    {
                        numScène++;
                        currentScene.EndFrame = sceneShots[i - 1].EndFrame;
                        string com = currentVideoTape.Titre + " Scene " + numScène.ToString();
                        currentScene = new Scenes
                        {
                            Code_Bande = currentVideotape.Code_Bande,
                            Videos = currentVideotape,
                            Titre = com,
                            StartFrame = sceneShots[i].StartFrame,
                            Lieux = sceneShots[i].Lieux,
                            Image = sceneShots[i].Image,
                            DateDebut = sceneShots[i].DateShot
                        };
                        currentVideotape.Scenes.Add(currentScene);
                    }
                    SequenceScene sqs = new SequenceScene { Scenes = currentScene, Shots = sceneShots[i] };
                    currentScene.SequenceScene.Add(sqs);
                    t = sceneShots[i].DateShot.Value;
                }
                catch (Exception ex) { System.Diagnostics.Trace.WriteLine(ex.Message); }
            }
            timeLine.Init(currentVideotape);
            md.SaveChanges();
        }
        private void PlayShots()
        {
            fichiers.Clear();
            var u = axWindowsMediaPlayer.playlistCollection.newPlaylist("Playlist1");
            timeLine.CurrentPosition = 0;
            foreach (Shots currentShot in shotsToPlay)
            {
                string file = currentShot.Fichier;
                if (currentShot.Codec == "dvsd")
                {
                    BasePath = Disque + @"\Vidéos\DVRender\";
                }
                else
                {
                    BasePath = Disque + @"\Vidéos\HDWRITER\";
                }
                if (!file.Contains(BasePath))
                    file = BasePath + file;
                fichiers.Add(file);
                IWMPMedia video = axWindowsMediaPlayer.newMedia(file);
                u.appendItem(video);
            }
            current = 0;
            shotsToPlay.ForEach(s => { s.Current = false; s.Selected = false; });
            Play();
            //   axWindowsMediaPlayer.currentPlaylist = u;
            //if (current >= fichiers.Count)
            //    return;
            //toolStripLabel.Text = fichiers[current];
            //shotsToPlay.ForEach(s => s.Current = false);
            //shotsToPlay[current].Current = true;
            //if (timeLine.CurrentPosition * 5 > timeLine.Width / 2)
            //{
            //    timeLine.SetStart(shotsToPlay[current]);
            //    timeLine.CurrentPosition = 0;
            //}
            //frameTimer.Enabled = true;
            //frameTimer.Interval = 1000;
            //timeLine.CurrentTime = (int)shotsToPlay[current].StartFrame / 25;// curPos;
            //timeLine.CurrentPosition += timeLine.CurrentTime - curTime;// (int)shotsToPlay[current].StartFrame / 25;// curPos;
            //timeLine.Refresh();
            //frameTimer.Start();
            //axWindowsMediaPlayer.currentPlaylist.URL = fichiers[current];
            //axWindowsMediaPlayer.Ctlcontrols.play();
        }
        private void timeLine_Pause(object sender, PlayerArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.pause();
        }
        private void timeLine_Stop(object sender, PlayerArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.stop();
        }
        #region Evénements
        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            timeLine.CurrentPosition++;
            timeLine.CurrentTime++;
            timeLine.Refresh();
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            Play();
            time.Enabled = false;
        }
        private void Videos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videos.SelectedItem == null)
                return;
            currentVideotape = (Videos)videos.SelectedItem;
            axWindowsMediaPlayer.Ctlcontrols.stop();
            timeLine.CurrentPosition = 0;
            #region Show tape data 
            foreach (Control c in splitContainer6.Panel1.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            Cursor = Cursors.WaitCursor;
            bdComment.Text = currentVideotape.Commentaire;
            bdPeriode.Text = currentVideotape.Periode;
            bdTitreFichier.Text = currentVideotape.Directory;
            bdTitreBande.Text = currentVideotape.Titre;
            if ((currentVideotape.NombreFrames == null) | (currentVideotape.NombreFrames == 0))
            {
                //Cursor = Cursors.Default;
                //return;
                currentVideotape.NombreFrames = currentVideotape.Frames;
                md.SaveChanges();
                if (currentVideotape.NombreShots == null)
                {
                    currentVideotape.NombreShots = currentVideotape.Shots.Count;
                    if (currentVideotape.NombreScènes == null)
                        currentVideotape.NombreScènes = currentVideotape.Scenes.Count;
                    md.SaveChanges();
                }
            }
            bdNumberOfShots.Text = currentVideotape.NombreShots?.ToString();
            bdNumberOfScenes.Text = currentVideotape.NombreScènes.ToString();
            bdDuration.Text = currentVideotape.Durée;
            bdFrames.Text = currentVideotape.NombreFrames?.ToString();
            local.Text = currentVideotape.Shots.Count + " clips, " + currentVideotape.Durée;
            #endregion
            #region Paramètres
            if (currentVideotape.Mode == "dvsd")
            {
                BasePath = Disque + @"\Vidéos\DVRender SD\";
            }
            else
            {
                BasePath = Disque + @"\Vidéos\HDWRITER\";
            }
            #endregion
            Cursor = Cursors.WaitCursor;
            displayScenesPanel.Init(currentVideotape);
            timeLine.Init(currentVideotape);
            currentScene = currentVideotape.Scenes.First();
            sceneIndexControl.SetScene(currentScene);
            timeLine.SetStart(currentScene);
            Cursor = Cursors.Default;
            return;
        }
        private void SceneIndexControl_SceneInfoChanged(object sender, SceneSelectedArgs e)
        {
            Scenes sc = e.scene;
            md.SaveChanges();
            displayScenesPanel.Refresh();
        }
        private void DisplayScenesPanel_MultiSceneSelected(object sender, MultiSceneSelectedArgs e)
        {
            Scenes sceneModèle = e.scenes[0];
            if (sceneModèle == null)
                return;
            switch (e.type)
            {
                case "Fuse scenes":
                    #region Fusion
                    for (int i = 1; i < e.scenes.Count; i++)
                    {
                        Scenes scene = e.scenes[i];
                        foreach (var x in scene.SequenceScene)
                        {
                            sceneModèle.AddShotToScene(x.Shots);
                        }
                        try
                        {
                            md.Scenes.Remove(scene);
                        }
                        catch { }
                    }
                    currentVideotape.NombreScènes = currentVideotape.Scenes.Count;
                    md.SaveChanges();
                    #endregion
                    break;
                case "Lieu":
                    for (int i = 1; i < e.scenes.Count; i++)
                        e.scenes[i].Lieux = sceneModèle.Lieux;
                    for (int i = 1; i < e.scenes[0].SequenceScene.Count; i++)
                        e.scenes[0].SequenceScene.First().Shots.Lieux = sceneModèle.Lieux;
                    md.SaveChanges();
                    break;
                case "Commentaire":
                    for (int i = 1; i < e.scenes.Count; i++)
                        e.scenes[i].Commentaire = sceneModèle.Commentaire;
                    md.SaveChanges();
                    break;
                case "Titre":
                    for (int i = 1; i < e.scenes.Count; i++)
                        e.scenes[i].Titre = sceneModèle.Titre;
                    md.SaveChanges();
                    break;
                case "Play":
                    #region Liste à jouer
                    shotsToPlay.Clear();
                    foreach (Scenes scene in e.scenes)
                    {
                        foreach (SequenceScene y in scene.SequenceScene)
                        {
                            shotsToPlay.Add(y.Shots);
                            y.Shots.Selected = true;
                        }
                    }
                    PlayShots();
                    #endregion
                    break;
                case "Mots Clés":
                    #region Mise à jour mots clés
                    if (sceneModèle.KeywordScene != null)
                        for (int i = 1; i < e.scenes.Count; i++)
                        {
                            foreach (KeywordScene y in sceneModèle.KeywordScene)
                            {
                                e.scenes[i].AddKeywordToScene(y.Keywords);
                            }
                        }
                    md.SaveChanges();
                    #endregion
                    break;
                case "Personne":
                    #region Mise à jour personnes
                    if (sceneModèle.PrésenceScène != null)
                        for (int i = 1; i < e.scenes.Count; i++)
                        {
                            foreach (PrésenceScène y in sceneModèle.PrésenceScène)
                            {
                                e.scenes[i].AddPersonToScene(y.Personnes);
                            }
                        }
                    md.SaveChanges();
                    #endregion
                    break;
                case "Split scene":
                    Scenes sc = sceneModèle;
                    //            if (sc.Videos.NombreScènes == 1)
                    //{
                    //    if (sc.SequenceScene.Count == 0)
                    //    {
                    //        foreach(Shots sh in sc.Videos.Shots)
                    //        {
                    //            sc.SequenceScene.Add(new SequenceScene { Shots = sh, Scenes = sc });
                    //        }
                    //    }
                    //}

                    //foreach (var x in sc.SequenceScene)
                    //{
                    //    Scenes scene = new Scenes();
                    //    scene.SequenceScene.Add(x);
                    //    currentVideotape.Scenes.Add(scene);
                    //}
                    //try
                    //{
                    //    md.Scenes.Remove(sc);
                    //}
                    //catch { }
                    //currentVideotape.NombreScènes = currentVideotape.Scenes.Count;
                    //md.SaveChanges();
                    break;
            }
            displayScenesPanel.Refresh();
            bdNumberOfScenes.Text = currentVideotape.Scenes.Count.ToString();/*md.Scenes.Where(s => s.Videos.Code_Bande == currentVideotape.Code_Bande).Count().ToString()*/;
        }
        private void TimeLine_ShotSelected(object sender, ShotSelectedArgs e)
        {
            if (e.Shots != null)
            {
                shotsToPlay = e.Shots;
                PlayShots();
            }
        }
        private void détails_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void DisplayScenesPanel_SceneSelected(object sender, SceneSelectedArgs e)
        {
            currentScene = e.scene;
            var sq = currentScene.SequenceScene;
            currentVideotape.Shots.ToList().ForEach(s => s.Selected = false);
            sceneIndexControl.SetScene(e.scene);
            #region Sélectionne les clips
            shotsToPlay.Clear();
            foreach (SequenceScene y in sq)
            {
                y.Shots.Selected = true;
                shotsToPlay.Add(y.Shots);
            }
            //if (détails.Checked)
            //    PlayShots();
            #endregion
            timeLine.SetStart(currentScene);
        }
        #endregion
        #region Menus
        /// <summary>
        /// Destiné à l'intégration de films AVCHD déjà saisis dans la base grâce au script Vegas 
        /// D:\Documents\Visual Studio 2017\Projets\Médias\Vegas Studio\Vegas Lib\Vegas\Vegas\EntryPoint.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OuvrirToolStripButton_Click(object sender, EventArgs e)
        {
            if (videos.SelectedItems.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                var video = (Videos)videos.SelectedItem;
                string t = ((Videos)videos.SelectedItem).Directory;
                Analyse(video, t);
                Cursor = Cursors.Default;
                CutIntoScenes(video);
                displayScenesPanel.Init(video);
                timeLine.Init(video);
            }
            else
            {

            }
        }
        /// <summary>
        /// Intégration de nouveaux films non présents dans la base 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NouveauToolStripButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog { SelectedPath = @"H:\Vidéos\HDWRITER", Description = "Choisir le répertoire du film" };
            if (fld.ShowDialog() == DialogResult.OK)
            {
                string an = Path.GetFileNameWithoutExtension(fld.SelectedPath);
                foreach (string fol in Directory.GetDirectories(fld.SelectedPath))
                {
                    string folder = fol + @"\PRIVATE\AVCHDL\BDMV\STREAM";
                    string[] files = Directory.GetFiles(folder, "*.m2ts");
                    Videos vid = new Videos { Periode = an, Titre = Path.GetFileNameWithoutExtension(fol), Directory = fol, Hauteur = 1080, Largeur = 1920, Mode = "AVC" };
                    foreach (string f in files)
                    {
                        Shots shot = ShotFromFile(f, vid); // new Shots { Videos = vid, Fichier = f };
                        md.Shots.Add(shot);
                        videos.Items.Add(vid);
                    }
                    md.Videos.Add(vid);
                    vid.Ordre = vid.Code_Bande;
                }
            }
            md.SaveChanges();
        }
        private void Update_Click(object sender, EventArgs e)
        {
            currentVideotape.Commentaire = bdComment.Text;
            currentVideotape.Periode = bdPeriode.Text;
            currentVideotape.Titre = bdTitreBande.Text;
            md.SaveChanges();
            currentSelection = currentVideotape;
            videos.DataSource = null;
            videos.DataSource = md.Videos.ToList();
            videos.SelectedItem = currentSelection;
            videos.TopIndex = videos.Items.IndexOf(currentSelection);
        }
        private void CouperToolStripButton_Click(object sender, EventArgs e)
        {
            if (currentVideotape == null)
                return;
            currentVideotape.Scenes.Clear();
            CutIntoScenes(currentVideotape);
            displayScenesPanel.Init(currentVideotape);
            displayScenesPanel.Refresh();
            bdNumberOfScenes.Text = currentVideotape.Scenes.Count.ToString();
        }
        private void Détails_Click(object sender, EventArgs e)
        {
            displayScenesPanel.Détails = détails.Checked;
            displayScenesPanel.Refresh();
        }
        private void ZoomIn_Click(object sender, EventArgs e)
        {
            displayScenesPanel.ImageZoomFactor *= 1.1;
            if (displayScenesPanel.ImageZoomFactor > 4)
                displayScenesPanel.ImageZoomFactor = 1;
            displayScenesPanel.Refresh();
        }
        private void ZoomOut_Click(object sender, EventArgs e)
        {
            displayScenesPanel.ImageZoomFactor /= 1.1;
            if (displayScenesPanel.ImageZoomFactor < 0.3)
                displayScenesPanel.ImageZoomFactor = 1;
            displayScenesPanel.Refresh();
        }
        private void DrawRoute_Click(object sender, EventArgs e)
        {
            DrawRoute dr = new DrawRoute();
            if (dr.ShowDialog() == DialogResult.OK)
            {

            }
        }
        #endregion
        private void DisplayScenesPanel_Resize(object sender, EventArgs e) => displayScenesPanel.Refresh();
        #region Recherche
        private void DataSelector1_LieuxSelected(object sender, LieuxSelectedArgs e)
        {
            var scenes = md.Scenes.Where(s => s.Lieux.Code_Lieu == e.Lieu.Code_Lieu);
            scenes = scenes.Where(s => s.SequenceScene.Count > 0);
            if (scenes.Count() == 0)
            {

            }
            else
            {
                DisplayScenes(scenes.ToList(), e.Lieu.ToString());
            }
        }

        private void DataSelector1_PersonneSelected(object sender, PersonneSelectedArgs e)
        {
            List<Scenes> scenes = new List<Scenes>();
            md.PrésenceScene.Where(ps => ps.Personnes.Code == e.Personne.Code & ps.Scenes.Videos != null).ToList().ForEach(sc => scenes.Add(sc.Scenes));
            DisplayScenes(scenes, e.Personne.ToString());
        }

        private void DataSelector1_KeywordsSelected(object sender, KeywordSelectedArgs e)
        {
            List<Scenes> scenes = new List<Scenes>();
            md.KeywordScene.Where(ps => ps.Keywords.Code_Keyword == e.KwChoosen.Code_Keyword).ToList().ForEach(sc => scenes.Add(sc.Scenes));
            DisplayScenes(scenes, e.KwChoosen.Keyword);
        }

        private void DataSelector1_DateSelected(object sender, DateSelectedArgs e)
        {
            DateTime début = e.BeginDate;
            DateTime Fin = e.EndDate;
            List<Scenes> scenes = new List<Scenes>();
            scenes = md.Scenes.Where(ps => ps.DateDebut >= e.BeginDate & ps.DateDebut <= e.EndDate).ToList();
            DisplayScenes(scenes, e.BeginDate.ToShortDateString() + "-" + e.EndDate.ToShortDateString());
        }
        #endregion
        private void DisplayScenes(List<Scenes> scenes, string clé)
        {
            displayScenesPanel.Init(scenes.ToList(), clé);
            currentScene = null;
            currentVideotape = new Videos
            {
                Scenes = scenes.ToList()
            };
            if (shotsToPlay != null)
                shotsToPlay.Clear();
            else shotsToPlay = new List<Shots>();
            foreach (Scenes x in scenes)
                foreach (SequenceScene sq in x.SequenceScene)
                {
                    currentVideotape.Shots.Add(sq.Shots);
                    shotsToPlay.Add(sq.Shots);
                    sq.Shots.Selected = true;

                }
            timeLine.Init(currentVideotape);
            bdNumberOfShots.Text = currentVideotape.Shots.Count.ToString();
            bdNumberOfScenes.Text = currentVideotape.Scenes.Count.ToString();
            bdDuration.Text = currentVideotape.Durée;
            bdFrames.Text = currentVideotape.Frames.ToString();
        }
        #region Media Player
        private void Play()
        {
            if (current >= fichiers.Count)
                return;
            toolStripLabel.Text = fichiers[current];
            shotsToPlay.ForEach(s => s.Current = false);
            shotsToPlay[current].Current = true;
            if (timeLine.CurrentPosition * 5 > timeLine.Width / 2)
            {
                timeLine.SetStart(shotsToPlay[current]);
                timeLine.CurrentPosition = 0;
            }
            frameTimer.Enabled = true;
            frameTimer.Interval = 1000;
            timeLine.CurrentTime = (int)shotsToPlay[current].StartFrame / 25;// curPos;
            timeLine.CurrentPosition += timeLine.CurrentTime - curTime;// (int)shotsToPlay[current].StartFrame / 25;// curPos;
            timeLine.Refresh();
            frameTimer.Start();
            axWindowsMediaPlayer.URL = fichiers[current];
            axWindowsMediaPlayer.Ctlcontrols.play();
        }
        private void AxWindowsMediaPlayer_CurrentItemChange(object sender, AxWMPLib._WMPOCXEvents_CurrentItemChangeEvent e)
        {
            var x = axWindowsMediaPlayer.currentMedia.name;
            SelectFromName(x);
            timeLine.Refresh();
            Console.WriteLine(x);
        }
        private void SelectFromName(string name)
        {
            shotsToPlay.ForEach(c => c.Selected = false);
            shotsToPlay.ForEach(c => c.Current = false);
            shotsToPlay.Single(c => c.Fichier.Contains(name)).Current = true;
        }
        private void AxWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch ((PlayerEvents)e.newState)
            {
                case PlayerEvents.Stopped:// 1:
                                          //           frameTimer.Stop();
                    break;
                case PlayerEvents.Paused:// 2:
                    break;
                case PlayerEvents.Playing://3
                    frameTimer.Start();
                    break;
                case PlayerEvents.Scan_Forward://5
                    break;
                case PlayerEvents.Scan_Backwards://6
                    break;
                case PlayerEvents.Buffering://6
                    break;
                case PlayerEvents.Waiting://7
                    break;
                case PlayerEvents.Media_Ended: // 8:
                    time.Enabled = true;
                    time.Start();
                    frameTimer.Stop();
                    curPos = timeLine.CurrentPosition;
                    curTime = timeLine.CurrentTime;
                    current++;
                    break;
                case PlayerEvents.Transitioning://9
                    break;

                case PlayerEvents.Ready://10
                    break;
                case PlayerEvents.Reconnecting://11
                    break;
                case PlayerEvents.Last://12
                    break;
                default:
                    break;
            }
        }
        #endregion
        private void Videos_DataSourceChanged(object sender, EventArgs e)
        {
            videos.SelectedItem = currentVideotape;
            Refresh();
        }
        #region Affichage plein écran
        Form pleinEcran;
        private void PleinEcran_FormClosed(object sender, FormClosedEventArgs e)
        {
            // axWindowsMediaPlayer.close();
            pleinEcran.Controls.Remove(axWindowsMediaPlayer);
            this.splitContainer7.Panel2.Controls.Add(this.axWindowsMediaPlayer);
        }
        private void Fullscreen_CheckedChanged(object sender, EventArgs e)
        {
            if (!fullscreen.Checked)
            {
                pleinEcran?.Close();
            }
            else
            {
                pleinEcran = new Form();
                pleinEcran.Controls.Add(axWindowsMediaPlayer);
                axWindowsMediaPlayer.Dock = DockStyle.Fill;
                axWindowsMediaPlayer.stretchToFit = true;
                pleinEcran.FormClosed += PleinEcran_FormClosed;
                pleinEcran.WindowState = FormWindowState.Normal;
                pleinEcran.StartPosition = FormStartPosition.Manual;
                if (Screen.AllScreens.Count() > 0)
                {
                    pleinEcran.Bounds = new Rectangle(1920, 30, 1920, 1040);
                }
                else
                {
                    pleinEcran.Bounds = new Rectangle(0, 30, 1920, 1040);
                }
                pleinEcran.Show();
            }
        }
        #endregion
        private void imprimerToolStripButton_Click(object sender, EventArgs e)
        {

        }


    }
    enum PlayerEvents
    {
        Undefined = 0,
        Stopped = 1,
        Paused = 2,
        Playing = 3,
        Scan_Forward = 4,
        Scan_Backwards = 5,
        Buffering = 6,
        Waiting = 7,
        Media_Ended = 8,
        Transitioning = 9,
        Ready = 10,
        Reconnecting = 11,
        Last = 12
    }
}
