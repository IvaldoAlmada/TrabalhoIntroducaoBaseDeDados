using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("conduz", Schema = "public")]
  public partial class Conduz
  {
    [Key]
    public int ids
    {
      get;
      set;
    }
    public Supermercado Supermercado { get; set; }
    [Key]
    public int idv
    {
      get;
      set;
    }
    public Vium Vium { get; set; }
  }
}
