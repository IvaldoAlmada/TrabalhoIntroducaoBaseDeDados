using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindSupermarket.Models.FindSupermarketDb
{
  [Table("spatial_ref_sys", Schema = "public")]
  public partial class SpatialRefSy
  {
    [Key]
    public int srid
    {
      get;
      set;
    }
    public int? auth_srid
    {
      get;
      set;
    }
    public string auth_name
    {
      get;
      set;
    }
    public string srtext
    {
      get;
      set;
    }
    public string proj4text
    {
      get;
      set;
    }
  }
}
