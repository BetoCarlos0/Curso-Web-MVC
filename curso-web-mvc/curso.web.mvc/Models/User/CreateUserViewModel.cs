using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace curso.web.mvc.Models.User
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Login Obrigatória")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Login não pode ser menor que 3 ou maior que 40 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email Inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Senha Obrigatória")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Senha muito pequena")]
        [DataType(DataType.Password)]
        [JsonPropertyName("Senha")]
        public string Password { get; set; }
    }
}
