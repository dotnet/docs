---
title: "&lt;trace&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/trace"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#trace"
helpviewer_keywords: 
  - "<trace> element"
  - "listeners"
  - "trace element"
  - "trace listener, <trace> element"
ms.assetid: 7931c942-63c1-47c3-a045-9d9de3cacdbf
caps.latest.revision: 13
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;trace&gt; Element
Contains listeners that collect, store, and route tracing messages.  
  
 \<configuration>  
\<system.diagnostics>  
\<trace>  
  
## Syntax  
  
```xml  
<trace autoflush="true|false"   
       indentsize="indent value"  
       useGlobalLock="true| false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`autoflush`|Optional attribute.<br /><br /> Specifies whether the trace listeners automatically flush the output buffer after every write operation.|  
|`indentsize`|Optional attribute.<br /><br /> Specifies the number of spaces to indent.|  
|`useGlobalLock`|Optional attribute.<br /><br /> Indicates whether the global lock should be used.|  
  
## autoflush Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|Does not automatically flush the output buffer. This is the default.|  
|`true`|Automatically flushes the output buffer.|  
  
## useGlobalLock Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|Does not use the global lock if the listener is thread safe; otherwise, uses the global lock.|  
|`true`|Uses the global lock regardless of whether the listener is thread safe. This is the default.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<listeners>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/listeners-element-for-trace.md)|Specifies a listener that collects, stores, and routes messages.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
  
## Example  
 The following example shows how to use the `<trace>` element to add the listener `MyListener` to the `Listeners` collection. `MyListener` creates a file that is named `MyListener.log` and writes the output to the file. The `useGlobalLock` attribute is set to `false`, which causes the global lock not to be used if the trace listener is thread safe. The `autoflush` attribute is set to `true`, which causes the trace listener to write to the file regardless of whether the <xref:System.Diagnostics.Trace.Flush%2A?displayProperty=nameWithType> method is called. The `indentsize` attribute is set to 0 (zero), which causes the listener to indent zero spaces when the <xref:System.Diagnostics.Trace.Indent%2A?displayProperty=nameWithType> method is called.  
  
```xml  
<configuration>  
   <system.diagnostics>  
      <trace useGlobalLock="false" autoflush="true" indentsize="0">  
         <listeners>  
            <add name="myListener" type="System.Diagnostics.TextWriterTraceListener, system version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="c:\myListener.log" />  
         </listeners>  
      </trace>  
   </system.diagnostics>  
</configuration>  
```  
  
## See Also  
 <xref:System.Diagnostics.TraceListener>  
 <xref:System.Diagnostics.DefaultTraceListener>  
 <xref:System.Diagnostics.TextWriterTraceListener>  
 <xref:System.Diagnostics.EventLogTraceListener>  
 [Trace and Debug Settings Schema](../../../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)
