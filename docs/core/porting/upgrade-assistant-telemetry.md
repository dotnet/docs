---
title: Upgrade Assistant Telemetry
description: Learn about telemetry collected by the Upgrade Assistant.
author: tasou
ms.date: 06/03/2021
---
# Upgrade Assistant telemetry

The [Upgrade Assistant](./upgrade-assistant-overview.md) includes a telemetry feature that collects usage data. It's important that the Upgrade Assistant team understands how the tool is used so it can be improved.

## How to opt out

The Upgrade Assistant telemetry feature is enabled by default. To opt out of the telemetry feature, set the `DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

## Disclosure

The Upgrade Assistant displays text similar to the following when you first run the tool. Text may vary slightly depending on the version of the tool you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
Telemetry
---------
The .NET tools collect usage data in order to help us improve your experience. It is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.
```

To suppress the "first run" experience text, set the `DOTNET_UPGRADEASSISTANT_SKIP_FIRST_TIME_EXPERIENCE` environment variable to `1` or `true`.

## Data points

The telemetry feature doesn't:

* Collect samples of code

The data is sent securely to Microsoft servers and held under restricted access.

Protecting your privacy is important to us. If you suspect the telemetry feature is collecting sensitive data or the data is being insecurely or inappropriately handled, take one of the following actions:

* File an issue in the [dotnet/upgrade-assistant](https://github.com/dotnet/upgrade-assistant/issues) repository.
* Send an email to [dotnet@microsoft.com](mailto:dotnet@microsoft.com) for investigation.

The telemetry feature collects the following data.

| Upgrade Assistant versions | Data                                                                                                        |
| -------------------------- | ----------------------------------------------------------------------------------------------------------- |
| >=0.2.231802               | Timestamp of invocation.                                                                                    |
| >=0.2.231802               | Three-octet IP address used to determine the geographical location.                                         |
| >=0.2.231802               | Operating system and version.                                                                               |
| >=0.2.231802               | Runtime ID (RID) the tool is running on.                                                                    |
| >=0.2.231802               | Whether the tool is running in a container.                                                                 |
| >=0.2.231802               | Hashed Media Access Control (MAC) address: a cryptographically (SHA256) hashed and unique ID for a machine. |
| >=0.2.231802               | Kernel version.                                                                                             |
| >=0.2.231802               | Upgrade Assistant version.                                                                                  |
| >=0.2.231802               | The command and argument names invoked. Actual argument values aren't collected.                            |
| >=0.2.231802               | MSBuild version used.                                                                                       |
| >=0.2.231802               | Hashed solution id (or hashed path if no id is available).                                                  |
| >=0.2.231802               | Hashed project id (or hashed path if no id is available) for each project.                                  |
| >=0.2.231802               | Hashed project id (or hashed path if no id is available) for each entrypoint.                               |
| >=0.2.231802               | For each step, the time to initialize and apply the step.                                                   |
| >=0.2.231802               | For each step, the decision selected (for example, `apply`).                                            |

## Additional resources

* [.NET Core SDK telemetry](/dotnet/core/tools/telemetry)
* [.NET Core CLI telemetry data](https://dotnet.microsoft.com/platform/telemetry)
