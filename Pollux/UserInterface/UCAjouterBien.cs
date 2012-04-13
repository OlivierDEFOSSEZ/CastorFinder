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
    public partial class UCAjouterBien : UserControl, InterfaceFenetre
    {

        public UCAjouterBien()
        {
            InitializeComponent();
            loadClients();
            loadVilles();
        }
        public UCAjouterBien(Client c)
        {
            InitializeComponent();
            loadClients();
            loadVilles();
            comboBoxProprietaire.SelectedText = c.Nom;
            comboBoxProprietaire.Enabled = false;
        }
        #region Chargement des comboBox
        private void loadClients()
        {
            comboBoxProprietaire.Items.Clear();
            List<string> listeNomClients = SqlDataProvider.GetListeNomClients();
            foreach (string nom in listeNomClients) 
            {
                comboBoxProprietaire.Items.Add(nom);
            }
        }
        private void loadVilles()
        {
            comboBoxVille.Items.Clear();
            List<Ville> listeVilles = SqlDataProvider.GetListeVilles();
            foreach (Ville ville in listeVilles)
            {
                comboBoxVille.Items.Add(string.Format("{0} ({1})", ville.Nom, ville.CodePostal));
            }
        }
        #endregion

        #region Trackbars
        private void trackBarAjoutBienPrix_Scroll(object sender, EventArgs e)
        {
            textBoxAjoutBienPrix.Text = trackBarAjoutBienPrix.Value.ToString();
        }

        private void trackBarAjoutBienSurfHab_Scroll(object sender, EventArgs e)
        {
            textBoxAjoutBienSurfHab.Text = trackBarAjoutBienSurfHab.Value.ToString();
        }

        private void trackBarAjoutBienJardin_Scroll(object sender, EventArgs e)
        {
            textBoxAjoutBienJardin.Text = trackBarAjoutBienJardin.Value.ToString();
        } 
        #endregion

        private void buttonAjoutVille_Click(object sender, EventArgs e)
        {
            Form Ville = new FormVilles();
            if (Ville.ShowDialog() == DialogResult.OK)
            {
                loadVilles();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
