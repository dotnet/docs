---
title: dotnet publish command - .NET Core CLI
description: The dotnet publish command publishes your .NET Core project into a directory.
author: mairaw
ms.author: mairaw
ms.date: 03/10/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet publish

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet publish` - Packs the application and its dependencies into a folder for deployment to a hosting system.

## Synopsis

# [.NET Core 2.x](#tab/netcore2x)

```
dotnet publish [<PROJECT>] [-c|--configuration] [-f|--framework] [--force] [--manifest] [--no-dependencies] [--no-restore] [-o|--output] [-r|--runtime] [--self-contained] [-v|--verbosity] [--version-suffix]
dotnet publish [-h|--help]
```

# [.NET Core 1.x](#tab/netcore1x)

```
dotnet publish [<PROJECT>] [-c|--configuration] [-f|--framework] [-o|--output] [-r|--runtime] [-v|--verbosity] [--version-suffix]
dotnet publish [-h|--help]
```

---

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output will contain the following:

* Intermediate Language (IL) code in an assembly with a *dll* extension.
* *.deps.json* file that contains all of the dependencies of the project.
* *.runtime.config.json* file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).
* The application's dependencies. These are copied from the NuGet cache into the output folder.

The `dotnet publish` command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution and is the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET Core shared runtime installed on it. For more information, see [.NET Core Application Deployment](../deploying/index.md). For the directory structure of a published application, see [Directory structure](/aspnet/core/hosting/directory-structure).

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

## Arguments

`PROJECT`

The project to publish, which defaults to the current directory if not specified.

## Options

# [.NET Core 2.x](#tab/netcore2x)

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Publishes the application for the specified [target framework](../../standard/frameworks.md). You must specify the target framework in the project file.

`--force`

Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the *project.assets.json* file.

`-h|--help`

Prints out a short help for the command.

`--manifest <PATH_TO_MANIFEST_FILE>`

Specifies one or several [target manifests](../deploying/runtime-store.md) to use to trim the set of packages published with the app. The manifest file is part of the output of the [`dotnet store` command](dotnet-store.md). To specify multiple manifests, add a `--manifest` option for each manifest. This option is available starting with .NET Core 2.0 SDK.

`--no-dependencies`

Ignores project-to-project references and only restores the root project.

`--no-restore`

Doesn't perform an implicit restore when running the command.

`-o|--output <OUTPUT_DIRECTORY>`

Specifies the path for the output directory. If not specified, it defaults to *./bin/[configuration]/[framework]/* for a framework-dependent deployment or *./bin/[configuration]/[framework]/[runtime]* for a self-contained deployment.
If a relative path is provided, the output directory generated is relative to the project file location, not to the current working directory.

`--self-contained`

Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is `true`. For more information about the different deployment types, see [.NET Core application deployment](../deploying/index.md).

`-r|--runtime <RUNTIME_IDENTIFIER>`

Publishes the application for a given runtime. This is used when creating a [self-contained deployment (SCD)](../deploying/index.md#self-contained-deployments-scd). For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Default is to publish a [framework-dependent deployment (FDD)](../deploying/index.md#framework-dependent-deployments-fdd).

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix to replace the asterisk (`*`) in the version field of the project file.

# [.NET Core 1.x](#tab/netcore1x)

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Publishes the application for the specified [target framework](../../standard/frameworks.md). You must specify the target framework in the project file.

`-h|--help`

Prints out a short help for the command.

`--manifest <PATH_TO_MANIFEST_FILE>`

Specifies one or several [target manifests](../deploying/runtime-store.md) to use to trim the set of packages published with the app. The manifest file is part of the output of the [`dotnet store` command](dotnet-store.md). To specify multiple manifests, add a `--manifest` option for each manifest. This option is available starting with .NET Core 2.0 SDK.

`-o|--output <OUTPUT_DIRECTORY>`

Specifies the path for the output directory. If not specified, it defaults to *./bin/[configuration]/[framework]/* for a framework-dependent deployment or *./bin/[configuration]/[framework]/[runtime]* for a self-contained deployment.
If a relative path is provided, the output directory generated is relative to the project file location, not to the current working directory.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Publishes the application for a given runtime. This is used when creating a [self-contained deployment (SCD)](../deploying/index.md#self-contained-deployments-scd). For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Default is to publish a [framework-dependent deployment (FDD)](../deploying/index.md#framework-dependent-deployments-fdd).

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix to replace the asterisk (`*`) in the version field of the project file.

---

## Examples

Publish the project in the current directory:

`dotnet publish`

Publish the application using the specified project file:

`dotnet publish ~/projects/app1/app1.csproj`

Publish the project in the current directory using the `netcoreapp1.1` framework:

`dotnet publish --framework netcoreapp1.1`

Publish the current application using the `netcoreapp1.1` framework and the runtime for `OS X 10.10` (you must list this RID in the project file).

`dotnet publish --framework netcoreapp1.1 --runtime osx.10.11-x64`

Publish the current application but don't restore project-to-project (P2P) references, just the root project during the restore operation (.NET Core SDK 2.0 and later versions):

`dotnet publish --no-dependencies`

## See also

* [Target frameworks](../../standard/frameworks.md)
* [Runtime IDentifier (RID) catalog](../rid-catalog.md)