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

        static public bool AjouterBien(Bien bien)
        {
            bool ajout = false;
            // TODO ajouter le bien fournit en paramètre dans la base


            return ajout;
        }

        static public List<Bien> GetListeBiens(Bien bien)
        {
            List<Bien> listeBiens = null;
            // TODO retourne la liste des biens correspondant au bien fournit en paramètre
            // voir si en paramètres c'est mieux ça ou chaque attribut


            return listeBiens;
        }
        
    }
}
