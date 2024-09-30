using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Zara_GestionDVD.Models
{
    public class Utilisateur : IdentityUser
    {
        public string Prenom { get; set; }
        public bool NotificationsActives { get; set; }
        public List<DVD> DVDsPossedes { get; set; }
    }
}