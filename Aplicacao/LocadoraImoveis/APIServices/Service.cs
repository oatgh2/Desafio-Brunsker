using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
  public class Service
  {

    public Service()
    {
      Database = new LocacaoimoveisContext();
    }

    public Service(LoggedUser user)
    {
      Database = new LocacaoimoveisContext();
      User = user;
    }

    protected readonly LoggedUser? User;
    protected readonly LocacaoimoveisContext Database;
  }
}
