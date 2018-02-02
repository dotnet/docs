---
title: "WCF Web HTTP Programming Model Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 381fdc3a-6e6c-4890-87fe-91cca6f4b476
caps.latest.revision: 45
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Web HTTP Programming Model Overview
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] WEB HTTP programming model provides the basic elements required to build WEB HTTP services with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP services are designed to be accessed by the widest range of possible clients, including Web browsers and have the following unique requirements:  
  
-   **URIs and URI Processing** URIs play a central role in the design of WEB HTTP services. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model uses the <xref:System.UriTemplate> and <xref:System.UriTemplateTable> classes to provide URI processing capabilities.  
  
-   **Support for GET and POST operations** WEB HTTP services make use of the GET verb for data retrieval, in addition to various invoke verbs for data modification and remote invocation. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model uses the <xref:System.ServiceModel.Web.WebGetAttribute> and <xref:System.ServiceModel.Web.WebInvokeAttribute> to associate service operations with both GET and other HTTP verbs like PUT, POST, and DELETE.  
  
-   **Multiple data formats** Web-style services process many kinds of data in addition to SOAP messages. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model uses the <xref:System.ServiceModel.WebHttpBinding> and <xref:System.ServiceModel.Description.WebHttpBehavior> to support many different data formats including XML documents, JSON data object, and streams of binary content such as images, video files, or plain text.  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model extends the reach of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to cover Web-style scenarios that include WEB HTTP services, AJAX and JSON services, and Syndication (ATOM/RSS) feeds. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] AJAX and JSON services, see [AJAX Integration and JSON Support](../../../../docs/framework/wcf/feature-details/ajax-integration-and-json-support.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] Syndication, see [WCF Syndication Overview](../../../../docs/framework/wcf/feature-details/wcf-syndication-overview.md).  
  
 There are no extra restrictions on the types of data that can be returned from a WEB HTTP service. Any serializable type can be returned from an WEB HTTP service operation. Because WEB HTTP service operations can be invoke by a web browser there is a limitation on what data types can be specified in a URL. For more information on what types are supported by default see the **UriTemplate Query String Parameters and URLs** section below. The default behavior can be changed by providing your own T:System.ServiceModel.Dispatcher.QueryStringConverter implementation which specifies how to convert the parameters specified in a URL to the actual parameter type. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.Dispatcher.QueryStringConverter>  
  
> [!CAUTION]
>  Services written with the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model do not use SOAP messages. Because SOAP is not used, the security features provided by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] cannot be used. You can, however use transport-based security by hosting your service with HTTPS. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security, see [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md)  
  
> [!WARNING]
>  Installing the WebDAV extension for IIS can cause Web HTTP services to return an HTTP 405 error as the WebDAV extension attempts to handle all PUT requests. To work around this issue you can uninstall the WebDAV extension or disable the WebDAV extension for your web site. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [IIS and WebDav](http://learn.iis.net/page.aspx/357/webdav-for-iis-70/)  
  
## URI Processing with UriTemplate and UriTemplateTable  
 URI templates provide an efficient syntax for expressing large sets of structurally similar URIs. For example, the following template expresses the set of all three-segment URIs that begin with "a" and end with "c" without regard to the value of the intermediate segment: a/{segment}/c  
  
 This template describes URIs like the following:  
  
-   a/x/c  
  
-   a/y/c  
  
-   a/z/c  
  
-   and so on.  
  
 In this template, the curly brace notation ("{segment}") indicates a variable segment instead of a literal value.  
  
 .NET Framework provides an API for working with URI templates called <xref:System.UriTemplate>. `UriTemplates` allow you to do the following:  
  
-   You can call one of the `Bind` methods with a set of parameters to produce a *fully-closed URI* that matches the template. This means all variables within the URI template are replaced with actual values.  
  
-   You can call `Match`() with a candidate URI, which uses a template to break up a candidate URI into its constituent parts and returns a dictionary that contains the different parts of the URI labeled according to the variables in the template.  
  
-   `Bind`() and `Match`() are inverses so that you can call `Match`( `Bind`( x ) ) and come back with the same environment you started with.  
  
 There are many times (especially on the server, where dispatching a request to a service operation based on the URI is necessary) that you want to keep track of a set of <xref:System.UriTemplate> objects in a data structure that can independently address each of the contained templates. <xref:System.UriTemplateTable> represents a set of URI templates and selects the best match given a set of templates and a candidate URI. This is not affiliated with any particular networking stack ([!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] included) so you can use it wherever necessary.  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Service Model makes use of <xref:System.UriTemplate> and <xref:System.UriTemplateTable> to associate service operations with a set of URIs described by a <xref:System.UriTemplate>. A service operation is associated with a <xref:System.UriTemplate>, using either the <xref:System.ServiceModel.Web.WebGetAttribute> or the <xref:System.ServiceModel.Web.WebInvokeAttribute>. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] <xref:System.UriTemplate> and <xref:System.UriTemplateTable>, see [UriTemplate and UriTemplateTable](../../../../docs/framework/wcf/feature-details/uritemplate-and-uritemplatetable.md)  
  
