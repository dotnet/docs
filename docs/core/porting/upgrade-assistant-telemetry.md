---
title: Upgrade Assistant Telemetry
description: Learn about telemetry collected by the Upgrade Assistant.
author: tasou
ms.date: 11/08/2021
---
# Upgrade Assistant telemetry

The [Upgrade Assistant](./upgrade-assistant-overview.md) includes a telemetry feature that collects usage data. The telemetry data is used to help understand how to make improvements to the tool.

## How to opt out

The Upgrade Assistant telemetry feature is enabled by default. To opt out of the telemetry feature, set the `DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

### [Console](#tab/console)

Create and assign persisted environment variable, given the value.

```console
:: Assigns the env var to the value
setx DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT="1"
```

In a new instance of the **Command Prompt**, read the environment variable.

```console
:: Prints the env var value
echo %DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT%
```

### [PowerShell](#tab/powershell)

Create and assign persisted environment variable, given the value.

```powershell
# Assigns the env var to the value
[System.Environment]::SetEnvironmentVariable('DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT', '1', 'User')
```

In a new instance of the **Windows PowerShell**, read the environment variable.

```powershell
# Prints the env var value
[System.Environment]::GetEnvironmentVariable('DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT')
```

### [Bash](#tab/bash)

Create and assign persisted environment variable, given the value.

```Bash
# Assigns the env var to the value
echo export DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT="1" >> /etc/environment && source /etc/environment
```

In a new instance of the **Bash**, read the environment variable.

```Bash
# Prints the env var value
echo "${DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT}"

# Or use printenv:
# printenv DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT
```

---

## Disclosure

The Upgrade Assistant displays text similar to the following when you first run the tool. Text may vary slightly depending on the version of the tool you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
Telemetry
---------
The .NET tools collect usage data in order to help us improve your experience.
It is collected by Microsoft and shared with the community. You can opt-out of
telemetry by setting the DOTNET_UPGRADEASSISTANT_TELEMETRY_OPTOUT environment
variable to '1' or 'true' using your favorite shell.
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

* [.NET SDK telemetry](../tools/telemetry.md)
* [.NET CLI telemetry data](https://dotnet.microsoft.com/platform/telemetry)
