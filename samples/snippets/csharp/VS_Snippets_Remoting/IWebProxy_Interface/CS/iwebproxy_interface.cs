/*
  This program demonstrates  'Credentials' property, 'GetProxy' and 'IsBypassed' methods of 
  IWebProxy interface.
  The 'WebProxy_Interface' class implements the 'IWebProxy' interface. It provides an implementation for the
  'GetProxy' and 'IsByPassed' methods and 'ICredentials' property. The 'GetProxy' method returns the url 
  of the proxy server as specified in the constructor. The 'IsByPassed' method returns false indicating 
  that the proxy server must never be bypassed for any requested url. The 'ICredentials' property stores 
  the credentials required by the proxy server to authenticate the actual user.
*/

using System;
using System.Net;

// <Snippet1>
// <Snippet2>
// <snippet3>
public class WebProxy_Interface : IWebProxy

{

	// The credentials to be used with the web proxy.
	private ICredentials iCredentials;

	// Uri of the associated proxy server.
	private Uri webProxyUri;

	public WebProxy_Interface(Uri proxyUri) {

		webProxyUri = proxyUri;	

	}

	// Get and Set the Credentials property.
	public ICredentials Credentials {
		get {
			return iCredentials;
		}
		set {
			if(iCredentials != value)
				iCredentials = value;
		}
	}

	// Return the web proxy for the specified destination(destUri).
	public Uri GetProxy(Uri destUri) {

		// Always use the same proxy.
		return webProxyUri;

	}

	// Return whether the web proxy should be bypassed for the specified destination(hostUri).
	public bool IsBypassed(Uri hostUri) {

		// Never bypass the proxy.
		return false;

	}
};
// </Snippet3>
// </Snippet2>
// </Snippet1>

public class WebProxy_Example {
	public static void Main() 
	{
	//<Snippet4>
		WebProxy_Interface webProxy_Interface = new WebProxy_Interface(new Uri("http://proxy.example.com"));

		webProxy_Interface.Credentials = new NetworkCredential("myusername", "mypassword");

		Console.WriteLine("The web proxy is : {0}", webProxy_Interface.GetProxy(new Uri("http://www.contoso.com")));

		// Determine whether the Web proxy can be bypassed for the site "http://www.contoso.com".
		if(webProxy_Interface.IsBypassed(new Uri("http://www.contoso.com")))
			Console.WriteLine("Web Proxy is by passed");
		else
			Console.WriteLine("Web Proxy is not by passed");

      //</Snippet4>
	}
};