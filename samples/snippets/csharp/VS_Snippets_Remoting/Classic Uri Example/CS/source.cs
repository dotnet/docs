using System;
using System.Data;
using System.Net;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
Uri siteUri = new Uri("http://www.contoso.com/");
 
WebRequest wr = WebRequest.Create(siteUri);

// </Snippet1>
 }
}
