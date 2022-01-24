using curso.web.mvc.Models.User;
using curso.web.mvc.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
                //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                var user = await _userServices.Login(loginUserViewModel);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Usuario.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, user.Usuario.Login),
                    new Claim(ClaimTypes.Email, user.Usuario.Email),
                    new Claim("token", user.Token),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddDays(1))
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                ModelState.AddModelError("", $"O usuário está autenticado {user.Token}");
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
