namespace VideoTapes
{
    partial class TimeLine
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeLine));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.smaller = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.ouvrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.enregistrerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomIn = new System.Windows.Forms.ToolStripButton();
            this.zoomOut = new System.Windows.Forms.ToolStripButton();
            this.bigger = new System.Windows.Forms.ToolStripButton();
            this.couperToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copierToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.collerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.play = new System.Windows.Forms.ToolStripButton();
            this.pause = new System.Windows.Forms.ToolStripButton();
            this.stop = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripButton();
            this.PlayAll = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripButton,
            this.enregistrerToolStripButton,
            this.toolStripSeparator2,
            this.zoomIn,
            this.zoomOut,
            this.smaller,
            this.bigger,
            this.toolStripSeparator,
            this.couperToolStripButton,
            this.copierToolStripButton,
            this.collerToolStripButton,
            this.toolStripSeparator1,
            this.ToolStripButton,
            this.PlayAll,
            this.play,
            this.pause,
            this.stop,
            this.toolStripSeparator3,
            this.export});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(759, 25);
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // smaller
            // 
            this.smaller.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.smaller.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.smaller.Name = "smaller";
            this.smaller.Size = new System.Drawing.Size(23, 22);
            this.smaller.Text = "-";
            this.smaller.Click += new System.EventHandler(this.Bigger_Click);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 179);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(759, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel1.Text = "                          ";
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.Location = new System.Drawing.Point(0, 162);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(759, 17);
            this.hScrollBar.TabIndex = 8;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBar_Scroll);
            // 
            // ouvrirToolStripButton
            // 
            this.ouvrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ouvrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ouvrirToolStripButton.Image")));
            this.ouvrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ouvrirToolStripButton.Name = "ouvrirToolStripButton";
            this.ouvrirToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ouvrirToolStripButton.Text = "&Ouvrir";
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
            // zoomIn
            // 
            this.zoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomIn.Image = ((System.Drawing.Image)(resources.GetObject("zoomIn.Image")));
            this.zoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(23, 22);
            this.zoomIn.Text = "Zoom In";
            // 
            // zoomOut
            // 
            this.zoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOut.Image = global::VideoTapes.Properties.Resources.ZoomOut_12927;
            this.zoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(23, 22);
            this.zoomOut.Text = "Zoom Out";
            // 
            // bigger
            // 
            this.bigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bigger.Image = ((System.Drawing.Image)(resources.GetObject("bigger.Image")));
            this.bigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bigger.Name = "bigger";
            this.bigger.Size = new System.Drawing.Size(23, 22);
            this.bigger.Text = "+";
            this.bigger.ToolTipText = "Bigger";
            this.bigger.Click += new System.EventHandler(this.Smaller_Click);
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
            // play
            // 
            this.play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.play.Image = ((System.Drawing.Image)(resources.GetObject("play.Image")));
            this.play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(23, 22);
            this.play.Text = "Play";
            this.play.Click += new System.EventHandler(this.Play_Click);
            // 
            // pause
            // 
            this.pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pause.Image = global::VideoTapes.Properties.Resources.PauseHS;
            this.pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(23, 22);
            this.pause.Text = "toolStripButton1";
            this.pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // stop
            // 
            this.stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stop.Image = global::VideoTapes.Properties.Resources.StopHS;
            this.stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(23, 22);
            this.stop.Text = "toolStripButton2";
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // export
            // 
            this.export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.export.Image = global::VideoTapes.Properties.Resources.export;
            this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(23, 22);
            this.export.Text = "Export Timeline";
            this.export.Click += new System.EventHandler(this.Export_Click);
            // 
            // PlayAll
            // 
            this.PlayAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PlayAll.Image = global::VideoTapes.Properties.Resources.Run;
            this.PlayAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayAll.Name = "PlayAll";
            this.PlayAll.Size = new System.Drawing.Size(23, 22);
            this.PlayAll.Text = "toolStripButton1";
            this.PlayAll.Click += new System.EventHandler(this.PlayAll_Click);
            // 
            // TimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Name = "TimeLine";
            this.Size = new System.Drawing.Size(759, 201);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TimeLine_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeLine_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimeLine_MouseMove);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton ouvrirToolStripButton;
        private System.Windows.Forms.ToolStripButton enregistrerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton zoomIn;
        private System.Windows.Forms.ToolStripButton zoomOut;
        private System.Windows.Forms.ToolStripButton smaller;
        private System.Windows.Forms.ToolStripButton bigger;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton couperToolStripButton;
        private System.Windows.Forms.ToolStripButton copierToolStripButton;
        private System.Windows.Forms.ToolStripButton collerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        private System.Windows.Forms.ToolStripButton play;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton pause;
        private System.Windows.Forms.ToolStripButton stop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton PlayAll;
    }
}
