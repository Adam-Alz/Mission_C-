using Mission_C_.Controller;
using Mission_C_.DAL;
using Mission_C_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mission_C_
{
    public partial class Form1 : Form
    {
        // Gestionnaire central (couche métier)
        Mgr manager;

        // Collections locales pour stocker les données récupérées
        List<Secteur> listeSecteur = new List<Secteur>();
        List<Liaison> listeLiaison = new List<Liaison>();
        List<Port> listePortDepart = new List<Port>();
        List<Port> listePortArrivee = new List<Port>();

        public Form1()
        {
            InitializeComponent();

            // Instancie le manager qui appelle les DAO
            manager = new Mgr();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Chargement initial des données depuis la base
            listeSecteur = manager.getSecteursDB();
            listePortDepart = manager.getPortDB();
            listePortArrivee = manager.getPortDB();

            // Mise à jour des contrôles d'affichage
            lbSecteurAffichage();
            cbSecteurAffichage();
            cbPortDepartAffichage();
            cbPortArriveeAffichage();
        }

        // Remplit la ListBox des secteurs
        public void lbSecteurAffichage()
        {
            try
            {
                lbSecteur.DataSource = null;
                lbSecteur.DataSource = listeSecteur;
                lbSecteur.DisplayMember = "Description"; // propriété ToString ou équivalente attendue
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); // affichage simple des erreurs
            }
        }

        // Remplit le ComboBox des secteurs
        public void cbSecteurAffichage()
        {
            try
            {
                cbSecteur.DataSource = null;
                cbSecteur.DataSource = listeSecteur;
                cbSecteur.DisplayMember = "Description";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Filtre les ports de départ en fonction du secteur sélectionné
        public void cbPortDepartAffichage()
        {
            List<Port> selectedPort = new List<Port>();

            // Récupère le secteur sélectionné dans le combo
            Secteur selectedSecteur = (Secteur)cbSecteur.SelectedItem;
            string secteurName = selectedSecteur.getNomSecteur();

            // Parcours et filtrage simple par nom (attention : dépend du modèle de données)
            foreach (Port p in listePortDepart)
            {
                // Si le nom du port correspond au nom du secteur, on l'ajoute
                if (p.getNomPort() == secteurName)
                {
                    selectedPort.Add(p);
                }
            }

            // Affecte la liste filtrée au ComboBox
            cbPortDepart.DataSource = null;
            cbPortDepart.DataSource = selectedPort;
            cbPortDepart.DisplayMember = "Description";
        }

        // Remplit le ComboBox des ports d'arrivée (sans filtrage ici)
        public void cbPortArriveeAffichage()
        {
            try
            {
                cbPortArrivee.DataSource = null;
                cbPortArrivee.DataSource = listePortArrivee;
                cbPortArrivee.DisplayMember = "Description";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Affiche les liaisons pour le secteur sélectionné dans la ListBox
        public void lbLiaisonAffichage()
        {
            Secteur s = (Secteur)lbSecteur.SelectedItem;
            listeLiaison = manager.getLiaisonsDB(s);
            try
            {
                lbLiaison.DataSource = null;
                lbLiaison.DataSource = listeLiaison;
                lbLiaison.DisplayMember = "Description";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Bouton : rafraîchir l'affichage des liaisons
        private void bAffichage_Click(object sender, EventArgs e)
        {
            lbLiaisonAffichage();
        }

        // Bouton : mise à jour de la durée d'une liaison sélectionnée
        private void bMaj_Click(object sender, EventArgs e)
        {
            Liaison l = (Liaison)lbLiaison.SelectedItem;
            TimeSpan duree = TimeSpan.Parse(tb_UpdateDuree.Text); // attention aux formats invalides

            manager.updateLiaison(l, duree);
            lbLiaisonAffichage(); // rafraîchit l'affichage après MAJ
        }

        // Bouton : suppression de la liaison sélectionnée
        private void bDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
        "Êtes-vous sûr de vouloir supprimer cette liaison ?",
        "Confirmation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if ( result == DialogResult.Yes)
            {
                Liaison l = (Liaison)lbLiaison.SelectedItem;

                manager.deleteLiaisonDB(l);

                lbLiaisonAffichage(); // rafraîchit la liste
            }
            else
            {
                return;
            }

            
        }

        // Bouton : insertion d'une nouvelle liaison
        private void bInsert_Click(object sender, EventArgs e)
        {
            Secteur s = (Secteur)cbSecteur.SelectedItem;
            Port pd = (Port)cbPortDepart.SelectedItem;
            Port pa = (Port)cbPortArrivee.SelectedItem;

            int codeLiaison = Convert.ToInt16(tbCodeLiaison.Text);
            int idPortDepart = Convert.ToInt16(pd.getIdPort());
            int idPortArrivee = Convert.ToInt16(pa.getIdPort());
            int idSecteur = Convert.ToInt16(s.getIdSecteur());
            TimeSpan duree = TimeSpan.Parse(tbDuree.Text);

            // Validation simple : ports différents
            if (idPortDepart == idPortArrivee)
            {
                MessageBox.Show("Le port de départ ne peut pas être le même que le port d'arrivée");
                return;
            }
            else
            {
                LiaisonDAO.insertLiaison(codeLiaison, idPortDepart, idPortArrivee, idSecteur, duree);
                lbLiaisonAffichage();
            }
        }

        // Quand le secteur change, on met à jour les ports de départ et les liaisons affichées
        private void cbSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPortDepartAffichage();
            lbLiaisonAffichage();
        }
    }
}