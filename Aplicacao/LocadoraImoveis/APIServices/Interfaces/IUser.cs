using LocadoraImoveisModels.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models.Interfaces
{
  public interface IUserService
  {
    public User? GetUser(int idUser);
    public List<User> GetUsers();
    public User CreateUser(RegisterUser user);
    public LoggedUser? AuthenticateUser(LoginUser user);
  }
}
