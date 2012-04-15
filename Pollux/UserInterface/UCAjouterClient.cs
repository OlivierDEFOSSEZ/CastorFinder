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
            comboBoxAgents.SelectedIndex = 0;
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

        /*
        private void buttonCreer_Click(object sender, EventArgs e)
        {
            if (textBoxNom.Text != "" && textBoxAdresse.Text != "" && textBoxTelephone.Text != "" && comboBoxVilles.SelectedItem != null)
            {
                Client c = new Client(-1, textBoxNom.Text, textBoxAdresse.Text, textBoxTelephone.Text, ((Ville)comboBoxVilles.SelectedItem).Index);
                if (radioButtonBien.Checked)
                {
                    if (!SqlDataProvider.ClientExiste(c))  // peut etre à vérifier en premier et controler l'état du radioBouton aprés
                    {
                        MessageBox.Show("OK", "ajout client sans agent possible");
                        /*
                        UserControl ajouterBien = new UCAjouterBien(c);
                        ajouterBien.Parent = this.Parent;
                        ajouterBien.Dock = DockStyle.Fill;
                        ajouterBien.Show();
                        this.Hide();
                         
                        //MainWindowName is the name of your main MDI parent form
                        UserControl ajouterBien = new UCAjouterBien(c);
                        ajouterBien.Parent = Application.OpenForms["FenetrePrincipale"];
                        ajouterBien.Dock = DockStyle.Fill;
                        ajouterBien.Show();
                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("KO", "ajout client sans agent impossible");
                    }
                }
                else
                {
                    if (comboBoxAgents != null)
                    {
                        c.Agent = (Agent)comboBoxAgents.SelectedItem;
                        // ? pourquoi faire compliqué , la comboBox contient déjà les agents(index + prénom)
                        //c.Agent = SqlDataProvider.trouverAgent(((Agent)comboBoxAgents.SelectedItem).Index);
                        // ? pourquoi revérifier si le client existe: est-ce qu'un client (meme nom, adresse,etc)
                        // peut avoir 2 agents assignés différents : non une fois en base le client contacte tjr le meme agent
                        if (!SqlDataProvider.ClientExiste(c))
                        {
                            MessageBox.Show("OK", "ajout client avec agent possible");
                            
                            
                            UserControl ajouterSouhait = new UCAjouterSouhait(c);
                            //ajouterSouhait.Parent = this.Parent;
                            //ajouterSouhait.Dock = DockStyle.Fill;
                            FenetrePrincipale parent = (FenetrePrincipale)this.Parent;
                            //Now you can access objects on the MDI Parent form from MDI Children
                            parent.MdiChild = null;
                            parent.MdiChild = ajouterSouhait;
                            ajouterSouhait.Dock = DockStyle.Fill;
                            ajouterSouhait.Show();
                        }
                        else
                        {
                            MessageBox.Show("KO", "ajout client avec agent impossible");
                        }
                    }
                }
            }
        }
        */


        // TEST pas au point pour la création
        // A FINIR
        private void buttonCreer_Click(object sender, EventArgs e)
        {
            bool ajoutBien;
            if (textBoxNom.Text != "" && textBoxAdresse.Text != "" && textBoxTelephone.Text != "" && comboBoxVilles.SelectedItem != null)
            {
                Client client = SqlDataProvider.ClientExiste(textBoxNom.Text, (Ville)comboBoxVilles.SelectedItem);
                    //
                // si client existe, on bascule directement sur UCAjouterBien avec ce client
                if (client != null)
                {
                    // limite rajouter un truc pour choisir entre continuer ou modifier les infos client saisies ?
                    MessageBox.Show("Attention, ce client existe déjà.", "Alerte", MessageBoxButtons.YesNoCancel);
                }
                else
                    client = new Client(-1, textBoxNom.Text, textBoxAdresse.Text, textBoxTelephone.Text, ((Ville)comboBoxVilles.SelectedItem).Index);

                if (radioButtonBien.Checked)
                {
                    ajoutBien = true;  // ça sera un bien
                    /*
                  UserControl ajouterBien = new UCAjouterBien(c);
                  ajouterBien.Parent = this.Parent;
                  ajouterBien.Dock = DockStyle.Fill;
                  ajouterBien.Show();
                  this.Hide();
                   */   
                    //MainWindowName is the name of your main MDI parent form
                    UserControl ajouterBien = new UCAjouterBien(client);
                    ajouterBien.Parent = Application.OpenForms["FenetrePrincipale"];
                    ajouterBien.Dock = DockStyle.Fill;
                    ajouterBien.Show();
                    this.Hide();
                }
                else
                {
                    ajoutBien = false;  // ça sera un souhait
                    // le controle si la comboBox est à null pas vraiment utile si on fixe la 1ere ligne par défaut
                    // vérification si ce client a déjà un agent assigné dans le cas où il existe déjà
                    client.Agent = (Agent)comboBoxAgents.SelectedItem;
                    // ? pourquoi faire compliqué , la comboBox contient déjà les agents(index + prénom)
                    //c.Agent = SqlDataProvider.trouverAgent(((Agent)comboBoxAgents.SelectedItem).Index);
                    // ? pourquoi revérifier si le client existe: est-ce qu'un client (meme nom, adresse,etc)
                    // peut avoir 2 agents assignés différents : non une fois en base le client contacte tjr le meme agent
                    UserControl ajouterSouhait = new UCAjouterSouhait(client);
                    //ajouterSouhait.Parent = this.Parent;
                    //ajouterSouhait.Dock = DockStyle.Fill;
                    FenetrePrincipale parent = (FenetrePrincipale)this.Parent;
                    //Now you can access objects on the MDI Parent form from MDI Children
                    parent.MdiChild = null;
                    parent.MdiChild = ajouterSouhait;
                    ajouterSouhait.Dock = DockStyle.Fill;
                    ajouterSouhait.Show();
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

        private void radioButtonSouhait_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSouhait.Checked)
            {
                comboBoxAgents.Enabled = true;
            }
            else
            {
                comboBoxAgents.Enabled = false;
            }
        }

       

    }
}
