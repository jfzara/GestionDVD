using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Zara_GestionDVD.Models
{
    public class Utilisateur : IdentityUser
    {
        public string Prenom { get; set; }

        public bool NotificationsActives { get; set; }

        // Change List<DVD> to ICollection<DVD>
        public ICollection<DVD> DVDsPossedes { get; set; } = new List<DVD>();
    }
}