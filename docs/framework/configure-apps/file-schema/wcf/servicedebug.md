---
title: "&lt;serviceDebug&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6d7ea986-f232-49fe-842c-f934d9966889
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;serviceDebug&gt;
Specifies debugging and help information features for a [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] service.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceDebug>  
  
## Syntax  
  
```xml  
<serviceDebug     httpHelpPageBinding="String"    httpHelpPageBindingConfiguration="String"  
    httpHelpPageEnabled="Boolean"  
    httpHelpPageUrl="Uri"  
    httpsHelpPageBinding="String"    httpsHelpPageBindingConfiguration="String"  
    httpsHelpPageEnabled="Boolean"  
    httpsHelpPageUrl="Uri"  
    includeExceptionDetailInFaults="Boolean" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|httpHelpPageBinding|A string value that specifies the type of binding to be used when HTTP is utilized to access the service help page.<br /><br /> Only bindings with inner binding elements that support <xref:System.ServiceModel.Channels.IReplyChannel?displayProperty=nameWithType> will be supported. Additionally, the <xref:System.ServiceModel.Channels.MessageVersion?displayProperty=nameWithType> property of the binding must be <xref:System.ServiceModel.Channels.MessageVersion.None?displayProperty=nameWithType>.|  
|httpHelpPageBindingConfiguration|A string that specifies the name of the binding that is specified in the `httpHelpPageBinding` attribute, which references to the additional configuration information of this binding. The same name must be defined in the `<bindings>` section.|  
|httpHelpPageEnabled|A Boolean value that controls whether [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] publishes an HTML help page at the address specified by the `httpHelpPageUrl` attribute. The default is `true`.<br /><br /> You can set this property to `false` to disable the publication of an HTML help page visible to HTML browsers.<br /><br /> To ensure the HTML help page is published at the location controlled by the `httpHelpPageUrl` attribute, you must set this attribute to `true`. In addition, one of the following conditions must also be met:<br /><br /> -   The `httpHelpPageUrl` attribute is an absolute address that supports the HTTP protocol scheme.<br />-   There is a base address for the service that supports the HTTP protocol scheme.<br /><br /> Although an exception is thrown if an absolute address that does not support the HTTP protocol scheme is assigned to the `httpHelpPageUrl` attribute, any other scenario in which neither of the preceding criteria is met results in no exception and no HTML help page.|  
|httpHelpPageUrl|A URI that specifies the relative or absolute HTTP-based URL of the custom HTML help file the user sees when the endpoint is viewed using an HTML browser.<br /><br /> You can use this attribute to enable the use of a custom HTML help file that is returned from an HTTP/Get request, for example, from an HTML browser. The location of the HTML help file is resolved as follows.<br /><br /> 1.  If the value of this attribute is a relative address, the location of the HTML help file is the value of the service base address that supports HTTP requests, plus this property value.<br />2.  If the value of this attribute is an absolute address and supports HTTP requests, the location of the HTML help file is the value of this property.<br />3.  If the value of this attribute is absolute but does not support HTTP requests, an exception is thrown.<br /><br /> This attribute is valid only when the `httpHelpPageEnabled` attribute is `true`.|  
|httpsHelpPageBinding|A string value that specifies the type of binding to be used when HTTPS is utilized to access the service help page.<br /><br /> Only bindings with inner binding elements that support <xref:System.ServiceModel.Channels.IReplyChannel> will be supported. Additionally, the <xref:System.ServiceModel.Channels.MessageVersion?displayProperty=nameWithType> property of the binding must be <xref:System.ServiceModel.Channels.MessageVersion.None?displayProperty=nameWithType>.|  
|httpsHelpPageBindingConfiguration|A string that specifies the name of the binding that is specified in the `httpsHelpPageBinding` attribute, which references to the additional configuration information of this binding. The same name must be defined in the `<bindings>` section.|  
|httpsHelpPageEnabled|A Boolean value that controls whether [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] publishes an HTML help page at the address specified by the `httpsHelpPageUrl` attribute. The default is `true`.<br /><br /> You can set this property to `false` to disable the publication of an HTML help page visible to HTML browsers.<br /><br /> To ensure the HTML help page is published at the location controlled by the `httpsHelpPageUrl` attribute, you must set this attribute to `true`. In addition, one of the following conditions must also be met:<br /><br /> -   The `httpsHelpPageUrl` attribute is an absolute address that supports the HTTPS protocol scheme.<br />-   There is a base address for the service that supports the HTTPS protocol scheme.<br /><br /> Although an exception is thrown if an absolute address that does not support the HTTPS protocol scheme is assigned to the `httpsHelpPageUrl` attribute, any other scenario in which neither of the preceding criteria is met results in no exception and no HTML help page.|  
|httpsHelpPageUrl|A URI that specifies the relative or absolute HTTPS-based URL of the custom HTML help file the user sees when the endpoint is viewed using an HTML browser.<br /><br /> You can use this attribute to enable the use of a custom HTML help file that is returned from an HTTPS/Get request, for example, from an HTML browser. The location of the HTML help file is resolved as follows:<br /><br /> -   If the value of this property is a relative address, the location of the HTML help file is the value of the service base address that supports HTTPS requests, plus this property value.<br />-   If the value of this property is an absolute address and supports HTTPS requests, the location of the HTML help file is the value of this property.<br />-   If the value of this property is absolute but does not support HTTPS requests, an exception is thrown.<br /><br /> This attribute is valid only when the `httpHelpPageEnabled` attribute is `true`.|  
|includeExceptionDetailInFaults|A value that specifies whether to include managed exception information in the detail of SOAP faults returned to the client for debugging purposes. The default is `false`.<br /><br /> If you set this attribute to `true`, you can enable the flow of managed exception information to the client for debugging purposes, as well as the publication of HTML information files for users browsing the service in Web browsers. **Caution:**  Returning managed exception information to clients  can be a security risk. This is because exception details expose information about the internal service implementation that could be used by unauthorized clients.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  
 Setting `includeExceptionDetailInFaults` to `true` allows the service to return any exception that is thrown by the application code even if the exception is not declared using the <xref:System.ServiceModel.FaultContractAttribute>. This setting is useful when debugging cases where the server is throwing an unexpected exception. By using this attribute, a serialized form of the unknown exception is returned and you can examine more details of the exception.  
  
> [!CAUTION]
>  Returning managed exception information to clients can be a security risk because exception details expose information about the internal service implementation that could be used by unauthorized clients. Because of the security issues involved, it is strongly recommended that you only do so in controlled debugging scenarios. You should set `includeExceptionDetailInFaults` to `false` when deploying your application.  
  
 For details about the security issues related to managed exception, see [Specifying and Handling Faults in Contracts and Services](../../../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md). For a code sample, see [Service Debug Behavior](../../../../../docs/framework/wcf/samples/service-debug-behavior.md).  
  
 You can also set `httpsHelpPageEnabled` and `httpsHelpPageUrl` to enable or disable the help page. Each service can optionally expose a help page that contains information about the service including the endpoint to get WSDL for the service. This can be enabled by setting `httpHelpPageEnabled` to `true`. This enables the help page to be returned to a GET request to the base address of the service. You can change this address by setting the `httpHelpPageUrl` attribute. In addition, you can make this secure by using HTTPS instead of HTTP.  
  
 The optional `httpHelpPageBinding` and `httpHelpPageBinding` attributes allow you to configure the bindings used to access the service web page. If they are not specified, the default bindings (`HttpTransportBindingElement`, in the case of HTTP and `HttpsTransportBindingElement`, in the case of HTTPS) are used for service help page access as appropriate. Notice that you cannot use these attributes with the built-in WCF bindings. Only bindings with inner binding elements that support xref:System.ServiceModel.Channels.IReplyChannel> will be supported. Additionally, the <xref:System.ServiceModel.Channels.MessageVersion?displayProperty=nameWithType> property of the binding must be <xref:System.ServiceModel.Channels.MessageVersion.None?displayProperty=nameWithType>.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ServiceDebugElement>  
 <xref:System.ServiceModel.Description.ServiceDebugBehavior>  
 [Specifying and Handling Faults in Contracts and Services](../../../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)  
 [Handling Exceptions and Faults](../../../../../docs/framework/wcf/extending/handling-exceptions-and-faults.md)  
 [Service Debug Behavior](../../../../../docs/framework/wcf/samples/service-debug-behavior.md)
