---
title: "<switches> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/switches"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#switches"
helpviewer_keywords: 
  - "<switches> element"
  - "switches element"
  - "trace switches, <switches> element"
ms.assetid: 4cf36786-b89a-40e2-a0f1-86bb9b783343
---
# \<switches> Element
Contains trace switches and the level where the trace switches are set.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<system.diagnostics>**](system-diagnostics-element.md)  
&nbsp;&nbsp;&nbsp;&nbsp;**\<switches>**  
  
## Syntax  
  
```xml  
      <switches>   
</switches>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](add-element-for-switches.md)|Specifies the level where a trace switch is set.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`System.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
  
## Remarks  
 You can change the level of a trace switch by putting it in a configuration file. If the switch is a <xref:System.Diagnostics.BooleanSwitch>, you can turn it on and off. If the switch is a <xref:System.Diagnostics.TraceSwitch>, you can assign different levels to it to specify the types of trace or debug messages the application outputs.  
  
## Example  
 The following example shows how to use the **\<switch>** element to set the `General` trace switch to the <xref:System.Diagnostics.TraceLevel> level, and enable the `Data` Boolean trace switch.  
  
```xml  
<configuration>  
   <system.diagnostics>  
      <switches>  
         <add name="General" value="4" />  
         <add name="Data" value="1" />  
      </switches>  
   </system.diagnostics>  
</configuration>  
```  
  
## See also

- <xref:System.Diagnostics.Switch>
- <xref:System.Diagnostics.TraceSwitch>
- <xref:System.Diagnostics.BooleanSwitch>
- [Trace and Debug Settings Schema](index.md)
 