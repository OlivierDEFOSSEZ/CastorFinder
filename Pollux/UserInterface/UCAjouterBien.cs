﻿using System;
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
            comboBoxProprietaire.SelectedText = c.ToString(); 
            comboBoxProprietaire.Enabled = false;
        }
        #region Chargement des comboBox
        private void loadClients()
        {
            comboBoxProprietaire.Items.Clear();
            List<Client> listeClient = SqlDataProvider.GetListeClients();
            foreach (Client proprietaire in listeClient)
            {
                comboBoxProprietaire.Items.Add(proprietaire);
            }
        }
        private void loadVilles()
        {
            comboBoxVille.Items.Clear();
            List<Ville> listeVilles = SqlDataProvider.GetListeVilles();
            foreach (Ville ville in listeVilles)
            {
                comboBoxVille.Items.Add(ville);
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



        // A FINIR
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            // Récupération des infos
            int prix = int.Parse(textBoxAjoutBienPrix.Text);
            // TODO un controle pour la date de mise en vente
            int surfHab = int.Parse(textBoxAjoutBienSurfHab.Text);
            int surfJard = int.Parse(textBoxAjoutBienJardin.Text);
            Client proprietaire = (Client)comboBoxProprietaire.SelectedItem;
            Ville ville = (Ville)comboBoxVille.SelectedItem;
            Bien bien = new Bien(prix, new DateTime(2000,5,12), surfHab, surfJard, ville, proprietaire);
            // Ajout en base du bien
            if (SqlDataProvider.AjouterBien(bien))
            {
                // l'ajout du bien réussit on peut ajouter le proprio mais si l'ajout du proprio échoue, faudrait enlever le bien ?? rofl
                MessageBox.Show("Ajout du bien effectué", "Opération réussit");
                if (SqlDataProvider.ajouterClient(proprietaire))
                    MessageBox.Show("Ajout du client effectué", "Opération réussit");
            }
            else
                MessageBox.Show("Ajout du bien non effectué", "Echec");
            this.Hide();
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
