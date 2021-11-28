using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using FindSupermarket.Models.FindSupermarketDb;

namespace FindSupermarket.Data
{
  public partial class FindSupermarketDbContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public FindSupermarketDbContext(DbContextOptions<FindSupermarketDbContext> options):base(options)
    {
    }

    public FindSupermarketDbContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<FindSupermarket.Models.FindSupermarketDb.Conduz>().HasKey(table => new {
          table.ids, table.idv
        });
        builder.Entity<FindSupermarket.Models.FindSupermarketDb.Conduz>()
              .HasOne(i => i.Supermercado)
              .WithMany(i => i.Conduzs)
              .HasForeignKey(i => i.ids)
              .HasPrincipalKey(i => i.ids);
        builder.Entity<FindSupermarket.Models.FindSupermarketDb.Conduz>()
              .HasOne(i => i.Vium)
              .WithMany(i => i.Conduzs)
              .HasForeignKey(i => i.idv)
              .HasPrincipalKey(i => i.idv);
        builder.Entity<FindSupermarket.Models.FindSupermarketDb.Produto>()
              .HasOne(i => i.Supermercado)
              .WithMany(i => i.Produtos)
              .HasForeignKey(i => i.ids)
              .HasPrincipalKey(i => i.ids);
        builder.Entity<FindSupermarket.Models.FindSupermarketDb.Supermercado>()
              .HasOne(i => i.Zona)
              .WithMany(i => i.Supermercados)
              .HasForeignKey(i => i.idz)
              .HasPrincipalKey(i => i.idz);
        builder.Entity<FindSupermarket.Models.FindSupermarketDb.Transporte>()
              .HasOne(i => i.Vium)
              .WithMany(i => i.Transportes)
              .HasForeignKey(i => i.idv)
              .HasPrincipalKey(i => i.idv);

        this.OnModelBuilding(builder);
    }


    public DbSet<FindSupermarket.Models.FindSupermarketDb.Conduz> Conduzs
    {
      get;
      set;
    }

    public DbSet<FindSupermarket.Models.FindSupermarketDb.Produto> Produtos
    {
      get;
      set;
    }

    public DbSet<FindSupermarket.Models.FindSupermarketDb.SpatialRefSy> SpatialRefSies
    {
      get;
      set;
    }

    public DbSet<FindSupermarket.Models.FindSupermarketDb.Supermercado> Supermercados
    {
      get;
      set;
    }

    public DbSet<FindSupermarket.Models.FindSupermarketDb.Transporte> Transportes
    {
      get;
      set;
    }

    public DbSet<FindSupermarket.Models.FindSupermarketDb.Vium> Via
    {
      get;
      set;
    }

    public DbSet<FindSupermarket.Models.FindSupermarketDb.Zona> Zonas
    {
      get;
      set;
    }
  }
}
