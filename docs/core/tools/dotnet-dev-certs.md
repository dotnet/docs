---
title: dotnet dev-certs command
description: The dotnet dev-certs command generates a self-signed certificate to enable HTTPS use in development.
ms.date: 06/06/2022
---
# dotnet dev-certs

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet dev-certs` - Generates a self-signed certificate to enable HTTPS use in development.

## Synopsis

```dotnetcli
dotnet dev-certs https 
  [-c|--check] [--clean] [-ep|--export-path]
  [--format] [-i|--import] [-np|--no-password]
  [-p|--password] [-q|--quiet] [-t|--trust]
  [-v|--verbose] [--version]

dotnet dev-certs https -h|--help
```

## Description

The `dotnet dev-certs` command generates a self-signed certificate to enable HTTPS use in local web app development. The command recognizes options that perform related functions, such as checking if a certificate is already present, and importing and exporting certificates from and to certificate files.

## Commands

<!-- markdownlint-disable MD012 -->

- **`https`**

  The `dotnet dev-certs` command has only one subcommand: `https`. The `dotnet dev-certs https` command with no options checks if a development certificate is present in the user's certificate store on the machine. If the command finds a development certificate, it displays a message like the following example:

  ```output
  A valid HTTPS certificate is already present.
  ```

  If the command doesn't find a development certificate:

  * On Windows, it creates a certificate in the certificate store named `My`, in the location `CurrentUser`. By default, it doesn't create a file. To create a file, use the `--export-path` option.
  * On Linux, it creates a certificate file and stores the certificate in *~/.dotnet/corefx/cryptography/x509stores/my/*.
  
  After creating a certificate, the command displays a message like the following example:

  ```output
  The HTTPS developer certificate was generated successfully.
  ```

  By default, the newly created certificate is not trusted. To trust the certificate, use the `--trust` option.

## Options

- **`-c|--check`**

  Checks for the existence of the development certificate but doesn't perform any action. Use this option with the `--trust` option to check if the certificate is not only valid but also trusted.

- **`--clean`**

  Removes all HTTPS development certificates from the machine. On Windows, it doesn't get rid of any physical files that have been exported. It only clears the certificate store of the generated certificate.

  If there is at least one certificate in the certificate store, the command displays a message like the following example:

  ```output
  Cleaning HTTPS development certificates
  from the machine.
  A prompt might get displayed to confirm
  the removal of some of the certificates.

  HTTPS development certificates
  successfully removed from the machine.
  ```

- **`-ep|--export-path`**

  The full path to the exported certificate file, including the file name. To create a physical file on Windows, you have to specify this option.

  When you specify this option on Linux, the command:

  * Exports the file to the path you specify.
  * Puts a PFX file, with the filename set to the fingerprint of the certificate, in the default directory.

  The Linux behavior is functionally identical to Windows and macOS from the perspective of .NET application code.

- **`--format`**

  When used with `--export-path`, specifies the format of the exported certificate file. Valid values are `PFX` and `PEM`, case-insensitive. `PFX` is the default.

  The file format is independent of the file name extension. For example, if you specify `--format pfx` and `--export-format ./cert.pem` you will get a file named *cert.pem* in `PFX` format.

  On Linux, you can use a PEM file that was generated on Windows, but not a PFX file that was generated on Windows.

  If you don't specify this option, or if you specify `PEM` format, the command creates a password-protected PEM file, with no separate key file. To generate a PEM file with separate certificate and key files, use the `--no-password` option.

  - **`-i|--import <PATH>`**

  Imports the provided HTTPS development certificate into the machine. Requires that you also specify the `--clean` option, which clears out any existing HTTPS developer certificates.

  `PATH` specifies a path to a certificate file. To import a password-protected PEM or PFX file, provide the password with the `--password` option.

- **`-np|--no-password`**

  Doesn't use a password for the key when exporting a certificate to a PEM format. This option is not applicable to PFX format files.

  By default, the command exports a PEM file as a password-protected file, with no key file. The `--no-password` option generates a PEM file with separate cert and key files. In addition to the file name specified for the `--export-path` option, you'll get another file in the same directory with the same name but a *.key* extension. For example, the following command will generate a file named *localhost.pem* and a file named *localhost.key* in the */home/user* directory:

  ```dotnetcli
  dotnet dev-certs https --format pem -ep /home/user/localhost.pem -np 
  ```

- **`-p|--password`**

  Specifies the password to use:
  * When exporting the development certificate to a PFX or PEM file.
  * When importing a PFX file or a password-protected PEM file.

- **`-q|--quiet`**

  Display warnings and errors only.

- **`-t|--trust`**

  Trusts the certificate on the current machine.

  If this option isn't specified, the certificate is added to the certificate store but not to a trusted list.

  When combined with the `--check` option, validates that the certificate is trusted.

- **`-v|--verbose`**

  Display more debug information.

## Examples

- Check for the presence of a development certificate, and create one in the default certificate store if one doesn't exist yet. But don't trust the certificate.

  ```dotnetcli
  dotnet dev-certs https
  ```

- Remove any development certificates that already exist on the local machine.

  ```dotnetcli
  dotnet dev-certs https --clean
  ```

- Import a PFX file.

  ```dotnetcli
  dotnet dev-certs https --clean --import ./certificate.pfx -p password```
  ```

- Check if a trusted development certificate is present on the local machine.

  ```dotnetcli
  dotnet dev-certs https --check --trust
  ```

- Create a certificate, trust it, and export it to a PFX file.

  ```dotnetcli
  dotnet dev-certs https -ep ./certificate.pfx -p password --trust
  ```

- Create a certificate, trust it, and export it to a PEM file.

  ```dotnetcli
  dotnet dev-certs https -ep ./certificate.crt --trust --key-format Pem
  ```

- Create a certificate, trust it, and export it to a PEM file.

  ```dotnetcli
  dotnet dev-certs https -ep ./certificate.crt -p password --trust --key-format Pem
  ```

## See also

* [Generate self-signed certificates with the .NET CLI](/dotnet/core/additional-tools/self-signed-certificates-guide)
* [Enforce HTTPS in ASP.NET Core](/aspnet/core/security/enforcing-ssl)
* [Troubleshoot certificate problems such as certificate not trusted](/aspnet/core/security/enforcing-ssl#troubleshoot-certificate-problems-such-as-certificate-not-trusted)
* [Hosting ASP.NET Core images with Docker over HTTPS](/aspnet/core/security/docker-https)
* [Hosting ASP.NET Core images with Docker Compose over HTTPS](/aspnet/core/security/docker-compose-https)
