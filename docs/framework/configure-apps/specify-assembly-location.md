---
title: "Specifying an Assembly's Location"
description: See how to specify the location of an assembly in .NET by using the codeBase element or the probing element in an XML configuration file.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "configuration [.NET Framework], applications"
  - "application configuration [.NET Framework]"
  - "assemblies [.NET Framework], specifying location"
ms.assetid: 1cb92bd7-6bab-44cf-8fd3-36303ce84fea
---
# Specifying an Assembly's Location

There are two ways to specify an assembly's location:  
  
- Using the [\<codeBase>](./file-schema/runtime/codebase-element.md) element.  
  
- Using the [\<probing>](./file-schema/runtime/probing-element.md) element.  
  
 You can also use the [.NET Framework Configuration Tool (Mscorcfg.msc)](/previous-versions/dotnet/netframework-4.0/2bc0cxhc(v=vs.100)) to specify assembly locations or specify locations for the common language runtime to probe for assemblies.  
  
## Using the \<codeBase> Element  

 You can use the **\<codeBase>** element only in machine configuration or publisher policy files that also redirect the assembly version. When the runtime determines which assembly version to use, it applies the code base setting from the file that determines the version. If no code base is indicated, the runtime probes for the assembly in the normal way. For details, see [How the Runtime Locates Assemblies](../deployment/how-the-runtime-locates-assemblies.md).  
  
 The following example shows how to specify an assembly's location.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
       <dependentAssembly>  
         <assemblyIdentity name="myAssembly"  
                           publicKeyToken="32ab4ba45e0a69a1"  
                           culture="en-us" />  
         <codeBase version="2.0.0.0"  
                   href="http://www.litwareinc.com/myAssembly.dll"/>  
       </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
 The **version** attribute is required for all strong-named assemblies but should be omitted for assemblies that are not strong-named. The **\<codeBase>** element requires the **href** attribute. You cannot specify version ranges in the **\<codeBase>** element.  
  
> [!NOTE]
> If you are supplying a code base hint for an assembly that is not strong-named, the hint must point to the application base or a subdirectory of the application base directory.  
  
## Using the \<probing> Element  

 The runtime locates assemblies that do not have a code base by probing. For more information about probing, see [How the Runtime Locates Assemblies](../deployment/how-the-runtime-locates-assemblies.md).  
  
 You can use the [\<probing>](./file-schema/runtime/probing-element.md) element in the application configuration file to specify subdirectories the runtime should search when locating an assembly. The following example shows how to specify directories the runtime should search.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <probing privatePath="bin;bin2\subbin;bin3"/>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
 The **privatePath** attribute contains the directories that the runtime should search for assemblies. If the application is located at C:\Program Files\MyApp, the runtime will look for assemblies that do not specify a code base in C:\Program Files\MyApp\Bin, C:\Program Files\MyApp\Bin2\Subbin, and C:\Program Files\MyApp\Bin3. The directories specified in **privatePath** must be subdirectories of the application base directory.  
  
## See also

- [Assemblies in .NET](../../standard/assembly/index.md)
- [Programming with Assemblies](../../standard/assembly/index.md)
- [How the Runtime Locates Assemblies](../deployment/how-the-runtime-locates-assemblies.md)
- [Configuring Apps by using Configuration Files](index.md)
