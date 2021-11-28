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
    public partial class EditViumComponent : ComponentBase
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
        public dynamic idv { get; set; }

        FindSupermarket.Models.FindSupermarketDb.Vium _vium;
        protected FindSupermarket.Models.FindSupermarketDb.Vium vium
        {
            get
            {
                return _vium;
            }
            set
            {
                if (!object.Equals(_vium, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "vium", NewValue = value, OldValue = _vium };
                    _vium = value;
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
            var findSupermarketDbGetViumByidvResult = await FindSupermarketDb.GetViumByidv(idv);
            vium = findSupermarketDbGetViumByidvResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(FindSupermarket.Models.FindSupermarketDb.Vium args)
        {
            try
            {
                var findSupermarketDbUpdateViumResult = await FindSupermarketDb.UpdateVium(idv, vium);
                DialogService.Close(vium);
            }
            catch (System.Exception findSupermarketDbUpdateViumException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Vium" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
