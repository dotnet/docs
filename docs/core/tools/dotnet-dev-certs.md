---
title: dotnet dev-certs command
description: The dotnet dev-certs command is a file watcher that restarts or hot reloads the specified application when changes in the source code are detected.
ms.date: 04/23/2022
---
# dotnet dev-certs

**This article applies to:** ✅ .NET Core 3.1 SDK and later versions

## Name

`dotnet dev-certs` - Generates a self-signed certificate to enable SSL use in development. 

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

The `dotnet dev-certs` command generates a self-signed certificate to enable HTTPS use in local web app development.

## Commands

<!-- markdownlint-disable MD012 -->

- **`https`**

  The `dotnet dev-certs` command has only one subcommand, `https`. The `dotnet dev-certs https` command with no options checks if a development certificate is present in the user's certificate store on the machine. If the command finds a development certificate, it displays a message like the following example:

  ```output
  A valid HTTPS certificate is already present.
  ```

  If the command doesn't find a development certificate:

  * On Windows, it creates a certificate in the certificate store named `My`, in the location `CurrentUser`. By default, it doesn't create a file. To create a file, use the `--export-path` option.
  * On Linux, it creates a certificate file and stores the certificate in *~/.dotnet/corefx/cryptography/x509stores/my/*.
  * <todo>what about macOS?

  After creating a certificate, the command displays a message like the following example:

  ```output
  The HTTPS developer certificate was generated successfully.
  ```

  By default, the newly created certificate is not trusted. To trust the certificate, use the `--trust` option.<todo>what use is the certificate if it's not trusted?

## Options

- **`-c|--check`**

  Checks for the existence of the development certificate but doesn't perform any action. Use this option with the `--trust` option to check if the certificate is not only valid but also trusted.

- **`--clean`**

  Removes all HTTPS development certificates from the machine. On Windows, it doesn't get rid of any physical files that have been exported. It only clears the certificate store of the generated certificate.<todo>What about Linux and macOS?

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
  * Puts a PFX file, with the filename set to the fingerprint of the certificate, in the default directory.<todo>which default directory?

  The Linux behavior is functionally identical to Windows and macOS from the perspective of .NET application code.<todo>is this accurate?

- **`--format`**

  When used with `--export-path`, specifies the format of the exported certificate file. Valid values are `PFX` and `PEM`, case-insensitive. `PFX` is the default.

  The file format is independent of the file name extension. For example, if you specify `--format pfx` and `--export-format ./cert.pem` you will get a file named *cert.pem* in `PFX` format.

  On Linux, you can use a PEM file that was generated on Windows, but not a PFX file that was generated on Windows.

  By default, the command creates a password-protected PEM file, with no key file. To generate a PEM file with separate certificate and key files, use the `--no-password` option.

  <todo>quoting the issue:
  It's unclear what the password is; potentially it's an empty string. More testing needs to be done. EDIT: I have done some testing here, and I actually can't get this to work in code at all. The only way to get it to work is to provide a password via -p, and use the overload of CreateFromEncryptedPemFile which includes the cert file path, the password, and the key file path.
  Using --format Pem does not produce a PEM that can be loaded by .NET's CreateFromEncryptedPemFile. It seems like the overload for the file path and password (no key file path) is for a type of PEM that dev-certs cannot create (that is, one with the key encrypted in the same file as the certificate PEM).
  This specific behavior should be noted, since there shouldn't be an output of dotnet dev-certs that cannot be loaded by a dotnet program. This is actually an issue with the dev-certs tool itself, not necessarily with documentation.

- **`-i|--import`**

  Imports the provided HTTPS development certificate into the machine. All other HTTPS developer certificates will be cleared out.

  To import a password-protected PEM or PFX file, provide the password with the `--password` option.


- **`-np|--no-password`**

  Explicitly request that you don't use a password for the key when exporting a certificate to a PEM format. This option is not applicable to PFX format files.

  If you don't specify this option for a PEM file export, the command creates a password-protected PEM file, with no key file. The `--no-password` option generates a PEM file with separate cert and key files. In addition to the file name specified for the `--export-path`, you'll get another file in the same directory with the same name but a *.key* extension. For example, the following command will generate a file named *localhost.pem* and a file named *localhost.key* in the */home/user* directory:

  ```dotnetcli
  dotnet dev-certs https --format pem -ep /home/user/localhost.pem -np 
  ```

- **`-p|--password`**

  Password to use:
  * When exporting the development certificate to a PFX or PEM file.
  * When importing a PEM file. (But any value can be specified for the password if the PEM file was created by dotnet dev-certs.)<todo>why does any password work with import, but you have to specify --password?

- **`-q|--quiet`**

  Display warnings and errors only.

- **`-t|--trust`**

  Trusts the certificate on the current platform.

  If this option isn't specified, the certificate is added to the certificate store but not to a trusted list.

  When combined with the `--check` option, validates that the certificate is trusted.

- **`-v|--verbose`**

  Display more debug information.

## Examples

'dotnet dev-certs https'
'dotnet dev-certs https --clean'
'dotnet dev-certs https --clean --import ./certificate.pfx -p password'
'dotnet dev-certs https --check --trust'
'dotnet dev-certs https -ep ./certificate.pfx -p password --trust'
'dotnet dev-certs https -ep ./certificate.crt --trust --key-format Pem'
'dotnet dev-certs https -ep ./certificate.crt -p password --trust --key-format Pem'

## See also

* [Generate self-signed certificates with the .NET CLI](/dotnet/core/additional-tools/self-signed-certificates-guide)
* [Enforce HTTPS in ASP.NET Core](/aspnet/core/security/enforcing-ssl)
* [Troubleshoot certificate problems such as certificate not trusted](/aspnet/core/security/enforcing-ssl#troubleshoot-certificate-problems-such-as-certificate-not-trusted)
* [Hosting ASP.NET Core images with Docker over HTTPS](/aspnet/core/security/docker-https)
* [Hosting ASP.NET Core images with Docker Compose over HTTPS](/aspnet/core/security/docker-compose-https)
