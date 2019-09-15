---
title: "<system.web> Element (Web Settings)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Web.config configuration file [ASP.NET]"
  - "system.Web element"
  - "<system.Web> element"
  - "ASP.NET configuration system"
  - "configuration files [ASP.NET]"
ms.assetid: 24c4cf4f-ad32-42b2-b040-8e4549e2855e
---
# \<system.web> Element (Web Settings)
Contains information about how the ASP.NET hosting layer manages process-wide behavior.  
  
 \<configuration>  
\<system.web> Element (Web Settings)  
  
## Syntax  
  
```xml  
<system.web>  
</system.web>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<applicationPool>](applicationpool-element-web-settings.md)|Specifies configuration settings for IIS application pools in an aspnet.config file.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration>](../configuration-element.md)|Specifies the root element in every configuration file that is used by the common language runtime and .NET Framework applications.|  
  
## Remarks  
 The `system.web` element and its child `applicationPool` element were added to the .NET Framework as of .NET Framework 3.5 SP1. When you run IIS 7.0 or later versions in Integrated mode, this element combination lets you configure how ASP.NET manages threads and how it queues requests when ASP.NET is hosted in an IIS application pool. If you run IIS 7.0 or later versions in Classic or ISAPI mode, these settings are ignored.  
  
## Example  
 The following example shows how to configure ASP.NET process-wide behavior in the aspnet.config file when ASP.NET is hosted in an IIS application pool. The example assumes that IIS is running in Integrated mode and that the application is using the .NET Framework 3.5 SP1 or a later version. This behavior does not occur in versions of the .NET Framework earlier than the .NET Framework 3.5 SP1. The values in the example are the default values.  
  
```xml  
<configuration>  
  <system.web>  
    <applicationPool   
        maxConcurrentRequestsPerCPU="5000"   
        maxConcurrentThreadsPerCPU="0"   
        requestQueueLimit="5000" />  
  </system.web>  
</configuration>  
```  
  
## Element Information  
  
|||  
|-|-|  
|Namespace||  
|Schema Name||  
|Validation File||  
|Can be Empty||  
  
## See also

- [\<applicationPool> Element (Web Settings)](applicationpool-element-web-settings.md)
