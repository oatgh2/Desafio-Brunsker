using APIServices.Interfaces;
using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
  internal class PropertyService : Service, IPropertyService
  {
    public PropertyService(LocacaoimoveisContext dbContext, IHttpContextAccessor httpContext) : base(dbContext, httpContext){}

    public List<ResultProperty> GetPropererties()
    {
      List<ResultProperty> result = Database.Properties.Select(x => x.GetResultProperty()).ToList();
      return result;
    }

    public ResultProperty? GetProperty(int idProperty)
    {
      ResultProperty? result = Database.Properties.Where(x => x.Idproperties == idProperty).Select(x => x.GetResultProperty()).FirstOrDefault();
      return result;
    }

    public async Task<ResultProperty?> RegisterProperty(RegisterProperty property)
    {
      RestClient client = new RestClient("viacep.com.br/ws/");
      RestRequest request = new RestRequest(string.Format("{0}/json", property.CEP), Method.Get);
      RestResponse response = await client.ExecuteAsync(request, CancellationToken.None);

      throw new NotImplementedException();
    }

    public ResultProperty? RemoveProperty(int idProperty)
    {
      throw new NotImplementedException();
    }

    public ResultProperty? RentProperty(int idProperty)
    {
      throw new NotImplementedException();
    }

    public ResultProperty? UnrentProperty(int idProperty)
    {
      throw new NotImplementedException();
    }

    public Task<ResultProperty?> UpdateProperty(string idProperty)
    {
      throw new NotImplementedException();
    }
  }
}
