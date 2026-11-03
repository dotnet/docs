---
title: "Breaking change: Environment variables take precedence in app runtime configuration settings"
description: "Learn about the breaking change in .NET 9 where environment variables take precedence over runtimeconfig.json settings for configuring the runtime."
ms.date: 01/09/2026
ai-usage: ai-assisted
---
# Environment variables take precedence in app runtime configuration settings

Starting in .NET 9, the priority of how app runtime configuration is resolved has changed. If both an environment variable and a corresponding setting in the application's `runtimeconfig.json` (or project file) are provided, the environment variable takes precedence over the configuration file.

## Version introduced

.NET 9

## Previous behavior

Previously, when both an environment variable and the corresponding setting in the application's `runtimeconfig.json` were set, the `runtimeconfig.json` took precedence.

For example, consider an application with the following `runtimeconfig.json` file:

```json
{
  "runtimeOptions": {
    "configProperties": {
      "System.GC.Server": true
    }
  }
}
```

If the environment variable `DOTNET_gcServer` was set to `0` (false), the application would still use server garbage collection because the `runtimeconfig.json` setting took precedence. The environment variable was effectively ignored.

## New behavior

Starting in .NET 9, when both an environment variable and the corresponding setting in the application's `runtimeconfig.json` are set, the environment variable takes precedence.

Using the same example as in the [Previous behavior](#previous-behavior) section, if the environment variable `DOTNET_gcServer` is set to `0` (false), the application now uses workstation garbage collection instead of server garbage collection, even though `runtimeconfig.json` specifies `System.GC.Server` as `true`. The environment variable overrides the configuration file setting.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The new behavior is more consistent with how configuration tends to work in .NET and elsewhere, with environment variables taking precedence.

## Recommended action

If your app runs in an environment with runtime configuration environment variables set to values different than what's desired, either unset the environment variable or set it to the desired configuration value.

## Affected APIs

None.

## See also

- [.NET runtime configuration settings](../../../runtime-config/index.md)
