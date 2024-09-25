namespace Zara_GestionDVD.Models
{
    public class Utilisateur
    {
        public string Id { get; set; }
        public string Prenom { get; set; }
        public string Courriel { get; set; }
        public string MotDePasse { get; set; }
        public bool NotificationsActives { get; set; }
        public List<DVD> DVDsPossedes { get; set; }
    }
}
