---
description: "Learn more about: <legacyCorruptedStateExceptionsPolicy> Element"
title: "<legacyCorruptedStateExceptionsPolicy> Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "<legacyCorruptedStateExceptionsPolicy> element"
  - "legacyCorruptedStateExceptionsPolicy element"
ms.assetid: e0a55ddc-bfa8-4f3e-ac14-d1fc3330e4bb
---
# \<legacyCorruptedStateExceptionsPolicy> Element

Specifies whether the common language runtime allows managed code to catch access violations and other corrupted state exceptions.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<legacyCorruptedStateExceptionsPolicy>**  
  
## Syntax  
  
```xml  
<legacyCorruptedStateExceptionsPolicy enabled="true|false"/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies that the application will catch corrupting state exception failures such as access violations.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|The application will not catch corrupting state exception failures such as access violations. This is the default.|  
|`true`|The application will catch corrupting state exception failures such as access violations.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  

 In the .NET Framework version 3.5 and earlier, the common language runtime allowed managed code to catch exceptions that were raised by corrupted process states. An access violation is an example of this type of exception.  
  
 Starting with the .NET Framework 4, managed code no longer catches these types of exceptions in `catch` blocks. However, you can override this change and maintain the handling of corrupted state exceptions in two ways:  
  
- Set the `<legacyCorruptedStateExceptionsPolicy>` element's `enabled` attribute to `true`. This configuration setting is applied processwide and affects all methods.  
  
 -or-  
  
- Apply the <xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute?displayProperty=nameWithType> attribute to the method that contains the exceptions `catch` block.  
  
 This configuration element is available only in the .NET Framework 4 and later.  
  
## Example  

 The following example shows how to specify that the application should revert to the behavior before the .NET Framework 4, and catch all corrupting state exception failures.  
  
```xml  
<configuration>  
   <runtime>  
      <legacyCorruptedStateExceptionsPolicy enabled="true" />  
   </runtime>  
</configuration>  
```  
  
## See also

- <xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute>
- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
