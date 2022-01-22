using System.ComponentModel.DataAnnotations;

namespace curso.web.mvc.Models.User
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Login Obrigatória")]
        [StringLength(10), MinLength(3, ErrorMessage = "Login menor que 3 dígitos")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Senha Obrigatória")]
        [StringLength(10), MinLength(3, ErrorMessage = "Senha menor que 3 dígitos")]
        [Display(Name="Senha")]
        public string Password { get; set; }
    }
}
