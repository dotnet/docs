---
title: "NETSDK1240: The current .NET SDK feature band is discontinued"
description: Learn how to resolve build warning NETSDK1240, which reports that the feature band of the .NET SDK that built your project has no newer release.
ms.topic: error-reference
ms.date: 05/15/2026
ai-usage: ai-assisted
f1_keywords:
- NETSDK1240
---
# NETSDK1240: The current .NET SDK feature band is discontinued

This warning indicates that the feature band of the .NET SDK used to build your project has no newer release, even though a newer SDK exists in a different feature band on the same major version. The full warning message is similar to the following example:

> NETSDK1240: The current .NET SDK (\<version>) has no newer release in its feature band. Update to version \<version>: <https://dotnet.microsoft.com/download>

A .NET SDK version has the form `<major>.<minor>.<feature-band><patch>` (for example, `8.0.404`, where `4xx` is the feature band). When the recommended servicing path moves to a different feature band, the older band stops receiving updates. To resolve the warning, install the recommended .NET SDK version from <https://dotnet.microsoft.com/download> and update your `global.json` (if present) to select it.

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

The .NET CLI refreshes a local cache of SDK release metadata in the background under `~/.dotnet/sdk-vulnerability-cache/`. By default, it refreshes the cache at most once every 24 hours. To change that interval, set [`DOTNET_SDK_VULNERABILITY_CHECK_INTERVAL_HOURS`](../dotnet-environment-variables.md#dotnet_sdk_vulnerability_check_interval_hours). The MSBuild check reads only that cache; it does not make network calls during the build.

## Suppress the warning

To suppress the warning without updating the SDK:

- Add `NETSDK1240` to `NoWarn`:

  ```xml
  <NoWarn>$(NoWarn);NETSDK1240</NoWarn>
  ```

- Set `CheckSdkVulnerabilities` to `false` (the default) to turn off NETSDK1238, NETSDK1239, and NETSDK1240.
- Set the [`DOTNET_SDK_VULNERABILITY_CHECK_DISABLE`](../dotnet-environment-variables.md#dotnet_sdk_vulnerability_check_disable) environment variable to `true`.

## See also

- [NETSDK1238: The current .NET SDK has known vulnerabilities](netsdk1238.md)
- [NETSDK1239: The current .NET SDK is end of life](netsdk1239.md)
- [.NET SDK versioning](../../versions/index.md)
