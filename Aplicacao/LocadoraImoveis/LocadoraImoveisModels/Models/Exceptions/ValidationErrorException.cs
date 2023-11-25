using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models.Exceptions
{

  [Serializable]
  public class ValidationErroException : Exception
  {
    public ValidationErroException(List<ValidationResult> errors)
    {
      Errors = errors;
    }
    public ValidationErroException(List<ValidationResult> errors, string message) : base(message)
    {
      Errors = errors;
    }
    public ValidationErroException(List<ValidationResult> errors, string message, Exception inner) : base(message, inner) { Errors = errors; }
    public List<ValidationResult> Errors { get; set; }
    protected ValidationErroException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
  }

}
