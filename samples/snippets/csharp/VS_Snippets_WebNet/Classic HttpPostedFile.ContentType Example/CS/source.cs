using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpFileCollection MyFileCollection = Request.Files;
 
 for (int Loop1 = 0; Loop1 < MyFileCollection.Count; Loop1++)
 {
    if (MyFileCollection[Loop1].ContentType == "video/mpeg")
    {
       //...
    }
 }
    
// </Snippet1>
 }
}
