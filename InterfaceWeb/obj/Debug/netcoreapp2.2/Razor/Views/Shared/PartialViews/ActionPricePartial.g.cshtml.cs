#pragma checksum "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7606163729366a0c8660b64a2fbc81883e3dd93e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PartialViews_ActionPricePartial), @"mvc.1.0.view", @"/Views/Shared/PartialViews/ActionPricePartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/PartialViews/ActionPricePartial.cshtml", typeof(AspNetCore.Views_Shared_PartialViews_ActionPricePartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7606163729366a0c8660b64a2fbc81883e3dd93e", @"/Views/Shared/PartialViews/ActionPricePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ed713e237dc60e2333c467817d4dde0379866ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PartialViews_ActionPricePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Test_CSN_ENERGY.Models.CatalogBooksViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(56, 17, false);
#line 3 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(73, 24, true);
            WriteLiteral(" = \"CSN ENERGY TEST\"\r\n\r\n");
            EndContext();
#line 5 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
  
    //Récupère le catalogue présent dans le conteur (valide seulement si bien renseigné lors de l'appel des PartialView) (Action/Result)
    var CatalogBooksModel = ViewData["CatalogBooksViewModel"] as CatalogBooksViewModel;

#line default
#line hidden
            BeginContext(331, 140, true);
            WriteLiteral("\r\n\r\n<div class=\"col-sm-12 col-sm-offset-2\">\r\n    <h1>Price</h1>\r\n\r\n    <div class=\"panel panel-default\">\r\n        <div class=\"panel-body\">\r\n");
            EndContext();
