#pragma checksum "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ae197e5d3c86e41f647888222eb4bd54046b153"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserDetails), @"mvc.1.0.view", @"/Views/Admin/UserDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ae197e5d3c86e41f647888222eb4bd54046b153", @"/Views/Admin/UserDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ce12b4e7eab16e16dace5aa27e585d92feff818", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AppUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("h4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<br />\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ae197e5d3c86e41f647888222eb4bd54046b1534364", async() => {
                WriteLiteral("<i class=\"fa fa-arrow-left\"></i>&nbsp;Back ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <br /><br />\r\n        <div class=\"col-sm-12 text-center\">\r\n            <h4 class=\"text-primary\">Details of ");
#nullable restore
#line 11 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <span>\r\n");
#nullable restore
#line 13 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                 if (Model.IsFaculty)
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("~ Faculty");
#nullable restore
#line 15 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                                          
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("~ Student");
#nullable restore
#line 19 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                                          
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </span>
        </div>
    </div>
    <br />
    <div class=""row"">
        <div class=""col-sm-12"">
            <table class=""table table-striped"">
                <thead>
                    <tr>
                        <th>Field</th>
                        <th>Details</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Email : </td>
                        <td>");
#nullable restore
#line 37 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Name : </td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Mobile Number : </td>\r\n                        <td>");
#nullable restore
#line 45 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                       Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Birth Date : </td>\r\n                        <td>");
#nullable restore
#line 49 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                       Write(Model.BirthDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Address : </td>\r\n                        <td>");
#nullable restore
#line 53 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                       Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Gender : </td>\r\n                        <td>");
#nullable restore
#line 57 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                       Write(Model.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Caste : </td>\r\n                        <td>");
#nullable restore
#line 61 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                       Write(Model.Caste);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Branch : </td>\r\n                        <td>");
#nullable restore
#line 65 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                       Write(Model.Branch);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 67 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                     if (Model.IsFaculty)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>Degree : </td>\r\n                            <td>");
#nullable restore
#line 71 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                           Write(Model.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 73 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>HSC Board : </td>\r\n                            <td>");
#nullable restore
#line 78 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                           Write(Model.HscBoard);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>Board Result :</td>\r\n                            <td>");
#nullable restore
#line 82 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                           Write(Model.BoardResult);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 84 "C:\Users\lenovo\source\repos\StudentPortal\StudentPortal\Views\Admin\UserDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AppUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
