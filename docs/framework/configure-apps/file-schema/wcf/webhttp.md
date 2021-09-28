---
description: "Learn more about: <webHttp>"
title: "<webHttp>"
ms.date: "03/30/2017"
ms.assetid: 1f9d0754-d41e-44ce-a298-e51cb3096c64
---
# \<webHttp>

This element specifies the <xref:System.ServiceModel.Description.WebHttpBehavior> on an endpoint through configuration. This behavior, when used in conjunction with the [\<webHttpBinding>](webhttpbinding.md) standard binding, enables the Web programming model for a Windows Communication Foundation (WCF) service.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<webHttp>**  
  
## Syntax  
  
```xml  
<webHttp />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|automaticFormatSelectionEnabled|When this property is set to `true`, the WCF infrastructure determines the best format to use. Automatic format selection is disabled by default for backwards compatibility. Automatic format selection can be enabled programmatically or through configuration.|  
|defaultBodyStyle|Specifies the default body style of returned messages. For more information, see <xref:System.ServiceModel.Web.WebMessageBodyStyle> and [WCF Web HTTP Formatting](../../../wcf/feature-details/wcf-web-http-formatting.md).|  
|defaultOutgoingResponseFormat|Specifies the default outgoing response format for messages. For more information, see [WCF Web HTTP Formatting](../../../wcf/feature-details/wcf-web-http-formatting.md).|  
|faultExceptionEnabled|Gets or sets the flag that specifies whether a FaultException is generated when an internal server error (HTTP status code: 500) occurs.|  
|helpEnabled|Gets or sets a value that determines if the Help page is enabled.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-endpointbehaviors.md)|Specifies the set of endpoint behaviors.|  
  
## See also

- <xref:System.ServiceModel.Configuration.WebHttpElement>
- <xref:System.ServiceModel.Description.WebHttpBehavior>
- [AJAX Integration and JSON Support](../../../wcf/feature-details/ajax-integration-and-json-support.md)
- [\<webHttpBinding>](webhttpbinding.md)
