---
title: dotnet nuget verify command
description: The dotnet nuget verify command verifies a signed package.
author: kartheekp-ms
ms.date: 10/08/2020
---
# dotnet nuget verify

**This article applies to:** ✔️ .NET 5.0.100-rc.2.x SDK and later versions

## Name

`dotnet nuget verify` - Verifies a signed NuGet package.

## Synopsis

```dotnetcli
dotnet nuget verify [<package-path(s)>]
    [--all]
    [--certificate-fingerprint <FINGERPRINT>]
    [-v|--verbosity <LEVEL>]

dotnet nuget verify -h|--help
```

## Description

The `dotnet nuget verify` command verifies a signed NuGet package.

## Arguments

- **`package-path(s)`**

  Specifies the file path to the package(s) to be verified. Multiple position arguments can be passed in to verify multiple packages.

## Options

- **`--all`**

  Specifies that all verifications possible should be performed on the package(s). By default, only `signatures` are verified.

> [!NOTE]
> This command currently supports only `signature` verification. Additional quality checks shall be added in the future.

- **`--certificate-fingerprint <FINGERPRINT>`**

  Verify that the signer certificate matches with one of the specified `SHA256` fingerprints. This option can be supplied multiple times to provide multiple fingerprints.

* **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `normal`.

* **`-h|--help`**

  Prints out a short help for the command.

## Examples

- Verifies *foo.nupkg*:

  ```dotnetcli
  dotnet nuget verify foo.nupkg
  ```

- Verifies multiple NuGet packages *foo.nupkg* and *all .nupkg files in the directory specified*:

  ```dotnetcli
  dotnet nuget verify foo.nupkg c:\mydir\*.nupkg
  ```

- Verifies *foo.nupkg* signature matches with the specified certificate fingerprint:

  ```dotnetcli
  dotnet nuget verify foo.nupkg --certificate-fingerprint CE40881FF5F0AD3E58965DA20A9F571EF1651A56933748E1BF1C99E537C4E039
  ```
