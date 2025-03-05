---
title: dotnet add package command
description: The 'dotnet add package' command provides a convenient option to add a NuGet package reference to a project.
ms.date: 04/13/2022
---
# dotnet add package

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet add package` - Adds or updates a package reference in a project file.

## Synopsis

```dotnetcli
dotnet add [<PROJECT>] package <PACKAGE_NAME>
    [-f|--framework <FRAMEWORK>] [--interactive]
    [-n|--no-restore] [--package-directory <PACKAGE_DIRECTORY>]
    [--prerelease] [-s|--source <SOURCE>] [-v|--version <VERSION>]

dotnet add package -h|--help
```

## Description

The `dotnet add package` command provides a convenient option to add or update a package reference in a project file. When you run the command, there's a compatibility check to ensure the package is compatible with the frameworks in the project. If the check passes and the package isn't referenced in the project file, a `<PackageReference>` element is added to the project file. If the check passes and the package is already referenced in the project file, the `<PackageReference>` element is updated to the latest compatible version. After the project file is updated, [dotnet restore](dotnet-restore.md) is run.

For example, adding `Microsoft.EntityFrameworkCore` to *ToDo.csproj* produces output similar to the following example:

```console
  Determining projects to restore...
  Writing C:\Users\username\AppData\Local\Temp\tmp24A8.tmp
info : Adding PackageReference for package 'Microsoft.EntityFrameworkCore' into project 'C:\ToDo\ToDo.csproj'.
info :   CACHE https://api.nuget.org/v3/registration5-gz-semver2/microsoft.entityframeworkcore/index.json
info :   GET https://pkgs.dev.azure.com/dnceng/9ee6d478-d288-47f7-aacc-f6e6d082ae6d/_packaging/516521bf-6417-457e-9a9c-0a4bdfde03e7/nuget/v3/registrations2-semver2/microsoft.entityframeworkcore/index.json
info :   CACHE https://api.nuget.org/v3/registration5-gz-semver2/microsoft.entityframeworkcore/page/0.0.1-alpha/3.1.3.json
info :   CACHE https://api.nuget.org/v3/registration5-gz-semver2/microsoft.entityframeworkcore/page/3.1.4/7.0.0-preview.2.22153.1.json
info :   CACHE https://api.nuget.org/v3/registration5-gz-semver2/microsoft.entityframeworkcore/page/7.0.0-preview.3.22175.1/7.0.0-preview.3.22175.1.json
info :   NotFound https://pkgs.dev.azure.com/dnceng/9ee6d478-d288-47f7-aacc-f6e6d082ae6d/_packaging/516521bf-6417-457e-9a9c-0a4bdfde03e7/nuget/v3/registrations2-semver2/microsoft.entityframeworkcore/index.json 257ms
info : Restoring packages for C:\ToDo\ToDo.csproj...
info : Package 'Microsoft.EntityFrameworkCore' is compatible with all the specified frameworks in project 'C:\ToDo\ToDo.csproj'.
info : PackageReference for package 'Microsoft.EntityFrameworkCore' version '6.0.4' added to file 'C:\ToDo\ToDo.csproj'.
info : Writing assets file to disk. Path: C:\ToDo\obj\project.assets.json
log  : Restored C:\ToDo\ToDo.csproj (in 171 ms).
```

The *ToDo.csproj* file now contains a [`<PackageReference>`](/nuget/consume-packages/package-references-in-project-files) element for the referenced package.

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.4" />
```

If the project is onboarded onto [Central Package Management (CPM)](https://devblogs.microsoft.com/nuget/introducing-central-package-management/) the `<PackageVersion>` element in the `Directory.Packages.props file` is added/updated and the `<PackageReference>` element is added to the project file.

The following scenarios are currently supported. These examples assume that the latest version of `Microsoft.EntityFrameworkCore` is 6.0.4. Additional scenarios related to CPM are documented in [this design spec](https://github.com/NuGet/Home/pull/11915).

Scenario 1: `<PackageReference>` does not exist in the project file, `<PackageVersion>` element does not exist in the `Directory.Packages.props file`, and the version argument is not passed from the commandline.

  CLI command that is executed: `dotnet add ToDo.csproj package Microsoft.EntityFrameworkCore`

  The `<PackageVersion>` element is added to the `Directory.Packages.props file`.

  ```xml
  <PackageVersion Include="Microsoft.EntityFrameworkCore" Version="6.0.4" />
  ```

  The `<PackageReference>` element is added to the project file.

  ```xml
  <PackageReference Include="Microsoft.EntityFrameworkCore" />
  ```

Scenario 2: `<PackageReference>` does not exist in the project file, `<PackageVersion>` element does not exist in the `Directory.Packages.props file`, and the version argument is passed from the commandline.

  CLI command that is executed: `dotnet add ToDo.csproj package Microsoft.EntityFrameworkCore --version 5.0.4`

  The `<PackageVersion>` element is added to the `Directory.Packages.props file`.

  ```xml
  <PackageVersion Include="Microsoft.EntityFrameworkCore" Version="5.0.4" />
  ```

  The `<PackageReference>` element is added to the project file.

  ```xml
  <PackageReference Include="Microsoft.EntityFrameworkCore" />
  ```

### Implicit restore

[!INCLUDE[DotNet Restore Note](../../../includes/dotnet-restore-note.md)]

## Arguments

- **`PROJECT`**

  Specifies the project file. If not specified, the command searches the current directory for one.

- **`PACKAGE_NAME`**

  The package reference to add.

## Options

- **`-f|--framework <FRAMEWORK>`**

  Adds a package reference only when targeting a specific [framework](../../standard/frameworks.md).

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`-n|--no-restore`**

  Adds a package reference without performing a restore preview and compatibility check.

- **`--package-directory <PACKAGE_DIRECTORY>`**

  The directory where to restore the packages. The default package restore location is `%userprofile%\.nuget\packages` on Windows and `~/.nuget/packages` on macOS and Linux. For more information, see [Managing the global packages, cache, and temp folders in NuGet](/nuget/consume-packages/managing-the-global-packages-and-cache-folders).

- **`--prerelease`**

  Allows prerelease packages to be installed. Available since .NET Core 5 SDK

- **`-s|--source <SOURCE>`**

  The URI of the NuGet package source to use during the restore operation.

- **`-v|--version <VERSION>`**

  Version of the package. See [NuGet package versioning](/nuget/reference/package-versioning).

## Examples

- Add `Microsoft.EntityFrameworkCore` NuGet package to a project:

  ```dotnetcli
  dotnet add package Microsoft.EntityFrameworkCore
  ```

- Add a specific version of a package to a project:

  ```dotnetcli
  dotnet add ToDo.csproj package Microsoft.Azure.DocumentDB.Core -v 1.0.0
  ```

- Add a package using a specific NuGet source:

  ```dotnetcli
  dotnet add package Microsoft.AspNetCore.StaticFiles -s https://dotnet.myget.org/F/dotnet-core/api/v3/index.json
  ```

## See also

- [Managing the global packages, cache, and temp folders in NuGet](/nuget/consume-packages/managing-the-global-packages-and-cache-folders)
- [NuGet package versioning](/nuget/reference/package-versioning)
