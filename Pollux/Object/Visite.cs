using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pollux.Object
{
    public class Visite
    {
        private DateTime m_dateHeure;
        private Client m_client;
        private Bien m_bien;

        #region Propriétés
        public DateTime DateHeure
        {
            get { return m_dateHeure; }
            set { m_dateHeure = value; }
        }
        public Client Client
        {
            get { return m_client; }
            set { m_client = value; }
        }
        public Bien Bien
        {
            get { return m_bien; }
            set { m_bien = value; }
        }
        #endregion


    }
}
