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
    public partial class EditSupermercadoComponent : ComponentBase
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
        public dynamic ids { get; set; }

        FindSupermarket.Models.FindSupermarketDb.Supermercado _supermercado;
        protected FindSupermarket.Models.FindSupermarketDb.Supermercado supermercado
        {
            get
            {
                return _supermercado;
            }
            set
            {
                if (!object.Equals(_supermercado, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "supermercado", NewValue = value, OldValue = _supermercado };
                    _supermercado = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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
            var findSupermarketDbGetSupermercadoByidsResult = await FindSupermarketDb.GetSupermercadoByids(ids);
            supermercado = findSupermarketDbGetSupermercadoByidsResult;

            var findSupermarketDbGetZonasResult = await FindSupermarketDb.GetZonas();
            getZonasResult = findSupermarketDbGetZonasResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(FindSupermarket.Models.FindSupermarketDb.Supermercado args)
        {
            try
            {
                var findSupermarketDbUpdateSupermercadoResult = await FindSupermarketDb.UpdateSupermercado(ids, supermercado);
                DialogService.Close(supermercado);
            }
            catch (System.Exception findSupermarketDbUpdateSupermercadoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Supermercado" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
