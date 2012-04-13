using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Pollux.Object;
using Pollux.DataBase;

namespace Pollux.UserInterface
{
    public partial class UCAjouterClient : UserControl
    {
        public UCAjouterClient()
        {
            InitializeComponent();
            loadAgents();
            loadVilles();
        }

        #region Chargement des comboBox
        private void loadAgents()
        {
            comboBoxAgents.Items.Clear();
            List<Agent> listeAgents = SqlDataProvider.GetListeAgents();
            foreach (Agent agent in listeAgents)
            {
                comboBoxAgents.Items.Add(agent);
            }
        }
        private void loadVilles()
        {
            comboBoxVilles.Items.Clear();
            List<Ville> listeVilles = SqlDataProvider.GetListeVilles();
            foreach (Ville ville in listeVilles)
            {
                comboBoxVilles.Items.Add(ville);
            }
        }
        #endregion

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonCreer_Click(object sender, EventArgs e)
        {
            if (textBoxNom.Text != "" && textBoxAdresse.Text != "" && textBoxTelephone.Text != "" && comboBoxVilles.SelectedItem != null)
            {
                Client c = new Client(textBoxNom.Text, textBoxAdresse.Text, textBoxTelephone.Text, ((Agent)comboBoxAgents.SelectedItem).Index, ((Ville)comboBoxVilles.SelectedItem).Index);
                if (radioButtonBien.Checked)
                {
                    MessageBox.Show("Attention", "erreur BIEN OK BdD");
                    //UCAjouterBien(c)
                    this.Hide();
                }
                else
                {
                    if (comboBoxAgents != null)
                    {
                        if (SqlDataProvider.ajouterClient(c))
                        {
                            MessageBox.Show("OK", "ajout client OK BdD");
                        }
                        else
                        {
                            MessageBox.Show("KO", "ajout client KO BdD");
                        }
                        //UCAjouterSouhait(c)
                        this.Hide();
                    }
                }
            }
        }

        private void buttonAjoutVille_Click(object sender, EventArgs e)
        {
            Form Ville = new FormVilles();
            if (Ville.ShowDialog() == DialogResult.OK)
            {
                loadVilles();
            }
        }
    }
}
