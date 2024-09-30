using System.ComponentModel.DataAnnotations;

namespace Zara_GestionDVD.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Courriel { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Display(Name = "Rester connecté")]
        public bool ResterConnecte { get; set; }
    }
}