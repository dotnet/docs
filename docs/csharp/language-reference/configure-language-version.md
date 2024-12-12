---
title: Configure language version
description: Learn how to override the default C# language version manually. The C# compiler can support any language version up to the version in the installed SDK.
ms.custom: "updateeachrelease"
ms.date: 09/17/2024
---

# Configure C# language version

> [!WARNING]
>
> Setting the `LangVersion` element to `latest` is discouraged. The `latest` setting means the installed compiler uses its latest version. That can change from machine to machine, making builds unreliable. In addition, it enables language features that may require runtime or library features not included in the current SDK.

If you must specify your C# version explicitly, you can do so in several ways:

- Manually edit the [project file](#edit-the-project-file).
- Set the language version [for multiple projects in a subdirectory](#configure-multiple-projects).
- Configure the [LangVersion compiler option](compiler-options/language.md#langversion).

> [!TIP]
> You can see the language version in Visual Studio in the project properties page. Under the *Build* tab, the *Advanced* pane displays the version selected.
>
> To know what language version you're currently using, put `#error version` (case sensitive) in your code. This makes the compiler report a compiler error, CS8304, with a message containing the compiler version being used and the current selected language version. See [#error (C# Reference)](preprocessor-directives.md#error-and-warning-information) for more information.

## Why you can't select a different C# version in Visual Studio

In Visual Studio, the option to change the language version through the UI might be disabled because the default version is aligned with the project's target framework (`TFM`). This default configuration ensures compatibility between language features and runtime support.

For example, changing the target `TFM` (for example, from [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)) will update the language version accordingly, from C# 10 to C# 13. This approach prevents issues with runtime compatibility and minimizes unexpected build errors due to unsupported language features.

If you need a specific language version that differs from the one automatically selected, refer to the methods below to override the default settings directly in the project file.

## Edit the project file

You can set the language version in your project file. For example, if you explicitly want access to preview features, add an element like this:

```xml
<PropertyGroup>
   <LangVersion>preview</LangVersion>
</PropertyGroup>
```

The value `preview` uses the latest available preview C# language version that your compiler supports.

## Configure multiple projects

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

> [!IMPORTANT]
>
> Using a C# language version newer than the version associated with your target TFM is unsupported.

The following table shows all current C# language versions. Older compilers might not understand every value. If you install the latest .NET SDK, you have access to everything listed.

[!INCLUDE [langversion-table](includes/langversion-table.md)]
