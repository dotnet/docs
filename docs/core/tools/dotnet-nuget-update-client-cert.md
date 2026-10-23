---
title: dotnet nuget update client-cert command
description: The dotnet nuget update client-cert command updates the HTTPS client certificate configuration for a NuGet package source.
ms.date: 10/23/2026
ai-usage: ai-generated
---
# dotnet nuget update client-cert

**This article applies to:** ✔️ .NET Core 3.1.400 SDK and later versions

## Name

`dotnet nuget update client-cert` - Update a client certificate configuration for a NuGet package source.

## Synopsis

```dotnetcli
dotnet nuget update client-cert --package-source <SOURCE_NAME>
    [--path <CERTIFICATE_PATH>] [--password <PASSWORD>]
    [--store-password-in-clear-text] [--configfile <FILE>] [-f|--force]

dotnet nuget update client-cert --package-source <SOURCE_NAME>
    [--find-value <VALUE>] [--find-by <FIND_TYPE>]
    [--store-location <LOCATION>] [--store-name <STORE_NAME>]
    [--configfile <FILE>] [-f|--force]

dotnet nuget update client-cert -h|--help
```

## Description

The `dotnet nuget update client-cert` command updates the client certificate configuration that matches a package source name. The configuration must already exist. To add a configuration, use [dotnet nuget add client-cert](dotnet-nuget-add-client-cert.md).

Specify at least one setting for the existing certificate source type:

- **File:** Specify `--path`, `--password`, or both.
- **Certificate store:** Specify one or more of `--store-location`, `--store-name`, `--find-by`, and `--find-value`.

Settings you omit retain their existing values. For example, to replace a certificate file that uses the same password, specify only `--path`. To change how a password is stored, supply the password again with `--password`; `--store-password-in-clear-text` alone doesn't update the configuration.

Don't combine file options with store options. You can't change a file configuration to a store configuration, or a store configuration to a file configuration. To change the certificate source type, [remove the configuration](dotnet-nuget-remove-client-cert.md), and then [add a new configuration](dotnet-nuget-add-client-cert.md).

Unless you specify `--force`, NuGet checks that it can find and load the certificate before it saves the configuration. The command doesn't test authentication with the package source.

## Options

- [!INCLUDE [configfile](includes/cli-configfile.md)]

- **`--find-by <FIND_TYPE>`**

  The certificate store search method. Values are case-insensitive. Use an X.509 find type **without** the `FindBy` prefix. For example, use `Thumbprint` or `SubjectName`, not `FindByThumbprint` or `FindBySubjectName`. For all accepted values, see the [add command's `--find-by` option](dotnet-nuget-add-client-cert.md#options).

- **`--find-value <VALUE>`**

  The value to search for in the certificate store, such as a certificate thumbprint or subject name.

- **`-f|--force`**

  Saves the configuration even if NuGet can't find or load the certificate. This option doesn't disable HTTPS server certificate validation.

- [!INCLUDE [help](includes/cli-help.md)]

- **`-s|--package-source <SOURCE_NAME>`**

  The package source name associated with the existing client certificate configuration. Required. Specify the source name, not its URL.

- **`--password <PASSWORD>`**

  The password for the certificate file. Use only with a file configuration. By default, NuGet encrypts the password before it saves it.

  > [!NOTE]
  > Password encryption is supported only on Windows. Only the same user on the same machine can decrypt the password.

- **`--path <CERTIFICATE_PATH>`**

  The path to the replacement certificate file. Use an absolute path or a path relative to the NuGet configuration file.

- **`--store-location <LOCATION>`**

  The certificate store location: `CurrentUser` or `LocalMachine`.

- **`--store-name <STORE_NAME>`**

  The certificate store name. Accepted values are `AddressBook`, `AuthRoot`, `CertificateAuthority`, `Disallowed`, `My`, `Root`, `TrustedPeople`, and `TrustedPublisher`. Certificate store availability depends on your operating system.

- **`--store-password-in-clear-text`**

  Saves the certificate file password without encryption. Specify this option with `--password`. To save a password on a platform other than Windows, use this option.

  > [!WARNING]
  > Avoid clear-text passwords when possible. Restrict access to configuration files that contain passwords, and don't commit passwords or private keys to source control.

## Examples

These examples require an existing client certificate configuration for a package source named `Contoso`.

- Replace a certificate file. If the replacement uses a different password, also specify `--password`:

  ```dotnetcli
  dotnet nuget update client-cert --package-source Contoso --path .\replacement-client.pfx --configfile .\nuget.config
  ```

- Update a store configuration to use a different certificate thumbprint. Replace `<CERTIFICATE_THUMBPRINT>` with the new thumbprint:

  ```dotnetcli
  dotnet nuget update client-cert --package-source Contoso --find-by Thumbprint --find-value <CERTIFICATE_THUMBPRINT> --configfile .\nuget.config
  ```

## See also

- [dotnet nuget add client-cert](dotnet-nuget-add-client-cert.md)
- [dotnet nuget list client-cert](dotnet-nuget-list-client-cert.md)
- [dotnet nuget remove client-cert](dotnet-nuget-remove-client-cert.md)
- [Common NuGet configurations](/nuget/consume-packages/configuring-nuget-behavior)
