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
    public partial class TransportesComponent : ComponentBase
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
        protected RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.Transporte> grid0;

        IEnumerable<FindSupermarket.Models.FindSupermarketDb.Transporte> _getTransportesResult;
        protected IEnumerable<FindSupermarket.Models.FindSupermarketDb.Transporte> getTransportesResult
        {
            get
            {
                return _getTransportesResult;
            }
            set
            {
                if (!object.Equals(_getTransportesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTransportesResult", NewValue = value, OldValue = _getTransportesResult };
                    _getTransportesResult = value;
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
            var findSupermarketDbGetTransportesResult = await FindSupermarketDb.GetTransportes(new Query() { Expand = "Vium" });
            getTransportesResult = findSupermarketDbGetTransportesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTransporte>("Add Transporte", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(FindSupermarket.Models.FindSupermarketDb.Transporte args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTransporte>("Edit Transporte", new Dictionary<string, object>() { {"idt", args.idt} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var findSupermarketDbDeleteTransporteResult = await FindSupermarketDb.DeleteTransporte(data.idt);
                    if (findSupermarketDbDeleteTransporteResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception findSupermarketDbDeleteTransporteException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Transporte" });
            }
        }
    }
}
