﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pollux.DataBase;

namespace Pollux.Object
{
    public class Client
    {
        private int m_index;
        private string m_nom;
        private string m_adresse;
        private string m_telephone;
        private Agent m_agent = null;
        private Ville m_ville;

        #region Propriétés
        public int Index
        {
            get { return m_index; }
            set { m_index = value; }
        }
        public string Nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }
        public string Adresse
        {
            get { return m_adresse; }
            set { m_adresse = value; }
        }
        public string Telephone
        {
            get { return m_telephone; }
            set { m_telephone = value; }
        }        
        public Agent Agent
        {
            get { return m_agent; }
            set { m_agent = value; }
        }
        public Ville Ville
        {
            get { return m_ville; }
            set { m_ville = value; }
        }
        #endregion

        public Client(int index, string nom, string adresse, string telephone, int index_agent, int index_ville)
        {
            m_index = index;
            m_nom = nom;
            m_adresse = adresse;
            m_telephone = telephone;
            m_agent = SqlDataProvider.trouverAgent(index_agent);
            m_ville = SqlDataProvider.trouverVille(index_ville);
        }
        public Client(int index, string nom, string adresse, string telephone, int index_ville)
        {
            m_index = index;
            m_nom = nom;
            m_adresse = adresse;
            m_telephone = telephone;
            m_ville = SqlDataProvider.trouverVille(index_ville);
        }

        public Client(int index, string nom, string adresse, string telephone, Agent agent, Ville ville)
        {
            m_index = index;
            m_nom = nom;
            m_adresse = adresse;
            m_telephone = telephone;
            m_agent = agent;
            m_ville = ville;
        }

        public override string ToString()
        {
            return m_nom ;
        }
    }
}
