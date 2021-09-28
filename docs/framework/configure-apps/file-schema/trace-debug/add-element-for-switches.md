---
description: "Learn more about: <add> Element for <switches>"
title: "<add> Element for <switches>"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/switches/add"
helpviewer_keywords: 
  - "<add> element for <switches>"
  - "add element for <switches>"
ms.assetid: 712ac3a7-7abf-4a9e-8db4-acd241c2f369
---
# \<add> Element for \<switches>

Specifies the level where a trace switch is set.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.diagnostics>**](system-diagnostics-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<switches>**](switches-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**

## Syntax  
  
```xml  
<add name="switch name"  
     value="value"/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**name**|Required attribute.<br /><br /> Specifies the name of the switch. The value of this attribute corresponds to the *displayName* parameter that is passed to switch constructor.|  
|**value**|Required attribute.<br /><br /> Specifies the level of the switch.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`switches`|Contains trace switches and the level where the trace switches are set.|  
|`system.diagnostics`|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
  
## Remarks  

 You can change the level of a trace switch by putting it in a configuration file. If the switch is a <xref:System.Diagnostics.BooleanSwitch>, you can turn it on and off. If the switch is a <xref:System.Diagnostics.TraceSwitch>, you can assign different levels to it to specify the types of trace or debug messages the application outputs.  
  
## Example  

 The following example shows how to use the **\<add>** element to set the `General` trace switch to the <xref:System.Diagnostics.TraceLevel> level, and enable the `Data` Boolean trace switch.  
  
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
