---
title: Install .NET on Linux without using a package manager
description: Demonstrates how to install the .NET SDK and the .NET Runtime on Linux without a package manager. Use the install script or manually extract the binaries.
author: adegeo
ms.author: adegeo
ms.date: 11/11/2024
ms.custom: linux-related-content
---

# Install .NET on Linux by using an install script or by extracting binaries

This article demonstrates how to install the .NET SDK or the .NET Runtime on Linux by using the install script or by extracting the binaries. For a list of distributions that support the built-in package manager, see [Install .NET on Linux](linux.md).

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## .NET releases

There are two types of supported releases, Long Term Support (LTS) releases or Standard Term Support (STS). The quality of all releases is the same. The only difference is the length of support. LTS releases get free support and patches for 3 years. STS releases get free support and patches for 18 months. For more information, see [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

The following table lists the support status of each version of .NET (and .NET Core):

| ✔️ Supported | ❌ Unsupported |
|-------------|---------------|
| 9 (STS)     | 7             |
| 8 (LTS)     | 6 (LTS)       |
|             | 5             |
|             | 3.1           |
|             | 3.0           |
|             | 2.2           |
|             | 2.1           |
|             | 2.0           |
|             | 1.1           |
|             | 1.0           |

## Dependencies

It's possible that when you install .NET, specific dependencies may not be installed, such as when [manually installing](#manual-install). The following list details Linux distributions that are supported by Microsoft and have dependencies you may need to install. Check the distribution page for more information:

- [Alpine](linux-alpine.md#dependencies)
- [Debian](linux-debian.md#dependencies)
- [Fedora](linux-fedora.md#dependencies)
- [RHEL and CentOS Stream](linux-rhel.md#dependencies)
- [SLES](linux-sles.md#dependencies)
- [Ubuntu](linux-ubuntu-decision.md#dependencies)

For generic information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/main/Documentation/self-contained-linux-apps.md).

### RPM dependencies

If your distribution wasn't previously listed, and is RPM-based, you may need the following dependencies:

- krb5-libs
- libicu
- openssl-libs

### DEB dependencies

If your distribution wasn't previously listed, and is debian-based, you may need the following dependencies:

- libc6
- libgcc1
- libgssapi-krb5-2
- libicu70
- libssl3
- libstdc++6
- zlib1g

## Scripted install

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the **SDK** and **Runtime**. You can download the script from <https://dot.net/v1/dotnet-install.sh>. When .NET is installed in this way, you must install the dependencies required by your Linux distribution. Use the links in the [Install .NET on Linux](linux.md) article for your specific Linux distribution.

> [!IMPORTANT]
> Bash is required to run the script.

You can download the script with `wget`:

```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
```

Or, with `curl`:

```bash
curl -L https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
```

Before running this script, make sure you grant permission for this script to run as an executable:

```bash
chmod +x ./dotnet-install.sh
```

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) SDK version, which is .NET 8. To install the latest release, which might not be an (LTS) version, use the `--version latest` parameter.

```bash
./dotnet-install.sh --version latest
```

To install .NET Runtime instead of the SDK, use the `--runtime` parameter.

```bash
./dotnet-install.sh --version latest --runtime aspnetcore
```

You can install a specific major version with the `--channel` parameter to indicate the specific version. The following command installs .NET 9.0 SDK.

```bash
./dotnet-install.sh --channel 9.0
```

For more information, see [dotnet-install scripts reference](../tools/dotnet-install-script.md).

To enable .NET on the command line, see [Set environment variables system-wide](#set-environment-variables-system-wide).

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

## Manual install

<!-- Note, this content is copied in macos.md. Any fixes should be applied there too, though content may be different -->

As an alternative to the package managers, you can download and manually install the SDK and runtime. Manual installation is commonly used as part of continuous integration testing or on an unsupported Linux distribution. For a developer or user, it's better to use a package manager.

Download a **binary** release for either the SDK or the runtime from one of the following sites. The .NET SDK includes the corresponding runtime:

- ✔️ [.NET 9 downloads](https://dotnet.microsoft.com/download/dotnet/9.0)
- ✔️ [.NET 8 downloads](https://dotnet.microsoft.com/download/dotnet/8.0)
- [All .NET Core downloads](https://dotnet.microsoft.com/download/dotnet)

Extract the downloaded file and use the `export` command to set `DOTNET_ROOT` to the extracted folder's location and then ensure .NET is in PATH. Exporting `DOTNET_ROOT` makes the .NET CLI commands available in the terminal. For more information about .NET environment variables, see [.NET SDK and CLI environment variables](../tools/dotnet-environment-variables.md#net-sdk-and-cli-environment-variables).

Different versions of .NET can be extracted to the same folder, which coexist side-by-side.

### Example

<!-- Note, this content is copied in macos.md. Any fixes should be applied there too, though content may be different -->

The following commands use Bash to set the environment variable `DOTNET_ROOT` to the current working directory followed by `.dotnet`. That directory is created if it doesn't exist. The `DOTNET_FILE` environment variable is the filename of the .NET binary release you want to install. This file is extracted to the `DOTNET_ROOT` directory. Both the `DOTNET_ROOT` directory and its `tools` subdirectory are added to the `PATH` environment variable.

> [!IMPORTANT]
> If you run these commands, remember to change the `DOTNET_FILE` value to the name of the .NET binary you downloaded.

```bash
DOTNET_FILE=dotnet-sdk-9.0.100-linux-x64.tar.gz
export DOTNET_ROOT=$(pwd)/.dotnet

mkdir -p "$DOTNET_ROOT" && tar zxf "$DOTNET_FILE" -C "$DOTNET_ROOT"

export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
```

You can install more than one version of .NET in the same folder.

You can also install .NET to the home directory identified by the `HOME` variable or `~` path:

```bash
export DOTNET_ROOT=$HOME/.dotnet
```

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

## Verify downloaded binaries

[!INCLUDE [verify-download-intro](includes/verify-download-intro.md)]

[!INCLUDE [verify-download-macos-linux](includes/verify-download-macos-linux.md)]

## Set environment variables system-wide

If you used the previous install script, the variables set only apply to your current terminal session. Add them to your shell profile. There are many different shells available for Linux and each has a different profile. For example:

- **Bash Shell**: *~/.bash_profile* or *~/.bashrc*
- **Korn Shell**: *~/.kshrc* or *.profile*
- **Z Shell**: *~/.zshrc* or *.zprofile*

Set the following two environment variables in your shell profile:

- `DOTNET_ROOT`

  This variable is set to the folder .NET was installed to, such as `$HOME/.dotnet`:

  ```bash
  export DOTNET_ROOT=$HOME/.dotnet
  ```

- `PATH`

  This variable should include both the `DOTNET_ROOT` folder and the `DOTNET_ROOT/tools` folder:

  ```bash
  export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
  ```

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
