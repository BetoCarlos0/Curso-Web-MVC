using curso.web.mvc.Models.User;
using Refit;
using System.Threading.Tasks;

namespace curso.web.mvc.Services
{
    public interface IUserServices
    {
        [Post("/api/v1/usuario/registrar")]
        Task<CreateUserViewModel> Register(CreateUserViewModel createUserViewModel);

        [Post("/api/v1/usuario/logar")]
        Task<LoginViewModelOutput> Index(LoginUserViewModel loginUserViewModel);
    }
}
