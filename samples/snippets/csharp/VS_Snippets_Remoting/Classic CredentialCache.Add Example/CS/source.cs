using System;
using System.Net;

public class Class
{
 private void Method1()
 {
	string UserName = Console.ReadLine();
	string SecurelyStoredPassword = Console.ReadLine();
	string Domain = Console.ReadLine();

    WebRequest wReq = WebRequest.Create("http://www.contoso.com");
    // <Snippet1>
    CredentialCache myCache = new CredentialCache();

    myCache.Add(new Uri("http://www.contoso.com/"),"Basic",new NetworkCredential(UserName,SecurelyStoredPassword));
    myCache.Add(new Uri("http://www.contoso.com/"),"Digest", new NetworkCredential(UserName,SecurelyStoredPassword,Domain));

    wReq.Credentials = myCache;
    // </Snippet1>
 }
}
