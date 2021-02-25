---
description: "C# Compiler Options to control input files for compilation"
title: "C# Compiler Options - input file options"
ms.date: 02/18/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "FileAlignment compiler option [C#]"
  - "Optimize compiler option [C#]"
---
# C# Compiler Options that specify inputs

The following options control compiler inputs. The new MSBuild syntax is shown in **Bold**. The older `csc.exe` syntax is shown in `code style`.

- **AddModules** / `-addmodule`: Add a module (created with `target:module` to this assembly.)
- **References** / `-reference` or `-references`: Reference metadata from the specified assembly file or files.
- **??** / `-recurse`: Include all files in the current directory and subdirectories according to the wildcard specifications
- **??** / `-link`: Embed metadata from the specified interop assembly files.
- **??** / `-analyzer`: Run the analyzers from the specified assembly.
- **??** / `-additionalfile`: Add additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.

## AddModules

This option adds a module that was created with the `<TargetType>module</TargetType>` switch to the current compilation:

```xml
<AddModules>file1,file2</AddModules>
```

Where `file`, `file2` are output files that contain metadata. The file cannot contain an assembly manifest. To import more than one file, separate file names with either a comma or a semicolon. All modules added with **AddModules** must be in the same directory as the output file at run time. That is, you can specify a module in any directory at compile time but the module must be in the application directory at run time. If the module is not in the application directory at run time, you will get a <xref:System.TypeLoadException>. `file` cannot contain an assembly. For example, if the output file was created with [-target:module](./target-module-compiler-option.md), its metadata can be imported with **AddModules**.

If the output file was created with a **TargetType** option other than **module**, its metadata cannot be imported with **AddModules** but can be imported with [**References**](#references) option.

## References

The **References** option causes the compiler to import [public](../keywords/public.md) type information in the specified file into the current project, thus enabling you to reference metadata from the specified assembly files.

```xml
<Reference Include="filename" />
```

 `filename` is the name of a file that contains an assembly manifest. To import more than one file, include a separate **Reference** option for each file. You can define an alias as a child element of the **Reference** element:

```xml
<Reference Include="filename.dll">
  <Aliases>LS</Aliases>
</Reference>
``

In the previous example, `LS` is the valid C# identifier that represents a root namespace that will contain all namespaces in the assembly *filename.dll*. To import from more than one file, include a **Reference** element for each file. The files you import must contain a manifest. Use [-lib](./lib-compiler-option.md) to specify the directory in which one or more of your assembly references is located. The **-lib** topic also discusses the directories in which the compiler searches for assemblies. In order for the compiler to recognize a type in an assembly, and not in a module, it needs to be forced to resolve the type, which you can do by defining an instance of the type. There are other ways to resolve type names in an assembly for the compiler: for example, if you inherit from a type in an assembly, the type name will then be recognized by the compiler. Sometimes it is necessary to reference two different versions of the same component from within one assembly. To do this, use the **Aliases** element on the **Reference** element for each file to distinguish between the two files. This alias will be used as a qualifier for the component name, and will resolve to the component in one of the files.

> [!NOTE]
> In Visual Studio, use the **Add Reference** command. For more information, see [How to: Add or Remove References By Using the Reference Manager](/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager).
