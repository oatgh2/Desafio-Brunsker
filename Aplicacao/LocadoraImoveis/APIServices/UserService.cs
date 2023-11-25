using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;
using LocadoraImoveisModels.Models.Exceptions;
using LocadoraImoveisModels.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIServices
{
  public class UserService : Service, IUserService
  {
    public LoggedUser? AuthenticateUser(LoginUser user)
    {
      string passwordHash = user.Password!.GetPasswordHash();
      User? loggingUser = Database.User.Where(x => x.UserCpf.Equals(user) && x.UserPasswordHash.Equals(user)).FirstOrDefault();

      if (loggingUser != null)
      {
        LoggedUser loggedUser = loggingUser!.GetLoggedUser("");
        loggedUser.TokenJwt = Jwt.GetKey(loggedUser);
        return loggedUser;
      }
      return null;
    }

    public User CreateUser(RegisterUser model)
    {
      User user = model.GetDatabaseUser();
      user.UserPasswordHash = model.Password!.GetPasswordHash();

      Database.Entry(user).State = EntityState.Added;
      return user;
    }

    public ResultUser? GetUser(int idUser)
    {
      ResultUser? result = Database.User.Where(x => x.Iduser == idUser).Select(x => new ResultUser()
      {
        Id = x.Iduser,
        Cpf = x.UserCpf,
        IsAdm = x.AdminUser > 0,
        Name = x.UserName
      }).FirstOrDefault();
      return result;
    }

    public List<ResultUser> GetUsers()
    {
      List<ResultUser> result = Database.User.Select(x => new ResultUser()
      {
        Id = x.Iduser,
        Cpf = x.UserCpf,
        IsAdm = x.AdminUser > 0,
        Name = x.UserName
      }).ToList();
      return result;
    }

    public void ValidateUserRegistration(RegisterUser user)
    {
      List<ValidationResult> errors = new List<ValidationResult>();
      bool duplicatedCpf = Database.User.Where(x => x.UserCpf.Equals(user.Cpf)).Count() > 0;
      if (duplicatedCpf) { errors.Add(new ValidationResult("CPF já cadastrado", new[] { nameof(user.Cpf) })); }

      if (errors.Count > 0)
        throw new ValidationErroException(errors);
    }
  }
}