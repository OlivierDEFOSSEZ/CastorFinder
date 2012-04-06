using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using Pollux.Object;

namespace Pollux.DataBase
{
    static public partial class SqlDataProvider  
    {

        static public List<string> GetListePrenomAgents()
        {
            List<string> listePrenomAgents = new List<string>();
            if (DBConnect())
            {
                string requete = "SELECT PRÉNOM_A FROM AGENTS ORDER BY PRÉNOM_A";
                OleDbCommand command = new OleDbCommand(requete, connect);
                OleDbDataReader reader = command.ExecuteReader();
                // ajout des prénoms des agents dans la liste
                while (reader.Read())
                {
                    listePrenomAgents.Add(reader.GetString(0));
                }
                // déconnexion
                reader.Close();
                connect.Close();
            }
            return listePrenomAgents;
        }


        static public Agent GetAgent(Client client)
        {
            Agent agent = null;
            // TODO rechercher l'agent du client fournit en paramètre



            return agent;
        }
    }
}
