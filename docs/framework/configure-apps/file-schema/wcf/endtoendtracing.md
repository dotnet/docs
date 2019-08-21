---
title: "<endToEndTracing>"
ms.date: "03/30/2017"
ms.assetid: 5034f5de-bb60-4157-9ad4-58aaade094e0
---
# \<endToEndTracing>
A configuration element that allows you to enable and disable different aspects of end-to-end tracing during the running of a service application.  
  
 \<system.ServiceModel>  
\<diagnostic>  
\<endToEndTracing>  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <diagnostics>
    <endToEndTracing activityTracing="Boolean"
                     messageFlowTracing="Boolean"
                     propagateActivity="Boolean" />
  </diagnostics>
</system.serviceModel>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`activityTracing`|A Boolean value that specifies whether activity tracing is enabled.|  
|`messageFlowTracing`|A Boolean value that specifies whether message flow tracing in enabled.|  
|`propagateActivity`|A Boolean value that specifies whether the propagate attribute is set to true.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<diagnostics>](diagnostics.md)|Defines WCF settings for runtime inspection and control for the administrator.|  
  
## See also

- <xref:System.ServiceModel.Configuration.DiagnosticSection>
- <xref:System.ServiceModel.Diagnostics>
- <xref:System.ServiceModel.Configuration.DiagnosticSection.EndToEndTracing%2A>
- <xref:System.ServiceModel.Configuration.EndToEndTracingElement>
- [End-to-End Tracing](../../../wcf/diagnostics/tracing/end-to-end-tracing.md)
