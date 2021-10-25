---
title: .NET Package Validation
description: Learn how .NET compatibility features can be used to develop consistent and well-formed multi-targeting packages.
ms.date: 09/29/2021
---

# Package validation overview

Cross-platform compatibility has become a mainstream requirement for .NET library authors. However, without validation tooling for these packages, they often don't work well. This is especially problematic for emerging platforms where adoption isn't high enough to warrant special attention by library authors.

Until package validation was introduced, the .NET SDK tooling provided almost no validation that multi-targeted packages were well formed. For example, a package that multi-targets for .NET 6.0 and .NET Standard 2.0 needs to ensure that code compiled against the .NET Standard 2.0 binary can run against the .NET 6.0 binary.

You might think that a change is safe and compatible if source consuming that change continues to compile without changes. However, the changes can still cause problems at run time if the consumer wasn't recompiled. For example, adding an optional parameter to a method or changing the value of a constant can cause these kinds of compatibility issues.

Package validation tooling allows library developers to validate that their packages are consistent and well formed. It provides the following checks:

- Validates that there are no breaking changes across versions.
- Validates that the package has the same set of publics APIs for all the different runtime-specific implementations.
- Helps developers catch any applicability holes.

## Enable package validation

You enable package validation in your .NET project by setting the [`EnablePackageValidation` property](../core/project-sdk/msbuild-props.md#enablepackagevalidation) to `true`.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net6.0</TargetFrameworks>
    <EnablePackageValidation>true</EnablePackageValidation>
  </PropertyGroup>

</Project>
```

`EnablePackageValidation` runs a series of checks after the `pack` task. There are some additional checks that can be run by setting other MSBuild properties.
