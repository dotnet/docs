using System;
using System.Web.Services.Protocols;

public class MatchAttribute_Example : HttpGetClientProtocol
{
	public MatchAttribute_Example()
	{
		Url = "http://localhost";
	}

	[HttpMethodAttribute(typeof(TextReturnReader), typeof(UrlParameterWriter))]
	public Example_Headers GetHeaders()
	{
		return ((Example_Headers)Invoke("GetHeaders", (Url + "/MyHeaders.html"),
			new object[0]));
	}

	public System.IAsyncResult BeginGetHeaders(System.AsyncCallback callback,
		object asyncState) 
	{
		return BeginInvoke("GetHeaders", (Url + "/MyHeaders.html"), 
			new object[0], callback, asyncState);
	}

	public Example_Headers EndGetHeaders(System.IAsyncResult asyncResult) 
	{
		return (Example_Headers)(EndInvoke(asyncResult));
	}
}
public class Example_Headers 
{    
	[MatchAttribute("TITLE>(.*?)<")]
	public string Title;
        
	[MatchAttribute("", Pattern="h1>(.*?)<", IgnoreCase=true)]
	public string H1;

	[MatchAttribute("H2>((([^<,]*),?)+)<", Group=3, Capture=4)] 
	public string Element;

	[MatchAttribute("H2>((([^<,]*),?){2,})<", Group=3, MaxRepeats=0)] 
	public string[] Elements1;

	[MatchAttribute("H2>((([^<,]*),?){2,})<", Group=3, MaxRepeats=1)] 
	public string[] Elements2;

	[MatchAttribute("H3 ([^=]*)=([^>]*)", Group=1)]
	public string Attribute;

	[MatchAttribute("H3 ([^=]*)=([^>]*)", Group=2)]
	public string Value;
}
