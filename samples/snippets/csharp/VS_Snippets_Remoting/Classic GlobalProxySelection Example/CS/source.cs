using System;
using System.Net;
using System.IO;
using System.Windows.Forms;

public class Form1: Form
{
 public void Method()
 {
// <Snippet1>
Uri proxyURI = new Uri("http://webproxy:80");
 GlobalProxySelection.Select = new WebProxy(proxyURI);

// </Snippet1>
 }
}
