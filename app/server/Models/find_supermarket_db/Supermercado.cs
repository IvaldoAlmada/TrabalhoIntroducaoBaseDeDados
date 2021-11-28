using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("supermercado", Schema = "public")]
  public partial class Supermercado
  {
    public int? idz
    {
      get;
      set;
    }
    public Zona Zona { get; set; }
    public DateTime horafechamento
    {
      get;
      set;
    }
    [Key]
    public int ids
    {
      get;
      set;
    }

    public ICollection<Produto> Produtos { get; set; }
    public ICollection<Conduz> Conduzs { get; set; }
    public DateTime horaabertura
    {
      get;
      set;
    }
    public string tipo
    {
      get;
      set;
    }
  }
}
