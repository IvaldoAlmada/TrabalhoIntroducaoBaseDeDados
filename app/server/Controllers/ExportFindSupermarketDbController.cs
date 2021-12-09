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
        private readonly FindSupermarketDbService service;
        public ExportFindSupermarketDbController(FindSupermarketDbContext context, FindSupermarketDbService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/FindSupermarketDb/conduzs/csv")]
        [HttpGet("/export/FindSupermarketDb/conduzs/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportConduzsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConduzs(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/conduzs/excel")]
        [HttpGet("/export/FindSupermarketDb/conduzs/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportConduzsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConduzs(), Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/geographycolumns/csv")]
        [HttpGet("/export/FindSupermarketDb/geographycolumns/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGeographyColumnsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGeographyColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/geographycolumns/excel")]
        [HttpGet("/export/FindSupermarketDb/geographycolumns/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGeographyColumnsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGeographyColumns(), Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/geometrycolumns/csv")]
        [HttpGet("/export/FindSupermarketDb/geometrycolumns/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGeometryColumnsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGeometryColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/geometrycolumns/excel")]
        [HttpGet("/export/FindSupermarketDb/geometrycolumns/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGeometryColumnsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGeometryColumns(), Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/produtos/csv")]
        [HttpGet("/export/FindSupermarketDb/produtos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProdutosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProdutos(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/produtos/excel")]
        [HttpGet("/export/FindSupermarketDb/produtos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProdutosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProdutos(), Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/produtozonas/csv")]
        [HttpGet("/export/FindSupermarketDb/produtozonas/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProdutoZonasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProdutoZonas(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/produtozonas/excel")]
        [HttpGet("/export/FindSupermarketDb/produtozonas/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProdutoZonasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProdutoZonas(), Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/spatialrefsies/csv")]
        [HttpGet("/export/FindSupermarketDb/spatialrefsies/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSpatialRefSiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSpatialRefSies(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/spatialrefsies/excel")]
        [HttpGet("/export/FindSupermarketDb/spatialrefsies/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSpatialRefSiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSpatialRefSies(), Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/supermercados/csv")]
        [HttpGet("/export/FindSupermarketDb/supermercados/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSupermercadosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSupermercados(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/supermercados/excel")]
        [HttpGet("/export/FindSupermarketDb/supermercados/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSupermercadosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSupermercados(), Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/via/csv")]
        [HttpGet("/export/FindSupermarketDb/via/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportViaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetVia(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/via/excel")]
        [HttpGet("/export/FindSupermarketDb/via/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportViaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetVia(), Request.Query), fileName);
        }
        [HttpGet("/export/FindSupermarketDb/zonas/csv")]
        [HttpGet("/export/FindSupermarketDb/zonas/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportZonasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetZonas(), Request.Query), fileName);
        }

        [HttpGet("/export/FindSupermarketDb/zonas/excel")]
        [HttpGet("/export/FindSupermarketDb/zonas/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportZonasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetZonas(), Request.Query), fileName);
        }
    }
}
