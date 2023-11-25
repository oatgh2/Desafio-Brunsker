using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class LoggedUser
  {
    public LoggedUser(int id, string name, string cpf, bool isAdmin, string tokenJwt)
    {
      Id = id;
      Name = name;
      Cpf = cpf;
      IsAdmin = isAdmin;
      TokenJwt = tokenJwt;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public bool IsAdmin { get; set; }
    public string TokenJwt { get; set; }
  }
}
