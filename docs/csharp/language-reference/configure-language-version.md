---
title: Configure language version
description: Learn how to override the default C# language version manually. The C# compiler can support any language version up to the version in the installed SDK.
ms.custom: "updateeachrelease"
ms.date: 01/31/2025
---

# Configure C# language version

The information in this article applies to .NET 5 and above. For UWP projects, see this information in the article on [Choosing a UWP version](/windows/uwp/updates-and-versions/choose-a-uwp-version).

In Visual Studio, the option to change the language version through the UI is disabled because the default version is aligned with the project's target framework (`TFM`). This default configuration ensures compatibility between language features and runtime support. To change the language version in Visual Studio, change the project's target framework.

For example, changing the target `TFM` (for example, from [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)) updates the language version accordingly, from C# 10 to C# 13. This approach prevents issues with runtime compatibility and minimizes unexpected build errors due to unsupported language features.

If you need a specific language version that differs from the one automatically selected, refer to the methods in this article to override the default settings directly in the project file.

> [!WARNING]
>
> Setting the `LangVersion` element to `latest` is discouraged. The `latest` setting means the installed compiler uses its latest version. The value of `latest` can change from machine to machine, making builds unreliable. In addition, it enables language features that might require runtime or library features not included in the current SDK.

If you must specify your C# version explicitly, you can do so in several ways:

- Manually edit the [project file](#edit-the-project-file).
- Set the language version [for multiple projects in a subdirectory](#configure-multiple-projects).
- Configure the [LangVersion compiler option](compiler-options/language.md#langversion).

> [!TIP]
> You can see the language version in Visual Studio in the project properties page. Under the *Build* tab, the *Advanced* pane displays the version selected.
>
> To know what language version you're currently using, put `#error version` (case sensitive) in your code. This pragma makes the compiler report a compiler error, CS8304, with a message containing the compiler version and the current selected language version. For more information about this pragma, see [#error (C# Reference)](preprocessor-directives.md#error-and-warning-information).

## Edit the project file

You can set the language version in your project file. For example, if you explicitly want access to preview features, add an element like the following example:

```xml
<PropertyGroup>
   <LangVersion>preview</LangVersion>
</PropertyGroup>
```

The value `preview` uses the latest available preview C# language version your compiler supports.

## Configure multiple projects

To configure multiple C# projects, you can create a *Directory.Build.props* file, typically in your solution directory, that contains the `<LangVersion>` element. Add the following setting to the *Directory.Build.props* file:

```xml
<Project>
 <PropertyGroup>
   <LangVersion>preview</LangVersion>
 </PropertyGroup>
</Project>
```

Builds in all subdirectories of the directory containing that file now use the preview C# version. For more information, see [Customize your build](/visualstudio/msbuild/customize-your-build).

> [!NOTE]
>
> The versions for C# and VB are different. Don't use the *Directory.Build.Props* file for a folder where subdirectories contain projects for both languages. The versions don't match.

## C# language version reference

> [!IMPORTANT]
>
> Using a C# language version newer than the version associated with your target TFM is unsupported.

The following table shows all current C# language versions. Older compilers might not understand every value. If you install the latest .NET SDK, you have access to everything listed.

[!INCLUDE [langversion-table](includes/langversion-table.md)]
