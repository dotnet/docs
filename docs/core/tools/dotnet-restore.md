---
title: dotnet restore command
description: Learn how to restore dependencies and project-specific tools with the dotnet restore command.
ms.date: 07/19/2023
---
# dotnet restore

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet restore` - Restores the dependencies and tools of a project.

## Synopsis

```dotnetcli
dotnet restore [<ROOT>] [--configfile <FILE>] [--disable-build-servers]
    [--disable-parallel]
    [-f|--force] [--force-evaluate] [--ignore-failed-sources]
    [--interactive] [--lock-file-path <LOCK_FILE_PATH>] [--locked-mode]
    [--no-cache] [--no-dependencies] [--packages <PACKAGES_DIRECTORY>]
    [-r|--runtime <RUNTIME_IDENTIFIER>] [-s|--source <SOURCE>]
    [--tl:[auto|on|off]] [--use-current-runtime, --ucr [true|false]]
    [--use-lock-file] [-v|--verbosity <LEVEL>]

dotnet restore -h|--help
```

## Description

A .NET project typically references external libraries in [NuGet](https://www.nuget.org) packages that provide additional functionality. These external dependencies are referenced in the project file (*.csproj* or *.vbproj*). When you run the `dotnet restore` command, the .NET CLI uses NuGet to look for these dependencies and download them if necessary. It also ensures that all the dependencies required by the project are compatible with each other and that there are no conflicts between them. Once the command is completed, all the dependencies required by the project are available in a local cache and can be used by the .NET CLI to build and run the application.

In most cases, you don't need to explicitly use the `dotnet restore` command, since if a NuGet restore is necessary, the following commands run it implicitly:

- [`dotnet new`](dotnet-new.md)
- [`dotnet build`](dotnet-build.md)
- [`dotnet build-server`](dotnet-build-server.md)
- [`dotnet run`](dotnet-run.md)
- [`dotnet test`](dotnet-test.md)
- [`dotnet publish`](dotnet-publish.md)
- [`dotnet pack`](dotnet-pack.md)

Sometimes, it might be inconvenient to run the implicit NuGet restore with these commands. For example, some automated systems, such as build systems, need to call `dotnet restore` explicitly to control when the restore occurs so that they can control network usage. To prevent the implicit NuGet restore, you can use the `--no-restore` flag with any of these commands.

  > [!NOTE]
  > Signed package verification during restore operations requires a certificate root store that is valid for both code signing and timestamping. For more inforomation, see [NuGet signed package verification](nuget-signed-package-verification.md).

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

[!INCLUDE [arch](../../../includes/cli-arch.md)]

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [disable-build-servers](../../../includes/cli-disable-build-servers.md)]

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

  Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the `<RuntimeIdentifiers>` tag in the *.csproj* file. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

- **`-s|--source <SOURCE>`**

  Specifies the URI of the NuGet package source to use during the restore operation. This setting overrides all of the sources specified in the *nuget.config* files. Multiple sources can be provided by specifying this option multiple times.

[!INCLUDE [tl](../../../includes/cli-tl.md)]

- **`--use-current-runtime, --ucr [true|false]`**

  Sets the `RuntimeIdentifier` to a platform portable `RuntimeIdentifier` based on the one of your machine. This happens implicitly with properties that require a `RuntimeIdentifier`, such as `SelfContained`, `PublishAot`, `PublishSelfContained`, `PublishSingleFile`, and `PublishReadyToRun`. If the property is set to false, that implicit resolution will no longer occur.

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

## Audit for security vulnerabilities

Starting in .NET 8, `dotnet restore` includes NuGet security auditing. This auditing produces a report of security vulnerabilities with the affected package name, the severity of the vulnerability, and a link to the advisory for more details.

To opt out of the security auditing, set the `<NuGetAudit>` MSBuild property to `false` in your project file.

To retrieve the known vulnerability dataset, ensure that you have the NuGet.org central registry defined as one of your package sources:

```xml
<packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
</packageSources>
```

You can configure the level at which auditing will fail by setting the `<NuGetAuditLevel>` MSBuild property. Possible values are `low`, `moderate`, `high`, and `critical`. For example if you only want to see moderate, high, and critical advisories, you can set the property to `moderate`.

Starting in .NET 9, NuGet audits both *direct* and *transitive* package references, by default. In .NET 8, only *direct* package references are audited. You can change the mode by setting the `<NuGetAuditMode>` MSBuild property to `direct` or `all`.

For more information, see [Auditing package dependencies for security vulnerabilities](/nuget/concepts/auditing-packages).
