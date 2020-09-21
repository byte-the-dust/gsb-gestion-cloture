using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsbCloture
{
    public class GestionDate
    {
        /// <summary>
        /// Mois précédant la date passée en paramètre
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Mois au format "mm"</returns>
        public string GetMoisPrecedent(DateTime date)
        {
            int moisPrecedant = date.AddMonths(-1).Month;            
            return moisPrecedant.ToString("D2");
        }     
        
        /// <summary>
        /// Mois précédant la date du jour
        /// </summary>
        /// <returns>Mois au format "mm"</returns>
        public string GetMoisPrecedent()
        {
            return GetMoisPrecedent(DateTime.Now);
        }

        /// <summary>
        /// Mois suivant la date passée en paramètre
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Mois au format "mm"</returns>
        public string GetMoisSuivant(DateTime date)
        {
            int moisSuivant = date.AddMonths(1).Month;
            return moisSuivant.ToString("D2");
        }

        /// <summary>
        /// Mois suivant la date du jour
        /// </summary>
        /// <returns>Mois au format "mm"</returns>
        public string GetMoisSuivant()
        {
            return GetMoisSuivant(DateTime.Now);
        }

        /// <summary>
        /// Indique si le paramètre date est situé entre jourDebut et jourFin
        /// </summary>
        /// <param name="jourDebut">Compris dans l'intervalle [1;31]</param>
        /// <param name="jourFin">Compris dans l'intervalle [1;31]</param>
        /// <param name="date"></param>
        /// <returns>Vrai si la date passée en paramètre est comprise dans l'intervalle</returns>
        public bool Entre(int jourDebut, int jourFin, DateTime date)
        {
                bool inclus = false;
                int jourEntre = date.Day;
                int nbJoursMois = DateTime.DaysInMonth(date.Year, date.Month);

                // Correction si jourDebut est inférieur à 1
                if (jourDebut < 1)
                {
                    jourDebut = 1;
                }

                // Correction si jourFin est supérieur au nombre de jours du mois
                if (jourFin > nbJoursMois)
                {                    
                    jourFin = nbJoursMois;
                }

                // Correction si jourFin inférieur à jourDebut
                if (jourFin < jourDebut)
                {
                    jourFin = jourDebut;
                }
                
                if ((jourEntre >= jourDebut) && (jourEntre <= jourFin))
                {
                    inclus = true;
                }

                return inclus;
        }

        /// <summary>
        /// Indique si la date du jour se situe entre deux jours passés en paramètre
        /// </summary>
        /// <param name="jourDebut">Compris dans l'intervalle [1;31]</param>
        /// <param name="jourFin">Compris dans l'intervalle [1;31]</param>
        /// <returns>Vrai si la date du jour est comprise dans l'intervale</returns>
        public bool Entre(int jourDebut, int jourFin)
        {
            return Entre(jourDebut, jourFin, DateTime.Now);
        }
    }
}
