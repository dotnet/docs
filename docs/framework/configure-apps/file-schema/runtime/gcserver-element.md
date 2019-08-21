---
title: "<gcServer> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/gcServer"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#gcServer"
helpviewer_keywords: 
  - "gcServer element"
  - "<gcServer> element"
ms.assetid: 8d25b80e-2581-4803-bd87-a59528e3cb03
author: "rpetrusha"
ms.author: "ronpet"
---
# \<gcServer> Element
Specifies whether the common language runtime runs server garbage collection.  
  
 \<configuration>  
\<runtime>  
\<gcServer>  
  
## Syntax  
  
```xml  
<gcServer    
   enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime runs server garbage collection.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|Does not run server garbage collection. This is the default.|  
|`true`|Runs server garbage collection.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 The common language runtime (CLR) supports two types of garbage collection: workstation garbage collection, which is available on all systems, and server garbage collection, which is available on multiprocessor systems. You use the `<gcServer>` element to control the type of garbage collection the CLR performs. Use the <xref:System.Runtime.GCSettings.IsServerGC%2A?displayProperty=nameWithType> property to determine if server garbage collection is enabled.  
  
 For single-processor computers, the default workstation garbage collection should be the fastest option. Either workstation or server can be used for two-processor computers. Server garbage collection should be the fastest option for more than two processors.  
  
 This element can be used only in the application configuration file; it is ignored if it is in the machine configuration file.  
  
> [!NOTE]
> In the .NET Framework 4 and earlier versions, concurrent garbage collection is not available when server garbage collection is enabled. Starting with the .NET Framework 4.5, server garbage collection is concurrent. To use non-concurrent server garbage collection, set the `<gcServer>` element to `true` and the [\<gcConcurrent> element](gcconcurrent-element.md) to `false`.  
  
## Example  
 The following example enables server garbage collection.  
  
```xml  
<configuration>  
   <runtime>  
      <gcServer enabled="true"/>  
   </runtime>  
</configuration>  
```  
  
## See also

- <xref:System.Runtime.GCSettings.IsServerGC%2A?displayProperty=nameWithType>
- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [To disable concurrent garbage collection](gcconcurrent-element.md#to-disable-background-garbage-collection)
