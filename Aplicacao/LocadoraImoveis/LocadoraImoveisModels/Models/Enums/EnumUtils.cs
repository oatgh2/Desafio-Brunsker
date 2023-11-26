using LocadoraImoveisModels.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models.Enums
{
  public static class EnumUtils
  {
    public static string? GetDescription<T>(this T @enum) where T : Enum
    {
      Type type = typeof(T);

      MemberInfo[] memberInfo = type.GetMember(@enum.ToString());

      if (memberInfo.Length > 0)
      {
        object[] descriptionAttributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        if(descriptionAttributes.Length > 0)
        {
          DescriptionAttribute descriptionAttribute = (DescriptionAttribute)descriptionAttributes[0];

          return descriptionAttribute.Description;
        }
        return null;
      }
      else
      {
        return null;
      }
    }
  }
}
