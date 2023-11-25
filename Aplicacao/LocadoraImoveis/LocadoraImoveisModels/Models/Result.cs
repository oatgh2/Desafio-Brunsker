using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraImoveisModels.Models
{
  public class Result
  {
    public Result()
    {
    }

    public Result(string? status, object? data)
    {
      Status = status;
      Data = data;
    }

    public string? Status { get; set; }
    public object? Data { get; set; }
  }
}
