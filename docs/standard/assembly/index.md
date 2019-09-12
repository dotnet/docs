---
title: "Assemblies in .NET"
ms.date: 07/10/2018
ms.assetid: 149f5ca5-5b34-4746-9542-1ae43b2d0256
---
# Assemblies in .NET

Assemblies form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions for a .NET-based application. Assemblies take the form of an executable (.exe) file or dynamic link library (.dll) file, and are the building blocks of the .NET applications. They provide the common language runtime with the information it needs to be aware of type implementations. You can think of an assembly as a collection of types and resources that form a logical unit of functionality and are built to work together.

In .NET Core and .NET Framework, an assembly can be built from one or more source code files. In .NET Framework, assemblies can contain one or more modules. This allows larger projects to be planned in such a way that several individual developers work on separate source code files or modules, which are combined to create a single assembly. For more information about modules, see [How to: Build a Multifile Assembly](../../framework/app-domains/how-to-build-a-multifile-assembly.md).

Assemblies have the following properties:

- Assemblies are implemented as .exe or .dll files.

- For libraries that target the .NET Framework, you can share an assembly between applications by putting it in the [global assembly cache](../../framework/app-domains/gac.md). Assemblies must be strong-named before they can be included in the global assembly cache. For more information, see [Strong-Named Assemblies](../../framework/app-domains/strong-named-assemblies.md).

- Assemblies are only loaded into memory if they are required. If they are not used, they are not loaded. This means that assemblies can be an efficient way to manage resources in larger projects.

- You can programmatically obtain information about an assembly by using reflection. For more information, see [Reflection (C#)](../../csharp/programming-guide/concepts/reflection.md) or [Reflection (Visual Basic)](../../visual-basic/programming-guide/concepts/reflection.md).

- You can load an assembly only to inspect by using the <xref:System.Reflection.MetadataLoadContext> class.

## Assembly manifest

Within every assembly is an *assembly manifest*. Similar to a table of contents, the assembly manifest contains the following:

- The assembly's identity (its name and version).

- A file table describing all the other files that make up the assembly, such as other assemblies you created that your .exe or .dll file relies on, or even bitmap or Readme files.

- An *assembly reference list*, which is a list of all external dependencies — .dlls or other files your application needs that may have been created by someone else. Assembly references contain references to both global and private objects. Global objects are available to all other applications. In .NET Core, they are coupled with a particular .NET Core runtime. In .NET Framework, they reside in the global assembly cache. The <xref:System.IO?displayProperty=nameWithType> namespace is an example of an assembly in the global assembly cache. Private objects must be in a directory at either the same level as or below the directory in which your application is installed.

Because assemblies contain information about content, versioning, and dependencies, the applications that use them need not rely on Windows registry values to function properly. Assemblies reduce .dll conflicts and make your applications more reliable and easier to deploy. In many cases, you can install a .NET-based application simply by copying its files to the target computer. For more information, see [Assembly Manifest](../../framework/app-domains/assembly-manifest.md).

## Adding a reference to an assembly

To use an assembly, you must add a reference to it. Next, you can use the [using directive](../../csharp/language-reference/keywords/using-directive.md) for C# or [Imports statement](../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md) for Visual Basic to choose the namespace of the items you want to use. Once an assembly is referenced and imported, all the accessible types, properties, methods, and other members of its namespaces are available to your application as if their code were part of your source file.

> [!NOTE]
> Most assemblies from the .NET Class Library are referenced automatically. In some cases, though, a system assembly may not automatically be referenced. In .NET Core, you can add a reference to the NuGet package that contains the assembly either by using NuGet Package Manager in Visual Studio or by adding a [\<PackageReference>](../../core/tools/dependencies.md#the-new-packagereference-element) element for the assembly to the *.csproj or *.vbproj project. In .NET Framework, you can add a reference to the assembly by using the **Add Reference** dialog in Visual Studio or by using the `-reference` command line option for the [C#](../../csharp/language-reference/compiler-options/reference-compiler-option.md) or [Visual Basic](../../visual-basic/reference/command-line-compiler/reference.md) compilers.

In C#, you can also use two versions of the same assembly in a single application. For more information, see [extern alias](../../csharp/language-reference/keywords/extern-alias.md).

## Creating an assembly

Compile your application by building it in Visual Studio, by building it from the command line by using .NET Core command-line interface (CLI) tools, or by building .NET Framework assemblies with a command-line compiler. For more information about building assemblies using .NET CLI tools, see [.NET Core command-line interface (CLI) tools](../../core/tools/index.md). For building assemblies with the command-line compilers, see [Command-line build with csc.exe](../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md) for C# and [Building from the Command Line](../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md) for Visual Basic.

> [!NOTE]
> To build an assembly in Visual Studio, on the **Build** menu choose **Build**.

## See also

- [.NET assembly file format](file-format.md)
- [Assemblies in the Common Language Runtime](../../framework/app-domains/assemblies-in-the-common-language-runtime.md)
- [Friend Assemblies](friend-assemblies.md)
- [Reference Assemblies](reference-assemblies.md)
- [How to: Load and Unload Assemblies (C#)](../../csharp/programming-guide/concepts/assemblies-gac/how-to-load-and-unload-assemblies.md)
- [How to: Load and Unload Assemblies (Visual Basic)](../../visual-basic/programming-guide/concepts/assemblies-gac/how-to-load-and-unload-assemblies.md)
- [How to: Use and Debug Assembly Unloadability in .NET Core](unloadability-howto.md)
- [How to: Determine If a File Is an Assembly (C#)](../../csharp/programming-guide/concepts/assemblies-gac/how-to-determine-if-a-file-is-an-assembly.md)
- [How to: Determine If a File Is an Assembly (Visual Basic)](../../visual-basic/programming-guide/concepts/assemblies-gac/how-to-determine-if-a-file-is-an-assembly.md)
