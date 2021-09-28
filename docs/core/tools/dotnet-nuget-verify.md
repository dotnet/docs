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

<!-- markdownlint-disable MD012 -->

- **`--all`**

  Specifies that all verifications possible should be performed on the package(s). By default, only `signatures` are verified.

> [!NOTE]
> This command currently supports only `signature` verification.

- **`--certificate-fingerprint <FINGERPRINT>`**

  Verify that the signer certificate matches with one of the specified `SHA256` fingerprints. This option can be supplied multiple times to provide multiple fingerprints.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`. For more information, see <xref:Microsoft.Build.Framework.LoggerVerbosity>.

  The following table shows what is displayed for each verbosity level.

  ​                                  | `q[uiet]` | `m[inimal]` | `n[ormal]` | `d[etailed]` | `diag[nostic]`
  ----------------------------------| --------- | ----------- | ---------- | -----------| --------------
  `Certificate chain Information`   | ❌       | ❌          | ❌         | ✔️         | ✔️
  `Path to package being verified`  | ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Hashing algorithm used for signature`        | ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> SHA1 hash`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> Issued By`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Timestamp Certificate -> Issued By`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Timestamp Certificate -> SHA-256 hash`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Timestamp Certificate -> Validity period`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Timestamp Certificate -> SHA1 hash`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Timestamp Certificate -> Subject name`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> Subject name`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> SHA-256 hash`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> Validity period`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> Service index URL (If applicable)`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Package name being verified`                    | ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Type of signature (author or repository)`| ❌       | ✔️          | ✔️         | ✔️         | ✔️

  ❌ indicates details that are **not** displayed. ✔️ indicates details that are displayed.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Verify *foo.nupkg*:

  ```dotnetcli
  dotnet nuget verify foo.nupkg
  ```

- Verify multiple NuGet packages - *foo.nupkg* and *all .nupkg files in the directory specified*:

  ```dotnetcli
  dotnet nuget verify foo.nupkg c:\mydir\*.nupkg
  ```

- Verify *foo.nupkg* signature matches with the specified certificate fingerprint:

  ```dotnetcli
  dotnet nuget verify foo.nupkg --certificate-fingerprint CE40881FF5F0AD3E58965DA20A9F571EF1651A56933748E1BF1C99E537C4E039
  ```

- Verify *foo.nupkg* signature matches with one of the specified certificate fingerprints:

  ```dotnetcli
  dotnet nuget verify foo.nupkg --certificate-fingerprint CE40881FF5F0AD3E58965DA20A9F571EF1651A56933748E1BF1C99E537C4E039 --certificate-fingerprint EC10992GG5F0AD3E58965DA20A9F571EF1651A56933748E1BF1C99E537C4E027
  ```
