using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using FindSupermarket.Data;

namespace FindSupermarket
{
    public partial class FindSupermarketDbService
    {
        FindSupermarketDbContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly FindSupermarketDbContext context;
        private readonly NavigationManager navigationManager;

        public FindSupermarketDbService(FindSupermarketDbContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportConduzsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/conduzs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/conduzs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConduzsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/conduzs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/conduzs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConduzsRead(ref IQueryable<Models.FindSupermarketDb.Conduz> items);

        public async Task<IQueryable<Models.FindSupermarketDb.Conduz>> GetConduzs(Query query = null)
        {
            var items = Context.Conduzs.AsQueryable();

            items = items.Include(i => i.Supermercado);

            items = items.Include(i => i.Vium);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnConduzsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnConduzCreated(Models.FindSupermarketDb.Conduz item);
        partial void OnAfterConduzCreated(Models.FindSupermarketDb.Conduz item);

        public async Task<Models.FindSupermarketDb.Conduz> CreateConduz(Models.FindSupermarketDb.Conduz conduz)
        {
            OnConduzCreated(conduz);

            var existingItem = Context.Conduzs
                              .Where(i => i.ids == conduz.ids && i.idv == conduz.idv)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Conduzs.Add(conduz);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(conduz).State = EntityState.Detached;
                conduz.Supermercado = null;
                conduz.Vium = null;
                throw;
            }

            OnAfterConduzCreated(conduz);

            return conduz;
        }
        public async Task ExportProdutosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/produtos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/produtos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProdutosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/produtos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/produtos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProdutosRead(ref IQueryable<Models.FindSupermarketDb.Produto> items);

        public async Task<IQueryable<Models.FindSupermarketDb.Produto>> GetProdutos(Query query = null)
        {
            var items = Context.Produtos.AsQueryable();

            items = items.Include(i => i.Supermercado);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProdutosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProdutoCreated(Models.FindSupermarketDb.Produto item);
        partial void OnAfterProdutoCreated(Models.FindSupermarketDb.Produto item);

        public async Task<Models.FindSupermarketDb.Produto> CreateProduto(Models.FindSupermarketDb.Produto produto)
        {
            OnProdutoCreated(produto);

            var existingItem = Context.Produtos
                              .Where(i => i.idp == produto.idp)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Produtos.Add(produto);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(produto).State = EntityState.Detached;
                produto.Supermercado = null;
                throw;
            }

            OnAfterProdutoCreated(produto);

            return produto;
        }
        public async Task ExportSpatialRefSiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/spatialrefsies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/spatialrefsies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSpatialRefSiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/spatialrefsies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/spatialrefsies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSpatialRefSiesRead(ref IQueryable<Models.FindSupermarketDb.SpatialRefSy> items);

        public async Task<IQueryable<Models.FindSupermarketDb.SpatialRefSy>> GetSpatialRefSies(Query query = null)
        {
            var items = Context.SpatialRefSies.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSpatialRefSiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSpatialRefSyCreated(Models.FindSupermarketDb.SpatialRefSy item);
        partial void OnAfterSpatialRefSyCreated(Models.FindSupermarketDb.SpatialRefSy item);

        public async Task<Models.FindSupermarketDb.SpatialRefSy> CreateSpatialRefSy(Models.FindSupermarketDb.SpatialRefSy spatialRefSy)
        {
            OnSpatialRefSyCreated(spatialRefSy);

            var existingItem = Context.SpatialRefSies
                              .Where(i => i.srid == spatialRefSy.srid)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SpatialRefSies.Add(spatialRefSy);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(spatialRefSy).State = EntityState.Detached;
                throw;
            }

            OnAfterSpatialRefSyCreated(spatialRefSy);

            return spatialRefSy;
        }
        public async Task ExportSupermercadosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/supermercados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/supermercados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSupermercadosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/supermercados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/supermercados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSupermercadosRead(ref IQueryable<Models.FindSupermarketDb.Supermercado> items);

        public async Task<IQueryable<Models.FindSupermarketDb.Supermercado>> GetSupermercados(Query query = null)
        {
            var items = Context.Supermercados.AsQueryable();

            items = items.Include(i => i.Zona);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSupermercadosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupermercadoCreated(Models.FindSupermarketDb.Supermercado item);
        partial void OnAfterSupermercadoCreated(Models.FindSupermarketDb.Supermercado item);

        public async Task<Models.FindSupermarketDb.Supermercado> CreateSupermercado(Models.FindSupermarketDb.Supermercado supermercado)
        {
            OnSupermercadoCreated(supermercado);

            var existingItem = Context.Supermercados
                              .Where(i => i.ids == supermercado.ids)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Supermercados.Add(supermercado);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(supermercado).State = EntityState.Detached;
                supermercado.Zona = null;
                throw;
            }

            OnAfterSupermercadoCreated(supermercado);

            return supermercado;
        }
        public async Task ExportTransportesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/transportes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/transportes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransportesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/transportes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/transportes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransportesRead(ref IQueryable<Models.FindSupermarketDb.Transporte> items);

        public async Task<IQueryable<Models.FindSupermarketDb.Transporte>> GetTransportes(Query query = null)
        {
            var items = Context.Transportes.AsQueryable();

            items = items.Include(i => i.Vium);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTransportesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransporteCreated(Models.FindSupermarketDb.Transporte item);
        partial void OnAfterTransporteCreated(Models.FindSupermarketDb.Transporte item);

        public async Task<Models.FindSupermarketDb.Transporte> CreateTransporte(Models.FindSupermarketDb.Transporte transporte)
        {
            OnTransporteCreated(transporte);

            var existingItem = Context.Transportes
                              .Where(i => i.idt == transporte.idt)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Transportes.Add(transporte);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transporte).State = EntityState.Detached;
                transporte.Vium = null;
                throw;
            }

            OnAfterTransporteCreated(transporte);

            return transporte;
        }
        public async Task ExportViaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/via/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/via/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportViaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/via/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/via/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnViaRead(ref IQueryable<Models.FindSupermarketDb.Vium> items);

