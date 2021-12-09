using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("produto", Schema = "public")]
  public partial class Produto
  {
    [Key]
    public int idp
    {
      get;
      set;
    }
    public int? qtd
    {
      get;
      set;
    }
    public int? ids
    {
      get;
      set;
    }
    public Supermercado Supermercado { get; set; }
    public string nomedoproduto
    {
      get;
      set;
    }
  }
}
