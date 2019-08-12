---
title: "Assembly Location"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "locating assemblies"
  - "assemblies [.NET Framework], location"
ms.assetid: 9f1f41a7-2954-49d3-a2c0-62b6ef4d40ab
author: "rpetrusha"
ms.author: "ronpet"
---
# Assembly Location
An assembly's location determines whether the common language runtime can locate it when referenced, and can also determine whether the assembly can be shared with other assemblies. You can deploy an assembly in the following locations:  
  
- The application's directory or subdirectories.  
  
     This is the most common location for deploying an assembly. The subdirectories of an application's root directory can be based on language or culture. If an assembly has information in the culture attribute, it must be in a subdirectory under the application directory with that culture's name.  
  
- The global assembly cache.  
  
     This is a machine-wide code cache that is installed wherever the common language runtime is installed. In most cases, if you intend to share an assembly with multiple applications, you should deploy it into the global assembly cache.  
  
- On an HTTP server.  
  
     An assembly deployed on an HTTP server must have a strong name; you point to the assembly in the codebase section of the application's configuration file.  
  
## See also

- [Creating Assemblies](create-assemblies.md)
- [Global Assembly Cache](../../framework/app-domains/gac.md)
- [How the Runtime Locates Assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md)
- [Programming with Assemblies](programming-with-assemblies.md)