#line 16 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
             using (Html.BeginForm("Basket", "Home", FormMethod.Post, new { role = "form" }))
            {

                

#line default
#line hidden
            BeginContext(643, 85, true);
            WriteLiteral("                <div class=\"form-group\" style=\"display: none;\">\r\n                    ");
            EndContext();
            BeginContext(729, 39, false);
#line 21 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
               Write(Html.LabelFor(m => m.SelectedBookNames));

#line default
#line hidden
            EndContext();
            BeginContext(768, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(791, 284, false);
#line 22 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
               Write(Html.DropDownList("selectBooks", new SelectList(Model.Catalog.Select(x => new { Value = x.Name, Text = $"{x.Category.Trim()} - {x.Name.Trim()}", Price = x.Price }), "Value", "Text"), new { @onclick = "listebook_OnClick(this)", @class = "form-control", size = 6, multiple = "simple" }));

#line default
#line hidden
            EndContext();
            BeginContext(1075, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
            BeginContext(1158, 102, true);
            WriteLiteral("                <div class=\"form-group\" style=\"font-size: 14px;height: auto; /*overflow-y: auto;*/\">\r\n");
            EndContext();
#line 27 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                     if (Model.Catalog.Count() > 0)
                    {
                        

#line default
#line hidden
            BeginContext(1389, 229, true);
            WriteLiteral("                        <table class=\"table\">\r\n                            <thead>\r\n                                <tr>\r\n                                    <th style=\"padding: 0.5rem;\">\r\n                                        ");
            EndContext();
            BeginContext(1619, 60, false);
#line 34 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Catalog.First().Category));

#line default
#line hidden
            EndContext();
            BeginContext(1679, 152, true);
            WriteLiteral("\r\n                                    </th>\r\n                                    <th style=\"padding: 0.5rem;\">\r\n                                        ");
            EndContext();
            BeginContext(1832, 56, false);
#line 37 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Catalog.First().Name));

#line default
#line hidden
            EndContext();
            BeginContext(1888, 171, true);
            WriteLiteral("\r\n                                    </th>\r\n                                    <th style=\"text-align: right; padding: 0.5rem;\">\r\n                                        ");
            EndContext();
            BeginContext(2060, 60, false);
#line 40 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Catalog.First().Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(2120, 171, true);
            WriteLiteral("\r\n                                    </th>\r\n                                    <th style=\"text-align: right; padding: 0.5rem;\">\r\n                                        ");
            EndContext();
            BeginContext(2292, 57, false);
#line 43 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Catalog.First().Price));

#line default
#line hidden
            EndContext();
            BeginContext(2349, 405, true);
            WriteLiteral(@"
                                    </th>
                                    <th style=""text-align: right; padding: 0.5rem;"">
                                        Qt.
                                    </th>
                                    <th style=""padding: 0.5rem;""></th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 52 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                  
                                    var index = 0;
                                

#line default
#line hidden
            BeginContext(2877, 32, true);
            WriteLiteral("                                ");
            EndContext();
#line 55 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                 foreach (var item in Model.Catalog)
                                {
                                    var idx = "index" + index++;

#line default
#line hidden
            BeginContext(3048, 223, true);
            WriteLiteral("                                    <tr>\r\n                                        <td class=\"alert alert-light\" style=\"vertical-align: middle;\">\r\n                                            <span class=\"font-weight-normal\">");
            EndContext();
            BeginContext(3272, 77, false);
#line 60 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                        Write(Html.DisplayFor(modelItem => item.Category, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(3349, 237, true);
            WriteLiteral("</span>\r\n                                        </td>\r\n                                        <td class=\"alert alert-light\" style=\"vertical-align: middle;\">\r\n                                            <span class=\"font-weight-bolder\">");
            EndContext();
            BeginContext(3587, 73, false);
#line 63 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                        Write(Html.DisplayFor(modelItem => item.Name, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(3660, 256, true);
            WriteLiteral(@"</span>
                                        </td>
                                        <td class=""alert alert-light"" style=""vertical-align: middle; text-align: right;"">
                                            <span class=""font-weight-normal"">");
            EndContext();
            BeginContext(3917, 77, false);
#line 66 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                        Write(Html.DisplayFor(modelItem => item.Quantity, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(3994, 254, true);
            WriteLiteral("</span>\r\n                                        </td>\r\n                                        <td class=\"alert alert-light\" style=\"vertical-align: middle; text-align: right;\">\r\n                                            <span class=\"font-weight-bold\">");
            EndContext();
            BeginContext(4249, 74, false);
#line 69 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                      Write(Html.DisplayFor(modelItem => item.Price, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(4323, 58, true);
            WriteLiteral("</span>\r\n                                        </td>\r\n\r\n");
            EndContext();
            BeginContext(4452, 191, true);
            WriteLiteral("                                        <td class=\"alert alert-heading\" style=\"vertical-align: middle; text-align: right; font-size: 14px;\">\r\n                                            <span");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4643, "\"", 4652, 1);
#line 74 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
WriteAttributeValue("", 4648, idx, 4648, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4653, 12, true);
            WriteLiteral(" data-prix=\"");
            EndContext();
            BeginContext(4666, 10, false);
#line 74 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                  Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(4676, 93, true);
            WriteLiteral("\" class=\"qClass font-weight-bold\">0</span>\r\n                                        </td>\r\n\r\n");
            EndContext();
            BeginContext(4840, 469, true);
            WriteLiteral(@"                                        <td style=""vertical-align: middle; text-align:center; border-top: 0px solid #dee2e6;"">
                                            <div class=""form-group"" style=""margin-bottom: 0;"">
                                                <input class=""btnExecute btn btn-danger"" style=""font-size: 12px; font-weight: bold; width: 70px; padding-top: 2px; padding-bottom: 2px; margin-bottom: 1px;"" type=""button"" value=""Retirer"" data-idx=""");
            EndContext();
            BeginContext(5310, 3, false);
#line 80 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                                                                                                                                                                                                Write(idx);

#line default
#line hidden
            EndContext();
            BeginContext(5313, 13, true);
            WriteLiteral("\" data-name=\"");
            EndContext();
            BeginContext(5327, 9, false);
#line 80 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                                                                                                                                                                                                                 Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(5336, 252, true);
            WriteLiteral("\" />\r\n                                                <input class=\"btnExecute btn btn-success\" style=\"font-size: 12px; font-weight: bold; width: 70px; padding-top: 2px; padding-bottom: 2px; margin-bottom: 1px;\" type=\"button\" value=\"Ajouter\" data-idx=\"");
            EndContext();
            BeginContext(5589, 3, false);
#line 81 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                                                                                                                                                                                                 Write(idx);

#line default
#line hidden
            EndContext();
            BeginContext(5592, 13, true);
            WriteLiteral("\" data-name=\"");
            EndContext();
            BeginContext(5606, 9, false);
#line 81 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                                                                                                                                                                                                                                                  Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(5615, 148, true);
            WriteLiteral("\" />\r\n                                            </div>\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 85 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                                }

#line default
#line hidden
            BeginContext(5798, 428, true);
            WriteLiteral(@"                                <tr style=""border-top: 2px solid #dee2e6; font-size: 14px;"">
                                    <td class=""alert alert-light"" style=""vertical-align: middle;""></td>
                                    <td class=""alert alert-light"" style=""vertical-align: middle;""></td>
                                    <td class=""alert alert-light"" style=""vertical-align: middle; text-align: right;""></td>
");
            EndContext();
            BeginContext(6292, 290, true);
            WriteLiteral(@"                                    <td colspan=""1"" id=""TdPrixTotal"" class=""alert alert-dark"" style=""vertical-align: middle; text-align: right;"">
                                        <span id=""SpPrixTotal"" class=""font-weight-bold"">0</span>
                                    </td>

");
            EndContext();
            BeginContext(6649, 508, true);
            WriteLiteral(@"                                    <td colspan=""1"" id=""TdCountTotal"" class=""alert alert-dark"" style=""vertical-align: middle; text-align: right;"">
                                        <span id=""SpCountTotal"" class=""font-weight-bold"">0</span>
                                    </td>
                                    <td class=""alert alert-light"" style=""vertical-align: middle;""></td>
                                </tr>

                            </tbody>
                        </table>
");
            EndContext();
#line 104 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                    }

#line default
#line hidden
            BeginContext(7180, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
            BeginContext(7208, 21, true);
            WriteLiteral("                <p>\r\n");
            EndContext();
            BeginContext(7300, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(7321, 194, false);
#line 110 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
               Write(Html.TextArea("SelectedBookNames", "", 4, 45, new { onchange = "selectedBookName_Change()", placeholder = "La sélection...", @class = "form-control", style = "font-size: small; display: none" }));

#line default
#line hidden
            EndContext();
            BeginContext(7515, 120, true);
            WriteLiteral("\r\n                </p>\r\n                <button type=\"submit\" class=\"btn btn-primary\" style=\"\">Calcul du Prix</button>\r\n");
            EndContext();
#line 113 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
            }

#line default
#line hidden
            BeginContext(7650, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 115 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
             if (Model.Price > -1)
            {
                var colorAlert = "alert-success";
                var style = "padding: 0; margin-top: 10px; margin-bottom: 10px; line-height: 0;";

                

#line default
#line hidden
#line 120 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                 if (Model.Price == 0)
                {
                    colorAlert = "alert-danger";
                }

#line default
#line hidden
            BeginContext(7985, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 8005, "\"", 8053, 4);
            WriteAttributeValue("", 8013, "text-left", 8013, 9, true);
            WriteAttributeValue(" ", 8022, "text-sm-left", 8023, 13, true);
            WriteAttributeValue(" ", 8035, "alert", 8036, 6, true);
#line 125 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
WriteAttributeValue(" ", 8041, colorAlert, 8042, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("style", " style=\"", 8054, "\"", 8068, 1);
#line 125 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
WriteAttributeValue("", 8062, style, 8062, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8069, 26, true);
            WriteLiteral(">\r\n                    <p>");
            EndContext();
            BeginContext(8096, 65, false);
#line 126 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
                  Write(await Html.PartialAsync("PartialViews/ResultPricePartial", Model));

#line default
#line hidden
            EndContext();
            BeginContext(8161, 30, true);
            WriteLiteral("</p>\r\n                </div>\r\n");
            EndContext();
#line 128 "F:\Sources NET\Espace de travail\CSN ENERGY\InterfaceWeb\Views\Shared\PartialViews\ActionPricePartial.cshtml"
            }

#line default
#line hidden
            BeginContext(8206, 3422, true);
            WriteLiteral(@"        </div>
    </div>
</div>

<script type=""text/javascript"">
    var arrBookSelected = [];
    var intervalId;

    function numberPlus(idCount, bookName) {
        var idxCount = parseInt($('#' + idCount).html());
        idxCount++;
        $('#' + idCount).html(idxCount);

        redefineArrayBooks(bookName, idxCount);
    };

    function numberMoins(idCount, bookName) {
        var idxCount = parseInt($('#' + idCount).html());

        if (idxCount <= 0)
            idxCount = 1;

        idxCount--;
        $('#' + idCount).html(idxCount);

        redefineArrayBooks(bookName, idxCount);
    };

    /**
     * Permet de redéfinir la liste des livres sélectionnés dans le modèle utilisé
     * bookName : le titre du livre
     * count : nombre du titre
     */
    function redefineArrayBooks(bookName, count) {
        val = $(""#SelectedBookNames"").val();
        arrBookSelected = val !== """" ? val.split("", "") : [];

        arrBookSelected = $.grep(arrBookSelected");
            WriteLiteral(@", function (e) {
            return e != bookName;
        });

        if (count > 0) {
            for (var i = 0; i < count; i++) {
                arrBookSelected.push(bookName);
            }
        }

        $(""#SelectedBookNames"").val(arrBookSelected.join(', '));
        //total des sélections
        $('#SpCountTotal').html(arrBookSelected.length);

        calculTotal();
    };

    /**
     * Format le nombre avec son signe
     * prixCalcule : le prix
     * idcont : le conteneur qui affichera le résultat
     */
    function formatMoney(prixCalcule, idcont) {
        //permet d'obtenir le signe
        var formatter = new Intl.NumberFormat('fr-FR', {
            style: 'currency',
            currency: 'EUR',
            minimumFractionDigits: 2,
        });

        var prixTotal = formatter.format(prixCalcule);
        document.getElementById(idcont).innerHTML = prixTotal;
    }

    /**
     * Permet de calculer dynamiquement la quantité sélectionné avec le ");
            WriteLiteral(@"prix (sans remise)
     * */
    function calculTotal() {
        //prix total sans remise
        var prixCalcule = 0;

        //prix total sans remise
        $(""span"").each(function (i) {
            if ($(this).hasClass('qClass')) {
                var prix = parseFloat($(this).data('prix'));
                var qt = parseInt($(this).text());
                prixCalcule += prix * qt;
            }
        });

        formatMoney(prixCalcule, 'SpPrixTotal');
    }

    /**
    * Ajout dans le tableau la sélection faite dans la combo
    * */
    function listebook_OnClick(ddlObject) {
        //Selected value de la dropdownlist
        var selectedValue = $(ddlObject).val();
        //Selected text de la dropdownlist
        var selectedText = $(ddlObject).children(""option:selected"").html();

        arrBookSelected.push(selectedValue);
        $(""#SelectedBookNames"").val(arrBookSelected.join(', '));
        //permettra de faire x sélection consécutif
        $('#selectBooks");
            WriteLiteral(@"').val(null);
    };

    /**
     * redéfinition du tableau si suppression manuel dans le textbox
     * */
    function selectedBookName_Change() {
        val = $(""#SelectedBookNames"").val();
        arrBookSelected = val !== """" ? $(""#SelectedBookNames"").val().split("", "") : [];
    };

    formatMoney(0, 'SpPrixTotal');

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
