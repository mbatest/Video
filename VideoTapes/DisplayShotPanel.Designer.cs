namespace VideoTapes
{
    partial class DisplayShotsPanel
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
            this.scrollPictures = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // scrollPictures
            // 
            this.scrollPictures.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrollPictures.Location = new System.Drawing.Point(457, 0);
            this.scrollPictures.Name = "scrollPictures";
            this.scrollPictures.Size = new System.Drawing.Size(17, 259);
            this.scrollPictures.TabIndex = 0;
            this.scrollPictures.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollPictures_Scroll);
            // 
            // DisplayPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollPictures);
            this.DoubleBuffered = true;
            this.Name = "DisplayPanel";
            this.Size = new System.Drawing.Size(474, 259);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayPanel_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayPanel_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar scrollPictures;
    }
}
