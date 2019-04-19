---
title: "<Crst_DisableSpinWait> element"
ms.date: "04/18/2019"
f1_keywords: 
  - "Crst_DisableSpinWait"
helpviewer_keywords: 
  - "Crst_DisableSpinWait element"
author: "rpetrusha"
ms.author: "ronpet"
---
# \<Crst_DisableSpinWait> element

Specifies whether to disable spin-waiting for a critical section when contended. \ 
  
 \<configuration>  
\<runtime>  
\<Crst_DisableSpinWait>  
  
## Syntax  
  
```xml  
<Crst_DisableSpinWait enabled="true | false"/>  
```  
  
## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**enabled**|Specifies whether spin-waiting for critical sections is enabled when they are contended.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|1|Spin-waiting is enabled. This is the default. |  
|0|Spin-waiting is disabled. |  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about various runtime configuration settings.|  
  
## Example  

The following example disables spin-waiting in critical sections when contended.  
  
```xml  
<configuration>  
   <runtime>  
      <Crst_DisableSpinWait enabled="1"/>  
   </runtime>  
</configuration>  
```  
  
## See also

- [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)
- [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
