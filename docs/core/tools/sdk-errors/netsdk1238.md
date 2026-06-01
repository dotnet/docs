---
title: "NETSDK1238: The current .NET SDK has known vulnerabilities"
description: Learn how to resolve build warning NETSDK1238, which reports known CVEs against the .NET SDK that built your project.
ms.topic: error-reference
ms.date: 05/15/2026
ai-usage: ai-assisted
f1_keywords:
- NETSDK1238
---
# NETSDK1238: The current .NET SDK has known vulnerabilities

This warning indicates that the .NET SDK used to build your project has one or more known Common Vulnerabilities and Exposures (CVEs). The full warning message is similar to the following example:

> NETSDK1238: The current .NET SDK (\<version>) has known vulnerabilities (\<CVE list>). Update to version \<version>. See <https://dotnet.microsoft.com/download>

To resolve the warning, install a patched .NET SDK from <https://dotnet.microsoft.com/download> and update your `global.json` (if present) to select the new version.

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

By default, the .NET CLI refreshes a local cache of SDK release metadata in the background at most once every 24 hours under `~/.dotnet/sdk-vulnerability-cache/`. To change that interval, set [`DOTNET_SDK_VULNERABILITY_CHECK_INTERVAL_HOURS`](../dotnet-environment-variables.md#dotnet_sdk_vulnerability_check_interval_hours). The MSBuild check reads only that cache; it does not make network calls during the build. On machines that have never had network access, no warning is emitted.

## Suppress the warning

To suppress the warning without updating the SDK:

- Add `NETSDK1238` to `NoWarn`:

  ```xml
  <NoWarn>$(NoWarn);NETSDK1238</NoWarn>
  ```

- Set `CheckSdkVulnerabilities` to `false` (the default) to turn off NETSDK1238, NETSDK1239, and NETSDK1240.
- Set the [`DOTNET_SDK_VULNERABILITY_CHECK_DISABLE`](../dotnet-environment-variables.md#dotnet_sdk_vulnerability_check_disable) environment variable to `true` to disable both the cache refresh and the build-time check.

## See also

- [NETSDK1239: The current .NET SDK is end of life](netsdk1239.md)
- [NETSDK1240: The current .NET SDK feature band is discontinued](netsdk1240.md)
- [.NET releases and support](../../releases-and-support.md)
