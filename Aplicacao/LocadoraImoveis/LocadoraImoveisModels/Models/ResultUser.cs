using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class ResultUser
  {
    public ResultUser() { }

    public ResultUser(int? id, string? name, string? cpf, bool? isAdm)
    {
      Id = id;
      Name = name;
      Cpf = cpf;
      IsAdm = isAdm;
    }

    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public bool? IsAdm { get; set; }
  }
}
