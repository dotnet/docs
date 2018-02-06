---
title: "&lt;assemblyIdentity&gt; Element for &lt;runtime&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding/dependentAssembly/assemblyIdentity"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#assemblyIdentity"
helpviewer_keywords: 
  - "<assemblyIdentity> element"
  - "container tags, <assemblyIdentity> element"
  - "assemblyIdentity element"
ms.assetid: cea4d187-6398-4da4-af09-c1abc6a349c1
caps.latest.revision: 17
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;assemblyIdentity&gt; Element for &lt;runtime&gt;
Contains identifying information about the assembly.  
  
 \<configuration>  
\<runtime>  
\<assemblyBinding>  
\<dependentAssembly>  
\<assemblyIdentity>  
  
## Syntax  
  
```xml  
   <assemblyIdentity    
name="assembly name"  
publicKeyToken="public key token"  
culture="assembly culture"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`name`|Required attribute.<br /><br /> The name of the assembly|  
|`culture`|Optional attribute.<br /><br /> A string that specifies the language and country/region of the assembly.|  
|`publicKeyToken`|Optional attribute.<br /><br /> A hexadecimal value that specifies the strong name of the assembly.|  
|`processorArchitecture`|Optional attribute.<br /><br /> One of the values "x86", "amd64", "msil", or "ia64", specifying the processor architecture for an assembly that contains processor-specific code. The values are not case-sensitive. If the attribute is assigned any other value, the entire `<assemblyIdentity>` element is ignored. See <xref:System.Reflection.ProcessorArchitecture>.|  
  
## processorArchitecture Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`amd64`|A 64-bit AMD processor only.|  
|`ia64`|A 64-bit Intel processor only.|  
|`msil`|Neutral with respect to processor and bits-per-word|  
|`x86`|A 32-bit Intel processor, either native or in the Windows on Windows (WOW) environment on a 64-bit platform.|  
  
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
 Every **\<dependentAssembly>** element must have one **\<assemblyIdentity>** child element.  
  
 If the `processorArchitecture` attribute is present, the `<assemblyIdentity>` element applies only to the assembly with the corresponding processor architecture. If the `processorArchitecture` attribute is not present, the `<assemblyIdentity>` element can apply to an assembly with any processor architecture.  
  
 The following example shows a configuration file for two assemblies with the same name that target two different two processor architectures, and whose versions have not been maintained in synch. When the application executes on the x86 platform the first `<assemblyIdentity>` element applies and the other is ignored. If the application executes on a platform other than x86 or ia64, both are ignored.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <dependentAssembly>  
            <assemblyIdentity name="MyAssembly"  
                  publicKeyToken="14a739be0244c389"  
                  culture="neutral"  
                  processorArchitecture="x86" />  
            <bindingRedirect oldVersion= "1.0.0.0"   
                  newVersion="1.1.0.0" />  
         </dependentAssembly>  
         <dependentAssembly>  
            <assemblyIdentity name="MyAssembly"  
                  publicKeyToken="14a739be0244c389"  
                  culture="neutral"   
                  processorArchitecture="ia64" />  
            <bindingRedirect oldVersion="1.0.0.0"   
                  newVersion="2.0.0.0" />  
         </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
 If a configuration file contains an `<assemblyIdentity>` element with no `processorArchitecture` attribute, and does not contain an element that matches the platform, the element without the `processorArchitecture` attribute is used.  
  
## Example  
 The following example shows how to provide information about an assembly.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <dependentAssembly>  
            <assemblyIdentity name="myAssembly"  
                              publicKeyToken="32ab4ba45e0a69a1"  
                              culture="neutral" />  
            <!--Redirection and codeBase policy for myAssembly.-->  
         </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Redirecting Assembly Versions](../../../../../docs/framework/configure-apps/redirect-assembly-versions.md)
