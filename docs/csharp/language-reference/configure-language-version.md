---
title: C# language versioning - C# Guide
description: Learn about how the C# language version is determined based on your project and the reasons behind that choice. Learn how to override the default manually.
ms.custom: "updateeachrelease"
ms.date: 10/30/2023
---

# C# language versioning

The latest C# compiler determines a default language version based on your project's target framework or frameworks. Visual Studio doesn't provide a UI to change the value, but you can change it by editing the *csproj* file. The choice of default ensures that you use the latest language version compatible with your target framework. You benefit from access to the latest language features compatible with your project's target. This default choice also ensures you don't use a language that requires types or runtime behavior not available in your target framework. Choosing a language version newer than the default can cause hard to diagnose compile-time and runtime errors.

[C# 11](../whats-new/csharp-11.md) is supported only on .NET 7 and newer versions. [C# 10](../whats-new/csharp-10.md) is supported only on .NET 6 and newer versions. [C# 9](../whats-new/csharp-9.md) is supported only on .NET 5 and newer versions.

Check the [Visual Studio platform compatibility](/visualstudio/releases/2022/compatibility#-visual-studio-2022-support-for-net-development) page for details on which .NET versions are supported by versions of Visual Studio. Check the [Visual Studio for Mac platform compatibility](/visualstudio/mac/supported-versions-net) page for details on which .NET versions are supported by versions of Visual Studio for Mac. Check the [Mono page for C#](https://www.mono-project.com/docs/about-mono/languages/csharp/) for Mono compatibility with C# versions.

## Defaults

The compiler determines a default based on these rules:

[!INCLUDE [langversion-table](includes/default-langversion-table.md)]

If your project targets a `preview` framework that has a corresponding preview language version, the language version used is the preview language version. You use the latest features with that preview in any environment, without affecting projects that target a released .NET Core version.

> [!IMPORTANT]
> The new project template for Visual Studio 2017 added a `<LangVersion>latest</LangVersion>` entry to new project files. If you upgrade the target framework for these projects, it can [override the default](#override-the-default). When you update the .NET SDK for these projects, remove the `<LangVersion>latest</LangVersion>` from your project file to ensure your project uses the recommended compiler version for your target framework. You can update the target framework to access newer language features.

## Override the default

If you must specify your C# version explicitly, you can do so in several ways:

- Manually edit your [project file](#edit-the-project-file).
- Set the language version [for multiple projects in a subdirectory](#configure-multiple-projects).
- Configure the [LangVersion compiler option](compiler-options/language.md#langversion).

> [!TIP]
> You can see the language version in Visual Studio in the project properties page. Under the *Build* tab, the *Advanced* pane displays the version selected.
>
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

To configure multiple projects, you can create a *Directory.Build.props* file, typically in your solution directory, that contains the `<LangVersion>` element. Add the following setting to the *Directory.Build.props* file:

```xml
<Project>
 <PropertyGroup>
   <LangVersion>preview</LangVersion>
 </PropertyGroup>
</Project>
```

Builds in all subdirectories of the directory containing that file now use the preview C# version. For more information, see [Customize your build](/visualstudio/msbuild/customize-your-build).

## C# language version reference

The following table shows all current C# language versions. Older compilers might not understand every value. If you install the latest .NET SDK, you have access to everything listed.

[!INCLUDE [langversion-table](includes/langversion-table.md)]
