#pragma checksum "D:\Dev\Schedules2\Schedules\Schedules\APP2\Pages\PatientDates.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94fedebe09d37fe482f866842bc7bcbb6ce082d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MVC.Pages.Pages_PatientDates), @"mvc.1.0.view", @"/Pages/PatientDates.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/PatientDates.cshtml", typeof(MVC.Pages.Pages_PatientDates))]
namespace MVC.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Dev\Schedules2\Schedules\Schedules\APP2\Pages\_ViewImports.cshtml"
using MVC;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94fedebe09d37fe482f866842bc7bcbb6ce082d4", @"/Pages/PatientDates.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fb963481a43f0c8c138e62415de7665efee81cd", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PatientDates : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Dev\Schedules2\Schedules\Schedules\APP2\Pages\PatientDates.cshtml"
  
    ViewData["Title"] = "PatientDates";

#line default
#line hidden
            BeginContext(48, 817, true);
            WriteLiteral(@"

<header>
    <div class=""jumbotron jumbotron-fluid"">
        <div class=""container"">
            <h2 class=""display-4"">Test .Net Developer </h2>
            <p class=""lead"">David Gómez</p>
        </div>
    </div>
</header>

<main>
    <div class=""form-row top-buffer"">
        <div class=""form-group col-md-2"">
            <label for=""ID"">ID EMPLOYEE:</label>
        </div>
        <div class=""form-group col-md-2"">
            <input id=""idEmployee"" class=""form-control form-control-lg"" type=""number"" placeholder=""Insert the ID"">
        </div>
        <div class=""form-group col-md-3"">
            <button type=""button"" class=""btn btn-primary"" id=""btnSearch"">Search</button>
        </div>
    </div>
    <div class=""row top-buffer"">
        <div id=""jsGrid""></div>
    </div>
</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
