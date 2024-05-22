---
title: Configure language version
description: Learn how to override the default C# language version manually.
ms.custom: "updateeachrelease"
ms.date: 10/30/2023
---

# Configure C# language version

If you must specify your C# version explicitly, you can do so in several ways:

- Manually edit the [project file](#edit-the-project-file).
- Set the language version [for multiple projects in a subdirectory](#configure-multiple-projects).
- Configure the [LangVersion compiler option](compiler-options/language.md#langversion).

> [!TIP]
> You can see the language version in Visual Studio in the project properties page. Under the *Build* tab, the *Advanced* pane displays the version selected.
>
> To know what language version you're currently using, put `#error version` (case sensitive) in your code. This makes the compiler report a compiler error, CS8304, with a message containing the compiler version being used and the current selected language version. See [#error (C# Reference)](preprocessor-directives.md#error-and-warning-information) for more information.

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
