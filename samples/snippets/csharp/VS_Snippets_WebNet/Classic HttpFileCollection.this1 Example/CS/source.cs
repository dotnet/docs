using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpPostedFile MyPostedMember = Request.Files[0];
 String MyFileName = MyPostedMember.FileName;
    
// </Snippet1>
 }
}
