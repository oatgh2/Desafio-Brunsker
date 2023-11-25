using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models.Enums
{
  public enum ResultType
  {
    [Description("success")]
    Success,
    [Description("error")]
    Error,
    [Description("invalidObject")]
    InvalideObject
  }
}
