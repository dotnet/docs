---
title: "&lt;add&gt; Element for &lt;listeners&gt; for &lt;trace&gt;"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/trace/listeners/add"
helpviewer_keywords: 
  - "initializeData attribute"
  - "<add> element for <listeners>"
  - "add element for <listeners>"
ms.assetid: 81e804a3-ef11-4d39-bbde-bfa012c179e2
caps.latest.revision: 24
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; Element for &lt;listeners&gt; for &lt;trace&gt;
Adds a listener to the **Listeners** collection.  
  
 \<configuration>  
\<system.diagnostics>  
\<trace>  
\<listeners>  
\<add>  
  
## Syntax  
  
```xml  
<add name="name"   
     type="trace listener class name, Version, Culture, PublicKeyToken"  
     initializeData="data"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**type**|Required attribute.<br /><br /> Specifies the type of the listener. You must use a string that meets the requirements specified in [Specifying Fully Qualified Type Names](../../../../../docs/framework/reflection-and-codedom/specifying-fully-qualified-type-names.md).|  
|**initializeData**|Optional attribute.<br /><br /> The string passed to the constructor for the specified class.|  
|**name**|Optional attribute.<br /><br /> Specifies the name of the listener.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<filter>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/filter-element-for-add-for-listeners-for-trace.md)|Adds a filter to a listener in the `Listeners` collection for a trace.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`listeners`|Specifies a listener that collects, stores, and routes messages. Listeners direct the tracing output to an appropriate target.|  
|`system.diagnostics`|Specifies the root element for the ASP.NET configuration section.|  
|`trace`|Contains listeners that collect, store, and route tracing messages.|  
  
## Remarks  
 The <xref:System.Diagnostics.Debug> and <xref:System.Diagnostics.Trace> classes share the same **Listeners** collection. If you add a listener object to the collection in one of these classes, the other class uses the same listener. The listener classes derive from the <xref:System.Diagnostics.TraceListener>.  
  
 If you do not specify the `name` attribute of the trace listener, the <xref:System.Diagnostics.TraceListener.Name%2A> of the trace listener defaults to an empty string (""). If your application has only one listener, you can add it without specifying a name, and remove it by specifying an empty string for the name. However, if your application has more than one listener, you should specify unique names for each trace listener, which allows you to identify and manage individual trace listeners within the <xref:System.Diagnostics.Debug.Listeners%2A> and <xref:System.Diagnostics.Trace.Listeners%2A> collections.  
  
> [!NOTE]
>  Adding more than one trace listener of the same type and with the same name results in only one trace listener of that type and name being added to the `Listeners` collection. However, you can programmatically add multiple identical listeners to the `Listeners` collection.  
  
 The value for the **initializeData** attribute depends on the type of listener you create. Not all trace listeners require that you specify **initializeData**.  
  
> [!NOTE]
>  When you use the `initializeData` attribute, you may get the compiler warning "The 'initializeData' attribute is not declared." This warning occurs because the configuration settings are validated against the abstract base class <xref:System.Diagnostics.TraceListener>, which does not recognize the `initializeData` attribute. Typically, you can ignore this warning for trace listener implementations that have a constructor that takes a parameter.  
  
 The following table shows the trace listeners that are included with the .NET Framework and describes the value of their **initializeData** attributes.  
  
|Trace listener class|initializeData attribute value|  
|--------------------------|------------------------------------|  
|<xref:System.Diagnostics.ConsoleTraceListener?displayProperty=nameWithType>|The `useErrorStream` value for the <xref:System.Diagnostics.ConsoleTraceListener.%23ctor%2A> constructor.  Set the `initializeData` attribute to "`true`" to write trace and debug output to <xref:System.Console.Error%2A?displayProperty=nameWithType>; "`false`" to write to <xref:System.Console.Out%2A?displayProperty=nameWithType>.|  
|<xref:System.Diagnostics.DelimitedListTraceListener?displayProperty=nameWithType>|The name of the file the <xref:System.Diagnostics.DelimitedListTraceListener> writes to.|  
|<xref:System.Diagnostics.EventLogTraceListener?displayProperty=nameWithType>|The name of the name of an existing event log source.|  
|<xref:System.Diagnostics.EventSchemaTraceListener?displayProperty=nameWithType>|The name of the file that the <xref:System.Diagnostics.EventSchemaTraceListener> writes to.|  
|<xref:System.Diagnostics.TextWriterTraceListener?displayProperty=nameWithType>|The name of the file that the <xref:System.Diagnostics.TextWriterTraceListener> writes to.|  
|<xref:System.Diagnostics.XmlWriterTraceListener?displayProperty=nameWithType>|The name of the file that the <xref:System.Diagnostics.XmlWriterTraceListener> writes to.|  
  
## Example  
 The following example shows how to use **\<add>** elements to add the listeners `MyListener` and `MyEventListener` to the **Listeners** collection. `MyListener` creates a file called `MyListener.log` and writes the output to the file. `MyEventListener` creates an entry in the event log.  
  
```xml  
<configuration>  
   <system.diagnostics>  
      <trace autoflush="true" indentsize="0">  
         <listeners>  
            <add name="myListener" type="System.Diagnostics.TextWriterTraceListener, system, version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="c:\myListener.log" />  
            <add name="MyEventListener"  
                 type="System.Diagnostics.EventLogTraceListener, system, version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"                 initializeData="MyConfigEventLog"/>  
            <add name="configConsoleListener"  
                 type="System.Diagnostics.ConsoleTraceListener, system, version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>  
         </listeners>  
      </trace>  
   </system.diagnostics>  
</configuration>  
```  
  
## See Also  
 <xref:System.Diagnostics.Trace>  
 <xref:System.Diagnostics.Debug>  
 <xref:System.Diagnostics.EventLogTraceListener>  
 <xref:System.Diagnostics.ConsoleTraceListener>  
 <xref:System.Diagnostics.TextWriterTraceListener>  
 [Trace and Debug Settings Schema](../../../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)  
 [Trace Listeners](../../../../../docs/framework/debug-trace-profile/trace-listeners.md)