## WebGet and WebInvoke Attributes  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP services make use of retrieval verbs (for example HTTP GET) in addition to various invoke verbs (for example HTTP POST, PUT, and DELETE). The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model allows service developers to control the both the URI template and verb associated with their service operations with the <xref:System.ServiceModel.Web.WebGetAttribute> and <xref:System.ServiceModel.Web.WebInvokeAttribute>. The <xref:System.ServiceModel.Web.WebGetAttribute> and the <xref:System.ServiceModel.Web.WebInvokeAttribute> allow you to control how individual operations get bound to URIs and the HTTP methods associated with those URIs. For example, adding <xref:System.ServiceModel.Web.WebGetAttribute> and <xref:System.ServiceModel.Web.WebInvokeAttribute> in the following code.  
  
```  
[ServiceContract]  
interface ICustomer  
{  
  //"View It"  
  
  [WebGet]  
  Customer GetCustomer():  
  
  //"Do It"  
    [WebInvoke]  
  Customer UpdateCustomerName( string id,   
                               string newName );  
}  
```  
  
 The preceding code allows you to make the following HTTP requests.  
  
 `GET /GetCustomer`  
  
 `POST /UpdateCustomerName`  
  
 <xref:System.ServiceModel.Web.WebInvokeAttribute> defaults to POST but you can use it for other verbs too.  
  
```  
[ServiceContract]  
interface ICustomer  
{  
  //"View It" -> HTTP GET  
    [WebGet( UriTemplate="customers/{id}" )]  
  Customer GetCustomer( string id ):  
  
  //"Do It" -> HTTP PUT  
  [WebInvoke( UriTemplate="customers/{id}", Method="PUT" )]  
  Customer UpdateCustomer( string id, Customer newCustomer );  
}  
```  
  
 To see a complete sample of a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that uses the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model, see [How to: Create a Basic WCF Web HTTP Service](../../../../docs/framework/wcf/feature-details/how-to-create-a-basic-wcf-web-http-service.md)  
  
## UriTemplate Query String Parameters and URLs  
 Web-style services can be called from a Web browser by typing a URL that is associated with a service operation. These service operations may take query string parameters that must be specified in a string form within the URL. The following table shows the types that can be passed within a URL and the format used.  
  
