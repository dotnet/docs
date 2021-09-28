---
title: "Using Serviced Components with the Global Assembly Cache"
description: Use serviced components (managed code COM+ components) with the global assembly cache in .NET. See if the CLR and COM+ services can handle non-GAC components.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "assemblies [.NET Framework], global assembly cache"
  - "GAC (global assembly cache), serviced components"
  - "serviced components, global assembly cache"
  - "global assembly cache, serviced components"
ms.assetid: 3423e5d9-234c-4571-8161-e35f6d130128
---
# Using Serviced Components with the Global Assembly Cache

Serviced components (managed code COM+ components) should be put in the Global Assembly Cache. In some scenarios, the Common Language Runtime and COM+ Services can handle serviced components that are not in the Global Assembly Cache; in other scenarios, they cannot. The following scenarios illustrate this:  
  
- For serviced components in a COM+ Server application, the assembly containing the components must be in the Global Assembly Cache, because Dllhost.exe does not run in the same directory as the one that contains the serviced components.  
  
- For serviced components in a COM+ Library application, the runtime and COM+ Services can resolve the reference to the assembly containing the components by searching in the current directory. In this case, the assembly does not have to be in the global assembly cache.  
  
- For serviced components in an ASP.NET application, the situation is different. If you place the assembly containing the serviced components in the bin directory of the application base and use on-demand registration, the assembly will be shadow-copied into the download cache because ASP.NET leverages the shadow capabilities of the runtime.  
  
## See also

- [Working with Assemblies and the Global Assembly Cache](working-with-assemblies-and-the-gac.md)
- [Gacutil.exe (Global Assembly Cache Tool)](../tools/gacutil-exe-gac-tool.md)
