#pragma checksum "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ResultPricePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "471e4a430adcb055a08e235f997fa8e5366847bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PartialViews_ResultPricePartial), @"mvc.1.0.view", @"/Views/Shared/PartialViews/ResultPricePartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/PartialViews/ResultPricePartial.cshtml", typeof(AspNetCore.Views_Shared_PartialViews_ResultPricePartial))]
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
#line 1 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\_ViewImports.cshtml"
using Test_CSN_ENERGY;

#line default
#line hidden
#line 2 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\_ViewImports.cshtml"
using Test_CSN_ENERGY.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"471e4a430adcb055a08e235f997fa8e5366847bd", @"/Views/Shared/PartialViews/ResultPricePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ed713e237dc60e2333c467817d4dde0379866ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PartialViews_ResultPricePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Test_CSN_ENERGY.Models.CatalogBooksViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ResultPricePartial.cshtml"
  
    ViewData["Title"] = "CSN ENERGY TEST";

#line default
#line hidden
            BeginContext(106, 169, true);
            WriteLiteral("\r\n<div class=\"col-sm-6 col-sm-offset-2\">\r\n    <div class=\"panel panel-default\">\r\n        <div class=\"panel-body\">\r\n            <div class=\"form-group\">\r\n                ");
            EndContext();
            BeginContext(276, 27, false);
#line 11 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ResultPricePartial.cshtml"
           Write(Html.LabelFor(m => m.Price));

#line default
#line hidden
            EndContext();
            BeginContext(303, 49, true);
            WriteLiteral("\r\n                <span class=\"font-weight-bold\">");
            EndContext();
            BeginContext(353, 63, false);
#line 12 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ResultPricePartial.cshtml"
                                          Write(Html.DisplayFor(m => m.Price, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(416, 278, true);
            WriteLiteral(@"</span>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    function erase() {
        arrBookSelected = [];
        document.getElementById('SelectedBookNames').value = arrBookSelected.join(', ');
    };
    erase();
</script>
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Test_CSN_ENERGY.Models.CatalogBooksViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
