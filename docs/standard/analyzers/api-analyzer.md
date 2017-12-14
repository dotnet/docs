---
title: .NET API Analyzer
description: Learn how the .NET API Analyzer can help detecting deprecated APIs and platform compatibility issues.
author: oliag
ms.author: mairaw
ms.date: 12/11/2017
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
---

# .NET API Analyzer

The .NET API Analyzer is a Roslyn analyzer that discovers potential compatibility risks for APIs with different platforms and detects calls to deprecated APIs. It can be useful for any developers of the .NET family at any stage of development.

API Analyzer comes as [NuGet package](https://www.nuget.org/packages/Microsoft.DotNet.Analyzers.Compatibility/) and after you reference it in a project, it automatically monitors the code and indicates problematic API usage. You can also get suggestions on possible fixes by clicking on the light bulb.The drop-down menu includes an option to suppress the warnings.

## Discovering deprecated APIs
When a deprecated API (for example `WebClient`)is used in a code, API Analyzer highlights it with a green squiggly line and shows a light bulb on the left

![](media/api-analyzer/green-squiggle.jpg) !

The Error List window contains warnings with a unique ID per deprecated API (in our example `DE004`). By clicking on the ID, you go to a webpage with detailed information about why the API was deprecated and what alternative APIs should be used.

![](media/api-analyzer/warnings.jpg)

Any warnings can be suppressed by right-clicking on the highlighted member and selecting **Quick Actions and Refactorings**. Here you get two suppression options: locally (in source) or globally (in a suppression file). We encourage developers to use global suppression to ensure consistency of API usage across their project.

## Discovering cross-platform issues
Similar to deprecated APIs the analyzer squiggles out all APIs that are not cross-platform supported (For example `Console.WindowWidth` works on Windows but not on Linux and macOS). The diagnostic ID is shown in Error List window. You can suppress warning by right click and choosing "Quick Actions and Refactorings". Unlike deprecation cases where you have two options: either keep using deprecated member and suppress warnings or not use it at all, here if you are developing your code only for certain platform you can suppress all warnings for all other  platforms you don't plan to run your code on. To do so, you just need to edit your project file and add a property `PlatformCompatIgnore` that lists all platforms to be ignored:
```
<PropertyGroup>
    <PlatformCompatIgnore>Linux;MacOSX</PlatformCompatIgnore>
</PropertyGroup>
```
If your code targets multiple platforms and you want to take advantage of an API not supported on some of them, you can guard that part of the code with an `if`-statement:

```CSharp
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
     var w = Console.WindowWidth;
     // More code
}
```
You can also conditionally compile per target framework/operating system, but you currently need to do that manually.

## Supported diagnostics
Right now the analyzer handles the following cases:
* Usage of a .NET Standard API that throws `PlatformNoSupportedException` (PC001).
* Usage of a .NET Standard API that isn't available on the .NET Framework 4.6.1 (PC002).
* Usage of a native API that doesn’t exist in UWP (PC003).
* Usage of an API that is marked as deprecated (DEXXXX).

## CI machine
All these diagnostics are available not only in the IDE, but also on the command line as part of building your project, which includes the CI server.

## Configuration
It is up to a user to decide how the diagnostics should be treated: as warnings, errors, suggestions, or to be turned off. For example, as an architect, you can decide that compatibility issues should be treated as errors, calls to some deprecated APIs generate warnings, while others only generate suggestions. You can configure this separately by diagnostic ID and by project. To do so in your project tree -> Dependencies -> Analyzers -> Microsoft.DotNet.Analyzers.Compatibility, right click on the diagnostic ID and Set Rule Set Severity and pick a desired option. 

## See also:
* [Introducing API Analyzer](https://blogs.msdn.microsoft.com/dotnet/2017/10/31/introducing-api-analyzer/) blog post.
* [API Analyzer](https://youtu.be/eeBEahYXGd0) demo video.