using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoTapes
{
    public partial class SceneIndexControl : UserControl
    {
        public event SceneInfoChangedHandler SceneInfoChanged;
        Modèle md;
        #region Construction
        public SceneIndexControl()
        {
            InitializeComponent();
            listPersons.View = View.List;
            listPersons.Columns.Add("Nom", 100, HorizontalAlignment.Left);
            listPersons.Columns.Add("Prénom", 100, HorizontalAlignment.Left);
        }
        public void Init(Modèle m)
        {
            md = m;
            GetData();
            Valid.Enabled = false;
            AddKey.Enabled = false;
            AddPerson.Enabled = false;
            cBKeyword.SelectedIndex = -1;
            cBPersonnes.SelectedIndex = -1;
            Famille.SelectedIndex = -1;
        }
        public void SetScene(Scenes sc)
        {
            currentScene = sc;
            listPersons.Items.Clear();
            SceneTitle.Text = currentScene.Titre;
            comment.Text = currentScene.Commentaire;
            if (sc.Lieux != null)
            {
                cBPays.SelectedItem = sc.Lieux.Villes.Pays;
                cBPays.Text = sc.Lieux.Villes.Pays.Nom_Pays;
                cBVille.Text = sc.Lieux.Villes.Nom;
                cBLieu.Text = sc.Lieux.Lieu;
                cBVille.SelectedItem = sc.Lieux.Villes;
                cBLieu.SelectedItem = sc.Lieux;
            }
            else
            {
                cBPays.SelectedItem = md.Pays.Single(p => p.Nom_Pays == "France");
                cBVille.Text = "";
                cBLieu.Text = "";
                UpDateVilles((Pays)cBPays.SelectedItem);
            }
            ShotNumber.Text = currentScene.SequenceScene.Count.ToString();
            Duration.Text = Videos.DuréeShot(currentScene.FrameCount);
            keywordList.Items.Clear();
            foreach (var x in currentScene.KeywordScene)
            {
                AddKeywordToListView(x.Keywords);
            }
            if (currentScene.PrésenceScène != null)
                foreach (var p in currentScene.PrésenceScène)
                {
                    AddPersonToListView(p.Personnes);
                }

            Valid.Enabled = true;
        }
        //    public void SetScene(List<Scenes> sc)
        //    {
        //        scenes = sc;
        //        currentScene = sc[0];
        //        codes = null;
        // //       codes = Utils.accBd.GetCodesForPlace(currentScene.Code_Lieu);
        //        for (int i = 0; i < countries.Count; i++)
        //        {
        //            Pays ct = (Pays)countries[i];
        //            if (ct.Code_Pays == codes[1])
        //            {
        //                cBPays.SelectedIndex = i;
        //                break;
        //            }
        //        }
        // //       cBPays.SelectedItem= currentScene.

        //        if (cBPays.SelectedItem != null)
        //            UpDateVilles((Pays)cBPays.SelectedItem);
        //        SceneTitle.Text = currentScene.Commentaire;
        //        listPersons.Items.Clear();
        // //       personsInScene = Utils.accBd.GetPeopleInAScene(currentScene);
        //        foreach (Personne p in personsInScene)
        //        {
        //            AddPersonToList(p);
        //        }
        //        keywordList.Items.Clear();
        ////        keywords = Utils.accBd.GetKeywordInAScene(currentScene);
        //        foreach (Keywords k in keywords)
        //        {
        //            ListViewItem lst = new ListViewItem(k.Keyword);
        //            lst.Tag = k;
        //            keywordList.Items.Add(lst);
        //        }
        //        //ShotNumber.Text = currentScene.ShotsInScene.Count.ToString();
        //        //Duration.Text = currentScene.Duration.ToString();
        //        valid.Enabled = true;
        //        addKeyword.Enabled = false;
        //        AddPerson.Enabled = false;
        //        cBKeyword.SelectedIndex = -1;
        //        cBPersonnes.SelectedIndex = -1;
        //        Famille.SelectedIndex = -1;
        //        NouvFamille.Text = "";
        //        Prenom.Text = "";
        //    }
        #endregion
        #region Private members
        //List<Pays> countries;
        //List<Villes> cities;
        //List<Lieux> places;
        List<string> surnames;
        public Scenes currentScene;
        #endregion
        #region Private methods
        #region General
        private void GetData()
        {
            nouvLieu.Text = "";
            nouvVille.Text = "";
            NouvFamille.Text = "";
            Prenom.Text = "";
            newKeyword.Text = "";
            #region Lieux
            cBPays.DataSource = md.Pays.ToList();
            cBPays.Text = "France";
            #endregion
            #region Personnes
            cBPersonnes.DataSource = md.Personne.OrderBy(p => p.Prénom).ThenBy(p => p.Nom).ToList();
            surnames = new List<string>();
            Famille.Items.Clear();
            md.Personne.ToList().ForEach(p => surnames.Add(p.Nom));
            surnames.Distinct().ToList().ForEach(s => Famille.Items.Add(s));
            #endregion
            #region Mots clés
            cBKeyword.DataSource = md.Keywords.Distinct().OrderBy(k => k.Keyword).ToList();
            #endregion
        }
        private void Valid_Click(object sender, EventArgs e)
        {
            GetPlace();
            currentScene.Titre = SceneTitle.Text;
            currentScene.Commentaire = comment.Text;
            SceneInfoChanged?.Invoke(this, new SceneSelectedArgs { scene = currentScene });
            GetData();
            md.SaveChanges();
        }
        #endregion
        #region ListViews
        private void AddPersonToListView(Personne p)
        {
            ListViewItem lst = new ListViewItem(p.Prénom + " " + p.Nom)
            {
                Tag = p
            };
            lst.SubItems.Add(p.Prénom);
            listPersons.Items.Add(lst);
        }
        private void AddKeywordToListView(Keywords key)
        {
            ListViewItem lw = new ListViewItem(key.Keyword)
            {
                Tag = key
            };
            keywordList.Items.Add(lw);
        }
        #endregion
        #region Lieux
        private void CBPays_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpDateVilles((Pays)cBPays.SelectedItem);
        }
        private void CBVille_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpDateLieux((Villes)cBVille.SelectedItem);
        }
        private void UpDateVilles(Pays rech)
        {
            cBVille.Text = "";
            cBVille.DataSource = md.Villes.Where(v => v.Pays.Code_Pays == rech.Code_Pays).OrderBy(v => v.Nom).ToList();
            cBVille.AutoCompleteMode = AutoCompleteMode.Suggest;
            cBLieu.Text = "";
            if ((cBVille.SelectedItem == null) && (cBVille.Items.Count > 0))
                cBVille.SelectedIndex = 0;
            if (cBVille.SelectedItem != null)
                UpDateLieux((Villes)cBVille.SelectedItem);
        }
        private void UpDateLieux(Villes rech)
        {
            cBLieu.DataSource= md.Lieux.Where(l => l.Villes.Code_Ville == rech.Code_Ville).OrderBy(l => l.Lieu).ToList();
            cBLieu.Text = "";
            if ((cBLieu.SelectedItem == null) && (cBLieu.Items.Count > 0))
                cBLieu.SelectedIndex = 0;
        }
        private void GetPlace()
        {
            if (cBLieu.SelectedItem != null)
            {
                currentScene.Lieux = (Lieux)cBLieu.SelectedItem;
            }
            else
            {
                if (cBVille.SelectedItem != null)
                {
                    if (!String.IsNullOrEmpty(nouvLieu.Text))
                    {
                        Lieux lieu = new Lieux { Lieu = nouvLieu.Text, Villes = (Villes)cBVille.SelectedItem };
                        md.Lieux.Add(lieu);
                        currentScene.Lieux = lieu;
                        md.SaveChanges();
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(nouvVille.Text))
                    {
                        Villes ville = new Villes { Nom = nouvVille.Text, Pays = (Pays)cBPays.SelectedItem };
                        if (!String.IsNullOrEmpty(nouvLieu.Text))
                        {
                            Lieux lieu = new Lieux { Lieu = nouvLieu.Text, Villes = ville };
                            md.Lieux.Add(lieu);
                            currentScene.Lieux = lieu;
                        }
                    }
                }
            }
            foreach(SequenceScene seq in currentScene.SequenceScene)
            {
                seq.Shots.Lieux = currentScene.Lieux;
            }
            nouvLieu.Text = "";
            nouvVille.Text = "";
        }
        #endregion
        #region Personnes
        private void AddPerson_Click(object sender, EventArgs e)
        {
            Personne p = null;
            if (!String.IsNullOrEmpty(NouvFamille.Text))
            {
                if (!String.IsNullOrEmpty(Prenom.Text))
                {
                    p = new Personne { Nom = NouvFamille.Text, Prénom = Prenom.Text };
                    md.Personne.Add(p);
                }
            }
            else if ((Famille.SelectedItem != null) && (!String.IsNullOrEmpty(Prenom.Text)))
            {
                p = new Personne { Nom = Famille.Text, Prénom = Prenom.Text };
                md.Personne.Add(p);
            }
            else if (cBPersonnes.SelectedItem != null)
            {
                p = (Personne)cBPersonnes.SelectedItem;
            }
            if (p != null)
            {
                AddPersonToListView(p);
                currentScene.AddPersonToScene(p);
                md.SaveChanges();
                GetData();
                SceneInfoChanged?.Invoke(this, new SceneSelectedArgs { scene = currentScene });
            }
        }
        private void CBPersonnes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cBPersonnes.SelectedIndex > -1) && (currentScene != null))
                AddPerson.Enabled = true;
        }
        private void ListPersons_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip mnu = new ContextMenuStrip();
            ToolStripMenuItem contextMenu = new ToolStripMenuItem("Remove person");
            contextMenu.Click += new EventHandler(ContextMenu_Click);
            mnu.Items.Add(contextMenu);
            mnu.Show((Control)sender, new Point(0, 12), ToolStripDropDownDirection.BelowRight);
        }
        private void ContextMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem lv = (ToolStripMenuItem)sender;
            switch (lv.Text)
            {
                case "Remove person":
                    Personne p = (Personne)listPersons.SelectedItems[0].Tag;
                    listPersons.SelectedItems[0].Remove();
                    var pers = currentScene.PrésenceScène.Where(ke => ke.Personnes == p);
                    pers.ToList().ForEach(pp => currentScene.PrésenceScène.ToList().Remove(pp));
                    break;
                case "Remove keyword":
                    Keywords k = (Keywords)keywordList.SelectedItems[0].Tag;
                    keywordList.SelectedItems[0].Remove();
                    var keyScene = currentScene.KeywordScene.Where(ke => ke.Keywords == k);
                    keyScene.ToList().ForEach(kk => currentScene.KeywordScene.ToList().Remove(kk));
                    break;
            }
            md.SaveChanges();
        }
        private void NouvFamille_TextChanged(object sender, EventArgs e)
        {
            AddPerson.Enabled = true;
        }
        #endregion
        #region Keywords
        private void KeywordList_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip mnu = new ContextMenuStrip();
            ToolStripMenuItem contextMenu = new ToolStripMenuItem("Remove keyword");
            contextMenu.Click += new EventHandler(ContextMenu_Click);
            mnu.Items.Add(contextMenu);
            mnu.Show((Control)sender, new Point(0, 12), ToolStripDropDownDirection.BelowRight);
        }
        private void CBKeyword_SelectedIndexChanged(object sender, EventArgs e)
        {
            newKeyword.Text = "";
            if ((cBKeyword.SelectedIndex > -1) && (currentScene != null))
                AddKey.Enabled = true;
        }
        private void NewKeyword_TextChanged(object sender, EventArgs e)
        {
            AddKey.Enabled = newKeyword.Text != "";
        }
        private void AddKey_Click(object sender, EventArgs e)
        {
            if ((cBKeyword.SelectedIndex == -1) && (newKeyword.Text == ""))
                return;
            Keywords kw = null;
            if (!String.IsNullOrEmpty(newKeyword.Text))
            {
                kw = new Keywords { Keyword = newKeyword.Text };
                List<Keywords> lk = md.Keywords.ToList();
                if (!lk.Contains(kw))
                    md.Keywords.Add(kw);
            }
            else if (cBKeyword.SelectedIndex != -1)
                kw = (Keywords)cBKeyword.Items[cBKeyword.SelectedIndex];
            currentScene.AddKeywordToScene(kw);
            newKeyword.Text ="";
            md.SaveChanges();
            SceneInfoChanged?.Invoke(this, new SceneSelectedArgs { scene = currentScene });
        }
        #endregion

        #endregion
        private void ListPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPersons.SelectedIndices.Count > 0)
            {
                int i = listPersons.SelectedIndices[0];
                listPersons.Items.RemoveAt(i);
                currentScene.DeletePersonne((Personne)listPersons.SelectedItems[0].Tag);
                md.SaveChanges();
            }
        }
        private void KeywordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (keywordList.SelectedIndices.Count > 0)
            {
                int i = keywordList.SelectedIndices[0];
                keywordList.Items.RemoveAt(i);
                currentScene.DeleteKeyword((Keywords)keywordList.SelectedItems[0].Tag);
                md.SaveChanges();
            }
        }
    }
}
