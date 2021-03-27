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
    public partial class DataSelector : UserControl
    {
        public event LieuxSelectedHandler LieuxSelected;
        public event PersonneSelectedHandler PersonneSelected;
        public event DateSelectedHandler DateSelected;
        public event KeywordsSelectedHandler KeywordsSelected;
        Modèle md;
        public DataSelector()
        {
            InitializeComponent();
        }
        #region
        public void Init(Modèle m)
        {
            md = m;
            UpdateCountries();
            UpdateKeywords();
            UpdatePersonnes();
        }
        #endregion
        #region Private members
        List<string> surnames;
        private void UpdateCountries()
        {
            md.Lieux.Where(l => l.Scenes.Count > 0)
                .Select(l => l.Villes.Pays)
                .Distinct().OrderBy(p => p.Nom_Pays)
            .ToList().ForEach(l => cBPays.Items.Add(l));
        }
        private void UpdatePersonnes()
        {
            Personnes.Items.Clear();
            md.Personne
                .Where(p => p.PrésenceScène.Count > 0)
                .Distinct().OrderBy(p=>p.Nom)
                .ThenBy(p=>p.Prénom).ToList()
                .ForEach(p=>Personnes.Items.Add(p));
            surnames = md.Personne.Select(p => new { p.Nom }.Nom).Distinct().ToList();
        }
        private void UpdateKeywords()
        {
            keywordList.Items.Clear();
            md.Keywords.Where(k => k.KeywordScene.Count > 0)
                .OrderBy(k => k.Keyword).Distinct().ToList()
                .ForEach(k=>keywordList.Items.Add(k));
        }
        private void cBPays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBPays.SelectedItem == null) return;
            Pays p = (Pays)cBPays.SelectedItem;
            md.Lieux.Where(l => l.Scenes.Count > 0 & l.Villes.Pays.Code_Pays == p.Code_Pays)
            .OrderBy(l => l.Villes.Pays.Nom_Pays)
            .ThenBy(l => l.Villes.Nom)
            .ThenBy(l => l.Lieu)
            .ToList()
            .ForEach(l => paysLieux.Items.Add(l));
        }
        private void SelectLieu_Click(object sender, EventArgs e)
        {
            LieuxSelected?.Invoke(this, new LieuxSelectedArgs {Lieu = (Lieux)paysLieux.SelectedItem });
        }
        private void SelectPersonne_Click(object sender, EventArgs e)
        {
            PersonneSelected?.Invoke(this, new PersonneSelectedArgs { Personne = (Personne)Personnes.SelectedItem });
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DateSelected?.Invoke(this, new DateSelectedArgs { BeginDate = beginPicker.Value, EndDate = endPicker.Value });
        }

        private void searchKeywords_Click(object sender, EventArgs e)
        {
            KeywordsSelected?.Invoke(this, new KeywordSelectedArgs { KwChoosen = (Keywords)keywordList.SelectedItem });
        }

        private void beginPicker_ValueChanged(object sender, EventArgs e)
        {
            endPicker.Value = beginPicker.Value;
        }
    }
}
