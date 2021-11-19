---
title: Install .NET on Linux with Snap - .NET
description: Demonstrates how to install either the .NET SDK or the .NET Runtime on Linux with Snap.
author: adegeo
ms.author: adegeo
ms.date: 10/26/2021
---

# Install the .NET SDK or the .NET Runtime with Snap

Use a Snap package to install the .NET SDK or .NET Runtime. Snaps are a great alternative to the package manager built into your Linux distribution. This article describes how to install .NET through [Snap](https://snapcraft.io/dotnet-sdk).

A snap is a bundle of an app and its dependencies that works without modification across many different Linux distributions. Snaps are discoverable and installable from the Snap Store. For more information about Snap, see [Getting started with Snap](https://snapcraft.io/docs/getting-started).

> [!CAUTION]
> Snap packages aren't supported in WSL2 on Windows 10. As an alternative, use the [`dotnet-install` script](linux-scripted-manual.md#scripted-install) or the package manager for the particular WSL2 distribution. It's not recommended but you can try to enable snap with an [unsupported workaround from the snapcraft forums](https://forum.snapcraft.io/t/running-snaps-on-wsl2-insiders-only-for-now/13033).

## .NET releases

Only ✔️ supported versions of .NET SDK are available through Snap. All versions of the .NET Runtime are available through snap starting with version 2.1. The following table lists the .NET (and .NET Core) releases:

| ✔️ Supported | ❌ Unsupported |
|-------------|---------------|
| 6 (LTS)     | 3.0           |
| 5           | 2.2           |
| 3.1 (LTS)   | 2.1           |
|             | 2.0           |
|             | 1.1           |
|             | 1.0           |

For more information about the life cycle of .NET releases, see [.NET Core and .NET 5 Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## SDK or Runtime

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Install the SDK

Snap packages for the .NET SDK are all published under the same identifier: `dotnet-sdk`. A specific version of the SDK can be installed by specifying the channel. The SDK includes the corresponding runtime. The following table lists the channels:

| .NET version | Snap package or channel  |
|--------------|--------------------------|
| 6 (LTS)      | `6.0` or `latest/stable` or `lts/stable` |
| 5            | `5.0` |
| 3.1 (LTS)    | `3.1` |

Use the `snap install` command to install a .NET SDK snap package. Use the `--channel` parameter to indicate which version to install. If this parameter is omitted, `latest/stable` is used. In this example, `6.0` is specified:

```bash
sudo snap install dotnet-sdk --classic --channel=6.0
```

Next, register the `dotnet` command for the system with the `snap alias` command:

```bash
sudo snap alias dotnet-sdk.dotnet dotnet
```

This command is formatted as: `sudo snap alias {package}.{command} {alias}`. You can choose any `{alias}` name you would like. For example, you could name the command after the specific version installed by snap: `sudo snap alias dotnet-sdk.dotnet dotnet60`. When you use the command `dotnet60`, you'll invoke this specific version of .NET. But choosing a different alias is incompatible with most tutorials and examples as they expect a `dotnet` command to be used.

## Install the runtime

Snap packages for the .NET Runtime are each published under their own package identifier. The following table lists the package identifiers:

| .NET version      | Snap package        |
|-------------------|---------------------|
| 6 (LTS)           | `dotnet-runtime-60` |
| 5                 | `dotnet-runtime-50` |
| 3.1 (LTS)         | `dotnet-runtime-31` |
| 3.0               | `dotnet-runtime-30` |
| 2.2               | `dotnet-runtime-22` |
| 2.1               | `dotnet-runtime-21` |

Use the `snap install` command to install a .NET Runtime snap package. In this example, .NET 6 is installed:

```bash
sudo snap install dotnet-runtime-60 --classic
```

Next, register the `dotnet` command for the system with the `snap alias` command:

```bash
sudo snap alias dotnet-runtime-60.dotnet dotnet
```

The command is formatted as: `sudo snap alias {package}.{command} {alias}`. You can choose any `{alias}` name you would like. For example, you could name the command after the specific version installed by snap: `sudo snap alias dotnet-runtime-60.dotnet dotnet60`. When you use the command `dotnet60`, you'll invoke a specific version of .NET. But choosing a different alias is incompatible with most tutorials and examples as they expect a `dotnet` command to be available.

## Export the install location

The `DOTNET_ROOT` environment variable is often used by tools to determine where .NET is installed. When .NET is installed through Snap, this environment variable isn't configured. You should configure the *DOTNET_ROOT* environment variable in your profile. The path to the snap uses the following format: `/snap/{package}/current`. For example, if you installed the `dotnet-sdk` snap, use the following command to set the environment variable to where .NET is located:

```bash
export DOTNET_ROOT=/snap/dotnet-sdk/current
```

> [!TIP]
> The preceding `export` command only sets the environment variable for the terminal session in which it was run.
>
> You can edit your shell profile to permanently add the commands. There are a number of different shells available for Linux and each has a different profile. For example:
>
> - **Bash Shell**: *~/.bash_profile*, *~/.bashrc*
> - **Korn Shell**: *~/.kshrc* or *.profile*
> - **Z Shell**: *~/.zshrc* or *.zprofile*
>
> Edit the appropriate source file for your shell and add `export DOTNET_ROOT=/snap/dotnet-sdk/current`.

## TLS/SSL Certificate errors

When .NET is installed through Snap, it's possible that on some distros the .NET TLS/SSL certificates may not be found and you may receive an error during `restore`:

```bash
Processing post-creation actions...
Running 'dotnet restore' on /home/myhome/test/test.csproj...
  Restoring packages for /home/myhome/test/test.csproj...
/snap/dotnet-sdk/27/sdk/2.2.103/NuGet.targets(114,5): error : Unable to load the service index for source https://api.nuget.org/v3/index.json. [/home/myhome/test/test.csproj]
/snap/dotnet-sdk/27/sdk/2.2.103/NuGet.targets(114,5): error :   The SSL connection could not be established, see inner exception. [/home/myhome/test/test.csproj]
/snap/dotnet-sdk/27/sdk/2.2.103/NuGet.targets(114,5): error :   The remote certificate is invalid according to the validation procedure. [/home/myhome/test/test.csproj]
```

To resolve this problem, set a few environment variables:

```bash
export SSL_CERT_FILE=[path-to-certificate-file]
export SSL_CERT_DIR=/dev/null
```

The certificate location will vary by distro. Here are the locations for the distros where the issue has been experienced.

| Distribution | Location                                            |
|--------------|-----------------------------------------------------|
| **Fedora**   | `/etc/pki/ca-trust/extracted/pem/tls-ca-bundle.pem` |
| **OpenSUSE** | `/etc/ssl/ca-bundle.pem`                            |
| **Solus**    | `/etc/ssl/certs/ca-certificates.crt`                |

## Troubles resolving dotnet

It's common for other apps, such as the OmniSharp extension for Visual Studio Code, to try to resolve the location of the .NET SDK. Typically, this is done by figuring out where the `dotnet` executable is located. A snap-installed .NET SDK may confuse these apps. When these apps can't resolve the .NET SDK, you'll see an error similar to one of the following messages:

- The SDK 'Microsoft.NET.Sdk' specified could not be found
- The SDK 'Microsoft.NET.Sdk.Web' specified could not be found
- The SDK 'Microsoft.NET.Sdk.Razor' specified could not be found

To fix this problem, symlink the snap `dotnet` executable to the location that the program is looking for. Two common paths the `dotnet` command is looking for are `/usr/local/bin/dotnet` and `/usr/share/dotnet`. For example, to link the current .NET SDK snap package, use the following command:

```bash
ln -s /snap/dotnet-sdk/current/dotnet /usr/local/bin/dotnet
```

You can also review these GitHub issues for information about these problems:

- [SDK resolver doesn't work with snap installations of SDK on Linux](https://github.com/dotnet/sdk/issues/10403)
- [It wasn't possible to find any installed .NET SDKs](https://github.com/OmniSharp/omnisharp-vscode/issues/4409)

### The dotnet alias

It's possible that if you created the `dotnet` alias for the snap-installed .NET, you'll have a conflict. Use the `snap unalias dotnet` command to remove it, and then add a different alias if you want.

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
