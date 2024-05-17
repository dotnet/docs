---
title: .NET SDK and .NET CLI telemetry
description: The .NET SDK and the .NET CLI collect usage information and send it to Microsoft. Learn what data is collected and how to opt out.
author: KathleenDollard
ms.date: 02/24/2022
---
# .NET SDK and .NET CLI telemetry

The [.NET SDK](index.md) includes a telemetry feature that collects usage data and sends it to Microsoft when you use [.NET CLI](index.md) commands. The usage data includes exception information when the .NET CLI crashes. The .NET CLI comes with the .NET SDK and is the set of verbs that enable you to build, test, and publish your .NET apps. Telemetry data helps the .NET team understand how the tools are used so they can be improved. Information on failures helps the team resolve problems and fix bugs.

The collected data is published in aggregate under the [Creative Commons Attribution License](https://creativecommons.org/licenses/by/4.0/). Some of the collected data is published at [.NET CLI Telemetry Data](https://dotnet.microsoft.com/platform/telemetry).

## Scope

`dotnet` has two functions: to run apps and to execute CLI commands. Telemetry *isn't collected* when using `dotnet` to start an application in the following format:

- `dotnet [path-to-app].dll`

Telemetry *is collected* when using any of the [.NET CLI commands](index.md), such as:

- `dotnet build`
- `dotnet pack`
- `dotnet run`

## How to opt out

The .NET SDK telemetry feature is enabled by default for Microsoft distributions of the SDK. To opt out of the telemetry feature, set the `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

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

The telemetry feature doesn't collect personal data, such as usernames or email addresses. It doesn't scan your code and doesn't extract project-level data, such as name, repository, or author. It doesn't extract the contents of any data files accessed or created by your apps, dumps of any memory occupied by your apps' objects, or the contents of the clipboard. The data is sent securely to Microsoft servers using [Azure Monitor](https://azure.microsoft.com/services/monitor/) technology, held under restricted access, and published under strict security controls from secure [Azure Storage](https://azure.microsoft.com/services/storage/) systems.

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
| >=3.0.100     | On a CLI/SDK crash, the exception type and its stack trace (only CLI/SDK code is included in the stack trace sent). For more information, see [Crash exception telemetry](#crash-exception-telemetry). |
| >=5.0.100     | Hashed TargetFrameworkVersion used for build (MSBuild property) |
| >=5.0.100     | Hashed RuntimeIdentifier used for build (MSBuild property) |
| >=5.0.100     | Hashed SelfContained used for build (MSBuild property) |
| >=5.0.100     | Hashed UseApphost used for build (MSBuild property) |
| >=5.0.100     | Hashed OutputType used for build (MSBuild property  |
| >=5.0.201     | Hashed PublishReadyToRun used for build (MSBuild property) |
| >=5.0.201     | Hashed PublishTrimmed used for build (MSBuild property) |
| >=5.0.201     | Hashed PublishSingleFile used for build (MSBuild property) |
| >=5.0.202     | Elapsed time from process start until entering the CLI program's main method, measuring host and runtime startup. |
| >=5.0.202     | Elapsed time for the step that adds .NET Tools to the path on first run. |
| >=5.0.202     | Elapsed time to display first time use notice on first run. |
| >=5.0.202     | Elapsed time for generating ASP.NET Certificate on first run. |
| >=5.0.202     | Elapsed time to parse the CLI input. |
| >=6.0.100     | OS architecture |
| >=6.0.104     | Hashed PublishReadyToRunUseCrossgen2 used for build (MSBuild property) |
| >=6.0.104     | Hashed Crossgen2PackVersion used for build (MSBuild property) |
| >=6.0.104     | Hashed CompileListCount used for build (MSBuild property) |
| >=6.0.104     | Hashed _ReadyToRunCompilationFailures used for build (MSBuild property) |
| >=6.0.300     | If the CLI was invoked from a Continuous Integration environment. For more information, see [Continuous Integration Detection](#continuous-integration-detection).|
| >=7.0.100     | Hashed PublishAot used for build (MSBuild property) |
| >=7.0.100     | Hashed PublishProtocol used for build (MSBuild property) |

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

### Template engine telemetry

The `dotnet new` template instantiation command collects additional data for Microsoft-authored templates, starting with .NET Core 2.1.100 SDK:

* `--framework`
* `--auth`

## Crash exception telemetry

If the .NET CLI/SDK crashes, it collects the name of the exception and stack trace of the CLI/SDK code. This information is collected to assess problems and improve the quality of the .NET SDK and CLI. This article provides information about the data we collect. It also provides tips on how users building their own version of the .NET SDK can avoid inadvertent disclosure of personal or sensitive information.

The .NET CLI collects information for CLI/SDK exceptions only, not exceptions in your application. The collected data contains the name of the exception and the stack trace. This stack trace is of CLI/SDK code.

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

## Continuous Integration Detection

In order to detect if the .NET CLI is running in a Continuous Integration environment, the .NET CLI probes for the presence and values of several well-known environment variables that common CI providers set.

The full list of environment variables, and what is done with their values, is shown below.  Note that in every case, the value of the environment variable is never collected, only used to set a boolean flag.

| Variable(s) | Provider | Action |
| ----------- | -------- | ------ |
| TF_BUILD    | Azure Pipelines | Parse boolean value |
| GITHUB_ACTIONS | GitHub Actions | Parse boolean value |
| APPVEYOR | Appveyor | Parse boolean value |
| CI | Many/Most | Parse boolean value |
| TRAVIS | Travis CI | Parse boolean value |
| CIRCLECI | Circle CI | Parse boolean value |
| CODEBUILD_BUILD_ID, AWS_REGION | Amazon Web Services CodeBuild | Check if all are present and non-null |
| BUILD_ID, BUILD_URL | Jenkins | Check if all are present and non-null |
| BUILD_ID, PROJECT_ID | Google Cloud Build | Check if all are present and non-null |
| TEAMCITY_VERSION | TeamCity | Check if present and non-null |
| JB_SPACE_API_URL | JetBrains Space | Check if present and non-null |

## Avoid inadvertent disclosure of information

.NET contributors and anyone else running a version of the .NET SDK that they built themselves should consider the path to their SDK source code. If a crash occurs while using a .NET SDK that is a custom debug build or configured with custom build symbol files, the SDK source file path from the build machine is collected as part of the stack trace and isn't hashed.

Because of this, custom builds of the .NET SDK shouldn't be located in directories whose path names expose personal or sensitive information.

## See also

- [.NET CLI telemetry data](https://dotnet.microsoft.com/platform/telemetry)
- [Telemetry reference source (dotnet/sdk repository)](https://github.com/dotnet/sdk/tree/main/src/Cli/dotnet/Telemetry)
