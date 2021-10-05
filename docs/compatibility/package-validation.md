---
title: .NET Package Validation
description: Learn how .NET compatibility features can be used to develop consistent and well-formed multi-targeting packages.
ms.date: 09/29/2021
---

## Importance of package validation

With .NET Core & Xamarin we have made cross-platform a mainstream requirement for library authors. However, we lack validation tooling for cross targeting packages, which can result in packages that don't work well, which in turn hurts our ecosystem. This is especially problematic for emerging platforms where adoption isn't high enough to warrant special attention by library authors.

The tooling we provide as part of the SDK has close to zero validation that multi-targeted packages are well-formed. For example, a package that multi-targets for .NET 6.0 and .NET Standard 2.0 needs to ensure that code compiled against the .NET Standard 2.0 binary can run against the .NET 6.0 binary. We have seen this issue in the wild, even with 1st parties, for example, the Azure AD libraries.

It's easy to think that a change is safe and compatible if source consuming that change continues to compile without changes. However, certain changes may work fine in C# but can cause problems at runtime if the consumer wasn't recompiled, for example, adding an optional parameter or changing the value of a constant.

Package Validation tooling will allow library developers to validate that their packages are consistent and well-formed. It involves validating that there are no breaking changes across versions. It will validate that the package have the same set of publics APIs for all the different runtime-specific implementations. It will also help developers to catch any applicability holes.


## Enable package validation

You enable package validation in your .NET project by setting `EnablePackageValidation`. 

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net6.0</TargetFrameworks>
    <EnablePackageValidation>true</EnablePackageValidation>
  </PropertyGroup>

</Project>
```

`EnablePackageValidation` runs a series of checks after the pack task. There are some additional checks that can be run by setting other MSBuild properties.