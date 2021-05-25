#pragma checksum "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Administrator\Department.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c63caba2cf20f6e22e68f82568eae9ed1a1622e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrator_Department), @"mvc.1.0.view", @"/Views/Administrator/Department.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administrator/Department.cshtml", typeof(AspNetCore.Views_Administrator_Department))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c63caba2cf20f6e22e68f82568eae9ed1a1622e1", @"/Views/Administrator/Department.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrator_Department : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Administrator\Department.cshtml"
  
  ViewData["Title"] = "Department";
  Layout = "~/Views/Shared/AdministratorLayout.cshtml";

#line default
#line hidden
            BeginContext(103, 32, true);
            WriteLiteral("\r\n<h4 id=\"classname\">Courses in ");
            EndContext();
            BeginContext(136, 19, false);
#line 7 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Administrator\Department.cshtml"
                         Write(ViewData["subject"]);

#line default
#line hidden
            EndContext();
            BeginContext(155, 1492, true);
            WriteLiteral(@"</h4>

<div id=""departmentDiv"" class=""col-md-12"">
  <div class=""panel panel-primary"">
    <div class=""panel-heading"">
      <h3 class=""panel-title""></h3>
    </div>
    <div class=""panel-body"">
      <table id=""tblCourses"" class=""table table-bordered table-striped table-responsive table-hover"">
        <thead>
          <tr>
            <th align=""left"" class=""productth"">Number</th>
            <th align=""left"" class=""productth"">Name</th>
          </tr>
        </thead>
        <tbody></tbody>
      </table>
    </div>
  </div>
</div>


<div class=""col-md-12"">
  <div class=""panel panel-primary"">
    <div class=""panel-heading"">
      <h3 class=""panel-title"">New Course</h3>
    </div>
    <div class=""panel-body"">
      <div class=""form-group col-md-5"">
        <label>Course Name</label>
        <input type=""text"" name=""CourseName"" id=""CourseName"" class=""form-control"" placeholder=""Enter course name"" required="""" />
      </div>
      <div class=""form-group col-md-5"">
        <lab");
            WriteLiteral(@"el>Course Number</label>
        <input type=""text"" name=""CourseNumber"" id=""CourseNumber"" class=""form-control"" placeholder=""Enter course number"" required="""" />
      </div>

      <div class=""form-group col-md-1"">
        <div style=""float: right; display:inline-block;"">
          <input class=""btn btn-primary"" name=""submitButton"" id=""btnSave"" value=""Add"" type=""button"" onclick=""AddCourse()"">
        </div>
      </div>
    </div>
  </div>
</div>



");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1668, 242, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n\r\n    LoadData();\r\n\r\n    function AddCourse() {\r\n\r\n      var corName = $(\"#CourseName\").val();\r\n      var corNum = Number($(\"#CourseNumber\").val());\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(1911, 43, false);
#line 67 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Administrator\Department.cshtml"
         Write(Url.Action("CreateCourse", "Administrator"));

#line default
#line hidden
                EndContext();
                BeginContext(1954, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(2023, 19, false);
#line 70 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Administrator\Department.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(2042, 1004, true);
                WriteLiteral(@"',
          number: corNum,
          name: corName},
        success: function (data, status) {
          //alert(JSON.stringify(data));
          if (!data.success) {
            alert(""Unable to add course"");
          }
          LoadData();
        },
          error: function (ex) {
            alert(""CreateCourse controller did not return successfully"");
        }
        });

    }

    function PopulateTable(tbl, offerings) {
      var newBody = document.createElement(""tbody"");

      offerings.sort(function (a, b) {
        return a.number - b.number;
      });

      $.each(offerings, function (i, item) {
        var tr = document.createElement(""tr"");

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.number));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        var a = document.createElement(""a"");
        a.setAttribute(""href"", ""/Administrator/Course/?subject="" + '");
                EndContext();
                BeginContext(3047, 19, false);
#line 103 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Administrator\Department.cshtml"
                                                               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3066, 465, true);
                WriteLiteral(@"' + ""&num="" + item.number);
        a.appendChild(document.createTextNode(item.name));
        td.appendChild(a);
        tr.appendChild(td);

        newBody.appendChild(tr);
      });

      tbl.appendChild(newBody);

    }

    function LoadData() {

      var tbl = document.getElementById(""tblCourses"");
      var body = tbl.getElementsByTagName(""tbody"")[0];
      tbl.removeChild(body);

      $.ajax({
        type: 'POST',
        url: '");
                EndContext();
                BeginContext(3532, 41, false);
#line 123 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Administrator\Department.cshtml"
         Write(Url.Action("GetCourses", "Administrator"));

#line default
#line hidden
                EndContext();
                BeginContext(3573, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(3642, 19, false);
#line 126 "C:\Users\lishi\source\repos\LMS_handout\LMS\Views\Administrator\Department.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3661, 319, true);
                WriteLiteral(@"'
        },
          success: function (data, status) {
            //alert(JSON.stringify(data));
            PopulateTable(tbl, data);
          },
          error: function (ex) {
              alert(""GetCourses controller did not return successfully"");
          }
        });
    }

    </script>

");
                EndContext();
            }
            );
            BeginContext(3983, 4, true);
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
