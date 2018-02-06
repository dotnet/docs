---
title: .NET Core CLI Tools telemetry
description: Discover the .NET Core tools telemetry features that collect usage information for analysis, which data is collected and how to disable it.
keywords: .NET,.NET Core,telemetry
author: richlander
ms.author: mairaw
ms.date: 08/04/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 480df976-7568-4df4-9d26-9911357b5a31
ms.workload: 
  - dotnetcore
---

# .NET Core CLI Tools telemetry

The [.NET Core SDK](index.md) includes a [telemetry feature](https://github.com/dotnet/cli/pull/2145) that collects usage information. It's important that the .NET Team understands how the tools are used so that we can improve them. For more information, see [What we've learned from .NET Core SDK Telemetry](https://blogs.msdn.microsoft.com/dotnet/2017/07/21/what-weve-learned-from-net-core-sdk-telemetry/).

The collected data is anonymous and published in an aggregated form for use by both Microsoft and the community under the [Creative Commons Attribution License](https://creativecommons.org/licenses/by/4.0/). 

## Scope

The `dotnet` command is used to launch both apps and the .NET Core CLI. The `dotnet` command itself doesn't collect telemetry. The .NET Core CLI commands run by the `dotnet` command collect the telemetry.

Telemetry *isn't enabled* when using the `dotnet` command itself, with no command attached:

- `dotnet`
- `dotnet [path-to-app]`

Telemetry *is enabled* when using the [.NET Core CLI commands](index.md), such as:

- `dotnet build`
- `dotnet pack`
- `dotnet restore`
- `dotnet run`


## Behavior

The .NET Core CLI Tools telemetry feature is enabled by default. Opt-out of the telemetry feature by setting the `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

## Data points

The feature collects the following data:

- Timestamp of invocation&#8224;
- Command invoked (for example, "build")&#8224;
- Three octet IP address used to determine geographical location&#8224;
- `ExitCode` of the command
- Test runner (for test projects)
- Operating system and version&#8224;
- Whether runtime IDs are present in the runtimes node
- .NET Core SDK version&#8224;

&#8224;This metric is published.

Starting with .NET Core SDK 2.0, new data points are collected:

- `dotnet` command arguments and options: only known arguments and options are collected (not arbitrary strings).
- Whether the SDK is running in a container.
- Target frameworks.
- Hashed MAC address: a cryptographically (SHA256) anonymous and unique ID for a machine. This metric is not published.
- Hashed current working directory.

The feature doesn't collect personal data, such as usernames or email addresses. It doesn't scan your code and doesn't extract sensitive project-level data, such as name, repo, or author. The data is sent securely to Microsoft servers using [Microsoft Azure Application Insights](https://azure.microsoft.com/services/application-insights/) technology, held under restricted access, and published under strict security controls from secure [Azure Storage](https://azure.microsoft.com/services/storage/) systems.

We want to know how the tools are used and if they're working well, not what you're building with the tools. If you suspect that the telemetry is collecting sensitive data or that we're insecurely or inappropriately handling data, [file an issue in the dotnet/cli repo issues](https://github.com/dotnet/cli/issues) for investigation.

## Published data

Published data is available quarterly and are listed at [.NET Core SDK Usage Data](https://github.com/dotnet/core/blob/master/release-notes/cli-usage-data.md). The columns of a data file are:
- Timestamp
- Occurrences&#8224;
- Command
- Geography&#8225;
- OSFamily
- RuntimeID
- OSVersion
- SDKVersion

&#8224;The *Occurrences* column displays the aggregate count of that command's use for that row's metrics that day. 

&#8225;Typically, the *Geography* column displays the name of a country. In some cases, the continent of Antarctica appears in this column, either due to researchers using .NET Core in Antarctica or incorrect location data.

### Example

| Timestamp      | Occurrences | Command | Geography | OSFamily | RuntimeID     | OSVersion | SDKVersion |
| -------------- | ----------- | ------- | --------- | -------- | ------------- | --------- | ---------- |
| 4/16/2017 0:00 | 8           | run     | Uganda    | Darwin   | osx.10.12-x64 | 10.12     | 1.0.1      |

### Datasets

[2016 - Q3](https://dotnetcli.blob.core.windows.net/usagedata/dotnet-cli-usage-2016-q3.tsv)  
[2016 - Q4](https://dotnetcli.blob.core.windows.net/usagedata/dotnet-cli-usage-2016-q4.tsv)  
[2017 - Q1](https://dotnetcli.blob.core.windows.net/usagedata/dotnet-cli-usage-2017-q1.tsv)  
[2017 - Q2](https://dotnetcli.blob.core.windows.net/usagedata/dotnet-cli-usage-2017-q2.tsv)

Additional datasets are posted using a standard URL format. Replace `<YEAR>` with the year and replace `<QUARTER>` with the quarter of the year (use `1`, `2`, `3`, or `4`). The files are in tab-separated values (*TSV*) format. 

```
https://dotnetcli.blob.core.windows.net/usagedata/dotnet-cli-usage-<YEAR>-q<QUARTER>.tsv
```

## License

The Microsoft distribution of .NET Core is licensed with the [MICROSOFT .NET LIBRARY EULA](https://aka.ms/dotnet-core-eula). This license includes the "DATA" section to enable telemetry (shown below).

[.NET NuGet packages](https://www.nuget.org/profiles/dotnetframework) use the same license but don't enable telemetry (see [Scope](#scope)).

> 2. DATA. The software may collect information about you and your use of the software, and send that to Microsoft. Microsoft may use this information to improve our products and services. You can learn more about data collection and use in the help documentation and the privacy statement at http://go.microsoft.com/fwlink/?LinkId=528096. Your use of the software operates as your consent to these practices.

## Disclosure

The .NET Core CLI Tools display the following text when you first run one of the commands (for example, `dotnet restore`). Text may vary slightly depending on the version of the SDK you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
Welcome to .NET Core!
---------------------
Learn more about .NET Core @ https://aka.ms/dotnet-docs. Use dotnet --help to see available commands or go to https://aka.ms/dotnet-cli-docs.
 
Telemetry
--------------
The .NET Core tools collect usage data in order to improve your experience. The data is anonymous and does not include command-line arguments. The data is collected by Microsoft and shared with the community.
You can opt out of telemetry by setting a DOTNET_CLI_TELEMETRY_OPTOUT environment variable to 1 using your favorite shell.
You can read more about .NET Core tools telemetry @ https://aka.ms/dotnet-cli-telemetry.
```

## See also

[What we've learned from .NET Core SDK Telemetry](https://blogs.msdn.microsoft.com/dotnet/2017/07/21/what-weve-learned-from-net-core-sdk-telemetry/)  
[Telemetry reference source (dotnet/cli repo; release/2.0.0 branch)](https://github.com/dotnet/cli/tree/release/2.0.0/src/dotnet/Telemetry)   
[.NET Core SDK Usage Data](https://github.com/dotnet/core/blob/master/release-notes/cli-usage-data.md)
