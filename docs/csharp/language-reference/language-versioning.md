---
title: C# language versioning - C# Guide
description: Learn about how the C# language version is determined based on your project and the reasons behind that choice.
ms.custom: "updateeachrelease"
ms.date: 10/30/2023
---

# C# language versioning

The latest C# compiler determines a default language version based on your project's target framework or frameworks. Visual Studio doesn't provide a UI to change the value, but you can change it by editing the *csproj* file. The choice of default ensures that you use the latest language version compatible with your target framework. You benefit from access to the latest language features compatible with your project's target. This default choice also ensures you don't use a language that requires types or runtime behavior not available in your target framework. Choosing a language version newer than the default can cause hard to diagnose compile-time and runtime errors.

[C# 12](../whats-new/csharp-12.md) is supported only on .NET 8 and newer versions. [C# 11](../whats-new/csharp-11.md) is supported only on .NET 7 and newer versions. [C# 10](../whats-new/csharp-10.md) is supported only on .NET 6 and newer versions.

Check the [Visual Studio platform compatibility](/visualstudio/releases/2022/compatibility#-visual-studio-2022-support-for-net-development) page for details on which .NET versions are supported by versions of Visual Studio. Check the [Visual Studio for Mac platform compatibility](/visualstudio/mac/supported-versions-net) page for details on which .NET versions are supported by versions of Visual Studio for Mac. Check the [Mono page for C#](https://www.mono-project.com/docs/about-mono/languages/csharp/) for Mono compatibility with C# versions.

## Defaults

The compiler determines a default based on these rules:

[!INCLUDE [langversion-table](includes/default-langversion-table.md)]

If your project targets a `preview` framework that has a corresponding preview language version, the language version used is the preview language version. You use the latest features with that preview in any environment, without affecting projects that target a released .NET Core version.

> [!IMPORTANT]
> The new project template for Visual Studio 2017 added a `<LangVersion>latest</LangVersion>` entry to new project files. If you upgrade the target framework for these projects, the `<LangVersion>` setting can [override the default](configure-language-version.md) for the new target framework. Be sure to remove the `<LangVersion>latest</LangVersion>` from your project file to ensure your project uses the recommended compiler version for your target framework. You can update the target framework to access newer language features.

## C# language version reference

The following table shows all current C# language versions. Older compilers might not understand every value. If you install the latest .NET SDK, you have access to everything listed.

[!INCLUDE [langversion-table](includes/langversion-table.md)]

>[!NOTE]
>Specifying **LangVersion** with the `default` value is different from omitting the **LangVersion** option. Specifying `default` uses the latest version of the language that the compiler supports, without taking into account the target framework. For example, building a project that targets .NET 6 from the current version of Visual Studio 2022 uses C# 10 if **LangVersion** isn't specified, but uses C# 12 if **LangVersion** is set to `default`.
