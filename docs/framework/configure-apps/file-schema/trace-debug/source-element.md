---
title: "&lt;source&gt; Element"
ms.date: "09/29/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/sources/source"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#source"
helpviewer_keywords: 
  - "<source> element"
  - "source element"
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;source&gt; Element
Specifies a trace source that initiates tracing messages.  
  
 \<configuration>  
\<system.diagnostics>  
\<sources>  
\<source>  
  
## Syntax  
  
```xml  
<source>   
  <listeners>...</listeners>  
</source>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`name`|Optional attribute.<br /><br /> Specifies the name of the trace source.|  
|`switchName`|Optional attribute.<br /><br /> Specifies the name of a trace switch instance in the application. If the switch is not identified in a `<switches>` element, the value specifies the level for the switch.|  
|`switchType`|Optional attribute.<br /><br /> Specifies the type of the trace switch. If present, the type must be a valid class name and cannot be an empty string.|  
|`extraAttribute`|Optional attribute.<br /><br /> Specifies the value for a trace source-specific attribute identified by the <xref:System.Diagnostics.TraceSource.GetSupportedAttributes%2A> method for that trace source.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<listeners>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/listeners-element-for-source.md)|Contains listeners that collect, store, and route messages.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
|`sources`|Contains trace sources that initiate tracing messages.|  
  
## Remarks  
 This element can be used in the machine configuration file (Machine.config) and the application configuration file.  
  
## Example  
 The following example shows how to use the `<source>` element to add the trace source `mySource` and to set the level for the source switch named `sourceSwitch`. A console trace listener is added that writes trace information to the console.  
  
```xml  
<configuration>  
  <system.diagnostics>  
    <sources>  
      <source name="mySource" switchName="sourceSwitch" switchType="System.Diagnostics.SourceSwitch"  >  
        <listeners>  
          <add name="console" type="System.Diagnostics.ConsoleTraceListener" >  
            <filter type="System.Diagnostics.EventTypeFilter" initializeData="Error" />  
          </add>  
          <remove name="Default" />  
        </listeners>  
      </source>  
    </sources>  
        <switches>  
           <add name="sourceSwitch" value="Warning" />  
        </switches>    
  </system.diagnostics>   
</configuration>  
```  
  
## See Also  
 [Trace and Debug Settings Schema](../../../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)  
 [Trace Switches](../../../../../docs/framework/debug-trace-profile/trace-switches.md)
