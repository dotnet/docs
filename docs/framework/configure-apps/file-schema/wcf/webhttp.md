---
title: "&lt;webHttp&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1f9d0754-d41e-44ce-a298-e51cb3096c64
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;webHttp&gt;
This element specifies the <xref:System.ServiceModel.Description.WebHttpBehavior> on an endpoint through configuration. This behavior, when used in conjunction with the [\<webHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/webhttpbinding.md) standard binding, enables the Web programming model for a [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] service.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<webHttp>  
  
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
|defaultBodyStyle|Specifies the default body style of returned messages. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.Web.WebMessageBodyStyle> and [WCF Web HTTP Formatting](../../../../../docs/framework/wcf/feature-details/wcf-web-http-formatting.md).|  
|defaultOutgoingResponseFormat|Specifies the default outgoing response format for messages. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [WCF Web HTTP Formatting](../../../../../docs/framework/wcf/feature-details/wcf-web-http-formatting.md).|  
|faultExceptionEnabled|Gets or sets the flag that specifies whether a FaultException is generated when an internal server error (HTTP status code: 500) occurs.|  
|helpEnabled|Gets or sets a value that determines if the Help page is enabled.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies the set of endpoint behaviors.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.WebHttpElement>  
 <xref:System.ServiceModel.Description.WebHttpBehavior>  
 [AJAX Integration and JSON Support](../../../../../docs/framework/wcf/feature-details/ajax-integration-and-json-support.md)  
 [\<webHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/webhttpbinding.md)
