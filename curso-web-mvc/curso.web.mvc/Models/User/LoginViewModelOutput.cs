using System.ComponentModel.DataAnnotations;

namespace curso.web.mvc.Models.User
{
    public class LoginViewModelOutput
    {
        //[Required(ErrorMessage = "Login Obrigatório")]
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
