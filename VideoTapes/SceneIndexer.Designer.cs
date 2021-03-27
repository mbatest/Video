namespace VideoTapes
{
    partial class SceneIndexControl
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.Famille = new System.Windows.Forms.ComboBox();
            this.Prenom = new System.Windows.Forms.TextBox();
            this.NouvFamille = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listPersons = new System.Windows.Forms.ListView();
            this.cBPersonnes = new System.Windows.Forms.ComboBox();
            this.AddPerson = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.keywordList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.cBKeyword = new System.Windows.Forms.ComboBox();
            this.AddKey = new System.Windows.Forms.Button();
            this.newKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SceneTitleLabel = new System.Windows.Forms.Label();
            this.lbCom = new System.Windows.Forms.Label();
            this.SceneTitle = new System.Windows.Forms.TextBox();
            this.comment = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panDetailSeq = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Duration = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ShotNumber = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nouvVille = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nouvLieu = new System.Windows.Forms.TextBox();
            this.cBVille = new System.Windows.Forms.ComboBox();
            this.lbPays = new System.Windows.Forms.Label();
            this.lbLieu = new System.Windows.Forms.Label();
            this.lbVille = new System.Windows.Forms.Label();
            this.cBPays = new System.Windows.Forms.ComboBox();
            this.cBLieu = new System.Windows.Forms.ComboBox();
            this.Valid = new System.Windows.Forms.Button();
            this.keyword = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panDetailSeq.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.Famille);
            this.tabPage2.Controls.Add(this.Prenom);
            this.tabPage2.Controls.Add(this.NouvFamille);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.listPersons);
            this.tabPage2.Controls.Add(this.cBPersonnes);
            this.tabPage2.Controls.Add(this.AddPerson);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(229, 162);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Personnes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 78;
            this.label17.Text = "Nom";
            // 
            // Famille
            // 
            this.Famille.FormattingEnabled = true;
            this.Famille.Location = new System.Drawing.Point(43, 114);
            this.Famille.Name = "Famille";
            this.Famille.Size = new System.Drawing.Size(95, 21);
            this.Famille.TabIndex = 10;
            // 
            // Prenom
            // 
            this.Prenom.Location = new System.Drawing.Point(48, 140);
            this.Prenom.Name = "Prenom";
            this.Prenom.Size = new System.Drawing.Size(127, 20);
            this.Prenom.TabIndex = 12;
            this.Prenom.TextChanged += new System.EventHandler(this.NouvFamille_TextChanged);
            // 
            // NouvFamille
            // 
            this.NouvFamille.Location = new System.Drawing.Point(146, 114);
            this.NouvFamille.Name = "NouvFamille";
            this.NouvFamille.Size = new System.Drawing.Size(77, 20);
            this.NouvFamille.TabIndex = 11;
            this.NouvFamille.TextChanged += new System.EventHandler(this.NouvFamille_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 83;
            this.label15.Text = "Prénom";
            // 
            // listPersons
            // 
            this.listPersons.HideSelection = false;
            this.listPersons.Location = new System.Drawing.Point(8, 6);
            this.listPersons.Name = "listPersons";
            this.listPersons.Size = new System.Drawing.Size(215, 77);
            this.listPersons.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listPersons.TabIndex = 77;
            this.listPersons.UseCompatibleStateImageBehavior = false;
            this.listPersons.SelectedIndexChanged += new System.EventHandler(this.ListPersons_SelectedIndexChanged);
            this.listPersons.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListPersons_MouseClick);
            // 
            // cBPersonnes
            // 
            this.cBPersonnes.FormattingEnabled = true;
            this.cBPersonnes.Location = new System.Drawing.Point(10, 89);
            this.cBPersonnes.Name = "cBPersonnes";
            this.cBPersonnes.Size = new System.Drawing.Size(143, 21);
            this.cBPersonnes.TabIndex = 9;
            this.cBPersonnes.SelectedIndexChanged += new System.EventHandler(this.CBPersonnes_SelectedIndexChanged);
            // 
            // AddPerson
            // 
            this.AddPerson.Enabled = false;
            this.AddPerson.Location = new System.Drawing.Point(161, 88);
            this.AddPerson.Name = "AddPerson";
            this.AddPerson.Size = new System.Drawing.Size(56, 25);
            this.AddPerson.TabIndex = 13;
            this.AddPerson.Text = "Ajouter";
            this.AddPerson.UseVisualStyleBackColor = true;
            this.AddPerson.Click += new System.EventHandler(this.AddPerson_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.keywordList);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.cBKeyword);
            this.tabPage3.Controls.Add(this.AddKey);
            this.tabPage3.Controls.Add(this.newKeyword);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(229, 162);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mot-clé";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // keywordList
            // 
            this.keywordList.HideSelection = false;
            this.keywordList.Location = new System.Drawing.Point(7, 7);
            this.keywordList.Name = "keywordList";
            this.keywordList.Size = new System.Drawing.Size(217, 59);
            this.keywordList.TabIndex = 80;
            this.keywordList.UseCompatibleStateImageBehavior = false;
            this.keywordList.SelectedIndexChanged += new System.EventHandler(this.KeywordList_SelectedIndexChanged);
            this.keywordList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.KeywordList_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Mot-clé";
            // 
            // cBKeyword
            // 
            this.cBKeyword.FormattingEnabled = true;
            this.cBKeyword.Location = new System.Drawing.Point(90, 71);
            this.cBKeyword.Name = "cBKeyword";
            this.cBKeyword.Size = new System.Drawing.Size(126, 21);
            this.cBKeyword.TabIndex = 14;
            this.cBKeyword.SelectedIndexChanged += new System.EventHandler(this.CBKeyword_SelectedIndexChanged);
            // 
            // AddKey
            // 
            this.AddKey.Enabled = false;
            this.AddKey.Location = new System.Drawing.Point(141, 122);
            this.AddKey.Name = "AddKey";
            this.AddKey.Size = new System.Drawing.Size(75, 23);
            this.AddKey.TabIndex = 79;
            this.AddKey.Text = "Ajouter";
            this.AddKey.UseVisualStyleBackColor = true;
            this.AddKey.Click += new System.EventHandler(this.AddKey_Click);
            // 
            // newKeyword
            // 
            this.newKeyword.Location = new System.Drawing.Point(90, 96);
            this.newKeyword.Name = "newKeyword";
            this.newKeyword.Size = new System.Drawing.Size(126, 20);
            this.newKeyword.TabIndex = 15;
            this.newKeyword.TextChanged += new System.EventHandler(this.NewKeyword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Nouveau";
            // 
            // SceneTitleLabel
            // 
            this.SceneTitleLabel.AutoSize = true;
            this.SceneTitleLabel.Location = new System.Drawing.Point(5, 17);
            this.SceneTitleLabel.Name = "SceneTitleLabel";
            this.SceneTitleLabel.Size = new System.Drawing.Size(28, 13);
            this.SceneTitleLabel.TabIndex = 37;
            this.SceneTitleLabel.Text = "Titre";
            // 
            // lbCom
            // 
            this.lbCom.AutoSize = true;
            this.lbCom.Location = new System.Drawing.Point(5, 38);
            this.lbCom.Name = "lbCom";
            this.lbCom.Size = new System.Drawing.Size(51, 13);
            this.lbCom.TabIndex = 36;
            this.lbCom.Text = "Comment";
            // 
            // SceneTitle
            // 
            this.SceneTitle.Location = new System.Drawing.Point(60, 13);
            this.SceneTitle.Name = "SceneTitle";
            this.SceneTitle.Size = new System.Drawing.Size(106, 20);
            this.SceneTitle.TabIndex = 1;
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(60, 37);
            this.comment.Multiline = true;
            this.comment.Name = "comment";
            this.comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.comment.Size = new System.Drawing.Size(181, 20);
            this.comment.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(253, 281);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 75;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panDetailSeq);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 281);
            this.panel1.TabIndex = 35;
            // 
            // panDetailSeq
            // 
            this.panDetailSeq.AutoScroll = true;
            this.panDetailSeq.Controls.Add(this.groupBox1);
            this.panDetailSeq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetailSeq.Location = new System.Drawing.Point(0, 0);
            this.panDetailSeq.Name = "panDetailSeq";
            this.panDetailSeq.Size = new System.Drawing.Size(253, 281);
            this.panDetailSeq.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Duration);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ShotNumber);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.Valid);
            this.groupBox1.Controls.Add(this.SceneTitleLabel);
            this.groupBox1.Controls.Add(this.lbCom);
            this.groupBox1.Controls.Add(this.SceneTitle);
            this.groupBox1.Controls.Add(this.comment);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 281);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Durée";
            // 
            // Duration
            // 
            this.Duration.Location = new System.Drawing.Point(159, 60);
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Size = new System.Drawing.Size(82, 20);
            this.Duration.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Clips";
            // 
            // ShotNumber
            // 
            this.ShotNumber.Location = new System.Drawing.Point(61, 59);
            this.ShotNumber.Name = "ShotNumber";
            this.ShotNumber.ReadOnly = true;
            this.ShotNumber.Size = new System.Drawing.Size(39, 20);
            this.ShotNumber.TabIndex = 44;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(9, 86);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(237, 188);
            this.tabControl1.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.cBVille);
            this.tabPage1.Controls.Add(this.lbPays);
            this.tabPage1.Controls.Add(this.lbLieu);
            this.tabPage1.Controls.Add(this.lbVille);
            this.tabPage1.Controls.Add(this.cBPays);
            this.tabPage1.Controls.Add(this.cBLieu);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(229, 162);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lieu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nouvVille);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nouvLieu);
            this.groupBox2.Location = new System.Drawing.Point(13, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 63);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nouveau lieu";
            // 
            // nouvVille
            // 
            this.nouvVille.Location = new System.Drawing.Point(69, 14);
            this.nouvVille.Name = "nouvVille";
            this.nouvVille.Size = new System.Drawing.Size(117, 20);
            this.nouvVille.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Lieu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Ville";
            // 
            // nouvLieu
            // 
            this.nouvLieu.Location = new System.Drawing.Point(69, 37);
            this.nouvLieu.Name = "nouvLieu";
            this.nouvLieu.Size = new System.Drawing.Size(117, 20);
            this.nouvLieu.TabIndex = 8;
            // 
            // cBVille
            // 
            this.cBVille.FormattingEnabled = true;
            this.cBVille.Location = new System.Drawing.Point(76, 29);
            this.cBVille.Name = "cBVille";
            this.cBVille.Size = new System.Drawing.Size(123, 21);
            this.cBVille.TabIndex = 4;
            this.cBVille.SelectedIndexChanged += new System.EventHandler(this.CBVille_SelectedIndexChanged);
            // 
            // lbPays
            // 
            this.lbPays.AutoSize = true;
            this.lbPays.Location = new System.Drawing.Point(10, 13);
            this.lbPays.Name = "lbPays";
            this.lbPays.Size = new System.Drawing.Size(30, 13);
            this.lbPays.TabIndex = 32;
            this.lbPays.Text = "Pays";
            // 
            // lbLieu
            // 
            this.lbLieu.AutoSize = true;
            this.lbLieu.Location = new System.Drawing.Point(11, 56);
            this.lbLieu.Name = "lbLieu";
            this.lbLieu.Size = new System.Drawing.Size(27, 13);
            this.lbLieu.TabIndex = 34;
            this.lbLieu.Text = "Lieu";
            // 
            // lbVille
            // 
            this.lbVille.AutoSize = true;
            this.lbVille.Location = new System.Drawing.Point(11, 32);
            this.lbVille.Name = "lbVille";
            this.lbVille.Size = new System.Drawing.Size(26, 13);
            this.lbVille.TabIndex = 30;
            this.lbVille.Text = "Ville";
            // 
            // cBPays
            // 
            this.cBPays.FormattingEnabled = true;
            this.cBPays.Location = new System.Drawing.Point(76, 5);
            this.cBPays.Name = "cBPays";
            this.cBPays.Size = new System.Drawing.Size(123, 21);
            this.cBPays.TabIndex = 3;
            this.cBPays.SelectedIndexChanged += new System.EventHandler(this.CBPays_SelectedIndexChanged);
            // 
            // cBLieu
            // 
            this.cBLieu.FormattingEnabled = true;
            this.cBLieu.Location = new System.Drawing.Point(48, 53);
            this.cBLieu.Name = "cBLieu";
            this.cBLieu.Size = new System.Drawing.Size(175, 21);
            this.cBLieu.TabIndex = 5;
            // 
            // Valid
            // 
            this.Valid.Enabled = false;
            this.Valid.Location = new System.Drawing.Point(186, 11);
            this.Valid.Name = "Valid";
            this.Valid.Size = new System.Drawing.Size(55, 25);
            this.Valid.TabIndex = 39;
            this.Valid.Text = "Valid";
            this.Valid.UseVisualStyleBackColor = true;
            this.Valid.Click += new System.EventHandler(this.Valid_Click);
            // 
            // keyword
            // 
            this.keyword.FormattingEnabled = true;
            this.keyword.Location = new System.Drawing.Point(95, 19);
            this.keyword.Name = "keyword";
            this.keyword.Size = new System.Drawing.Size(101, 21);
            this.keyword.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "New keyword";
            // 
            // SceneIndexControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.keyword);
            this.Controls.Add(this.label6);
            this.Name = "SceneIndexControl";
            this.Size = new System.Drawing.Size(253, 281);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panDetailSeq.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox Famille;
        private System.Windows.Forms.TextBox Prenom;
        private System.Windows.Forms.TextBox NouvFamille;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView listPersons;
        private System.Windows.Forms.ComboBox cBPersonnes;
        private System.Windows.Forms.Button AddPerson;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView keywordList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBKeyword;
        private System.Windows.Forms.Button AddKey;
        private System.Windows.Forms.TextBox newKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SceneTitleLabel;
        private System.Windows.Forms.Label lbCom;
        private System.Windows.Forms.TextBox SceneTitle;
        private System.Windows.Forms.TextBox comment;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panDetailSeq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Duration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ShotNumber;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox nouvVille;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nouvLieu;
        private System.Windows.Forms.ComboBox cBVille;
        private System.Windows.Forms.Label lbPays;
        private System.Windows.Forms.Label lbLieu;
        private System.Windows.Forms.Label lbVille;
        private System.Windows.Forms.ComboBox cBPays;
        private System.Windows.Forms.ComboBox cBLieu;
        private System.Windows.Forms.Button Valid;
        private System.Windows.Forms.ComboBox keyword;
        private System.Windows.Forms.Label label6;
    }
}
