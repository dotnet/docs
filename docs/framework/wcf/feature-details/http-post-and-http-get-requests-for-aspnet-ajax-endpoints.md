---
description: "Learn more about: How to: Choose between HTTP POST and HTTP GET requests for ASP.NET AJAX Endpoints"
title: "How to: Choose between HTTP POST and HTTP GET requests for ASP.NET AJAX Endpoints"
ms.date: "03/30/2017"
ms.topic: how-to
ms.assetid: b47de82a-4c92-4af6-bceb-a5cb8bb8ede9
---
# How to: Choose between HTTP POST and HTTP GET requests for ASP.NET AJAX Endpoints

Windows Communication Foundation (WCF) allows you to create a service that exposes an ASP.NET AJAX-enabled endpoint that can be called from JavaScript on a client Web site. The basic procedures for building such services is discussed in [How to: Use Configuration to Add an ASP.NET AJAX Endpoint](how-to-use-configuration-to-add-an-aspnet-ajax-endpoint.md) and [How to: Add an ASP.NET AJAX Endpoint Without Using Configuration](how-to-add-an-aspnet-ajax-endpoint-without-using-configuration.md).  
  
 ASP.NET AJAX supports operations that use the HTTP POST and HTTP GET verbs, with HTTP POST being the default. When creating an operation that has no side effects and returns data that rarely or never changes, use HTTP GET instead. Results of GET operations can be cached, which means that multiple calls to the same operation may result in only one request to your service. The caching is not done by WCF but can take place at any level (in a user's browser, on a proxy server, and other levels.) Caching is advantageous if you want to increase service performance, but may not be acceptable if data changes frequently or if the operation performs some action.  
  
 For example, if you are designing service to manage a user's music library, an operation that looks up the artist based on an album's title benefits from using GET, but an operation that adds an album to the user's personal collection must use POST.  
  
 To control the lifetime of the cache, use the <xref:System.ServiceModel.Web.OutgoingWebResponseContext> type. For example, when designing a service that returns weather forecasts updated hourly, you would use GET but limit the cache duration to an hour or less to prevent the users of the service from accessing stale data.  
  
 When using services from an ASP.NET AJAX page that use the Script Manager control, it makes no difference whether the operation uses GET or POST - the script manager mechanism ensures that the correct request type is issued.  
  
 HTTP GET operations use any input parameters supported by POST operations, including complex data contract types. However, in most cases it is recommended to avoid too many parameters or parameters that are too complex in GET operations because it reduces caching efficiency.  
  
 This topic demonstrates how to select between GET and POST by adding the <xref:System.ServiceModel.Web.WebGetAttribute> or <xref:System.ServiceModel.Web.WebInvokeAttribute> attributes to the relevant operations in the service contract. The other steps (to implement, configure and host the service) that are required to get the service running are similar to those used by any ASP.NET AJAX service in WCF.  
  
 An operation marked with the <xref:System.ServiceModel.Web.WebGetAttribute> always uses a GET request. An operation marked with the <xref:System.ServiceModel.Web.WebInvokeAttribute>, or not marked with any of the two attributes, uses a POST request. The <xref:System.ServiceModel.Web.WebInvokeAttribute> allows the use of other HTTP verbs, other than GET and POST (such as PUT and DELETE) through the <xref:System.ServiceModel.Web.WebInvokeAttribute.Method%2A> property. However, these verbs are not supported by ASP.NET AJAX. If you intend to use the service from ASP.NET pages using the Script Manager control, do not use the <xref:System.ServiceModel.Web.WebInvokeAttribute.Method%2A> property.  
  
 For a working example of switching to GET, see the [Basic AJAX Service](../samples/basic-ajax-service.md) sample.  
  
 For a sample that uses POST, see the [AJAX Service Using HTTP POST](../samples/ajax-service-using-http-post.md) sample.  
  
## To create a WCF service that responds to HTTP GET or HTTP POST requests
  
1. Define a basic WCF service contract with an interface marked with the <xref:System.ServiceModel.ServiceContractAttribute> attribute. Mark each operation with the <xref:System.ServiceModel.OperationContractAttribute>. Add the <xref:System.ServiceModel.Web.WebGetAttribute> attribute to stipulate that an operation should respond to HTTP GET requests. You can also add the <xref:System.ServiceModel.Web.WebInvokeAttribute> attribute to explicitly specify HTTP POST, or not specify an attribute, which defaults to HTTP POST.
  
    ```csharp
    [ServiceContract]  
    public interface IMusicService  
    {  
        //This operation uses a GET method.  
        [OperationContract]  
        [WebGet]  
        string LookUpArtist(string album);  
  
        //This operation will use a POST method.  
        [OperationContract]  
        [WebInvoke]  
        void AddAlbum(string user, string album);  
  
        //This operation will use POST method by default  
        //since nothing else is explicitly specified.  
        [OperationContract]  
        string[] GetAlbums(string user);  
  
        //Other operations omitted…  
  
    }  
    ```  
  
2. Implement the `IMusicService` service contract with a `MusicService`.
  
    ```csharp
    public class MusicService : IMusicService  
    {  
        public void AddAlbum(string user, string album)  
        {  
            //Add implementation here.  
        }  
  
         //Other operations omitted…  
    }  
    ```  
  
3. Create a new file named service with a .svc extension in the application. Edit this file by adding the appropriate [\@ServiceHost](../../configure-apps/file-schema/wcf-directive/servicehost.md) directive information for the service. Specify that the <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory> is to be used in the [\@ServiceHost](../../configure-apps/file-schema/wcf-directive/servicehost.md) directive to automatically configure an ASP.NET AJAX endpoint.  
  
    ```aspx-csharp
    <%@ServiceHost
        language=c#
        Debug="true"
        Service="Microsoft.Ajax.Samples.MusicService"  
        Factory=System.ServiceModel.Activation.WebScriptServiceHostFactory  
    %>  
    ```  
  
## To call the service  
  
1. You can test your service's GET operations without any client code, by using the browser. For example, if your service is configured at the `http://example.com/service.svc` address, then typing `http://example.com/service.svc/LookUpArtist?album=SomeAlbum` into the browser address bar invokes the service and causes the response to be downloaded or displayed.
  
2. You can use services with GET operations in the same way as any other ASP.NET AJAX services - by entering the service URL into the Scripts collection of the ASP.NET AJAX Script Manager control. For an example, see the [Basic AJAX Service](../samples/basic-ajax-service.md).
  
## See also

- [Creating WCF Services for ASP.NET AJAX](creating-wcf-services-for-aspnet-ajax.md)
- [How to: Migrate AJAX-Enabled ASP.NET Web Services to WCF](how-to-migrate-ajax-enabled-aspnet-web-services-to-wcf.md)
