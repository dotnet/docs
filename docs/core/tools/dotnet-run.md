---
title: dotnet run command
description: The dotnet run command provides a convenient option to run your application from the source code.
ms.date: 09/02/2026
ai-usage: ai-assisted
---
# dotnet run

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet run` - Runs source code without any explicit compile or launch commands.

## Synopsis

```dotnetcli
dotnet run [<applicationArguments>]
  [-a|--arch <ARCHITECTURE>] [--artifacts-path <ARTIFACTS_DIR>]
  [-c|--configuration <CONFIGURATION>] [--disable-build-servers]
  [-e|--environment <KEY=VALUE>] [--file <FILE_PATH>]
  [-f|--framework <FRAMEWORK>] [--force] [--interactive]
  [-lp|--launch-profile <NAME>] [--no-build] [--no-cache]
  [--no-dependencies] [--no-launch-profile] [--no-restore] [--os <OS>]
  [-p|--property:<PROPERTYNAME>=<VALUE>]
  [--project <PATH>] [-r|--runtime <RUNTIME_IDENTIFIER>]
  [--sc|--self-contained] [--tl:[auto|on|off]] [-v|--verbosity <LEVEL>]
  [[--] [application arguments]]

dotnet run -h|--help
```

## Description

The `dotnet run` command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the [`dotnet build`](dotnet-build.md) command to build the code. Any requirements for the build apply to `dotnet run` as well.

Output files are written into the default location, which is `bin/<configuration>/<target>`. For example if you have a `netcoreapp2.1` application and you run `dotnet run`, the output is placed in `bin/Debug/netcoreapp2.1`. Files are overwritten as needed. Temporary files are placed in the `obj` directory.

If the project specifies multiple frameworks, executing `dotnet run` results in an error unless the `-f|--framework <FRAMEWORK>` option is used to specify the framework.

The `dotnet run` command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use [dotnet](dotnet.md) without a command. For example, to run `myapp.dll`, use:

```dotnetcli
dotnet myapp.dll
```

For more information on the `dotnet` driver, see [.NET CLI overview](index.md).

To run the application, the `dotnet run` command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use `dotnet run` to run applications in production. Instead, [create a deployment](../deploying/index.md) using the [`dotnet publish`](dotnet-publish.md) command and deploy the published output.

### Implicit restore

[!INCLUDE[dotnet restore note + options](includes/dotnet-restore-note-options.md)]

[!INCLUDE [cli-advertising-manifests](includes/cli-advertising-manifests.md)]

## Launch profiles

Launch profiles configure how `dotnet run` starts an app during development. For an SDK-style project, put the settings in `Properties/launchSettings.json`. Visual Basic projects use `My Project/launchSettings.json` instead.

File-based apps can use an `[ApplicationName].run.json` file next to the source file. For the file lookup order and examples, see [Launch profiles for file-based apps](../sdk/file-based-apps.md#launch-profiles).

The launch settings file contains a top-level `profiles` object. Each property in `profiles` defines a named profile:

```json
{
  "profiles": {
    "Local": {
      "commandName": "Project",
      "commandLineArgs": "--input sample.txt",
      "dotnetRunMessages": true,
      "environmentVariables": {
        "APP_MODE": "local"
      }
    }
  }
}
```

The .NET SDK launch settings parser accepts JSON comments and trailing commas.

### Select a profile

Use `--launch-profile <NAME>` to select a named profile. The name match is case-insensitive. Profile names that differ only by case are ambiguous and produce an error.

If you don't specify a name, `dotnet run` selects the first profile in file order whose `commandName` it supports. Use `--no-launch-profile` to skip the launch settings file.

When `dotnet run` applies a profile, it sets [`DOTNET_LAUNCH_PROFILE`](dotnet-environment-variables.md#dotnet_launch_profile) to the selected profile name in the launched process. A later environment-variable source can override the value.

### Supported profile types

The .NET SDK supports these `commandName` values for `dotnet run`. The values are case-sensitive.

| `commandName` | Behavior |
| --- | --- |
| `Project` | Builds the project and starts the command produced by the project. |
| `Executable` | Starts the command specified by `executablePath`. Unless you specify `--no-build`, `dotnet run` still builds the project first. |

### Common properties

`dotnet run` recognizes these properties for both supported profile types:

`dotnet run` expands `%NAME%` environment-variable references in supported string values. It also expands MSBuild property references in values that it uses to launch the process, using the same token replacement as Visual Studio. In .NET 11 and earlier versions, `dotnet run` doesn't expand MSBuild property references. It doesn't expand shell-style `$NAME` references.

| Property | Behavior |
| --- | --- |
| `commandLineArgs` | Specifies arguments for the launched process. Explicit application arguments on the command line take precedence. For a `Project` profile, arguments supplied by the project also take precedence. |
| `environmentVariables` | Specifies environment variables for the launched process. Profile values override inherited and SDK-generated environment variables, and `-e\|--environment` values override profile values. |
| `dotnetRunMessages` | When `true`, prints `Building...` before `dotnet run` builds the project. The default is `false`. This property doesn't control the message that identifies the launch settings file. |

Use `environmentVariables` to apply development-time runtime configuration settings that have an environment-variable form. For example, a profile can set GC settings such as `DOTNET_gcServer`. For the available settings, environment-variable names, and precedence rules, see [.NET runtime configuration settings](../runtime-config/index.md) and [Runtime configuration options for garbage collection](../runtime-config/garbage-collector.md).

Not every runtime setting has an environment-variable form. To configure an app independently of its launch profile, use an MSBuild property or `RuntimeHostConfigurationOption` item in the project, or use a `runtimeconfig.template.json` file. Some settings can also be changed in code with <xref:System.AppContext.SetSwitch*?displayProperty=nameWithType>. These mechanisms produce or modify the app's runtime configuration; they aren't additional `launchSettings.json` properties.

### `Project` properties

`dotnet run` recognizes these additional properties when `commandName` is `Project`:

| Property | Behavior |
| --- | --- |
| `applicationUrl` | Sets `ASPNETCORE_URLS` in the launched process. An `ASPNETCORE_URLS` value in `environmentVariables` or from `-e\|--environment` takes precedence. |
| `launchBrowser` | Tells launch tooling whether to open a browser. `dotnet run` retains this property in the parsed profile but doesn't open a browser. |
| `launchUrl` | Tells launch tooling which URL to open. `dotnet run` retains this property in the parsed profile but doesn't open a browser or use the URL. |

The `applicationUrl` behavior supports ASP.NET Core, but launch profiles and the other common properties apply to any runnable SDK-style .NET project.

### `Executable` properties

`dotnet run` recognizes these additional properties when `commandName` is `Executable`:

| Property | Behavior |
| --- | --- |
| `executablePath` | Required. Specifies the process to start. The SDK expands supported variable references, but it doesn't resolve a relative value against the launch settings file. Use an absolute path or a command that the operating system can locate. |
| `workingDirectory` | Optional. Specifies the working directory for the launched process. The SDK expands supported variable references and resolves a relative path against the directory that contains the launch settings file. If you omit the property, the working directory defaults to the directory that contains the project or file-based app. |

### Visual Studio and debugger extensions

`launchSettings.json` is a shared input format, but each consumer decides which values to support and how to interpret them. Visual Studio, debuggers, and other tools can recognize more `commandName` values and properties than `dotnet run`.

The following table compares the `dotnet run` contract with the common .NET project-system behavior in Visual Studio:

| Setting or behavior | `dotnet run` | Visual Studio |
| --- | --- | --- |
| Supported profile types | Supports `Project` and `Executable`. | Supports `Project`, `Executable`, and an empty `commandName`. Installed project-system extensions can add other profile types. |
| Variable expansion | Expands `%NAME%` environment-variable references and MSBuild property references in values that it uses to launch the process. In .NET 11 and earlier versions, doesn't expand MSBuild property references. | Expands environment variables and MSBuild properties in `executablePath`, `commandLineArgs`, `workingDirectory`, `launchUrl`, environment-variable values, and string-valued extension settings. |
| `commandLineArgs` for `Project` | Uses the profile value only when the project doesn't provide run arguments and you don't pass application arguments on the command line. | Appends the profile value to the run arguments from the project. |
| `workingDirectory` for `Project` | Ignores the property. | Supports the property. A relative path is relative to the project directory. |
| `workingDirectory` for `Executable` | A relative path is relative to the directory that contains the launch settings file. If omitted, the path defaults to the project or file-based app directory. | A relative path is relative to the project directory. If omitted, the path defaults to the output directory when that directory exists, or to the project directory otherwise. |
| Relative `executablePath` | Passes the value to the operating system without rebasing it. | Resolves a value with path components from the profile's working directory. For a bare executable name, Visual Studio checks its own current directory and then `PATH`. |
| `launchBrowser` and `launchUrl` | Retains the values in the parsed profile but doesn't open a browser. | Makes the values available to a launch provider. For example, ASP.NET Core tooling can open a browser. |
| `applicationUrl` | Sets `ASPNETCORE_URLS`. | Makes the value available to installed launch providers, such as ASP.NET Core tooling. |
| `dotnetRunMessages` | Controls the `Building...` message. | Doesn't use the property to control Visual Studio output. |
| Debugger properties | Ignores debugger-specific properties. | Uses properties such as `nativeDebugging`, `sqlDebugging`, `jsWebView2Debugging`, `remoteDebugEnabled`, and `hotReloadEnabled` when the project and debugger support the feature. |

In .NET 11 and earlier versions, no single `workingDirectory` value identifies the project directory for both consumers. Visual Studio expands `"$(ProjectDir)"`, while `dotnet run` treats it as literal text and resolves relative paths from the directory that contains the launch settings file. Therefore, use `".."` for `dotnet run` with a conventional `Properties/launchSettings.json` or `My Project/launchSettings.json` file. Visual Studio resolves the same value to the parent of the project directory. In later versions, both consumers expand `"$(ProjectDir)"`.

Windows Forms and WPF apps don't add another `dotnet run` profile type. Use a `Project` profile with common settings such as `commandLineArgs` and `environmentVariables`. In Visual Studio, these desktop project types can also use applicable debugger properties, such as `nativeDebugging` for mixed managed and native debugging or `jsWebView2Debugging` for WebView2. Browser and URL properties only have an effect when a launch provider or the application consumes them.

Other project types and Visual Studio workloads can install launch providers that add profile types or interpret extra properties. Those extensions don't add support to `dotnet run`: the CLI skips unsupported profile types during default selection and reports an error when you select one explicitly.

For Visual Studio's supported debugger settings and project UI, see [Project settings for a .NET C# debug configuration](/visualstudio/debugger/project-settings-for-csharp-debug-configurations-dotnetcore).

## Arguments

  `<applicationArguments>`
  
  Arguments passed to the application that is being run.
  
  Any arguments that aren't recognized by `dotnet run` are passed to the application. To separate arguments for `dotnet run` from arguments for the application, use the `--` option.

## Forward arguments to the application

`dotnet run` forwards any token it doesn't recognize to the application. The forwarded tokens keep their original order, but `dotnet run` first removes the options it understands. When a recognized option appears between an unrecognized option name and its value, removing the recognized option can change the meaning of the leftover tokens.

For example, the following command interleaves the recognized option `--project` between tokens the application is meant to receive:

```dotnetcli
dotnet run --app-flag --app-name --project ConsoleApp.csproj A.txt
```

After `dotnet run` consumes `--project ConsoleApp.csproj`, the application receives `--app-flag --app-name A.txt`. The application then treats `A.txt` as the value of `--app-name`, which doesn't match the original command line.

To avoid this ambiguity, place application arguments after a literal `--`:

```dotnetcli
dotnet run --project ConsoleApp.csproj -- --app-flag --app-name A.txt
```

The `--` separator marks every following token as an application argument, so `dotnet run` doesn't reorder or reinterpret them. The separator also future-proofs scripts against new `dotnet run` options that might later match a token previously forwarded to the application.

> [!NOTE]
> The same behavior applies to `dotnet build` and to `dotnet test` in Microsoft.Testing.Platform (MTP) mode, which forward unrecognized tokens to MSBuild or to the test application respectively. For more information about `dotnet test`, see [Forward arguments to the test application](dotnet-test-mtp.md#forward-arguments-to-the-test-application).

## Options

- **`--`**

  Delimits arguments to `dotnet run` from arguments for the application being run. All arguments after this delimiter are passed to the application run.

- [!INCLUDE [arch](includes/cli-arch.md)]

- [!INCLUDE [artifacts-path](includes/cli-artifacts-path.md)]

- [!INCLUDE [configuration](includes/cli-configuration.md)]

- [!INCLUDE [disable-build-servers](includes/cli-disable-build-servers.md)]

- **`-e|--environment <KEY=VALUE>`**

  Sets the specified environment variable in the process that will be run by the command. The specified environment variable is *not* applied to the `dotnet run` process.

  Environment variables passed through this option take precedence over ambient environment variables, System.CommandLine `env` directives, and `environmentVariables` from the chosen launch profile. For more information, see [Environment variables](#environment-variables).

  (This option was added in .NET SDK 9.0.200.)

- **`-f|--framework <FRAMEWORK>`**

  Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

- **`--file <FILE_PATH>`**

  The path to the file-based app to run. If a path isn't specified, the current directory is used to find and run the file. For more information on file-based apps, see [Build file-based C# apps](../../csharp/fundamentals/tutorials/file-based-programs.md).
  
  On Unix, execute file-based apps directly using the filename by adding a shebang (`#!`) directive and setting the execute permission. For more information, see [Unix shebang (`#!`) support](../../csharp/fundamentals/tutorials/file-based-programs.md#unix-shebang--support).

  Introduced in .NET SDK 10.0.100.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

