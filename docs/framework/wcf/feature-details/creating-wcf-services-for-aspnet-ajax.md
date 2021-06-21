---
description: "Learn more about: Creating WCF Services for ASP.NET AJAX"
title: "Creating WCF Services for ASP.NET AJAX"
ms.date: "03/30/2017"
ms.assetid: 04c0402c-e617-4ba5-aedf-d17692234776
---
# Creating WCF Services for ASP.NET AJAX

Microsoft ASP.NET AJAX enables you to quickly create Web pages that include a rich user experience with responsive and familiar user interface elements. ASP.NET AJAX provides client-script libraries that incorporate cross-browser ECMAScript (JavaScript) and dynamic HTML (DHTML) technologies, and it integrates them with the ASP.NET 2.0 server-based development platform. By using ASP.NET AJAX, you can improve the user experience and the efficiency of your Web applications.

ASP.NET AJAX consists of client-script libraries and of server components that are integrated to provide a robust development framework. To access a service from an ASP.NET page: once the service URL is added to the ASP.NET Script Manager control on the page, service operations may be invoked using JavaScript code that looks exactly like a regular JavaScript function call.

Most Windows Communication Foundation (WCF) services may be exposed as a service compatible with ASP.NET AJAX by adding an appropriate ASP.NET AJAX endpoint.

If you are using Visual Studio, you may use a pre-built template for AJAX-enabled WCF services, available in the **Add New Item** dialog when working with ASP.NET Web Sites or Web Applications.

If you are not using the Visual Studio templates, there are two ways to create an ASP.NET AJAX endpoint:

- Create the endpoint using dynamic host activation without using any configuration. This is the most basic approach if you are unfamiliar with the WCF configuration system. For more information, see [How to: Add an ASP.NET AJAX Endpoint Without Using Configuration](how-to-add-an-aspnet-ajax-endpoint-without-using-configuration.md).

- Add an AJAX-enabled endpoint to a WCF service using configuration. For more information, see [How to: Use Configuration to Add an ASP.NET AJAX Endpoint](how-to-use-configuration-to-add-an-aspnet-ajax-endpoint.md).

The Web Programming Model described in the [WCF Web HTTP Programming Model Overview](wcf-web-http-programming-model-overview.md) may be used with ASP.NET AJAX services. Specifically:

- You can use the <xref:System.ServiceModel.Web.WebGetAttribute> and <xref:System.ServiceModel.Web.WebInvokeAttribute> attributes to select between HTTP GET and HTTP POST verbs. If used correctly, this may significantly improve your application’s performance. For more information, see [How to: Choose between HTTP POST and HTTP GET requests for ASP.NET AJAX Endpoints](http-post-and-http-get-requests-for-aspnet-ajax-endpoints.md).

- You can use the <xref:System.ServiceModel.Web.WebGetAttribute.ResponseFormat%2A> and <xref:System.ServiceModel.Web.WebInvokeAttribute.ResponseFormat%2A> properties to cause your service to return XML data instead of the default JavaScript Object Notation (JSON). Doing this with the ASP.NET AJAX framework causes the JavaScript client to receive an XML DOM object.

  > [!WARNING]
  > Your operation must set the content type to text/xml for this to work. Otherwise, the JavaScript client will receive a string containing the XML instead of an XML DOM object.

    The following is an example of an operation that returns XML data with the content type set appropriately:

  ```csharp
  [OperationContract, WebGet(ResponseFormat=WebMessageFormat.Xml)]
  public XElement GetData()
  {
      XElement x;
      //Get some data here...

      WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
      return x;
  }
  ```

- No other properties on the <xref:System.ServiceModel.Web.WebGetAttribute> and <xref:System.ServiceModel.Web.WebInvokeAttribute> attributes can be changed if compatibility with ASP.NET AJAX is required. Other aspects of the Web Programming Model can be used as long as the ASP.NET AJAX calling conventions are not violated.

 More advanced scenarios require some additional details of AJAX support in WCF be understood:

- To understand how data is transferred between an AJAX page client and a WCF service using JavaScript, and for details on how .NET Framework types map to JavaScript types, see [Support for JSON and Other Data Transfer Formats](support-for-json-and-other-data-transfer-formats.md).

- To take advantage of ASP.NET features, for example, URL-based authentication and accessing the ASP.NET session information, you may want to enable the ASP.NET Compatibility Mode through configuration.

AJAX endpoints in WCF may even be consumed without the ASP.NET AJAX framework. Doing so requires an understanding of the support architecture of AJAX support in WCF. For a discussion of this architecture, see [WCF Web HTTP Programming Object Model](wcf-web-http-programming-object-model.md). For a code sample demonstrating this approach, see the [AJAX Service with JSON and XML](/previous-versions/dotnet/framework/wcf/samples/ajax-service-with-json-and-xml-sample).

## See also

- [WCF Web HTTP Programming Model](wcf-web-http-programming-model.md)
- [How to: Add an ASP.NET AJAX Endpoint Without Using Configuration](how-to-add-an-aspnet-ajax-endpoint-without-using-configuration.md)
- [How to: Use Configuration to Add an ASP.NET AJAX Endpoint](how-to-use-configuration-to-add-an-aspnet-ajax-endpoint.md)
- [How to: Choose between HTTP POST and HTTP GET requests for ASP.NET AJAX Endpoints](http-post-and-http-get-requests-for-aspnet-ajax-endpoints.md)
