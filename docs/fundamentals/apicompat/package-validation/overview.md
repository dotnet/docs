---
title: .NET Package Validation
description: Learn how .NET compatibility features can be used to develop consistent and well-formed multi-targeting packages.
ms.date: 11/30/2023
ms.topic: overview
---

# Package validation

Package validation tooling allows you, as a library developer, to validate that your packages are consistent and well formed. It provides the following checks:

- Validates that there are no breaking changes across versions.
- Validates that the package has the same set of public APIs for all the different runtime-specific implementations.
- Catches any applicability holes.

You can run package validation either as an [MSBuild task](#enable-msbuild-task) or using the [Microsoft.DotNet.ApiCompat.Tool global tool](../global-tool.md). If your app isn't packable, use [assembly validation](../assembly-validation.md) instead.

## Enable MSBuild task

You enable package validation in your .NET project by setting the [`EnablePackageValidation` property](../../../core/project-sdk/msbuild-props.md#enablepackagevalidation) to `true`.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net6.0</TargetFrameworks>
    <EnablePackageValidation>true</EnablePackageValidation>
  </PropertyGroup>

</Project>
```

`EnablePackageValidation` runs a series of checks after the `Pack` task. There are some additional checks that can be run by setting other MSBuild properties. For more information, see [Package validation properties](../../../core/project-sdk/msbuild-props.md#package-validation-properties).

## Validator types

There are three different validators that verify your package as part of the `Pack` task:

- The [Baseline version validator](baseline-version-validator.md) validates your library project against a previously released, stable version of your package.
- The [Compatible runtime validator](compatible-framework-validator.md) validates that your runtime-specific implementation assemblies are compatible with each other and with the compile-time assemblies.
- The [Compatible framework validator](compatible-framework-in-package-validator.md) validates that code compiled against one framework can run against all the others in a multi-targeting package.

## Suppress compatibility warnings

For information about suppressing compatibility warnings, see [How to suppress](../diagnostic-ids.md#how-to-suppress).
