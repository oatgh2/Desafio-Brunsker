using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;
using LocadoraImoveisModels.Models.Exceptions;
using LocadoraImoveisModels.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIServices
{
  public class UserService : Service, IUserService
  {
    public UserService(LocacaoimoveisContext dbContext, IHttpContextAccessor httpContext) : base(dbContext, httpContext) { }
    

    public LoggedUser? AuthenticateUser(LoginUser user)
    {
      string passwordHash = user.Password!.GetPasswordHash();
      User? loggingUser = Database.User.Where(x => x.UserCpf.Equals(user.Cpf) && x.UserPasswordHash.Equals(passwordHash)).FirstOrDefault();

      if (loggingUser != null)
      {
        LoggedUser loggedUser = loggingUser!.GetLoggedUser("");
        loggedUser.TokenJwt = Jwt.GetKey(loggedUser);
        return loggedUser;
      }
      return null;
    }

    public ResultUser CreateUser(RegisterUser model)
    {
      ValidateUserRegistration(model);
      User user = model.GetDatabaseUser();
      user.UserPasswordHash = model.Password!.GetPasswordHash();
      Create(user);
      ResultUser resultUser = user.GetResultUser();
      return resultUser;
    }

    public void DeleteUser(int idUser)
    {
      throw new NotImplementedException();
    }

    public ResultUser? GetUser(int idUser)
    {
      ResultUser? result = Database.User.Where(x => x.Iduser == idUser).Select(x => x.GetResultUser()).FirstOrDefault();
      return result;
    }

    public List<ResultUser> GetUsers()
    {
      List<ResultUser> result = Database.User.Select(x => x.GetResultUser()).ToList();
      return result;
    }

    public ResultUser? MakeAdmin(int idUser)
    {
      User? user = Database.User.Where(x => x.Iduser == idUser).FirstOrDefault();
      if (user != null)
      {
        user.AdminUser = 1;
        Update(user);
        return user.GetResultUser();
      }
      return null;
    }

    public ResultUser? RemoveAdmin(int idUser)
    {
      User? user = Database.User.Where(x => x.Iduser == idUser).FirstOrDefault();
      if (user != null)
      {
        user.AdminUser = 0;
        Update(user);
        return user.GetResultUser();
      }
      return null;
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