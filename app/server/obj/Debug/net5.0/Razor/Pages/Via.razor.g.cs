#pragma checksum "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31b7828fa1dce2688bba0ca0dc281c10238c7bde"
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
#line 5 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
using FindSupermarket.Models.FindSupermarketDb;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/via")]
    public partial class Via : FindSupermarket.Pages.ViaComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(3);
                __builder2.AddAttribute(4, "Size", "H1");
                __builder2.AddAttribute(5, "Text", "Via");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\n    ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(11);
                __builder2.AddAttribute(12, "Icon", "add_circle_outline");
                __builder2.AddAttribute(13, "style", "margin-bottom: 10px");
                __builder2.AddAttribute(14, "Text", "Add");
                __builder2.AddAttribute(15, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                               Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.Vium>>(17);
                __builder2.AddAttribute(18, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 16 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 16 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                       Radzen.FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 16 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                                true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 16 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<FindSupermarket.Models.FindSupermarketDb.Vium>>(
#nullable restore
#line 16 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                                                                 getViaResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "RowSelect", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<FindSupermarket.Models.FindSupermarketDb.Vium>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<FindSupermarket.Models.FindSupermarketDb.Vium>(this, 
#nullable restore
#line 16 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                                                                                                                                                 Grid0RowSelect

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(24, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.Vium>>(25);
                    __builder3.AddAttribute(26, "Property", "idv");
                    __builder3.AddAttribute(27, "Title", "Idv");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(28, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.Vium>>(29);
                    __builder3.AddAttribute(30, "Property", "tamanho");
                    __builder3.AddAttribute(31, "Title", "Tamanho");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(32, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.Vium>>(33);
                    __builder3.AddAttribute(34, "Property", "nome");
                    __builder3.AddAttribute(35, "Title", "Nome");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(36, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<FindSupermarket.Models.FindSupermarketDb.Vium>>(37);
                    __builder3.AddAttribute(38, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 24 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                    false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(39, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 24 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                                     false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(40, "Width", "70px");
                    __builder3.AddAttribute(41, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 24 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                                                                    TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(42, "Template", (Microsoft.AspNetCore.Components.RenderFragment<FindSupermarket.Models.FindSupermarketDb.Vium>)((findSupermarketModelsFindSupermarketDbVium) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(43);
                        __builder4.AddAttribute(44, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 26 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(45, "Icon", "close");
                        __builder4.AddAttribute(46, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 26 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(47, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                             (args) =>GridDeleteButtonClick(args, findSupermarketModelsFindSupermarketDbVium)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(48, "onclick", 
#nullable restore
#line 26 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                                                                                                                                                                                                                          true

#line default
#line hidden
#nullable disable
                        );
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(49, (__value) => {
#nullable restore
#line 16 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\Via.razor"
                              grid0 = (Radzen.Blazor.RadzenDataGrid<FindSupermarket.Models.FindSupermarketDb.Vium>)__value;

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
