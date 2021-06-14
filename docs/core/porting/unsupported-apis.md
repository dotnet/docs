---
title: Unsupported APIs
description: Learn about unsupported APIs and what to do about them.
author: stebon
ms.date: 06/10/2021
---
# Find unsupported APIs in your code

APIs in your .NET Framework code may not be supported in .NET for a number of reasons that range from the simple to fix, such as a namespace change; to the more challenging to fix such as an entire technology not being supported. The first step is to determine which of your APIs are no longer supported and then identify the proper fix.

## .NET Portability Analyzer

The .NET Portability Analyzer is a tool that analyzes assemblies and provides a detailed report on .NET APIs that are missing for the applications or libraries to be portable on your specified targeted .NET platforms.

To use the .NET Portability Analyzer in Visual Studio, install the [extension from the marketplace](https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer).

For more information, see [The .NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md).
