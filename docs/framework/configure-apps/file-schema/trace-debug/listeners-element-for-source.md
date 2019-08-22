---
title: "<listeners> Element for <source>"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/sources/source/listeners"
helpviewer_keywords: 
  - "listeners element for <source>"
  - "<listeners> element for <source>"
ms.assetid: a2991f43-b4d3-4614-a8e7-da392de9697f
---
# \<listeners> Element for \<source>
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
|[\<add>](add-element-for-listeners-for-source.md)|Adds a listener to the `Listeners` collection.|  
|[\<remove>](remove-element-for-listeners-for-source.md)|Removes a listener from the `Listeners` collection.|  
|[\<clear>](clear-element-for-listeners-for-source.md)|Clears the `Listeners` collection for a trace source.|  
  
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
  
## See also

- <xref:System.Diagnostics.TraceListener>
- [Trace and Debug Settings Schema](index.md)
- [Trace Listeners](../../../debug-trace-profile/trace-listeners.md)
