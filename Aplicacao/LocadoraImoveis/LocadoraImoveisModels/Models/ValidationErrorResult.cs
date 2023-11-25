using LocadoraImoveisModels.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class ValidationErrorResult : Result
  {
    public ValidationErrorResult(List<ValidationResult> validationResults)
    {
      Data = validationResults;
      Status = ResultType.InvalideObject.GetDescription();
    }
  }
}
