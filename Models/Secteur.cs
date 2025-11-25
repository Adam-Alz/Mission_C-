using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_C_.Models
{
    /// <summary>
    /// Représente un secteur avec son identifiant et son nom.
    /// Fournit des accesseurs en lecture et une représentation textuelle.
    /// </summary>
    internal class Secteur
    {
        /// <summary>
        /// Identifiant unique du secteur.
        /// </summary>
        private int idSecteur;

        /// <summary>
        /// Nom du secteur.
        /// </summary>
        private string nomSecteur;

        /// <summary>
        /// Initialise une nouvelle instance de Secteur avec l'identifiant et le nom fournis.
        /// </summary>
        /// <param name="unIdSecteur">Identifiant du secteur.</param>
        /// <param name="unNomSecteur">Nom du secteur.</param>
        public Secteur(int unIdSecteur, string unNomSecteur)
        {
            this.idSecteur = unIdSecteur;
            this.nomSecteur = unNomSecteur;
        }

        /// <summary>
        /// Retourne l'identifiant du secteur.
        /// </summary>
        /// <returns>Identifiant du secteur.</returns>
        public int getIdSecteur()
        {
            return this.idSecteur;
        }

        /// <summary>
        /// Retourne le nom du secteur.
        /// </summary>
        /// <returns>Nom du secteur.</returns>
        public string getNomSecteur()
        {
            return this.nomSecteur;
        }

        /// <summary>
        /// Retourne une représentation textuelle du secteur sous la forme "id, nom".
        /// Utile pour l'affichage rapide ou le débogage.
        /// </summary>
        /// <returns>Chaîne contenant l'id et le nom du secteur.</returns>
        public override string ToString()
        {
            return (this.idSecteur + ", " + this.nomSecteur);
        }
    }
}