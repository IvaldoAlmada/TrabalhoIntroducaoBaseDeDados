using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using FindSupermarket.Models.FindSupermarketDb;
using Microsoft.EntityFrameworkCore;

namespace FindSupermarket.Pages
{
    public partial class SupermercadosComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected FindSupermarketDbService FindSupermarketDb { get; set; }
        protected RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.Supermercado> grid0;

        IEnumerable<FindSupermarket.Models.FindSupermarketDb.Supermercado> _getSupermercadosResult;
        protected IEnumerable<FindSupermarket.Models.FindSupermarketDb.Supermercado> getSupermercadosResult
        {
            get
            {
                return _getSupermercadosResult;
            }
            set
            {
                if (!object.Equals(_getSupermercadosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSupermercadosResult", NewValue = value, OldValue = _getSupermercadosResult };
                    _getSupermercadosResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var findSupermarketDbGetSupermercadosResult = await FindSupermarketDb.GetSupermercados(new Query() { Expand = "Zona" });
            getSupermercadosResult = findSupermarketDbGetSupermercadosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSupermercado>("Add Supermercado", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(FindSupermarket.Models.FindSupermarketDb.Supermercado args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSupermercado>("Edit Supermercado", new Dictionary<string, object>() { {"ids", args.ids} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var findSupermarketDbDeleteSupermercadoResult = await FindSupermarketDb.DeleteSupermercado(data.ids);
                    if (findSupermarketDbDeleteSupermercadoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception findSupermarketDbDeleteSupermercadoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Supermercado" });
            }
        }
    }
}
