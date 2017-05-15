using System;
using System.Net;
using System.IO;
using System.Windows.Forms;

public class Form1: Form
{
 public void Method()
 {
string SecurelyStoredUserName = "";
string SecurelyStoredPassword = "";
string SecurelyStoredDomain = "";
// <Snippet1>
NetworkCredential myCred = new NetworkCredential(
	SecurelyStoredUserName,SecurelyStoredPassword,SecurelyStoredDomain);
 
CredentialCache myCache = new CredentialCache();
 
myCache.Add(new Uri("www.contoso.com"), "Basic", myCred);
myCache.Add(new Uri("app.contoso.com"), "Basic", myCred);
 
WebRequest wr = WebRequest.Create("www.contoso.com");
wr.Credentials = myCache;

// </Snippet1>
 }
}
