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

        static public List<Agent> GetListeAgents()
        {
            List<Agent> listeAgents = new List<Agent>();
            if (DBConnect())
            {
                string requete = "SELECT NUM_A, PRÉNOM_A FROM AGENTS ORDER BY PRÉNOM_A";
                OleDbCommand command = new OleDbCommand(requete, connect);
                OleDbDataReader reader = command.ExecuteReader();
                // ajout des prénoms des agents dans la liste
                while (reader.Read())
                {
                    listeAgents.Add(new Agent(reader.GetInt16(0), reader.GetString(1)));
                }
                // déconnexion
                reader.Close();
                connect.Close();
            }
            return listeAgents;
        }

        // Retrouver un agent à partir de son index
        static public Agent trouverAgent(int index)
        {
            if (DBConnect())
            {
                string requete = "SELECT PRÉNOM_A FROM AGENTS WHERE NUM_A = " + index;
                OleDbCommand command = new OleDbCommand(requete, connect);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string prenom = reader.GetString(0);
                    Agent agent = new Agent(index, prenom);
                    return agent;
                }
                reader.Close();
                connect.Close();
            }
            return null;
        }

        static public Agent GetAgent(Client client)
        {
            Agent agent = null;
            // TODO rechercher l'agent du client fournit en paramètre
            // hmm en fait pas besoin si l'agent fait parti du client ...


            return agent;
        }

        
    }
}