        public async Task<IQueryable<Models.FindSupermarketDb.Vium>> GetVia(Query query = null)
        {
            var items = Context.Via.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnViaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnViumCreated(Models.FindSupermarketDb.Vium item);
        partial void OnAfterViumCreated(Models.FindSupermarketDb.Vium item);

        public async Task<Models.FindSupermarketDb.Vium> CreateVium(Models.FindSupermarketDb.Vium vium)
        {
            OnViumCreated(vium);

            var existingItem = Context.Via
                              .Where(i => i.idv == vium.idv)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Via.Add(vium);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(vium).State = EntityState.Detached;
                throw;
            }

            OnAfterViumCreated(vium);

            return vium;
        }
        public async Task ExportZonasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/zonas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/zonas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportZonasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/findsupermarketdb/zonas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/findsupermarketdb/zonas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnZonasRead(ref IQueryable<Models.FindSupermarketDb.Zona> items);

        public async Task<IQueryable<Models.FindSupermarketDb.Zona>> GetZonas(Query query = null)
        {
            var items = Context.Zonas.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnZonasRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnZonaCreated(Models.FindSupermarketDb.Zona item);
        partial void OnAfterZonaCreated(Models.FindSupermarketDb.Zona item);

        public async Task<Models.FindSupermarketDb.Zona> CreateZona(Models.FindSupermarketDb.Zona zona)
        {
            OnZonaCreated(zona);

            var existingItem = Context.Zonas
                              .Where(i => i.idz == zona.idz)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Zonas.Add(zona);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(zona).State = EntityState.Detached;
                throw;
            }

            OnAfterZonaCreated(zona);

            return zona;
        }

        partial void OnConduzDeleted(Models.FindSupermarketDb.Conduz item);
        partial void OnAfterConduzDeleted(Models.FindSupermarketDb.Conduz item);

