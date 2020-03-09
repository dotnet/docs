# dotnet nuget add source
---
title: dotnet nuget add source command
description: The `dotnet nuget add source` command adds a new package source to your NuGet configuration files. 
author: nugetClient
ms.date: 03/09/2020
---

**This article applies to:** ✔️ .NET Core 3.1.200 SDK and later versions

## Name

`dotnet nuget add source` - Add a NuGet source.

## Synopsis

```dotnetcli
`dotnet nuget add source PACKAGESOURCEPATH [--name] [--username] [--password] [--store-password-in-clear-text] [--valid-authentication-types] [--configfile]`
`dotnet nuget add source [-h|--help]`
```

## Description

The `dotnet nuget add source` command adds a new package source to your NuGet configuration files. 

## Arguments

- **`PACKAGESOURCEPATH`**

  Path to the package(s) source.

## Options

- **`-n|--name`**

  Name of the source.

- **`-u|--username`**

  Username to be used when connecting to an authenticated source.

- **`-p|--password`**

  Password to be used when connecting to an authenticated source.

- **`--store-password-in-clear-text`**

  Enables storing portable package source credentials by disabling password encryption.

- **`--valid-authentication-types`**

  Comma-separated list of valid authentication types for this source. By default, all authentication types are valid. Example: basic,negotiate

- **`--configfile`**

  The NuGet configuration file. If specified, only the settings from this file will be used. If not specified, the hierarchy of configuration files from the current directory will be used. To learn more about NuGet configuration go to https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior.

## Examples

- Add `nuget.org` as a source:

  ```dotnetcli
  dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
  ```

- Add `c:\packages` as a local source:

  ```dotnetcli
  dotnet nuget add source c:\packages
  ```

- Add a source that needs authentication:

  ```dotnetcli
  dotnet nuget add source https://someServer/myTeam -n myTeam -u myUsername -p myPassword --store-password-in-clear-text
  ```

- Add a source that needs authentication (then go install credential provider):

  ```dotnetcli
  dotnet nuget add source https://azureartifacts.microsoft.com/myTeam -n myTeam
  ```

## See also

- [Package source sections in NuGet.config files](/nuget/reference/nuget-config-file#package-source-sections)

- [sources command (nuget.exe)](/nuget/reference/cli-reference/cli-ref-sources)
