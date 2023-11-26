using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;

namespace APIServices
{
  public class Service
  {

    public Service(LocacaoimoveisContext dbContext, IHttpContextAccessor httpContext)
    {
      Database = dbContext;
      HttpContextAccessor = httpContext;
    }

    public T Create<T>(T Model) where T : class
    {
      Database.Entry(Model).State = EntityState.Added;
      Database.SaveChanges();

      return Model;
    }

    public T Update<T>(T Model) where T : class
    {
      Database.Entry(Model).State = EntityState.Modified;
      Database.SaveChanges();

      return Model;
    }

    public T Delete<T>(T Model) where T : class
    {
      Database.Entry(Model).State = EntityState.Deleted;
      Database.SaveChanges();

      return Model;
    }

    protected IHttpContextAccessor HttpContextAccessor { get; }
    protected LoggedUser? User
    {
      get
      {
        IEnumerable<Claim> userClaims = HttpContextAccessor.HttpContext.User.Claims;
        if (userClaims != null && userClaims.Count() > 0)
        {
          LoggedUser? loggedUser = JsonConvert.DeserializeObject<LoggedUser>(userClaims.FirstOrDefault()!.Value);
          return loggedUser;
        }
        return null;
      }
    }
    protected LocacaoimoveisContext Database { get; private set; }
  }
}
