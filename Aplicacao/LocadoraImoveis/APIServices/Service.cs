using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace APIServices
{
  public class Service
  {

    public Service()
    {
      Database = new LocacaoimoveisContext();
    }

    public Service(IHttpContextAccessor httpContextAccessor)
    {
      IEnumerable<Claim> userClaims = httpContextAccessor.HttpContext.User.Claims;
      Database = new LocacaoimoveisContext();
      if (userClaims!= null && userClaims.Count() > 0)
      {
        LoggedUser? loggedUser = new LoggedUser(userClaims);
        User = loggedUser;
      }
    }

    protected readonly LoggedUser? User;
    protected readonly LocacaoimoveisContext Database;
  }
}
