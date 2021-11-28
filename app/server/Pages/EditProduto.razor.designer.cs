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
    public partial class EditProdutoComponent : ComponentBase
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
        public dynamic idp { get; set; }

        FindSupermarket.Models.FindSupermarketDb.Produto _produto;
        protected FindSupermarket.Models.FindSupermarketDb.Produto produto
        {
            get
            {
                return _produto;
            }
            set
            {
                if (!object.Equals(_produto, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "produto", NewValue = value, OldValue = _produto };
                    _produto = value;
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var findSupermarketDbGetProdutoByidpResult = await FindSupermarketDb.GetProdutoByidp(idp);
            produto = findSupermarketDbGetProdutoByidpResult;

            var findSupermarketDbGetSupermercadosResult = await FindSupermarketDb.GetSupermercados();
            getSupermercadosResult = findSupermarketDbGetSupermercadosResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(FindSupermarket.Models.FindSupermarketDb.Produto args)
        {
            try
            {
                var findSupermarketDbUpdateProdutoResult = await FindSupermarketDb.UpdateProduto(idp, produto);
                DialogService.Close(produto);
            }
            catch (System.Exception findSupermarketDbUpdateProdutoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Produto" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
