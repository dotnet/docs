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
dotnet nuget trust [command] [OPTIONS]

dotnet nuget trust -h|--help
```

## Description

The `dotnet nuget trust` manage the trusted signers. By default, NuGet accepts all authors and repositories. These commands allow you to specify only a specific subset of signers whose signatures will be accepted, while rejecting all others. For additional usage, see [Common NuGet configurations](../../../nuget/consume-packages/configuring-nuget-behavior.md). For details on how the nuget.config schema looks like, refer to the [NuGet config file reference](../../../nuget/reference/nuget-config-file.md).

## Options

- **`-h|--help`**

  Prints out a description of how to use the command.

## Commands

If no command is specified, the command will default to `list`.

### `list`

Lists all the trusted signers in the configuration. This option will include all the certificates (with fingerprint and fingerprint algorithm) each signer has. If a certificate has a preceding [U], it means that certificate entry has allowUntrustedRoot set as true.

#### Synopsis:

```dotnetcli
dotnet nuget trust list [OPTIONS]
```

#### OPTIONS:

- **`-h|--help`**

  Prints out a description of how to use the command.

- **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

- **`--configfile <PATH>`**

  Specific NuGet file that should be used instead of the standard hierarchy.

### `sync`

Deletes the current list of certificates and replaces them with an up-to-date list from the repository.

#### Synopsis

```dotnetcli
dotnet nuget trust sync <name> [OPTIONS]
```

#### Arguments

- **`name`**

  The name of existing trusted signer going be synced.

#### OPTIONS:

- **`-h|--help`**

  Prints out a description of how to use the command.

- **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

- **`--configfile <PATH>`**

  Specific NuGet file that should be used instead of the standard hierarchy.

### `remove`

Removes any trusted signers that match the given name.

#### Synopsis

```dotnetcli
dotnet nuget trust remove <name> [OPTIONS]
```

#### Arguments

- **`name`**

  The name of existing trusted signer going be removed.
  
#### OPTIONS:

- **`-h|--help`**

  Prints out a description of how to use the command.

- **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

- **`--configfile <PATH>`**

  Specific NuGet file that should be used instead of the standard hierarchy.

### `author`

Adds a trusted signer with the given name, based on the author signature of the package.

#### Synopsis

```dotnetcli
dotnet nuget trust author <name> <package> [OPTIONS]
```

#### Arguments

- **`name`**

  The name of existing trusted signer going be added. If `name` already exists in the configuration, the signature will be appended.

- **`package`**

  The given `package` should be local path to the signed .nupkg file.
  
#### OPTIONS:

- **`--allow-untrusted-root`**

  Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root. This is not recommended.

- **`-h|--help`**

  Prints out a description of how to use the command.

- **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

- **`--configfile <PATH>`**

  Specific NuGet file that should be used instead of the standard hierarchy.

### `repository`

Adds a trusted signer with the given name, based on the repository signature or countersignature of a signed package.

#### Synopsis

```dotnetcli
dotnet nuget trust repository <name> <package> [OPTIONS]
```

#### Arguments

- **`name`**

  The name of existing trusted signer going be added. If `name` already exists in the configuration, the signature will be appended.

- **`package`**

  The given `package` should be local path to the signed .nupkg file.

#### OPTIONS:

- **`--allow-untrusted-root`**

  Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root. This is not recommended.

- **`-h|--help`**

  Prints out a description of how to use the command.

- **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

- **`--configfile <PATH>`**

  Specific NuGet file that should be used instead of the standard hierarchy.

### `certificate`

Adds a trusted signer with the given name, based on a certificate fingerprint.

#### Synopsis

```dotnetcli
dotnet nuget trust certificate <name> <fingerprint> [OPTIONS]
```

#### Arguments

- **`name`**

  The name of existing trusted signer going be added. If a trusted signer with the given name already exists, the certificate item will be added to that signer. Otherwise a trusted author will be created with a certificate item from given certificate information.

- **`<fingerprint>`**

  The fingerprint of the certificate.

#### OPTIONS:

- **`--allow-untrusted-root`**

  Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root. This is not recommended.

- **`--algorithm <ALGORITHM>`**

  Specifies the hash algorithm used to calculate the certificate fingerprint. Defaults to SHA256. Values supported are SHA256, SHA384 and SHA512.
  
- **`-h|--help`**

  Prints out a description of how to use the command.

- **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

- **`--configfile <PATH>`**

  Specific NuGet file that should be used instead of the standard hierarchy.

### `source`

Adds a trusted signer based on a given package source.

#### Synopsis

```dotnetcli
dotnet nuget trust source <name> [source-url] [--owners <List>] [OPTIONS]
```

#### Arguments

- **`name`**

  The name of existing trusted signer going be added. If only `<name>` is provided without `<source-url>`, the package source from your NuGet configuration files with the same name will be added to the trusted list. If `<name>` already exists in the configuration, the package source will be appended to it.

#### OPTIONS:

- **`--owners <List>`**

  Semi-colon separated list of trusted owners to further restrict the trust of a repository.

- **`source-url`**

  If a `source-url` is provided, it MUST be a v3 package source URL (like <https://api.nuget.org/v3/index.json>). Other package source types are not supported.

- **`-h|--help`**

  Prints out a description of how to use the command.

- **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

- **`--configfile`**

  Specific NuGet file that should be used instead of the standard hierarchy.

## Examples

- List trusted signers:

  ```dotnetcli
  dotnet nuget trust list
  ```

- Trust source *NuGet* in specified *nuget.config* file:

  ```dotnetcli
  dotnet nuget trust source NuGet --configfile ..\nuget.config
  ```

- Trust an author from signed nupkg package file *foo.nupkg* with *--allow-untrusted-root* option:

  ```dotnetcli
  dotnet nuget trust author PackageAuthor .\foo.nupkg --allow-untrusted-root
  ```

- Trust a repository from signed nupkg package file *foo.nupkg*:

  ```dotnetcli
  dotnet nuget trust repository PackageRepository .\foo.nupkg
  ```

- Trust a package signing certificate using it's SHA256 fingerprint:

  ```dotnetcli
    dotnet nuget trust certificate MyCert  F99EC8CDCE5642B380296A19E22FA8EB3AEF1C70079541A2B3D6E4A93F5E1AFD --algorithm SHA256
  ```

- Trust owners *Nuget* and *Microsoft* from the repository <https://api.nuget.org/v3/index.json>:

  ```dotnetcli
    dotnet nuget trust source NuGetTrust https://api.nuget.org/v3/index.json --owners "Nuget;Microsoft"
  ```

- Removes trusted signer named *NuGet* from  specified *nuget.config* file:

  ```dotnetcli
    dotnet nuget trust remove NuGet --configfile ..\nuget.config
  ```
