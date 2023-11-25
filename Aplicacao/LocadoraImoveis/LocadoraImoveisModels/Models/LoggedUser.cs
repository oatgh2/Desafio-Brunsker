using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class LoggedUser
  {
    public LoggedUser(IEnumerable<Claim> claims)
    {
      string id = claims.Where(x => x.Type.ToLower().Equals("Id")).Select(x => x.Value).FirstOrDefault()!;
      string CPF = claims.Where(x => x.Type.ToLower().Equals("CPF")).Select(x => x.Value).FirstOrDefault()!;
      string IsAdm = claims.Where(x => x.Type.ToLower().Equals("IsAdm")).Select(x => x.Value).FirstOrDefault()!;
      string Name = claims.Where(x => x.Type.ToLower().Equals("Name")).Select(x => x.Value).FirstOrDefault()!;

      Id = Convert.ToInt32(id);
      this.Name = Name;
      Cpf = CPF;
      IsAdmin = IsAdm.ToLower().Equals("true");
      TokenJwt = "";
    }

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
