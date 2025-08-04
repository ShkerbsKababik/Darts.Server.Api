using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Darts.Server.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Darts.Server.Infrastructure.Services;

public interface ISecurityService
{
    string GenerateToken(string login, string password);
}

public class SecurityService : ISecurityService
{
    private readonly IUserRepository _userRepository;

    public SecurityService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string GenerateToken(string login, string password)
    {
        var user = _userRepository.GetUserWithRolesByLogin(login);
        if (user.Login != login || user.Password != password)
        {
            throw new Exception("incorrect user or password");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, login),
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }

        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    const string KEY = "MyAuthKey";   // ключ для шифрации // должно быть больше 128 бит в utf-8
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        var keyBytes = Encoding.UTF8.GetBytes(KEY);

        // Если ключ всё ещё слишком короткий, можно дополнить его до нужного размера
        if (keyBytes.Length < 32)
        {
            var paddedKey = new byte[32];
            Array.Copy(keyBytes, paddedKey, Math.Min(keyBytes.Length, 32));
            keyBytes = paddedKey;
        }
        
        return new SymmetricSecurityKey(keyBytes);
    }
}