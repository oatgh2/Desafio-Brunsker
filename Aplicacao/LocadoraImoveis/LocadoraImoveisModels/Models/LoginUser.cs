using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class LoginUser
  {
    public LoginUser() { }
    public LoginUser(string? password, string? cpf)
    {
      Password = password;
      Cpf = cpf;
    }
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(32, ErrorMessage = "Máximo de 32 caracteres")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(11, ErrorMessage = "Máximo de 11 caracteres")]
    public string? Cpf { get; set; }
  }
}
