---
title: Install .NET Runtime on Linux with Snap
description: Learn about how to install the .NET Runtime snap package. Canonical maintains and supports .NET-related snap packages.
author: adegeo
ms.author: adegeo
ms.date: 05/22/2024
ms.topic: install-set-up-deploy
ms.custom: linux-related-content
#customer intent: As a Linux user, I want to install .NET Runtime through Snap.
---

# Install .NET Runtime with Snap

This article describes how to install the .NET Runtime snap package. .NET Runtime snap packages are provided by and maintained by Canonical. Snaps are a great alternative to the package manager built into your Linux distribution.

A snap is a bundle of an app and its dependencies that works without modification across many different Linux distributions. Snaps are discoverable and installable from the Snap Store. For more information about Snap, see [Getting started with Snap](https://snapcraft.io/docs/getting-started).

> [!CAUTION]
> Snap installations of .NET may have problems running [.NET tools](../tools/global-tools.md). If you wish to use .NET tools, we recommend that you install .NET using the [`dotnet-install` script](linux-scripted-manual.md#scripted-install) or the package manager for the particular Linux distribution.

## Prerequisites

- Linux distribution that supports snap.
- `snapd` the snap daemon.

It's possible your Linux distribution already includes snap. Try running `snap` from a terminal. For a list of supported Linux distributions, and instructions on how to install snap, see [Installing `snapd`](https://snapcraft.io/docs/installing-snapd).

## .NET releases

[!INCLUDE [supported-versions](includes/supported-versions.md)]

## 1. Install the runtime

Snap packages for the .NET Runtime are each published under their own package identifier. The following table lists the package identifiers:

| .NET version                                      | Snap package        | .NET version supported by Microsoft |
|---------------------------------------------------|---------------------|-----|
| [8 (STS)](https://snapcraft.io/dotnet-runtime-80) | `dotnet-runtime-80` | Yes |
| [7 (STS)](https://snapcraft.io/dotnet-runtime-70) | `dotnet-runtime-70` | No  |
| [6 (LTS)](https://snapcraft.io/dotnet-runtime-60) | `dotnet-runtime-60` | Yes |
| [5](https://snapcraft.io/dotnet-runtime-50)       | `dotnet-runtime-50` | No  |
| [3.1](https://snapcraft.io/dotnet-runtime-31)     | `dotnet-runtime-31` | No  |
| [3.0](https://snapcraft.io/dotnet-runtime-30)     | `dotnet-runtime-30` | No  |
| [2.2](https://snapcraft.io/dotnet-runtime-22)     | `dotnet-runtime-22` | No  |
| [2.1](https://snapcraft.io/dotnet-runtime-21)     | `dotnet-runtime-21` | No  |

01. Open a terminal.
01. Use `snap install` to install the .NET Runtime snap package. For example, the following command installs .NET 8 Runtime.

    ```bash
    sudo snap install dotnet-runtime-80
    ```

## 2. Enable the dotnet command

When the .NET Runtime snap package is installed, the `dotnet` command isn't automatically configured. Use the `snap alias` command to use the `dotnet` command from the terminal. The command is formatted as: `sudo snap alias {package}.{command} {alias}`. The following example maps the `dotnet` alias:

```bash
sudo snap alias dotnet-runtime-80.dotnet dotnet
```

## 3. Export the install location

The `DOTNET_ROOT` environment variable is often used by tools to determine where .NET is installed. When .NET is installed through Snap, this environment variable isn't configured. You should configure the *DOTNET_ROOT* environment variable in your profile. The path to the snap uses the following format: `/snap/{package}/current`. For example, if you installed the `dotnet-runtime-80` snap, use the following command to set the environment variable to where .NET is located:

```bash
export DOTNET_ROOT=/snap/dotnet-runtime-80/current
```

### Export the environment variable permanently

The preceding `export` command only sets the environment variable for the terminal session in which it was run.

You can edit your shell profile to permanently add the commands. There are a number of different shells available for Linux and each has a different profile. For example:

- **Bash Shell**: *~/.bash_profile*, *~/.bashrc*
- **Korn Shell**: *~/.kshrc* or *.profile*
- **Z Shell**: *~/.zshrc* or *.zprofile*

Edit the appropriate source file for your shell and add `export DOTNET_ROOT=/snap/dotnet-runtime-80/current`.

## Troubleshooting

- [The dotnet terminal command doesn't work](#the-dotnet-terminal-command-doesnt-work)
- [Can't install Snap on WSL2](#cant-install-snap-on-wsl2)

### The dotnet terminal command doesn't work

Snap packages can map an alias to a command provided by the package. By default, the .NET SDK snap packages create an alias for the `dotnet` command, but the .NET Runtime packages don't. To map the `dotnet` alias, use the following command:

```bash
sudo snap alias dotnet-runtime-80.dotnet dotnet
```

Substitute `dotnet-runtime-80` with the name of your runtime package.

### Can't install Snap on WSL2

`systemd` must be enabled on the WSL2 instance before Snap can be installed.

1. Open `/etc/wsl.conf` in a text editor of your choice.
1. Paste in the following configuration:

   ```ini
   [boot]
   systemd=true
   ```

1. Save the file and restart the WSL2 instance through PowerShell. Use the `wsl.exe --shutdown` command.

## Related content

- [How to enable TAB completion for the .NET CLI.](../tools/enable-tab-autocomplete.md)
