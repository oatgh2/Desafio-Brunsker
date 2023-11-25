using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;

namespace APIServices
{

  public static class Jwt
  {
    public static string SECURITY_KEY = "00A27B2B-B72B-44FB-9172-909904C6EBE";
    public static string GetKey(LoggedUser model)
    {
      SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECURITY_KEY));
      SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      JwtSecurityToken token = new JwtSecurityToken(
        claims: new[]
        {
          new Claim(ClaimTypes.Name, model.Name!),
          new Claim("CPF", model.Cpf!),
          new Claim("IsAdm", model.IsAdmin.ToString()),
          new Claim("Id", model.Id.ToString())
        },
        signingCredentials: credentials
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }

  public static class Utils
  {
    public static string GetPasswordHash(this string password)
    {
      byte[] salt = Encoding.UTF8.GetBytes("{CB5B6E11-F404-4ED0-9A36-64C020B07D2E}");

      string passWithSalt = password + Convert.ToBase64String(salt);

      string hashSenha = ComputeHash(passWithSalt);

      return hashSenha;
    }

    private static string ComputeHash(string passWithSalt)
    {
      using (var sha256 = SHA256.Create())
      {
        byte[] bytes = Encoding.UTF8.GetBytes(passWithSalt);
        byte[] hashBytes = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hashBytes);
      }
    }

    public static bool ToBoolean(this sbyte sByte)
    {
      return sByte > 0;
    }

    public static LoggedUser GetLoggedUser(this User user, string token)
    {
      LoggedUser loggedUser = new LoggedUser(user.Iduser, user.UserName, user.UserCpf, user.AdminUser.ToBoolean(), token);
      return loggedUser;
    }
  }
}
