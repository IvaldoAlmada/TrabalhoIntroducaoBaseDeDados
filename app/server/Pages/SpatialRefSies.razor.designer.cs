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
    public partial class SpatialRefSiesComponent : ComponentBase
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
        protected RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.SpatialRefSy> grid0;

        IEnumerable<FindSupermarket.Models.FindSupermarketDb.SpatialRefSy> _getSpatialRefSiesResult;
        protected IEnumerable<FindSupermarket.Models.FindSupermarketDb.SpatialRefSy> getSpatialRefSiesResult
        {
            get
            {
                return _getSpatialRefSiesResult;
            }
            set
            {
                if (!object.Equals(_getSpatialRefSiesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSpatialRefSiesResult", NewValue = value, OldValue = _getSpatialRefSiesResult };
                    _getSpatialRefSiesResult = value;
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
            var findSupermarketDbGetSpatialRefSiesResult = await FindSupermarketDb.GetSpatialRefSies();
            getSpatialRefSiesResult = findSupermarketDbGetSpatialRefSiesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSpatialRefSy>("Add Spatial Ref Sy", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(FindSupermarket.Models.FindSupermarketDb.SpatialRefSy args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSpatialRefSy>("Edit Spatial Ref Sy", new Dictionary<string, object>() { {"srid", args.srid} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var findSupermarketDbDeleteSpatialRefSyResult = await FindSupermarketDb.DeleteSpatialRefSy(data.srid);
                    if (findSupermarketDbDeleteSpatialRefSyResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception findSupermarketDbDeleteSpatialRefSyException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete SpatialRefSy" });
            }
        }
    }
}
