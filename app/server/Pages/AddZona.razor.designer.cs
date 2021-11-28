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
    public partial class AddZonaComponent : ComponentBase
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

        FindSupermarket.Models.FindSupermarketDb.Zona _zona;
        protected FindSupermarket.Models.FindSupermarketDb.Zona zona
        {
            get
            {
                return _zona;
            }
            set
            {
                if (!object.Equals(_zona, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "zona", NewValue = value, OldValue = _zona };
                    _zona = value;
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
            zona = new FindSupermarket.Models.FindSupermarketDb.Zona(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(FindSupermarket.Models.FindSupermarketDb.Zona args)
        {
            try
            {
                var findSupermarketDbCreateZonaResult = await FindSupermarketDb.CreateZona(zona);
                DialogService.Close(zona);
            }
            catch (System.Exception findSupermarketDbCreateZonaException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Zona!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
