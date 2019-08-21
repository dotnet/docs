---
title: "<webHttpEndpoint>"
ms.date: "03/30/2017"
ms.assetid: ecaaeb6f-ebd0-411d-8b53-92477cd45347
---
# \<webHttpEndpoint>
This configuration element defines a standard endpoint with a fixed [\<webHttpBinding>](webhttpbinding.md) binding that automatically adds the [\<webHttp>](webhttp.md) behavior. Use this endpoint when writing a REST service.  
  
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
                        webEndpointType="String" />
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
|[\<standardEndpoints>](standardendpoints.md)|A collection of standard endpoints that are pre-defined endpoints with one or more of their properties (address, binding, contract) fixed.|  
  
## See also

- <xref:System.ServiceModel.Description.WebHttpEndpoint>
- <xref:System.ServiceModel.Configuration.WebHttpEndpointElement>
