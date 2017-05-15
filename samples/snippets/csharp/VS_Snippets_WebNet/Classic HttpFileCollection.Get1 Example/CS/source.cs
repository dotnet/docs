using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpFileCollection MyFileColl = Request.Files;
 HttpPostedFile MyPostedMember = MyFileColl.Get(0);
 String MyFileName = MyPostedMember.FileName;
   
// </Snippet1>
 }
}
