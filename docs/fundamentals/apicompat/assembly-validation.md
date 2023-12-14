---
title: Assembly validation
description: Learn how assembly validation can be used to develop consistent and well-formed multi-targeting assemblies.
ms.date: 12/01/2023
ms.topic: overview
---

# Assembly validation

Similar to [package validation](package-validation/overview.md), assembly validation tooling allows you, as a library developer, to validate that your assemblies are consistent and well formed. Use assembly validation instead of package validation when your app isn't packable.

Assembly validation provides the following checks:

- Validates that there are no breaking changes across versions.
- Validates that the assembly has the same set of public APIs for all the different runtime-specific implementations.
- Catches any applicability holes.

You can run assembly validation either as an [MSBuild task](#enable-msbuild-task) or using the [Microsoft.DotNet.ApiCompat.Tool global tool](global-tool.md).

## Enable MSBuild task

You enable assembly validation in your .NET project by setting the [`ApiCompatValidateAssemblies`](../../core/project-sdk/msbuild-props.md#apicompatvalidateassemblies) property to `true`. You must also add a package reference to [Microsoft.DotNet.ApiCompat.Task](https://www.nuget.org/packages/Microsoft.DotNet.ApiCompat.Task). (The `targets` files in that package aren't part of the .NET SDK.)

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net6.0</TargetFrameworks>
    <ApiCompatValidateAssemblies>true</ApiCompatValidateAssemblies>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup Condition="'$(ApiCompatValidateAssemblies)' == 'true'">
    <PackageReference Include="Microsoft.DotNet.ApiCompat.Task" Version="8.0.100" PrivateAssets="all" IsImplicitlyDefined="true" />
  </ItemGroup>

</Project>
```

Assembly validation runs either in the outer build for multi-targeting projects (after the `DispatchToInnerBuilds` target) or in the inner build for a single-targeting project (as part of the `PrepareForRun` target). It's also fully incremental, meaning the comparison is only triggered if the inputs or outputs have changed.

## Suppress compatibility warnings

For information about suppressing compatibility warnings, see [How to suppress](diagnostic-ids.md#how-to-suppress).
