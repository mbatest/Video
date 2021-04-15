namespace Route
{
    partial class DrawRoute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawRoute));
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.aVCHD1488XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aVCHD1920X1080ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Etiq = new System.Windows.Forms.ToolStripTextBox();
            this.lb = new System.Windows.Forms.ToolStripLabel();
            this.labelColor = new System.Windows.Forms.ToolStripButton();
            this.vehicleStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.busToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerPrincipal = new System.Windows.Forms.SplitContainer();
            this.drawPanel = new Route.DoubleBufferPanel();
            this.drawRecord = new Route.DoubleBufferPanel();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.dVD720X576ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movieType = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.nombreImages = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ouvrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imprimerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.couperToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copierToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.collerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Record = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.movieLength = new Route.ToolStripSlider();
            this.lineWidth = new Route.ToolStripSlider();
            this.labFont = new System.Windows.Forms.ToolStripButton();
            this.play = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPrincipal)).BeginInit();
            this.splitContainerPrincipal.Panel1.SuspendLayout();
            this.splitContainerPrincipal.Panel2.SuspendLayout();
            this.splitContainerPrincipal.SuspendLayout();
            this.drawRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 422);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1021, 17);
            this.hScrollBar1.TabIndex = 5;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // aVCHD1488XToolStripMenuItem
            // 
            this.aVCHD1488XToolStripMenuItem.Name = "aVCHD1488XToolStripMenuItem";
            this.aVCHD1488XToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aVCHD1488XToolStripMenuItem.Text = "AVCHD 1488 x";
            this.aVCHD1488XToolStripMenuItem.Click += new System.EventHandler(this.aVCHD1488XToolStripMenuItem_Click);
            // 
            // aVCHD1920X1080ToolStripMenuItem
            // 
            this.aVCHD1920X1080ToolStripMenuItem.Name = "aVCHD1920X1080ToolStripMenuItem";
            this.aVCHD1920X1080ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aVCHD1920X1080ToolStripMenuItem.Text = "AVCHD 1920 x 1080";
            this.aVCHD1920X1080ToolStripMenuItem.Click += new System.EventHandler(this.aVCHD1920X1080ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // Etiq
            // 
            this.Etiq.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Etiq.Name = "Etiq";
            this.Etiq.Size = new System.Drawing.Size(50, 26);
            this.Etiq.ToolTipText = "Etiquette";
            this.Etiq.TextChanged += new System.EventHandler(this.Etiq_TextChanged);
            // 
            // lb
            // 
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(39, 23);
            this.lb.Text = "Width";
            // 
            // labelColor
            // 
            this.labelColor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.labelColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelColor.Image = ((System.Drawing.Image)(resources.GetObject("labelColor.Image")));
            this.labelColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(23, 23);
            this.labelColor.ToolTipText = "Couleur";
            this.labelColor.Click += new System.EventHandler(this.LabelColor_Click);
            // 
            // vehicleStripDropDownButton
            // 
            this.vehicleStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.vehicleStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.busToolStripMenuItem,
            this.carToolStripMenuItem,
            this.planeToolStripMenuItem,
            this.trainToolStripMenuItem});
            this.vehicleStripDropDownButton.Image = global::Route.Properties.Resources.avion_50;
            this.vehicleStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.vehicleStripDropDownButton.Name = "vehicleStripDropDownButton";
            this.vehicleStripDropDownButton.Size = new System.Drawing.Size(29, 23);
            this.vehicleStripDropDownButton.Text = "toolStripDropDownButton1";
            this.vehicleStripDropDownButton.ToolTipText = "Icone";
            // 
            // busToolStripMenuItem
            // 
            this.busToolStripMenuItem.Image = global::Route.Properties.Resources.Autobus_50;
            this.busToolStripMenuItem.Name = "busToolStripMenuItem";
            this.busToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.busToolStripMenuItem.Text = "Bus";
            this.busToolStripMenuItem.Click += new System.EventHandler(this.busToolStripMenuItem_Click);
            // 
            // carToolStripMenuItem
            // 
            this.carToolStripMenuItem.Image = global::Route.Properties.Resources.Voiture46108;
            this.carToolStripMenuItem.Name = "carToolStripMenuItem";
            this.carToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.carToolStripMenuItem.Text = "Car";
            this.carToolStripMenuItem.Click += new System.EventHandler(this.carToolStripMenuItem_Click);
            // 
            // planeToolStripMenuItem
            // 
            this.planeToolStripMenuItem.Image = global::Route.Properties.Resources.avion_50;
            this.planeToolStripMenuItem.Name = "planeToolStripMenuItem";
            this.planeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.planeToolStripMenuItem.Text = "Plane";
            this.planeToolStripMenuItem.Click += new System.EventHandler(this.planeToolStripMenuItem_Click);
            // 
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.Image = global::Route.Properties.Resources.Train_50;
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.trainToolStripMenuItem.Text = "Train";
            this.trainToolStripMenuItem.Click += new System.EventHandler(this.trainToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainerPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPrincipal.Location = new System.Drawing.Point(0, 26);
            this.splitContainerPrincipal.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainerPrincipal.Panel1.Controls.Add(this.drawPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainerPrincipal.Panel2.Controls.Add(this.drawRecord);
            this.splitContainerPrincipal.Size = new System.Drawing.Size(1021, 413);
            this.splitContainerPrincipal.SplitterDistance = 596;
            this.splitContainerPrincipal.TabIndex = 9;
            // 
            // drawPanel
            // 
            this.drawPanel.AutoScroll = true;
            this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanel.Location = new System.Drawing.Point(0, 0);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(596, 413);
            this.drawPanel.TabIndex = 3;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanel_Paint);
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseMove);
            this.drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseUp);
            // 
            // drawRecord
            // 
            this.drawRecord.Controls.Add(this.mediaPlayer);
            this.drawRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawRecord.Location = new System.Drawing.Point(0, 0);
            this.drawRecord.Name = "drawRecord";
            this.drawRecord.Size = new System.Drawing.Size(421, 413);
            this.drawRecord.TabIndex = 1;
            this.drawRecord.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawRecord_Paint);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(421, 413);
            this.mediaPlayer.TabIndex = 0;
            this.mediaPlayer.Resize += new System.EventHandler(this.mediaPlayer_Resize);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(1021, 26);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 413);
            this.vScrollBar1.TabIndex = 6;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // dVD720X576ToolStripMenuItem
            // 
            this.dVD720X576ToolStripMenuItem.Name = "dVD720X576ToolStripMenuItem";
            this.dVD720X576ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.dVD720X576ToolStripMenuItem.Text = "DVD 720 x 576";
            this.dVD720X576ToolStripMenuItem.Click += new System.EventHandler(this.dVD720X576ToolStripMenuItem_Click);
            // 
            // movieType
            // 
            this.movieType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dVD720X576ToolStripMenuItem,
            this.aVCHD1488XToolStripMenuItem,
            this.aVCHD1920X1080ToolStripMenuItem});
            this.movieType.Image = ((System.Drawing.Image)(resources.GetObject("movieType.Image")));
            this.movieType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.movieType.Name = "movieType";
            this.movieType.Size = new System.Drawing.Size(180, 23);
            this.movieType.Text = "toolStripDropDownButton1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nombreImages});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1038, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // nombreImages
            // 
            this.nombreImages.Name = "nombreImages";
            this.nombreImages.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripButton,
            this.imprimerToolStripButton,
            this.toolStripSeparator,
            this.couperToolStripButton,
            this.copierToolStripButton,
            this.collerToolStripButton,
            this.toolStripSeparator1,
            this.ZoomOut,
            this.ZoomIn,
            this.toolStripSeparator2,
            this.Record,
            this.toolStripLabel1,
            this.ToolStripButton,
            this.movieLength,
            this.movieType,
            this.toolStripSeparator3,
            this.lb,
            this.lineWidth,
            this.labelColor,
            this.labFont,
            this.Etiq,
            this.vehicleStripDropDownButton,
            this.play});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1038, 26);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ouvrirToolStripButton
            // 
            this.ouvrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ouvrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ouvrirToolStripButton.Image")));
            this.ouvrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ouvrirToolStripButton.Name = "ouvrirToolStripButton";
            this.ouvrirToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.ouvrirToolStripButton.Text = "&Ouvrir";
            this.ouvrirToolStripButton.Click += new System.EventHandler(this.ouvrirToolStripButton_Click);
            // 
            // imprimerToolStripButton
            // 
            this.imprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("imprimerToolStripButton.Image")));
            this.imprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimerToolStripButton.Name = "imprimerToolStripButton";
            this.imprimerToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.imprimerToolStripButton.Text = "&Imprimer";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 26);
            // 
            // couperToolStripButton
            // 
            this.couperToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.couperToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("couperToolStripButton.Image")));
            this.couperToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.couperToolStripButton.Name = "couperToolStripButton";
            this.couperToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.couperToolStripButton.Text = "C&ouper";
            // 
            // copierToolStripButton
            // 
            this.copierToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copierToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copierToolStripButton.Image")));
            this.copierToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copierToolStripButton.Name = "copierToolStripButton";
            this.copierToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.copierToolStripButton.Text = "Co&pier";
            // 
            // collerToolStripButton
            // 
            this.collerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.collerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("collerToolStripButton.Image")));
            this.collerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collerToolStripButton.Name = "collerToolStripButton";
            this.collerToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.collerToolStripButton.Text = "Co&ller";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // ZoomOut
            // 
            this.ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOut.Image")));
            this.ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(23, 23);
            this.ZoomOut.Text = "ZoomOut";
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // ZoomIn
            // 
            this.ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomIn.Image")));
            this.ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(23, 23);
            this.ZoomIn.Text = "ZoomIn";
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // Record
            // 
            this.Record.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Record.Image = ((System.Drawing.Image)(resources.GetObject("Record.Image")));
            this.Record.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(23, 23);
            this.Record.Text = "Record";
            this.Record.Click += new System.EventHandler(this.Record_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 23);
            this.toolStripLabel1.Text = "Movie length";
            this.toolStripLabel1.Click += new System.EventHandler(this.MovieLength_ValueChanged);
            // 
            // ToolStripButton
            // 
            this.ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton.Image")));
            this.ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton.Name = "ToolStripButton";
            this.ToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.ToolStripButton.Text = "&?";
            // 
            // movieLength
            // 
            this.movieLength.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.movieLength.Name = "movieLength";
            this.movieLength.Size = new System.Drawing.Size(41, 23);
            this.movieLength.Text = "0";
            this.movieLength.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lineWidth
            // 
            this.lineWidth.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(41, 23);
            this.lineWidth.Text = "0";
            this.lineWidth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lineWidth.ValueChanged += new System.EventHandler(this.lineWidth_ValueChanged);
            // 
            // labFont
            // 
            this.labFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.labFont.Image = global::Route.Properties.Resources.TextBox_708;
            this.labFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.labFont.Name = "labFont";
            this.labFont.Size = new System.Drawing.Size(23, 23);
            this.labFont.Text = "Police";
            this.labFont.Click += new System.EventHandler(this.LabFont_Click);
            // 
            // play
            // 
            this.play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.play.Image = ((System.Drawing.Image)(resources.GetObject("play.Image")));
            this.play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(23, 23);
            this.play.Text = "Play film";
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // DrawRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 461);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.splitContainerPrincipal);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DrawRoute";
            this.Text = "Draw Route";
            this.splitContainerPrincipal.Panel1.ResumeLayout(false);
            this.splitContainerPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPrincipal)).EndInit();
            this.splitContainerPrincipal.ResumeLayout(false);
            this.drawRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.ToolStripMenuItem aVCHD1488XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aVCHD1920X1080ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox Etiq;
        private System.Windows.Forms.ToolStripLabel lb;
        private System.Windows.Forms.ToolStripButton labelColor;
        private System.Windows.Forms.ToolStripDropDownButton vehicleStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem busToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerPrincipal;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ToolStripMenuItem dVD720X576ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton movieType;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel nombreImages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ouvrirToolStripButton;
        private System.Windows.Forms.ToolStripButton imprimerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton couperToolStripButton;
        private System.Windows.Forms.ToolStripButton copierToolStripButton;
        private System.Windows.Forms.ToolStripButton collerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ZoomOut;
        private System.Windows.Forms.ToolStripButton ZoomIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Record;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        private ToolStripSlider movieLength;
        private ToolStripSlider lineWidth;
        private DoubleBufferPanel drawPanel;
        private DoubleBufferPanel drawRecord;
        private System.Windows.Forms.ToolStripButton labFont;
        private System.Windows.Forms.ToolStripButton play;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
    }
}

