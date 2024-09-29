using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Zara_GestionDVD.Models
{
    public class Utilisateur : IdentityUser
    {
        // Propriétés supplémentaires
        public string Prenom { get; set; }
        public bool NotificationsActives { get; set; }

        // Relation avec les DVDs
        public List<DVD> DVDsPossedes { get; set; }
    }
}