|Type|Format|  
|----------|------------|  
|<xref:System.Byte>|0 - 255|  
|<xref:System.SByte>|-128 - 127|  
|<xref:System.Int16>|-32768 - 32767|  
|<xref:System.Int32>|-2,147,483,648 - 2,147,483,647|  
|<xref:System.Int64>|-9,223,372,036,854,775,808 - 9,223,372,036,854,775,807|  
|<xref:System.UInt16>|0 - 65535|  
|<xref:System.UInt32>|0 - 4,294,967,295|  
|<xref:System.UInt64>|0 - 18,446,744,073,709,551,615|  
|<xref:System.Single>|-3.402823e38 - 3.402823e38 (exponent notation is not required)|  
|<xref:System.Double>|-1.79769313486232e308 - 1.79769313486232e308 (exponent notation is not required)|  
|<xref:System.Char>|Any single character|  
|<xref:System.Decimal>|Any decimal in standard notation (no exponent)|  
|<xref:System.Boolean>|True or False (case insensitive)|  
|<xref:System.String>|Any string (null string is not supported and no escaping is done)|  
|<xref:System.DateTime>|MM/DD/YYYY<br /><br /> MM/DD/YYYY HH:MM:SS [AM&#124;PM]<br /><br /> Month Day Year<br /><br /> Month Day Year HH:MM:SS [AM&#124;PM]|  
|<xref:System.TimeSpan>|DD.HH:MM:SS<br /><br /> Where DD = Days, HH = Hours, MM = minutes, SS = Seconds|  
|<xref:System.Guid>|A GUID, for example:<br /><br /> 936DA01F-9ABD-4d9d-80C7-02AF85C822A8|  
|<xref:System.DateTimeOffset>|MM/DD/YYYY HH:MM:SS MM:SS<br /><br /> Where DD = Days, HH = Hours, MM = minutes, SS = Seconds|  
|Enumerations|The enumeration value for example, which defines the enumeration as shown in the following code.<br /><br /> `public enum Days{ Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };`<br /><br /> Any of the individual enumeration values (or their corresponding integer values) may be specified in the query string.|  
|Types that have a `TypeConverterAttribute` that can convert the type to and from a string representation.|Depends on the Type Converter.|  
  
## Formats and the WCF WEB HTTP Programming Model  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model has new features to work with many different data formats. At the binding layer, the <xref:System.ServiceModel.WebHttpBinding> can read and write the following different kinds of data:  
  
-   XML  
  
-   JSON  
  
-   Opaque binary streams  
  
 This means the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model can handle any type of data but, you may be programming against <xref:System.IO.Stream>.  
  
 [!INCLUDE[netfx35_short](../../../../includes/netfx35-short-md.md)] provides support for JSON data (AJAX) as well as Syndication feeds (including ATOM and RSS). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] these features, see [WCF Web HTTP Formatting](../../../../docs/framework/wcf/feature-details/wcf-web-http-formatting.md)[WCF Syndication Overview](../../../../docs/framework/wcf/feature-details/wcf-syndication-overview.md) and [AJAX Integration and JSON Support](../../../../docs/framework/wcf/feature-details/ajax-integration-and-json-support.md).  
  
## WCF WEB HTTP Programming Model and Security  
 Because the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP programming model does not support the WS-* protocols, the only way to secure a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP service is to expose the service over HTTPS using SSL. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] setting up SSL with [!INCLUDE[iisver](../../../../includes/iisver-md.md)], see [How to implement SSL in IIS](http://go.microsoft.com/fwlink/?LinkId=131613)  
  
## Troubleshooting the WCF WEB HTTP Programming Model  
 When calling WCF WEB HTTP services using a <xref:System.ServiceModel.Channels.ChannelFactoryBase%601> to create a channel, the <xref:System.ServiceModel.Description.WebHttpBehavior> uses the <xref:System.ServiceModel.EndpointAddress> set in the configuration file even if a different <xref:System.ServiceModel.EndpointAddress> is passed to the <xref:System.ServiceModel.Channels.ChannelFactoryBase%601>.  
  
## See Also  
 [WCF Syndication](../../../../docs/framework/wcf/feature-details/wcf-syndication.md)  
 [WCF Web HTTP Programming Object Model](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-object-model.md)  
 [WCF Web HTTP Programming Model](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model.md)
