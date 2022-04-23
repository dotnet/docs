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

  The `dotnet dev-certs` command has only one subcommand, `https`. The `dotnet dev-certs https` command with no options checks if a development certificate is present in the user's certificate store on the machine. If a certiicate is found, the following message is displayed:

  ```output
  A valid HTTPS certificate is already present.
  ```

  If a certificate is not found:

  * On Windows, the command creates a certificate and stores it in the user's certificate store. No file is created. To create a file, use the `--export-path` option.
  * On Linux, the command creates a certificate file and stores it certificate in *~/.dotnet/corefx/cryptography/x509stores/my/*.

  The following message is displayed:

  ```output
  The HTTPS developer certificate was generated successfully.
  ```
 
  The newly created certificate is not trusted. To trust the certificate, use the `--trust` option.<todo>what use is the certificate if it's not trusted?

## Options

- **`-c|--check`**

  Check for the existence of the certificate but do not perform any action.

- **`--clean`**

  Clean all HTTPS development certificates from the machine. Does not get rid of any physical files that have been exported. It only clears the certificate store of the generated certificate. This is the case even if you have exported your certificate to the (Linux) certificate store directory.<todo>so if you've exported to the Linux cert store directory --clean does or doesn't remove the file?

- **`-ep|--export-path`**

  Full path to the exported certificate.

  On Windows, if you don't specify this option, the command doesn't create a physical file.

  When you pass an export path on Linux, the command will both export the file to the path you give it (including your filename), and it will also put a PFX file (with the filename set to the fingerprint of the certificate) in the default directory. This behavior is functionally identical to Windows and macOS from the perspective of .NET application code.

- **`--format`**

  Export the certificate in the given format. Valid values are PFX and PEM. PFX is the default. On Linux, you can use a PEM file that was generated on Windows, but not a PFX file that was generated on Windows.

  By default, the command creates a password-protected PEM file, with no key file. To generate a PEM file with separate cert and key files, use the `--no-password` option.

  If you specify a PEM file, you have to specify the `--export-path`.

  <todo>It's unclear what the password is; potentially it's an empty string. More testing needs to be done. EDIT: I have done some testing here, and I actually can't get this to work in code at all. The only way to get it to work is to provide a password via -p, and use the overload of CreateFromEncryptedPemFile which includes the cert file path, the password, and the key file path. Using --format Pem does not produce a PEM that can be loaded by .NET's CreateFromEncryptedPemFile. It seems like the overload for the file path and password (no key file path) is for a type of PEM that dev-certs cannot create (that is, one with the key encrypted in the same file as the certificate PEM).
  This specific behavior should be noted, since there shouldn't be an output of dotnet dev-certs that cannot be loaded by a dotnet program. This is actually an issue with the dev-certs tool itself, not necessarily with documentation.

- **`-i|--import`**

  Import the provided HTTPS development certificate into the machine. All other HTTPS developer certificates will be cleared out.

- **`-np|--no-password`**

  Explicitly request that you don't use a password for the key when exporting a certificate to a PEM format.

  If you don't specify this option, the command creates a password-protected PEM file, with no key file. This option generates a PEM file with separate cert and key files. As a result, you'll get a file named `<yourcertname>.pem` and a file named `<yourcertname>.key` in the directory you pass as part of the export path. For example, the following command will generate a file named *localhost.pem* and a file named *localhost.key* in the */home/user* directory:

  ```dotnetcli
  dotnet dev-certs --format pem -ep /home/user/localhost.pem -np 
  ```

- **`-p|--password`**

  Password to use when exporting the certificate with the private key into a pfx file or to encrypt the Pem exported key.

- **`-q|--quiet`**

  Display warnings and errors only.

- **`-t|--trust`**

  Trust the certificate on the current platform. When combined with the `--check` option, validates that the certificate is trusted. If this option isn't specified, the certificate is added to the certificate store but not to a trusted list.

- **`-v|--verbose`**

  Display more debug information.

## See also

* [Generate self-signed certificates with the .NET CLI](/dotnet/core/additional-tools/self-signed-certificates-guide)
* [Enforce HTTPS in ASP.NET Core](/aspnet/core/security/enforcing-ssl)
* [Troubleshoot certificate problems such as certificate not trusted](/aspnet/core/security/enforcing-ssl#troubleshoot-certificate-problems-such-as-certificate-not-trusted)
* [Hosting ASP.NET Core images with Docker over HTTPS](/aspnet/core/security/docker-https)
* [Hosting ASP.NET Core images with Docker Compose over HTTPS](/aspnet/core/security/docker-compose-https)
