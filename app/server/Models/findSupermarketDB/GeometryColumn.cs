using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("geometry_columns", Schema = "public")]
  public partial class GeometryColumn
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
    public string f_geometry_column
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
