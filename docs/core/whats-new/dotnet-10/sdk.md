---
title: What's new in the SDK and tooling for .NET 10
description: Learn about the new .NET SDK features introduced in .NET 10.
titleSuffix: ""
ms.date: 02/20/2025
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in the SDK and tooling for .NET 10

This article describes new features and enhancements in the .NET SDK for .NET 10. It has been updated for Preview 1.

## New features and enhancements

- [Pruning of framework-provided package references](#pruning-of-framework-provided-package-references)

## Pruning of framework-provided package references

Starting in .NET 10, the [NuGet Audit](/nuget/concepts/auditing-packages) feature can now [prune framework-provided package references](https://github.com/NuGet/Home/blob/451c27180d14214bca60483caee57f0dc737b8cf/accepted/2024/prune-package-reference.md) that aren't used by the project. This feature is enabled by default for all `net` target frameworks (for example, `net8.0` and `net10.0`) and .NET Standard 2.0 and greater target frameworks. This change helps to reduce the number of packages that are restored and analyzed during the build process, which can lead to faster build times and reduced disk space usage. It also can lead to a reduction in false positives from NuGet Audit and other dependency-scanning mechanisms.

When this feature is enabled, you should see a marked reduction in the contents of your applications' generated *.deps.json* files. Any package references you might have had that are actually supplied by the .NET runtime you use are automatically removed from the generated dependency file.

While this feature is enabled by default for the listed TFMs, you can disable it by setting the `RestoreEnablePackagePruning` property to `false` in your project file or *Directory.Build.props* file.
