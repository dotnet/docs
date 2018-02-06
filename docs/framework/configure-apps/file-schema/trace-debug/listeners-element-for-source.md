---
title: "&lt;listeners&gt; Element for &lt;source&gt;"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/sources/source/listeners"
helpviewer_keywords: 
  - "listeners element for <source>"
  - "<listeners> element for <source>"
ms.assetid: a2991f43-b4d3-4614-a8e7-da392de9697f
caps.latest.revision: 10
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;listeners&gt; Element for &lt;source&gt;
Adds or removes listeners in the <xref:System.Diagnostics.TraceSource.Listeners%2A> collection for a <xref:System.Diagnostics.TraceSource>. A listener directs the tracing output to an appropriate target, such as a log, window, or text file.  
  
 \<configuration>  
\<system.diagnostics>  
\<sources>  
\<source>  
\<listeners> Element  
  
## Syntax  
  
```xml  
<listeners>   
  <add>...</add>  
  <remove ... />  
  <clear/>  
</listeners>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/add-element-for-listeners-for-source.md)|Adds a listener to the `Listeners` collection.|  
|[\<remove>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/remove-element-for-listeners-for-source.md)|Removes a listener from the `Listeners` collection.|  
|[\<clear>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/clear-element-for-listeners-for-source.md)|Clears the `Listeners` collection for a trace source.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
|`sources`|Contains trace sources that initiate tracing messages.|  
|`source`|Specifies a trace source that initiates tracing messages.|  
  
## Remarks  
  
## Configuration File  
 This element can be used in the machine configuration file (Machine.config) and the application configuration file.  
  
## Example  
 The following example shows how to use the `<listeners>` element to add a console trace listener to the `mySource` source and to remove the default trace listener.  
  
```xml  
<configuration>  
  <system.diagnostics>  
    <sources>  
      <source name="mySource" switchName="sourceSwitch"   
        switchType="System.Diagnostics.SourceSwitch">  
        <listeners>  
          <add name="console"   
            type="System.Diagnostics.ConsoleTraceListener">  
            <filter type="System.Diagnostics.EventTypeFilter"   
              initializeData="Error"/>  
          </add>  
          <remove name="Default"/>  
        </listeners>  
      </source>  
    </sources>  
    <switches>  
      <add name="sourceSwitch" value="Warning"/>  
    </switches>  
  </system.diagnostics>  
</configuration>  
```  
  
## See Also  
 <xref:System.Diagnostics.TraceListener>  
 [Trace and Debug Settings Schema](../../../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)  
 [Trace Listeners](../../../../../docs/framework/debug-trace-profile/trace-listeners.md)
