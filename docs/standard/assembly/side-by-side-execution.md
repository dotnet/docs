---
title: "Assemblies and side-by-side execution"
description: Learn about side-by-side execution, which is the ability to store and run multiple versions of an application or component on the same computer.
ms.date: "08/20/2019"
helpviewer_keywords: 
  - "side-by-side execution [.NET]"
  - "assemblies [.NET], side-by-side execution"
ms.assetid: e42036ee-7590-47d1-b884-cc856e39bd5d
---
# Assemblies and side-by-side execution

Side-by-side execution is the ability to store and execute multiple versions of an application or component on the same computer. This means that you can have multiple versions of the runtime, and multiple versions of applications and components that use a version of the runtime, on the same computer at the same time. Side-by-side execution gives you more control over what versions of a component an application binds to, and more control over what version of the runtime an application uses.  
  
Support for side-by-side storage and execution of different versions of the same assembly is an integral part of strong naming and is built into the infrastructure of the runtime. Because the strong-named assembly's version number is part of its identity, the runtime can store multiple versions of the same assembly in the global assembly cache and load those assemblies at run time.  
  
Although the runtime provides you with the ability to create side-by-side applications, side-by-side execution is not automatic. For more information on creating applications for side-by-side execution, see [Guidelines for creating components for side-by-side execution](../../framework/deployment/guidelines-for-creating-components-for-side-by-side-execution.md).  
  
## See also

- [How the runtime locates assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md)
- [Assemblies in .NET](index.md)
