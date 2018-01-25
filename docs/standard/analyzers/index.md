---
title: The Roslyn based Analyzers - .NET
description: Learn about Roslyn based analyzers that find issues and suggest fixes for those issues.
keywords: .NET, .NET Core
author: billwagner
ms.author: billwagner
ms.date: 01/24/2018
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
---

# The Roslyn based Analyzers

Roslyn-based analyzers use the .NET Compiler SDK (Roslyn APIs) to analyze your project's source code to find issues and suggest corrections. Different analyzers look for different classes of issues, ranging from practices that are likely to cause bugs to security concerns to API compatibility.

Roslyn-based analyzers work both interactively and during builds. The analyzer provides different guidance when in Visual Studio or in command line builds.

While you edit code in Visual Studio, the analyzers run as you make changes, catching possible issues as soon as you create code that trigger concerns. Any issues are highlighted with squiggles under any issue. Visual Studio displays a light bulb, and when you click on it the analyzer will suggest possible fixes for that issue. When you build the project, either in Visual Studio or from the command line, all the source code is analyzed and the analyzer provides a full list of potential issues.

Roslyn-based analyzers report potential issues as errors, warnings, or information based on the severity of the issue.

You install Roslyn-based analyzers as NuGet packages in your project. The configured analyzers and any settings for each analyzer will be restored and run on any developer's machine for that project.

## Workflow for Roslyn based analyzers

The basic workflow for any Roslyn-based analyzer is the same:

1. Find the analyzer on [NuGet](https://nuget.org/packages). 
1. Add the analyzer to your solution or project.
1. Run the analyzer on the code you've created already.
1. Correct any issues.
1. Continue coding and watch for any new issues.

## More information on specific analyzers

The following analyzers are covered in this section:

[API Analyzer](api-analyzer.md): This analyzer examines your code for potential compatibility risks or uses of deprecated APIs.    
[Security Analyzer](security-analyzer.md): This analyzer examines your code for potential security risks. It is part of the larger [FxCopAnalyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers) NuGet package.  
