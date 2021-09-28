---
description: "Learn more about: <system.diagnostics> Element"
title: "<system.diagnostics> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#system.diagnostics"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics"
helpviewer_keywords: 
  - "<system.diagnostics> element"
  - "system.diagnostics element"
ms.assetid: 3f348f42-fa72-4ff2-aa1c-bb9eecad4bb2
---
# \<system.diagnostics> Element

Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;**\<system.diagnostics>**  
  
## Syntax  
  
```xml  
<system.diagnostics>
</system.diagnostics>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<assert>](assert-element.md)|Specifies whether to display a message box when you call the <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType> method; also specifies the name of the file to write messages to.|  
|[\<performanceCounters>](performancecounters-element.md)|Specifies the size of the global memory shared by performance counters.|  
|[\<sharedListeners>](sharedlisteners-element.md)|Contains listeners that any source or trace element can reference. Listeners identified as shared listeners can be added to sources or traces by name.|  
|[\<sources>](sources-element.md)|Specifies trace sources that initiate tracing messages.|  
|[\<switches>](switches-element.md)|Contains trace switches and the levels where the trace switches are set.|  
|[\<trace>](trace-element.md)|Contains listeners that collect, store, and route tracing messages.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
  
## Example  

 The following example shows how to embed a trace switch and a trace listener inside the **\<system.diagnostics>** element. The `General` trace switch is set to the <xref:System.Diagnostics.TraceLevel> level. The trace listener `myListener` creates a file called `MyListener.log` and writes the output to the file.  
  
> [!NOTE]
> In the .NET Framework version 2.0, you can use text to specify the value for a switch. For example, you can specify `true` for a <xref:System.Diagnostics.BooleanSwitch> or use the text representing an enumeration value such as `Error` for a <xref:System.Diagnostics.TraceSwitch>. The line `<add name="myTraceSwitch" value="Error" />` is equivalent to `<add name="myTraceSwitch" value="1" />`.  
  
```xml  
<configuration>  
   <system.diagnostics>  
      <switches>  
         <add name="General" value="4" />  
      </switches>  
      <trace autoflush="true" indentsize="2">  
         <listeners>  
            <add name="myListener" type="System.Diagnostics.TextWriterTraceListener, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="MyListener.log" traceOutputOptions="ProcessId, LogicalOperationStack, Timestamp, ThreadId, Callstack, DateTime" />  
         </listeners>  
      </trace>  
   </system.diagnostics>  
</configuration>  
```  
  
## See also

- <xref:System.Diagnostics.Trace>
- <xref:System.Diagnostics.Debug>
- [Trace and Debug Settings Schema](index.md)
