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
    public partial class ZonasComponent : ComponentBase
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
        protected RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.Zona> grid0;

        IEnumerable<FindSupermarket.Models.FindSupermarketDb.Zona> _getZonasResult;
        protected IEnumerable<FindSupermarket.Models.FindSupermarketDb.Zona> getZonasResult
        {
            get
            {
                return _getZonasResult;
            }
            set
            {
                if (!object.Equals(_getZonasResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getZonasResult", NewValue = value, OldValue = _getZonasResult };
                    _getZonasResult = value;
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
            var findSupermarketDbGetZonasResult = await FindSupermarketDb.GetZonas();
            getZonasResult = findSupermarketDbGetZonasResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddZona>("Add Zona", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(FindSupermarket.Models.FindSupermarketDb.Zona args)
        {
            var dialogResult = await DialogService.OpenAsync<EditZona>("Edit Zona", new Dictionary<string, object>() { {"idz", args.idz} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var findSupermarketDbDeleteZonaResult = await FindSupermarketDb.DeleteZona(data.idz);
                    if (findSupermarketDbDeleteZonaResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception findSupermarketDbDeleteZonaException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Zona" });
            }
        }
    }
}
