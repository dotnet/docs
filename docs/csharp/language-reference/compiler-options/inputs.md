---
description: "C# Compiler Options to control input files for compilation. These options specify how the compiler reads metadata from dependent assemblies and modules."
title: "C# Compiler Options - input file options"
ms.date: 03/12/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "References compiler option [C#]"
  - "AddModules compiler option [C#]"
  - "EmbedInteropTypes compiler option [C#]"
---
# C# Compiler Options that specify inputs

The following options control compiler inputs. The new MSBuild syntax is shown in **Bold**. The older *csc.exe* syntax is shown in `code style`.

- **References** / `-reference` or `-references`: Reference metadata from the specified assembly file or files.
- **AddModules** / `-addmodule`: Add a module (created with `target:module` to this assembly.)
- **EmbedInteropTypes** / `-link`: Embed metadata from the specified interop assembly files.

## References

The **References** option causes the compiler to import [public](../keywords/public.md) type information in the specified file into the current project, enabling you to reference metadata from the specified assembly files.

```xml
<Reference Include="filename" />
```

 `filename` is the name of a file that contains an assembly manifest. To import more than one file, include a separate **Reference** element for each file. You can define an alias as a child element of the **Reference** element:

```xml
<Reference Include="filename.dll">
  <Aliases>LS</Aliases>
</Reference>
```

In the previous example, `LS` is the valid C# identifier that represents a root namespace that will contain all namespaces in the assembly *filename.dll*. The files you import must contain a manifest. Use [**AdditionalLibPaths**](advanced.md#additionallibpaths) to specify the directory in which one or more of your assembly references is located. The [**AdditionalLibPaths**](advanced.md#additionallibpaths) topic also discusses the directories in which the compiler searches for assemblies. In order for the compiler to recognize a type in an assembly, and not in a module, it needs to be forced to resolve the type, which you can do by defining an instance of the type. There are other ways to resolve type names in an assembly for the compiler: for example, if you inherit from a type in an assembly, the type name will then be recognized by the compiler. Sometimes it is necessary to reference two different versions of the same component from within one assembly. To do this, use the **Aliases** element on the **References** element for each file to distinguish between the two files. This alias will be used as a qualifier for the component name, and will resolve to the component in one of the files.

> [!NOTE]
> In Visual Studio, use the **Add Reference** command. For more information, see [How to: Add or Remove References By Using the Reference Manager](/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager).

## AddModules

This option adds a module that was created with the `<TargetType>module</TargetType>` switch to the current compilation:

```xml
<AddModule Include=file1 />
<AddModule Include=file2 />
```

Where `file`, `file2` are output files that contain metadata. The file can't contain an assembly manifest. To import more than one file, separate file names with either a comma or a semicolon. All modules added with **AddModules** must be in the same directory as the output file at run time. That is, you can specify a module in any directory at compile time but the module must be in the application directory at run time. If the module isn't in the application directory at run time, you'll get a <xref:System.TypeLoadException>. `file` can't contain an assembly. For example, if the output file was created with [**TargetType**](output.md#targettype) option of **module**, its metadata can be imported with **AddModules**.

If the output file was created with a [**TargetType**](output.md#targettype) option other than **module**, its metadata cannot be imported with **AddModules** but can be imported with the [**References**](#references) option.

## EmbedInteropTypes

Causes the compiler to make COM type information in the specified assemblies available to the project that you are currently compiling.

```xml
<References>
  <EmbedInteropTypes>file1;file2;file3</EmbedInteropTypes>
</References>
```

Where  `file1;file2;file3` is a semicolon-delimited list of assembly file names. If the file name contains a space, enclose the name in quotation marks. The **EmbedInteropTypes** option enables you to deploy an application that has embedded type information. The application can then use types in a runtime assembly that implement the embedded type information without requiring a reference to the runtime assembly. If various versions of the runtime assembly are published, the application that contains the embedded type information can work with the various versions without having to be recompiled. For an example, see [Walkthrough: Embedding Types from Managed Assemblies](../../../standard/assembly/embed-types-visual-studio.md).

Using the **EmbedInteropTypes** option is especially useful when you're working with COM interop. You can embed COM types so that your application no longer requires a primary interop assembly (PIA) on the target computer. The **EmbedInteropTypes** option instructs the compiler to embed the COM type information from the referenced interop assembly into the resulting compiled code. The COM type is identified by the CLSID (GUID) value. As a result, your application can run on a target computer that has installed the same COM types with the same CLSID values. Applications that automate Microsoft Office are a good example. Because applications like Office usually keep the same CLSID value across different versions, your application can use the referenced COM types as long as .NET Framework 4 or later is installed on the target computer and your application uses methods, properties, or events that are included in the referenced COM types. The **EmbedInteropTypes** option embeds only interfaces, structures, and delegates. Embedding COM classes isn't supported.

> [!NOTE]
> When you create an instance of an embedded COM type in your code, you must create the instance by using the appropriate interface. Attempting to create an instance of an embedded COM type by using the CoClass causes an error.

Like the [**References**](#references) compiler option, the **EmbedInteropTypes** compiler option uses the Csc.rsp response file, which references frequently used .NET assemblies. Use the [**NoConfig**](miscellaneous.md#noconfig) compiler option if you don't want the compiler to use the Csc.rsp file.

[!code-csharp[VbLinkCompilerCS#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/vblinkcompilercs/cs/program.cs#1)]

Types that have a generic parameter whose type is embedded from an interop assembly cannot be used if that type is from an external assembly. This restriction doesn't apply to interfaces. For example, consider the <xref:Microsoft.Office.Interop.Excel.Range> interface that is defined in the <xref:Microsoft.Office.Interop.Excel> assembly. If a library embeds interop types from the <xref:Microsoft.Office.Interop.Excel> assembly and exposes a method that returns a generic type that has a parameter whose type is the <xref:Microsoft.Office.Interop.Excel.Range> interface, that method must return a generic interface, as shown in the following code example.

[!code-csharp[VbLinkCompilerCS#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/vblinkcompilercs/cs/utility.cs)]

In the following example, client code can call the method that returns the <xref:System.Collections.IList> generic interface without error.

[!code-csharp[VbLinkCompilerCS#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/vblinkcompilercs/cs/program.cs#5)]
