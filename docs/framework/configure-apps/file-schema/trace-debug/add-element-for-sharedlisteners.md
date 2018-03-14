---
title: "&lt;add&gt; Element for &lt;sharedListeners&gt;"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/sharedListeners/add"
helpviewer_keywords: 
  - "initializeData attribute"
  - "<add> element for <sharedListeners>"
  - "add element for <sharedListeners>"
ms.assetid: 1595e1bc-2492-421f-8384-7f382eb8eb57
caps.latest.revision: 13
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; Element for &lt;sharedListeners&gt;
Adds a listener to the `sharedListeners` collection. `sharedListeners` is a collection of listeners that any [\<source>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/source-element.md) or [\<trace>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/trace-element.md) can reference.  By default, listeners in the `sharedListeners` collection are not placed in a `Listeners` collection. They must be added by name to the [\<source>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/source-element.md) or [\<trace>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/trace-element.md). It is not possible to get the listeners in the `sharedListeners` collection in code at run time.  
  
 \<configuration>  
\<system.diagnostics>  
\<sharedListeners> Element  
\<add>  
  
## Syntax  
  
```xml  
<add name="name"   
  type="TraceListenerClassName, Version, Culture, PublicKeyToken"  
  initializeData="data"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`name`|Required attribute.<br /><br /> Specifies the name of the listener that is used to add the shared listener to a `Listeners` collection.|  
|`type`|Required attribute.<br /><br /> Specifies the type of the listener. You must use a string that meets the requirements specified in [Specifying Fully Qualified Type Names](../../../../../docs/framework/reflection-and-codedom/specifying-fully-qualified-type-names.md).|  
|`initializeData`|Optional attribute.<br /><br /> The string passed to the constructor for the specified class.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<filter>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/filter-element-for-add-for-sharedlisteners.md)|Adds a filter to a listener in the `sharedListeners` collection.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
|`sharedListeners`|A collection of listeners that any source or trace element can reference.|  
  
## Remarks  
 The listener classes shipped with the .NET Framework derive from the <xref:System.Diagnostics.TraceListener> class. The value for the `name` attribute is used to add the shared listener to a `Listeners` collection for either a trace or a trace source. The value for the `initializeData` attribute depends on the type of listener you create. Not all trace listeners require that you specify `initializeData`.  
  
> [!NOTE]
>  When you use the `initializeData` attribute, you may get the compiler warning "The 'initializeData' attribute is not declared." This warning occurs because the configuration settings are validated against the abstract base class <xref:System.Diagnostics.TraceListener>, which does not recognize the `initializeData` attribute. Typically, you can ignore this warning for trace listener implementations that have a constructor that takes a parameter.  
  
 The following table shows the trace listeners that are included with the .NET Framework and describes the value of their `initializeData` attributes.  
  
|Trace listener class|initializeData attribute value|  
|--------------------------|------------------------------------|  
|<xref:System.Diagnostics.ConsoleTraceListener>|The `useErrorStream` value for the <xref:System.Diagnostics.ConsoleTraceListener.%23ctor%2A> constructor.  Set the `initializeData` attribute to "`true`" to write trace and debug output to the standard error stream; set it to "`false`" to write to the standard output stream.|  
|<xref:System.Diagnostics.DelimitedListTraceListener>|The name of the file the <xref:System.Diagnostics.DelimitedListTraceListener> writes to.|  
|<xref:System.Diagnostics.EventLogTraceListener?displayProperty=nameWithType>|The name of an existing event log source.|  
|<xref:System.Diagnostics.EventSchemaTraceListener?displayProperty=nameWithType>|The name of the file that the <xref:System.Diagnostics.EventSchemaTraceListener> writes to.|  
|<xref:System.Diagnostics.TextWriterTraceListener?displayProperty=nameWithType>|The name of the file that the <xref:System.Diagnostics.TextWriterTraceListener> writes to.|  
|<xref:System.Diagnostics.XmlWriterTraceListener>|The name of the file that the <xref:System.Diagnostics.XmlWriterTraceListener> writes to.|  
  
## Configuration File  
 This element can be used in the machine configuration file (Machine.config) and the application configuration file.  
  
## Example  
 The following example shows how to use `<add>` elements to add the <xref:System.Diagnostics.TextWriterTraceListener>`textListener` to the `sharedListeners` collection.   `textListener` is added by name to the `Listeners` collection for the trace source `TraceSourceApp`. The `textListener` listener writes trace output to the file myListener.log.  
  
```xml  
<configuration>  
  <system.diagnostics>  
    <sources>  
      <source name="TraceSourceApp" switchName="sourceSwitch"   
        switchType="System.Diagnostics.SourceSwitch">  
        <listeners>  
          <add name="console"   
            type="System.Diagnostics.ConsoleTraceListener"/>  
          <add name="textListener"/>  
          <remove name="Default"/>  
        </listeners>  
      </source>  
    </sources>  
    <sharedListeners>  
      <add name="textListener"   
        type="System.Diagnostics.TextWriterTraceListener"   
        initializeData="myListener.log"/>  
    </sharedListeners>  
    <switches>  
      <add name="sourceSwitch" value="Warning"/>  
    </switches>  
  </system.diagnostics>  
</configuration>   
```  
  
## See Also  
 <xref:System.Diagnostics.TraceSource>  
 <xref:System.Diagnostics.TraceListener>  
 [Trace and Debug Settings Schema](../../../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)  
 [Trace Listeners](../../../../../docs/framework/debug-trace-profile/trace-listeners.md)
