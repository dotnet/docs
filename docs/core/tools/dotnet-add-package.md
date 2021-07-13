---
title: dotnet add package command
description: The 'dotnet add package' command provides a convenient option to add a NuGet package reference to a project.
ms.date: 11/11/2020
---
# dotnet add package

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet add package` - Adds a package reference to a project file.

## Synopsis

```dotnetcli
dotnet add [<PROJECT>] package <PACKAGE_NAME>
    [-f|--framework <FRAMEWORK>] [--interactive]
    [-n|--no-restore] [--package-directory <PACKAGE_DIRECTORY>]
    [--prerelease] [-s|--source <SOURCE>] [-v|--version <VERSION>]

dotnet add package -h|--help
```

## Description

The `dotnet add package` command provides a convenient option to add a package reference to a project file. After running the command, there's a compatibility check to ensure the package is compatible with the frameworks in the project. If the check passes, a `<PackageReference>` element is added to the project file and [dotnet restore](dotnet-restore.md) is run.

For example, adding `Newtonsoft.Json` to *ToDo.csproj* produces output similar to the following example:

```console
Writing C:\Users\me\AppData\Local\Temp\tmp95A8.tmp
info : Adding PackageReference for package 'Newtonsoft.Json' into project 'C:\projects\ToDo\ToDo.csproj'.
log  : Restoring packages for C:\Temp\projects\consoleproj\consoleproj.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json 79ms
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/12.0.1/newtonsoft.json.12.0.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/12.0.1/newtonsoft.json.12.0.1.nupkg 232ms
log  : Installing Newtonsoft.Json 12.0.1.
info : Package 'Newtonsoft.Json' is compatible with all the specified frameworks in project 'C:\projects\ToDo\ToDo.csproj'.
info : PackageReference for package 'Newtonsoft.Json' version '12.0.1' added to file 'C:\projects\ToDo\ToDo.csproj'.
```

The *ToDo.csproj* file now contains a [`<PackageReference>`](/nuget/consume-packages/package-references-in-project-files) element for the referenced package.

```xml
<PackageReference Include="Newtonsoft.Json" Version="12.0.1" />
```

### Implicit restore

[!INCLUDE[DotNet Restore Note](../../../includes/dotnet-restore-note.md)]

## Arguments

- **`PROJECT`**

  Specifies the project file. If not specified, the command searches the current directory for one.

- **`PACKAGE_NAME`**

  The package reference to add.

## Options

<!-- markdownlint-disable MD012 -->

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

- Add `Newtonsoft.Json` NuGet package to a project:

  ```dotnetcli
  dotnet add package Newtonsoft.Json
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
