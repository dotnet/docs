---
description: "Learn more about: <appDomainManagerType> Element"
title: "<appDomainManagerType> Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "appDomainManagerType element"
  - "<appDomainManagerType> element"
ms.assetid: ae8d5a7e-e7f7-47f7-98d9-455cc243a322
---
# \<appDomainManagerType> Element

Specifies the type that serves as the application domain manager for the default application domain.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<appDomainManagerType>**  
  
## Syntax  
  
```xml  
<appDomainManagerAssembly
   value="type name" />  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`value`|Required attribute. Specifies the name of the type, including the namespace, that serves as the application domain manager for the default application domain in the process.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  

 To specify the type of the application domain manager, you must specify both this element and the [\<appDomainManagerAssembly>](appdomainmanagerassembly-element.md) element. If either of these elements is not specified, the other is ignored.  
  
 When the default application domain is loaded, <xref:System.TypeLoadException> is thrown if the specified type does not exist in the assembly that is specified by the [\<appDomainManagerAssembly>](appdomainmanagerassembly-element.md) element; and the process fails to start.  
  
 When you specify the application domain manager type for the default application domain, other application domains created from the default application domain inherit the application domain manager type. Use the <xref:System.AppDomainSetup.AppDomainManagerType%2A?displayProperty=nameWithType> and <xref:System.AppDomainSetup.AppDomainManagerAssembly%2A?displayProperty=nameWithType> properties to specify a different application domain manager type for a new application domain.  
  
 Specifying the application domain manager type requires the application to have full trust. (For example, an application running on the desktop has full trust.) If the application does not have full trust, a <xref:System.TypeLoadException> is thrown.  
  
 The format of the type and namespace is the same format that is used for the <xref:System.Type.FullName%2A?displayProperty=nameWithType> property.  
  
 This configuration element is available only in the .NET Framework 4 and later.  
  
## Example  

 The following example shows how to specify that the application domain manager for the default application domain of a process is the `MyMgr` type in the `AdMgrExample` assembly.  
  
```xml  
<configuration>  
   <runtime>  
      <appDomainManagerType value="MyMgr" />  
      <appDomainManagerAssembly
         value="AdMgrExample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6856bccf150f00b3" />  
   </runtime>  
</configuration>  
```  
  
## See also

- <xref:System.AppDomainSetup.AppDomainManagerType%2A?displayProperty=nameWithType>
- <xref:System.AppDomainSetup.AppDomainManagerAssembly%2A?displayProperty=nameWithType>
- [\<appDomainManagerAssembly> Element](appdomainmanagerassembly-element.md)
- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [SetAppDomainManagerType Method](../../../unmanaged-api/hosting/iclrcontrol-setappdomainmanagertype-method.md)
