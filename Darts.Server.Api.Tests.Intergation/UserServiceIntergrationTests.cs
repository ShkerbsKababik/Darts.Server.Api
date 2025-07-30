using Darts.Server.Application.DTO;
using System.Net.Http.Json;

namespace Darts.Server.Api.Tests.Intergation;

public class UserServiceIntergrationTests : IClassFixture<DartsServerApiApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;

    public UserServiceIntergrationTests(DartsServerApiApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task UserCreationTest()
    {
        var login = $"user{Guid.NewGuid()}";
        var password = $"password{Guid.NewGuid()}";

        var userCreationDTO = new UserCreationDTO()
        {
            Login = login,
            Password = password
        };

        await _httpClient.PostAsJsonAsync("/user/add", userCreationDTO);
        var users = await _httpClient.GetFromJsonAsync<List<UserDTO>>($"/users");

        Assert.NotNull(users);
        Assert.Contains(users, u => u.Login == login);
    }
}
