using Connecte;
using Mission_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_C_.DAL
{
    /// <summary>
    /// DAO pour gérer l'accès aux données de la table Port.
    /// Fournit une méthode statique pour récupérer la liste des ports depuis la base de données.
    /// </summary>
    public class PortDAO
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
        /// Récupère tous les ports présents dans la table port.
        /// Ouvre la connexion, exécute une requête SELECT, lit les résultats et construit une liste d'objets Port.
        /// </summary>
        /// <returns>Liste de Port récupérée depuis la base de données.</returns>
        public static List<Port> getPorts()
        {
            List<Port> listePort = new List<Port>();

            try
            {
                // Obtention de l'instance de connexion (singleton) et ouverture de la connexion
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                // Préparation et exécution de la requête pour récupérer tous les ports
                Ocom = maConnexionSql.reqExec("select * from port");

                MySqlDataReader reader = Ocom.ExecuteReader();

                Port port;

                // Parcours du DataReader et construction des objets Port
                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);

                    port = new Port(id, nom);

                    listePort.Add(port);
                }

                // Fermeture du reader puis de la connexion
                reader.Close();

                maConnexionSql.closeConnection();

                return listePort;
            }
            catch (Exception e)
            {
                // Remonte l'exception vers l'appelant
                throw e;
            }
        }
    }
}