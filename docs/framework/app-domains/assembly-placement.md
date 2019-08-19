---
title: "Assembly Placement"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "<codeBase> element"
  - "locating assemblies"
  - "assemblies [.NET Framework], placement"
  - "assemblies [.NET Framework], location"
ms.assetid: ff8d48bc-f606-484f-9fe1-d0af264269fb
author: "rpetrusha"
ms.author: "ronpet"
---
# Assembly Placement
For most .NET Framework applications, you locate assemblies that make up an application in the application's directory, in a subdirectory of the application's directory, or in the global assembly cache (if the assembly is shared). You can override where the common language runtime looks for an assembly by using the [\<codeBase> Element](../configure-apps/file-schema/runtime/codebase-element.md) in a configuration file. If the assembly does not have a strong name, the location specified using the [\<codeBase> Element](../configure-apps/file-schema/runtime/codebase-element.md) is restricted to the application directory or a subdirectory. If the assembly has a strong name, the [\<codeBase> Element](../configure-apps/file-schema/runtime/codebase-element.md) can specify any location on the computer or on a network.  
  
 Similar rules apply to locating assemblies when working with unmanaged code or COM interop applications: if the assembly will be shared by multiple applications, it should be installed into the global assembly cache. Assemblies used with unmanaged code must be exported as a type library and registered. Assemblies used by COM interop must be registered in the catalog, although in some cases this registration occurs automatically.  
  
## See also

- [How the Runtime Locates Assemblies](../deployment/how-the-runtime-locates-assemblies.md)
- [Configuring Apps](../configure-apps/index.md)
- [Interoperating with unmanaged code](../interop/index.md)
- [Assemblies in the Common Language Runtime](assemblies-in-the-common-language-runtime.md)
