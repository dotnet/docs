---
title: C# language versioning - C# Guide
description: Learn about how the C# language version is determined based on your project and the reasons behind that choice. Learn how to override the default manually.
ms.custom: "updateeachrelease"
ms.date: 07/06/2021
---

# C# language versioning

The latest C# compiler determines a default language version based on your project's target framework or frameworks. Visual Studio doesn't provide a UI to change the value, but you can change it by editing the *csproj* file. The choice of default ensures that you use the latest language version compatible with your target framework. You benefit from access to the latest language features compatible with your project's target. This default choice also ensures you don't use a language that requires types or runtime behavior not available in your target framework. Choosing a language version newer than the default can cause hard to diagnose compile-time and runtime errors.

The rules in this article apply to the compiler delivered with Visual Studio 2019 or the .NET SDK. The C# compilers that are part of the Visual Studio 2017 installation or earlier .NET Core SDK versions target C# 7.0 by default.

C# 8.0 is supported only on .NET Core 3.x and newer versions. Many of the newest features require library and runtime features introduced in .NET Core 3.x:

- [Default interface implementation](../whats-new/csharp-8.md#default-interface-methods) requires new features in the .NET Core 3.0 CLR.
- [Async streams](../whats-new/csharp-8.md#asynchronous-streams) require the new types <xref:System.IAsyncDisposable?displayProperty=nameWithType>, <xref:System.Collections.Generic.IAsyncEnumerable%601?displayProperty=nameWithType>, and <xref:System.Collections.Generic.IAsyncEnumerator%601?displayProperty=nameWithType>.
- [Indices and ranges](../whats-new/csharp-8.md#indices-and-ranges) require the new types <xref:System.Index?displayProperty=nameWithType> and <xref:System.Range?displayProperty=nameWithType>.
- [Nullable reference types](../whats-new/csharp-8.md#nullable-reference-types) make use of several [attributes](attributes/nullable-analysis.md) to provide better warnings. Those attributes were added in .NET Core 3.0. Other target frameworks haven't been annotated with any of these attributes. That means nullable warnings may not accurately reflect potential issues.

C# 9 is supported only on .NET 5 and newer versions.

C# 10 is supported only on .NET 6 and newer versions.

## Defaults

The compiler determines a default based on these rules:

| Target framework | version | C# language version default |
|------------------|---------|-----------------------------|
| .NET             | 6.x     | C# 10                     |
| .NET             | 5.x     | C#  9.0                     |
| .NET Core        | 3.x     | C#  8.0                     |
| .NET Core        | 2.x     | C#  7.3                     |
| .NET Standard    | 2.1     | C#  8.0                     |
| .NET Standard    | 2.0     | C#  7.3                     |
| .NET Standard    | 1.x     | C#  7.3                     |
| .NET Framework   | all     | C#  7.3                     |

When your project targets a preview framework that has a corresponding preview language version, the language version used is the preview language version. You use the latest features with that preview in any environment, without affecting projects that target a released .NET Core version.

> [!IMPORTANT]
> Visual Studio 2017 added a `<LangVersion>latest</LangVersion>` entry to any project files it created. That meant *C# 7.0* when it was added. However, once you upgrade to Visual Studio 2019, that means the latest released version, regardless of the target framework. These projects now [override the default behavior](#override-a-default). You should edit the project file and remove that node. Then, your project will use the compiler version recommended for your target framework.

## Override a default

If you must specify your C# version explicitly, you can do so in several ways:

- Manually edit your [project file](#edit-the-project-file).
- Set the language version [for multiple projects in a subdirectory](#configure-multiple-projects).
- Configure the [**LangVersion** compiler option](compiler-options/language.md#langversion).

> [!TIP]
> To know what language version you're currently using, put `#error version` (case sensitive) in your code. This makes the compiler report a compiler error, CS8304, with a message containing the compiler version being used and the current selected language version. See [#error (C# Reference)](preprocessor-directives.md#error-and-warning-information) for more information.

### Edit the project file

You can set the language version in your project file. For example, if you explicitly want access to preview features, add an element like this:

```xml
<PropertyGroup>
   <LangVersion>preview</LangVersion>
</PropertyGroup>
```

The value `preview` uses the latest available preview C# language version that your compiler supports.

### Configure multiple projects

To configure multiple projects, you can create a **Directory.Build.props** file that contains the `<LangVersion>` element. You typically do that in your solution directory. Add the following to a **Directory.Build.props** file in your solution directory:

```xml
<Project>
 <PropertyGroup>
   <LangVersion>preview</LangVersion>
 </PropertyGroup>
</Project>
```

Builds in all subdirectories of the directory containing that file will use the preview C# version. For more information, see [Customize your build](/visualstudio/msbuild/customize-your-build).

## C# language version reference

The following table shows all current C# language versions. Your compiler may not necessarily understand every value if it's older. If you install the latest .NET SDK, then you have access to everything listed.

[!INCLUDE [langversion-table](includes/langversion-table.md)]
