---
title: "Attributes interpreted by the compiler: Global attributes"
ms.date: 01/14/2026
description: Attributes provide metadata the compiler uses to understand more semantics of your program
---
# Assembly level attributes interpreted by the C# compiler

Most attributes apply to specific language elements such as classes or methods. However, some attributes are global. They apply to an entire assembly or module. For example, use the <xref:System.Reflection.AssemblyVersionAttribute> attribute to embed version information into an assembly, like this:

```csharp
[assembly: AssemblyVersion("1.0.0.0")]
```

Global attributes appear in the source code after any top level `using` directives and before any type, module, or namespace declarations. You can include global attributes in multiple source files, but you must compile the files in a single compilation pass. In .NET Framework projects, Visual Studio adds global attributes to the AssemblyInfo.cs file. These attributes aren't added to .NET Core projects.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Assembly attributes provide information about an assembly. They fall into the following categories:

- Assembly identity attributes
- Informational attributes
- Assembly manifest attributes

## Assembly identity attributes

Three attributes (with a strong name, if applicable) determine the identity of an assembly: name, version, and culture. These attributes form the full name of the assembly and are required when you reference it in code. You can set an assembly's version and culture by using attributes. However, you set the name value by the compiler, the Visual Studio IDE in the [Assembly Information Dialog Box](/visualstudio/ide/reference/assembly-information-dialog-box), or the Assembly Linker (Al.exe) when you create the assembly. The assembly name is based on the assembly manifest. The <xref:System.Reflection.AssemblyFlagsAttribute> attribute specifies whether multiple copies of the assembly can coexist.

The following table shows the identity attributes.

| Attribute                                         | Purpose                                        |
|---------------------------------------------------|------------------------------------------------|
| <xref:System.Reflection.AssemblyVersionAttribute> | Specifies the version of an assembly.          |
| <xref:System.Reflection.AssemblyCultureAttribute> | Specifies which culture the assembly supports. |
| <xref:System.Reflection.AssemblyFlagsAttribute>   | Specifies a bitwise combination of flags for an assembly, describing just-in-time (JIT) compiler options, whether the assembly is retargetable, and whether it has a full or tokenized public key. |

## Informational attributes

Use informational attributes to provide more company or product information for an assembly. The following table shows the informational attributes defined in the <xref:System.Reflection?displayProperty=nameWithType> namespace.

| Attribute                                                      | Purpose                                                      |
|----------------------------------------------------------------|--------------------------------------------------------------|
| <xref:System.Reflection.AssemblyProductAttribute>              | Specifies a product name for an assembly manifest.           |
| <xref:System.Reflection.AssemblyTrademarkAttribute>            | Specifies a trademark for an assembly manifest.              |
| <xref:System.Reflection.AssemblyInformationalVersionAttribute> | Specifies an informational version for an assembly manifest. |
| <xref:System.Reflection.AssemblyCompanyAttribute>              | Specifies a company name for an assembly manifest.           |
| <xref:System.Reflection.AssemblyCopyrightAttribute>            | Defines a custom attribute that specifies a copyright for an assembly manifest. |
| <xref:System.Reflection.AssemblyFileVersionAttribute>          | Sets a specific version number for the Win32 file version resource. |
| <xref:System.CLSCompliantAttribute>                            | Indicates whether the assembly is compliant with the Common Language Specification (CLS). |

## Assembly manifest attributes

Use assembly manifest attributes to provide information in the assembly manifest. The attributes include title, description, default alias, and configuration. The following table shows the assembly manifest attributes defined in the <xref:System.Reflection?displayProperty=nameWithType> namespace.

| Attribute                                               | Purpose                                                     |
|---------------------------------------------------------|-------------------------------------------------------------|
| <xref:System.Reflection.AssemblyTitleAttribute>         | Specifies an assembly title for an assembly manifest.       |
| <xref:System.Reflection.AssemblyDescriptionAttribute>   | Specifies an assembly description for an assembly manifest. |
| <xref:System.Reflection.AssemblyConfigurationAttribute> | Specifies an assembly configuration (such as retail or debug) for an assembly manifest. |
| <xref:System.Reflection.AssemblyDefaultAliasAttribute>  | Defines a friendly default alias for an assembly manifest.  |
