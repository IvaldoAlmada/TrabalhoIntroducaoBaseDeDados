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
    public partial class GeometryColumnsComponent : ComponentBase
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
        protected RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.GeometryColumn> grid0;

        IEnumerable<FindSupermarket.Models.FindSupermarketDb.GeometryColumn> _getGeometryColumnsResult;
        protected IEnumerable<FindSupermarket.Models.FindSupermarketDb.GeometryColumn> getGeometryColumnsResult
        {
            get
            {
                return _getGeometryColumnsResult;
            }
            set
            {
                if (!object.Equals(_getGeometryColumnsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getGeometryColumnsResult", NewValue = value, OldValue = _getGeometryColumnsResult };
                    _getGeometryColumnsResult = value;
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
            var findSupermarketDbGetGeometryColumnsResult = await FindSupermarketDb.GetGeometryColumns();
            getGeometryColumnsResult = findSupermarketDbGetGeometryColumnsResult;
        }
    }
}
