---
title: dotnet-scaffold telemetry
description: Learn about the telemetry collected by the dotnet-scaffold CLI tool.
author: tdykstra
ms.author: tdykstra
ms.date: 08/03/2026
ai-usage: ai-assisted
---
# dotnet-scaffold telemetry

The `dotnet-scaffold` tool includes a telemetry feature that collects usage data. This feature helps the `dotnet-scaffold` team understand how the tool is used so they can improve it.

`dotnet-scaffold` is a .NET global tool that generates scaffolding code for common components, such as controllers, views, and pages, so you don't have to write that boilerplate by hand. It isn't included with the .NET SDK. To install it, run the following command:

```dotnetcli
dotnet tool install --global Microsoft.dotnet-scaffold
```

For more information about the tool, see the [dotnet/Scaffolding repository](https://github.com/dotnet/Scaffolding) and the [Getting Started guide](https://github.com/dotnet/Scaffolding/blob/main/docs/Getting-Started.md).

## How to opt out

The `dotnet-scaffold` telemetry feature is enabled by default. To opt out of the telemetry feature, set the `DOTNET_SCAFFOLD_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

## Disclosure

When you run the `dotnet-scaffold` tool for the first time, it displays output similar to the following example. The text might vary slightly depending on the version of the tool you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
dotnet-scaffold collects usage data in order to help us improve your experience. The data is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_SCAFFOLD_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about dotnet-scaffold telemetry:
https://aka.ms/dotnet-scaffold/telemetry
Read more about .NET CLI Tools telemetry:
https://aka.ms/dotnet-cli-telemetry
```

To suppress the "first run" experience text, set the `DOTNET_SCAFFOLD_SKIP_FIRST_TIME_EXPERIENCE` environment variable to `1` or `true`.

## Data points

The telemetry feature collects the following data for .NET SDK version 8.0 and later:

* Timestamp of invocation.
* Three-octet IP address used to determine the geographical location.
* Operating system and version.
* Runtime ID (RID) the tool is running on.
* Whether the tool is running in a container.
* Hashed Media Access Control (MAC) address: a cryptographically (SHA256) hashed and unique ID for a machine.
* Kernel version.
* dotnet-scaffold version.
* Hashed tool information (tool name, tool version, tool package name, tool package version, chosen scaffolder category, related scaffolding categories).
* Tool level (global or local tool).
* Hashed command invoked (for example, `mvccontroller`) and whether it succeeded.
* dotnet-scaffold-aspnet scaffolder name, step names, and whether they succeeded.
* dotnet-scaffold-aspire scaffolder name and whether it succeeded.
* dotnet-scaffold-aspnet scaffolder validation method name and whether it succeeded.
* dotnet-scaffold-aspire scaffolder validation method name and whether it succeeded.

The telemetry feature **does not** collect:

* Personal data, such as usernames, email addresses, or URLs.
* Any project data.

The data is sent securely to Microsoft servers and held under restricted access.

Protecting your privacy is important to us. If you suspect the telemetry feature is collecting sensitive data or the data is being insecurely or inappropriately handled, take one of the following actions:

* File an issue in the [dotnet/scaffolding](https://github.com/dotnet/scaffolding/issues) repository.
* Send an email to [dotnet@microsoft.com](mailto:dotnet@microsoft.com) for investigation.

## Additional resources

* [.NET SDK telemetry](telemetry.md)
* [.NET CLI telemetry data](https://dotnet.microsoft.com/platform/telemetry)
* [dotnet/Scaffolding repository](https://github.com/dotnet/Scaffolding)
* [Get started with dotnet-scaffold](https://github.com/dotnet/Scaffolding/blob/main/docs/Getting-Started.md)
* [Microsoft.dotnet-scaffold NuGet package](https://www.nuget.org/packages/Microsoft.dotnet-scaffold/)
