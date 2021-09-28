---
description: "Learn more about: <diagnostics> for Activation"
title: "<diagnostics> for Activation"
ms.date: "03/30/2017"
ms.assetid: 1486e0eb-fe2a-46c3-b584-c924889477dd
---
# \<diagnostics> for Activation

Configures Windows Communication Foundation (WCF) listener's diagnostics functionalities.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel.activation>**](system-servicemodel-activation.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<diagnostics>**  
  
## Syntax  
  
```xml  
<configuration>
  <system.serviceModel.activation>
    <diagnostics performanceCountersEnabled="Boolean" />
  </system.serviceModel.activation>
</configuration>
```  
  
## Type  

 `Type`  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`performanceCountersEnabled`|A Boolean value that indicates whether performance counters are enabled for diagnostic purposes.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.serviceModel.activation>](system-servicemodel-activation.md)|Contains configuration settings for the listener process SMSvcHost.exe.|  
  
## See also

- <xref:System.ServiceModel.Activation.Configuration.DiagnosticSection>
