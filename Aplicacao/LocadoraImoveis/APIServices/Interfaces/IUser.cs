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
    public ResultUser? GetUser(int idUser);
    public List<ResultUser> GetUsers();
    public ResultUser CreateUser(RegisterUser user);
    public LoggedUser? AuthenticateUser(LoginUser user);
    public ResultUser? MakeAdmin(int idUser);
    public ResultUser? RemoveAdmin(int idUser);
  }
}
