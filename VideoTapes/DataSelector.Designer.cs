namespace VideoTapes
{
    partial class DataSelector
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
            this.endPicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.beginPicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.keywordList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchKeyword = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Personnes = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.AjoutPersonne = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.paysLieux = new System.Windows.Forms.ComboBox();
            this.lieuValid = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBPays = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // endPicker
            // 
            this.endPicker.Location = new System.Drawing.Point(7, 62);
            this.endPicker.Name = "endPicker";
            this.endPicker.Size = new System.Drawing.Size(193, 20);
            this.endPicker.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Fin";
            // 
            // beginPicker
            // 
            this.beginPicker.Location = new System.Drawing.Point(9, 23);
            this.beginPicker.Name = "beginPicker";
            this.beginPicker.Size = new System.Drawing.Size(193, 20);
            this.beginPicker.TabIndex = 65;
            this.beginPicker.ValueChanged += new System.EventHandler(this.beginPicker_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 63;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.endPicker);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.beginPicker);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(215, 115);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Date";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Début";
            // 
            // keywordList
            // 
            this.keywordList.FormattingEnabled = true;
            this.keywordList.Location = new System.Drawing.Point(66, 7);
            this.keywordList.Name = "keywordList";
            this.keywordList.Size = new System.Drawing.Size(139, 21);
            this.keywordList.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "Mot -Clés";
            // 
            // searchKeyword
            // 
            this.searchKeyword.Location = new System.Drawing.Point(65, 41);
            this.searchKeyword.Name = "searchKeyword";
            this.searchKeyword.Size = new System.Drawing.Size(75, 23);
            this.searchKeyword.TabIndex = 73;
            this.searchKeyword.Text = "Select";
            this.searchKeyword.UseVisualStyleBackColor = true;
            this.searchKeyword.Click += new System.EventHandler(this.searchKeywords_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.keywordList);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.searchKeyword);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(215, 115);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Mot-Clés";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Personnes
            // 
            this.Personnes.FormattingEnabled = true;
            this.Personnes.Location = new System.Drawing.Point(60, 15);
            this.Personnes.Name = "Personnes";
            this.Personnes.Size = new System.Drawing.Size(139, 21);
            this.Personnes.TabIndex = 71;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 63;
            this.label17.Text = "Nom";
            // 
            // AjoutPersonne
            // 
            this.AjoutPersonne.Location = new System.Drawing.Point(60, 42);
            this.AjoutPersonne.Name = "AjoutPersonne";
            this.AjoutPersonne.Size = new System.Drawing.Size(75, 23);
            this.AjoutPersonne.TabIndex = 69;
            this.AjoutPersonne.Text = "Select";
            this.AjoutPersonne.UseVisualStyleBackColor = true;
            this.AjoutPersonne.Click += new System.EventHandler(this.SelectPersonne_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Personnes);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.AjoutPersonne);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 109);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(215, 115);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Personnes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Lieux";
            // 
            // paysLieux
            // 
            this.paysLieux.FormattingEnabled = true;
            this.paysLieux.Location = new System.Drawing.Point(44, 36);
            this.paysLieux.Name = "paysLieux";
            this.paysLieux.Size = new System.Drawing.Size(159, 21);
            this.paysLieux.TabIndex = 57;
            // 
            // lieuValid
            // 
            this.lieuValid.Location = new System.Drawing.Point(61, 62);
            this.lieuValid.Name = "lieuValid";
            this.lieuValid.Size = new System.Drawing.Size(75, 23);
            this.lieuValid.TabIndex = 62;
            this.lieuValid.Text = "Select";
            this.lieuValid.UseVisualStyleBackColor = true;
            this.lieuValid.Click += new System.EventHandler(this.SelectLieu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBPays);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.paysLieux);
            this.groupBox1.Controls.Add(this.lieuValid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 109);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Pays";
            // 
            // cBPays
            // 
            this.cBPays.FormattingEnabled = true;
            this.cBPays.Location = new System.Drawing.Point(61, 10);
            this.cBPays.Name = "cBPays";
            this.cBPays.Size = new System.Drawing.Size(135, 21);
            this.cBPays.TabIndex = 64;
            this.cBPays.SelectedIndexChanged += new System.EventHandler(this.cBPays_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(215, 115);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lieux";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(223, 141);
            this.tabControl1.TabIndex = 75;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 160);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
            // 
            // DataSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "DataSelector";
            this.Size = new System.Drawing.Size(229, 160);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker endPicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker beginPicker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox keywordList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button searchKeyword;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox Personnes;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button AjoutPersonne;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox paysLieux;
        private System.Windows.Forms.Button lieuValid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBPays;
    }
}
