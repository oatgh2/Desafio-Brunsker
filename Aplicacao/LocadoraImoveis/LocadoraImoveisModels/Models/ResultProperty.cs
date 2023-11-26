using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class ResultProperty
  {
    public ResultProperty()
    {
    }

    public ResultProperty(int? id, string? name, string? bairro, string? cidade, string? numero, string? estado, string? cEP, bool? isRentend, UserProperty? rent)
    {
      Id = id;
      Name = name;
      Bairro = bairro;
      Cidade = cidade;
      Numero = numero;
      Estado = estado;
      CEP = cEP;
      IsRentend = isRentend;
      Rent = rent;
    }

    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Numero { get; set; }
    public string? Estado { get; set; }
    public string? CEP { get; set; }
    public bool? IsRentend { get; set; }
    public UserProperty? Rent { get; set; }
  }
}
