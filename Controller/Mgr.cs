using Mission_C_.DAL;
using Mission_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_C_.Controller
{
    /// <summary>
    /// Gestionnaire central qui expose des méthodes simples pour accéder aux DAO.
    /// Sert de couche intermédiaire entre l'interface et la couche DAL.
    /// </summary>
    public class Mgr
    {
        // Instances DAO (non statiques) utilisées par le gestionnaire
        SecteurDAO secDAO = new SecteurDAO();
        LiaisonDAO liaiDAO = new LiaisonDAO();

        // Collections locales pour stocker les résultats
        List<Secteur> listeSecteur;
        List<Liaison> listeLiaison;

        /// <summary>
        /// Initialise les listes locales.
        /// </summary>
        public Mgr()
        {
            listeSecteur = new List<Secteur>();
            listeLiaison = new List<Liaison>();
        }

        /// <summary>
        /// Récupère la liste des secteurs depuis la base de données via le DAO.
        /// </summary>
        /// <returns>Liste de Secteur</returns>
        public List<Secteur> getSecteursDB()
        {
            listeSecteur = SecteurDAO.getSecteurs();

            return (listeSecteur);
        }

        /// <summary>
        /// Récupère les liaisons pour un secteur donné via le DAO.
        /// </summary>
        /// <param name="s">Secteur cible</param>
        /// <returns>Liste de Liaison</returns>
        public List<Liaison> getLiaisonsDB(Secteur s)
        {
            listeLiaison = LiaisonDAO.getLiaisons(s);

            return (listeLiaison);
        }

        /// <summary>
        /// Met à jour la durée d'une liaison en base.
        /// </summary>
        public void updateLiaison(Liaison l, TimeSpan uneDuree)
        {
            LiaisonDAO.updateLiaison(l, uneDuree);
        }

        /// <summary>
        /// Supprime une liaison en base.
        /// </summary>
        public void deleteLiaisonDB(Liaison l)
        {
            LiaisonDAO.deleteLiaison(l);
        }

        /// <summary>
        /// Insère une nouvelle liaison en base.
        /// </summary>
        public void insertLiaisonDB(int unCodeLiaison, int unIdPortDepart, int unIdPortArrivee, int unIdSecteur, TimeSpan uneDuree)
        {
            LiaisonDAO.insertLiaison(unCodeLiaison, unIdPortDepart, unIdPortArrivee, unIdSecteur, uneDuree);
        }

        /// <summary>
        /// Récupère la liste des ports depuis la base via le DAO.
        /// </summary>
        /// <returns>Liste de Port</returns>
        public List<Port> getPortDB()
        {
            return PortDAO.getPorts();
        }

    }
}