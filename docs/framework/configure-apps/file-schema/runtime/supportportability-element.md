---
title: "&lt;supportPortability&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "supportPortability element"
  - "<supportPortability> element"
ms.assetid: 6453ef66-19b4-41f3-b712-52d0c2abc9ca
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;supportPortability&gt; Element
Specifies that an application can reference the same assembly in two different implementations of the .NET Framework, by disabling the default behavior that treats the assemblies as equivalent for application portability purposes.  
  
 \<configuration> Element  
\<runtime> Element  
\<assemblyBinding> Element  
\<supportPortability> Element  
  
## Syntax  
  
```xml  
<supportPortability PKT="public_key_token" enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|PKT|Required attribute.<br /><br /> Specifies the public key token of the affected assembly, as a string.|  
|enabled|Optional attribute.<br /><br /> Specifies whether support for portability between implementations of the specified .NET Framework assembly should be enabled.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|true|Enable support for portability between implementations of the specified .NET Framework assembly. This is the default.|  
|false|Disable support for portability between implementations of the specified .NET Framework assembly. This enables the application to have references to multiple implementations of the specified assembly.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
|`assemblyBinding`|Contains information about assembly version redirection and the locations of assemblies.|  
  
## Remarks  
 Beginning with the [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)], support is automatically provided for applications that can use either of two implementations of the .NET Framework, for example either the .NET Framework implementation or the .NET Framework for Silverlight implementation. The two implementations of a particular .NET Framework assembly are seen as equivalent by the assembly binder. In a few scenarios, this application portability feature causes problems. In those scenarios, the `<supportPortability>` element can be used to disable the feature.  
  
 One such scenario is an assembly that has to reference both the .NET Framework implementation and the .NET Framework for Silverlight implementation of a particular reference assembly. For example, a XAML designer written in Windows Presentation Foundation (WPF) might need to reference both the WPF Desktop implementation, for the designer's user interface, and the subset of WPF that is included in the Silverlight implementation. By default, the separate references cause a compiler error, because assembly binding sees the two assemblies as equivalent. This element disables the default behavior, and allows compilation to succeed.  
  
> [!IMPORTANT]
>  In order for the compiler to pass the information to the common language runtime's assembly-binding logic, you must use the `/appconfig` compiler option to specify the location of the app.config file that contains this element.  
  
## Example  
 The following example enables an application to have references to both the .NET Framework implementation and the .NET Framework for Silverlight implementation of any .NET Framework assembly that exists in both implementations. The `/appconfig` compiler option must be used to specify the location of this app.config file.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding>  
         <supportPortability PKT="7cec85d7bea7798e" enable="false"/>  
         <supportPortability PKT="31bf3856ad364e35" enable="false"/>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [/appconfig (C# Compiler Options)](http://msdn.microsoft.com/library/ee523958.aspx)  
 [.NET Framework Assembly Unification Overview](http://msdn.microsoft.com/library/8d8cc65e-031d-463b-bde3-2c6dc2e3bc48)
