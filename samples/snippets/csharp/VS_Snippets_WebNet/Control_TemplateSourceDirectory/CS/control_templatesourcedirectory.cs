// System.Web.Control.MapPathSecure
// System.Web.Control.TemplateSourceDirectory

/* The following example demonstrates 'TemplateSourceDirectory' and 'MapPathSecure' 
  properties of 'Control' class. A new CustomControl derived from control class is 
  instantiated and the 'TemplateSourceDirectory' property is displayed.The absolute path 
  of the control is obtained and all the files in the directory are rendered onto the 
  browser.
*/


using System;
using System.IO;
using System.Web;
using System.Web.Util;
using System.Web.UI;

namespace Control_TemplateSource
{
   public class MyControl:Control
   {
      protected override void Render (HtmlTextWriter output)
      {
         try
         {
// <Snippet1>
// <Snippet2>
   // An HttpException occurs if the server control does not,;
   // have permissions to read the resulting mapped file. 
        output.Write("The Actual Path of the virtual directory : "+
        MapPathSecure(TemplateSourceDirectory)+"<br>");

       // Get all the files from the absolute path of 'MyControl';
       // using TemplateSourceDirectory which gives the virtual Directory.
           string [] myFiles=
           Directory.GetFiles(MapPathSecure(TemplateSourceDirectory));
           output.Write("The files in this Directory are <br>");

            // List all the files.
            for (int i=0;i<myFiles.Length;i++)
               output.Write(myFiles[i]+"<br>");
// </Snippet2>
// </Snippet1>
         }
         catch(HttpException e)
         {
            output.Write("<br>The following Exception occurred:</b>"+e.Message);
         }
      }
   }
}