- [!INCLUDE [interactive](includes/cli-interactive.md)]

- **`-lp|--launch-profile <NAME>`**

  The name of the launch profile to use when launching the application. For more information, see [Launch profiles](#launch-profiles).

- **`--no-build`**

  Doesn't build the project before running. It also implicitly sets the `--no-restore` flag.

- **`--no-cache`**

  Skip up to date checks and always build the program before running.

- **`--no-dependencies`**

  When restoring a project with project-to-project (P2P) references, restores the root project and not the references.

- **`--no-launch-profile`**

  Doesn't try to use *launchSettings.json* to configure the application.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- [!INCLUDE [no-self-contained](includes/cli-no-self-contained.md)]

- [!INCLUDE [os](includes/cli-os.md)]

- **`--project <PATH>`**

  Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

  The [`-p` abbreviation for `--project` is deprecated](../compatibility/sdk/6.0/deprecate-p-option-dotnet-run.md) starting in .NET 6 SDK. For a limited time, `-p` can still be used for `--project` despite the deprecation warning. If the argument provided for the option doesn't contain `=`, the command accepts `-p` as short for `--project`. Otherwise, the command assumes that `-p` is short for `--property`. This flexible use of `-p` for `--project` will be phased out in .NET 7.

- **`--property:<NAME>=<VALUE>`**

  Sets one or more MSBuild properties. Specify multiple properties delimited by semicolons or by repeating the option:

  ```dotnetcli
  --property:<NAME1>=<VALUE1>;<NAME2>=<VALUE2>
  --property:<NAME1>=<VALUE1> --property:<NAME2>=<VALUE2>
  ```

  The short form `-p` can be used for `--property`. If the argument provided for the option contains `=`, `-p` is accepted as short for `--property`. Otherwise, the command assumes that `-p` is short for `--project`.

  To pass `--property` to the application rather than set an MSBuild property, provide the option after the `--` syntax separator, for example:

  ```dotnetcli
  dotnet run -- --property name=value
  ```

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

- [!INCLUDE [self-contained](includes/cli-self-contained.md)]

- [!INCLUDE [tl](includes/cli-tl.md)]

- [!INCLUDE [verbosity](includes/cli-verbosity-minimal.md)]

- [!INCLUDE [help](includes/cli-help.md)]

## Environment variables

The following sources apply environment variables to the launched application:

1. Ambient environment variables from the operating system when the command is run.
1. System.CommandLine `env` directives, like `[env:key=value]`. These apply to the entire `dotnet run` process, not just the project being run by `dotnet run`.
1. Values generated from the chosen launch profile. `dotnet run` sets `DOTNET_LAUNCH_PROFILE`, and `applicationUrl` in a `Project` profile sets `ASPNETCORE_URLS`.
1. `environmentVariables` from the [chosen launch profile](#launch-profiles), if any. These apply to the project being run by `dotnet run`.
1. `-e|--environment` CLI option values (added in .NET SDK version 9.0.200). These apply to the project being run by `dotnet run`.

The environment is constructed in the same order as this list, so the `-e|--environment` option has the highest precedence.

## Examples

- Run the project in the current directory:

  ```dotnetcli
  dotnet run
  ```

- Run the specified file-based app in the current directory:

  ```dotnetcli
  dotnet run --file ConsoleApp.cs
  ```

  File-based app support was added in .NET SDK 10.0.100.

- Run the specified project:

  ```dotnetcli
  dotnet run --project ./projects/proj1/proj1.csproj
  ```

- Run the project in the current directory, specifying Release configuration:

  ```dotnetcli
  dotnet run --property:Configuration=Release
  ```

- Run the project in the current directory (the `--help` argument in this example is passed to the application, since the blank `--` option is used):

  ```dotnetcli
  dotnet run --configuration Release -- --help
  ```

- Restore dependencies and tools for the project in the current directory only showing minimal output and then run the project:

  ```dotnetcli
  dotnet run --verbosity m
  ```

- Run the project in the current directory using the specified framework and pass arguments to the application:

  ```dotnetcli
  dotnet run -f net6.0 -- arg1 arg2
  ```

  In the following example, three arguments are passed to the application. One argument is passed using `-`, and two arguments are passed after `--`:

  ```dotnetcli
  dotnet run -f net6.0 -arg1 -- arg2 arg3
  ```
