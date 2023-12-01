---
title: Assembly validation
description: Learn how assembly validation can be used to develop consistent and well-formed multi-targeting assemblies.
ms.date: 11/30/2023
ms.topic: overview
---

# Assembly validation

Similar to [package validation](../package-validation/overview.md), assembly validation tooling allows you, as a library developer, to validate that your assemblies are consistent and well formed. It provides the following checks:

- Validates that there are no breaking changes across versions.
- Validates that the assembly has the same set of public APIs for all the different runtime-specific implementations.
- Catches any applicability holes.

You can run assembly validation either as an [MSBuild task](#enable-msbuild-task) or using the [Microsoft.DotNet.ApiCompat.Tool global tool](global-tool.md). You can run assembly validation in an inner or outer build for maximum performance. <!--how?--> It's also fully incremental, meaning the comparison is only triggered if the inputs or outputs have changed.

Optionally, you can transform the left and right input assembly paths that are emitted into the suppression file to avoid environment specific paths. To transform the paths, use the [ApiCompatLeftAssembliesTransformationPattern](../../core/project-sdk/msbuild-props.md#apicompatleftassembliestransformationpattern) and [ApiCompatRightAssembliesTransformationPattern](../../core/project-sdk/msbuild-props.md#apicompatrightassembliestransformationpattern) MSBuild properties (or the corresponding options for the command-line tool).

For more information about ways you can configure assembly validation, see [Assembly validation properties](../../core/project-sdk/msbuild-props.md#assembly-validation-properties).

## Enable MSBuild task

You enable assembly validation in your .NET project by setting the [`ApiCompatValidateAssemblies`](../../../core/project-sdk/msbuild-props.md#apicompatvalidateassemblies) property to `true`.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net6.0</TargetFrameworks>
    <ApiCompatValidateAssemblies>true</ApiCompatValidateAssemblies>
  </PropertyGroup>

</Project>
```

## Suppress compatibility warnings

For information about suppressing compatibility warnings, see [How to suppress](diagnostic-ids.md#how-to-suppress).
