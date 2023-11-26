using LocadoraImoveisModels.Models.Attributes;

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
