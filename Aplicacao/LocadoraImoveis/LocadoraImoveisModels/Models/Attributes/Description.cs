using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models.Attributes
{
  [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
  sealed class DescriptionAttribute : Attribute
  {
    public DescriptionAttribute(string description)
    {
      Description = description;
    }
    public string Description { get; set; }
  }
}
