---
title: dotnet nuget add source command
description: The dotnet nuget add source command adds a new package source to your NuGet configuration files. 
ms.date: 03/20/2020
---
# dotnet nuget add source

**This article applies to:** ✔️ .NET Core 3.1.200 SDK and later versions

## Name

`dotnet nuget add source` - Add a NuGet source.

> [!NOTE]
> Use package sources that you trust.

## Synopsis

```dotnetcli
dotnet nuget add source <PACKAGE_SOURCE_PATH> [--name <SOURCE_NAME>] [--username <USER>]
    [--password <PASSWORD>] [--store-password-in-clear-text]
    [--valid-authentication-types <TYPES>] [--configfile <FILE>] [--allow-insecure-connections]

dotnet nuget add source -h|--help
```

## Description

The `dotnet nuget add source` command adds a new package source to your NuGet configuration files.

> [!WARNING]
> When adding multiple package sources, be careful not to introduce a [dependency confusion vulnerability](/nuget/concepts/security-best-practices#nuget-feeds).

## Arguments

- **`PACKAGE_SOURCE_PATH`**

  Path to the package source.

## Options

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

- **`--allow-insecure-connections`**
  
  Allows HTTP connections for adding or updating packages. This method is not secure. Available since .NET 9 SDK.
  
- **`-n|--name <SOURCE_NAME>`**

  Name of the source.

- **`-p|--password <PASSWORD>`**

  Password to be used when connecting to an authenticated source.

> [!NOTE]
> Be aware that encrypted passwords are only supported on Windows.
> Moreover, they can only be decrypted on the same machine and by the same user who originally encrypted them.

- **`--store-password-in-clear-text`**

  Enables storing portable package source credentials by disabling password encryption.

> [!WARNING]
> Storing passwords in clear text is strongly discouraged.
> For more information on managing credentials securely, refer to the [security best practices for consuming packages from private feeds](/nuget/consume-packages/consuming-packages-authenticated-feeds#security-best-practices-for-managing-credentials).

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
  dotnet nuget add source https://someServer/myTeam -n myTeam -u myUsername -p myPassword
  ```

- Add a source that needs authentication (then go install credential provider):

  ```dotnetcli
  dotnet nuget add source https://azureartifacts.microsoft.com/myTeam -n myTeam
  ```

## See also

- [Security best practices for managing package source credentials](/nuget/consume-packages/consuming-packages-authenticated-feeds#security-best-practices-for-managing-credentials)

- [Package source sections in NuGet.config files](/nuget/reference/nuget-config-file#package-source-sections)

- [sources command (nuget.exe)](/nuget/reference/cli-reference/cli-ref-sources)
