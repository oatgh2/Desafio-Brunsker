using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class RegisterProperty
  {
    public RegisterProperty()
    {
    }

    public RegisterProperty(string? numero, string? cEP, string? name)
    {
      Numero = numero;
      CEP = cEP;
      Name = name;
    }

    public string? Numero { get; set; }
    public string? CEP { get; set; }
    public string? Name { get; set; }
  }
}
