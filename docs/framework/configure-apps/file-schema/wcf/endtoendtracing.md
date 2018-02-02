---
title: "&lt;endToEndTracing&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5034f5de-bb60-4157-9ad4-58aaade094e0
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;endToEndTracing&gt;
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
|[\<diagnostics>](../../../../../docs/framework/configure-apps/file-schema/wcf/diagnostics.md)|Defines WCF settings for runtime inspection and control for the administrator.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.DiagnosticSection>  
 <xref:System.ServiceModel.Diagnostics>  
 <xref:System.ServiceModel.Configuration.DiagnosticSection.EndToEndTracing%2A>  
 <xref:System.ServiceModel.Configuration.EndToEndTracingElement>  
 [End-to-End Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/end-to-end-tracing.md)
