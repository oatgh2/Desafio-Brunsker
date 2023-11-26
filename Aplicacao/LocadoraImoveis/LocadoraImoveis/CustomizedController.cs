using Microsoft.AspNetCore.Mvc;
using LocadoraImoveisModels.Models;
using System.Security.Claims;
using Newtonsoft.Json;

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
          LoggedUser? loggedUser = JsonConvert.DeserializeObject<LoggedUser>(userClaims.FirstOrDefault()!.Value);
          return loggedUser;
        }
        return null;
      }
    }
  }
}
