---
title: "&lt;filter&gt; Element for &lt;add&gt; for &lt;listeners&gt; for &lt;source&gt;"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#filter"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/sources/source/listeners/add/filter"
helpviewer_keywords: 
  - "initializeData attribute"
  - "<filter> element for <add> for <listeners> for <source>"
  - "filter element for <add> for <listeners> for <source>"
ms.assetid: 15808b80-4579-4c25-b385-178cfdf154ba
caps.latest.revision: 7
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;filter&gt; Element for &lt;add&gt; for &lt;listeners&gt; for &lt;source&gt;
Adds a filter to a listener in the `Listeners` collection for a trace source.  
  
 \<configuration>  
\<system.diagnostics>  
\<sources>  
\<source>  
\<listeners>  
\<add>  
\<filter>  
  
## Syntax  
  
```xml  
<filter   
  type="traceFilterClassName"   
  initializeData="data" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`type`|Required attribute.<br /><br /> Specifies the type of the filter, which should inherit from the <xref:System.Diagnostics.TraceFilter> class. You can use the namespace-qualified name of the type, which corresponds to the type's <xref:System.Type.FullName%2A> property, or you can use the fully qualified type name including the assembly information, which corresponds to the <xref:System.Type.AssemblyQualifiedName%2A> property. For information about fully qualified type names, see [Specifying Fully Qualified Type Names](../../../../../docs/framework/reflection-and-codedom/specifying-fully-qualified-type-names.md).|  
|`initializeData`|Optional attribute.<br /><br /> The string passed to the constructor for the specified filter class.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
|`sources`|Contains trace sources that initiate tracing messages.|  
|`source`|Specifies a trace source that initiates tracing messages.|  
|`listeners`|Contains listeners that collect, store, and route messages. Listeners direct the tracing output to an appropriate target.|  
|`add`|Adds a listener to the `Listeners` collection for a trace source.|  
  
## Remarks  
 The `<filter>` element must be contained in an `<add>` element for a trace source listener that specifies the type of the listener, not just the name of a listener defined in a [\<sharedListeners>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/sharedlisteners-element.md). If the listener is defined in a [\<sharedListeners>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/sharedlisteners-element.md), the filter for that listener must be defined in that element.  
  
 This element can be used in the machine configuration file (Machine.config) and the application configuration file.  
  
## Example  
 The following example shows how to use the `<filter>` element to add a filter to the listener `console` in the `Listeners` collection for the trace source `myTraceSource`, specifying the filter event level as `Error`.  
  
```xml  
<configuration>  
  <system.diagnostics>  
    <sources>  
      <source name="myTraceSource" switchName="SourceSwitch"   
        switchType="System.Diagnostics.SourceSwitch"  >  
        <listeners>  
          <add name="console"   
            type="System.Diagnostics.ConsoleTraceListener" >  
            <filter type="System.Diagnostics.EventTypeFilter"   
              initializeData="Error" />  
          </add>  
          <remove name="Default" />  
        </listeners>  
      </source>  
    </sources>  
    <switches>  
      <add name="SourceSwitch" value="Warning" />  
    </switches>  
  </system.diagnostics>  
</configuration>  
```  
  
## See Also  
 <xref:System.Diagnostics.TraceSource>  
 <xref:System.Diagnostics.TraceListener>  
 <xref:System.Diagnostics.TraceListener.Filter%2A?displayProperty=nameWithType>  
 <xref:System.Diagnostics.TraceFilter>  
 [Trace and Debug Settings Schema](../../../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)
