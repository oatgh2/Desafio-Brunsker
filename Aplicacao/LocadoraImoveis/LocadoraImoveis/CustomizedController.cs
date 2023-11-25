using Microsoft.AspNetCore.Mvc;
using LocadoraImoveisModels.Models;
using System.Security.Claims;

namespace LocadoraImoveisAPI
{
  public class CustomizedController : ControllerBase
  {
    protected LoggedUser? UserContext
    {
      get
      {
        IEnumerable<Claim> userClaims = HttpContext.User.Claims;
        if (userClaims != null && userClaims.Count() > 0)
        {
          LoggedUser? loggedUser = new LoggedUser(userClaims);
          return loggedUser;
        }
        return null;
      }
    }
  }
}
