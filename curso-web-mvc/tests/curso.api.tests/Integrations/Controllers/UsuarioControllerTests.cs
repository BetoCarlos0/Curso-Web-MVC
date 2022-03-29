using curso.api.Models.Usuarios;
using curso.web.mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace curso.api.tests.Integrations.Controllers
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _httpClient;

        public UsuarioControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        public Task DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task InitializeAsync()
        {
            //Arrange
            var loginViewModelInput = new LoginViewModelInput
            {
                Login = "user",
                Senha = "123456"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginViewModelInput), Encoding.UTF8, "application/json");

            //Action
            var httpClient = await _httpClient.PostAsync("api/v1/usuario/logar", content);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, httpClient.StatusCode);
        }

        [Fact]
        public async Task Logar_informandoUsuarioESenhaExistente_RetornaOk()
        {
            //Arrange
            var loginViewModelInput = new LoginViewModelInput
            {
                Login = "user",
                Senha = "123456"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginViewModelInput), Encoding.UTF8, "application/json");

            //Action
            var httpClient = await _httpClient.PostAsync("api/v1/usuario/logar", content);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, httpClient.StatusCode);
        }
    }
}
