using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;
using LocadoraImoveisModels.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIServices
{
  public class UserService : Service, IUserService
  {
    public LoggedUser? AuthenticateUser(LoginUser user)
    {
      string passwordHash = user.Password!.GetPasswordHash();
      User? loggingUser = Database.User.Where(x => x.UserCpf.Equals(user) && x.UserPasswordHash.Equals(user)).FirstOrDefault();
      
      if(loggingUser != null)
      {
        LoggedUser loggedUser =  loggingUser!.GetLoggedUser("");
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

    public User? GetUser(int idUser)
    {
      User? result = Database.User.Where(x => x.Iduser == idUser).FirstOrDefault();
      return result;
    }


    public List<User> GetUsers()
    {
      List<User> result = Database.User.ToList();
      return result;
    }
  }
}