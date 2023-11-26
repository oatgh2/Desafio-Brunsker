using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class UserProperty
  {
    public UserProperty()
    {
    }

    public UserProperty(int id, string name)
    {
      Name = name;
      Id = id;
    }

    public string? Name { get; set; }
    public int? Id { get; set; }
  }
}
