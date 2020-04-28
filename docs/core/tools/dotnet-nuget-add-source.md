---
title: dotnet nuget add source command
description: The dotnet nuget add source command adds a new package source to your NuGet configuration files. 
ms.date: 03/20/2020
---
# dotnet nuget add source

**This article applies to:** ✔️ .NET Core 3.1.200 SDK and later versions

## Name

`dotnet nuget add source` - Add a NuGet source.

## Synopsis

```dotnetcli
dotnet nuget add source <PACKAGE_SOURCE_PATH> [--name <SOURCE_NAME>] [--username <USER>]
    [--password <PASSWORD>] [--store-password-in-clear-text]
    [--valid-authentication-types <TYPES>] [--configfile <FILE>]

dotnet nuget add source -h|--help
```

## Description

The `dotnet nuget add source` command adds a new package source to your NuGet configuration files.

## Arguments

- **`PACKAGE_SOURCE_PATH`**

  Path to the package source.

## Options

- **`--configfile <FILE>`**

  The NuGet configuration file. If specified, only the settings from this file will be used. If not specified, the hierarchy of configuration files from the current directory will be used. For more information, see [Common NuGet Configurations](https://docs.microsoft.com/nuget/consume-packages/configuring-nuget-behavior).

- **`-n|--name <SOURCE_NAME>`**

  Name of the source.

- **`-p|--password <PASSWORD>`**

  Password to be used when connecting to an authenticated source.

- **`--store-password-in-clear-text`**

  Enables storing portable package source credentials by disabling password encryption.

- **`-u|--username <USER>`**

  Username to be used when connecting to an authenticated source.

- **`--valid-authentication-types <TYPES>`**

  Comma-separated list of valid authentication types for this source. Set this to `basic` if the server advertises NTLM or Negotiate and your credentials must be sent using the Basic mechanism, for instance when using a PAT with on-premises Azure DevOps Server. Other valid values include `negotiate`, `kerberos`, `ntlm`, and `digest`, but these values are unlikely to be useful.

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
