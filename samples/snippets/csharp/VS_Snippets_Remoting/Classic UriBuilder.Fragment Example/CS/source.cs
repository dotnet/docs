using System;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
UriBuilder uBuild = new UriBuilder("http://www.contoso.com/");
uBuild.Path = "index.htm";
uBuild.Fragment = "main";

Uri myUri = uBuild.Uri;
   
// </Snippet1>
 }
}
