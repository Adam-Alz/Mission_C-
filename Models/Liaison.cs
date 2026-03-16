using Connecte;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mission_C_.Models
{
    /// <summary>
    /// Représente une liaison entre deux ports.
    /// Contient les identifiants, la durée et des propriétés pour les noms de ports et du secteur.
    /// Fournit des accesseurs en lecture/écriture pour certains champs et une représentation textuelle.
    /// </summary>
    public class Liaison
    {
        /// <summary>
        /// Adresse du serveur de base de données (utilisée par le DAO si nécessaire).
        /// </summary>
        // attributs de connexion statiques
        private static string provider = "localhost";
        /// <summary>
        /// Nom de la base de données.
        /// </summary>
        private static string dataBase = "sicilyLines";
        /// <summary>
        /// Identifiant de connexion à la base.
        /// </summary>
        private static string uid = "root";
        /// <summary>
        /// Mot de passe de connexion à la base.
        /// </summary>
        private static string mdp = "";
        /// <summary>
        /// Instance de la connexion SQL (singleton).
        /// </summary>
        private static ConnexionSql maConnexionSql;
        /// <summary>
        /// Objet MySqlCommand réutilisable pour exécuter des requêtes.
        /// </summary>
        private static MySqlCommand Ocom;

        /// <summary>
        /// Code unique de la liaison.
        /// </summary>
        private int codeLiaison;
        /// <summary>
        /// Identifiant du port de départ.
        /// </summary>
        private int idPortDepart;
        /// <summary>
        /// Identifiant du port d'arrivée.
        /// </summary>
        private int idPortArrivee;
        /// <summary>
        /// Identifiant du secteur associé à la liaison.
        /// </summary>
        private int idSecteur;
        /// <summary>
        /// Durée de la liaison.
        /// </summary>
        private TimeSpan duree;

        /// <summary>
        /// Nom du port de départ (peut être renseigné après récupération depuis la base).
        /// </summary>
        private string nomPortDepart;
        /// <summary>
        /// Nom du port d'arrivée (peut être renseigné après récupération depuis la base).
        /// </summary>
        private string nomPortArrivee;
        /// <summary>
        /// Nom du secteur (peut être renseigné après récupération depuis la base).
        /// </summary>
        private string nomSecteur;

        /// <summary>
        /// Initialise une nouvelle instance de Liaison avec les valeurs fournies.
        /// </summary>
        /// <param name="unCodeLiaison">Code unique de la liaison.</param>
        /// <param name="unIdPortDepart">Identifiant du port de départ.</param>
        /// <param name="unIdPortArrivee">Identifiant du port d'arrivée.</param>
        /// <param name="unIdSecteur">Identifiant du secteur.</param>
        /// <param name="uneDuree">Durée de la liaison.</param>
        public Liaison(int unCodeLiaison, int unIdPortDepart, int unIdPortArrivee, int unIdSecteur, TimeSpan uneDuree)
        {
            this.codeLiaison = unCodeLiaison;
            this.idPortDepart = unIdPortDepart;
            this.idPortArrivee = unIdPortArrivee;
            this.idSecteur = unIdSecteur;
            this.duree = uneDuree;
        }

        /// <summary>
        /// Retourne le code de la liaison.
        /// </summary>
        /// <returns>Code de la liaison.</returns>
        public int getCodeLiaison()
        {
            return this.codeLiaison;
        }

        /// <summary>
        /// Propriété pour accéder/modifier l'identifiant du port de départ.
        /// </summary>
        public int IdPortDepart
        {
            get { return idPortDepart; }
            set { idPortDepart = value; }
        }

        /// <summary>
        /// Propriété pour accéder/modifier l'identifiant du port d'arrivée.
        /// </summary>
        public int IdPortArrivee
        {
            get { return idPortArrivee; }
            set { idPortArrivee = value; }
        }

        /// <summary>
        /// Propriété pour accéder/modifier l'identifiant du secteur.
        /// </summary>
        public int IdSecteur
        {
            get { return idSecteur; }
            set { idSecteur = value; }
        }

        /// <summary>
        /// Nom du port de départ. Propriété auto-implémentée pour simplifier l'affectation après lecture en base.
        /// </summary>
        public string NomPortDepart { get; set; }
        /// <summary>
        /// Nom du port d'arrivée. Propriété auto-implémentée pour simplifier l'affectation après lecture en base.
        /// </summary>
        public string NomPortArrivee { get; set; }
        /// <summary>
        /// Nom du secteur. Propriété auto-implémentée pour simplifier l'affectation après lecture en base.
        /// </summary>
        public string NomSecteur { get; set; }

        /// <summary>
        /// Représentation textuelle de la liaison.
        /// Retourne le code, les noms des ports, le nom du secteur et la durée.
        /// Utile pour l'affichage ou le débogage.
        /// </summary>
        /// <returns>Chaîne décrivant la liaison.</returns>
        public override string ToString()
        {
            //return (this.codeLiaison + ", " + NomPort + ", " + NomSecteur + ", " + this.duree + ", " + this.portdepart + ", " + this.portarrivee);
            return (this.codeLiaison + ", " + NomPortDepart + ", " + NomPortArrivee + ", " + NomSecteur + ", " + this.duree);
        }
    }
}