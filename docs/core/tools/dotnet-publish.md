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
dotnet publish [<PROJECT>|<SOLUTION>] [-c|--configuration] [-f|--framework] [--force] [--interactive] [--manifest] [--no-build] [--no-dependencies] [--no-restore] [--nologo] [-o|--output] [-r|--runtime] [--self-contained] [--no-self-contained] [-v|--verbosity] [--version-suffix]
dotnet publish [-h|--help]
```

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output includes the following assets:

- Intermediate Language (IL) code in an assembly with a *dll* extension.
- A *.deps.json* file that includes all of the dependencies of the project.
- A *.runtimeconfig.json* file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).
- The application's dependencies, which are copied from the NuGet cache into the output folder.

The `dotnet publish` command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution. It's the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET Core shared runtime installed on it. For more information, see [.NET Core application publishing](../deploying/index.md). For the directory structure of a published application, see [Directory structure](/aspnet/core/hosting/directory-structure).

## Arguments

- **`PROJECT|SOLUTION`**

  The project or solution to publish.
  
  * `PROJECT` is the path and filename of a [C#](csproj.md), F#, or Visual Basic project file, or the path to a directory that contains a C#, F#, or Visual Basic project file. If the directory is not specified, it defaults to the current directory.

  * `SOLUTION` is available starting in .NET Core 3.0 SDK. It's either the path and filename of a solution file (*.sln* extension), or the path to a directory that contains a solution file. If the directory is not specified, it defaults to the current directory.

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

  Allows the command to stop and wait for user input or action. For example, to complete authentication. Available starting with .NET Core SDK 3.0.

- **`--manifest <PATH_TO_MANIFEST_FILE>`**

  Specifies one or several [target manifests](../deploying/runtime-store.md) to use to trim the set of packages published with the app. The manifest file is part of the output of the [`dotnet store` command](dotnet-store.md). To specify multiple manifests, add a `--manifest` option for each manifest.

- **`--no-build`**

  Doesn't build the project before publishing. It also implicitly sets the `--no-restore` flag.

- **`--no-dependencies`**

  Ignores project-to-project references and only restores the root project.

- **`--nologo`**

  Doesn't display the startup banner or the copyright message. Available starting with .NET Core SDK 3.0.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Specifies the path for the output directory. If not specified, it defaults to *./bin/[configuration]/[framework]/publish/* for a runtime-dependent executable and cross-platform binaries. It defaults to *./bin/[configuration]/[framework]/[runtime]/publish/* for a self-contained executable.

  If the path is relative, the output directory generated is relative to the project file location, not to the current working directory.

- **`--self-contained`**

  Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. Default is `true` if a runtime identifier is specified. For more information about the different deployment types, see [.NET Core application publishing](../deploying/index.md).

- **`--no-self-contained`**

  Publish the application as a runtime-dependent application without the .NET Core runtime. A supported .NET Core runtime must be installed to run the application. Available starting with .NET Core SDK 3.0.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Publishes the application for a given runtime. This is used when creating a [self-contained executable](../deploying/index.md#publish-self-contained). For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Default is to publish a [runtime-dependent application](../deploying/index.md#publish-runtime-dependent).

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

- **`--version-suffix <VERSION_SUFFIX>`**

  Defines the version suffix to replace the asterisk (`*`) in the version field of the project file.

## Examples

Publish the project in the current directory:

```dotnetcli
dotnet publish
```

Publish the application using the specified project file:

```dotnetcli
dotnet publish ~/projects/app1/app1.csproj
```

Publish the project in the current directory using the `netcoreapp1.1` framework:

```dotnetcli
dotnet publish --framework netcoreapp1.1
```

Publish the current application using the `netcoreapp1.1` framework and the runtime for `OS X 10.10` (you must list this RID in the project file).

```dotnetcli
dotnet publish --framework netcoreapp1.1 --runtime osx.10.11-x64
```

Publish the current application but don't restore project-to-project (P2P) references, just the root project during the restore operation:

```dotnetcli
dotnet publish --no-dependencies
```

## See also

- [.NET Core application publishing](../deploying/index.md)
- [Target frameworks](../../standard/frameworks.md)
- [Runtime IDentifier (RID) catalog](../rid-catalog.md)
- [Working with macOS Catalina Notarization](../install/macos-notarization-issues.md)
