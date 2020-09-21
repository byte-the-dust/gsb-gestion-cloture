using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;

namespace GsbCloture
{
    public partial class AccesDonnees
    {
        MySqlConnection connexionBase = new MySqlConnection("database=gsb_cloture; server=localhost; user id=root; pwd=");
        string requete;

        public void TraitementRequete()
        {
            MySqlCommand cmd = new MySqlCommand(requete);

            connexionBase.Open();
            cmd.Connection = connexionBase;
            cmd.ExecuteNonQuery();
            connexionBase.Close();
        }

        public void InsertIntoFicheFrais(string idVisiteur, string mois, int nbJustif, float mtValide, string dateModif, string idEtat)
        {            
            requete = "INSERT INTO ficheFrais (idVisiteur, mois, nbJustificatifs, montantValide, dateModif, idEtat) " +
                      "VALUES (" + idVisiteur + "," + mois + "," + nbJustif + "," + mtValide + "," + dateModif + "," + idEtat + ")";

            TraitementRequete();
        }

        public void UpdateFicheFrais(string idEtatAnt, string idEtatMaj, string mois, string dateModif)
        {
            requete = "UPDATE ficheFrais " +
                      "SET idEtat = " + idEtatMaj + ", dateModif = " + dateModif +
                     " WHERE mois < " + mois + " AND idEtat = " + idEtatAnt;

            TraitementRequete();
        }

        public void DeleteFicheFrais(string idVisiteur, string mois)
        {
            requete = "DELETE FROM ficheFrais " +
                     " WHERE idVisiteur = " + idVisiteur + " AND mois = " + mois;

            TraitementRequete();
        }

        public void SelectAl(string table)
        {
            requete = "SELECT * " +
                "FROM " + table;

            TraitementRequete();                
        }


    }
}
