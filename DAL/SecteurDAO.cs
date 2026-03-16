using Connecte;
using Mission_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mission_C_.DAL
{
    /// <summary>
    ///DAO pour gérer l'accès aux données de la table Secteur.
    /// Fournit une méthode statique pour récupérer la liste des secteurs depuis la base de données.
    /// </summary>
    public class SecteurDAO
    {
        /// <summary>
        /// Adresse du serveur de base de données (provider).
        /// </summary>
        // attributs de connexion statiques
        private static string provider = "localhost";

        /// <summary>
        /// Nom de la base de données utilisée.
        /// </summary>
        private static string dataBase = "sicilyLines";

        /// <summary>
        /// Identifiant de connexion à la base de données.
        /// </summary>
        private static string uid = "root";

        /// <summary>
        /// Mot de passe de connexion à la base de données.
        /// </summary>
        private static string mdp = "";

        /// <summary>
        /// Instance singleton de la classe de connexion personnalisée.
        /// Utilisée pour ouvrir/fermer la connexion et exécuter des commandes SQL.
        /// </summary>
        private static ConnexionSql maConnexionSql;

        /// <summary>
        /// Objet MySqlCommand utilisé pour exécuter les requêtes.
        /// </summary>
        private static MySqlCommand Ocom;

        /// <summary>
        /// Récupère tous les secteurs présents dans la table secteur.
        /// Ouvre la connexion, exécute une requête SELECT, lit les résultats et construit une liste d'objets Secteur.
        /// </summary>
        /// <returns>Liste de Secteur récupérée depuis la base de données.</returns>
        public static List<Secteur> getSecteurs()
        {
            List<Secteur> ls = new List<Secteur>();

            try
            {
                // Obtention de l'instance de connexion (singleton) et ouverture de la connexion
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                // Préparation et exécution de la requête pour récupérer tous les secteurs
                Ocom = maConnexionSql.reqExec("select * from secteur");

                MySqlDataReader reader = Ocom.ExecuteReader();

                Secteur s;

                // Parcours du DataReader et construction des objets Secteur
                while (reader.Read())
                {
                    int idSecteur = (int)reader.GetValue(0);
                    string nomSecteur = (string)reader.GetValue(1);

                    s = new Secteur(idSecteur, nomSecteur);

                    ls.Add(s);
                }

                // Fermeture du reader puis de la connexion
                reader.Close();

                maConnexionSql.closeConnection();

                return (ls);
            }
            catch (Exception e)
            {
                // Remonte l'exception vers l'appelant
                throw (e);
            }
        }
    }
}