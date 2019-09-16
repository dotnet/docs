---
title: "Compiling an Interop Project"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "interoperation with unmanaged code, compiling"
  - "COM interop, compiling"
  - "exposing COM components to .NET Framework"
  - "compiling interop projects"
  - "interoperation with unmanaged code, exposing COM components"
  - "COM interop, exposing COM components"
ms.assetid: 6fcf6588-5e25-41af-b4ae-780974f2c3df
author: "rpetrusha"
ms.author: "ronpet"
---
# Compiling an Interop Project

COM interop projects that reference one or more assemblies containing imported COM types are compiled like any other managed project. You can reference interop assemblies in a development environment such as Visual Studio, or you can reference them when you use a command-line compiler. In either case, to compile properly, the interop assembly must be in the same directory as the other project files.

 There are two ways to reference interop assemblies:

- Embedded interop types: Beginning with the .NET Framework 4 and Visual Studio 2010, you can instruct the compiler to embed type information from an interop assembly into your executable. This is the recommended technique.

- Deploying interop assemblies: You can create a standard reference to an interop assembly. In this case, the interop assembly must be deployed with your application.

 The differences between these two techniques are discussed in greater detail in [Using COM Types in Managed Code](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/3y76b69k(v=vs.100)).

 Embedding interop types with Visual Studio is demonstrated in [Walkthrough: Embedding Types from Managed Assemblies in Visual Studio](../../standard/assembly/embed-types-visual-studio.md).

 To reference an interop assembly with a command-line compiler and embed type information in your executables, use the [/link (C# Compiler Options)](../../csharp/language-reference/compiler-options/link-compiler-option.md) or the [/link (Visual Basic)](../../visual-basic/reference/command-line-compiler/link.md) compiler switch and specify the name of the interop assembly.

> [!NOTE]
> Visual C++ applications cannot embed type information, but they can interoperate with applications or add-ins that do.

 To compile an application that includes a primary interop assembly when it is deployed, use the **/reference** compiler switch and specify the name of the interop assembly.

## See also

- [Exposing COM Components to the .NET Framework](exposing-com-components.md)
- [Language Independence and Language-Independent Components](../../standard/language-independence-and-language-independent-components.md)
- [Using COM Types in Managed Code](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/3y76b69k(v=vs.100))
- [Walkthrough: Embedding Types from Managed Assemblies in Visual Studio](../../standard/assembly/embed-types-visual-studio.md)
- [Importing a Type Library as an Assembly](importing-a-type-library-as-an-assembly.md)
