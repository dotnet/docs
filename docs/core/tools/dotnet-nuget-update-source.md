---
title: dotnet nuget update source command
description: The dotnet nuget update source command updates an existing source in your NuGet configuration files. 
ms.date: 11/03/2026
ai-usage: ai-assisted
---
# dotnet nuget update source

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet nuget update source` - Update a NuGet source.

> [!NOTE]
> Use package sources that you trust.

## Synopsis

```dotnetcli
dotnet nuget update source <NAME> [--source <SOURCE>] [--username <USER>]
    [--password <PASSWORD>] [--store-password-in-clear-text]
    [--valid-authentication-types <TYPES>] [--configfile <FILE>]
    [--min-publish-age-hours <HOURS>]

dotnet nuget update source -h|--help
```

## Description

The `dotnet nuget update source` command updates an existing source in your NuGet configuration files.

## Arguments

- **`NAME`**

  Name of the source.

## Options

- [!INCLUDE [configfile](includes/cli-configfile.md)]

- **`--min-publish-age-hours <HOURS>`**

  Sets the minimum package publish age for this source in nonnegative whole hours. When `dotnet package add` or `dotnet package update` automatically selects a version, it excludes versions from this source that haven't reached the minimum age, unless the package matches a configured exception. Sets the `minPublishAgeHours` attribute in *nuget.config*. Set the option to `0` to remove the source's minimum age. If you omit the option, the existing value stays unchanged. Available starting with .NET SDK 11.0.100.

  For package-selection behavior, exceptions, and restore limitations, see [Minimum package publish age](/nuget/consume-packages/minimum-package-publish-age).

- **`-p|--password <PASSWORD>`**

  Password to be used when connecting to an authenticated source.

> [!NOTE]
> Be aware that encrypted passwords are only supported on Windows.
> Moreover, they can only be decrypted on the same machine and by the same user who originally encrypted them.

- **`-s|--source <SOURCE>`**

  Path to the package source.

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

- Update a source with name of `mySource`:

  ```dotnetcli
  dotnet nuget update source mySource --source c:\packages
  ```

- Set a 72-hour minimum package publish age for `nuget.org`:

  ```dotnetcli
  dotnet nuget update source nuget.org --min-publish-age-hours 72
  ```

- Remove the minimum package publish age for `nuget.org`:

  ```dotnetcli
  dotnet nuget update source nuget.org --min-publish-age-hours 0
  ```

## See also

- [Security best practices for managing package source credentials](/nuget/consume-packages/consuming-packages-authenticated-feeds#security-best-practices-for-managing-credentials)

- [Package source sections in NuGet.config files](/nuget/reference/nuget-config-file#package-source-sections)

- [sources command (nuget.exe)](/nuget/reference/cli-reference/cli-ref-sources)
