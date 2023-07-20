---
title: dotnet build command
description: The dotnet build command builds a project and all of its dependencies.
ms.date: 07/19/2023
---
# dotnet build

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet build` - Builds a project and all of its dependencies.

## Synopsis

```dotnetcli
dotnet build [<PROJECT>|<SOLUTION>] [-a|--arch <ARCHITECTURE>]
    [-c|--configuration <CONFIGURATION>] [-f|--framework <FRAMEWORK>]
    [--disable-build-servers]
    [--force] [--interactive] [--no-dependencies] [--no-incremental]
    [--no-restore] [--nologo] [--no-self-contained] [--os <OS>]
    [-o|--output <OUTPUT_DIRECTORY>]
    [-p|--property:<PROPERTYNAME>=<VALUE>]
    [-r|--runtime <RUNTIME_IDENTIFIER>]
    [--self-contained [true|false]] [--source <SOURCE>]
    [--tl [auto|on|off]] [--use-current-runtime, --ucr [true|false]]
    [-v|--verbosity <LEVEL>] [--version-suffix <VERSION_SUFFIX>]

dotnet build -h|--help
```

## Description

The `dotnet build` command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a *.dll* extension.  Depending on the project type and settings, other files may be included, such as:

- An executable that can be used to run the application, if the project type is an executable targeting .NET Core 3.0 or later.
- Symbol files used for debugging with a *.pdb* extension.
- A *.deps.json* file, which lists the dependencies of the application or library.
- A *.runtimeconfig.json* file, which specifies the shared runtime and its version for an application.
- Other libraries that the project depends on (via project references or NuGet package references).

For executable projects targeting versions earlier than .NET Core 3.0, library dependencies from NuGet are typically NOT copied to the output folder.  They're resolved from the NuGet global packages folder at run time. With that in mind, the product of `dotnet build` isn't ready to be transferred to another machine to run. To create a version of the application that can be deployed, you need to publish it (for example, with the [dotnet publish](dotnet-publish.md) command). For more information, see [.NET Application Deployment](../deploying/index.md).

For executable projects targeting .NET Core 3.0 and later, library dependencies are copied to the output folder. This means that if there isn't any other publish-specific logic (such as Web projects have), the build output should be deployable.

### Implicit restore

Building requires the *project.assets.json* file, which lists the dependencies of your application. The file is created when [`dotnet restore`](dotnet-restore.md) is executed. Without the assets file in place, the tooling can't resolve reference assemblies, which results in errors.

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

### Executable or library output

Whether the project is executable or not is determined by the `<OutputType>` property in the project file. The following example shows a project that produces executable code:

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

To produce a library, omit the `<OutputType>` property or change its value to `Library`. The IL DLL for a library doesn't contain entry points and can't be executed.

### MSBuild

`dotnet build` uses MSBuild to build the project, so it supports both parallel and incremental builds. For more information, see [Incremental Builds](/visualstudio/msbuild/incremental-builds).

In addition to its options, the `dotnet build` command accepts MSBuild options, such as `-p` for setting properties or `-l` to define a logger. For more information about these options, see the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference). Or you can also use the [dotnet msbuild](dotnet-msbuild.md) command.

> [!NOTE]
> When `dotnet build` is run automatically by `dotnet run`, arguments like `-property:property=value` aren't respected.

Running `dotnet build` is equivalent to running `dotnet msbuild -restore`; however, the default verbosity of the output is different.

[!INCLUDE [cli-advertising-manifests](../../../includes/cli-advertising-manifests.md)]

## Arguments

`PROJECT | SOLUTION`

The project or solution file to build. If a project or solution file isn't specified, MSBuild searches the current working directory for a file that has a file extension that ends in either *proj* or *sln* and uses that file.

## Options

[!INCLUDE [arch](../../../includes/cli-arch.md)]

[!INCLUDE [configuration](../../../includes/cli-configuration.md)]

[!INCLUDE [disable-build-servers](../../../includes/cli-disable-build-servers.md)]

- **`-f|--framework <FRAMEWORK>`**

  Compiles for a specific [framework](../../standard/frameworks.md). The framework must be defined in the [project file](../project-sdk/overview.md). Examples: `net7.0`, `net462`.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

- **`--no-dependencies`**

  Ignores project-to-project (P2P) references and only builds the specified root project.

- **`--no-incremental`**

  Marks the build as unsafe for incremental build. This flag turns off incremental compilation and forces a clean rebuild of the project's dependency graph.

- **`--no-restore`**

  Doesn't execute an implicit restore during build.

- **`--nologo`**

  Doesn't display the startup banner or the copyright message.

- **`--no-self-contained`**

  Publishes the application as a framework dependent application. A compatible .NET runtime must be installed on the target machine to run the application. Available since .NET 6 SDK.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Directory in which to place the built binaries. If not specified, the default path is `./bin/<configuration>/<framework>/`.  For projects with multiple target frameworks (via the `TargetFrameworks` property), you also need to define `--framework` when you specify this option.

  - .NET 7.0.200 SDK and later

    If you specify the `--output` option when running this command on a solution, the CLI will emit a warning (an error in 7.0.200) due to the unclear semantics of the output path. The `--output` option is disallowed because all outputs of all built projects would be copied into the specified directory, which isn't compatible with multi-targeted projects, as well as projects that have different versions of direct and transitive dependencies. For more information, see [Solution-level `--output` option no longer valid for build-related commands](../compatibility/sdk/7.0/solution-level-output-no-longer-valid.md).

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`-p|--property:<PROPERTYNAME>=<VALUE>`**

  Sets one or more MSBuild properties. Specify multiple properties delimited by semicolons or by repeating the option:

  ```dotnetcli
  --property:<NAME1>=<VALUE1>;<NAME2>=<VALUE2>
  --property:<NAME1>=<VALUE1> --property:<NAME2>=<VALUE2>
  ```

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). If you use this option with .NET 6 SDK, use `--self-contained` or `--no-self-contained` also. If not specified, the default is to build for the current OS and architecture.

- **`--self-contained [true|false]`**

  Publishes the .NET runtime with the application so the runtime doesn't need to be installed on the target machine. The default is `true` if a runtime identifier is specified. Available since .NET 6.

- **`--source <SOURCE>`**

  The URI of the NuGet package source to use during the restore operation.

- **`--tl [auto|on|off]`**

  Specifies whether the *terminal logger* should be used for the build output. The default is `auto`, which first verifies the environment before enabling terminal logging. The environment check verifies that the terminal is capable of using modern output features and isn't using a redirected standard output before enabling the new logger. `on` skips the environment check and enables terminal logging. `off` skips the environment check and uses the default console logger.

  The terminal logger shows you the restore phase followed by the build phase. During each phase, the currently building projects appear at the bottom of the terminal. Each project that's building outputs both the MSBuild target currently being built and the amount of time spent on that target. You can search this information to learn more about the build. When a project is finished building, a single "build completed" section is written for that captures:

  - The name of the built project
  - The target framework (if multi-targeted)
  - The status of that build
  - The primary output of that build (which is hyperlinked)
  - Any diagnostics generated for that project

  This option is available starting in .NET 8.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`. By default, MSBuild displays warnings and errors at all verbosity levels. To exclude warnings, use `/property:WarningLevel=0`. For more information, see <xref:Microsoft.Build.Framework.LoggerVerbosity> and [WarningLevel](../../csharp/language-reference/compiler-options/errors-warnings.md#warninglevel).

- **`--use-current-runtime, --ucr [true|false]`**

  Sets the `RuntimeIdentifier` to a platform portable `RuntimeIdentifier` based on the one of your machine. This happens implicitly with properties that require a `RuntimeIdentifier`, such as `SelfContained`, `PublishAot`, `PublishSelfContained`, `PublishSingleFile`, and `PublishReadyToRun`. If the property is set to false, that implicit resolution will no longer occur.

- **`--version-suffix <VERSION_SUFFIX>`**

  Sets the value of the `$(VersionSuffix)` property to use when building the project. This only works if the `$(Version)` property isn't set. Then, `$(Version)` is set to the `$(VersionPrefix)` combined with the `$(VersionSuffix)`, separated by a dash.

## Examples

- Build a project and its dependencies:

  ```dotnetcli
  dotnet build
  ```

- Build a project and its dependencies using Release configuration:

  ```dotnetcli
  dotnet build --configuration Release
  ```

- Build a project and its dependencies for a specific runtime (in this example, Ubuntu 18.04):

  ```dotnetcli
  dotnet build --runtime ubuntu.18.04-x64
  ```

- Build the project and use the specified NuGet package source during the restore operation:

  ```dotnetcli
  dotnet build --source c:\packages\mypackages
  ```

- Build the project and set version 1.2.3.4 as a build parameter using the `-p` [MSBuild option](#msbuild):

  ```dotnetcli
  dotnet build -p:Version=1.2.3.4
  ```
