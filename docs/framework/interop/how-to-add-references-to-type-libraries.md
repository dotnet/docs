---
title: "How to: Add References to Type Libraries"
description: Understand how to add references to type libraries in Visual Studio or for command-line compilation.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "importing type library"
  - "interop assemblies, generating"
  - "type libraries"
  - "COM interop, importing type library"
ms.assetid: f5cfa6ba-cc25-4017-82cd-ba7391859113
---
# How to: Add References to Type Libraries

Visual Studio generates an interop assembly containing metadata when you add a reference to a type library. If a primary interop assembly is available, Visual Studio uses the existing assembly before generating a new interop assembly.  
  
### To add a reference to a type library in Visual Studio  
  
1. Install the COM DLL or EXE file on your computer, unless a Windows Setup.exe file performs the installation for you.  
  
2. Choose **Project**, **Add Reference**.  
  
3. In the Reference Manager, choose **COM**.  
  
4. Select the type library from the list, or browse for the .tlb file.  
  
5. Choose **OK**.  
  
6. In Solution Explorer, open the shortcut menu for the reference you just added, and then choose **Properties**.  
  
7. In the **Properties** window, make sure that the **Embed Interop Types** property is set to **True**. This causes Visual Studio to embed type information for COM types in your executables, eliminating the need to deploy primary interop assemblies with your app.  
  
> [!NOTE]
> The menu and dialog box options may vary depending on the version of Visual Studio you're using.  
  
### To add a reference to a type library for command-line compilation  
  
1. Generate an interop assembly as described in [How to: Generate Interop Assemblies from Type Libraries](how-to-generate-interop-assemblies-from-type-libraries.md).  
  
2. Use the [-link (C# Compiler Options)](../../csharp/language-reference/compiler-options/inputs.md#embedinteroptypes) or [-link (Visual Basic)](../../visual-basic/reference/command-line-compiler/link.md) compiler option with the interop assembly name to embed type information for COM types in your executables.  
  
## See also

- [Importing a Type Library as an Assembly](importing-a-type-library-as-an-assembly.md)
- [Exposing COM Components to the .NET Framework](exposing-com-components.md)
- [Walkthrough: Embedding Types from Managed Assemblies in Visual Studio](../../standard/assembly/embed-types-visual-studio.md)
- [-link (C# Compiler Options)](../../csharp/language-reference/compiler-options/inputs.md#embedinteroptypes)
- [-link (Visual Basic)](../../visual-basic/reference/command-line-compiler/link.md)
