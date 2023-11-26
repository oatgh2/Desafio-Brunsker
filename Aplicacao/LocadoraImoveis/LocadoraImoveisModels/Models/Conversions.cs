using LocadoraImoveisModels.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public static class Conversions
  {
    public static bool ToBoolean(this sbyte sByte)
    {
      return sByte > 0;
    }

    public static ResultUser GetResultUser(this User user)
    {
      ResultUser resultUser = new ResultUser(user.Iduser, user.UserName, user.UserCpf, user.AdminUser.ToBoolean());
      return resultUser;
    }

    public static LoggedUser GetLoggedUser(this User user, string token)
    {
      LoggedUser loggedUser = new LoggedUser(user.Iduser, user.UserName, user.UserCpf, user.AdminUser.ToBoolean(), token);
      return loggedUser;
    }
  }
}
