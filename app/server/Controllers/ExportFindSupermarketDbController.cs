using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindSupermarket.Data;

namespace FindSupermarket
{
    public partial class ExportFindSupermarketDbController : ExportController
    {
        private readonly FindSupermarketDbContext context;

        public ExportFindSupermarketDbController(FindSupermarketDbContext context)
        {
            this.context = context;
        }
        [HttpGet("/export/FindSupermarketDb/conduzs/csv")]
        [HttpGet("/export/FindSupermarketDb/conduzs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportConduzsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Conduzs, Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/conduzs/excel")]
        [HttpGet("/export/FindSupermarketDb/conduzs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportConduzsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Conduzs, Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/produtos/csv")]
        [HttpGet("/export/FindSupermarketDb/produtos/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProdutosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Produtos, Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/produtos/excel")]
        [HttpGet("/export/FindSupermarketDb/produtos/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProdutosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Produtos, Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/spatialrefsies/csv")]
        [HttpGet("/export/FindSupermarketDb/spatialrefsies/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSpatialRefSiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SpatialRefSies, Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/spatialrefsies/excel")]
        [HttpGet("/export/FindSupermarketDb/spatialrefsies/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSpatialRefSiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SpatialRefSies, Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/supermercados/csv")]
        [HttpGet("/export/FindSupermarketDb/supermercados/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSupermercadosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Supermercados, Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/supermercados/excel")]
        [HttpGet("/export/FindSupermarketDb/supermercados/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSupermercadosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Supermercados, Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/transportes/csv")]
        [HttpGet("/export/FindSupermarketDb/transportes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTransportesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Transportes, Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/transportes/excel")]
        [HttpGet("/export/FindSupermarketDb/transportes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTransportesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Transportes, Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/via/csv")]
        [HttpGet("/export/FindSupermarketDb/via/csv(fileName='{fileName}')")]
        public FileStreamResult ExportViaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Via, Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/via/excel")]
        [HttpGet("/export/FindSupermarketDb/via/excel(fileName='{fileName}')")]
        public FileStreamResult ExportViaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Via, Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/zonas/csv")]
        [HttpGet("/export/FindSupermarketDb/zonas/csv(fileName='{fileName}')")]
        public FileStreamResult ExportZonasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Zonas, Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/zonas/excel")]
        [HttpGet("/export/FindSupermarketDb/zonas/excel(fileName='{fileName}')")]
        public FileStreamResult ExportZonasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Zonas, Request.Query), fileName);
        }
    }
}
