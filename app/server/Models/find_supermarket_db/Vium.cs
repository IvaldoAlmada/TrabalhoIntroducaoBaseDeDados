using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("via", Schema = "public")]
  public partial class Vium
  {
    public int tamanho
    {
      get;
      set;
    }
    [Key]
    public int idv
    {
      get;
      set;
    }

    public ICollection<Transporte> Transportes { get; set; }
    public ICollection<Conduz> Conduzs { get; set; }
  }
}
