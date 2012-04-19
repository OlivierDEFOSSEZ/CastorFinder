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

        static public bool AjouterSouhait(Souhait souhait)
        {
            bool ajout = false;
            // TODO ajouter le souhait fournit en paramètre dans la base


            return ajout;
        }

        static public List<Souhait> GetListeSouhaits(Souhait souhait)
        {
            List<Souhait> listeSouhaits = null;
            // TODO retourne la liste des biens correspondant au bien fournit en paramètre
            // voir si en paramètres c'est mieux ça ou chaque attribut


            return listeSouhaits;
        }

        static public bool ajouterSouhaitEtClient(Client c, Souhait s)
        {
            //pour l'instant, il n'y a que l'ajout de client
            bool ajout;
            // si pas de connexion
            if (!DBConnect())
                ajout = false;
            // si connexion
            else
            {
                string requete;
                if (c.Agent == null)
                {
                    requete = string.Format("INSERT INTO CLIENTS (NOM_C, ADRESSE_C, NUM_V, TEL_C) VALUES (N'{0}',N'{1}',N'{2}',N'{3}')", c.Nom, c.Adresse, c.Ville.Index, c.Telephone);
                }
                else
                {
                    requete = string.Format("INSERT INTO CLIENTS (NOM_C, ADRESSE_C, NUM_V, TEL_C, NUM_A) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", c.Nom, c.Adresse, c.Ville.Index, c.Telephone, c.Agent.Index);
                }
                OleDbCommand command = new OleDbCommand(requete, connect);
                int rowCount = command.ExecuteNonQuery();
                if (rowCount == 1)
                {
                    ajout = true;  // ajout effectué
                }
                else
                    ajout = false; // ajout non effectué
                // déconnexion
                connect.Close();
            }
            return ajout;
        }
        
    }
}
