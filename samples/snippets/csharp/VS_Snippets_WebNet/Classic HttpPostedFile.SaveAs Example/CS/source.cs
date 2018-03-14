using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
String TempFileName;
 HttpFileCollection MyFileCollection = Request.Files;
 
 for (int Loop1 = 0; Loop1 < MyFileCollection.Count; Loop1++)
 {
    // Create a new file name.
    TempFileName = "C:\\TempFiles\\File_" + Loop1.ToString();
    // Save the file.
    MyFileCollection[Loop1].SaveAs(TempFileName);
 }
   
// </Snippet1>
 }
}
