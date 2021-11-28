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
    public partial class ConduzsComponent : ComponentBase
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
        protected RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.Conduz> grid0;

        IEnumerable<FindSupermarket.Models.FindSupermarketDb.Conduz> _getConduzsResult;
        protected IEnumerable<FindSupermarket.Models.FindSupermarketDb.Conduz> getConduzsResult
        {
            get
            {
                return _getConduzsResult;
            }
            set
            {
                if (!object.Equals(_getConduzsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getConduzsResult", NewValue = value, OldValue = _getConduzsResult };
                    _getConduzsResult = value;
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
            var findSupermarketDbGetConduzsResult = await FindSupermarketDb.GetConduzs(new Query() { Expand = "Supermercado,Vium" });
            getConduzsResult = findSupermarketDbGetConduzsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddConduz>("Add Conduz", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var findSupermarketDbDeleteConduzResult = await FindSupermarketDb.DeleteConduz(data.ids, data.idv);
                    if (findSupermarketDbDeleteConduzResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception findSupermarketDbDeleteConduzException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Conduz" });
            }
        }
    }
}
