using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Pollux.DataBase;
using Pollux.Object;

namespace Pollux.UserInterface
{
    public partial class UCAjouterSouhait : UserControl
    {
        public UCAjouterSouhait()
        {
            InitializeComponent();
            loadClients();
            loadVilles();
        }
        public UCAjouterSouhait(Client c)
        {
            InitializeComponent();
            loadClients();
            loadVilles();
            comboBoxAcheteur.SelectedText = c.Nom;
            comboBoxAcheteur.Enabled = false;
        }
        #region Chargement des comboBox
        private void loadClients()
        {
            comboBoxAcheteur.Items.Clear();
            List<string> listeClients = SqlDataProvider.GetListeNomClients();
            foreach (string prenom in listeClients)
            {
                comboBoxAcheteur.Items.Add(prenom);
            }
        }
        private void loadVilles()
        {
            listBoxVilles.Items.Clear();
            List<Ville> listeVilles = SqlDataProvider.GetListeVilles();
            foreach (Ville ville in listeVilles)
            {
                listBoxVilles.Items.Add(string.Format("{0} ({1})", ville.Nom, ville.CodePostal));
            }
        }
        #endregion

        #region TrackBars
        private void trackBarAjoutSouhaitsBudget_Scroll(object sender, EventArgs e)
        {
            textBoxAjoutSouhaitsBudget.Text = trackBarAjoutSouhaitsBudget.Value.ToString();
        }

        private void trackBarAjoutSouhaitSurfHab_Scroll(object sender, EventArgs e)
        {
            textBoxAjoutSouhaitSurfHab.Text = trackBarAjoutSouhaitSurfHab.Value.ToString();
        }

        private void trackBarAjoutSouhaitJardin_Scroll(object sender, EventArgs e)
        {
            textBoxAjoutSouhaitJardin.Text = trackBarAjoutSouhaitJardin.Value.ToString();
        }
        #endregion

        private void buttonAddVilles_Click(object sender, EventArgs e)
        {
            Form Ville = new FormVilles();
            if (Ville.ShowDialog() == DialogResult.OK)
            {
                loadVilles();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
