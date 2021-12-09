using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("produto_zona", Schema = "public")]
  public partial class ProdutoZona
  {
    public string tipo_supermercado
    {
      get;
      set;
    }
    public string nome_supermercado
    {
      get;
      set;
    }
    public string nome_produto
    {
      get;
      set;
    }
    public int? qtd_produto
    {
      get;
      set;
    }
    public string nome_zona
    {
      get;
      set;
    }
  }
}
