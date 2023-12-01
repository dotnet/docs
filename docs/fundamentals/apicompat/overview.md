---
title: API compatibility tools
description: Learn how .NET compatibility features, including MSBuild tasks and a command-line tool, can be used to develop consistent and well-formed multi-targeting libraries.
ms.date: 11/30/2023
ms.topic: overview
---

# API compatibility tools

Cross-platform compatibility has become a mainstream requirement for .NET library authors. However, without tooling to validate assemblies and packages, they might contain unintentional breaking changes. As a library author, you need to ensure that multi-targeted assemblies are compatible. For example, for a package that multi-targets for .NET 6 and .NET Standard 2.0, you must ensure that code compiled against the .NET Standard 2.0 binary can run against the .NET 6 binary.

You might think that a change is safe and compatible if source consuming that change continues to compile without changes. However, the changes can still cause problems at run time if the consumer wasn't recompiled. For example, adding an optional parameter to a method or changing the value of a constant can cause these kinds of compatibility issues.

The .NET SDK provides various ways you can compare versions built for different target frameworks. You can also validate a newer version against a baseline version to ensure no breaking changes have been introduced. Enable MSBuild tasks to validate your assemblies at compile time <!--correct?--> or your packages when you [pack](../../core/tools/dotnet-pack.md). Or, use the [Microsoft.DotNet.ApiCompat.Tool global tool](global-tool.md) to validate outside of MSBuild.

For more information about package validation, see [Package validation](package-validation/overview.md). For more information about assembly validation, see [Assembly validation](assembly-validation.md).
