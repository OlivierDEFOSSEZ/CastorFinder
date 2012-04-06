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
        
        
    }
}
