---
title: "&lt;webHttpEndpoint&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ecaaeb6f-ebd0-411d-8b53-92477cd45347
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;webHttpEndpoint&gt;
This configuration element defines a standard endpoint with a fixed [\<webHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/webhttpbinding.md) binding that automatically adds the [\<webHttp>](../../../../../docs/framework/configure-apps/file-schema/wcf/webhttp.md) behavior. Use this endpoint when writing a REST service.  
  
\<system.ServiceModel>  
\<standardEndpoints>  
  
## Syntax  
  
```xml  
<system.serviceModel>  
  <standardEndpoints>
    <webHttpEndpoint>
      <standardEndpoint automaticFormatSelectionEnabled="String" 
                        defaultOutgoingResponseFormat="Xml/Json" 
                        helpEnabled="Boolean" 
                        webEndpointType="String"/>
    </webHttpEndpoint>
  </standardEndpoints>  
</system.serviceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|automaticFormatSelectionEnabled|A Boolean value that indicates whether automatic format selection is enabled.<br /><br /> When automatic format selection is enabled, the infrastructure parses the `Accept` header of the request message and determines the most appropriate response format. If the `Accept` header does not specify a suitable response format, the infrastructure uses the `Content-Type` of the request message or the default response format of the operation.|  
|defaultOutgoingResponseFormat|An attribute that specifies the default outgoing response format. This attribute is of the <xref:System.ServiceModel.Web.WebMessageFormat> type|  
|helpEnabled|A Boolean value that indicates whether the HTTP help page is enabled for the endpoint.|  
|webEndpointType|A string that specifies the type of the endpoint.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<standardEndpoints>](../../../../../docs/framework/configure-apps/file-schema/wcf/standardendpoints.md)|A collection of standard endpoints that are pre-defined endpoints with one or more of their properties (address, binding, contract) fixed.|  
  
## See Also  
 <xref:System.ServiceModel.Description.WebHttpEndpoint>  
 <xref:System.ServiceModel.Configuration.WebHttpEndpointElement>
