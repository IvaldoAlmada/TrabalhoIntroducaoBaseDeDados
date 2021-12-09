#pragma checksum "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01a86551a5d28045562d712f79236d84c18b2e7a"
// <auto-generated/>
#pragma warning disable 1591
namespace FindSupermarket.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\_Imports.razor"
using FindSupermarket.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
using FindSupermarket.Models.FindSupermarketDb;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/geometry-columns")]
    public partial class GeometryColumns : FindSupermarket.Pages.GeometryColumnsComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(3);
                __builder2.AddAttribute(4, "Size", "H1");
                __builder2.AddAttribute(5, "Text", "Geometry Columns");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\n    ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(11);
                __builder2.AddAttribute(12, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 14 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
                                                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 14 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
                                                                       Radzen.FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(14, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 14 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
                                                                                                                true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 14 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
                                                                                                                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(
#nullable restore
#line 14 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
                                                                                                                                                 getGeometryColumnsResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(17, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(18);
                    __builder3.AddAttribute(19, "Property", "f_table_catalog");
                    __builder3.AddAttribute(20, "Title", "F Table Catalog");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(21, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(22);
                    __builder3.AddAttribute(23, "Property", "f_table_schema");
                    __builder3.AddAttribute(24, "Title", "F Table Schema");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(25, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(26);
                    __builder3.AddAttribute(27, "Property", "f_table_name");
                    __builder3.AddAttribute(28, "Title", "F Table Name");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(29, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(30);
                    __builder3.AddAttribute(31, "Property", "f_geometry_column");
                    __builder3.AddAttribute(32, "Title", "F Geometry Column");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(33, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(34);
                    __builder3.AddAttribute(35, "Property", "coord_dimension");
                    __builder3.AddAttribute(36, "Title", "Coord Dimension");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(37, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(38);
                    __builder3.AddAttribute(39, "Property", "srid");
                    __builder3.AddAttribute(40, "Title", "Srid");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(41, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>>(42);
                    __builder3.AddAttribute(43, "Property", "type");
                    __builder3.AddAttribute(44, "Title", "Type");
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(45, (__value) => {
#nullable restore
#line 14 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\GeometryColumns.razor"
                              grid0 = (Radzen.Blazor.RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.GeometryColumn>)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
