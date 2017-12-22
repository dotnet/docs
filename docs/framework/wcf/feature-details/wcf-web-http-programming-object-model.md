---
title: "WCF Web HTTP Programming Object Model"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ed96b5fc-ca2c-4b0d-bdba-d06b77c3cb2a
caps.latest.revision: 40
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Web HTTP Programming Object Model
The WCF WEB HTTP  Programming Model allows developers to expose [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] Web services through basic HTTP requests without requiring SOAP. The WCF WEB HTTP  Programming Model is built on top of the existing [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] extensibility model. It defines the following classes:  
  
 **Programming Model:**  
  
-   <xref:System.ServiceModel.Web.AspNetCacheProfileAttribute>  
  
-   <xref:System.ServiceModel.Web.WebGetAttribute>  
  
-   <xref:System.ServiceModel.Web.WebInvokeAttribute>  
  
-   <xref:System.ServiceModel.Web.WebServiceHost>  
  
 **Channels and Dispatcher Infrastructure:**  
  
-   <xref:System.ServiceModel.WebHttpBinding>  
  
-   <xref:System.ServiceModel.Description.WebHttpBehavior>  
  
 **Utility Classes and Extensibility Points:**  
  
-   <xref:System.UriTemplate>  
  
-   <xref:System.UriTemplateTable>  
  
-   <xref:System.ServiceModel.Dispatcher.QueryStringConverter>  
  
-   <xref:System.ServiceModel.Dispatcher.WebHttpDispatchOperationSelector>  
  
## AspNetCacheProfileAttribute  
 The <xref:System.ServiceModel.Web.AspNetCacheProfileAttribute>, when applied to a service operation, indicates the ASP.NET output cache profile in the configuration file that should be used by to cache responses from the operation in the ASP .NET Output Cache. This property takes only one parameter, the cache profile name that specifies the cache settings in the configuration file.  
  
## WebGetAttribute  
 The <xref:System.ServiceModel.Web.WebGetAttribute> attribute is used to mark a service operation as one that responds to HTTP GET requests. It is a passive operation behavior (the <xref:System.ServiceModel.Description.IOperationBehavior> methods do nothing) that adds metadata to the operation description. Applying the <xref:System.ServiceModel.Web.WebGetAttribute> has no effect unless a behavior that looks for this metadata in the operation description (specifically, the <xref:System.ServiceModel.Description.WebHttpBehavior>) is added to the service's behavior collection. The <xref:System.ServiceModel.Web.WebGetAttribute> attribute takes the optional parameters shown in the following table.  
  
|Parameter|Description|  
|---------------|-----------------|  
|`BodyStyle`|Controls whether to wrap requests and responses sent to and received from the service operation the attribute is applied to.|  
|`RequestFormat`|Controls how request messages are formatted.|  
|`ResponseFormat`|Controls how response messages are formatted.|  
|`UriTemplate`|Specifies the URI template that controls what HTTP requests get mapped to the service operation the attribute is applied to.|  
  
## WebHttpBinding  
 The <xref:System.ServiceModel.WebHttpBinding> class incorporates support for XML, JSON, and raw binary data using the <xref:System.ServiceModel.Channels.WebMessageEncodingBindingElement>. It is composed of an <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>, <xref:System.ServiceModel.Channels.HttpTransportBindingElement> and a <xref:System.ServiceModel.WebHttpSecurity> object. The <xref:System.ServiceModel.WebHttpBinding> is designed to be used in conjunction with the <xref:System.ServiceModel.Description.WebHttpBehavior>.  
  
