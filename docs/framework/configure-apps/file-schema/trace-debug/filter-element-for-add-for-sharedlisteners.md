---
title: "<filter> Element for <add> for <sharedListeners>"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/sharedListeners/add/filter"
helpviewer_keywords: 
  - "filter element for <add> for <sharedListeners>"
  - "initializeData attribute"
  - "<filter> element for <add> for <sharedListeners>"
  - "filters, trace listeners"
  - "trace listeners, filters"
ms.assetid: 7d4e7faa-2e4e-4379-ac76-f6cd7f2f8fac
---
# \<filter> Element for \<add> for \<sharedListeners>
Adds a filter to a listener in the `sharedListeners` collection.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.diagnostics>**](system-diagnostics-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<sharedListeners>**](sharedlisteners-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<add>**](add-element-for-sharedlisteners.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<filter>**

## Syntax  
  
```xml  
<filter type="System.Diagnostics.EventTypeFilter"   
  initializeData="Warning" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**type**|Required attribute.<br /><br /> Specifies the type of the filter. You can use only the full name of the type (in the format of the <xref:System.Type.FullName%2A?displayProperty=nameWithType> property), or you can use the fully qualified type name including the assembly information (in the format of the <xref:System.Type.AssemblyQualifiedName%2A?displayProperty=nameWithType> property). For information on creating a fully qualified type name, see [Specifying Fully Qualified Type Names](../../../reflection-and-codedom/specifying-fully-qualified-type-names.md).|  
|**initializeData**|Optional attribute.<br /><br /> The string passed to the constructor for the specified class.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
|`sharedListeners`|A collection of listeners that any source or trace element can reference.|  
|`add`|Adds a listener to the **sharedListeners** collection.|  
  
## Remarks  
 If a listener is defined in an `<add>` element of the `<sharedListeners>` element, the filter for that listener should be defined in a `<filter>` element that is a child of the `<add>` element.  
  
 This element can be used in the machine configuration file (Machine.config) and the application configuration file.  
  
## Example  
 The following example shows how to use the `<filter>` element to add a filter to the trace listener `console` in the `sharedListeners` collection.  
  
```xml  
<configuration>  
  <system.diagnostics>  
    <sources>  
      <source name="myTraceSource" >  
        <listeners>  
          <add name="console" />  
          <remove name="Default" />  
        </listeners>  
      </source>  
    </sources>  
    <sharedListeners>  
      <add name="console"   
        type="System.Diagnostics.ConsoleTraceListener" >  
        <filter type="System.Diagnostics.EventTypeFilter"   
          initializeData="Error" />  
      </add>  
    </sharedListeners>  
  </system.diagnostics>  
</configuration>  
```  
  
## See also

- <xref:System.Diagnostics.TraceFilter>
- <xref:System.Diagnostics.TraceListener>
- <xref:System.Diagnostics.TraceSource>
- [Trace and Debug Settings Schema](index.md)
