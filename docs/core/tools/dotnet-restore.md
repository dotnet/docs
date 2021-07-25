---
title: dotnet restore command
description: Learn how to restore dependencies and project-specific tools with the dotnet restore command.
ms.date: 02/27/2020
---
# dotnet restore

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Name

`dotnet restore` - Restores the dependencies and tools of a project.

## Synopsis

```dotnetcli
dotnet restore [<ROOT>] [--configfile <FILE>] [--disable-parallel]
    [-f|--force] [--force-evaluate] [--ignore-failed-sources]
    [--interactive] [--lock-file-path <LOCK_FILE_PATH>] [--locked-mode]
    [--no-cache] [--no-dependencies] [--packages <PACKAGES_DIRECTORY>]
    [-r|--runtime <RUNTIME_IDENTIFIER>] [-s|--source <SOURCE>]
    [--use-lock-file] [-v|--verbosity <LEVEL>]

dotnet restore -h|--help
```

## Description

The `dotnet restore` command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file.  In most cases, you don't need to explicitly use the `dotnet restore` command, since a NuGet restore is run implicitly if necessary when you run the following commands:

- [`dotnet new`](dotnet-new.md)
- [`dotnet build`](dotnet-build.md)
- [`dotnet build-server`](dotnet-build-server.md)
- [`dotnet run`](dotnet-run.md)
- [`dotnet test`](dotnet-test.md)
- [`dotnet publish`](dotnet-publish.md)
- [`dotnet pack`](dotnet-pack.md)

Sometimes, it might be inconvenient to run the implicit NuGet restore with these commands. For example, some automated systems, such as build systems, need to call `dotnet restore` explicitly to control when the restore occurs so that they can control network usage. To prevent the implicit NuGet restore, you can use the `--no-restore` flag with any of these commands to disable implicit restore.

### Specify feeds

To restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the *nuget.config* configuration file. A default configuration file is provided when the .NET SDK is installed. To specify additional feeds, do one of the following:

- Create your own *nuget.config* file in the project directory. For more information, see [Common NuGet configurations](/nuget/consume-packages/configuring-nuget-behavior) and [nuget.config differences](#nugetconfig-differences) later in this article.
- Use `dotnet nuget` commands such as [`dotnet nuget add source`](dotnet-nuget-add-source.md).

You can override the *nuget.config* feeds with the `-s` option.

For information about how to use authenticated feeds, see [Consuming packages from authenticated feeds](/nuget/consume-packages/consuming-packages-authenticated-feeds).

### Global packages folder

For dependencies, you can specify where the restored packages are placed during the restore operation using the `--packages` argument. If not specified, the default NuGet package cache is used, which is found in the `.nuget/packages` directory in the user's home directory on all operating systems. For example, */home/user1* on Linux or *C:\Users\user1* on Windows.

### Project-specific tooling

For project-specific tooling, `dotnet restore` first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.

### nuget.config differences

The behavior of the `dotnet restore` command is affected by the settings in the *nuget.config* file, if present. For example, setting the `globalPackagesFolder` in *nuget.config* places the restored NuGet packages in the specified folder. This is an alternative to specifying the `--packages` option on the `dotnet restore` command. For more information, see the [nuget.config reference](/nuget/schema/nuget-config-file).

There are three specific settings that `dotnet restore` ignores:

- [bindingRedirects](/nuget/schema/nuget-config-file#bindingredirects-section)

  Binding redirects don't work with `<PackageReference>` elements and .NET only supports `<PackageReference>` elements for NuGet packages.

- [solution](/nuget/schema/nuget-config-file#solution-section)

  This setting is Visual Studio specific and doesn't apply to .NET. .NET doesn't use a `packages.config` file and instead uses `<PackageReference>` elements for NuGet packages.

- [trustedSigners](/nuget/schema/nuget-config-file#trustedsigners-section)

  Support for cross-platform package signature verification was added in the .NET 5.0.100 SDK.

[!INCLUDE [cli-advertising-manifests](../../../includes/cli-advertising-manifests.md)]

## Arguments

- **`ROOT`**

  Optional path to the project file to restore.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

- **`--disable-parallel`**

  Disables restoring multiple projects in parallel.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

- **`--force-evaluate`**

  Forces restore to reevaluate all dependencies even if a lock file already exists.

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--ignore-failed-sources`**

  Only warn about failed sources if there are packages meeting the version requirement.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`--lock-file-path <LOCK_FILE_PATH>`**

  Output location where project lock file is written. By default, this is *PROJECT_ROOT\packages.lock.json*.

- **`--locked-mode`**

  Don't allow updating project lock file.

- **`--no-cache`**

  Specifies to not cache HTTP requests.

- **`--no-dependencies`**

  When restoring a project with project-to-project (P2P) references, restores the root project and not the references.

- **`--packages <PACKAGES_DIRECTORY>`**

  Specifies the directory for restored packages.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the `<RuntimeIdentifiers>` tag in the *.csproj* file. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Provide multiple RIDs by specifying this option multiple times.

- **`-s|--source <SOURCE>`**

  Specifies the URI of the NuGet package source to use during the restore operation. This setting overrides all of the sources specified in the *nuget.config* files. Multiple sources can be provided by specifying this option multiple times.

- **`--use-lock-file`**

  Enables project lock file to be generated and used with restore.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Examples

- Restore dependencies and tools for the project in the current directory:

  ```dotnetcli
  dotnet restore
  ```

- Restore dependencies and tools for the `app1` project found in the given path:

  ```dotnetcli
  dotnet restore ./projects/app1/app1.csproj
  ```

- Restore the dependencies and tools for the project in the current   directory using the file path provided as the source:

  ```dotnetcli
  dotnet restore -s c:\packages\mypackages
  ```

- Restore the dependencies and tools for the project in the current   directory using the two file paths provided as sources:

  ```dotnetcli
  dotnet restore -s c:\packages\mypackages -s c:\packages\myotherpackages
  ```

- Restore dependencies and tools for the project in the current directory   showing detailed output:

  ```dotnetcli
  dotnet restore --verbosity detailed
  ```
