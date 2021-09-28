---
description: "Learn more about: <qualifyAssembly> Element"
title: "<qualifyAssembly> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#qualifyAssembly"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding/qualifyAssembly"
helpviewer_keywords: 
  - "container tags, <qualifyAssembly> element"
  - "<qualifyAssembly> element"
  - "qualifyAssembly element"
ms.assetid: ad6442f6-1a9d-43b6-b733-04ac1b7f9b82
---
# \<qualifyAssembly> Element

Specifies the full name of the assembly that should be dynamically loaded when a partial name is used.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<assemblyBinding>**](assemblybinding-element-for-runtime.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<qualifyAssembly>**  
  
## Syntax  
  
```xml  
      <qualifyAssembly partialName=  
      "PartialAssemblyName"  
                 fullName="FullAssemblyName"/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`partialName`|Required attribute.<br /><br /> Specifies the partial name of the assembly as it appears in the code.|  
|`fullName`|Required attribute.<br /><br /> Specifies the full name of the assembly as it appears in the global assembly cache.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`assemblyBinding`|Contains information about assembly version redirection and the locations of assemblies.|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  

 Calling the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method using partial assembly names causes the common language runtime to look for the assembly only in the application base directory. Use the **\<qualifyAssembly>** element in your application configuration file to provide the full assembly information (name, version, public key token, and culture) and cause the common language runtime to search for the assembly in the global assembly cache.  
  
 The **fullName** attribute must include the four fields of assembly identity: name, version, public key token, and culture. The **partialName** attribute must partially reference an assembly. You must specify at least the assembly's text name (the most common case), but you can also include version, public key token, or culture (or any combination of the four, but not all four). The **partialName** must match the name specified in your call. For example, you cannot specify `"math"` as the **partialName** attribute in your configuration file and call `Assembly.Load("math, Version=3.3.3.3")` in your code.  
  
## Example  

 The following example logically turns the call `Assembly.Load("math")` into `Assembly.Load("math,version=1.0.0.0,publicKeyToken=a1690a5ea44bab32,culture=neutral")`.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <qualifyAssembly partialName="math"
                         fullName=  
"math,version=1.0.0.0,publicKeyToken=a1690a5ea44bab32,culture=neutral"/>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
## See also

- [Runtime Settings Schema](index.md)
- [How the Runtime Locates Assemblies](../../../deployment/how-the-runtime-locates-assemblies.md)
- [Partial Assembly References](/previous-versions/dotnet/netframework-4.0/0a7zy9z5(v=vs.100))
