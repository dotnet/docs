---
title: dotnet publish command
description: The dotnet publish command publishes a .NET Core project or solution to a directory.
ms.date: 02/24/2020
---
# dotnet publish

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Name

`dotnet publish` - Publishes the application and its dependencies to a folder for deployment to a hosting system.

## Synopsis

```dotnetcli
dotnet publish [<PROJECT>|<SOLUTION>] [-c|--configuration]
    [-f|--framework] [--force] [--interactive] [--manifest]
    [--no-build] [--no-dependencies] [--no-restore] [--nologo]
    [-o|--output] [-r|--runtime] [--self-contained]
    [--no-self-contained] [-v|--verbosity] [--version-suffix]

dotnet publish [-h|--help]
```

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output includes the following assets:

- Intermediate Language (IL) code in an assembly with a *dll* extension.
- A *.deps.json* file that includes all of the dependencies of the project.
- A *.runtimeconfig.json* file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).
- The application's dependencies, which are copied from the NuGet cache into the output folder.

The `dotnet publish` command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution. It's the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET Core shared runtime installed on it.

## Arguments

- **`PROJECT|SOLUTION`**

  The project or solution to publish.
  
  * `PROJECT` is the path and filename of a [C#](csproj.md), F#, or Visual Basic project file, or the path to a directory that contains a C#, F#, or Visual Basic project file. If the directory is not specified, it defaults to the current directory.

  * `SOLUTION` is the path and filename of a solution file (*.sln* extension), or the path to a directory that contains a solution file. If the directory is not specified, it defaults to the current directory. Available since .NET Core 3.0 SDK.

## Options

- **`-c|--configuration <CONFIGURATION>`**

  Defines the build configuration. The default for most projects is `Debug`, but you can override the build configuration settings in your project.

- **`-f|--framework <FRAMEWORK>`**

  Publishes the application for the specified [target framework](../../standard/frameworks.md). You must specify the target framework in the project file.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

- **`-h|--help`**

  Prints out a short help for the command.

- **`--interactive`**

  Allows the command to stop and wait for user input or action. For example, to complete authentication. Available since .NET Core 3.0 SDK.

- **`--manifest <PATH_TO_MANIFEST_FILE>`**

  Specifies one or several [target manifests](../deploying/runtime-store.md) to use to trim the set of packages published with the app. The manifest file is part of the output of the [`dotnet store` command](dotnet-store.md). To specify multiple manifests, add a `--manifest` option for each manifest.

- **`--no-build`**

  Doesn't build the project before publishing. It also implicitly sets the `--no-restore` flag.

- **`--no-dependencies`**

  Ignores project-to-project references and only restores the root project.

- **`--nologo`**

  Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Specifies the path for the output directory. If not specified, it defaults to *./bin/[configuration]/[framework]/publish/* for a runtime-dependent executable and cross-platform binaries. It defaults to *./bin/[configuration]/[framework]/[runtime]/publish/* for a self-contained executable.

  If the path is relative, the output directory generated is relative to the project file location, not to the current working directory.

- **`--self-contained [true|false]`**

  Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. Default is `true` if a runtime identifier is specified. For more information, see [.NET Core application publishing](../deploying/index.md) and [Publish .NET Core apps with the .NET Core CLI](../deploying/deploy-with-cli.md).

- **`--no-self-contained`**

  Equivalent to `--self-contained false`. Available since .NET Core 3.0 SDK.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Publishes the application for a given runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). For more information, see [.NET Core application publishing](../deploying/index.md) and [Publish .NET Core apps with the .NET Core CLI](../deploying/deploy-with-cli.md).

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. Default value is `minimal`.

- **`--version-suffix <VERSION_SUFFIX>`**

  Defines the version suffix to replace the asterisk (`*`) in the version field of the project file.

## Examples

- Create a [runtime-dependent cross-platform binary](../deploying/index.md#produce-a-cross-platform-binary) for the project in the current directory:

  ```dotnetcli
  dotnet publish
  ```

  Starting with .NET Core 3.0 SDK, this example also creates a [runtime-dependent executable](../deploying/index.md#publish-runtime-dependent) for the current platform.

- Create a [self-contained executable](../deploying/index.md#publish-self-contained) for the project in the current directory, for a specific runtime:

  ```dotnetcli
  dotnet publish --runtime osx.10.11-x64
  ```

  The RID must be in the project file.

- Create a [runtime-dependent executable](../deploying/index.md#publish-runtime-dependent) for the project in the current directory, for a specific platform:

  ```dotnetcli
  dotnet publish --runtime osx.10.11-x64 --self-contained false
  ```

  The RID must be in the project file. This example applies to .NET Core 3.0 SDK and later versions.

- Publish the project in the current directory, for a specific runtime and target framework:

  ```dotnetcli
  dotnet publish --framework netcoreapp3.1 --runtime osx.10.11-x64
  ```

- Publish the specified project file:

  ```dotnetcli
  dotnet publish ~/projects/app1/app1.csproj
  ```

- Publish the current application but don't restore project-to-project (P2P) references, just the root project during the restore operation:

  ```dotnetcli
  dotnet publish --no-dependencies
  ```

## See also

- [.NET Core application publishing overview](../deploying/index.md)
- [Publish .NET Core apps with the .NET Core CLI](../deploying/deploy-with-cli.md)
- [Target frameworks](../../standard/frameworks.md)
- [Runtime IDentifier (RID) catalog](../rid-catalog.md)
- [Working with macOS Catalina Notarization](../install/macos-notarization-issues.md)
 For more information, see he following resources:
- [Directory structure of a published application](/aspnet/core/hosting/directory-structure)
