using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class UpdateProperty
  {
    public UpdateProperty()
    {
    }

    public UpdateProperty(int? idProperty, string? numero, string? cEP, string? name)
    {
      Numero = numero;
      CEP = cEP;
      Name = name;
      IdProperty = idProperty;
    }
    public int? IdProperty { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string? Numero { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(9, ErrorMessage = "O campo não pode ter mais de 8 caracteres")]
    [MinLength(8, ErrorMessage = "O campo não pode ter menos de 8 caracteres")]
    public string? CEP { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(32, ErrorMessage = "O campo não pode ter mais de 32 caracteres")]
    public string? Name { get; set; }
  }
}
