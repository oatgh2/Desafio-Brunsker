using APIServices.Interfaces;
using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.DataBase;
using LocadoraImoveisModels.Models.Exceptions;
using LocadoraImoveisModels.Models.ViaCep;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
  internal class PropertyService : Service, IPropertyService
  {
    public PropertyService(LocacaoimoveisContext dbContext, IHttpContextAccessor httpContext) : base(dbContext, httpContext) { }

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
      ValidatePropertyRegistration(property);
      RestClient client = new RestClient("viacep.com.br/ws/");
      RestRequest request = new RestRequest(string.Format("{0}/json", property.CEP), Method.Get);
      RestResponse response = await client.ExecuteAsync(request, CancellationToken.None);

      if (response.IsSuccessStatusCode && response.Content != null)
      {
        ResultAddress? resultAddress = JsonConvert.DeserializeObject<ResultAddress>(response.Content);
        Properties properties = property.GetProperty(resultAddress!);
        Create(properties);

        return properties.GetResultProperty();
      }
      else
      {
        throw new ValidationErroException(new List<ValidationResult> {
        new ValidationResult("CEP não encontrado")
        });
      }
    }

    public void ValidatePropertyRegistration(RegisterProperty property)
    {
      List<ValidationResult> errors = new List<ValidationResult>();
      if (property.Numero!.Equals("0")) { errors.Add(new ValidationResult("Digite um numero válido", new[] { nameof(property.Numero) })); }
      
      bool duplicatedName = Database.Properties.Where(x => x.Name.Equals(property.Name!.ToLower())).Count() > 0;
      if (duplicatedName) { errors.Add(new ValidationResult("Propriedade já existente", new[] { nameof(property.Name) })); }



      if (errors.Count > 0)
        throw new ValidationErroException(errors);
    }

    public ResultProperty? RemoveProperty(int idProperty)
    {
      throw new NotImplementedException();
    }

    public ResultProperty? RentProperty(int idProperty)
    {
      Properties? property = Database.Properties.Where(x => x.Idproperties == idProperty).FirstOrDefault();
      ValidatePropertyRent(property);


      property!.IsRented = 1;
      property!.IdUser = User!.Id;
      Update(property);
      return property.GetResultProperty();
    }

    public void ValidatePropertyRent(Properties? propertie)
    {
      List<ValidationResult> errors = new List<ValidationResult>();

      if (propertie == null)
      {
        errors.Add(new ValidationResult("Propriedade não encontrada."));
        throw new ValidationErroException(errors);
      }


      if (propertie.IdUser.HasValue)
      {
        errors.Add(new ValidationResult("Propriedade já alugada."));
      }

      if (errors.Count > 0)
        throw new ValidationErroException(errors);
    }

    public ResultProperty? UnrentProperty(int idProperty)
    {
      Properties? property = Database.Properties.Where(x => x.Idproperties == idProperty).FirstOrDefault();
      ValidatePropertyUnRent(property);

      property!.IsRented = 0;
      property!.IdUser = null;
      Update(property);
      return property.GetResultProperty();
    }

    public void ValidatePropertyUnRent(Properties? propertie)
    {
      List<ValidationResult> errors = new List<ValidationResult>();

      if (propertie == null)
      {
        errors.Add(new ValidationResult("Propriedade não encontrada."));
        throw new ValidationErroException(errors);
      }

      

      if (propertie.IdUser.HasValue && (propertie.IdUser != User!.Id && User.IsAdmin != true))
      {
        errors.Add(new ValidationResult("Você não pode desalugar uma casa que não alugou."));
      }else if (!propertie.IdUser.HasValue)
      {
        errors.Add(new ValidationResult("Esta casa não está alugada"));
      }

      if (errors.Count > 0)
        throw new ValidationErroException(errors);
    }

    public async Task<ResultProperty?> UpdateProperty(UpdateProperty property)
    {
      ValidatePropertyUpdate(property);
      RestClient client = new RestClient("viacep.com.br/ws/");
      RestRequest request = new RestRequest(string.Format("{0}/json", property.CEP), Method.Get);
      RestResponse response = await client.ExecuteAsync(request, CancellationToken.None);

      if (response.IsSuccessStatusCode && response.Content != null)
      {
        ResultAddress? resultAddress = JsonConvert.DeserializeObject<ResultAddress>(response.Content);
        
        Properties properties = property.GetProperty(resultAddress!);
        Update (properties);

        return properties.GetResultProperty();
      }
      else
      {
        throw new ValidationErroException(new List<ValidationResult> {
         new ValidationResult("CEP não encontrado")
        });
      }
    }

    public void ValidatePropertyUpdate(UpdateProperty property)
    {
      List<ValidationResult> errors = new List<ValidationResult>();
      if (property.Numero!.Equals("0")) { errors.Add(new ValidationResult("Digite um numero válido", new[] { nameof(property.Numero) })); }

      bool duplicatedName = Database.Properties.Where(x => x.Name.Equals(property.Name!.ToLower())).Count() > 0;
      if (duplicatedName) { errors.Add(new ValidationResult("Propriedade já existente", new[] { nameof(property.Name) })); }



      if (errors.Count > 0)
        throw new ValidationErroException(errors);
    }
  }
}
