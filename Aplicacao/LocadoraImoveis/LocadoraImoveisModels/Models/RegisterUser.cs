using LocadoraImoveisModels.Models.Attributes;
using LocadoraImoveisModels.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class RegisterUser
  {
    public RegisterUser()
    {
    }

    public RegisterUser(string name, string password, string cpf)
    {
      Name = name;
      Password = password;
      Cpf = cpf;
    }

    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(256, ErrorMessage = "Máximo de 256 caracteres")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(32, ErrorMessage = "Máximo de 32 caracteres")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(11, ErrorMessage = "Máximo de 11 caracteres")]
    [CPFValidation("CPF Inválido")]
    public string? Cpf { get; set; }

    public User GetDatabaseUser()
    {
      User user = new User()
      {
        UserName = Name,
        UserCpf = Cpf,
      };
      return user;
    }
  }
}
