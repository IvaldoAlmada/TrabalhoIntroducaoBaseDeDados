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
    public partial class EditTransporteComponent : ComponentBase
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
        public dynamic idt { get; set; }

        FindSupermarket.Models.FindSupermarketDb.Transporte _transporte;
        protected FindSupermarket.Models.FindSupermarketDb.Transporte transporte
        {
            get
            {
                return _transporte;
            }
            set
            {
                if (!object.Equals(_transporte, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "transporte", NewValue = value, OldValue = _transporte };
                    _transporte = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<FindSupermarket.Models.FindSupermarketDb.Vium> _getViaResult;
        protected IEnumerable<FindSupermarket.Models.FindSupermarketDb.Vium> getViaResult
        {
            get
            {
                return _getViaResult;
            }
            set
            {
                if (!object.Equals(_getViaResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getViaResult", NewValue = value, OldValue = _getViaResult };
                    _getViaResult = value;
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
            var findSupermarketDbGetTransporteByidtResult = await FindSupermarketDb.GetTransporteByidt(idt);
            transporte = findSupermarketDbGetTransporteByidtResult;

            var findSupermarketDbGetViaResult = await FindSupermarketDb.GetVia();
            getViaResult = findSupermarketDbGetViaResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(FindSupermarket.Models.FindSupermarketDb.Transporte args)
        {
            try
            {
                var findSupermarketDbUpdateTransporteResult = await FindSupermarketDb.UpdateTransporte(idt, transporte);
                DialogService.Close(transporte);
            }
            catch (System.Exception findSupermarketDbUpdateTransporteException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Transporte" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
