---
title: .NET Core Tools Telemetry
description: .NET Core
keywords: .NET, .NET Core
author: richlander
manager: wpickett
ms.date: 06/27/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: f2b312bb-f80b-4b0d-9101-93908f06a6fa
---

.NET Core Tools Telemetry
=========================

The .NET Core tools include a [telemetry feature](https://github.com/dotnet/cli/pull/2145) so that the .NET Team can collect usage information about the .NET Core Tools. It’s important that team understands how the tools are being used so that we can improve them. The telemetry is only in the tools and does not affect your apps.

### Behavior

The telemetry feature is on by default. The data collected is anonymous in nature and will be published in an aggregated form for use by both Microsoft and community engineers under a Creative Commons license.

You can opt-out of the telemetry feature by setting an environment variable DOTNET_CLI_TELEMETRY_OPTOUT (e.g. export on OS X/Linux, set on Windows) to true (e.g. “true”, 1). Doing this will stop the collection process from running.

### Data Points

The feature collects the following pieces of data:

- The command being used (e.g. “build”, “restore”)
- The ExitCode of the command
- For test projects, the test runner being used
- The timestamp of invocation
- The framework used
- Whether runtime IDs are present in the “runtimes” node
- The CLI version being used

The feature will not collect any personal data, such as usernames or emails. It will not scan your code and not extract any project-level data that can be considered sensitive, such as name, repo or author (if you set those in your project.json). We want to know how the tools are used, not what you are using the tools to build. If you find sensitive data being collected, that’s a bug. Please [file an issue](https://github.com/dotnet/cli/issues) and it will be fixed.

We use the [MICROSOFT .NET LIBRARY EULA](http://go.microsoft.com/fwlink/?LinkId=329770) for the .NET Core Tools, which we also use for all .NET NuGet packages. We recently added a “DATA” section re-printed below, to enable telemetry from the tools. We want to stay with one EULA for .NET Core and only intend to collect data from the tools, not the runtime or libraries.