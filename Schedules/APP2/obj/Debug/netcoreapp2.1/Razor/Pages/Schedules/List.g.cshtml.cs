#pragma checksum "D:\Dev\Schedules2\Schedules\Schedules\APP2\Pages\Schedules\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d75e52a45dec3226a5323b3f5380dee6d3a6aaeb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MVC.Pages.Schedules.Pages_Schedules_List), @"mvc.1.0.razor-page", @"/Pages/Schedules/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Schedules/List.cshtml", typeof(MVC.Pages.Schedules.Pages_Schedules_List), null)]
namespace MVC.Pages.Schedules
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75e52a45dec3226a5323b3f5380dee6d3a6aaeb", @"/Pages/Schedules/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fb963481a43f0c8c138e62415de7665efee81cd", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Schedules_List : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 838, true);
            WriteLiteral(@"
<main>
    <div class=""form-row top-buffer"">
        <div class=""row"">
            <div class=""col-sm-6 col-md-6 col-xs-6 form-group"">
                <label for=""ID"">Nombre Paciente :</label>
                <div class=""control-group"">
                    <select id=""patient"" class=""demo-default"" placeholder=""Escriba nombre""></select>
                </div>
            </div>
            <div class=""col-sm-6 col-md-6 col-xs-6 form-group"">

            </div>
        </div>
        <div class=""row"">
            <div class=""col-sm-12 col-md-12 col-xs-12 form-group"">
                <button type=""button"" class=""btn btn-primary"" id=""btnSearch"">Buscar Cita</button>
            </div>
        </div>
        <div class=""row top-buffer"">
            <div id=""jsGrid""></div>
        </div>
    </div>
</main>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVC.Pages.Datebooks.ListModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MVC.Pages.Datebooks.ListModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MVC.Pages.Datebooks.ListModel>)PageContext?.ViewData;
        public MVC.Pages.Datebooks.ListModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
