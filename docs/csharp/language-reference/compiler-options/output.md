---
description: "C# Compiler Options that control compiler output. These options control the assembly generation from a compilation."
title: "C# Compiler Options - Output options"
ms.date: 03/12/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "DocumentationFile compiler option [C#]"
  - "OutputAssembly compiler option [C#]"
  - "PlatformTarget compiler option [C#]"
  - "ProduceReferenceAssembly compiler option [C#]"
  - "TargetType compiler option [C#]"
---
# C# Compiler Options that control compiler output

The following options control compiler output generation.

| MSBuild | *csc.exe* | Description |
|---|---|---|
| **DocumentationFile** | `-doc:` | Generate XML doc file from `///` comments. |
| **OutputAssembly** | `-out:` | Specify the output assembly file. |
| **PlatformTarget** | `-platform:` | Specify the target platform CPU. |
| **ProduceReferenceAssembly** | `-refout:` | Generate a reference assembly. |
| **TargetType** | `-target:` | Specify the type of the output assembly. |

## DocumentationFile

The **DocumentationFile** option allows you to place documentation comments in an XML file. To learn more about documenting your code, see [Recommended Tags for Documentation Comments](../xmldoc/recommended-tags.md). The value specifies the path to the output XML file. The XML file contains the comments in the source code files of the compilation.

```xml
<DocumentationFile>path/to/file.xml</DocumentationFile>
```

The source code file that contains Main or top-level statements is output first into the XML. You'll often want to use the generated .xml file with [IntelliSense](/visualstudio/ide/using-intellisense). The *.xml* filename must be the same as the assembly name. The *.xml* file must be in the same directory as the assembly. When the assembly is referenced in a Visual Studio project, the *.xml* file is found as well. For more information about generating code comments, see [Supplying Code Comments](/visualstudio/ide/reference/generate-xml-documentation-comments). Unless you compile with [`<TargetType:Module>`](#targettype), `file` will contain `<assembly>` and `</assembly>` tags specifying the name of the file containing the assembly manifest for the output file. For examples, see [How to use the XML documentation features](../xmldoc/index.md).

