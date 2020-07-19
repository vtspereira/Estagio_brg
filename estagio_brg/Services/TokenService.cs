using estagio_brg.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

public class TokenService
{
    public static object GenerateToken(UserApi userApi)
    {
        var key = Encoding.ASCII.GetBytes(Settings.Secret);

        ClaimsIdentity identity = new ClaimsIdentity(
                 new GenericIdentity(userApi.Username, "Login"),
                 new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userApi.Username),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userApi.Password)
                 }
             );

        DateTime dataCriacao = DateTime.Now;
        DateTime dataExpiracao = dataCriacao +
            TimeSpan.FromHours(1);



        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = null,
            Audience = null,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Subject = identity,
            NotBefore = dataCriacao,
            Expires = dataExpiracao
        });
        var token = handler.WriteToken(securityToken);

        return new
        {
            authenticated = true,
            created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
            expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
            Token = token,
            message = "OK"
        };
    }
}