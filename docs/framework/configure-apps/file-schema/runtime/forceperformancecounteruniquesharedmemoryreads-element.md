---
description: "Learn more about: <forcePerformanceCounterUniqueSharedMemoryReads> Element"
title: "<forcePerformanceCounterUniqueSharedMemoryReads> Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "forcePerformanceCounterUniqueSharedMemoryReads element"
  - "<forcePerformanceCounterUniqueSharedMemoryReads> element"
ms.assetid: 91149858-4810-4f65-9b48-468488172c9b
---
# \<forcePerformanceCounterUniqueSharedMemoryReads> Element

Specifies whether PerfCounter.dll uses the CategoryOptions registry setting in a .NET Framework version 1.1 application to determine whether to load performance counter data from category-specific shared memory or global memory.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<forcePerformanceCounterUniqueSharedMemoryReads>**  
  
## Syntax  
  
```xml  
<forcePerformanceCounterUniqueSharedMemoryReads
enabled="true|false"/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Indicates whether PerfCounter.dll uses the CategoryOptions registry setting to determine whether to load performance counter data from category-specific shared memory or global memory.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|PerfCounter.dll does not use the CategoryOptions registry setting This is the default.|  
|`true`|PerfCounter.dll does use the CategoryOptions registry setting.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  

 In versions of the .NET Framework before the .NET Framework 4, the version of PerfCounter.dll that was loaded corresponded to the runtime that was loaded in the process. If a computer had both the .NET Framework version 1.1 and the .NET Framework 2.0 installed, a .NET Framework 1.1 application would load the .NET Framework 1.1 version of PerfCounter.dll. Starting with the .NET Framework 4, the newest installed version of PerfCounter.dll is loaded. This means that a .NET Framework 1.1 application will load the .NET Framework 4 version of PerfCounter.dll if the .NET Framework 4 is installed on the computer.  
  
 Starting with the .NET Framework 4, when consuming performance counters, PerfCounter.dll checks the CategoryOptions registry entry for each provider to determine whether it should read from category-specific shared memory or global shared memory. The .NET Framework 1.1 PerfCounter.dll does not read that registry entry, because it is not aware of category-specific shared memory; it always reads from global shared memory.  
  
 For backward compatibility, the .NET Framework 4 PerfCounter.dll does not check the CategoryOptions registry entry when running in a .NET Framework 1.1 application. It simply uses global shared memory, just like the .NET Framework 1.1 PerfCounter.dll. However, you can instruct the .NET Framework 4 PerfCounter.dll to check the registry setting by enabling the `<forcePerformanceCounterUniqueSharedMemoryReads>` element.  
  
> [!NOTE]
> Enabling the `<forcePerformanceCounterUniqueSharedMemoryReads>` element does not guarantee that category-specific shared memory will be used. Setting enabled to `true` only causes PerfCounter.dll to reference the CategoryOptions registry setting. The default setting for CategoryOptions is to use category-specific shared memory; however, you can change CategoryOptions to indicate that global shared memory should be used.  
  
 The registry key that contains the CategoryOptions setting is HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\\<categoryName\>\Performance. By default, CategoryOptions is set to 3, which instructs PerfCounter.dll to use category-specific shared memory. If CategoryOptions is set to 0, PerfCounter.dll uses global shared memory. Instance data will be reused only if the name of the instance being created is identical to the instance being reused. All versions will be able to write to the category. If CategoryOptions is set to 1, global shared memory is used, but instance data can be reused if the category name is the same length as the category being reused.  
  
 The settings 0 and 1 can lead to memory leaks and the filling up of performance counter memory.  
  
## Example  

 The following example shows how to specify that PerfCounter.dll should reference the CategoryOptions registry entry to determine whether it should use category-specific shared memory.  
  
```xml  
<configuration>  
  <runtime>  
    <forcePerformanceCounterUniqueSharedMemoryReads enabled="true"/>  
  </runtime>  
</configuration>  
```  
  
## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
