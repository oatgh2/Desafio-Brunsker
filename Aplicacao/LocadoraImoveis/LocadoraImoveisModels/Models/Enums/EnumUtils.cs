using LocadoraImoveisModels.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models.Enums
{
  public static class EnumUtils
  {
    public static string? GetDescription<T>(this T @enum) where T : Enum
    {
      Type type = typeof(T);
      object[] attributes = type.GetCustomAttributes(typeof(DescriptionAttribute), false);

      if (attributes.Length > 0)
      {
        DescriptionAttribute descriptionAttribute = (DescriptionAttribute)attributes[0];

        return descriptionAttribute.Description;
      }
      else
      {
        return null;
      }
    }
  }
}
