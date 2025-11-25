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
    /// DAO pour gérer les opérations sur les liaisons en base de données.
    /// Fournit des méthodes statiques pour récupérer, insérer, mettre à jour et supprimer des liaisons.
    /// </summary>
    internal class LiaisonDAO
    {
        /// <summary>
        /// Nom ou adresse du serveur de base de données (provider).
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
        /// Instance de la classe de connexion personnalisée (singleton).
        /// Utilisée pour ouvrir/fermer la connexion et exécuter des commandes.
        /// </summary>
        private static ConnexionSql maConnexionSql;

        /// <summary>
        /// Commande MySQL utilisée pour exécuter des requêtes.
        /// </summary>
        private static MySqlCommand Ocom;

        /// <summary>
        /// Récupère la liste des liaisons pour un secteur donné.
        /// Ouvre la connexion, exécute une requête JOIN pour obtenir les informations de ports et secteur,
        /// construit des objets Liaison et les retourne dans une liste.
        /// </summary>
        /// <param name="s">Secteur dont on veut récupérer les liaisons.</param>
        /// <returns>Liste de Liaison correspondant au secteur fourni.</returns>
        public static List<Liaison> getLiaisons(Secteur s)
        {
            List<Liaison> listeLiaisons = new List<Liaison>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec(@"
                    SELECT 
                        l.CODELIAISON, 
                        l.IDPORTDEPART, 
                        l.IDPORTARRIVEE,
                        l.IDSECTEUR, 
                        l.DUREE, 
                        pd.NOMPORT,
                        pa.NOMPORT,
                        NOMSECTEUR
                    FROM 
                        LIAISON l
                    JOIN 
                        PORT pd ON l.IDPORTDEPART = pd.IDPORT
                        
                    JOIN
                        PORT pa ON l.IDPORTARRIVEE = pa.IDPORT
                    JOIN 
                        SECTEUR s ON l.IDSECTEUR = s.IDSECTEUR
                    WHERE 
                        l.IDSECTEUR = " + s.getIdSecteur());
                //Ocom = maConnexionSql.reqExec("select * from liaison where IDSECTEUR =  " + s.getIdSecteur());

                MySqlDataReader reader = Ocom.ExecuteReader();

                Liaison liaison;

                while (reader.Read())
                {
                    int codeL = (int)reader.GetValue(0);
                    int idPortDepart = (int)reader.GetValue(1);
                    int idPortArrivee = (int)reader.GetValue(2);
                    int idSecteur = (int)reader.GetValue(3);
                    TimeSpan duree = (TimeSpan)reader.GetValue(4);
                    string nomPortDepart = (string)reader.GetValue(5);
                    string nomPortArrivee = (string)reader.GetValue(6);
                    string nomSecteur = (string)reader.GetValue(7);



                    liaison = new Liaison(codeL, idPortDepart, idPortArrivee, idSecteur, duree);
                    liaison.NomPortDepart = nomPortDepart;
                    liaison.NomPortArrivee = nomPortArrivee;
                    liaison.NomSecteur = nomSecteur;



                    listeLiaisons.Add(liaison);

                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (listeLiaisons);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        /// <summary>
        /// Met à jour la durée d'une liaison existante.
        /// Convertit le TimeSpan en chaîne au format hh:mm:ss avant d'exécuter la requête UPDATE.
        /// </summary>
        /// <param name="l">Objet Liaison à mettre à jour (utilise son CODELIAISON).</param>
        /// <param name="uneDuree">Nouvelle durée à appliquer.</param>
        public static void updateLiaison(Liaison l, TimeSpan uneDuree)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                string dureeStr = uneDuree.ToString(@"hh\:mm\:ss");

                Ocom = maConnexionSql.reqExec("update liaison set DUREE = '" + dureeStr + "' where CODELIAISON = '" + l.getCodeLiaison() + "'");

                int i = Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();
            }
            catch (Exception emp)
            {
                throw (emp);
            }
        }

        /// <summary>
        /// Supprime une liaison de la base de données en se basant sur son CODELIAISON.
        /// Exécute une requête DELETE.
        /// </summary>
        /// <param name="l">Objet Liaison à supprimer (utilise son CODELIAISON).</param>
        public static void deleteLiaison(Liaison l)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("delete from liaison where CODELIAISON = '" + l.getCodeLiaison() + "'");

                int i = Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();
            }
            catch (Exception emp)
            {
                throw (emp);
            }
        }

        /// <summary>
        /// Insère une nouvelle liaison en base de données.
        /// Convertit la durée en chaîne au format hh:mm:ss et exécute une requête INSERT.
        /// </summary>
        /// <param name="unCodeLiaison">Code unique de la liaison.</param>
        /// <param name="unIdPortDepart">Identifiant du port de départ.</param>
        /// <param name="unIdPortArrivee">Identifiant du port d'arrivée.</param>
        /// <param name="unIdSecteur">Identifiant du secteur associé.</param>
        /// <param name="uneDuree">Durée de la liaison.</param>
        public static void insertLiaison(int unCodeLiaison, int unIdPortDepart, int unIdPortArrivee, int unIdSecteur, TimeSpan uneDuree)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                string dureeStr = uneDuree.ToString(@"hh\:mm\:ss");

                Ocom = maConnexionSql.reqExec("insert into liaison values (" + unCodeLiaison + ", " + unIdPortDepart + ", " + unIdPortArrivee + ", " + unIdSecteur + ", '" + dureeStr + "')");

                int i = Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}