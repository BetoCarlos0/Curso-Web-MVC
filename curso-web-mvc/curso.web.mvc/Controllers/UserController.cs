using curso.web.mvc.Models.User;
using curso.web.mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace curso.web.mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices iUserServices)
        {
            _userServices = iUserServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginUserViewModel loginUserViewModel)
        {
            try
            {
                var user = await _userServices.Index(loginUserViewModel);

                ModelState.AddModelError("", "Cadastrado com sucesso!");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            try
            {
                var user  = await _userServices.Register(createUserViewModel);

                ModelState.AddModelError("", "Cadastrado com sucesso!");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            //var clientHandler = new HttpClientHandler
            //{
            //    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            //};
            //var httpClient = new HttpClient(clientHandler)
            //{
            //    BaseAddress = new Uri("https://localhost:5001/")
            //};
            //var createUserViewModelJson = JsonConvert.SerializeObject(createUserViewModel);
            //var httpContent = new StringContent(createUserViewModelJson, Encoding.UTF8, "application/json");
            //var httpPost = httpClient.PostAsync("/api/v1/usuario/registrar", httpContent).GetAwaiter().GetResult();

            //if(httpPost.StatusCode == System.Net.HttpStatusCode.Created)
            //{
            //    ModelState.AddModelError("", "Cadastrado com sucesso!");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Erro ao cadastrar");
            //}
    
            return View();
        }
    }
}
