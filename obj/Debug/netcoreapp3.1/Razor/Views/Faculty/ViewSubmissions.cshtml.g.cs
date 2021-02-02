#pragma checksum "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa647e61f1727aa677e278da37922718195679fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Faculty_ViewSubmissions), @"mvc.1.0.view", @"/Views/Faculty/ViewSubmissions.cshtml")]
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
#line 1 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\_ViewImports.cshtml"
using StudentPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\_ViewImports.cshtml"
using StudentPortal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\_ViewImports.cshtml"
using StudentPortal.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa647e61f1727aa677e278da37922718195679fd", @"/Views/Faculty/ViewSubmissions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ce12b4e7eab16e16dace5aa27e585d92feff818", @"/Views/_ViewImports.cshtml")]
    public class Views_Faculty_ViewSubmissions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Submission>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<br />\r\n<div class=\"container\">\r\n    <div class=\"row text-center\">\r\n        <div class=\"col-sm-12\">\r\n            <h3 class=\"text-primary\">Students\' Submissions</h3><br />\r\n            <h4 class=\"text-secondary\">Subject :- ");
#nullable restore
#line 8 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
                                             Write(ViewBag.SubjectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <h5>Assignment :- ");
#nullable restore
#line 9 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
                         Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-2\"></div>\r\n        <div class=\"col-sm-8\">\r\n            <div class=\"card\">\r\n                <div class=\"card-body\">\r\n");
#nullable restore
#line 18 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
                     if (Model.Count == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"jumbotron\">\r\n                            <h4>No student has submitted yet.</h4>\r\n                        </div>\r\n");
#nullable restore
#line 23 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <table class=\"table\">\r\n                            <tr>\r\n                                <th>Student\'s Name</th>\r\n                                <th>Submitted File</th>\r\n                            </tr>\r\n\r\n");
#nullable restore
#line 32 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
                             foreach (var submission in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
                                   Write(submission.Student.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa647e61f1727aa677e278da37922718195679fd6087", async() => {
                WriteLiteral("File");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1308, "~/files/", 1308, 8, true);
#nullable restore
#line 36 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
AddHtmlAttributeValue("", 1316, submission.FilePath, 1316, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 38 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n");
#nullable restore
#line 40 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Faculty\ViewSubmissions.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-2\"></div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Submission>> Html { get; private set; }
    }
}
#pragma warning restore 1591