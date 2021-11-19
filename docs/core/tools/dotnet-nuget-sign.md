---
title: dotnet nuget sign command
description: The dotnet nuget sign command signs all the packages matching the first argument with a certificate.
author: heng-liu
ms.date: 07/07/2021
---
# dotnet nuget sign

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet nuget sign` - Signs all the NuGet packages matching the first argument with a certificate.

## Synopsis

```dotnetcli
dotnet nuget sign [<package-path(s)>]
    [--certificate-path <PATH>]
    [--certificate-store-name <STORENAME>]
    [--certificate-store-location <STORELOCATION>]
    [--certificate-subject-name <SUBJECTNAME>]
    [--certificate-fingerprint <FINGERPRINT>]
    [--certificate-password <PASSWORD>]
    [--hash-algorithm <HASHALGORITHM>]
    [-o|--output <OUTPUT DIRECTORY>]
    [--overwrite]
    [--timestamp-hash-algorithm <HASHALGORITHM>]
    [--timestamper <TIMESTAMPINGSERVER>]
    [-v|--verbosity <LEVEL>]

dotnet nuget sign -h|--help
```

## Description

The `dotnet nuget sign` command signs all the packages matching the first argument with a certificate. The certificate with the private key can be obtained from a file or from a certificate installed in a certificate store by providing a subject name or a SHA-1 fingerprint.

## Arguments

- **`package-path(s)`**

  Specifies the file path to the package(s) to be signed. Multiple arguments can be passed in to sign multiple packages.

## Options

<!-- markdownlint-disable MD012 -->

- **`--certificate-path <PATH>`**

  Specifies the file path to the certificate to be used in signing the package.

  > [!NOTE]
  > This option currently supports only `PKCS12 (PFX)` files that contain the certificate's private key.

- **`--certificate-store-name <STORENAME>`**

  Specifies the name of the X.509 certificate store to use to search for the certificate. Defaults to :::no-loc text="\"My\"":::, the X.509 certificate store for personal certificates. This option should be used when specifying the certificate via `--certificate-subject-name` or `--certificate-fingerprint` options.

- **`--certificate-store-location <STORELOCATION>`**

  Specifies the name of the X.509 certificate store use to search for the certificate. Defaults to :::no-loc text="\"CurrentUser\"":::, the X.509 certificate store used by the current user. This option should be used when specifying the certificate via `--certificate-subject-name` or `--certificate-fingerprint` options.

- **`--certificate-subject-name <SUBJECTNAME>`**

  Specifies the subject name of the certificate used to search a local certificate store for the certificate. The search is a case-insensitive string comparison using the supplied value, which will find all certificates with the subject name containing that string, regardless of other subject values. The certificate store can be specified by `--certificate-store-name` and `--certificate-store-location` options.

  > [!NOTE]
  > This option currently supports only a single matching certificate in the result. If there are multiple matching certificates in the result, or no matching certificate in the result, the sign command will fail.

- **`--certificate-fingerprint <FINGERPRINT>`**

   SHA-1 fingerprint of the certificate used to search a local certificate store for the certificate.

- **`--certificate-password <PASSWORD>`**

   Specifies the certificate password, if needed. If a certificate is password protected but no password is provided, the sign command will fail.

  > [!NOTE]
  > The `sign` command only supports non-interactive mode. There won't be any prompt for a password at run time.

- **`--hash-algorithm <HASHALGORITHM>`**

   Hash algorithm to be used to sign the package. Defaults to SHA256. Possible values are SHA256, SHA384, and SHA512.

- **`-o|--output`**

  Specifies the directory where the signed package should be saved. If this option is not specified, by default the original package is overwritten by the signed package.

- **`--overwrite`**

   Indicate that the current signature should be overwritten. By default the command will fail if the package already has a signature.

- **`--timestamp-hash-algorithm <HASHALGORITHM>`**

   Hash algorithm to be used by the RFC 3161 timestamp server. Defaults to SHA256.

- **`--timestamper <TIMESTAMPINGSERVER>`**

   URL to an RFC 3161 timestamping server.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Sign *foo.nupkg* with certificate *cert.pfx* (not password protected):

  ```dotnetcli
  dotnet nuget sign foo.nupkg --certificate-path cert.pfx
  ```

- Sign *foo.nupkg* with certificate *cert.pfx* (password protected):

  ```dotnetcli
  dotnet nuget sign foo.nupkg --certificate-path cert.pfx --certificate-password password
  ```

- Sign *foo.nupkg* with certificate (password protected) matches with the specified SHA-1 fingerprint in the default certificate store (CurrentUser\My):

  ```dotnetcli
  dotnet nuget sign foo.nupkg --certificate-fingerprint 89967D1DD995010B6C66AE24FF8E66885E6E03A8 --certificate-password password
  ```

- Sign *foo.nupkg* with certificate (password protected) matches with the specified subject name :::no-loc text="\"Test certificate for testing signing\""::: in the default certificate store (CurrentUser\My):

  ```dotnetcli
  dotnet nuget sign foo.nupkg --certificate-subject-name "Test certificate for testing signing" --certificate-password password
  ```

- Sign *foo.nupkg* with certificate (password protected) matches with the specified SHA-1 fingerprint in the certificate store CurrentUser\Root:

  ```dotnetcli
  dotnet nuget sign foo.nupkg --certificate-fingerprint 89967D1DD995010B6C66AE24FF8E66885E6E03A8 --certificate-password password --certificate-store-location CurrentUser --certificate-store-name Root
  ```

- Sign multiple NuGet packages - *foo.nupkg* and *all .nupkg files in the directory specified* with certificate *cert.pfx* (not password protected):

  ```dotnetcli
  dotnet nuget sign foo.nupkg c:\mydir\*.nupkg --certificate-path cert.pfx
  ```

- Sign *foo.nupkg* with certificate *cert.pfx* (password protected), and timestamp with `http://timestamp.test`:

  ```dotnetcli
  dotnet nuget sign foo.nupkg --certificate-path cert.pfx --certificate-password password --timestamper http://timestamp.test
  ```

- Sign *foo.nupkg* with certificate *cert.pfx* (not password protected) and save the signed package under specified directory:

  ```dotnetcli
  dotnet nuget sign foo.nupkg --certificate-path cert.pfx --output c:\signed\
  ```

- Sign *foo.nupkg* with certificate *cert.pfx* (not password protected) and overwrite the current signature if the package is already signed:

  ```dotnetcli
  dotnet nuget sign foo.nupkg --certificate-path cert.pfx --overwrite
  ```
