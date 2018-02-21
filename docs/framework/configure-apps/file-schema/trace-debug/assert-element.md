---
title: "&lt;assert&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/assert"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#assert"
helpviewer_keywords: 
  - "<assert> element"
  - "assert element"
ms.assetid: ef4c3229-b151-4d85-8091-e6456af9b935
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;assert&gt; Element
Specifies whether to display a message box when you call the <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType> method; also specifies the name of the file to write messages to.  
  
 \<configuration>  
\<system.diagnostics>  
\<assert>  
  
## Syntax  
  
```xml  
<assert assertuienabled="true|false" logfilename="file name"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`assertuienabled`|Optional attribute.<br /><br /> Specifies whether to display a message box when the **Debug.Assert** method evaluates to **false**.|  
|`logfilename`|Optional attribute.<br /><br /> Specifies the name of the file to write the message to if **Debug.Assert** evaluates to **false**.|  
  
## assertuienabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`true`|Displays the message box. This is the default.|  
|`false`|Does not display the message box.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
  
## Remarks  
 Both attributes in the **\<assert>** element are optional. You can disable message boxes without specifying a file to write the messages to, or you can specify a file to write messages to while leaving message boxes enabled.  
  
## Example  
 The following example shows how to disable displaying message boxes when you call **Debug.Assert** and write the messages to `c:\log.txt`.  
  
```xml  
<configuration>  
   <system.diagnostics>  
      <assert assertuienabled="false" logfilename="c:\log.txt"/>  
   </system.diagnostics>  
</configuration>  
```  
  
## See Also  
 <xref:System.Diagnostics.Debug>  
 [Trace and Debug Settings Schema](../../../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)
