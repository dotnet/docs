---
title: "NETSDK1239: The current .NET SDK is end of life"
description: Learn how to resolve build warning NETSDK1239, which reports that the .NET SDK that built your project is end of life.
ms.topic: error-reference
ms.date: 05/15/2026
ai-usage: ai-assisted
f1_keywords:
- NETSDK1239
---
# NETSDK1239: The current .NET SDK is end of life

This warning indicates that the .NET SDK used to build your project is end of life (EOL) and no longer receives security updates. The full warning message is similar to the following example:

> NETSDK1239: The current .NET SDK (\<version>) is end of life as of \<date>. It will receive no further security updates: <https://dotnet.microsoft.com/download>

To resolve the warning, install a supported .NET SDK from <https://dotnet.microsoft.com/download> and update your `global.json` (if present) to select the new version. For the current support timeline, see [.NET releases and support](../../releases-and-support.md).

This warning is distinct from [NETSDK1138](netsdk1138.md), which is raised when your project's *target framework* is out of support. NETSDK1239 is raised when the *SDK that runs the build* is out of support, regardless of which framework you target.

## How the check works

The check is opt-in and only runs when the MSBuild property `CheckSdkVulnerabilities` is set to `true`:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <CheckSdkVulnerabilities>true</CheckSdkVulnerabilities>
  </PropertyGroup>
</Project>
```

You can also pass `/p:CheckSdkVulnerabilities=true` to a .NET CLI command, such as `dotnet build`.

By default, the .NET CLI refreshes a local cache of SDK release metadata in the background at most once every 24 hours under `~/.dotnet/sdk-vulnerability-cache/`. Set [`DOTNET_SDK_VULNERABILITY_CHECK_INTERVAL_HOURS`](../dotnet-environment-variables.md#dotnet_sdk_vulnerability_check_interval_hours) to change the refresh interval. The MSBuild check reads only that cache; it doesn't make network calls during the build.

## Suppress the warning

To suppress the warning without updating the SDK:

- Add `NETSDK1239` to `NoWarn`:

  ```xml
  <NoWarn>$(NoWarn);NETSDK1239</NoWarn>
  ```

- Set `CheckSdkVulnerabilities` to `false` (the default) to turn off NETSDK1238, NETSDK1239, and NETSDK1240.
- Set the [`DOTNET_SDK_VULNERABILITY_CHECK_DISABLE`](../dotnet-environment-variables.md#dotnet_sdk_vulnerability_check_disable) environment variable to `true`.

## See also

- [NETSDK1238: The current .NET SDK has known vulnerabilities](netsdk1238.md)
- [NETSDK1240: The current .NET SDK feature band is discontinued](netsdk1240.md)
- [.NET releases and support](../../releases-and-support.md)
