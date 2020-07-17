---
title: "<Crst_DisableSpinWait> element"
ms.date: "04/18/2019"
f1_keywords: 
  - "Crst_DisableSpinWait"
helpviewer_keywords: 
  - "Crst_DisableSpinWait element"
---
# \<Crst_DisableSpinWait> element

Specifies whether to disable spin-waiting for a critical section when contended.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<Crst_DisableSpinWait>**  
  
## Syntax  
  
```xml  
<Crst_DisableSpinWait enabled="true | false"/>  
```  
  
## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**enabled**|Specifies whether spin-waiting for critical sections when they are contended is disabled.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|1|Disable spin-waiting when a critical section cannot be acquired.|  
|0|Do not disable spin-waiting when a critical section cannot be acquired. This is the default value.|  
  
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

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
