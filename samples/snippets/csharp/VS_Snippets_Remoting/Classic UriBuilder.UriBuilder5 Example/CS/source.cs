using System;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
UriBuilder myUri = new UriBuilder("http","www.contoso.com",8080,"index.htm");

// </Snippet1>
 }
}
