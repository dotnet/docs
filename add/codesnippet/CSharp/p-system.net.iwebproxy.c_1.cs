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