---
title: "Set assembly attributes in project files"
description: Learn how you can set assembly attributes using a project file.
ms.date: 01/19/2024
ms.topic: how-to
---

# Set assembly attributes in a project file

You can use an MSBuild property to [transform package-related project properties](#use-package-properties-as-assembly-attributes) into assembly attributes in a generated code file. Further, you can use MSBuild items to add [arbitrary assembly attributes](#set-arbitrary-attributes) to the generated file.

## Use package properties as assembly attributes

The [`GenerateAssemblyInfo` MSBuild property](../../core/project-sdk/msbuild-props.md#generateassemblyinfo) controls `AssemblyInfo` attribute generation for a project. When the `GenerateAssemblyInfo` value is `true` (which is the default), [package-related project properties](../../core/project-sdk/msbuild-props.md#package-properties) are transformed into assembly attributes. The following table lists the project properties that generate the attributes. It also lists the properties that you can use to disable that generation on a per-attribute basis, for example:

```xml
<PropertyGroup>
  <GenerateNeutralResourcesLanguageAttribute>false</GenerateNeutralResourcesLanguageAttribute>
</PropertyGroup>
```

| MSBuild property       | Assembly attribute                                             | Property to disable attribute generation        |
| ---------------------- | -------------------------------------------------------------- | ----------------------------------------------- |
| `Company`              | <xref:System.Reflection.AssemblyCompanyAttribute>              | `GenerateAssemblyCompanyAttribute`              |
| `Configuration`        | <xref:System.Reflection.AssemblyConfigurationAttribute>        | `GenerateAssemblyConfigurationAttribute`        |
| `Copyright`            | <xref:System.Reflection.AssemblyCopyrightAttribute>            | `GenerateAssemblyCopyrightAttribute`            |
| `Description`          | <xref:System.Reflection.AssemblyDescriptionAttribute>          | `GenerateAssemblyDescriptionAttribute`          |
| `FileVersion`          | <xref:System.Reflection.AssemblyFileVersionAttribute>          | `GenerateAssemblyFileVersionAttribute`          |
| `InformationalVersion` | <xref:System.Reflection.AssemblyInformationalVersionAttribute> | `GenerateAssemblyInformationalVersionAttribute` |
| `Product`              | <xref:System.Reflection.AssemblyProductAttribute>              | `GenerateAssemblyProductAttribute`              |
| `AssemblyTitle`        | <xref:System.Reflection.AssemblyTitleAttribute>                | `GenerateAssemblyTitleAttribute`                |
| `AssemblyVersion`      | <xref:System.Reflection.AssemblyVersionAttribute>              | `GenerateAssemblyVersionAttribute`              |
| `NeutralLanguage`      | <xref:System.Resources.NeutralResourcesLanguageAttribute>      | `GenerateNeutralResourcesLanguageAttribute`     |

Notes about these settings:

- `AssemblyVersion` and `FileVersion` default to the value of `$(Version)` without the suffix. For example, if `$(Version)` is `1.2.3-beta.4`, then the value would be `1.2.3`.
- `InformationalVersion` defaults to the value of `$(Version)`.
- If the `$(SourceRevisionId)` property is present, it's appended to `InformationalVersion`. You can disable this behavior using `IncludeSourceRevisionInInformationalVersion`.
- `Copyright` and `Description` properties are also used for NuGet metadata.
- `Configuration`, which defaults to `Debug`, is shared with all MSBuild targets. You can set it via the `--configuration` option of `dotnet` commands, for example, [dotnet pack](../../core/tools/dotnet-pack.md).
- Some of the properties are used when creating a NuGet package. For more information, see [Package properties](../../core/project-sdk/msbuild-props.md#package-properties).

## Set arbitrary attributes

It's possible to add your own assembly attributes to the generated file as well. To do so, define `<AssemblyAttribute>` MSBuild items that tell the SDK what type of attribute to create. These items should also include any constructor parameters that are required for that attribute. For example, the <xref:System.Reflection.AssemblyMetadataAttribute?displayProperty=fullName> attribute has a constructor that takes two strings:

- A name to describe an arbitrary value.
- The value to store.

If you had a `Date` property in MSBuild that contained the date when an assembly was created, you could use `AssemblyMetadataAttribute` to embed that date into the assembly attributes using the following MSBuild code:

```xml
<ItemGroup>
  <!-- Include must be the fully qualified .NET type name of the Attribute to create. -->
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <!-- _Parameter1, _Parameter2, etc. correspond to the
        matching parameter of a constructor of that .NET attribute type -->
    <_Parameter1>BuildDate</_Parameter1>
    <_Parameter2>$(Date)</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

This item tells the .NET SDK to emit the following C# (or equivalent F# or Visual Basic) as an assembly-level attribute:

```csharp
[assembly: System.Reflection.AssemblyMetadataAttribute("BuildDate", "01/19/2024")]
```

(The actual date string would be whatever you provided at the time of the build.)

If the attribute has parameter types other than `System.String`, you can specify the parameters by using a particular pattern of XML elements supported by the MSBuild `WriteCodeFragment` task. See [WriteCodeFragment task - Generate assembly-level attributes](/visualstudio/msbuild/writecodefragment-task#generate-assembly-level-attributes).

## Migrate from .NET Framework

If you migrate your .NET Framework project to .NET 6 or later, you might encounter an error related to duplicate assembly info files. That's because .NET Framework project templates create a code file with assembly info attributes set. The file is typically located at *.\Properties\AssemblyInfo.cs* or *.\Properties\AssemblyInfo.vb*. However, SDK-style projects also *generate* this file for you based on the project settings.

When porting your code to .NET 6 or later, do one of the following:

- Disable the generation of the temporary code file that contains the assembly info attributes by setting `GenerateAssemblyInfo` to `false` in your project file. This enables you to keep your *AssemblyInfo* file.
- Migrate the settings in the *AssemblyInfo* file to the project file, and then delete the *AssemblyInfo* file.
