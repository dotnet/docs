//<Snippet1>
<%@ WebService Language="c#" Class="SumService" %>

using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;

	[SoapDocumentService(SoapBindingUse.Literal,
		                 SoapParameterStyle.Wrapped,
		                 RoutingStyle=SoapServiceRoutingStyle.SoapAction)]
	public class SumService : System.Web.Services.WebService
	{
		[WebMethod]
		public int Add(int a, int b)
		{
			return a + b;
		}
	}
//</Snippet1>