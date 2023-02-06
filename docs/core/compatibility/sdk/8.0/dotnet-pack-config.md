---
title: "Breaking change: 'dotnet pack' uses Release configuration"
description: Learn about a breaking change in the .NET 8 SDK where 'dotnet pack' uses the 'Release' configuration by default.
ms.date: 02/02/2023
---
# 'dotnet pack' uses Release configuration

The [`dotnet pack` command](../../../tools/dotnet-pack.md), which packs code into a NuGet package, now uses the `Release` configuration instead of the `Debug` configuration by default.

## Previous behavior

Previously, `dotnet pack` used the `Debug` configuration unless the configuration was specified explicitly or `PackRelease` was set to `true`.

The [`PackRelease` property](../../../project-sdk/msbuild-props.md#packrelease) was added in .NET 7 as a path forward to this breaking change. Previously, you could set the `DOTNET_CLI_ENABLE_PACK_RELEASE_FOR_SOLUTIONS` environment variable to use `PackRelease` in a project that was part of a Visual Studio solution.

## New behavior

If you're developing with the .NET 8 SDK or a later version, `dotnet pack` uses the `Release` configuration by default for *all* projects. If you have a CI/CD script, tests, or code where you've hardcoded `Debug` into an output path, this change may break your workflow. Also, you won't be able to debug a packed app unless the `Debug` configuration was explicitly specified (for example, using `dotnet pack --configuration Debug`.

`dotnet pack` can pack for multiple target framework monikers (TFM) at the same time. If your project targets multiple versions and you have different `PackRelease` values for different targets, you can have a conflict where some TFMs pack the `Release` configuration and others pack the `Debug` configuration.

For projects in a solution:

- `dotnet pack` can pack all the projects in a Visual Studio solution if given a solution file. For each project in the solution, the value of `PackRelease` is implicitly set to `true` if it's undefined. In order for `dotnet pack` to determine the correct configuration to use, all projects in the solution must agree on their value of `PackRelease`.

- This change might cause the performance of `dotnet pack` to regress, especially for solutions that contain many projects. To address this, a new environment variable `DOTNET_CLI_LAZY_PUBLISH_AND_PACK_RELEASE_FOR_SOLUTIONS` has been introduced.

- The `DOTNET_CLI_ENABLE_PACK_RELEASE_FOR_SOLUTIONS` environment variable is no longer recognized.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and is also a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

In most cases when you create a package, you want your code to be optimized and can keep the package smaller by excluding debugging information.

The `DOTNET_CLI_ENABLE_PACK_RELEASE_FOR_SOLUTIONS` environment variable was removed since the behavior it enabled is now the default behavior and the granular control is no longer necessary.

## Recommended action

- To disable the new behavior entirely, you can set the `DOTNET_CLI_DISABLE_PUBLISH_AND_PACK_RELEASE` environment variable to `true` (or any other value). This variable affects both `dotnet publish` and `dotnet pack`.

- To explicitly specify the `Debug` configuration for packing, use the `-c` or `--configuration` option with `dotnet pack`.

- If your CI/CD pipeline is broken due to hardcoded output paths, update the paths to `Release` instead of `Debug`, disable the new behavior using the `DOTNET_CLI_DISABLE_PUBLISH_AND_PACK_RELEASE` environment variable, or specify that the `Debug` configuration should be used.

- If you're packing a solution and it's broken because one or more projects explicitly sets a value for `PackRelease`, you should explicitly set `PackRelease` to `false` in each project:

  ```xml
  <PropertyGroup>
    <PackRelease>false</PackRelease>
  </PropertyGroup>
  ```

- If you're packing a solution and the performance has regressed, you can set the `DOTNET_CLI_LAZY_PUBLISH_AND_PACK_RELEASE_FOR_SOLUTIONS` environment variable to `true` (or any other value) to remove the regression. If you use this variable and any project defines `PackRelease`, all projects must define it, or you can use a *Directory.Build.Props* file. This variable affects both `dotnet publish` and `dotnet pack`.

## See also

- ['dotnet publish' uses Release configuration](dotnet-publish-config.md)
