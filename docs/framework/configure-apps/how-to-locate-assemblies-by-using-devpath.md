---
title: "How to: Locate Assemblies by Using DEVPATH"
description: Test that a shared assembly works correctly with many applications in .NET by using an XML computer configuration file and the DEVPATH environment variable.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "DEVPATH"
  - ".NET Framework application configuration, assemblies"
  - "application configuration files, specifying assembly's location"
  - "app.config files, assembly locations"
  - "locating assemblies"
  - "assemblies [.NET Framework], location"
ms.assetid: 44d2eadf-7eec-443c-a2ac-d601fd919e17
---
# How to: Locate Assemblies by Using DEVPATH

Developers might want to make sure that a shared assembly they are building works correctly with multiple applications. Instead of continually putting the assembly in the global assembly cache during the development cycle, the developer can create a DEVPATH environment variable that points to the build output directory for the assembly.  
  
 For example, assume that you are building a shared assembly called MySharedAssembly and the output directory is C:\MySharedAssembly\Debug. You can put C:\MySharedAssembly\Debug in the DEVPATH variable. You must then specify the [\<developmentMode>](./file-schema/runtime/developmentmode-element.md) element in the machine configuration file. This element tells the common language runtime to use DEVPATH to locate assemblies.  
  
 The shared assembly must be discoverable by the runtime.  To specify a private directory for resolving assembly references use the [\<codeBase> Element](./file-schema/runtime/codebase-element.md) or [\<probing> Element](./file-schema/runtime/probing-element.md) in a configuration file, as described in [Specifying an Assembly's Location](specify-assembly-location.md).  You can also put the assembly in a subdirectory of the application directory. For more information, see [How the Runtime Locates Assemblies](../deployment/how-the-runtime-locates-assemblies.md).  
  
> [!NOTE]
> This is an advanced feature, intended only for development.  
  
 The following example shows how to cause the runtime to search for assemblies in directories specified by the DEVPATH environment variable.  
  
## Example  
  
```xml  
<configuration>  
  <runtime>  
    <developmentMode developerInstallation="true"/>  
  </runtime>  
</configuration>  
```  
  
 This setting defaults to false.  
  
> [!NOTE]
> Use this setting only at development time. The runtime does not check the versions on strong-named assemblies found in the DEVPATH. It simply uses the first assembly it finds.  
  
## See also

- [Configuring Apps by using Configuration Files](index.md)
