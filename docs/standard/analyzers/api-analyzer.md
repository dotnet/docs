---
title: .NET API analyzer
description: Learn how the .NET API Analyzer can help detect deprecated APIs and platform compatibility issues.
author: oliag
ms.author: mairaw
ms.date: 01/30/2018
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
---
# .NET API analyzer

The .NET API Analyzer is a Roslyn analyzer that discovers potential compatibility risks for C# APIs on different platforms and detects calls to deprecated APIs. It can be useful for all C# developers at any stage of development.

API Analyzer comes as a NuGet package [Microsoft.DotNet.Analyzers.Compatibility](https://www.nuget.org/packages/Microsoft.DotNet.Analyzers.Compatibility/). After you reference it in a project, it automatically monitors the code and indicates problematic API usage. You can also get suggestions on possible fixes by clicking on the light bulb. The drop-down menu includes an option to suppress the warnings.

> [!NOTE]
> The .NET API analyzer is still a pre-release version.

## Prerequisites

* Visual Studio 2017 or Visual Studio for Mac (all versions).

## Discovering deprecated APIs

### What are deprecated APIs?

The .NET family is a set of large products that are constantly upgraded to better serve customer needs. It's natural to deprecate some APIs and replace them with new ones. An API is considered deprecated when a better alternative exists. One way to inform that an API is deprecated and shouldn't be used is to mark it with the <xref:System.ObsoleteAttribute> attribute. The disadvantage of this approach is that there is only one diagnostic ID for all obsolete APIs (for C#, [CS0612](../../csharp/misc/cs0612.md)). This means that:
- It's impossible to have dedicated documents for each case.
- It's impossible to suppress certain category of warnings. You can suppress either all or none of them.
- To inform users of a new deprecation, a referenced assembly or targeting package has to be updated.

The API Analyzer uses API-specific error codes that begin with DE (which stands for Deprecation Error), which allows control over the display of individual warnings. The deprecated APIs identified by the analyzer are defined in the [dotnet/platform-compat](https://github.com/dotnet/platform-compat) repo.

### Using the API Analyzer

When a deprecated API, such as <xref:System.Net.WebClient>, is used in a code, API Analyzer highlights it with a green squiggly line. When you hover over the API call, a light bulb is displayed with information about the API deprecation, as in the following example:

!["Screenshot of WebClient API with green squiggly line and light bulb on the left"](media/api-analyzer/green-squiggle.jpg)

The **Error List** window contains warnings with a unique ID per deprecated API, as shown in the following example (`DE004`): 

!["Screenshot of the Error List window showing warning's ID and description"](media/api-analyzer/warnings.jpg)

By clicking on the ID, you go to a webpage with detailed information about why the API was deprecated and suggestions regarding alternative APIs that can be used.

Any warnings can be suppressed by right-clicking on the highlighted member and selecting **Suppress \<diagnostic ID>**. There are two ways to suppress warnings: 

* [locally (in source)](#suppressing-warnings-locally)
* [globally (in a suppression file)](#suppressing-warnings-globally) - recommended

### Suppressing warnings locally

To suppress warnings locally, right-click on the member you want to suppress warnings for and then select **Quick Actions and Refactorings** > **Suppress *diagnostic ID*\<diagnostic ID>** > **in Source**. The [#pragma](../../csharp/language-reference/preprocessor-directives/preprocessor-pragma-warning.md) warning preprocessor directive is added to your source code in the scope defined:
!["Screenshot of code framed with #pragma warning disable"](media/api-analyzer/suppress-in-source.jpg)

### Suppressing warnings globally

To suppress warnings globally, right-click on the member you want to suppress warnings for and then select **Quick Actions and Refactorings** > **Suppress *diagnostic ID*\<diagnostic ID>** > **in Suppression File**.

!["Screenshot of WebClient API with green squiggly line and light bulb on the left"](media/api-analyzer/suppress-in-sup-file.jpg)

A *GlobalSuppressions.cs* file is added to your project after the first suppression. New global suppressions are appended to this file.

!["Screenshot of WebClient API with green squiggly line and light bulb on the left"](media/api-analyzer/suppression-file.jpg)

Global suppression is the recommended way to ensure consistency of API usage across projects.

## Discovering cross-platform issues

Similar to deprecated APIs, the analyzer identifies all APIs that are not cross-platform. For example, <xref:System.Console.WindowWidth?displayProperty=nameWithType> works on Windows but not on Linux and macOS. The diagnostic ID is shown in the **Error List** window. You can suppress that warning by right-clicking and selecting **Quick Actions and Refactorings**. Unlike deprecation cases where you have two options (either keep using the deprecated member and suppress warnings or not use it at all), here if you're developing your code only for certain platforms, you can suppress all warnings for all other platforms you don't plan to run your code on. To do so, you just need to edit your project file and add the `PlatformCompatIgnore` property that lists all platforms to be ignored. The accepted values are: `Linux`, `MacOSX`, and `Windows`.

```xml
<PropertyGroup>
    <PlatformCompatIgnore>Linux;MacOS</PlatformCompatIgnore>
</PropertyGroup>
```

If your code targets multiple platforms and you want to take advantage of an API not supported on some of them, you can guard that part of the code with an `if` statement:

```csharp
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
     var w = Console.WindowWidth;
     // More code
}
```

You can also conditionally compile per target framework/operating system, but you currently need to do that [manually](../frameworks.md#how-to-specify-target-frameworks).

## Supported diagnostics

Currently, the analyzer handles the following cases:

* Usage of a .NET Standard API that throws <xref:System.PlatformNotSupportedException> (PC001).
* Usage of a .NET Standard API that isn't available on the .NET Framework 4.6.1 (PC002).
* Usage of a native API that doesn’t exist in UWP (PC003).
* Usage of an API that is marked as deprecated (DEXXXX).

## CI machine

All these diagnostics are available not only in the IDE, but also on the command line as part of building your project, which includes the CI server.

## Configuration

The user decides how the diagnostics should be treated: as warnings, errors, suggestions, or to be turned off. For example, as an architect, you can decide that compatibility issues should be treated as errors, calls to some deprecated APIs generate warnings, while others only generate suggestions. You can configure this separately by diagnostic ID and by project. To do so in **Solution Explorer**, navigate to the **Dependencies** node under your project. Expand the nodes **Dependencies** > **Analyzers** > **Microsoft.DotNet.Analyzers.Compatibility**. Right click on the diagnostic ID, select **Set Rule Set Severity** and pick the desired option.

!["Screenshot of the Solution Explorer showing diagnostics and pop-up dialog with Rule Set Severity"](media/api-analyzer/disable-notifications.jpg)

## See also

* [Introducing API Analyzer](https://blogs.msdn.microsoft.com/dotnet/2017/10/31/introducing-api-analyzer/) blog post.
* [API Analyzer](https://youtu.be/eeBEahYXGd0) demo video on YouTube.
