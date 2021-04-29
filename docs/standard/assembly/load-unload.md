---
title: "How to: Load and unload assemblies"
description: The CLR automatically loads .NET assemblies referenced by a program. You can also dynamically load specific assemblies into the current application domain.
ms.date: 08/19/2019
ms.topic: how-to
---
# How to: Load and unload assemblies

The assemblies referenced by your program will automatically be loaded by the common language runtime, but it is also possible to dynamically load specific assemblies into the current application domain. For more information, see [How to: Load assemblies into an application domain](../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md).

In .NET Framework, there is no way to unload an individual assembly without unloading all of the application domains that contain it. Even if the assembly goes out of scope, the actual assembly file will remain loaded until all application domains that contain it are unloaded. In .NET Core, the <xref:System.Runtime.Loader.AssemblyLoadContext?displayProperty=nameWithType> class handles the unloading of assemblies. For more information, see [How to use and debug assembly unloadability in .NET Core](unloadability.md).

## Load and unload assemblies

To load an assembly into an application domain, use one of the several load methods contained in the classes <xref:System.AppDomain> and <xref:System.Reflection.Assembly>. For more information, see [How to: Load assemblies into an application domain](../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md). Note that .NET Core supports only a single application domain.

To unload an assembly in the .NET Framework, you must unload all of the application domains that contain it. To unload an application domain, use the <xref:System.AppDomain.Unload%2A?displayProperty=nameWithType> method. For more information, see [How to: Unload an application domain](../../framework/app-domains/how-to-unload-an-application-domain.md).

If you want to unload some assemblies but not others in a .NET Framework application, consider creating a new application domain, executing the code inside that domain, and then unloading that application domain. For more information, see [How to: Unload an application domain](../../framework/app-domains/how-to-unload-an-application-domain.md).  

## See also

- [C# programming guide](../../csharp/programming-guide/index.md)
- [Programming concepts (Visual Basic)](../../visual-basic/programming-guide/concepts/index.md)
- [Assemblies in .NET](index.md)
- [How to: Load assemblies into an application domain](../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md)
