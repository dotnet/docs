---
title: dotnet nuget trust command
description: The dotnet nuget trust command gets or sets trusted signers to the NuGet configuration.
author: erdembayar
ms.date: 06/02/2021
---
# dotnet nuget trust

**This article applies to:** ✔️ .NET 5.0.300 SDK, 6.0.100-preview.4 SDK and later versions

## Name

`dotnet nuget trust` - Gets or sets trusted signers to the NuGet configuration.

## Synopsis

```dotnetcli
dotnet nuget trust [list|author|repository|source|certificate|remove|sync] [OPTIONS]

if none of list|add|remove|sync is specified, the command will default to list.

dotnet nuget trust -h|--help
```

## Description

The `dotnet nuget trust` gets or sets trusted signers to the NuGet configuration. For additional usage, see [Common NuGet configurations](../../consume-packages/configuring-nuget-behavior.md). For details on how the nuget.config schema looks like, refer to the [NuGet config file reference](../nuget-config-file.md).

## Arguments

- `<list|author|repository|source|certificate|remove|sync>`

  Specifies the command for gets or sets trusted signers to the NuGet configuration. 

#### `> dotnet nuget trust list`

```
Lists all the trusted signers in the configuration. This option will include all the certificates (with fingerprint and fingerprint algorithm) each signer has. If a certificate has a preceding [U], it means that certificate entry has allowUntrustedRoot set as true.

USAGE:
    dotnet nuget trust list [OPTIONS]

OPTIONS:
    -h, --help                          Prints out a short help for the command.
    -v, --verbosity <LEVEL>             Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].
        --configfile                    Specific NuGet file that should be used instead of the standard hierarchy.
```

#### `> dotnet nuget trust sync`

```
Deletes the current list of certificates and replaces them with an up-to-date list from the repository.

USAGE:
    dotnet nuget trust sync [OPTIONS] <name>

OPTIONS:
    -h, --help                          Prints out a short help for the command.
    -v, --verbosity <LEVEL>             Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].
        --configfile                    Specific NuGet file that should be used instead of the standard hierarchy.
```

#### `> dotnet nuget trust remove`

```
Removes any trusted signers that match the given name.

USAGE:
    dotnet nuget trust remove [OPTIONS] <name>

OPTIONS:
    -h, --help                          Prints out a short help for the command.
    -v, --verbosity <LEVEL>             Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].
        --configfile                    Specific NuGet file that should be used instead of the standard hierarchy.
```

#### `> dotnet nuget trust author`

```
Adds a trusted signer with the given name, based on the author signature(s) of one or more packages. If <name> already exists in the configuration, the signature(s) will be appended. The given a <package> should be local paths to signed .nupkg files.

USAGE:
    dotnet nuget trust author [OPTIONS] <name> <package>...

EXAMPLE:
    dotnet nuget trust author Contoso ./contoso.library.nupkg

OPTIONS:
        --allow-untrusted-root          Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root.
    -h, --help                          Prints out a short help for the command.
    -v, --verbosity <LEVEL>             Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].
        --configfile                    Specific NuGet file that should be used instead of the standard hierarchy.
```

#### `> dotnet nuget trust repository`

```
Adds a trusted signer with the given name, based on the repository signature(s) or countersignature(s) of one or more packages. If <name> already exists in the configuration, the signature(s) will be appended. The given a <package> should be local paths to signed .nupkg files.

USAGE:
    dotnet nuget trust repository [OPTIONS] <name> <package>...

OPTIONS:
        --allow-untrusted-root          Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root. This is not recommended.
        --owners                        Semi-colon separated list of trusted owners to further restrict the trust of a repository.
    -h, --help                          Prints out a short help for the command.
    -v, --verbosity <LEVEL>             Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].
        --configfile                    Specific NuGet file that should be used instead of the standard hierarchy.
```

#### `> dotnet nuget trust certificate`

```
Adds a trusted signer with the given name, based on a certificate fingerprint.

If a trusted signer with the given name already exists, the certificate item will be added to that signer. Otherwise a trusted author will be created with a certificate item from given certificate information.

USAGE:
    dotnet nuget trust certificate [OPTIONS] <name> <fingerprint>

OPTIONS:
        --allow-untrusted-root          Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root.
        --algorithm                     Specifies the hash algorithm used to calculate the certificate fingerprint. Defaults to SHA256. Values supported are SHA256, SHA384 and SHA512
    -h, --help                          Prints out a short help for the command.
    -v, --verbosity <LEVEL>             Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].
        --configfile                    Specific NuGet file that should be used instead of the standard hierarchy.
```

#### `> dotnet nuget trust source`

```
Adds a trusted signer based on a given package source.

If only `<name>` is provided without `<source-url>`, the package source from your NuGet configuration files with the same name will be added to the trusted list.

If a `<source-url>` is provided, it MUST be a v3 package source URL (like https://api.nuget.org/v3/index.json). Other package source types are not supported.

If <name> already exists in the configuration, the package source will be appended to it.

USAGE:
    dotnet nuget trust source <name> [source-url]

OPTIONS:
        --allow-untrusted-root          Specifies if the certificate for the trusted signer should be allowed to chain to an untrusted root.
        --owners                        Semi-colon separated list of trusted owners to further restrict the trust of a repository.
    -h, --help                          Prints out a short help for the command.
    -v, --verbosity <LEVEL>             Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].
        --configfile                    Specific NuGet file that should be used instead of the standard hierarchy.
```

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

- Trust owners *Nuget* and *Microsoft* from the repository *https://api.nuget.org/v3/index.json*:

  ```dotnetcli
    dotnet nuget trust source NuGetTrust https://api.nuget.org/v3/index.json --owners "Nuget;Microsoft"
  ```

- Removes trusted signer named *NuGet* from  specified *nuget.config* file:

  ```dotnetcli
    dotnet nuget trust remove NuGet --configfile ..\nuget.config
  ```