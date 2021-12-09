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
    public partial class AddConduzComponent : ComponentBase
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

        FindSupermarket.Models.FindSupermarketDb.Conduz _conduz;
        protected FindSupermarket.Models.FindSupermarketDb.Conduz conduz
        {
            get
            {
                return _conduz;
            }
            set
            {
                if (!object.Equals(_conduz, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "conduz", NewValue = value, OldValue = _conduz };
                    _conduz = value;
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
            var findSupermarketDbGetViaResult = await FindSupermarketDb.GetVia();
            getViaResult = findSupermarketDbGetViaResult;

            var findSupermarketDbGetSupermercadosResult = await FindSupermarketDb.GetSupermercados();
            getSupermercadosResult = findSupermarketDbGetSupermercadosResult;

            conduz = new FindSupermarket.Models.FindSupermarketDb.Conduz(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(FindSupermarket.Models.FindSupermarketDb.Conduz args)
        {
            try
            {
                var findSupermarketDbCreateConduzResult = await FindSupermarketDb.CreateConduz(conduz);
                DialogService.Close(conduz);
            }
            catch (System.Exception findSupermarketDbCreateConduzException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Conduz!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
