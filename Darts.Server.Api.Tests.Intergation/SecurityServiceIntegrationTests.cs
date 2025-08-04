using Darts.Server.Application.DTO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Darts.Server.Api.Tests.Intergation
{
    public class SecurityServiceIntegrationTests : IClassFixture<DartsServerApiApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public SecurityServiceIntegrationTests(DartsServerApiApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task CheckUnauthorized()
        {
            // Try with token 
            var responce = await _httpClient.GetAsync($"/auth/check");
            Assert.Equal(responce?.StatusCode, HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task CheckAuthorized()
        {
            var login = $"user{Guid.NewGuid()}";
            var password = $"password{Guid.NewGuid()}";

            var userCreationDTO = new UserCreationDTO()
            {
                Login = login,
                Password = password
            };

            var loginDTO = new LoginDTO()
            {
                Login = login,
                Password = password
            };

            // Create user
            await _httpClient.PostAsJsonAsync("/user/add", userCreationDTO);

            // Get auth token as registred user
            var responce = await _httpClient.PostAsJsonAsync("/auth", loginDTO);
            var jwtToken = await responce.Content.ReadAsStringAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            // Try with token 
            responce = await _httpClient.GetAsync($"/auth/check");
            Assert.Equal(responce?.StatusCode, HttpStatusCode.OK);
        }
    }
}
