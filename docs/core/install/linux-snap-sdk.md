---
title: Install .NET SDK on Linux with Snap
description: Learn about how to install the .NET SDK snap package. Canonical maintains and supports .NET-related snap packages.
author: adegeo
ms.author: adegeo
ms.date: 11/14/2025
ms.topic: install-set-up-deploy
ms.custom: linux-related-content, updateeachrelease
ai-usage: ai-assisted
#customer intent: As a Linux user, I want to install .NET SDK through Snap.
---

# Install .NET SDK with Snap

This article describes how to install the .NET SDK snap package. .NET SDK snap packages are provided by and maintained by Canonical. Snaps are a great alternative to the package manager built into your Linux distribution.

A snap is a bundle of an app and its dependencies that works across many different Linux distributions. Snaps are discoverable and installable from the Snap Store. For more information about Snap, see [Quickstart tour](https://snapcraft.io/docs/quickstart-tour).

> [!CAUTION]
> Snap installations of .NET may have problems running [.NET tools](../tools/global-tools.md). If you wish to use .NET tools, we recommend that you install .NET using the [`dotnet-install` script](linux-scripted-manual.md#scripted-install) or the package manager for the particular Linux distribution.
>
> It's a known issue that the `dotnet watch` command doesn't work when .NET is installed via Snap.
>
> If you're going to use .NET tools or the `dotnet watch` command, we recommend that you install .NET using the [`dotnet-install` script](linux-scripted-manual.md#scripted-install).

## Prerequisites

- Linux distribution that supports snap.
- `snapd` the snap daemon.

Your Linux distribution might already include snap. Try running `snap` from a terminal to see if the command works. For a list of supported Linux distributions, and instructions on how to install snap, see [Installing `snapd`](https://snapcraft.io/docs/installing-snapd).

## .NET releases

[!INCLUDE [supported-versions](includes/supported-versions.md)]

## 1. Install the SDK

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

Starting with .NET 9, snap packages for the .NET SDK are published under version-specific identifiers (for example, `dotnet-sdk-90` for .NET 9 and `dotnet-sdk-100` for .NET 10). Prior to .NET 9, all SDK versions were published under the same identifier `dotnet-sdk`, and you specified the version through a channel. Additionally, .NET 9 and later snap packages support both x64 and Arm64 architectures, while earlier versions only support x64. The SDK includes both the ASP.NET Core and .NET runtime, versioned to the SDK.

> [!TIP]
> The [Snapcraft .NET SDK package page](https://snapcraft.io/dotnet-sdk) includes distribution-specific instructions on how to install Snapcraft and .NET.

01. Open a terminal.
01. Use `snap install` to install the .NET SDK snap package.

    The `--classic` parameter is required.

    - **For .NET 9 and later**

      Install the version-specific package. For example, the following command installs .NET SDK 10:

      ```bash
      sudo snap install dotnet-sdk-100 --classic
      ```

    - **For .NET 8 and earlier**

      Install from the `dotnet-sdk` package and specify a channel. If this parameter is omitted, `latest/stable` is used. For example, the following command installs .NET SDK 8:

      ```bash
      sudo snap install dotnet-sdk --classic --channel 8.0/stable
      ```

The `dotnet` snap alias is automatically created and mapped to the snap package's `dotnet` command.

The following table lists the snap packages and channels you can install:

| .NET version | Snap package or channel                |
|--------------|----------------------------------------|
| 10 (LTS)     | `dotnet-sdk-100` (preview)             |
| 9 (STS)      | `dotnet-sdk-90`                        |
| 8 (LTS)      | `dotnet-sdk --channel 8.0/stable`      |
| 7            | `dotnet-sdk --channel 7.0/stable` (out of support) |
| 6            | `dotnet-sdk --channel 6.0/stable` (out of support) |
| 5            | `dotnet-sdk --channel 5.0/stable` (out of support) |
| 3.1          | `dotnet-sdk --channel 3.1/stable` (out of support) |
| 2.1          | `dotnet-sdk --channel 2.1/stable` (out of support) |

## 2. Export the install location

The `DOTNET_ROOT` environment variable is often used by tools to determine where .NET is installed. When .NET is installed through Snap, this environment variable isn't configured. You should configure the *DOTNET_ROOT* environment variable in your profile. The path to the snap uses the following format: `/snap/{package}/current`.

For .NET 9 and later, use the version-specific package name:

```bash
export DOTNET_ROOT=/snap/dotnet-sdk-100/current
```

For .NET 8 and earlier, use the shared package name:

```bash
export DOTNET_ROOT=/snap/dotnet-sdk/current
```

### Export the environment variable permanently

The preceding `export` command only sets the environment variable for the terminal session in which it was run.

You can edit your shell profile to permanently add the commands. There are many different shells available for Linux and each has a different profile. For example:

- **Bash Shell**: _~/.bash_profile_, _~/.bashrc_
- **Korn Shell**: _~/.kshrc_ or _.profile_
- **Z Shell**: _~/.zshrc* or _.zprofile_

Edit the appropriate source file for your shell and add the export command for your installed .NET version. For .NET 9+, use `export DOTNET_ROOT=/snap/dotnet-sdk-100/current` (adjust the version number as needed). For .NET 8 and earlier, use `export DOTNET_ROOT=/snap/dotnet-sdk/current`.

## 3. Use the .NET CLI

Open a terminal and type `dotnet`.

```dotnetcli
dotnet
```

The following output is displayed:

```output
Usage: dotnet [options]
Usage: dotnet [path-to-application]

Options:
  -h|--help         Display help.
  --info            Display .NET information.
  --list-sdks       Display the installed SDKs.
  --list-runtimes   Display the installed runtimes.

path-to-application:
  The path to an application .dll file to execute.
```

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

## Troubleshooting

- [The dotnet terminal command doesn't work](#the-dotnet-terminal-command-doesnt-work)
- [Can't install Snap on WSL2](#cant-install-snap-on-wsl2)
- [Can't resolve the dotnet command or SDK](#cant-resolve-the-dotnet-command-or-sdk)
- [TLS/SSL Certificate errors](#tlsssl-certificate-errors)

### The dotnet terminal command doesn't work

Snap packages can map an alias to a command provided by the package. By default, the .NET SDK snap packages create an alias for the `dotnet` command. If the alias wasn't created or was previously removed, use the following command to map the alias.

For .NET 9 and later:

```bash
sudo snap alias dotnet-sdk-100.dotnet dotnet
```

For .NET 8 and earlier:

```bash
sudo snap alias dotnet-sdk.dotnet dotnet
```

### Can't install Snap on WSL2

`systemd` must be enabled on the WSL2 instance before Snap can be installed.

01. Open `/etc/wsl.conf` in a text editor of your choice.
01. Paste in the following configuration:

    ```ini
    [boot]
    systemd=true
    ```

01. Save the file and restart the WSL2 instance through PowerShell. Use the `wsl.exe --shutdown` command.

### Can't resolve the dotnet command or SDK

It's common for other apps, such as a code IDE or an extension in Visual Studio Code, to try to resolve the location of the .NET SDK. Typically, discovery is done by checking the `DOTNET_ROOT` environment variable, or figuring out where the `dotnet` executable is located. A snap-installed .NET SDK might confuse these apps. When these apps can't resolve the .NET SDK, an error similar to one of the following messages is displayed:

- The SDK 'Microsoft.NET.Sdk' specified could not be found
- The SDK 'Microsoft.NET.Sdk.Web' specified could not be found
- The SDK 'Microsoft.NET.Sdk.Razor' specified could not be found

Try the following steps to fix the issue:

01. Making sure that you [export the `DOTNET_ROOT` environment variable permanently](#export-the-environment-variable-permanently).

01. Try to symbolic link the snap `dotnet` executable to the location that the program is looking for.

    Two common paths the `dotnet` command is looking for are:

    - `/usr/local/bin/dotnet`
    - `/usr/share/dotnet`

    Use the following command to create a symbolic link to the snap package. For .NET 9 and later, use the version-specific package name:

    ```bash
    ln -s /snap/dotnet-sdk-100/current/dotnet /usr/local/bin/dotnet
    ```

    For .NET 8 and earlier:

    ```bash
    ln -s /snap/dotnet-sdk/current/dotnet /usr/local/bin/dotnet
    ```

### TLS/SSL Certificate errors

When .NET is installed through Snap, it's possible that on some distributions the .NET TLS/SSL certificates might not be found and you might receive an error during `restore`:

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

The certificate location varies by distribution. Here are the locations for the distributions where the issue has been observed:

| Distribution | Location                                            |
|--------------|-----------------------------------------------------|
| **Fedora**   | `/etc/pki/ca-trust/extracted/pem/tls-ca-bundle.pem` |
| **OpenSUSE** | `/etc/ssl/ca-bundle.pem`                            |
| **Solus**    | `/etc/ssl/certs/ca-certificates.crt`                |

## Related content

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI.](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
