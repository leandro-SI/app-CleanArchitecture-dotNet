using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email é requerido")]
        [EmailAddress(ErrorMessage = "Formato de Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é requerido")]
        [StringLength(20, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
