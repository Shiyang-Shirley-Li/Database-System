#pragma checksum "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6b01caa85f11feef3951d847f92e678b5c93452"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professor_Students), @"mvc.1.0.view", @"/Views/Professor/Students.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Professor/Students.cshtml", typeof(AspNetCore.Views_Professor_Students))]
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
#line 1 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6b01caa85f11feef3951d847f92e678b5c93452", @"/Views/Professor/Students.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Professor_Students : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
  
  ViewData["Title"] = "Students";
  Layout = "~/Views/Shared/ProfessorLayout.cshtml";

#line default
#line hidden
            BeginContext(97, 10, true);
            WriteLiteral("\r\n<html>\r\n");
            EndContext();
            BeginContext(107, 750, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6b01caa85f11feef3951d847f92e678b5c934524097", async() => {
                BeginContext(113, 737, true);
                WriteLiteral(@"
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <style>
    body {
      font-family: ""Lato"", sans-serif;
    }

    .sidenav {
      width: 130px;
      height: 210px;
      position: fixed;
      left: 0;
      right: 0;
      z-index: 1;
      top: 50px;
      background: #eee;
      overflow-x: hidden;
      padding: 8px 0;
    }

      .sidenav a {
        padding: 6px 8px 6px 16px;
        text-decoration: none;
        font-size: 18px;
        color: #2196F3;
        display: block;
      }

        .sidenav a:hover {
          color: #064579;
        }

    .main {
      margin-left: 140px;
      min-height: 200px;
      padding: 0px 10px;
    }
  </style>
");
                EndContext();
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
            EndContext();
            BeginContext(857, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(859, 1307, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6b01caa85f11feef3951d847f92e678b5c934526021", async() => {
                BeginContext(865, 35, true);
                WriteLiteral("\r\n\r\n  <div class=\"sidenav\">\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 900, "\'", 1023, 8);
                WriteAttributeValue("", 907, "/Professor/Class?subject=", 907, 25, true);
#line 50 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 932, ViewData["subject"], 932, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 952, "&num=", 952, 5, true);
#line 50 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 957, ViewData["num"], 957, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 973, "&season=", 973, 8, true);
#line 50 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 981, ViewData["season"], 981, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1000, "&year=", 1000, 6, true);
#line 50 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1006, ViewData["year"], 1006, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1024, 24, true);
                WriteLiteral(">Assignments</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1048, "\'", 1174, 8);
                WriteAttributeValue("", 1055, "/Professor/Students?subject=", 1055, 28, true);
#line 51 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1083, ViewData["subject"], 1083, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1103, "&num=", 1103, 5, true);
#line 51 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1108, ViewData["num"], 1108, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1124, "&season=", 1124, 8, true);
#line 51 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1132, ViewData["season"], 1132, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1151, "&year=", 1151, 6, true);
#line 51 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1157, ViewData["year"], 1157, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1175, 21, true);
                WriteLiteral(">Students</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1196, "\'", 1324, 8);
                WriteAttributeValue("", 1203, "/Professor/Categories?subject=", 1203, 30, true);
#line 52 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1233, ViewData["subject"], 1233, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1253, "&num=", 1253, 5, true);
#line 52 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1258, ViewData["num"], 1258, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1274, "&season=", 1274, 8, true);
#line 52 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1282, ViewData["season"], 1282, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1301, "&year=", 1301, 6, true);
#line 52 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1307, ViewData["year"], 1307, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1325, 834, true);
                WriteLiteral(@">Assignment Categories</a>
  </div>


  <div class=""main"">
    <h4 id=""classname"">Class</h4>

    <div id=""studentsDiv"" class=""col-md-12"">
      <div class=""panel panel-primary"">
        <div class=""panel-heading"">
          <h3 class=""panel-title""></h3>
        </div>
        <div class=""panel-body"">
          <table id=""tblStudents"" class=""table table-bordered table-striped table-responsive table-hover"">
            <thead>
              <tr>
                <th align=""left"" class=""productth"">Name</th>
                <th align=""left"" class=""productth"">uID</th>
                <th align=""left"" class=""productth"">Standing</th>
                <th align=""left"" class=""productth"">Grade</th>
              </tr>
            </thead>
          </table>
        </div>
      </div>
    </div>
  </div>

");
                EndContext();
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
            EndContext();
            BeginContext(2166, 15, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2202, 1307, true);
                WriteLiteral(@"
  <script type=""text/javascript"">

    LoadData();

    function PopulateTable(tbl, offerings) {
      var newBody = document.createElement(""tbody"");


      $.each(offerings, function (i, item) {
        var tr = document.createElement(""tr"");

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.lname + "", "" + item.fname));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.uid));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        var bYear = Number(item.dob.substring(0, 4));
        var cYear = new Date().getFullYear();
        var age = cYear - bYear;
        var standing = ""freshman"";
        if (age == 19) { standing = ""sohpomore""; }
        if (age == 20) { standing = ""junior""; }
        if (age > 20) { standing = ""senior"";}
        td.appendChild(document.createTextNode(standing));
        tr.appendChild(td);

       ");
                WriteLiteral(@" var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.grade));
        tr.appendChild(td);

        newBody.appendChild(tr);
      });

      tbl.appendChild(newBody);

    }

    function LoadData() {

      classname.innerText = '");
                EndContext();
                BeginContext(3510, 19, false);
#line 129 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
                        Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3529, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3531, 15, false);
#line 129 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
                                             Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3546, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3548, 18, false);
#line 129 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
                                                              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(3566, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3568, 16, false);
#line 129 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
                                                                                  Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(3584, 118, true);
                WriteLiteral("\';\r\n\r\n      var tbl = document.getElementById(\"tblStudents\");\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(3703, 45, false);
#line 135 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
         Write(Url.Action("GetStudentsInClass", "Professor"));

#line default
#line hidden
                EndContext();
                BeginContext(3748, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(3817, 19, false);
#line 138 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3836, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(3864, 15, false);
#line 139 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3879, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(3904, 18, false);
#line 140 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(3922, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(3951, 16, false);
#line 141 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Professor\Students.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(3967, 318, true);
                WriteLiteral(@"')},
        success: function (data, status) {
          //alert(JSON.stringify(data));
          PopulateTable(tbl, data);
        },
          error: function (ex) {
              alert(""GetStudentsInClass controller did not return successfully"");
        }
        });

        
    }

  </script>

");
                EndContext();
            }
            );
            BeginContext(4288, 4, true);
            WriteLiteral("\r\n\r\n");
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
