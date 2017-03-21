		WebProxy_Interface webProxy_Interface = new WebProxy_Interface(new Uri("http://proxy.example.com"));

		webProxy_Interface.Credentials = new NetworkCredential("myusername", "mypassword");

		Console.WriteLine("The web proxy is : {0}", webProxy_Interface.GetProxy(new Uri("http://www.contoso.com")));

		// Determine whether the Web proxy can be bypassed for the site "http://www.contoso.com".
		if(webProxy_Interface.IsBypassed(new Uri("http://www.contoso.com")))
			Console.WriteLine("Web Proxy is by passed");
		else
			Console.WriteLine("Web Proxy is not by passed");
