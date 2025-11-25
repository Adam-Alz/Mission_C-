using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_C_.Models
{
    /// <summary>
    /// Représente un port avec son identifiant et son nom.
    /// Fournit des accesseurs en lecture et une représentation textuelle.
    /// </summary>
    internal class Port
    {
        /// <summary>
        /// Identifiant unique du port.
        /// </summary>
        private int idPort;

        /// <summary>
        /// Nom du port.
        /// </summary>
        private string nomPort;

        /// <summary>
        /// Initialise une nouvelle instance de Port avec l'identifiant et le nom fournis.
        /// </summary>
        /// <param name="idPort">Identifiant du port.</param>
        /// <param name="nomPort">Nom du port.</param>
        public Port(int idPort, string nomPort)
        {
            this.idPort = idPort;
            this.nomPort = nomPort;
        }

        /// <summary>
        /// Retourne l'identifiant du port.
        /// </summary>
        /// <returns>Identifiant du port.</returns>
        public int getIdPort()
        {
            return this.idPort;
        }

        /// <summary>
        /// Retourne le nom du port.
        /// </summary>
        /// <returns>Nom du port.</returns>
        public string getNomPort()
        {
            return this.nomPort;
        }

        /// <summary>
        /// Retourne une représentation textuelle du port sous la forme "id, nom".
        /// Utile pour l'affichage rapide ou le débogage.
        /// </summary>
        /// <returns>Chaîne contenant l'id et le nom du port.</returns>
        public override string ToString()
        {
            return (this.idPort + ", " + this.nomPort);
        }
    }
}