> [!NOTE]
> The **DocumentationFile** option applies to all files in the project. To disable warnings related to documentation comments for a specific file or section of code, use [#pragma warning](../preprocessor-directives.md#pragma-warning).

This option can be used in any .NET SDK-style project. For more information, see [DocumentationFile property](../../../core/project-sdk/msbuild-props.md#documentationfile).

## OutputAssembly

The **OutputAssembly** option specifies the name of the output file. The output path specifies the folder where compiler output is placed.

```xml
<OutputAssembly>folder</OutputAssembly>
```

Specify the full name and extension of the file you want to create. If you don't specify the name of the output file, MSBuild uses the name of the project to specify the name of the output assembly. Old style projects use the following rules:

- An .exe will take its name from the source code file that contains the `Main` method or top-level statements.  
- A .dll or .netmodule will take its name from the first source code file.

Any modules produced as part of a compilation become files associated with any assembly also produced in the compilation. Use [ildasm.exe](../../../framework/tools/ildasm-exe-il-disassembler.md) to view the assembly manifest to see the associated files.

The **OutputAssembly** compiler option is required in order for an exe to be the target of a [friend assembly](../../../standard/assembly/friend.md).

## PlatformTarget

Specifies which version of the CLR can run the assembly.

```xml
<PlatformTarget>anycpu</PlatformTarget>
```

- **anycpu** (default) compiles your assembly to run on any platform. Your application runs as a 64-bit process whenever possible and falls back to 32-bit when only that mode is available.
- **anycpu32bitpreferred** compiles your assembly to run on any platform. Your application runs in 32-bit mode on systems that support both 64-bit and 32-bit applications. You can specify this option only for projects that target .NET Framework 4.5 or later.
- **ARM** compiles your assembly to run on a computer that has an Advanced RISC Machine (ARM) processor.
- **ARM64** compiles your assembly to run by the 64-bit CLR on a computer that has an Advanced RISC Machine (ARM) processor that supports the A64 instruction set.
- **x64** compiles your assembly to be run by the 64-bit CLR on a computer that supports the AMD64 or EM64T instruction set.
- **x86** compiles your assembly to be run by the 32-bit, x86-compatible CLR.
- **Itanium** compiles your assembly to be run by the 64-bit CLR on a computer with an Itanium processor.

On a 64-bit Windows operating system:

- Assemblies compiled with **x86** execute on the 32-bit CLR running under WOW64.
- A DLL compiled with the **anycpu** executes on the same CLR as the process into which it's loaded.
- Executables that are compiled with the **anycpu** execute on the 64-bit CLR.
- Executables compiled with **anycpu32bitpreferred** execute on the 32-bit CLR.

The **anycpu32bitpreferred** setting is valid only for executable (.EXE) files, and it requires .NET Framework 4.5 or later. For more information about developing an application to run on a Windows 64-bit operating system, see [64-bit Applications](../../../framework/64-bit-apps.md).

You set the **PlatformTarget** option from **Build** properties page for your project in Visual Studio.

The behavior of **anycpu** has some additional nuances on .NET Core and .NET 5 and later releases. When you set **anycpu**, publish your app and execute it with either the x86 `dotnet.exe` or the x64 `dotnet.exe`. For self-contained apps, the `dotnet publish` step packages the executable for the configure RID.

## ProduceReferenceAssembly

The **ProduceReferenceAssembly** option specifies a file path where the reference assembly should be output. It translates to `metadataPeStream` in the Emit API. The `filepath` specifies the path for the reference assembly. It should generally match that of the primary assembly. The recommended convention (used by MSBuild) is to place the reference assembly in a "ref/" subfolder relative to the primary assembly.

```xml
<ProduceReferenceAssembly>filepath</ProduceReferenceAssembly>
```

Reference assemblies are a special type of assembly that contains only the minimum amount of metadata required to represent the library's public API surface. They include declarations for all members that are significant when referencing an assembly in build tools. Reference assemblies exclude all member implementations and declarations of private members. Those members have no observable impact on their API contract. For more information, see [Reference assemblies](../../../standard/assembly/reference-assemblies.md) in the .NET Guide.

The **ProduceReferenceAssembly** and [**ProduceOnlyReferenceAssembly**](./code-generation.md#produceonlyreferenceassembly) options are mutually exclusive.

## TargetType

The **TargetType** compiler option can be specified in one of the following forms:  
  
- **library**: to create a code library. **library** is the default value.
- **exe**: to create an .exe file.  
- **module** to create a module.  
- **winexe** to create a Windows program.
- **winmdobj** to create an intermediate *.winmdobj* file.
- **appcontainerexe** to create an .exe file for Windows 8.x Store apps.
  
> [!NOTE]
> For .NET Framework targets, unless you specify **module**, this option causes a .NET Framework assembly manifest to be placed in an output file. For more information, see [Assemblies in .NET](../../../standard/assembly/index.md) and [Common Attributes](../attributes/global.md).

```xml
<TargetType>library</TargetType>
```

The compiler creates only one assembly manifest per compilation. Information about all files in a compilation is placed in the assembly manifest. When producing multiple output files at the command line, only one assembly manifest can be created and it must go into the first output file specified on the command line.

If you create an assembly, you can indicate that all or part of your code is CLS-compliant with the <xref:System.CLSCompliantAttribute> attribute.

### library

The **library** option causes the compiler to create a dynamic-link library (DLL) rather than an executable file (EXE). The DLL will be created with the *.dll* extension. Unless otherwise specified with the [**OutputAssembly**](#outputassembly) option, the output file name takes the name of the first input file. When building a *.dll* file, a [`Main`](../../fundamentals/program-structure/main-command-line.md) method isn't required.

### exe

The **exe** option causes the compiler to create an executable (EXE), console application. The executable file will be created with the .exe extension. Use **winexe** to create a Windows program executable. Unless otherwise specified with the [**OutputAssembly**](#outputassembly) option, the output file name takes the name of the input file that contains the entry point ([Main](../../fundamentals/program-structure/main-command-line.md) method or top-level statements). One and only one entry point is required in the source code files that are compiled into an .exe file. The [**StartupObject**](./advanced.md#mainentrypoint-or-startupobject) compiler option lets you specify which class contains the `Main` method, in cases where your code has more than one class with a `Main` method.  

### module

This option causes the compiler to not generate an assembly manifest. By default, the output file created by compiling with this option will have an extension of *.netmodule*. A file that doesn't have an assembly manifest cannot be loaded by the .NET runtime. However, such a file can be incorporated into the assembly manifest of an assembly with [**AddModules**](inputs.md#addmodules). If more than one module is created in a single compilation, [internal](../keywords/internal.md) types in one module will be available to other modules in the compilation. When code in one module references `internal` types in another module, then both modules must be incorporated into an assembly manifest, with [**AddModules**](inputs.md#addmodules). Creating a module isn't supported in the Visual Studio development environment.

### winexe

The **winexe** option causes the compiler to create an executable (EXE), Windows program. The executable file will be created with the .exe extension. A Windows program is one that provides a user interface from either the .NET library or with the Windows APIs. Use **exe** to create a console application. Unless otherwise specified with the [**OutputAssembly**](#outputassembly) option, the output file name takes the name of the input file that contains the [`Main`](../../fundamentals/program-structure/main-command-line.md) method. One and only one `Main` method is required in the source code files that are compiled into an .exe file. The [**StartupObject**](./advanced.md#mainentrypoint-or-startupobject) option lets you specify which class contains the `Main` method, in cases where your code has more than one class with a `Main` method.

### winmdobj

If you use the **winmdobj** option, the compiler creates an intermediate *.winmdobj* file that you can convert to a Windows Runtime binary (*.winmd*) file. The *.winmd* file can then be consumed by JavaScript and C++ programs, in addition to managed language programs.

The **winmdobj** setting signals to the compiler that an intermediate module is required. The *.winmdobj* file can then be fed through the <xref:Microsoft.Build.Tasks.WinMDExp> export tool to produce a Windows metadata (*.winmd*) file. The *.winmd* file contains both the code from the original library and the WinMD metadata that is used by JavaScript or C++ and by the Windows Runtime. The output of a file that’s compiled by using the **winmdobj** compiler option is used only as input for the WimMDExp export tool. The *.winmdobj* file itself isn’t referenced directly. Unless you use the [**OutputAssembly**](#outputassembly) option, the output file name takes the name of the first input file. A [`Main`](../../fundamentals/program-structure/main-command-line.md) method isn’t required.

### appcontainerexe

If you use the **appcontainerexe** compiler option, the compiler creates a Windows executable (*.exe*) file that must be run in an app container. This option is equivalent to [-target:winexe](output.md) but is designed for Windows 8.x Store apps.

To require the app to run in an app container, this option sets a bit in the [Portable Executable](/windows/desktop/Debug/pe-format) (PE) file. When that bit is set, an error occurs if the CreateProcess method tries to launch the executable file outside an app container. Unless you use the [**OutputAssembly**](#outputassembly) option, the output file name takes the name of the input file that contains the [`Main`](../../fundamentals/program-structure/main-command-line.md) method.