## WebInvokeAttribute  
 The <xref:System.ServiceModel.Web.WebInvokeAttribute> attribute is similar to the <xref:System.ServiceModel.Web.WebGetAttribute>, but it is used to mark a service operation as one that responds to HTTP requests other than GET. It is a passive operation behavior (the <xref:System.ServiceModel.Description.IOperationBehavior> methods do nothing) that adds metadata to the operation description. Applying the <xref:System.ServiceModel.Web.WebInvokeAttribute> has no effect unless a behavior that looks for this metadata in the operation description (specifically, the <xref:System.ServiceModel.Description.WebHttpBehavior>) is added to the service's behavior collection.  
  
 The <xref:System.ServiceModel.Web.WebInvokeAttribute> attribute takes the optional parameters shown in the following table.  
  
|Parameter|Description|  
|---------------|-----------------|  
|`BodyStyle`|Controls whether to wrap requests and responses sent to and received from the service operation the attribute is applied to.|  
|`Method`|Specifies the HTTP method the service operation is mapped to.|  
|`RequestFormat`|Controls how request messages are formatted.|  
|`ResponseFormat`|Controls how response messages are formatted.|  
|`UriTemplate`|Specifies the URI template that controls what GET requests get mapped to the service operation the attribute is applied to.|  
  
## UriTemplate  
 The <xref:System.UriTemplate> class allows you to define a set of structurally similar URIs. Templates are composed of two parts, a path and a query. A path consists of a series of segments delimited by a slash (/). Each segment can have a literal value, a variable value (written within curly braces [{ }], constrained to match the contents of exactly one segment), or a wildcard (written as an asterisk [\*], which matches "the rest of the path"), which must appear at the end of the path. The query expression can be omitted entirely. If present, it specifies an unordered series of name/value pairs. Elements of the query expression can be either literal pairs (?x=2) or variable pairs (?x={*value*}). Unpaired values are not permitted. <xref:System.UriTemplate> is used internally by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP  Programming Model to map specific URIs or groups of URIs to service operations.  
  
## UriTemplateTable  
 The <xref:System.UriTemplateTable> class represents an associative set of <xref:System.UriTemplate> objects bound to an object of the developer's choosing. It lets you match candidate Uniform Resource Identifiers (URIs) against the templates in the set and retrieve the data associated with the matching templates. <xref:System.UriTemplateTable> is used internally by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP  Programming Model to map specific URIs or groups of URIs to service operations.  
  
## WebServiceHost  
 <xref:System.ServiceModel.Web.WebServiceHost> extends the <xref:System.ServiceModel.ServiceHost> to make it easier to host a non-SOAP Web-style service. If <xref:System.ServiceModel.Web.WebServiceHost> finds no endpoints in the service description, it automatically creates a default endpoint at the service's base address. When creating a default HTTP endpoint, the <xref:System.ServiceModel.Web.WebServiceHost> also disables the HTTP Help page and the Web Services Description Language (WSDL) GET functionality so the metadata endpoint does not interfere with the default HTTP endpoint. <xref:System.ServiceModel.Web.WebServiceHost> also ensures that all endpoints that use <xref:System.ServiceModel.WebHttpBinding> have the required <xref:System.ServiceModel.Description.WebHttpBehavior> attached. Finally, <xref:System.ServiceModel.Web.WebServiceHost> automatically configures the endpoint's binding to work with the associated Internet Information Services (IIS) security settings when used in a secure virtual directory.  
  
## WebServiceHostFactory  
 The <xref:System.ServiceModel.Activation.WebServiceHostFactory> class is used to dynamically create a <xref:System.ServiceModel.Web.WebServiceHost> when a service is hosted under Internet Information Services (IIS) or Windows Process Activation Service (WAS). Unlike a self-hosted service where the hosting application instantiates the <xref:System.ServiceModel.Web.WebServiceHost>, services hosted under IIS or WAS use this class to create the <xref:System.ServiceModel.Web.WebServiceHost> for the service. The <xref:System.ServiceModel.Activation.WebServiceHostFactory.CreateServiceHost%28System.Type%2CSystem.Uri%5B%5D%29> method is called when a incoming request for the service is received.  
  
