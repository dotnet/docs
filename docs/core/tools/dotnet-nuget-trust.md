---
title: dotnet nuget trust command
description: The dotnet nuget trust command gets or sets trusted signers to the NuGet configuration.
author: erdembayar
ms.date: 06/02/2021
---
# dotnet nuget trust

**This article applies to:** ✔️ .NET 5.0.300 SDK and later versions

## Name

`dotnet nuget trust` - Gets or sets trusted signers to the NuGet configuration.

## Synopsis

```dotnetcli
dotnet nuget trust [command] [Options]

dotnet nuget trust -h|--help
```

## Description

The `dotnet nuget trust` command manages the trusted signers. By default, NuGet accepts all authors and repositories. These commands allow you to specify only a specific subset of signers whose signatures will be accepted, while rejecting all others. For more information, see [Common NuGet configurations](/nuget/consume-packages/configuring-nuget-behavior). For details on what the nuget.config schema looks like, refer to the [NuGet config file reference](/nuget/reference/nuget-config-file).

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

## Commands

If no command is specified, the command will default to `list`.

### `list`

Lists all the trusted signers in the configuration. This option will include all the certificates (with fingerprint and fingerprint algorithm) each signer has. If a certificate has a preceding [U], it means that certificate entry has allowUntrustedRoot set as true.

#### Synopsis:

```dotnetcli
dotnet nuget trust list [--configfile <PATH>] [-h|--help] [-v, --verbosity <LEVEL>]
```

#### Options:

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

### `sync`

Deletes the current list of certificates and replaces them with an up-to-date list from the repository.

#### Synopsis

```dotnetcli
dotnet nuget trust sync <NAME> [--configfile <PATH>] [-h|--help] [-v, --verbosity <LEVEL>]
```

#### Arguments

- **`NAME`**

  The name of the existing trusted signer to sync.

#### Options:

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

### `remove`

Removes any trusted signers that match the given name.

#### Synopsis

```dotnetcli
dotnet nuget trust remove <NAME> [--configfile <PATH>] [-h|--help] [-v, --verbosity <LEVEL>]
```

#### Arguments

- **`NAME`**

  The name of the existing trusted signer to remove.
  
#### Options:

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

### `author`

Adds a trusted signer with the given name, based on the author signature of the package.

#### Synopsis

```dotnetcli
dotnet nuget trust author <NAME> <PACKAGE> [--allow-untrusted-root] [--configfile <PATH>] [-h|--help] [-v, --verbosity <LEVEL>]
```

#### Arguments

- **`NAME`**

  The name of the trusted signer to add. If `NAME` already exists in the configuration, the signature is appended.

- **`PACKAGE`**

  The given `PACKAGE` should be a local path to the signed *.nupkg* file.
  
#### Options:

- **`--allow-untrusted-root`**

  Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root. This is not recommended.

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

### `repository`

Adds a trusted signer with the given name, based on the repository signature or countersignature of a signed package.

#### Synopsis

```dotnetcli
dotnet nuget trust repository <NAME> <PACKAGE> [--allow-untrusted-root] [--configfile <PATH>] [-h|--help] [--owners <LIST>] [-v, --verbosity <LEVEL>]
```

#### Arguments

- **`NAME`**

  The name of the trusted signer to add. If `NAME` already exists in the configuration, the signature is appended.

- **`PACKAGE`**

  The given `PACKAGE` should be a local path to the signed *.nupkg* file.

#### Options:

- **`--allow-untrusted-root`**

  Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root. This is not recommended.

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--owners <LIST>`**

  Semicolon-separated list of trusted owners to further restrict the trust of a repository.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

### `certificate`

Adds a trusted signer with the given name, based on a certificate fingerprint.

#### Synopsis

```dotnetcli
dotnet nuget trust certificate <NAME> <FINGERPRINT> [--algorithm <ALGORITHM>] [--allow-untrusted-root] [--configfile <PATH>] [-h|--help] [-v, --verbosity <LEVEL>]
```

#### Arguments

- **`NAME`**

  The name of the trusted signer to add. If a trusted signer with the given name already exists, the certificate item is added to that signer. Otherwise a trusted author is created with a certificate item from the given certificate information.

- **`FINGERPRINT`**

  The fingerprint of the certificate.

#### Options:

- **`--algorithm <ALGORITHM>`**

  Specifies the hash algorithm used to calculate the certificate fingerprint. Defaults to SHA256. Values supported are SHA256, SHA384 and SHA512.

- **`--allow-untrusted-root`**

  Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root. This is not recommended.

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

### `source`

Adds a trusted signer based on a given package source.

#### Synopsis

```dotnetcli
dotnet nuget trust source <NAME> [--configfile <PATH>] [-h|--help] [--owners <LIST>] [--source-url] [-v, --verbosity <LEVEL>]
```

#### Arguments

- **`NAME`**

  The name of the trusted signer to add. If only `<NAME>` is provided without `--<source-url>`, the package source from your NuGet configuration files with the same name is added to the trusted list. If `<NAME>` already exists in the configuration, the package source is appended to it.

#### Options:

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--owners <LIST>`**

  Semicolon-separated list of trusted owners to further restrict the trust of a repository.

- **`--source-url`**

  If a `source-url` is provided, it must be a v3 package source URL (like `https://api.nuget.org/v3/index.json`). Other package source types are not supported.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Examples

- List trusted signers:

  ```dotnetcli
  dotnet nuget trust list
  ```

- Trust source *NuGet* in specified *nuget.config* file:

  ```dotnetcli
  dotnet nuget trust source NuGet --configfile ..\nuget.config
  ```

- Trust an author from signed nupkg package file *foo.nupkg*:

  ```dotnetcli
  dotnet nuget trust author PackageAuthor .\foo.nupkg
  ```

- Trust a repository from signed nupkg package file *foo.nupkg*:

  ```dotnetcli
  dotnet nuget trust repository PackageRepository .\foo.nupkg
  ```

- Trust a package signing certificate using its SHA256 fingerprint:

  ```dotnetcli
    dotnet nuget trust certificate MyCert  F99EC8CDCE5642B380296A19E22FA8EB3AEF1C70079541A2B3D6E4A93F5E1AFD --algorithm SHA256
  ```

- Trust owners *Nuget* and *Microsoft* from the repository `https://api.nuget.org/v3/index.json`:

  ```dotnetcli
    dotnet nuget trust source NuGetTrust https://api.nuget.org/v3/index.json --owners "Nuget;Microsoft"
  ```

- Remove trusted signer named *NuGet* from  specified *nuget.config* file:

  ```dotnetcli
    dotnet nuget trust remove NuGet --configfile ..\nuget.config
  ```
