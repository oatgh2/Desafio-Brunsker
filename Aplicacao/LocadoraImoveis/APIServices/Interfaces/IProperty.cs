using LocadoraImoveisModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Interfaces
{
  internal interface IPropertyService
  {
    public Task<ResultProperty?> RegisterProperty(RegisterProperty property);
    public List<ResultProperty> GetPropererties();
    public ResultProperty? GetProperty(int idProperty);
    public Task<ResultProperty?> UpdateProperty(UpdateProperty property);
    public ResultProperty? RemoveProperty(int idProperty);
    public ResultProperty? RentProperty(int idProperty);
    public ResultProperty? UnrentProperty(int idProperty);
  }
}
