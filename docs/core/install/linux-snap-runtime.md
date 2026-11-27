---
title: Install .NET Runtime on Linux with Snap
description: Learn about how to install the .NET Runtime snap package. Canonical maintains and supports .NET-related snap packages.
author: adegeo
ms.author: wiwagn
ms.date: 11/17/2026
ms.topic: install-set-up-deploy
ms.custom: linux-related-content
#customer intent: As a Linux user, I want to install .NET Runtime through Snap.
---

# Install .NET Runtime with Snap

This article describes how to install the .NET Runtime snap package. .NET Runtime snap packages are provided by and maintained by Canonical. Snaps are a great alternative to the package manager built into your Linux distribution. If you need to install the SDK, see [Install .NET SDK with Snap](linux-snap-sdk.md).

A snap is a bundle of an app and its dependencies that works across many different Linux distributions. Snaps are discoverable and installable from the Snap Store. For more information about Snap, see [Get started](https://snapcraft.io/docs/tutorials/get-started/#tutorials-get-started).

> [!CAUTION]
> Snap installations of .NET may have problems running [.NET tools](../tools/global-tools.md). If you wish to use .NET tools, we recommend that you install .NET using the [`dotnet-install` script](linux-scripted-manual.md#scripted-install) or the package manager for the particular Linux distribution.

## Prerequisites

- Linux distribution that supports snap.
- `snapd` the snap daemon.

Your Linux distribution might already include snap. Try running `snap` from a terminal to see if the command works. For a list of supported Linux distributions, and instructions on how to install snap, see [Installing `snapd`](https://snapcraft.io/docs/installing-snapd).

## .NET releases

[!INCLUDE [supported-versions](includes/supported-versions.md)]

## 1. Install the runtime

The following steps install the .NET 10 runtime snap package:

01. Open a terminal.
01. Use `snap install` to install the .NET Runtime snap package. For example, the following command installs the .NET 10 runtime.

    ```bash
    sudo snap install dotnet-runtime-100
    ```

Each .NET Runtime is published as an individual snap package. The following table lists the packages:

| .NET version                                        | Snap package         | .NET version supported by Microsoft |
|-----------------------------------------------------|----------------------|-------------------------------------|
| [11 (STS)](https://snapcraft.io/dotnet-runtime-110) | `dotnet-runtime-110` | Yes                                 |
| [10 (LTS)](https://snapcraft.io/dotnet-runtime-100) | `dotnet-runtime-100` | Yes                                 |
| [9 (STS)](https://snapcraft.io/dotnet-runtime-90)   | `dotnet-runtime-90`  | No                                  |
| [8 (LTS)](https://snapcraft.io/dotnet-runtime-80)   | `dotnet-runtime-80`  | No                                  |
| [7 (STS)](https://snapcraft.io/dotnet-runtime-70)   | `dotnet-runtime-70`  | No                                  |
| [6 (LTS)](https://snapcraft.io/dotnet-runtime-60)   | `dotnet-runtime-60`  | No                                  |
| [5](https://snapcraft.io/dotnet-runtime-50)         | `dotnet-runtime-50`  | No                                  |
| [3.1](https://snapcraft.io/dotnet-runtime-31)       | `dotnet-runtime-31`  | No                                  |
| [3.0](https://snapcraft.io/dotnet-runtime-30)       | `dotnet-runtime-30`  | No                                  |
| [2.2](https://snapcraft.io/dotnet-runtime-22)       | `dotnet-runtime-22`  | No                                  |
| [2.1](https://snapcraft.io/dotnet-runtime-21)       | `dotnet-runtime-21`  | No                                  |

## 2. Enable the dotnet command

Because Snap doesn't create an unversioned `dotnet` command, create a symbolic link to make `dotnet` available system-wide. Create this link only if you want to map the `dotnet` command to this specific Snap installation. If `/usr/local/bin/dotnet` already exists, remove it before creating the link; otherwise, `ln -s` fails.

```bash
sudo ln -s /snap/dotnet-runtime-100/current/usr/bin/dotnet /usr/local/bin/dotnet
```

Some runtime snaps expose a `dotnet` app for backwards compatibility. For example, with `dotnet-runtime-80`, you can instead enable the unversioned command with:

```bash
sudo snap alias dotnet-runtime-80.dotnet dotnet
```

Content-only snaps such as `dotnet-runtime-90`, `dotnet-runtime-100`, and `dotnet-runtime-110` don't expose a `dotnet` app. For those packages, use the preceding symbolic-link instructions.

## 3. Export the install location

The `DOTNET_ROOT` environment variable is often used by tools to determine where .NET is installed. When .NET is installed through Snap, this environment variable isn't configured. You should configure the *DOTNET_ROOT* environment variable in your profile. The path uses the following format: `/snap/{package}/current/usr/lib/dotnet`. For example, if you installed the `dotnet-runtime-100` snap, use the following command to set the environment variable to where .NET is located:

```bash
export DOTNET_ROOT=/snap/dotnet-runtime-100/current/usr/lib/dotnet
```

### Export the environment variable permanently

The preceding `export` command only sets the environment variable for the terminal session in which it was run.

You can edit your shell profile to permanently add the commands. There are a number of different shells available for Linux and each has a different profile. For example:

- **Bash Shell**: *~/.bash_profile*, *~/.bashrc*
- **Korn Shell**: *~/.kshrc* or *.profile*
- **Z Shell**: *~/.zshrc* or *.zprofile*

Edit the appropriate source file for your shell and add `export DOTNET_ROOT=/snap/dotnet-runtime-100/current/usr/lib/dotnet`.

## Troubleshooting

- [The dotnet terminal command doesn't work](#the-dotnet-terminal-command-doesnt-work)
- [Can't install Snap on WSL2](#cant-install-snap-on-wsl2)

### The dotnet terminal command doesn't work

Content-only .NET Runtime snaps, including `dotnet-runtime-90`, `dotnet-runtime-100`, and `dotnet-runtime-110`, don't create an unversioned `dotnet` command. To make the `dotnet` command available, create a symbolic link to the `dotnet` executable in the snap package:

```bash
sudo ln -s /snap/dotnet-runtime-100/current/usr/bin/dotnet /usr/local/bin/dotnet
```

Substitute `dotnet-runtime-100` with the name of your runtime package. If `/usr/local/bin/dotnet` already exists, remove it before you create the link.

For a runtime snap that exposes a `dotnet` app, such as `dotnet-runtime-80`, you can use `snap alias` instead:

```bash
sudo snap alias dotnet-runtime-80.dotnet dotnet
```

### Can't install Snap on WSL2

`systemd` must be enabled on the WSL2 instance before Snap can be installed.

1. Open `/etc/wsl.conf` in a text editor of your choice.
1. Paste in the following configuration:

   ```ini
   [boot]
   systemd=true
   ```

1. Save the file and restart the WSL2 instance through PowerShell. Use the `wsl.exe --shutdown` command.

## 4. Use the .NET CLI

Open a terminal and type `dotnet`.

```dotnetcli
dotnet
```

You'll see output similar to the following:

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

## Related content

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI.](../tools/enable-tab-autocomplete.md)
