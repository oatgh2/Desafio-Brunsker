using LocadoraImoveisModels.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models.Attributes
{
  [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
  public class RequireAdmin : ActionFilterAttribute
  {


    public RequireAdmin()
    {
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
      IEnumerable<Claim> userClaims = context.HttpContext.User.Claims;
      if (userClaims != null && userClaims.Count() > 0)
      {
        LoggedUser? loggedUser =
          JsonConvert.DeserializeObject<LoggedUser>(userClaims.FirstOrDefault()!.Value);

        if (loggedUser != null && loggedUser.IsAdmin == true)
          return;
      }
      context.Result = new ForbidResult();
    }
  }
}
