---
title: "<listeners> Element for <trace>"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/trace/listeners"
helpviewer_keywords: 
  - "<listeners> element"
  - "listeners element"
ms.assetid: 1394c2c3-6304-46db-87c1-8e8b16f5ad5b
---
# \<listeners> Element for \<trace>
Specifies a listener that collects, stores, and routes messages. Listeners direct the tracing output to an appropriate target.  
  
 \<configuration> Element  
\<system.diagnostics> Element  
\<trace> Element  
\<listeners> Element for \<trace>  
  
## Syntax  
  
```xml  
<listeners>   
  <add>...</add>  
  <clear/>  
  <remove ... />  
</listeners>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](add-element-for-listeners-for-trace.md)|Adds a listener to the `Listeners` collection.|  
|[\<clear>](clear-element-for-listeners-for-trace.md)|Clears the `Listeners` collection for trace.|  
|[\<remove>](remove-element-for-listeners-for-trace.md)|Removes a listener from the `Listeners` collection.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies the root element for the ASP.NET configuration section.|  
|`trace`|Contains listeners that collect, store, and route tracing messages.|  
  
## Remarks  
 The <xref:System.Diagnostics.Debug> and <xref:System.Diagnostics.Trace> classes share the same **Listeners** collection. If you add a listener object to the collection in one of these classes, the other class uses the same listener. The listener classes shipped with the .NET Framework derive from the <xref:System.Diagnostics.TraceListener> class.  
  
## Configuration File  
 This element can be used in the machine configuration file (Machine.config) and the application configuration file.  
  
## Example  
 The following example shows how to use the **\<listeners>** element to add the listeners `MyListener` and `MyEventListener` to the **Listeners** collection. `MyListener` creates a file called `MyListener.log` and writes the output to the file. `MyEventListener` creates an entry in the event log.  
  
```xml  
<configuration>  
  <system.diagnostics>  
    <trace autoflush="true" indentsize="0">  
      <listeners>  
        <add name="myListener"   
          type="System.Diagnostics.TextWriterTraceListener,   
            system, version=1.0.3300.0, Culture=neutral,   
            PublicKeyToken=b77a5c561934e089"   
          initializeData="c:\myListener.log" />  
        <add name="MyEventListener"  
          type="System.Diagnostics.EventLogTraceListener,   
            system, version=1.0.3300.0, Culture=neutral,   
            PublicKeyToken=b77a5c561934e089"  
          initializeData="MyConfigEventLog"/>  
      </listeners>  
    </trace>  
  </system.diagnostics>  
</configuration>  
```  
  
## See also

- <xref:System.Diagnostics.TraceListener>
- [Trace and Debug Settings Schema](index.md)