        public async Task<Models.FindSupermarketDb.Conduz> DeleteConduz(int? ids, int? idv)
        {
            var itemToDelete = Context.Conduzs
                              .Where(i => i.ids == ids && i.idv == idv)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnConduzDeleted(itemToDelete);

            Context.Conduzs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterConduzDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnConduzGet(Models.FindSupermarketDb.Conduz item);

        public async Task<Models.FindSupermarketDb.Conduz> GetConduzByIdsAndIdv(int? ids, int? idv)
        {
            var items = Context.Conduzs
                              .AsNoTracking()
                              .Where(i => i.ids == ids && i.idv == idv);

            items = items.Include(i => i.Supermercado);

            items = items.Include(i => i.Vium);

            var itemToReturn = items.FirstOrDefault();

            OnConduzGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.FindSupermarketDb.Conduz> CancelConduzChanges(Models.FindSupermarketDb.Conduz item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnConduzUpdated(Models.FindSupermarketDb.Conduz item);
        partial void OnAfterConduzUpdated(Models.FindSupermarketDb.Conduz item);

        public async Task<Models.FindSupermarketDb.Conduz> UpdateConduz(int? ids, int? idv, Models.FindSupermarketDb.Conduz conduz)
        {
            OnConduzUpdated(conduz);

            var itemToUpdate = Context.Conduzs
                              .Where(i => i.ids == ids && i.idv == idv)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(conduz);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterConduzUpdated(conduz);

            return conduz;
        }

        partial void OnProdutoDeleted(Models.FindSupermarketDb.Produto item);
        partial void OnAfterProdutoDeleted(Models.FindSupermarketDb.Produto item);

        public async Task<Models.FindSupermarketDb.Produto> DeleteProduto(int? idp)
        {
            var itemToDelete = Context.Produtos
                              .Where(i => i.idp == idp)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProdutoDeleted(itemToDelete);

            Context.Produtos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProdutoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnProdutoGet(Models.FindSupermarketDb.Produto item);

        public async Task<Models.FindSupermarketDb.Produto> GetProdutoByidp(int? idp)
        {
            var items = Context.Produtos
                              .AsNoTracking()
                              .Where(i => i.idp == idp);

            items = items.Include(i => i.Supermercado);

            var itemToReturn = items.FirstOrDefault();

            OnProdutoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.FindSupermarketDb.Produto> CancelProdutoChanges(Models.FindSupermarketDb.Produto item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProdutoUpdated(Models.FindSupermarketDb.Produto item);
        partial void OnAfterProdutoUpdated(Models.FindSupermarketDb.Produto item);

        public async Task<Models.FindSupermarketDb.Produto> UpdateProduto(int? idp, Models.FindSupermarketDb.Produto produto)
        {
            OnProdutoUpdated(produto);

            var itemToUpdate = Context.Produtos
                              .Where(i => i.idp == idp)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(produto);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterProdutoUpdated(produto);

            return produto;
        }

        partial void OnSpatialRefSyDeleted(Models.FindSupermarketDb.SpatialRefSy item);
        partial void OnAfterSpatialRefSyDeleted(Models.FindSupermarketDb.SpatialRefSy item);

        public async Task<Models.FindSupermarketDb.SpatialRefSy> DeleteSpatialRefSy(int? srid)
        {
            var itemToDelete = Context.SpatialRefSies
                              .Where(i => i.srid == srid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSpatialRefSyDeleted(itemToDelete);

            Context.SpatialRefSies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSpatialRefSyDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSpatialRefSyGet(Models.FindSupermarketDb.SpatialRefSy item);

        public async Task<Models.FindSupermarketDb.SpatialRefSy> GetSpatialRefSyBysrid(int? srid)
        {
            var items = Context.SpatialRefSies
                              .AsNoTracking()
                              .Where(i => i.srid == srid);

            var itemToReturn = items.FirstOrDefault();

            OnSpatialRefSyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.FindSupermarketDb.SpatialRefSy> CancelSpatialRefSyChanges(Models.FindSupermarketDb.SpatialRefSy item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSpatialRefSyUpdated(Models.FindSupermarketDb.SpatialRefSy item);
        partial void OnAfterSpatialRefSyUpdated(Models.FindSupermarketDb.SpatialRefSy item);

        public async Task<Models.FindSupermarketDb.SpatialRefSy> UpdateSpatialRefSy(int? srid, Models.FindSupermarketDb.SpatialRefSy spatialRefSy)
        {
            OnSpatialRefSyUpdated(spatialRefSy);

            var itemToUpdate = Context.SpatialRefSies
                              .Where(i => i.srid == srid)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(spatialRefSy);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterSpatialRefSyUpdated(spatialRefSy);

            return spatialRefSy;
        }

        partial void OnSupermercadoDeleted(Models.FindSupermarketDb.Supermercado item);
        partial void OnAfterSupermercadoDeleted(Models.FindSupermarketDb.Supermercado item);

        public async Task<Models.FindSupermarketDb.Supermercado> DeleteSupermercado(int? ids)
        {
            var itemToDelete = Context.Supermercados
                              .Where(i => i.ids == ids)
                              .Include(i => i.Produtos)
                              .Include(i => i.Conduzs)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupermercadoDeleted(itemToDelete);

            Context.Supermercados.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSupermercadoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSupermercadoGet(Models.FindSupermarketDb.Supermercado item);

        public async Task<Models.FindSupermarketDb.Supermercado> GetSupermercadoByids(int? ids)
        {
            var items = Context.Supermercados
                              .AsNoTracking()
                              .Where(i => i.ids == ids);

            items = items.Include(i => i.Zona);

            var itemToReturn = items.FirstOrDefault();

            OnSupermercadoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.FindSupermarketDb.Supermercado> CancelSupermercadoChanges(Models.FindSupermarketDb.Supermercado item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSupermercadoUpdated(Models.FindSupermarketDb.Supermercado item);
        partial void OnAfterSupermercadoUpdated(Models.FindSupermarketDb.Supermercado item);

        public async Task<Models.FindSupermarketDb.Supermercado> UpdateSupermercado(int? ids, Models.FindSupermarketDb.Supermercado supermercado)
        {
            OnSupermercadoUpdated(supermercado);

            var itemToUpdate = Context.Supermercados
                              .Where(i => i.ids == ids)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(supermercado);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterSupermercadoUpdated(supermercado);

            return supermercado;
        }

        partial void OnTransporteDeleted(Models.FindSupermarketDb.Transporte item);
        partial void OnAfterTransporteDeleted(Models.FindSupermarketDb.Transporte item);

        public async Task<Models.FindSupermarketDb.Transporte> DeleteTransporte(int? idt)
        {
            var itemToDelete = Context.Transportes
                              .Where(i => i.idt == idt)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransporteDeleted(itemToDelete);

            Context.Transportes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransporteDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTransporteGet(Models.FindSupermarketDb.Transporte item);

        public async Task<Models.FindSupermarketDb.Transporte> GetTransporteByidt(int? idt)
        {
            var items = Context.Transportes
                              .AsNoTracking()
                              .Where(i => i.idt == idt);

            items = items.Include(i => i.Vium);

            var itemToReturn = items.FirstOrDefault();

            OnTransporteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.FindSupermarketDb.Transporte> CancelTransporteChanges(Models.FindSupermarketDb.Transporte item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransporteUpdated(Models.FindSupermarketDb.Transporte item);
        partial void OnAfterTransporteUpdated(Models.FindSupermarketDb.Transporte item);

        public async Task<Models.FindSupermarketDb.Transporte> UpdateTransporte(int? idt, Models.FindSupermarketDb.Transporte transporte)
        {
            OnTransporteUpdated(transporte);

            var itemToUpdate = Context.Transportes
                              .Where(i => i.idt == idt)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(transporte);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTransporteUpdated(transporte);

            return transporte;
        }

        partial void OnViumDeleted(Models.FindSupermarketDb.Vium item);
        partial void OnAfterViumDeleted(Models.FindSupermarketDb.Vium item);

        public async Task<Models.FindSupermarketDb.Vium> DeleteVium(int? idv)
        {
            var itemToDelete = Context.Via
                              .Where(i => i.idv == idv)
                              .Include(i => i.Transportes)
                              .Include(i => i.Conduzs)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnViumDeleted(itemToDelete);

            Context.Via.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterViumDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnViumGet(Models.FindSupermarketDb.Vium item);

        public async Task<Models.FindSupermarketDb.Vium> GetViumByidv(int? idv)
        {
            var items = Context.Via
                              .AsNoTracking()
                              .Where(i => i.idv == idv);

            var itemToReturn = items.FirstOrDefault();

            OnViumGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.FindSupermarketDb.Vium> CancelViumChanges(Models.FindSupermarketDb.Vium item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnViumUpdated(Models.FindSupermarketDb.Vium item);
        partial void OnAfterViumUpdated(Models.FindSupermarketDb.Vium item);

        public async Task<Models.FindSupermarketDb.Vium> UpdateVium(int? idv, Models.FindSupermarketDb.Vium vium)
        {
            OnViumUpdated(vium);

            var itemToUpdate = Context.Via
                              .Where(i => i.idv == idv)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(vium);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterViumUpdated(vium);

            return vium;
        }

        partial void OnZonaDeleted(Models.FindSupermarketDb.Zona item);
        partial void OnAfterZonaDeleted(Models.FindSupermarketDb.Zona item);

        public async Task<Models.FindSupermarketDb.Zona> DeleteZona(int? idz)
        {
            var itemToDelete = Context.Zonas
                              .Where(i => i.idz == idz)
                              .Include(i => i.Supermercados)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnZonaDeleted(itemToDelete);

            Context.Zonas.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterZonaDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnZonaGet(Models.FindSupermarketDb.Zona item);

        public async Task<Models.FindSupermarketDb.Zona> GetZonaByidz(int? idz)
        {
            var items = Context.Zonas
                              .AsNoTracking()
                              .Where(i => i.idz == idz);

            var itemToReturn = items.FirstOrDefault();

            OnZonaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.FindSupermarketDb.Zona> CancelZonaChanges(Models.FindSupermarketDb.Zona item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnZonaUpdated(Models.FindSupermarketDb.Zona item);
        partial void OnAfterZonaUpdated(Models.FindSupermarketDb.Zona item);

        public async Task<Models.FindSupermarketDb.Zona> UpdateZona(int? idz, Models.FindSupermarketDb.Zona zona)
        {
            OnZonaUpdated(zona);

            var itemToUpdate = Context.Zonas
                              .Where(i => i.idz == idz)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(zona);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterZonaUpdated(zona);

            return zona;
        }
    }
}
