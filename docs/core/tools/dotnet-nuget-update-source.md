---
title: dotnet nuget update source command
description: The `dotnet nuget update source` command updates an existing source in your NuGet configuration files. 
author: nugetClient
ms.date: 03/09/2020
---
# dotnet nuget update source

**This article applies to:** ✔️ .NET Core 3.1.200 SDK and later versions

## Name

`dotnet nuget update source` - Update a NuGet source.

## Synopsis

```dotnetcli
`dotnet nuget update source NAME [--source] [--username] [--password] [--store-password-in-clear-text] [--valid-authentication-types] [--configfile]`
`dotnet nuget update source [-h|--help]`
```

## Description

The `dotnet nuget update source` command updates an existing source in your NuGet configuration files. 

## Arguments

- **`NAME`**

  Name of the source.


## Options

- **`-s|--source`**

  Path to the package(s) source.

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

- Update a source with name of `mySource`:

  ```dotnetcli
  dotnet nuget update source mySource --source c:\packages
  ```

## See also

- [Package source sections in NuGet.config files](/nuget/reference/nuget-config-file#package-source-sections)

- [sources command (nuget.exe)](/nuget/reference/cli-reference/cli-ref-sources)
