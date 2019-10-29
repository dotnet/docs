---
title: "<publisherPolicy> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding/publisherPolicy"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding/dependentAssembly/publisherPolicy"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#publisherPolicy"
helpviewer_keywords: 
  - "publisherPolicy element"
  - "container tags, <publisherPolicy> element"
  - "<publisherPolicy> element"
ms.assetid: 4613407e-d0a8-4ef2-9f81-a6acb9fdc7d4
---
# \<publisherPolicy> Element
Specifies whether the runtime applies publisher policy.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<assemblyBinding>**](assemblybinding-element-for-runtime.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<dependentAssembly>**](dependentassembly-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<publisherPolicy>**  
  
## Syntax  
  
```xml  
<publisherPolicy apply="yes|no"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`apply`|Specifies whether to apply publisher policy.|  
  
## apply Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`yes`|Applies publisher policy. This is the default setting.|  
|`no`|Does not apply publisher policy.|  
  
### Child Elements  

None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`assemblyBinding`|Contains information about assembly version redirection and the locations of assemblies.|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`dependentAssembly`|Encapsulates binding policy and assembly location for each assembly. Use one `<dependentAssembly>` element for each assembly.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 When a component vendor releases a new version of an assembly, the vendor can include a publisher policy so applications that use the old version now use the new version. To specify whether to apply publisher policy for a particular assembly, put the **\<publisherPolicy>** element in the **\<dependentAssembly>** element.  
  
 The default setting for the **apply** attribute is **yes**. Setting the **apply** attribute to **no** overrides any previous **yes** settings for an assembly.  
  
 Permission is required for an application to explicitly ignore publisher policy using the [\<publisherPolicy apply="no"/>](publisherpolicy-element.md) element in the application configuration file. The permission is granted by setting the <xref:System.Security.Permissions.SecurityPermissionFlag> flag on the <xref:System.Security.Permissions.SecurityPermission>. For more information, see [Assembly Binding Redirection Security Permission](../../assembly-binding-redirection-security-permission.md).  
  
## Example  
 The following example turns off publisher policy for the assembly, `myAssembly`.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <dependentAssembly>  
            <assemblyIdentity name="myAssembly"  
                                    publicKeyToken="32ab4ba45e0a69a1"  
                                    culture="neutral" />  
            <publisherPolicy apply="no"/>  
         </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [How the Runtime Locates Assemblies](../../../deployment/how-the-runtime-locates-assemblies.md)
- [Redirecting Assembly Versions](../../redirect-assembly-versions.md)
