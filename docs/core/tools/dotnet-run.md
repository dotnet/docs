---
title: dotnet run command
description: The dotnet run command provides a convenient option to run your application from the source code.
ms.date: 08/18/2021
---
# dotnet run

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet run` - Runs source code without any explicit compile or launch commands.

## Synopsis

```dotnetcli
dotnet run [-a|--arch <ARCHITECTURE>] [-c|--configuration <CONFIGURATION>]
    [-f|--framework <FRAMEWORK>] [--force] [--interactive]
    [--launch-profile <NAME>] [--no-build]
    [--no-dependencies] [--no-launch-profile] [--no-restore]
    [--os <OS>] [--project <PATH>] [-r|--runtime <RUNTIME_IDENTIFIER>]
    [-v|--verbosity <LEVEL>] [[--] [application arguments]]

dotnet run -h|--help
```

## Description

The `dotnet run` command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the [`dotnet build`](dotnet-build.md) command to build the code. Any requirements for the build, such as that the project must be restored first, apply to `dotnet run` as well.

> [!NOTE]
> `dotnet run` doesn't respect arguments like `/property:property=value`, which are respected by `dotnet build`.

Output files are written into the default location, which is `bin/<configuration>/<target>`. For example if you have a `netcoreapp2.1` application and you run `dotnet run`, the output is placed in `bin/Debug/netcoreapp2.1`. Files are overwritten as needed. Temporary files are placed in the `obj` directory.

If the project specifies multiple frameworks, executing `dotnet run` results in an error unless the `-f|--framework <FRAMEWORK>` option is used to specify the framework.

The `dotnet run` command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use [dotnet](dotnet.md) without a command. For example, to run `myapp.dll`, use:

```dotnetcli
dotnet myapp.dll
```

For more information on the `dotnet` driver, see the [.NET Command Line Tools (CLI)](index.md) topic.

To run the application, the `dotnet run` command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use `dotnet run` to run applications in production. Instead, [create a deployment](../deploying/index.md) using the [`dotnet publish`](dotnet-publish.md) command and deploy the published output.

### Implicit restore

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

[!INCLUDE [cli-advertising-manifests](../../../includes/cli-advertising-manifests.md)]

## Options

<!-- markdownlint-disable MD012 -->

- **`--`**

  Delimits arguments to `dotnet run` from arguments for the application being run. All arguments after this delimiter are passed to the application run.

[!INCLUDE [arch](../../../includes/cli-arch.md)]

[!INCLUDE [configuration](../../../includes/cli-configuration.md)]

- **`-f|--framework <FRAMEWORK>`**

  Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

- **`--launch-profile <NAME>`**

  The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the *launchSettings.json* file and are typically called `Development`, `Staging`, and `Production`. For more information, see [Working with multiple environments](/aspnet/core/fundamentals/environments).

- **`--no-build`**

  Doesn't build the project before running. It also implicit sets the `--no-restore` flag.

- **`--no-dependencies`**

  When restoring a project with project-to-project (P2P) references, restores the root project and not the references.

- **`--no-launch-profile`**

  Doesn't try to use *launchSettings.json* to configure the application.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`--project <PATH>`**

  Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

  The [`-p` abbreviation for `--project` is deprecated](../compatibility/sdk/6.0/deprecate-p-option-dotnet-run.md) starting in .NET 6 SDK. For a limited time starting in .NET 6 RC1 SDK, `-p` can still be used for `--project` despite the deprecation warning. If the argument provided for the option doesn't contain `=`, the command accepts `-p` as short for `--project`. Otherwise, the command assumes that `-p` is short for `--property`. This flexible use of `-p` for `--project` will be phased out in .NET 7.

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

  Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). `-r` short option available since .NET Core 3.0 SDK.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Examples

- Run the project in the current directory:

  ```dotnetcli
  dotnet run
  ```

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
