using System;
using System.Data;
using System.Net;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
IPHostEntry hostInfo = Dns.GetHostByName("www.contoso.com");
   
// </Snippet1>
 }
}
