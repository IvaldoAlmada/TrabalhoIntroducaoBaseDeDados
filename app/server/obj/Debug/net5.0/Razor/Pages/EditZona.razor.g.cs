#pragma checksum "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e1393ca7e04fc21ebff5433fcabec57f416bb98"
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
#line 5 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
using FindSupermarket.Models.FindSupermarketDb;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/edit-zona/{idz}")]
    public partial class EditZona : FindSupermarket.Pages.EditZonaComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(3, "div");
                __builder2.AddAttribute(4, "class", "row");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTemplateForm<FindSupermarket.Models.FindSupermarketDb.Zona>>(7);
                __builder2.AddAttribute(8, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<FindSupermarket.Models.FindSupermarketDb.Zona>(
#nullable restore
#line 12 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                                                                         zona

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                                                                                          zona != null

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "Submit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<FindSupermarket.Models.FindSupermarketDb.Zona>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<FindSupermarket.Models.FindSupermarketDb.Zona>(this, 
#nullable restore
#line 12 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                                                                                                                  Form0Submit

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder3) => {
                    __builder3.OpenElement(12, "div");
                    __builder3.AddAttribute(13, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(14, "class", "row");
                    __builder3.OpenElement(15, "div");
                    __builder3.AddAttribute(16, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(17);
                    __builder3.AddAttribute(18, "Text", "Idz");
                    __builder3.AddAttribute(19, "Component", "idz");
                    __builder3.AddAttribute(20, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(21, "\n              ");
                    __builder3.OpenElement(22, "div");
                    __builder3.AddAttribute(23, "class", "col-md-9");
                    __Blazor.FindSupermarket.Pages.EditZona.TypeInference.CreateRadzenNumeric_0(__builder3, 24, 25, "display: block; width: 100%", 26, "Idz", 27, 
#nullable restore
#line 20 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                                                                  zona.idz

#line default
#line hidden
#nullable disable
                    , 28, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => zona.idz = __value, zona.idz)), 29, () => zona.idz);
                    __builder3.AddMarkupContent(30, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(31);
                    __builder3.AddAttribute(32, "Component", "Idz");
                    __builder3.AddAttribute(33, "Text", "idz is required");
                    __builder3.AddAttribute(34, "style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(35, "\n            ");
                    __builder3.OpenElement(36, "div");
                    __builder3.AddAttribute(37, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(38, "class", "row");
                    __builder3.OpenElement(39, "div");
                    __builder3.AddAttribute(40, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(41);
                    __builder3.AddAttribute(42, "Text", "Populacao");
                    __builder3.AddAttribute(43, "Component", "populao");
                    __builder3.AddAttribute(44, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(45, "\n              ");
                    __builder3.OpenElement(46, "div");
                    __builder3.AddAttribute(47, "class", "col-md-9");
                    __Blazor.FindSupermarket.Pages.EditZona.TypeInference.CreateRadzenNumeric_1(__builder3, 48, 49, "width: 100%", 50, "Populao", 51, 
#nullable restore
#line 32 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                                                  zona.populao

#line default
#line hidden
#nullable disable
                    , 52, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => zona.populao = __value, zona.populao)), 53, () => zona.populao);
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(54, "\n            ");
                    __builder3.OpenElement(55, "div");
                    __builder3.AddAttribute(56, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(57, "class", "row");
                    __builder3.OpenElement(58, "div");
                    __builder3.AddAttribute(59, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(60);
                    __builder3.AddAttribute(61, "Text", "Name");
                    __builder3.AddAttribute(62, "Component", "name");
                    __builder3.AddAttribute(63, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(64, "\n              ");
                    __builder3.OpenElement(65, "div");
                    __builder3.AddAttribute(66, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(67);
                    __builder3.AddAttribute(68, "style", "width: 100%");
                    __builder3.AddAttribute(69, "Name", "Name");
                    __builder3.AddAttribute(70, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 42 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                                                  zona.name

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(71, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => zona.name = __value, zona.name))));
                    __builder3.AddAttribute(72, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => zona.name));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(73, "\n            ");
                    __builder3.OpenElement(74, "div");
                    __builder3.AddAttribute(75, "class", "row");
                    __builder3.OpenElement(76, "div");
                    __builder3.AddAttribute(77, "class", "col offset-sm-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(78);
                    __builder3.AddAttribute(79, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 48 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                          ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(80, "Icon", "save");
                    __builder3.AddAttribute(81, "Text", "Save");
                    __builder3.AddAttribute(82, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 48 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                                                                                  ButtonStyle.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(83, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(84);
                    __builder3.AddAttribute(85, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 50 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                           ButtonStyle.Light

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(86, "style", "margin-left: 1rem");
                    __builder3.AddAttribute(87, "Text", "Cancel");
                    __builder3.AddAttribute(88, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 50 "C:\Users\ivald\dev\TrabalhoIntroducaoBaseDeDados\app\server\Pages\EditZona.razor"
                                                                                                              Button2Click

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
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
namespace __Blazor.FindSupermarket.Pages.EditZona
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenNumeric_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.String __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenNumeric<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "Name", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateRadzenNumeric_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.String __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenNumeric<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "Name", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
