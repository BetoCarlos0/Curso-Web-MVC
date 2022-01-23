using curso.web.mvc.Models.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace curso.web.mvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginUserViewModel loginUserViewModel)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel createUserViewModel)
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            var httpClient = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };
            var createUserViewModelJson = JsonConvert.SerializeObject(createUserViewModel);

            var httpContent = new StringContent(createUserViewModelJson, Encoding.UTF8, "application/json");

            var httpPost = httpClient.PostAsync("/api/v1/usuario/registrar", httpContent).GetAwaiter().GetResult();

            if(httpPost.StatusCode == System.Net.HttpStatusCode.Created)
            {
                ModelState.AddModelError("", "Cadastrado com sucesso!");
            }
            else
            {
                ModelState.AddModelError("", "Erro ao cadastrar");
            }
    
            return View();
        }
    }
}
