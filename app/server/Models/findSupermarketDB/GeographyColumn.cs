using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("geography_columns", Schema = "public")]
  public partial class GeographyColumn
  {
    public string f_table_catalog
    {
      get;
      set;
    }
    public string f_table_schema
    {
      get;
      set;
    }
    public string f_table_name
    {
      get;
      set;
    }
    public string f_geography_column
    {
      get;
      set;
    }
    public int? coord_dimension
    {
      get;
      set;
    }
    public int? srid
    {
      get;
      set;
    }
    public string type
    {
      get;
      set;
    }
  }
}
