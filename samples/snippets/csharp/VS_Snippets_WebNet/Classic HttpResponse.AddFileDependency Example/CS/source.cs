using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
String FileName;
 FileName = "C:\\Files\\F1.txt";
 Response.AddFileDependency(FileName);
    
// </Snippet1>
 }
}
