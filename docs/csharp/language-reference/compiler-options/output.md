---
description: "C# Compiler Options that affect compiler output"
title: "C# Compiler Options - Output options"
ms.date: 02/18/2021
f1_keywords: 
  - "cs.build.options"
  - "Deterministic"
  - "DocumentationFile"
  - "ModuleAssemblyName"
  - "OutputAssembly"
  - "PathMap"
  - "PdbFile"
  - "PlatformTarget"
  - "ProduceReferenceAssembly"
  - "ProduceOnlyReferenceAssembly"
  - "Target"
helpviewer_keywords: 
  - "Deterministic compiler option [C#]"
  - "DocumentationFile compiler option [C#]"
  - "ModuleAssemblyName compiler option [C#]"
  - "OutputAssembly compiler option [C#]"
  - "PathMap compiler option [C#]"
  - "Pdb compiler option [C#]"
  - "PlatformTarget compiler option [C#]"
  - "ProduceReferenceAssembly compiler option [C#]"
  - "ProduceOnlyReferenceAssembly compiler option [C#]"
  - "Target compiler option [C#]"
---
# C# Compiler Options for optimization

The following options control compiler optimizations for size and speed. The new MSBuild syntax is shown in **Bold**. The older `csc.exe` syntax is shown in `code style`.

- **Deterministic** / `-deterministic`: Produce byte-for-byte equivalent output from the same input source.
- **Doc** / `-doc`: Generate XML doc file from `///` comments
- **ModuleAssemblyName** / `-moduleassemblyname`: Specify the output name of the module.
- **OutputAssembly** / `-out`: Specify the output assembly file.
- **PathMap** / `-pathmap`: Specify the mapping from source file paths
- **PdbFile** / `-pdb`: Specify the location of the output pdb file.
- **PlatformTarget** / `-platform`: Specify the target platform CPU.
- **ProduceReferenceAssembly** / `-refout`: Generate a reference assembly.
- **ProduceOnlyReferenceAssembly** `-refonly`: Product only a reference assembly.
- **Target** `-target`: Specify the type of the output assembly.

## Deterministic

Causes the compiler to produce an assembly whose byte-for-byte output is identical across compilations for identical inputs.

```xml
<Deterministic></Deterministic>
```

By default, compiler output from a given set of inputs is unique, since the compiler adds a timestamp and an MVID that is generated from random numbers. You use the `<Deterministic>` option to produce a *deterministic assembly*, one whose binary content is identical across compilations as long as the input remains the same. In such a build, the timestamp and MVID fields will be replaced with values derived from a hash of all the compilation inputs. The compiler considers the following inputs that affect determinism:

- The sequence of command-line parameters.
- The contents of the compiler's .rsp response file.
- The precise version of the compiler used, and its referenced assemblies.
- The current directory path.
- The binary contents of all files explicitly passed to the compiler either directly or indirectly, including:
  - Source files
  - Referenced assemblies
  - Referenced modules
  - Resources
  - The strong name key file
  - @ response files
  - Analyzers
  - Rulesets
  - Other files that may be used by analyzers
- The current culture (for the language in which diagnostics and exception messages are produced).
- The default encoding (or the current code page) if the encoding isn't specified.
- The existence, non-existence, and contents of files on the compiler's search paths (specified, for example, by `-lib` or `-recurse`).
- The Common Language Runtime (CLR) platform on which the compiler is run.
- The value of `%LIBPATH%`, which can affect analyzer dependency loading.

Deterministic compilation can be used for establishing whether a binary is compiled from a trusted source. This can be useful when the source is publicly available. It can also determine whether build steps that are dependent on changes to binary used in the build process.

## DocumentationFile

The **-doc** option allows you to place documentation comments in an XML file. To learn more about documenting your code, see the article on [Recommended Tags for Documentation Comments](../../programming-guide/xmldoc/recommended-tags-for-documentation-comments.md). The value specifies the path to the output XML file. The XML file contains the comments in the source code files of the compilation.

```xml
<DocumentationFile>path/to/file.xml</DocumentationFile>
```

The source code file that contains Main is output first into the XML. You'll often want to use the generated .xml file with [IntelliSense](/visualstudio/ide/using-intellisense). The .xml filename must be the same as the assembly name. The .xml file must be in the same directory as the assembly. When the assembly is referenced in a Visual Studio project, the .xml file is found as well. For more information about generating code comments, see [Supplying Code Comments](/visualstudio/ide/reference/generate-xml-documentation-comments). Unless you compile with [`<TargetType:Module>`](#targetype-module), `file` will contain `<assembly>` and `</assembly>` tags specifying the name of the file containing the assembly manifest for the output file.

