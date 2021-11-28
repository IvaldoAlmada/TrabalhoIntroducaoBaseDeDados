using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("transporte", Schema = "public")]
  public partial class Transporte
  {
    [Key]
    public int idt
    {
      get;
      set;
    }
    public int? idv
    {
      get;
      set;
    }
    public Vium Vium { get; set; }
    public string bilhetes
    {
      get;
      set;
    }
  }
}
