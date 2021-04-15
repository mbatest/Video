namespace VideoTapes
{
    partial class DisplayScenesPanel
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
            this.scrollPictures.Location = new System.Drawing.Point(479, 0);
            this.scrollPictures.Maximum = 1000;
            this.scrollPictures.Name = "scrollPictures";
            this.scrollPictures.Size = new System.Drawing.Size(17, 356);
            this.scrollPictures.SmallChange = 5;
            this.scrollPictures.TabIndex = 1;
            this.scrollPictures.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollPictures_Scroll);
            this.scrollPictures.ValueChanged += new System.EventHandler(this.scrollPictures_ValueChanged);
            // 
            // DisplayScenesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollPictures);
            this.Name = "DisplayScenesPanel";
            this.Size = new System.Drawing.Size(496, 356);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayPanel_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayPanel_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar scrollPictures;
    }
}
