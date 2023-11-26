using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models.Attributes
{
  public class CPFValidationAttribute : ValidationAttribute
  {

    public CPFValidationAttribute(string errorMessage) : base(errorMessage) { }


    public override bool IsValid(object? value)
    {
      string? cpf = value as string;

      if (string.IsNullOrWhiteSpace(cpf)) { return false; }

      if (cpf.Length != 11)
      {
        return false;
      }

      if (cpf.Distinct().Count() == 1)
      {
        return false;
      }

      int sum = 0;
      for (int i = 0; i < 9; i++)
      {
        sum += int.Parse(cpf[i].ToString()) * (10 - i);
      }

      int remainder = sum % 11;
      int checkDigit1 = (remainder < 2) ? 0 : 11 - remainder;

      if (int.Parse(cpf[9].ToString()) != checkDigit1)
      {
        return false;
      }

      sum = 0;
      for (int i = 0; i < 10; i++)
      {
        sum += int.Parse(cpf[i].ToString()) * (11 - i);
      }

      remainder = sum % 11;
      int checkDigit2 = (remainder < 2) ? 0 : 11 - remainder;

      if (int.Parse(cpf[10].ToString()) != checkDigit2)
      {
        return false;
      }

      return true;
    }
  }
}
