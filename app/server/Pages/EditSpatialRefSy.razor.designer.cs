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
    public partial class EditSpatialRefSyComponent : ComponentBase
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

        [Parameter]
        public dynamic srid { get; set; }

        FindSupermarket.Models.FindSupermarketDb.SpatialRefSy _spatialrefsy;
        protected FindSupermarket.Models.FindSupermarketDb.SpatialRefSy spatialrefsy
        {
            get
            {
                return _spatialrefsy;
            }
            set
            {
                if (!object.Equals(_spatialrefsy, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "spatialrefsy", NewValue = value, OldValue = _spatialrefsy };
                    _spatialrefsy = value;
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
            var findSupermarketDbGetSpatialRefSyBysridResult = await FindSupermarketDb.GetSpatialRefSyBysrid(srid);
            spatialrefsy = findSupermarketDbGetSpatialRefSyBysridResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(FindSupermarket.Models.FindSupermarketDb.SpatialRefSy args)
        {
            try
            {
                var findSupermarketDbUpdateSpatialRefSyResult = await FindSupermarketDb.UpdateSpatialRefSy(srid, spatialrefsy);
                DialogService.Close(spatialrefsy);
            }
            catch (System.Exception findSupermarketDbUpdateSpatialRefSyException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update SpatialRefSy" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
