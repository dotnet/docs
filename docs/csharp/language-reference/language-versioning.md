---
title: Language versioning
description: Learn about how the C# language version is determined based on your project and the reasons behind that choice.
ms.custom: "updateeachrelease"
ms.date: 09/17/2024
---

# C# language versioning

The latest C# compiler determines a default language version based on your project's target framework or frameworks. Visual Studio doesn't provide a UI to change the value, but you can change it by editing the *csproj* file. The choice of default ensures that you use the latest language version compatible with your target framework. You benefit from access to the latest language features compatible with your project's target. This default choice also ensures you don't use a language that requires types or runtime behavior not available in your target framework. Choosing a language version newer than the default can cause hard to diagnose compile-time and runtime errors.

[C# 13](../whats-new/csharp-13.md) is supported only on .NET 9 and newer versions. [C# 12](../whats-new/csharp-12.md) is supported only on .NET 8 and newer versions. [C# 11](../whats-new/csharp-11.md) is supported only on .NET 7 and newer versions. Using a C# language version newer than the version associated with your target TFM is unsupported.

Check the [Visual Studio platform compatibility](/visualstudio/releases/2022/compatibility#-visual-studio-2022-support-for-net-development) page for details on which .NET versions are supported by versions of Visual Studio. Check the [Mono page for C#](https://www.mono-project.com/docs/about-mono/languages/csharp/) for Mono compatibility with C# versions.

## Defaults

The compiler determines a default based on these rules:

[!INCLUDE [langversion-table](includes/default-langversion-table.md)]

If your project targets a `preview` framework that has a corresponding preview language version, the language version used is the preview language version. You use the latest features with that preview in any environment, without affecting projects that target a released .NET Core version.

## C# language version reference

The following table shows all current C# language versions. Older compilers might not understand every value. If you install the latest .NET SDK, you have access to everything listed.

[!INCLUDE [langversion-table](includes/langversion-table.md)]

>[!NOTE]
>Specifying **LangVersion** with the `default` value is different from omitting the **LangVersion** option. Specifying `default` uses the latest version of the language that the compiler supports, without taking into account the target framework. For example, building a project that targets .NET 6 from the current version of Visual Studio 2022 uses C# 10 if **LangVersion** isn't specified, but uses C# 12 if **LangVersion** is set to `default`.
