---
title: "<performanceCounter> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/settings/performanceCounters"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#performanceCounters"
helpviewer_keywords: 
  - "performanceCounter element"
  - "<performanceCounter> element"
ms.assetid: 3afa1586-e1b8-473d-8985-c3fc90cf561b
---
# \<performanceCounter> Element (Network Settings)
Enables or disables networking performance counters.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<settings>**](settings-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<performanceCounters>**

## Syntax  
  
```xml  
<performanceCounters  
  enabled="true|false"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Specifies whether the networking performance counters are enabled. The default value is `false`.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[settings](settings-element-network-settings.md)|Configures basic network options for the <xref:System.Net> namespace.|  
  
## Remarks  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
 Networking performance counters need to be enabled in the configuration file to be used. All networking performance counters are enabled or disabled with a single setting in the configuration file. Individual networking performance counters cannot be enabled or disabled. For more information on the specific networking performance counters, see [Networking performance counters](../../../debug-trace-profile/performance-counters.md#networking-performance-counters).  
  
 The default value is that networking performance counters are disabled.  
  
 The <xref:System.Net.Configuration.PerformanceCountersElement.Enabled%2A?displayProperty=nameWithType> property can be used to get the current value of the **enabled** attribute from applicable configuration files.  
  
## Example  
 The following example shows how to configure the <xref:System.Net> and related namespaces to enable networking performance counters.  
  
```xml  
<configuration>  
  <system.net>  
    <settings>  
      <performanceCounters  
        enabled="true"  
      />  
    </settings>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.Configuration.PerformanceCountersElement?displayProperty=nameWithType>
- <xref:System.Net.Configuration.PerformanceCountersElement.Enabled%2A?displayProperty=nameWithType>
- [Network Settings Schema](index.md)
- [Networking Performance Counters](../../../debug-trace-profile/performance-counters.md#networking-performance-counters)
