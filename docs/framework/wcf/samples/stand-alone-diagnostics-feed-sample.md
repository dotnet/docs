---
description: "Learn more about: Stand-Alone Diagnostics Feed Sample"
title: "Stand-Alone Diagnostics Feed Sample"
ms.date: "03/30/2017"
ms.assetid: d31c6c1f-292c-4d95-8e23-ed8565970ea5
---
# Stand-Alone Diagnostics Feed Sample

The [DiagnosticsFeed sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to create an RSS/Atom feed for syndication with Windows Communication Foundation (WCF). It is a basic "Hello World" program that shows the basics of the object model and how to set it up on a Windows Communication Foundation (WCF) service.

WCF models syndication feeds as service operations that return a special data type, <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter>. Instances of <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter> can serialize a feed into both the RSS 2.0 and Atom 1.0 formats. The following sample code shows the contract used.

```csharp
[ServiceContract(Namespace = "")]
    interface IDiagnosticsService
    {
        [OperationContract]
        //The [WebGet] attribute controls how WCF dispatches
        //HTTP requests to service operations based on a URI suffix
        //(the part of the request URI after the endpoint address)
        //using the HTTP GET method. The UriTemplate specifies a relative
        //path of 'feed', and specifies that the format is
        //supplied using a query string.
        [WebGet(UriTemplate="feed?format={format}")]
        [ServiceKnownType(typeof(Atom10FeedFormatter))]
        [ServiceKnownType(typeof(Rss20FeedFormatter))]
        SyndicationFeedFormatter GetProcesses(string format);
    }
```

The `GetProcesses` operation is annotated with the <xref:System.ServiceModel.Web.WebGetAttribute> attribute that enables you to control how WCF dispatches HTTP GET requests to service operations and specify the format of the messages sent.

Like any WCF service, syndication feeds can be self hosted in any managed application. Syndication services require a specific binding (the <xref:System.ServiceModel.WebHttpBinding>) and a specific endpoint behavior (the <xref:System.ServiceModel.Description.WebHttpBehavior>) to function correctly. The new <xref:System.ServiceModel.Web.WebServiceHost> class provides a convenient API for creating such endpoints without specific configuration.

```csharp
WebServiceHost host = new WebServiceHost(typeof(ProcessService), new Uri("http://localhost:8000/diagnostics"));

            //The WebServiceHost will automatically provide a default endpoint at the base address
            //using the proper binding (the WebHttpBinding) and endpoint behavior (the WebHttpBehavior)
```

Alternatively, you can use <xref:System.ServiceModel.Activation.WebServiceHostFactory> from within an IIS-hosted .svc file to provide equivalent functionality (this technique is not demonstrated in this sample code).

```xml
<% @ServiceHost Language="C#|VB" Debug="true" Service="ProcessService" %>
```

Because this service receives requests using the standard HTTP GET, you can use any RSS or ATOM-aware client to access the service. For example, you can view the output of this service by navigating to `http://localhost:8000/diagnostics/feed/?format=atom` or `http://localhost:8000/diagnostics/feed/?format=rss` in an RSS-aware browser.

You can also use the [How the WCF Syndication Object Model Maps to Atom and RSS](../feature-details/how-the-wcf-syndication-object-model-maps-to-atom-and-rss.md) to read syndicated data and process it using imperative code.

```csharp
XmlReader reader = XmlReader.Create( "http://localhost:8000/diagnostics/feed/?format=rss",
    new XmlReaderSettings()
    {
        //MaxCharactersInDocument can be used to control the maximum amount of data
        //read from the reader and helps prevent OutOfMemoryException
        MaxCharactersInDocument = 1024 * 64
    } );

SyndicationFeed feed = SyndicationFeed.Load(reader);

foreach (SyndicationItem i in feed.Items)
{
    XmlSyndicationContent content = i.Content as XmlSyndicationContent;
    ProcessData pd = content.ReadContent<ProcessData>();

    Console.WriteLine(i.Title.Text);
    Console.WriteLine(pd.ToString());
}
```

## Set up, build, and run the sample

1. Ensure that you have the right address registration permission for HTTP and HTTPS on the computer as explained in the set up instructions in [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. Build the solution.

3. Run the console application.

4. While the console application is running, navigate to `http://localhost:8000/diagnostics/feed/?format=atom` or `http://localhost:8000/diagnostics/feed/?format=rss` using an RSS-aware browser.

## See also

- [WCF Web HTTP Programming Model](../feature-details/wcf-web-http-programming-model.md)
- [WCF Syndication](../feature-details/wcf-syndication.md)
