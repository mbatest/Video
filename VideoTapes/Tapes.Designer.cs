namespace VideoTapes
{
    partial class Tapes
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                md.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tapes));
            this.splitContainerPrincipal = new System.Windows.Forms.SplitContainer();
            this.splitContainerVideos = new System.Windows.Forms.SplitContainer();
            this.videos = new System.Windows.Forms.ListBox();
            this.splitContainerDétailsVidéo = new System.Windows.Forms.SplitContainer();
            this.bdFrames = new System.Windows.Forms.TextBox();
            this.labelFrame = new System.Windows.Forms.Label();
            this.bdDuration = new System.Windows.Forms.TextBox();
            this.labelDurée = new System.Windows.Forms.Label();
            this.MetaJour = new System.Windows.Forms.Button();
            this.bdNumberOfScenes = new System.Windows.Forms.TextBox();
            this.labelScénes = new System.Windows.Forms.Label();
            this.bdNumberOfShots = new System.Windows.Forms.TextBox();
            this.labelShots = new System.Windows.Forms.Label();
            this.bdTitreBande = new System.Windows.Forms.TextBox();
            this.labelTitre = new System.Windows.Forms.Label();
            this.bdTitreFichier = new System.Windows.Forms.TextBox();
            this.labelFichier = new System.Windows.Forms.Label();
            this.labelComment = new System.Windows.Forms.Label();
            this.bdPeriode = new System.Windows.Forms.TextBox();
            this.bdComment = new System.Windows.Forms.TextBox();
            this.labelPériode = new System.Windows.Forms.Label();
            this.tabControlInfo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sceneIndexControl = new VideoTapes.SceneIndexControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataSelector = new VideoTapes.DataSelector();
            this.splitContainerTimeLine = new System.Windows.Forms.SplitContainer();
            this.splitContainerScenes = new System.Windows.Forms.SplitContainer();
            this.displayScenesPanel = new VideoTapes.DisplayScenesPanel();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.timeLine = new VideoTapes.TimeLine();
            this.splitContainerToolStrip = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.global = new System.Windows.Forms.ToolStripLabel();
            this.local = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.splitContainerMenu = new System.Windows.Forms.SplitContainer();
            this.sceneNumber = new System.Windows.Forms.ToolStripTextBox();
            this.nouveauToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ouvrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.enregistrerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imprimerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.couperToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copierToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.collerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.détails = new System.Windows.Forms.ToolStripButton();
            this.ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.drawRoute = new System.Windows.Forms.ToolStripButton();
            this.fullscreen = new System.Windows.Forms.ToolStripButton();
            this.searchScene = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPrincipal)).BeginInit();
            this.splitContainerPrincipal.Panel1.SuspendLayout();
            this.splitContainerPrincipal.Panel2.SuspendLayout();
            this.splitContainerPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVideos)).BeginInit();
            this.splitContainerVideos.Panel1.SuspendLayout();
            this.splitContainerVideos.Panel2.SuspendLayout();
            this.splitContainerVideos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDétailsVidéo)).BeginInit();
            this.splitContainerDétailsVidéo.Panel1.SuspendLayout();
            this.splitContainerDétailsVidéo.Panel2.SuspendLayout();
            this.splitContainerDétailsVidéo.SuspendLayout();
            this.tabControlInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTimeLine)).BeginInit();
            this.splitContainerTimeLine.Panel1.SuspendLayout();
            this.splitContainerTimeLine.Panel2.SuspendLayout();
            this.splitContainerTimeLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScenes)).BeginInit();
            this.splitContainerScenes.Panel1.SuspendLayout();
            this.splitContainerScenes.Panel2.SuspendLayout();
            this.splitContainerScenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerToolStrip)).BeginInit();
            this.splitContainerToolStrip.Panel1.SuspendLayout();
            this.splitContainerToolStrip.Panel2.SuspendLayout();
            this.splitContainerToolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenu)).BeginInit();
            this.splitContainerMenu.Panel1.SuspendLayout();
            this.splitContainerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerPrincipal
            // 
            this.splitContainerPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerPrincipal.IsSplitterFixed = true;
            this.splitContainerPrincipal.Location = new System.Drawing.Point(0, 0);
            this.splitContainerPrincipal.Name = "splitContainerPrincipal";
            // 
            // splitContainerPrincipal.Panel1
            // 
            this.splitContainerPrincipal.Panel1.Controls.Add(this.splitContainerVideos);
            // 
            // splitContainerPrincipal.Panel2
            // 
            this.splitContainerPrincipal.Panel2.Controls.Add(this.splitContainerTimeLine);
            this.splitContainerPrincipal.Size = new System.Drawing.Size(1279, 826);
            this.splitContainerPrincipal.SplitterDistance = 266;
            this.splitContainerPrincipal.TabIndex = 0;
            // 
            // splitContainerVideos
            // 
            this.splitContainerVideos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVideos.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVideos.Name = "splitContainerVideos";
            this.splitContainerVideos.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerVideos.Panel1
            // 
            this.splitContainerVideos.Panel1.Controls.Add(this.videos);
            // 
            // splitContainerVideos.Panel2
            // 
            this.splitContainerVideos.Panel2.Controls.Add(this.splitContainerDétailsVidéo);
            this.splitContainerVideos.Size = new System.Drawing.Size(266, 826);
            this.splitContainerVideos.SplitterDistance = 237;
            this.splitContainerVideos.TabIndex = 0;
            // 
            // videos
            // 
            this.videos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videos.FormattingEnabled = true;
            this.videos.Location = new System.Drawing.Point(0, 0);
            this.videos.Name = "videos";
            this.videos.Size = new System.Drawing.Size(266, 237);
            this.videos.TabIndex = 0;
            this.videos.SelectedIndexChanged += new System.EventHandler(this.Videos_SelectedIndexChanged);
            this.videos.DataSourceChanged += new System.EventHandler(this.Videos_DataSourceChanged);
            // 
            // splitContainerDétailsVidéo
            // 
            this.splitContainerDétailsVidéo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDétailsVidéo.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerDétailsVidéo.IsSplitterFixed = true;
            this.splitContainerDétailsVidéo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDétailsVidéo.Name = "splitContainerDétailsVidéo";
            this.splitContainerDétailsVidéo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDétailsVidéo.Panel1
            // 
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.bdFrames);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.labelFrame);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.bdDuration);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.labelDurée);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.MetaJour);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.bdNumberOfScenes);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.labelScénes);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.bdNumberOfShots);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.labelShots);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.bdTitreBande);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.labelTitre);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.bdTitreFichier);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.labelFichier);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.labelComment);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.bdPeriode);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.bdComment);
            this.splitContainerDétailsVidéo.Panel1.Controls.Add(this.labelPériode);
            // 
            // splitContainerDétailsVidéo.Panel2
            // 
            this.splitContainerDétailsVidéo.Panel2.Controls.Add(this.tabControlInfo);
            this.splitContainerDétailsVidéo.Size = new System.Drawing.Size(266, 585);
            this.splitContainerDétailsVidéo.SplitterDistance = 205;
            this.splitContainerDétailsVidéo.TabIndex = 0;
            // 
            // bdFrames
            // 
            this.bdFrames.Location = new System.Drawing.Point(185, 130);
            this.bdFrames.Name = "bdFrames";
            this.bdFrames.ReadOnly = true;
            this.bdFrames.Size = new System.Drawing.Size(74, 20);
            this.bdFrames.TabIndex = 90;
            // 
            // labelFrame
            // 
            this.labelFrame.AutoSize = true;
            this.labelFrame.Location = new System.Drawing.Point(134, 133);
            this.labelFrame.Name = "labelFrame";
            this.labelFrame.Size = new System.Drawing.Size(41, 13);
            this.labelFrame.TabIndex = 91;
            this.labelFrame.Text = "Frames";
            // 
            // bdDuration
            // 
            this.bdDuration.Location = new System.Drawing.Point(60, 130);
            this.bdDuration.Name = "bdDuration";
            this.bdDuration.ReadOnly = true;
            this.bdDuration.Size = new System.Drawing.Size(71, 20);
            this.bdDuration.TabIndex = 88;
            // 
            // labelDurée
            // 
            this.labelDurée.AutoSize = true;
            this.labelDurée.Location = new System.Drawing.Point(7, 133);
            this.labelDurée.Name = "labelDurée";
            this.labelDurée.Size = new System.Drawing.Size(36, 13);
            this.labelDurée.TabIndex = 89;
            this.labelDurée.Text = "Durée";
            // 
            // MetaJour
            // 
            this.MetaJour.Location = new System.Drawing.Point(80, 177);
            this.MetaJour.Name = "MetaJour";
            this.MetaJour.Size = new System.Drawing.Size(75, 23);
            this.MetaJour.TabIndex = 87;
            this.MetaJour.Text = "Update";
            this.MetaJour.UseVisualStyleBackColor = true;
            this.MetaJour.Click += new System.EventHandler(this.Update_Click);
            // 
            // bdNumberOfScenes
            // 
            this.bdNumberOfScenes.Location = new System.Drawing.Point(192, 153);
            this.bdNumberOfScenes.Name = "bdNumberOfScenes";
            this.bdNumberOfScenes.ReadOnly = true;
            this.bdNumberOfScenes.Size = new System.Drawing.Size(67, 20);
            this.bdNumberOfScenes.TabIndex = 85;
            // 
            // labelScénes
            // 
            this.labelScénes.AutoSize = true;
            this.labelScénes.Location = new System.Drawing.Point(135, 156);
            this.labelScénes.Name = "labelScénes";
            this.labelScénes.Size = new System.Drawing.Size(43, 13);
            this.labelScénes.TabIndex = 86;
            this.labelScénes.Text = "Scènes";
            // 
            // bdNumberOfShots
            // 
            this.bdNumberOfShots.Location = new System.Drawing.Point(60, 153);
            this.bdNumberOfShots.Name = "bdNumberOfShots";
            this.bdNumberOfShots.ReadOnly = true;
            this.bdNumberOfShots.Size = new System.Drawing.Size(71, 20);
            this.bdNumberOfShots.TabIndex = 83;
            // 
            // labelShots
            // 
            this.labelShots.AutoSize = true;
            this.labelShots.Location = new System.Drawing.Point(8, 156);
            this.labelShots.Name = "labelShots";
            this.labelShots.Size = new System.Drawing.Size(34, 13);
            this.labelShots.TabIndex = 84;
            this.labelShots.Text = "Shots";
            // 
            // bdTitreBande
            // 
            this.bdTitreBande.Location = new System.Drawing.Point(60, 4);
            this.bdTitreBande.Name = "bdTitreBande";
            this.bdTitreBande.Size = new System.Drawing.Size(199, 20);
            this.bdTitreBande.TabIndex = 75;
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(7, 7);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(28, 13);
            this.labelTitre.TabIndex = 76;
            this.labelTitre.Text = "Titre";
            // 
            // bdTitreFichier
            // 
            this.bdTitreFichier.Location = new System.Drawing.Point(60, 28);
            this.bdTitreFichier.Name = "bdTitreFichier";
            this.bdTitreFichier.ReadOnly = true;
            this.bdTitreFichier.Size = new System.Drawing.Size(199, 20);
            this.bdTitreFichier.TabIndex = 77;
            // 
            // labelFichier
            // 
            this.labelFichier.AutoSize = true;
            this.labelFichier.Location = new System.Drawing.Point(7, 31);
            this.labelFichier.Name = "labelFichier";
            this.labelFichier.Size = new System.Drawing.Size(38, 13);
            this.labelFichier.TabIndex = 78;
            this.labelFichier.Text = "Fichier";
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(7, 79);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(51, 13);
            this.labelComment.TabIndex = 82;
            this.labelComment.Text = "Comment";
            // 
            // bdPeriode
            // 
            this.bdPeriode.Location = new System.Drawing.Point(60, 52);
            this.bdPeriode.Name = "bdPeriode";
            this.bdPeriode.Size = new System.Drawing.Size(199, 20);
            this.bdPeriode.TabIndex = 79;
            // 
            // bdComment
            // 
            this.bdComment.Location = new System.Drawing.Point(60, 76);
            this.bdComment.Multiline = true;
            this.bdComment.Name = "bdComment";
            this.bdComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bdComment.Size = new System.Drawing.Size(199, 51);
            this.bdComment.TabIndex = 81;
            // 
            // labelPériode
            // 
            this.labelPériode.AutoSize = true;
            this.labelPériode.Location = new System.Drawing.Point(7, 55);
            this.labelPériode.Name = "labelPériode";
            this.labelPériode.Size = new System.Drawing.Size(43, 13);
            this.labelPériode.TabIndex = 80;
            this.labelPériode.Text = "Période";
            // 
            // tabControlInfo
            // 
            this.tabControlInfo.Controls.Add(this.tabPage1);
            this.tabControlInfo.Controls.Add(this.tabPage2);
            this.tabControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInfo.Location = new System.Drawing.Point(0, 0);
            this.tabControlInfo.Name = "tabControlInfo";
            this.tabControlInfo.SelectedIndex = 0;
            this.tabControlInfo.Size = new System.Drawing.Size(266, 376);
            this.tabControlInfo.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.sceneIndexControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(258, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // sceneIndexControl
            // 
            this.sceneIndexControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneIndexControl.Location = new System.Drawing.Point(3, 3);
            this.sceneIndexControl.Name = "sceneIndexControl";
            this.sceneIndexControl.Size = new System.Drawing.Size(252, 344);
            this.sceneIndexControl.TabIndex = 0;
            this.sceneIndexControl.SceneInfoChanged += new VideoTapes.SceneInfoChangedHandler(this.SceneIndexControl_SceneInfoChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataSelector);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(258, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Recherche";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataSelector
            // 
            this.dataSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSelector.Location = new System.Drawing.Point(3, 3);
            this.dataSelector.Name = "dataSelector";
            this.dataSelector.Size = new System.Drawing.Size(252, 344);
            this.dataSelector.TabIndex = 0;
            this.dataSelector.LieuxSelected += new VideoTapes.LieuxSelectedHandler(this.DataSelector_LieuxSelected);
            this.dataSelector.PersonneSelected += new VideoTapes.PersonneSelectedHandler(this.DataSelector_PersonneSelected);
            this.dataSelector.DateSelected += new VideoTapes.DateSelectedHandler(this.DataSelector_DateSelected);
            this.dataSelector.KeywordsSelected += new VideoTapes.KeywordsSelectedHandler(this.DataSelector_KeywordsSelected);
            // 
            // splitContainerTimeLine
            // 
            this.splitContainerTimeLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTimeLine.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTimeLine.Name = "splitContainerTimeLine";
            this.splitContainerTimeLine.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTimeLine.Panel1
            // 
            this.splitContainerTimeLine.Panel1.Controls.Add(this.splitContainerScenes);
            // 
            // splitContainerTimeLine.Panel2
            // 
            this.splitContainerTimeLine.Panel2.Controls.Add(this.timeLine);
            this.splitContainerTimeLine.Size = new System.Drawing.Size(1009, 826);
            this.splitContainerTimeLine.SplitterDistance = 589;
            this.splitContainerTimeLine.TabIndex = 1;
            // 
            // splitContainerScenes
            // 
            this.splitContainerScenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerScenes.Location = new System.Drawing.Point(0, 0);
            this.splitContainerScenes.Name = "splitContainerScenes";
            // 
            // splitContainerScenes.Panel1
            // 
            this.splitContainerScenes.Panel1.Controls.Add(this.displayScenesPanel);
            // 
            // splitContainerScenes.Panel2
            // 
            this.splitContainerScenes.Panel2.Controls.Add(this.axWindowsMediaPlayer);
            this.splitContainerScenes.Size = new System.Drawing.Size(1009, 589);
            this.splitContainerScenes.SplitterDistance = 426;
            this.splitContainerScenes.TabIndex = 0;
            // 
            // displayScenesPanel
            // 
            this.displayScenesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayScenesPanel.Facteur = 3;
            this.displayScenesPanel.ImageZoomFactor = 1D;
            this.displayScenesPanel.Location = new System.Drawing.Point(0, 0);
            this.displayScenesPanel.Name = "displayScenesPanel";
            this.displayScenesPanel.Size = new System.Drawing.Size(426, 589);
            this.displayScenesPanel.TabIndex = 1;
            this.displayScenesPanel.SceneSelected += new VideoTapes.SceneSelectedHandler(this.DisplayScenesPanel_SceneSelected);
            this.displayScenesPanel.MultiSceneSelected += new VideoTapes.MultiSceneSelectedHandler(this.DisplayScenesPanel_MultiSceneSelected);
            this.displayScenesPanel.Resize += new System.EventHandler(this.DisplayScenesPanel_Resize);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(579, 589);
            this.axWindowsMediaPlayer.TabIndex = 1;
            this.axWindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.AxWindowsMediaPlayer_PlayStateChange);
            this.axWindowsMediaPlayer.CurrentItemChange += new AxWMPLib._WMPOCXEvents_CurrentItemChangeEventHandler(this.AxWindowsMediaPlayer_CurrentItemChange);
            // 
            // timeLine
            // 
            this.timeLine.CurrentPosition = 0;
            this.timeLine.CurrentTime = 0;
            this.timeLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeLine.Location = new System.Drawing.Point(0, 0);
            this.timeLine.Name = "timeLine";
            this.timeLine.Size = new System.Drawing.Size(1009, 233);
            this.timeLine.TabIndex = 0;
            this.timeLine.ShotSelected += new VideoTapes.ShotSelectedHandler(this.TimeLine_ShotSelected);
            this.timeLine.Pause += new VideoTapes.PlayerHandler(this.TimeLine_Pause);
            this.timeLine.Stop += new VideoTapes.PlayerHandler(this.TimeLine_Stop);
            // 
            // splitContainerToolStrip
            // 
            this.splitContainerToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerToolStrip.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerToolStrip.IsSplitterFixed = true;
            this.splitContainerToolStrip.Location = new System.Drawing.Point(0, 0);
            this.splitContainerToolStrip.Name = "splitContainerToolStrip";
            this.splitContainerToolStrip.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerToolStrip.Panel1
            // 
            this.splitContainerToolStrip.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainerToolStrip.Panel2
            // 
            this.splitContainerToolStrip.Panel2.Controls.Add(this.splitContainerPrincipal);
            this.splitContainerToolStrip.Size = new System.Drawing.Size(1279, 855);
            this.splitContainerToolStrip.SplitterDistance = 25;
            this.splitContainerToolStrip.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripButton,
            this.ouvrirToolStripButton,
            this.enregistrerToolStripButton,
            this.toolStripLabel1,
            this.global,
            this.local,
            this.imprimerToolStripButton,
            this.toolStripSeparator,
            this.couperToolStripButton,
            this.copierToolStripButton,
            this.collerToolStripButton,
            this.toolStripSeparator1,
            this.ToolStripButton,
            this.détails,
            this.ZoomOut,
            this.ZoomIn,
            this.toolStripLabel,
            this.drawRoute,
            this.fullscreen,
            this.sceneNumber,
            this.searchScene});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1279, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(97, 22);
            this.toolStripLabel1.Text = "Longueur totale :";
            // 
            // global
            // 
            this.global.Name = "global";
            this.global.Size = new System.Drawing.Size(19, 22);
            this.global.Text = "    ";
            // 
            // local
            // 
            this.local.Name = "local";
            this.local.Size = new System.Drawing.Size(16, 22);
            this.local.Text = "   ";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(22, 22);
            this.toolStripLabel.Text = "     ";
            // 
            // splitContainerMenu
            // 
            this.splitContainerMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMenu.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMenu.Name = "splitContainerMenu";
            this.splitContainerMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMenu.Panel1
            // 
            this.splitContainerMenu.Panel1.Controls.Add(this.splitContainerToolStrip);
            this.splitContainerMenu.Panel2Collapsed = true;
            this.splitContainerMenu.Size = new System.Drawing.Size(1279, 855);
            this.splitContainerMenu.SplitterDistance = 583;
            this.splitContainerMenu.TabIndex = 3;
            // 
            // sceneNumber
            // 
            this.sceneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sceneNumber.Name = "sceneNumber";
            this.sceneNumber.Size = new System.Drawing.Size(100, 25);
            // 
            // nouveauToolStripButton
            // 
            this.nouveauToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nouveauToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nouveauToolStripButton.Image")));
            this.nouveauToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nouveauToolStripButton.Name = "nouveauToolStripButton";
            this.nouveauToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.nouveauToolStripButton.Text = "&Nouveau";
            this.nouveauToolStripButton.ToolTipText = "Importe un film";
            this.nouveauToolStripButton.Click += new System.EventHandler(this.NouveauToolStripButton_Click);
            // 
            // ouvrirToolStripButton
            // 
            this.ouvrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ouvrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ouvrirToolStripButton.Image")));
            this.ouvrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ouvrirToolStripButton.Name = "ouvrirToolStripButton";
            this.ouvrirToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ouvrirToolStripButton.Text = "&Ouvrir";
            this.ouvrirToolStripButton.Click += new System.EventHandler(this.OuvrirToolStripButton_Click);
            // 
            // enregistrerToolStripButton
            // 
            this.enregistrerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.enregistrerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("enregistrerToolStripButton.Image")));
            this.enregistrerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enregistrerToolStripButton.Name = "enregistrerToolStripButton";
            this.enregistrerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.enregistrerToolStripButton.Text = "&Enregistrer";
            // 
            // imprimerToolStripButton
            // 
            this.imprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("imprimerToolStripButton.Image")));
            this.imprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimerToolStripButton.Name = "imprimerToolStripButton";
            this.imprimerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.imprimerToolStripButton.Text = "&Imprimer";
            // 
            // couperToolStripButton
            // 
            this.couperToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.couperToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("couperToolStripButton.Image")));
            this.couperToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.couperToolStripButton.Name = "couperToolStripButton";
            this.couperToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.couperToolStripButton.Text = "C&ouper";
            this.couperToolStripButton.Click += new System.EventHandler(this.CouperToolStripButton_Click);
            // 
            // copierToolStripButton
            // 
            this.copierToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copierToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copierToolStripButton.Image")));
            this.copierToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copierToolStripButton.Name = "copierToolStripButton";
            this.copierToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copierToolStripButton.Text = "Co&pier";
            // 
            // collerToolStripButton
            // 
            this.collerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.collerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("collerToolStripButton.Image")));
            this.collerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collerToolStripButton.Name = "collerToolStripButton";
            this.collerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.collerToolStripButton.Text = "Co&ller";
            // 
            // ToolStripButton
            // 
            this.ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton.Image")));
            this.ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton.Name = "ToolStripButton";
            this.ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton.Text = "&?";
            // 
            // détails
            // 
            this.détails.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.détails.CheckOnClick = true;
            this.détails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.détails.Image = ((System.Drawing.Image)(resources.GetObject("détails.Image")));
            this.détails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.détails.Name = "détails";
            this.détails.Size = new System.Drawing.Size(23, 22);
            this.détails.Text = "Détails";
            this.détails.CheckedChanged += new System.EventHandler(this.détails_CheckedChanged);
            this.détails.Click += new System.EventHandler(this.Détails_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOut.Image")));
            this.ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(23, 22);
            this.ZoomOut.ToolTipText = "Zoom Out";
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // ZoomIn
            // 
            this.ZoomIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomIn.Image")));
            this.ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(23, 22);
            this.ZoomIn.Text = "toolStripButton1";
            this.ZoomIn.ToolTipText = "Zoom In";
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // drawRoute
            // 
            this.drawRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRoute.Image = ((System.Drawing.Image)(resources.GetObject("drawRoute.Image")));
            this.drawRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRoute.Name = "drawRoute";
            this.drawRoute.Size = new System.Drawing.Size(23, 22);
            this.drawRoute.Text = "toolStripButton1";
            this.drawRoute.Click += new System.EventHandler(this.DrawRoute_Click);
            // 
            // fullscreen
            // 
            this.fullscreen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.fullscreen.CheckOnClick = true;
            this.fullscreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fullscreen.Image = global::VideoTapes.Properties.Resources.full_screen_64;
            this.fullscreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fullscreen.Name = "fullscreen";
            this.fullscreen.Size = new System.Drawing.Size(23, 22);
            this.fullscreen.Text = "Plein Ecran";
            this.fullscreen.CheckedChanged += new System.EventHandler(this.Fullscreen_CheckedChanged);
            // 
            // searchScene
            // 
            this.searchScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchScene.Image = global::VideoTapes.Properties.Resources.SearchFolderHS;
            this.searchScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchScene.Name = "searchScene";
            this.searchScene.Size = new System.Drawing.Size(23, 22);
            this.searchScene.Text = "toolStripButton1";
            this.searchScene.Click += new System.EventHandler(this.searchScene_Click);
            // 
            // Tapes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 855);
            this.Controls.Add(this.splitContainerMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tapes";
            this.Text = "Tapes";
            this.Load += new System.EventHandler(this.Tapes_Load);
            this.splitContainerPrincipal.Panel1.ResumeLayout(false);
            this.splitContainerPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPrincipal)).EndInit();
            this.splitContainerPrincipal.ResumeLayout(false);
            this.splitContainerVideos.Panel1.ResumeLayout(false);
            this.splitContainerVideos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVideos)).EndInit();
            this.splitContainerVideos.ResumeLayout(false);
            this.splitContainerDétailsVidéo.Panel1.ResumeLayout(false);
            this.splitContainerDétailsVidéo.Panel1.PerformLayout();
            this.splitContainerDétailsVidéo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDétailsVidéo)).EndInit();
            this.splitContainerDétailsVidéo.ResumeLayout(false);
            this.tabControlInfo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainerTimeLine.Panel1.ResumeLayout(false);
            this.splitContainerTimeLine.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTimeLine)).EndInit();
            this.splitContainerTimeLine.ResumeLayout(false);
            this.splitContainerScenes.Panel1.ResumeLayout(false);
            this.splitContainerScenes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScenes)).EndInit();
            this.splitContainerScenes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.splitContainerToolStrip.Panel1.ResumeLayout(false);
            this.splitContainerToolStrip.Panel1.PerformLayout();
            this.splitContainerToolStrip.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerToolStrip)).EndInit();
            this.splitContainerToolStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainerMenu.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenu)).EndInit();
            this.splitContainerMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerPrincipal;
        private System.Windows.Forms.ListBox videos;
        private System.Windows.Forms.SplitContainer splitContainerVideos;
        private System.Windows.Forms.SplitContainer splitContainerToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nouveauToolStripButton;
        private System.Windows.Forms.ToolStripButton ouvrirToolStripButton;
        private System.Windows.Forms.ToolStripButton enregistrerToolStripButton;
        private System.Windows.Forms.ToolStripButton imprimerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton couperToolStripButton;
        private System.Windows.Forms.ToolStripButton copierToolStripButton;
        private System.Windows.Forms.ToolStripButton collerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        private System.Windows.Forms.ToolStripLabel local;
        private System.Windows.Forms.ToolStripLabel global;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer splitContainerTimeLine;
        private System.Windows.Forms.SplitContainer splitContainerDétailsVidéo;
        private System.Windows.Forms.TextBox bdFrames;
        private System.Windows.Forms.Label labelFrame;
        private System.Windows.Forms.TextBox bdDuration;
        private System.Windows.Forms.Label labelDurée;
        private System.Windows.Forms.Button MetaJour;
        private System.Windows.Forms.TextBox bdNumberOfScenes;
        private System.Windows.Forms.Label labelScénes;
        private System.Windows.Forms.TextBox bdNumberOfShots;
        private System.Windows.Forms.Label labelShots;
        private System.Windows.Forms.TextBox bdTitreBande;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.TextBox bdTitreFichier;
        private System.Windows.Forms.Label labelFichier;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox bdPeriode;
        private System.Windows.Forms.TextBox bdComment;
        private System.Windows.Forms.Label labelPériode;
        private System.Windows.Forms.SplitContainer splitContainerScenes;
        private SceneIndexControl sceneIndexControl;
        private DataSelector dataSelector;
        private System.Windows.Forms.ToolStripButton détails;
        private System.Windows.Forms.ToolStripButton ZoomIn;
        private System.Windows.Forms.ToolStripButton ZoomOut;
        private DisplayScenesPanel displayScenesPanel;
        private System.Windows.Forms.SplitContainer splitContainerMenu;
        private TimeLine timeLine;
        private System.Windows.Forms.ToolStripLabel toolStripLabel;
        private System.Windows.Forms.TabControl tabControlInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton drawRoute;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.ToolStripButton fullscreen;
        private System.Windows.Forms.ToolStripTextBox sceneNumber;
        private System.Windows.Forms.ToolStripButton searchScene;
    }
}

