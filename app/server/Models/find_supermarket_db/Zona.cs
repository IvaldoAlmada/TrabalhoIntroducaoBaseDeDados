using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("zona", Schema = "public")]
  public partial class Zona
  {

    [Column("população")]
    public int populao
    {
      get;
      set;
    }
    [Key]
    public int idz
    {
      get;
      set;
    }

    public ICollection<Supermercado> Supermercados { get; set; }
  }
}