> [!NOTE]
> The -doc option applies to all files in the project. To disable warnings related to documentation comments for a specific file or section of code, use [#pragma warning](../preprocessor-directives/preprocessor-pragma-warning.md).

You set the **Optimize** option from **Build** properties page for your project in Visual Studio.

## ModuleAssemblyName

Specifies an assembly whose non-public types a *.netmodule* can access. The `assembly_name` value specifies the name of the assembly whose non-public types the *.netmodule* can access.  

```xml
<ModuleAssemblyName>assembly_name</ModuleAssemblyName>
```

**ModuleAssemblyName** should be used when building a *.netmodule*, and where the following conditions are true:

- The *.netmodule* needs access to non-public types in an existing assembly.
- You know the name of the assembly into which the .netmodule will be built.
- The existing assembly has granted friend assembly access to the assembly into which the .netmodule will be built.

For more information on building a .netmodule, see [-target:module (C# Compiler Options)](./target-module-compiler-option.md). For more information on friend assemblies, see [Friend Assemblies](../../../standard/assembly/friend.md).

## OutputAssembly

The **OutputAssembly** option specifies the name of the output file. The output path specifies the folder where compiler output is placed.

```xml
<OutputAssembly>folder</OutputAssembly>
```

Specify the full name and extension of the file you want to create. If you don't specify the name of the output file:

- An .exe will take its name from the source code file that contains the **Main** method.  
- A .dll or .netmodule will take its name from the first source code file.

Any modules produced as part of a compilation become files associated with any assembly also produced in the compilation. Use [ildasm.exe](../../../framework/tools/ildasm-exe-il-disassembler.md) to view the assembly manifest to see the associated files.

The **OutputAssembly** compiler option is required in order for an exe to be the target of a [friend assembly](../../../standard/assembly/friend.md).

## PathMap

The **PathMap** compiler option specifies how to map physical paths to source path names output by the compiler. This option maps each physical path on the machine where the compiler runs to a corresponding path that should be written in the output files. In the following example, `path1` is the full path to the source files in the current environment, and `sourcePath1` is the source path substituted for `path1` in any output files. To specify multiple mapped source paths, separate each with a semicolon.

```xml
<PathMap>path1=sourcePath1;path2=sourcePath2</PathMap>
```

The compiler writes the source path into its output for the following reasons:

1. The source path is substituted for an argument when the <xref:System.Runtime.CompilerServices.CallerFilePathAttribute> is applied to an optional parameter.
1. The source path is embedded in a PDB file.
1. The path of the PDB file is embedded into a PE (portable executable) file.

## PdbFile

The **PdbFile** compiler option specifies the name and location of the debug symbols file.  The `filename` value specifies the name and location of the debug symbols file.  

```xml
<PdbFile>filename</PdbFile>
```

When you specify [-debug](./debug-compiler-option.md), the compiler will create a *.pdb* file in the same directory where the compiler will create the output file (.exe or .dll). The *.pdb* file has the same base file name as the name of the output file. **PdbFile** allows you to specify a non-default file name and location for the .pdb file. This compiler option cannot be set in the Visual Studio development environment, nor can it be changed programmatically.  

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

## ProduceReferenceAssembly

The **ProduceReferenceAssembly** option specifies a file path where the reference assembly should be output. It translates to `metadataPeStream` in the Emit API. This option corresponds to the [ProduceReferenceAssembly](/visualstudio/msbuild/common-msbuild-project-properties) project property of MSBuild.  The `filepath` specifies the path for the reference assembly. It should generally match that of the primary assembly. The recommended convention (used by MSBuild) is to place the reference assembly in a "ref/" subfolder relative to the primary assembly.

```xml
<ProduceReferenceAssembly>filepath</ProduceReferenceAssembly>
```

Reference assemblies are a special type of assembly that contain only the minimum amount of metadata required to represent the library's public API surface. They include declarations for all members that are significant when referencing an assembly in build tools, but exclude all member implementations and declarations of private members that have no observable impact on their API contract. For more information, see [Reference assemblies](../../../standard/assembly/reference-assemblies.md) in .NET Guide.

The **ProduceReferenceAssembly** and **ProduceOnlyReferenceAssembly** options are mutually exclusive.

## ProduceOnlyReferenceAssembly

The **ProduceOnlyReferenceAssembly** option indicates that a reference assembly should be output instead of an implementation assembly, as the primary output. The **ProduceOnlyReferenceAssembly** parameter silently disables outputting PDBs, as reference assemblies cannot be executed.

```xml
<ProduceOnlyReferenceAssembly></ProduceOnlyReferenceAssembly>
```

Reference assemblies are a special type of assembly. Reference assemblies contain only the minimum amount of metadata required to represent the library's public API surface. They include declarations for all members that are significant when referencing an assembly in build tools, but exclude all member implementations and declarations of private members that have no observable impact on their API contract. For more information, see [Reference assemblies](../../../standard/assembly/reference-assemblies.md) in .NET Guide.

The **ProduceOnlyReferenceAssembly** and **ProduceReferenceAssembly** options are mutually exclusive.

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

If you create an assembly, you can indicate that all or part of your code is CLS compliant with the <xref:System.CLSCompliantAttribute> attribute.

### library

The **library** option causes the compiler to create a dynamic-link library (DLL) rather than an executable file (EXE). The DLL will be created with the .dll extension. Unless otherwise specified with the [-out](./out-compiler-option.md) option, the output file name takes the name of the first input file. When building a .dll file, a [Main](../../programming-guide/main-and-command-args/index.md) method isn't required.

### exe

The **exe** option causes the compiler to create an executable (EXE), console application. The executable file will be created with the .exe extension. Use **winexe** to create a Windows program executable. Unless otherwise specified with the **OutputAssembly** option, the output file name takes the name of the input file that contains the [Main](../../programming-guide/main-and-command-args/index.md) method. One and only one **Main** method is required in the source code files that are compiled into an .exe file. The [-main](./main-compiler-option.md) compiler option lets you specify which class contains the **Main** method, in cases where your code has more than one class with a **Main** method.  

### module

This option causes the compiler to not generate an assembly manifest. By default, the output file created by compiling with this option will have an extension of *.netmodule*. A file that doesn't have an assembly manifest cannot be loaded by the .NET runtime. However, such a file can be incorporated into the assembly manifest of an assembly with **AddModule**. If more than one module is created in a single compilation, [internal](../keywords/internal.md) types in one module will be available to other modules in the compilation. When code in one module references `internal` types in another module, then both modules must be incorporated into an assembly manifest, with **AddModule**. Creating a module isn't supported in the Visual Studio development environment.

### winexe

The **winexe** option causes the compiler to create an executable (EXE), Windows program. The executable file will be created with the .exe extension. A Windows program is one that provides a user interface from either the .NET library or with the Windows APIs. Use **exe** to create a console application. Unless otherwise specified with the **OutputAssembly** option, the output file name takes the name of the input file that contains the [Main](../../programming-guide/main-and-command-args/index.md) method. One and only one **Main** method is required in the source code files that are compiled into an .exe file. The [-main](./main-compiler-option.md) option lets you specify which class contains the **Main** method, in cases where your code has more than one class with a **Main** method.

### winmdobj

If you use the **winmdobj** compiler option, the compiler creates an intermediate .winmdobj file that you can convert to a Windows Runtime binary (*.winmd*) file. The *.winmd* file can then be consumed by JavaScript and C++ programs, in addition to managed language programs.

The **winmdobj** setting signals to the compiler that an intermediate module is required. In response, Visual Studio compiles the C# class library as a *.winmdobj* file. The .winmdobj file can then be fed through the <xref:Microsoft.Build.Tasks.WinMDExp> export tool to produce a Windows metadata (*.winmd*) file. The *.winmd* file contains both the code from the original library and the WinMD metadata that is used by JavaScript or C++ and by the Windows Runtime. The output of a file that’s compiled by using the **winmdobj** compiler option is used only as input for the WimMDExp export tool; the *.winmdobj* file itself isn’t referenced directly. Unless you use the **OutputAssembly** option, the output file name takes the name of the first input file. A [Main](../../programming-guide/main-and-command-args/index.md) method isn’t required.

### appcontainerexe

If you use the **appcontainerexe** compiler option, the compiler creates a Windows executable (*.exe*) file that must be run in an app container. This option is equivalent to [-target:winexe](./target-winexe-compiler-option.md) but is designed for Windows 8.x Store apps.

To require the app to run in an app container, this option sets a bit in the [Portable Executable](/windows/desktop/Debug/pe-format) (PE) file. When that bit is set, an error occurs if the CreateProcess method tries to launch the executable file outside an app container. Unless you use the **OutputAssembly** option, the output file name takes the name of the input file that contains the [Main](../../programming-guide/main-and-command-args/index.md) method.
