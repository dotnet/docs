---
title: dotnet nuget add client-cert command
description: The dotnet nuget add client-cert command configures an HTTPS client certificate for a NuGet package source.
ms.date: 10/23/2026
ai-usage: ai-generated
---
# dotnet nuget add client-cert

**This article applies to:** ✔️ .NET Core 3.1.400 SDK and later versions

## Name

`dotnet nuget add client-cert` - Add a client certificate configuration for a NuGet package source.

## Synopsis

```dotnetcli
dotnet nuget add client-cert --package-source <SOURCE_NAME>
    --path <CERTIFICATE_PATH> [--password <PASSWORD>]
    [--store-password-in-clear-text] --configfile <FILE> [-f|--force]

dotnet nuget add client-cert --package-source <SOURCE_NAME>
    --find-value <VALUE> [--find-by <FIND_TYPE>]
    [--store-location <LOCATION>] [--store-name <STORE_NAME>]
    [--configfile <FILE>] [-f|--force]

dotnet nuget add client-cert -h|--help
```

## Description

The `dotnet nuget add client-cert` command adds a client certificate configuration to the `clientCertificates` section of your NuGet configuration files. Use a client certificate to authenticate to an HTTPS package source that requires client certificate authentication.

First, configure the package source with [dotnet nuget add source](dotnet-nuget-add-source.md). Then, associate a certificate with the source's name, not its URL. Choose one certificate source:

- **File:** Use `--path` to specify a PKCS #12 (`.pfx` or `.p12`) file that contains the certificate and its private key. Specify `--configfile` when you add a certificate from a file.
- **Certificate store:** Use `--find-value` to select a certificate from a certificate store. By default, NuGet searches by thumbprint in the current user's personal (`My`) store.

Don't combine file options (`--path` and `--password`) with store options (`--store-location`, `--store-name`, `--find-by`, and `--find-value`). Certificate store availability depends on your operating system.

Each package source can have only one client certificate configuration. If a configuration already exists for the source, the command fails. To change an existing configuration, use [dotnet nuget update client-cert](dotnet-nuget-update-client-cert.md).

Unless you specify `--force`, NuGet checks that it can find and load the certificate before it saves the configuration. The command doesn't test authentication with the package source.

## Options

- [!INCLUDE [configfile](includes/cli-configfile.md)]

  Required when you add a certificate from a file.

- **`--find-by <FIND_TYPE>`**

  The certificate store search method. Defaults to `Thumbprint`. Values are case-insensitive. Use an X.509 find type **without** the `FindBy` prefix. For example, use `SubjectName`, not `FindBySubjectName`.

  Accepted values are `Thumbprint`, `SubjectName`, `SubjectDistinguishedName`, `IssuerName`, `IssuerDistinguishedName`, `SerialNumber`, `TimeValid`, `TimeNotYetValid`, `TimeExpired`, `TemplateName`, `ApplicationPolicy`, `CertificatePolicy`, `Extension`, `KeyUsage`, and `SubjectKeyIdentifier`.

- **`--find-value <VALUE>`**

  The value to search for in the certificate store, such as a certificate thumbprint or subject name. Required for a certificate store configuration.

- **`-f|--force`**

  Saves the configuration even if NuGet can't find or load the certificate. Use this option to configure a certificate before it's available. This option doesn't disable HTTPS server certificate validation.

- [!INCLUDE [help](includes/cli-help.md)]

- **`-s|--package-source <SOURCE_NAME>`**

  The name of the package source to associate with the certificate, as defined in the `packageSources` section of your NuGet configuration. Required. Specify the source name, not its URL.

- **`--password <PASSWORD>`**

  The password for the certificate file, if needed. Use only with a file configuration. By default, NuGet encrypts the password before it saves it.

  > [!NOTE]
  > Password encryption is supported only on Windows. Only the same user on the same machine can decrypt the password.

- **`--path <CERTIFICATE_PATH>`**

  The path to the certificate file. Required for a file configuration. Use an absolute path or a path relative to the NuGet configuration file.

- **`--store-location <LOCATION>`**

  The certificate store location: `CurrentUser` or `LocalMachine`. Defaults to `CurrentUser`.

- **`--store-name <STORE_NAME>`**

  The certificate store name. Accepted values are `AddressBook`, `AuthRoot`, `CertificateAuthority`, `Disallowed`, `My`, `Root`, `TrustedPeople`, and `TrustedPublisher`. Defaults to `My`, the personal certificate store.

- **`--store-password-in-clear-text`**

  Saves the certificate file password without encryption. To save a password on a platform other than Windows, specify this option with `--password`.

  > [!WARNING]
  > Avoid clear-text passwords when possible. Restrict access to configuration files that contain passwords, and don't commit passwords or private keys to source control.

## Examples

Before you run these examples, configure a package source named `Contoso` in `nuget.config` and obtain a client certificate for that source.

- Add a certificate from a file without a password:

  ```dotnetcli
  dotnet nuget add client-cert --package-source Contoso --path .\client.pfx --configfile .\nuget.config
  ```

- Add a password-protected certificate file on Windows. Replace `<CERTIFICATE_PASSWORD>` with the file's password:

  ```dotnetcli
  dotnet nuget add client-cert --package-source Contoso --path .\client.pfx --password <CERTIFICATE_PASSWORD> --configfile .\nuget.config
  ```

- Add a certificate from the current user's personal store. Replace `<CERTIFICATE_THUMBPRINT>` with the certificate's thumbprint:

  ```dotnetcli
  dotnet nuget add client-cert --package-source Contoso --find-value <CERTIFICATE_THUMBPRINT> --configfile .\nuget.config
  ```

- Add a certificate from the current user's personal store by subject name:

  ```dotnetcli
  dotnet nuget add client-cert --package-source Contoso --store-location CurrentUser --store-name My --find-by SubjectName --find-value "Contoso NuGet client" --configfile .\nuget.config
  ```

Each example adds a configuration for the same source. Remove the existing configuration before you try another example.

## See also

- [dotnet nuget list client-cert](dotnet-nuget-list-client-cert.md)
- [dotnet nuget remove client-cert](dotnet-nuget-remove-client-cert.md)
- [dotnet nuget update client-cert](dotnet-nuget-update-client-cert.md)
- [Common NuGet configurations](/nuget/consume-packages/configuring-nuget-behavior)
- [NuGet configuration file reference](/nuget/reference/nuget-config-file)
