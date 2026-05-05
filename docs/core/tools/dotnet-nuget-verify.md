---
title: dotnet nuget verify command
description: The dotnet nuget verify command verifies a signed package.
author: kartheekp-ms
ms.date: 10/28/2025
---
# dotnet nuget verify

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet nuget verify` - Verifies a signed NuGet package.

## Synopsis

```dotnetcli
dotnet nuget verify [<package-path(s)>]
    [--all]
    [--certificate-fingerprint <FINGERPRINT>]
    [-v|--verbosity <LEVEL>]
    [--configfile <FILE>]

dotnet nuget verify -h|--help
```

## Description

The `dotnet nuget verify` command verifies a signed NuGet package.
In .NET 10 and later versions, the command also outputs:

- The package's content hash, which might be useful to investigate lock file validation errors.
- The Certificate Revocation List (CRL) and Online Certificate Status Protocol (OCSP) URLs for each certificate in the signature chain. For more information, see the [breaking change notice](../compatibility/sdk/10.0/dotnet-nuget-verify-crl-ocsp-urls.md).

  > [!NOTE]
  > This command requires a certificate root store that is valid for both code signing and timestamping. Also, this command may not be supported on some combinations of operating system and .NET SDK. For more information, see [NuGet signed package verification](nuget-signed-package-verification.md).

## Arguments

- **`package-path(s)`**

  Specifies the file path to the package(s) to be verified. Multiple position arguments can be passed in to verify multiple packages.

## Options

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
  `Timestamp Certificate -> CRL URL (If applicable)`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Timestamp Certificate -> OCSP URL (If applicable)`| ❌       | ❌          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> Subject name`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> SHA-256 hash`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> Validity period`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> Service index URL (If applicable)`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> CRL URL (If applicable)`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Author/Repository Certificate -> OCSP URL (If applicable)`| ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Package name being verified`                    | ❌       | ✔️          | ✔️         | ✔️         | ✔️
  `Type of signature (author or repository)`| ❌       | ✔️          | ✔️         | ✔️         | ✔️

  ❌ indicates details that are **not** displayed. ✔️ indicates details that are displayed.

- [!INCLUDE [configfile](includes/cli-configfile.md)]

- [!INCLUDE [help](includes/cli-help.md)]

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

- Verify the signature of *foo.nupkg* by using settings (`packagesources` and `trustedSigners`) only from the specified *nuget.config* file:

  ```dotnetcli
  dotnet nuget verify foo.nupkg --configfile ..\Settings\nuget.config
  ```
