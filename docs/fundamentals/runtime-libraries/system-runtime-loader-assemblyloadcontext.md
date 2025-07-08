---
title: System.Runtime.Loader.AssemblyLoadContext class
description: Learn about the System.Runtime.Loader.AssemblyLoadContext class.
ms.date: 12/31/2023
---
# System.Runtime.Loader.AssemblyLoadContext class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.Loader.AssemblyLoadContext> represents a load context. Conceptually, a load context creates a scope for loading, resolving, and potentially unloading a set of assemblies.

The <xref:System.Runtime.Loader.AssemblyLoadContext> exists primarily to provide assembly loading isolation. It allows multiple versions of the same assembly to be loaded within a single process. It replaces the isolation mechanisms provided by multiple <xref:System.AppDomain> instances in .NET Framework.

> [!NOTE]
>
> * <xref:System.Runtime.Loader.AssemblyLoadContext> does not provide any security features. All code has full permissions of the process.
> * In .NET Core 2.0 - 2.2 only, <xref:System.Runtime.Loader.AssemblyLoadContext> is an abstract class. To create a concrete class in these versions, implement the <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> method.

## Usage in the runtime

The runtime implements two assembly load contexts:

* <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> represents the runtime's default context, which is used for the application main assembly and its static dependencies.
* The <xref:System.Reflection.Assembly.LoadFile(System.String)?displayProperty=nameWithType> method isolates the assemblies it loads by instantiating the most basic <xref:System.Runtime.Loader.AssemblyLoadContext>. It has a simplistic isolation scheme that loads each assembly in its own <xref:System.Runtime.Loader.AssemblyLoadContext> with no dependency resolution.

### Application usage

An application can create its own <xref:System.Runtime.Loader.AssemblyLoadContext> to create a custom solution for advanced scenarios. The customization focuses on defining dependency resolution mechanisms.

The <xref:System.Runtime.Loader.AssemblyLoadContext> provides two extension points to implement managed assembly resolution:

1. The <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> method provides the first chance for the <xref:System.Runtime.Loader.AssemblyLoadContext> to resolve, load, and return the assembly. If the <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> method returns `null`, the loader tries to load the assembly into the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType>.
2. If the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> is unable to resolve the assembly, the original <xref:System.Runtime.Loader.AssemblyLoadContext> gets a second chance to resolve the assembly. The runtime raises the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving> event.

Additionally, the <xref:System.Runtime.Loader.AssemblyLoadContext.LoadUnmanagedDll(System.String)?displayProperty=nameWithType> virtual method allows customization of the default unmanaged assembly resolution. The default implementation returns `null`, which causes the runtime search to use its default search policy. The default search policy is sufficient for most scenarios.

## Technical challenges

* It's not possible to load multiple versions of the runtime in a single process.

   > [!CAUTION]
   > Loading multiple copies or different versions of framework assemblies can lead to unexpected and hard-to-diagnose behavior.

   > [!TIP]
   > Use process boundaries with remoting or interprocess communication to solve this isolation problem.

* The timing of assembly loading can make testing and debugging difficult. Assemblies are typically loaded without their dependencies immediately being resolved. The dependencies are loaded as they are needed:

  * When code branches into a dependent assembly.
  * When code loads resources.
  * When code explicitly loads assemblies.

* The implementation of <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> can add new dependencies that may need to be isolated to allow different versions to exist. The most natural implementation would place these dependencies in the default context. Careful design can isolate the new dependencies.

* The same assembly is loaded multiple times into different contexts.

  * This can lead to confusing error messages, for example "Unable to cast object of type 'Sample.Plugin' to type 'Sample.Plugin'".
  * Marshaling across isolation boundaries is non-trivial. A typical solution is to use an interface defined in an assembly that's only loaded into the default load context.
