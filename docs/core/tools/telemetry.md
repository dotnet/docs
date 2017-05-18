---
title: .NET Core Tools Telemetry | Microsoft Docs
description: .NET Core
keywords: .NET, .NET Core
author: richlander
ms.author: mairaw
ms.date: 11/16/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 480df976-7568-4df4-9d26-9911357b5a31
---

# .NET Core Tools Telemetry

The .NET Core Tools include a [telemetry feature](https://github.com/dotnet/cli/pull/2145) that collects usage information. It’s important that the .NET Team understands how the tools are being used so that we can improve them.

The data collected is anonymous and will be published in an aggregated form for use by both Microsoft and community engineers under the [Creative Commons Attribution License](https://creativecommons.org/licenses/by/4.0/).

## Scope

The `dotnet` command is used to launch both apps and the .NET Core Tools. The `dotnet` command itself does not collect telemetry. It is the .NET Core Tools that are run via the `dotnet` command that collect telemetry.

.NET Core commands (telemetry is not enabled):

- `dotnet`
- `dotnet [path-to-app]`

.NET Core Tools [commands](index.md) (telemetry is enabled), such as:

- `dotnet build`
- `dotnet pack`
- `dotnet restore`
- `dotnet run`

## Behavior

The .NET Core Tools telemetry feature is enabled by default. You can opt-out of the telemetry feature by setting an environment variable DOTNET_CLI_TELEMETRY_OPTOUT (for example, `export` on macOS/Linux, `set` on Windows) to true (for example, "true", 1).

## Data Points

The feature collects the following pieces of data:

- The command being used (for example, "build", "restore")
- The ExitCode of the command
- For test projects, the test runner being used
- The timestamp of invocation
- The framework used
- Whether runtime IDs are present in the "runtimes" node
- The CLI version being used

The feature will not collect any personal data, such as usernames or emails. It will not scan your code and not extract any project-level data that can be considered sensitive, such as name, repo or author (if you set those in your project.json). We want to know how the tools are used, not what you are building with the tools. If you find sensitive data being collected, that’s a bug. Please [file an issue](https://github.com/dotnet/cli/issues) and it will be fixed.

## License

The Microsoft distribution of .NET Core is licensed with the [MICROSOFT .NET LIBRARY EULA](https://aka.ms/dotnet-core-eula). This includes the "DATA" section re-printed below, to enable telemetry.

[.NET NuGet packages](https://www.nuget.org/profiles/dotnetframework) use this same license but do not enable telemetry (see [Scope](#scope) above).

```text
2.      DATA.  The software may collect information about you and your use of
the software, and send that to Microsoft. Microsoft may use this information
to improve our products and services. You can learn more about data collection
and use in the help documentation and the privacy statement at
http://go.microsoft.com/fwlink/?LinkId=528096 . Your use of the software
operates as your consent to these practices.
```

## Disclosure

The .NET Core Tools display the following text when you first run one of the commands (for example, `dotnet restore`). This "first run" experience is how Microsoft notifies you about data collection. This same experience also initially populates your NuGet cache with the libraries in the .NET Core SDK, avoiding requests to NuGet.org (or other NuGet feed) for these libraries.

```text
Welcome to .NET Core!
---------------------
Learn more about .NET Core @ https://aka.ms/dotnet-docs. Use dotnet --help to 
see available commands or go to https://aka.ms/dotnet-cli-docs.

Telemetry
--------------
The .NET Core tools collect usage data in order to improve your experience. 
The data is anonymous and does not include command-line arguments. The data is 
collected by Microsoft and shared with the community.
You can opt out of telemetry by setting a DOTNET_CLI_TELEMETRY_OPTOUT 
environment variable to 1 using your favorite shell.
You can read more about .NET Core tools telemetry @ https://aka.ms/dotnet-cli-telemetry.

Configuring...
-------------------
A command is running to initially populate your local package cache, to 
improve restore speed and enable offline access. This command will take up to 
a minute to complete and will only happen once. 
```
