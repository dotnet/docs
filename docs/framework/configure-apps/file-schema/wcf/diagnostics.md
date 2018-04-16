---
title: "&lt;diagnostics&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0c2f95c4-cc12-4fb5-a70c-7fc6fa95db58
caps.latest.revision: 20
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;diagnostics&gt;
The `diagnostics` element defines settings that can be used by an administrator for run-time inspection and control.  
  
 \<system.ServiceModel>  
\<diagnostics>  
  
## Syntax  
  
```xml  
<system.serviceModel>  
  <diagnostics 
      etwProviderId="String"       
      performanceCounters="Off/ServiceOnly/All/Default"              
      wmiProviderEnabled="Boolean" >       
    <endToEndTracing 
        activityTracing="Boolean"  
        messageFlowTracing="Boolean"  
        propagateActivity="Boolean" />  
    <messageLogging 
        logEntireMessage="Boolean"  
        logMalformedMessages="Boolean"  
        logMessagesAtServiceLevel="Boolean"  
        logMessagesAtTransportLevel="Boolean"  
        maxMessagesToLog="Integer"  
        maxSizeOfMessageToLog="Integer" >  
      <filters>  
        <clear />  
      </filters>  
    </messageLogging>  
  </diagnostics>  
</system.serviceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|etwProviderId|A string that specifies the identifier for the Event-Tracing provider, which writes events to ETW sessions.|  
|performanceCounters|Specifies whether performance counters for the assembly are enabled. Valid values are<br /><br /> -   Off: Performance counters are disabled.<br />-   ServiceOnly: Only performance counters relevant to this service is enabled.<br />-   All: Performance counters can be viewed at runtime.<br />-   Default: A single performance counter instance _WCF_Admin is created. This instance is used to enable the collection of SQM data for used by the infrastructure. None of the counter values for this instance are updated and therefore will remain at zero. This is the default value if no configuration is present for WCF.|  
|wmiProviderEnabled|A Boolean value that specifies whether the WMI provider for the assembly is enabled. The WMI provider is required for user to gain run-time access to the inspection and control features of Windows Communication Foundation (WCF). The default is `false`.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<endToEndTracing>](../../../../../docs/framework/configure-apps/file-schema/wcf/endtoendtracing.md)|A configuration element that allows you to enable and disable different aspects of end-to-end tracing during the running of a service application.|  
|[\<messageLogging>](../../../../../docs/framework/configure-apps/file-schema/wcf/messagelogging.md)|Describes the settings for WCF message logging.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|serviceModel|The root element of all WCF configuration elements.|  
  
## Remarks  
 The `diagnostics` section defines the diagnostics settings for all services located in an assembly. It is not possible to define separate diagnostics settings at the service level unless there is only one service in the assembly. Attributes are set according to the requirements of the section.  
  
## Example  
  
```xml  
<diagnostics
    wmiProviderEnabled="false"  
    performanceCounters="all">  
  <messageLogging 
      logEntireMessage="true"  
      logMalformedMessages="true"  
      logMessagesAtServiceLevel="true"  
      logMessagesAtTransportLevel="true"  
      maxMessagesToLog="42"  
      maxSizeOfMessageToLog="42">  
    <filters>  
      <clear />  
    </filters>  
  </messageLogging>  
</diagnostics>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.DiagnosticSection>  
 <xref:System.ServiceModel.Diagnostics>
