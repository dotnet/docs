---
title: "Breaking change: 'dotnet publish' uses Release configuration"
description: Learn about a breaking change in the .NET 8 SDK where 'dotnet publish' uses the 'Release' configuration by default.
ms.date: 02/02/2023
---
# 'dotnet publish' uses Release configuration

The [`dotnet publish` command](../../../tools/dotnet-publish.md) now uses the `Release` configuration instead of the `Debug` configuration by default if the target framework moniker is .NET 8 or a later version.

## Previous behavior

Previously, `dotnet publish` used the `Debug` configuration unless the configuration was specified explicitly or `PublishRelease` was set to `true`.

The [`PublishRelease` property](../../../project-sdk/msbuild-props.md#publishrelease) was added in .NET 7 as a path forward to this breaking change. Previously, you could set the `DOTNET_CLI_ENABLE_PUBLISH_RELEASE_FOR_SOLUTIONS` environment variable to use `PublishRelease` in a project that was part of a Visual Studio solution.

## New behavior

If you're developing with the .NET 8 SDK or later, `dotnet publish` uses the `Release` configuration by default for projects that target .NET 8 or later. If you have a CI/CD script where you've hardcoded `Debug` into an output path, this change may break your workflow.

If your project targets multiple versions, the new behavior only applies if you specify a target framework of .NET 8 or later when you publish (for example, using `dotnet publish -f net8.0`).

For projects in a Visual Studio solution that target .NET 8 or later, the value of `PublishRelease` is implicitly set to `true` if it's undefined. However, in order for `dotnet publish` to determine the correct configuration to use, all projects in the solution must agree on their value of `PublishRelease`. If an older project in the solution has `PublishRelease` set to `false`, you should explicitly set the property to `false` for any new .NET 8+ projects as well.

The `DOTNET_CLI_ENABLE_PUBLISH_RELEASE_FOR_SOLUTIONS` environment variable is no longer recognized. By default, the executable project's `PublishRelease` value takes precedence and is flowed to other projects in the solution.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and is also a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

In most cases when you publish, you want your code to be optimized and can keep the app smaller by excluding debugging information. Customers have asked for `Release` to be the default configuration for `publish` for a long time. Also, Visual Studio has had this behavior for many years.

The `DOTNET_CLI_ENABLE_PUBLISH_RELEASE_FOR_SOLUTIONS` environment variable was removed since the behavior it enabled is now the default behavior and the granular control is no longer necessary.

## Recommended action

- If you're publishing a solution and it's broken, you can explicitly set `PublishRelease` to `true` (or `false` to revert to the previous behavior).

  ```xml
  <PropertyGroup>
    <PublishRelease>true</PublishRelease>
  </PropertyGroup>
  ```

  Alternatively, you can specify the property in a *Directory.Build.Props* file. However, if you set it `false` in this file, you'll still need to explicitly set the property to `false` in the .NET 8+ projects in the solution. Similarly, if some projects explicitly set a value that's different from the value in the *Directory.Build.Props* file, publish will fail.

- To disable the new behavior entirely, you can set the `DOTNET_CLI_DISABLE_PUBLISH_AND_PACK_RELEASE` environment variable to `true` (or any other value).

- To explicitly specify the `Debug` configuration for publishing, use the `-c` or `--configuration` option. 

- If your CI/CD pipeline is broken due to hardcoded output paths, update the paths to `Release` instead of `Debug`, disable the new behavior using the `DOTNET_CLI_DISABLE_PUBLISH_AND_PACK_RELEASE` environment variable, or specify that the `Debug` configuration should be used.

## See also

- ['dotnet pack' uses Release configuration](dotnet-pack-config.md)
