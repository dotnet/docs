---
description: "Learn more about: <disableCommitThreadStack> Element"
title: "<disableCommitThreadStack> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/disableCommitThreadStack"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#disableCommitThreadStack"
helpviewer_keywords: 
  - "<disableCommitThreadStack> element"
  - "disableCommitThreadStack element"
ms.assetid: 3559d46a-7640-4c72-9a11-7e980768929e
---
# \<disableCommitThreadStack> Element

Specifies whether the full thread stack is committed when a thread is started.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<disableCommitThreadStack>**  
  
## Syntax  
  
```xml  
<disableCommitThreadStack enabled="0|1"/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|enabled|Required attribute.<br /><br /> Specifies whether committing the full thread stack on thread startup (the default behavior) is disabled.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|0|Do not disable the default behavior of the common language runtime, which is to commit the full thread stack when a thread is started.|  
|1|Disable the default behavior of the common language runtime, which is to commit the full thread stack when a thread is started.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  

 The default behavior of the common language runtime is to commit the full thread stack when a thread is started. If a large number of threads must be created on a server that has limited memory, and most of those threads will use very little stack space, the server might perform better if the common language runtime does not commit the full thread stack immediately when a thread is started.  
  
> [!NOTE]
> Unmanaged hosts can use the `STARTUP_DISABLE_COMMITTHREADSTACK` startup flag in the [STARTUP_FLAGS](../../../unmanaged-api/hosting/startup-flags-enumeration.md) enumeration to accomplish the same result.  
  
## Example  

 The following example shows how to disable the default behavior of the common language runtime, which is to commit the full thread stack on thread startup.  
  
```xml  
<configuration>  
   <runtime>  
      <disableCommitThreadStack enabled="1" />  
   </runtime>  
</configuration>  
```  
  
## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
