---
title: .NET SDK telemetry
description: Discover the .NET SDK telemetry features that collect usage information for analysis, which data is collected, and how to disable it.
author: KathleenDollard
ms.date: 08/27/2019
---
# .NET SDK telemetry

The [.NET SDK](index.md) includes a telemetry feature that collects usage data and exception information when the .NET CLI crashes. The .NET CLI comes with the .NET SDK and is the set of verbs that enable you to build, test, and publish your .NET apps. It's important that the .NET team understands how the tools are used so they can be improved. Information on failures helps the team resolve problems and fix bugs.

The collected data is published in aggregate under the [Creative Commons Attribution License](https://creativecommons.org/licenses/by/4.0/).

## Scope

`dotnet` has two functions: to run apps, and to execute CLI commands. Telemetry *isn't collected* when using `dotnet` to start an application in the following format:

- `dotnet [path-to-app].dll`

Telemetry *is collected* when using any of the [.NET CLI commands](index.md), such as:

- `dotnet build`
- `dotnet pack`
- `dotnet run`

## How to opt out

The .NET SDK telemetry feature is enabled by default. To opt out of the telemetry feature, set the `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

A single telemetry entry is also sent by the .NET SDK installer when a successful installation happens. To opt out, set the `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable before you install the .NET SDK.

> [!IMPORTANT]
> To opt out after you started the installer: close the installer, set the environment variable, and then run the installer again with that value set.

## Disclosure

The .NET SDK displays text similar to the following when you first run one of the [.NET CLI commands](index.md) (for example, `dotnet build`). Text may vary slightly depending on the version of the SDK you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
Telemetry
---------
The .NET tools collect usage data in order to help us improve your experience. The data is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about .NET CLI Tools telemetry: https://aka.ms/dotnet-cli-telemetry
```

To disable this message and the .NET welcome message, set the `DOTNET_NOLOGO` environment variable to `true`. Note that this variable has no effect on telemetry opt out.

## Data points

The telemetry feature doesn't collect personal data, such as usernames or email addresses. It doesn't scan your code and doesn't extract project-level data, such as name, repository, or author. The data is sent securely to Microsoft servers using [Azure Monitor](https://azure.microsoft.com/services/monitor/) technology, held under restricted access, and published under strict security controls from secure [Azure Storage](https://azure.microsoft.com/services/storage/) systems.

Protecting your privacy is important to us. If you suspect the telemetry is collecting sensitive data or the data is being insecurely or inappropriately handled, file an issue in the [dotnet/sdk](https://github.com/dotnet/sdk/issues) repository or send an email to [dotnet@microsoft.com](mailto:dotnet@microsoft.com) for investigation.

The telemetry feature collects the following data:

| SDK versions | Data |
|--------------|------|
| All          | Timestamp of invocation. |
| All          | Command invoked (for example, "build"), hashed starting in 2.1. |
| All          | Three octet IP address used to determine the geographical location. |
| All          | Operating system and version. |
| All          | Runtime ID (RID) the SDK is running on. |
| All          | .NET SDK version. |
| All          | Telemetry profile: an optional value only used with explicit user opt-in and used internally at Microsoft. |
| >=2.0        | Command arguments and options: several arguments and options are collected (not arbitrary strings). See [collected options](#collected-options). Hashed after 2.1.300. |
| >=2.0         | Whether the SDK is running in a container. |
| >=2.0         | Target frameworks (from the `TargetFramework` event), hashed starting in 2.1. |
| >=2.0         | Hashed Media Access Control (MAC) address (SHA256). |
| >=2.0         | Hashed current working directory. |
| >=2.0         | Install success report, with hashed installer exe filename. |
| >=2.1.300     | Kernel version. |
| >=2.1.300     | Libc release/version. |
| >=3.0.100     | Whether the output was redirected (true or false). |
| >=3.0.100     | On a CLI/SDK crash, the exception type and its stack trace (only CLI/SDK code is included in the stack trace sent). For more information, see [.NET CLI/SDK crash exception telemetry collected](#net-clisdk-crash-exception-telemetry-collected). |
| >=5.0.100     | Hashed TargetFrameworkVersion used for build (MSBuild property) |
| >=5.0.100     | Hashed RuntimeIdentifier used for build (MSBuild property) |
| >=5.0.100     | Hashed SelfContained used for build  (MSBuild property) |
| >=5.0.100     | Hashed UseApphost used for build  (MSBuild property) |
| >=5.0.100     | Hashed OutputType used for build (MSBuild property  |
| >=5.0.202     | Elapsed time from process start until entering the CLI program's main method, measuring host and runtime startup. |
| >=5.0.202     | Elapsed time for the step that adds .NET Tools to the path on first run. |
| >=5.0.202     | Elapsed time to display first time use notice on first run. |
| >=5.0.202     | Elapsed time for generating ASP.NET Certificate on first run. |
| >=5.0.202     | Elapsed time to parse the CLI input. |
| >=6.0.100     | OS architecture |

### Collected options

Certain commands send additional data. A subset of commands sends the first argument:

| Command               | First argument data sent                |
|-----------------------|-----------------------------------------|
| `dotnet help <arg>`   | The command help is being queried for.  |
| `dotnet new <arg>`    | The template name (hashed).             |
| `dotnet add <arg>`    | The word `package` or `reference`.      |
| `dotnet remove <arg>` | The word `package` or `reference`.      |
| `dotnet list <arg>`   | The word `package` or `reference`.      |
| `dotnet sln <arg>`    | The word `add`, `list`, or `remove`.    |
| `dotnet nuget <arg>`  | The word `delete`, `locals`, or `push`. |
| `dotnet workload <subcommand> <arg>`  | The word `install`, `update`, `list`, `search`, `uninstall`, `repair`, `restore` and the workload name (hashed). |
| `dotnet tool <subcommand> <arg>`  | The word `install`, `update`, `list`, `search`, `uninstall`, `run` and the dotnet tool name (hashed). |

A subset of commands sends selected options if they're used, along with their values:

| Option                  | Commands                                                                                       |
|-------------------------|------------------------------------------------------------------------------------------------|
| `--verbosity`           | All commands                                                                                   |
| `--language`            | `dotnet new`                                                                                   |
| `--configuration`       | `dotnet build`, `dotnet clean`, `dotnet publish`, `dotnet run`, `dotnet test`                  |
| `--framework`           | `dotnet build`, `dotnet clean`, `dotnet publish`, `dotnet run`, `dotnet test`, `dotnet vstest` |
| `--runtime`             | `dotnet build`,  `dotnet publish`                                                              |
| `--platform`            | `dotnet vstest`                                                                                |
| `--logger`              | `dotnet vstest`                                                                                |
| `--sdk-package-version` | `dotnet migrate`                                                                               |

Except for `--verbosity` and `--sdk-package-version`, all the other values are hashed starting with .NET Core 2.1.100 SDK.

## .NET CLI/SDK crash exception telemetry collected

If the .NET CLI/SDK crashes, it collects the name of the exception and stack trace of the CLI/SDK code. This information is collected to assess problems and improve the quality of the .NET SDK and CLI. This article provides information about the data we collect. It also provides tips on how users building their own version of the .NET SDK can avoid inadvertent disclosure of personal or sensitive information.

### Types of collected data

.NET CLI collects information for CLI/SDK exceptions only, not exceptions in your application. The collected data contains the name of the exception and the stack trace. This stack trace is of CLI/SDK code.

The following example shows the kind of data that is collected:

```console
System.IO.IOException
at System.ConsolePal.WindowsConsoleStream.Write(Byte[] buffer, Int32 offset, Int32 count)
at System.IO.StreamWriter.Flush(Boolean flushStream, Boolean flushEncoder)
at System.IO.StreamWriter.Write(Char[] buffer)
at System.IO.TextWriter.WriteLine()
at System.IO.TextWriter.SyncTextWriter.WriteLine()
at Microsoft.DotNet.Cli.Utils.Reporter.WriteLine()
at Microsoft.DotNet.Tools.Run.RunCommand.EnsureProjectIsBuilt()
at Microsoft.DotNet.Tools.Run.RunCommand.Execute()
at Microsoft.DotNet.Tools.Run.RunCommand.Run(String[] args)
at Microsoft.DotNet.Cli.Program.ProcessArgs(String[] args, ITelemetry telemetryClient)
at Microsoft.DotNet.Cli.Program.Main(String[] args)
```

### Avoid inadvertent disclosure of information

.NET contributors and anyone else running a version of the .NET SDK that they built themselves should consider the path to their SDK source code. If a crash occurs while using a .NET SDK that is a custom debug build or configured with custom build symbol files, the SDK source file path from the build machine is collected as part of the stack trace and isn't hashed.

Because of this, custom builds of the .NET SDK shouldn't be located in directories whose path names expose personal or sensitive information.

## See also

- [.NET CLI Telemetry Data](https://dotnet.microsoft.com/platform/telemetry)
- [Telemetry reference source (dotnet/sdk repository)](https://github.com/dotnet/sdk/tree/main/src/Cli/dotnet/Telemetry)
