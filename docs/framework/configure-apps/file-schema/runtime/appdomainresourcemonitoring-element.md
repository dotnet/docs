---
description: "Learn more about: <appDomainResourceMonitoring> Element"
title: "<appDomainResourceMonitoring> Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "appDomainResourceMonitoring element"
  - "<appDomainResourceMonitoring> element"
ms.assetid: 02119ab6-1e91-448e-97ad-e7b2e5c4bbbd
---
# \<appDomainResourceMonitoring> Element

Instructs the runtime to collect statistics on all application domains in the process for the life of the process.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<appDomainResourceMonitoring>**  
  
## Syntax  
  
```xml  
<appDomainResourceMonitoring
   enabled="true|false"/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime collects statistics for application domain resource monitoring.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`true`|Statistics for application domain resource monitoring are collected.|  
|`false`|Statistics for application domain resource monitoring are not collected.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  

 Application domain resource monitoring is available through the managed application domain class, the hosting [ICLRAppDomainResourceMonitor](../../../unmanaged-api/hosting/iclrappdomainresourcemonitor-interface.md) interface, and event tracing for Windows (ETW). When monitoring is enabled, statistics are collected for all application domains in the process for the life of the process.  
  
 To enable monitoring from managed code, use the <xref:System.AppDomain.MonitoringIsEnabled%2A> property.  
  
 This configuration element is available only in the .NET Framework 4 and later.  
  
## Example  

 The following example shows how to enable application domain resource monitoring.  
  
```xml  
<configuration>  
   <runtime>  
      <appDomainResourceMonitoring enabled="true"/>  
   </runtime>  
</configuration>  
```  
  
## See also

- <xref:System.AppDomain.MonitoringIsEnabled%2A?displayProperty=nameWithType>
- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
