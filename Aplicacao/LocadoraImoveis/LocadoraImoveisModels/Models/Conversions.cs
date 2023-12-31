﻿using LocadoraImoveisModels.Models.DataBase;
using LocadoraImoveisModels.Models.ViaCep;
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

    public static Properties GetProperty(this RegisterProperty registerProperty, ResultAddress address)
    {
      Properties properties = new Properties()
      {
        Cep = registerProperty.CEP,
        Name = registerProperty.Name,
        Numero = Convert.ToInt32(registerProperty.Numero),
        Bairro = address.bairro,
        Cidade = address.localidade,
        Estado = address.uf,
        IsRented = 0,
      };

      return properties;
    }
    public static Properties GetProperty(this UpdateProperty registerProperty, ResultAddress address)
    {
      Properties properties = new Properties()
      {
        Cep = registerProperty.CEP,
        Name = registerProperty.Name,
        Numero = Convert.ToInt32(registerProperty.Numero),
        Bairro = address.bairro,
        Cidade = address.localidade,
        Estado = address.uf,
        IsRented = 0,
      };

      return properties;
    }

    public static ResultProperty GetResultProperty(this Properties properties)
    {
      UserProperty? rentProperty = null;
      if (properties.IdUserNavigation != null)
        rentProperty = new UserProperty(properties.IdUserNavigation.Iduser, properties.IdUserNavigation.UserName);

      ResultProperty resultUser = new ResultProperty(properties.Idproperties, properties.Name, properties.Bairro,
        properties.Cidade, properties.Numero.ToString(), properties.Estado, properties.Cep, properties.IsRented.ToBoolean(), rentProperty
        );
      return resultUser;
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
