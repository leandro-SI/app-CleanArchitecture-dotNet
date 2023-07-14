using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CleanArchMVC.API.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Compare("Password", ErrorMessage = "A senha não corresponde")]
        public string ConfirmPassword { get; set; }
    }
}
