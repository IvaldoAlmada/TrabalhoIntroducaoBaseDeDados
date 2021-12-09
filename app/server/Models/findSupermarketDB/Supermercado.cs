using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("supermercado", Schema = "public")]
  public partial class Supermercado
  {
    [Key]
    public int ids
    {
      get;
      set;
    }

    public ICollection<Produto> Produtos { get; set; }
    public ICollection<Conduz> Conduzs { get; set; }
    public int? idz
    {
      get;
      set;
    }
    public Zona Zona { get; set; }
    public string nome
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
