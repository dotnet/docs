---
title: Configure language version
description: Learn how to override the default C# language version manually. The C# compiler can support any language version up to the version in the installed SDK.
ms.custom: "updateeachrelease"
ms.date: 01/16/2026
---

# Configure C# language version

The information in this article applies to .NET 5 and later. For UWP projects, see the article on [Choosing a UWP version](/windows/uwp/updates-and-versions/choose-a-uwp-version).

[!INCLUDE[csharp-version-note](./includes/initial-version.md)]

In Visual Studio, the option to change the language version through the UI is disabled because the default version aligns with the project's target framework (`TFM`). This default configuration ensures compatibility between language features and runtime support. To change the language version in Visual Studio, change the project's target framework.

For example, changing the target `TFM` (for example, from [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)) updates the language version accordingly, from C# 10 to C# 13. This approach prevents issues with runtime compatibility and minimizes unexpected build errors due to unsupported language features.

If you need a specific language version that differs from the one automatically selected, use the methods in this article to override the default settings directly in the project file.

> [!WARNING]
>
> Don't set the `LangVersion` element to `latest`. The `latest` setting means the installed compiler uses its latest version. The value of `latest` can change from machine to machine, making builds unreliable. In addition, it enables language features that might require runtime or library features not included in the current SDK.

If you must specify your C# version explicitly, you can do so in several ways:

- Manually edit the [project file](#edit-the-project-file).
- Set the language version [for multiple projects in a subdirectory](#configure-multiple-projects).
- Configure the [LangVersion compiler option](compiler-options/language.md#langversion).

> [!TIP]
> You can see the language version in Visual Studio in the project properties page. Under the *Build* tab, the *Advanced* pane displays the version selected.
>
> To know what language version you're currently using, put `#error version` (case sensitive) in your code. This pragma makes the compiler report a compiler error, CS8304, with a message containing the compiler version and the current selected language version. For more information about this pragma, see [#error (C# Reference)](preprocessor-directives.md#error-and-warning-information).

## Edit the project file

Set the language version in your project file. The project file is the `*.csproj` file in the root folder for your project. For production projects, specify an explicit version number (such as `12.0` or `13.0`) if you need to override the default associated with your target framework:

```xml
<PropertyGroup>
   <LangVersion>13.0</LangVersion>
</PropertyGroup>
```

If you want explicit access to preview language features, set the value to `preview`:

```xml
<PropertyGroup>
   <LangVersion>preview</LangVersion>
</PropertyGroup>
```

The value `preview` instructs the compiler to use the latest available preview C# language version supported by the installed SDK.

> [!NOTE]
> Setting `LangVersion` to `preview` lets you evaluate upcoming language features and provide early feedback. However, preview features are not recommended for production environments because they might change before final release or require preview runtime components.

## Configure multiple projects

To configure multiple C# projects across a repository, create a *Directory.Build.props* file, typically in your solution directory, that contains the `<LangVersion>` element:

```xml
<Project>
 <PropertyGroup>
   <LangVersion>12.0</LangVersion>
 </PropertyGroup>
</Project>
```

Builds in all subdirectories of the directory containing that file now use the specified C# version. For more information, see [Customize your build](/visualstudio/msbuild/customize-your-build).

> [!NOTE]
>
> The versions for C# and Visual Basic are different. Don't use the *Directory.Build.Props* file for a folder where subdirectories contain projects for both languages. The versions don't match.

## C# language version reference

> [!IMPORTANT]
>
> Using a C# language version newer than the version associated with your target TFM isn't supported.

The following table shows all current C# language versions. Older compilers might not understand every value. If you install the latest .NET SDK, you have access to everything listed.

[!INCLUDE [langversion-table](includes/langversion-table.md)]
