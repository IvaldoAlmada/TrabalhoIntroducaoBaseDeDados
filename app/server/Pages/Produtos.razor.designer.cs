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
    public partial class ProdutosComponent : ComponentBase
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
        protected RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.Produto> grid0;

        IEnumerable<FindSupermarket.Models.FindSupermarketDb.Produto> _getProdutosResult;
        protected IEnumerable<FindSupermarket.Models.FindSupermarketDb.Produto> getProdutosResult
        {
            get
            {
                return _getProdutosResult;
            }
            set
            {
                if (!object.Equals(_getProdutosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProdutosResult", NewValue = value, OldValue = _getProdutosResult };
                    _getProdutosResult = value;
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
            var findSupermarketDbGetProdutosResult = await FindSupermarketDb.GetProdutos(new Query() { Expand = "Supermercado" });
            getProdutosResult = findSupermarketDbGetProdutosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddProduto>("Add Produto", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(FindSupermarket.Models.FindSupermarketDb.Produto args)
        {
            var dialogResult = await DialogService.OpenAsync<EditProduto>("Edit Produto", new Dictionary<string, object>() { {"idp", args.idp} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var findSupermarketDbDeleteProdutoResult = await FindSupermarketDb.DeleteProduto(data.idp);
                    if (findSupermarketDbDeleteProdutoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception findSupermarketDbDeleteProdutoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Produto" });
            }
        }
    }
}
