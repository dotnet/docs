using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpFileCollection MyFileColl = Request.Files;
 HttpPostedFile MyPostedFile = MyFileColl.Get(0);
 String MyFileName = MyPostedFile.FileName;
    
// </Snippet1>
 }
}
