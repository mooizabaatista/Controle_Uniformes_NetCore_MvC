#pragma checksum "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb18e4a2c7cc134590d90d5a23b160bb6c7ab179"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fornecedores_RelatorioEntregasPDF), @"mvc.1.0.view", @"/Views/Fornecedores/RelatorioEntregasPDF.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\_ViewImports.cshtml"
using Requisicao_RSS.WebUi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\_ViewImports.cshtml"
using Requisicao_RSS.WebUi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb18e4a2c7cc134590d90d5a23b160bb6c7ab179", @"/Views/Fornecedores/RelatorioEntregasPDF.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61a06fe337c209599986bc332774917a82fa35ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Fornecedores_RelatorioEntregasPDF : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Requisicao_RSS.Application.DTOs.EntregaMaterialDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:150px;margin-top:10px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
  
    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb18e4a2c7cc134590d90d5a23b160bb6c7ab1795658", async() => {
                WriteLiteral("\r\n    <title>Relatório de Entregas</title>\r\n    <meta http-equiv=\"content-type\" content=\"text/html;charset=UTF-8\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bb18e4a2c7cc134590d90d5a23b160bb6c7ab1796044", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb18e4a2c7cc134590d90d5a23b160bb6c7ab1797926", async() => {
                WriteLiteral("\r\n\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-6\">\r\n            <br />\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bb18e4a2c7cc134590d90d5a23b160bb6c7ab1798286", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-12 ml-3 mt-3 text-center\">\r\n            <h4>Relatório de entrega de materiais</h4>\r\n            <br />\r\n            <h5><strong>");
#nullable restore
#line 28 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                   Write(ViewData["NomeFornecedor"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong></h5>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-12 text-center mt-3 \">\r\n            <span style=\"font-size:1.2em;\">\r\n                Período: &nbsp; <strong>");
#nullable restore
#line 35 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                                   Write(ViewData["DataInicio"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" à ");
#nullable restore
#line 35 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                                                             Write(ViewData["DataFim"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n            </span>\r\n        </div>\r\n    </div>\r\n    <br /><br />\r\n\r\n\r\n");
#nullable restore
#line 42 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <table class=\"table table-bordered table-sm text-center\">\r\n            <thead>\r\n                <tr>\r\n                    <th>Data</th>\r\n                    <th>Nome</th>\r\n                    <th>Tipo</th>\r\n");
#nullable restore
#line 50 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                     if (item.Tipo != "Luva")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <th>Camisetas</th>\r\n                        <th>Calças</th>\r\n");
#nullable restore
#line 54 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                     if (item.QuantidadeLuvas != 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <th>Luvas</th>\r\n");
#nullable restore
#line 58 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                     if (item.Divergencia == "Sim")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <th style=\"color:red;font-weight:700;\">Divergência</th>\r\n");
#nullable restore
#line 63 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tr>\r\n            </thead>\r\n            <tbody>\r\n                <tr>\r\n                    <td>");
#nullable restore
#line 68 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Data));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 69 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NomeFornecedor));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 70 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                   Write(item.Tipo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 71 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                     if (item.Tipo != "Luva")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>");
#nullable restore
#line 73 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                       Write(item.QuantidadeCamisas);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 74 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                       Write(item.QuantidadeCalcas);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 75 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                     if (item.QuantidadeLuvas != 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>");
#nullable restore
#line 78 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                       Write(item.QuantidadeLuvas);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 79 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                     if (item.Divergencia == "Sim")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td style=\"color:red;\">");
#nullable restore
#line 83 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                                          Write(item.Observacoes);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 84 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tr>\r\n            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 88 "C:\Requisicao_RSS\Requisicao_RSS\Requisicao_RSS.WebUi\Views\Fornecedores\RelatorioEntregasPDF.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n</html>\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Requisicao_RSS.Application.DTOs.EntregaMaterialDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591