---
title: Discover unsupported APIs in your app
description: Learn about how to find unsupported APIs your app might be using, and what to do about them.
author: StephenBonikowsky
ms.author: stebon
ms.date: 06/10/2021
---
# Find unsupported APIs in your code

APIs in your .NET Framework code may not be supported in .NET for many reasons. These reasons range from the simple to fix, such as a namespace change, to the more challenging to fix, such as an entire technology not being supported. The first step is to determine which of your APIs are no longer supported and then identify the proper fix.

[!INCLUDE [github-copilot-suggestion](includes/github-copilot-suggestion.md)]

## .NET Portability Analyzer

[!INCLUDE [deprecating-api-port](../../../includes/deprecating-api-port.md)]

The .NET Portability Analyzer is a tool that analyzes assemblies and provides a detailed report on .NET APIs that are missing for the applications or libraries to be portable on your specified targeted .NET platforms.

To use the .NET Portability Analyzer in Visual Studio, install the [extension from the marketplace](https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer).

For more information, see [The .NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md).
