---
title: "How to: Load and unload assemblies"
ms.date: 08/19/2019
ms.assetid: 6a4f490f-3576-471f-9533-003737cad4a3
---
# How to: Load and unload assemblies
The assemblies referenced by your program will automatically be loaded by the common language runtime, but it is also possible to dynamically load specific assemblies into the current application domain. For more information, see [How to: Load assemblies into an application domain](../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md).

There is no way to unload an individual assembly without unloading all of the application domains that contain it. Even if the assembly goes out of scope, the actual assembly file will remain loaded until all application domains that contain it are unloaded.  

## Load and unload assemblies

To load an assembly into an application domain, use one of the several load methods contained in the classes <xref:System.AppDomain> and <xref:System.Reflection>. For more information, see [How to: Load assemblies into an application domain](../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md).  

To unload an assembly, you must unload all of the application domains that contain it. To unload an application domain, use the <xref:System.AppDomain.Unload?displayProperty=nameWithType> method. For more information, see [How to: Unload an application domain](../../framework/app-domains/how-to-unload-an-application-domain.md).

If you want to unload some assemblies but not others, consider creating a new application domain, executing the code inside that domain, and then unloading that application domain. For more information, see [How to: Unload an application domain](../../framework/app-domains/how-to-unload-an-application-domain.md).  

## See also

- [C# programming guide](../../csharp/programming-guide/index.md)
- [Programming concepts (Visual Basic)](../../visual-basic/programming-guide/concepts/index.md)
- [Assemblies in .NET](index.md)
- [How to: Load assemblies into an application domain](../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md)