## WebHttpBehavior  
 The <xref:System.ServiceModel.Description.WebHttpBehavior> class supplies the necessary formatters, operation selectors, and so on, required for Web-style service support at the Service Model layer. This is implemented as an endpoint behavior (used in conjunction with the <xref:System.ServiceModel.WebHttpBinding>) and allows formatters and operation selectors to be specified for each endpoint, which enables the same service implementation to expose both SOAP and POX endpoints.  
  
### Extending WebHttpBehavior  
 <xref:System.ServiceModel.Description.WebHttpBehavior> is extensible by using a number of virtual methods: <xref:System.ServiceModel.Description.WebHttpBehavior.GetOperationSelector%28System.ServiceModel.Description.ServiceEndpoint%29>, <xref:System.ServiceModel.Description.WebHttpBehavior.GetReplyClientFormatter%28System.ServiceModel.Description.OperationDescription%2CSystem.ServiceModel.Description.ServiceEndpoint%29>, <xref:System.ServiceModel.Description.WebHttpBehavior.GetRequestClientFormatter%28System.ServiceModel.Description.OperationDescription%2CSystem.ServiceModel.Description.ServiceEndpoint%29>, <xref:System.ServiceModel.Description.WebHttpBehavior.GetReplyDispatchFormatter%28System.ServiceModel.Description.OperationDescription%2CSystem.ServiceModel.Description.ServiceEndpoint%29>, and <xref:System.ServiceModel.Description.WebHttpBehavior.GetRequestDispatchFormatter%28System.ServiceModel.Description.OperationDescription%2CSystem.ServiceModel.Description.ServiceEndpoint%29>. Developers can derive a class from <xref:System.ServiceModel.Description.WebHttpBehavior> and override these methods to customize the default behavior.  
  
 The <xref:System.ServiceModel.Description.WebScriptEnablingBehavior> is an example of extending <xref:System.ServiceModel.Description.WebHttpBehavior>. <xref:System.ServiceModel.Description.WebScriptEnablingBehavior> enables [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] endpoints to receive HTTP requests from a browser-based ASP.NET AJAX client. The [AJAX Service Using HTTP POST](../../../../docs/framework/wcf/samples/ajax-service-using-http-post.md) is an example of using this extensibility point.  
  
> [!WARNING]
>  When using the <xref:System.ServiceModel.Description.WebScriptEnablingBehavior>, <xref:System.UriTemplate> are not supported within <xref:System.ServiceModel.Web.WebGetAttribute> or <xref:System.ServiceModel.Web.WebInvokeAttribute> attributes.  
  
## WebHttpDispatchOperationSelector  
 The <xref:System.ServiceModel.Dispatcher.WebHttpDispatchOperationSelector> class uses <xref:System.UriTemplate> and <xref:System.UriTemplateTable> classes to dispatch calls to service operations.  
  
## Compatibility  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP Programming Model does not use SOAP-based messages and therefore does not support the WS-* protocols. You can however, expose the same contract by two different endpoint: one using SOAP and the other not using SOAP. See [How to: Expose a Contract to SOAP and Web Clients](../../../../docs/framework/wcf/feature-details/how-to-expose-a-contract-to-soap-and-web-clients.md) for an example.  
  
## Security  
 Because the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP  Programming Model does not support the WS-* protocols the only way to secure a Web service built on the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP  Programming Model is to expose your service using SSL. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] setting up SSL with [!INCLUDE[iisver](../../../../includes/iisver-md.md)] see [How to implement SSL in IIS](http://go.microsoft.com/fwlink/?LinkId=131613)  
  
## See Also  
 <xref:System.ServiceModel.WebHttpBinding>  
 <xref:System.ServiceModel.Web.WebGetAttribute>  
 <xref:System.ServiceModel.Web.WebInvokeAttribute>  
 <xref:System.ServiceModel.Description.WebHttpBehavior>  
 <xref:System.ServiceModel.Dispatcher.WebHttpDispatchOperationSelector>  
 [WCF Web HTTP Programming Model Overview](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model-overview.md)
