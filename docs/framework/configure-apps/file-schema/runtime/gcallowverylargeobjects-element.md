---
title: "&lt;gcAllowVeryLargeObjects&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "gcAllowVeryLargeObjects element"
  - "<gcAllowVeryLargeObjects> element"
ms.assetid: 5c7ea24a-39ac-4e5f-83b7-b9f9a1b556ab
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;gcAllowVeryLargeObjects&gt; Element
On 64-bit platforms, enables arrays that are greater than 2 gigabytes (GB) in total size.  
  
 \<configuration> Element  
\<runtime> Element  
\<gcAllowVeryLargeObjects> Element  
  
## Syntax  
  
```xml  
<gcAllowVeryLargeObjects    
   enabled="true|false" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether arrays that are greater than 2 GB in total size are enabled on 64-bit platforms.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|Arrays greater than 2 GB in total size are not enabled. This is the default.|  
|`true`|Arrays greater than 2 GB in total size are enabled on 64-bit platforms.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about runtime initialization options.|  
  
## Remarks  
 Using this element in your application configuration file enables arrays that are larger than 2 GB in size, but does not change other limits on object size or array size:  
  
-   The maximum number of elements in an array is <xref:System.UInt32.MaxValue?displayProperty=nameWithType>.  
  
-   The maximum index in any single dimension is 2,147,483,591 (0x7FFFFFC7) for byte arrays and arrays of single-byte structures, and 2,146,435,071 (0X7FEFFFFF) for other types.  
  
-   The maximum size for strings and other non-array objects is unchanged.  
  
> [!CAUTION]
>  Before enabling this feature, ensure that your application does not include unsafe code that assumes that all arrays are smaller than 2 GB in size. For example, unsafe code that uses arrays as buffers might be susceptible to buffer overruns if it is written on the assumption that arrays will not exceed 2 GB.  
  
## Example  
 The following example shows how to enable this feature for an application.  
  
```xml  
<configuration>  
  <runtime>  
    <gcAllowVeryLargeObjects enabled="true" />  
  </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
