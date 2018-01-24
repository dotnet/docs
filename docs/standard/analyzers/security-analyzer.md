---
title: The .NET Security Analyzers - .NET
description: Learn how to use the .NET Security Analyzers in the .NET Desktop Analyzers package to find and address security risks
keywords: .NET, .NET Core
author: billwagner
ms.author: billwagner
ms.date: 01/10/2018
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
---

# The .NET Security Analyzers

You can use the .NET Security Analyzers to find potential security risks
in your code. These analyzers will find potential issues and suggest
fixes to those issues.

The analyzers run interactively in Visual Studio as you write your code
or as part of a CI build. You'll want to add the analyzer to your project as
early as possible in your development. The sooner you find any potential issues
in your code, the easier it will be to fix. However, you can add it at any time
in the development cycle. It will find any issues with the existing code and
will start warning about new issues as you keep developing.

## Installing and configuring the .NET Security Analyzers

The .NET Security Analyzers must be installed as a NuGet package on every
project where you want them to run. Only one developer needs to add them
to the project. The analyzer package is a project dependency and will run
on every developer's machine once they have the updated solution.

The .NET Security Analyzers are delivered in the [Microsoft.NetFramework.Analyzers](https://www.nuget.org/packages/Microsoft.NetFramework.Analyzers/)
NuGet package. This package provides only the analyzers specific to the .NET Framework, which
includes the security analyzers. In most cases, you'll want
the [Microsoft.CodeAnalysis.FxCopAnalyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers) NuGet package. 
The FxCopAnalyzers aggregate package contains all the security analyzers included in the
Desktop.Analyzers package as well as other analyzers that
help your team enforce the rules recommended by FxCop.

To install it, right-click on the project, and select "Manage Dependencies".
From the NuGet explorer, search for "NetFramework Analyzers", or if you prefer,
"Fx Cop Analyzers". Install the latest stable version in all projects in your
solution.

Once the NuGet package is installed, build your solution. The analyzers examine
the code in your solution and provide you with a list of
warnings for the three security related issues:

- [CA2153](/visualstudio/code-quality/ca2153-avoid-handling-corrupted-state-exceptions): Avoid handling corrupted state exceptions
- [CA5350](/visualstudio/code-quality/ca5350-do-not-use-weak-cryptographic-algorithms): Do not use weak cryptographic algorithms
- [CA5351](/visualstudio/code-quality/ca5351-do-not-use-broken-cryptographic-algorithms): Do not use broken cryptographic algorithms

Code that triggers any of these analyzers generates a warning by default.

## Roslyn-based analyzers vs. Code Analysis libraries

The user experience for Roslyn-based analyzers is different than that of the
Code Analysis libraries like the older versions of FxCop and the Security analysis
tools.  You don't need to explicitly run the Roslyn-based analyzers. There's no need to use the "Run Code Analysis"
menu items on the "Analyze" menu in Visual Studio. Roslyn-based analyzers run asychronously as you work.

