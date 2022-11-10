---
title: Install .NET on Linux without using a package manager 
description: Demonstrates how to install the .NET SDK and the .NET Runtime on Linux without a package manager. Use the install script or manually extract the binaries.
author: adegeo
ms.author: adegeo
ms.date: 11/08/2022
---

# Install .NET on Linux by using an install script or by extracting binaries

This article demonstrates how to install the .NET SDK or the .NET Runtime on Linux by using the install script or by extracting the binaries. For a list of distributions that support the built-in package manager, see [Install .NET on Linux](linux.md).

You can also install .NET with snap. For more information, see [Install the .NET SDK or the .NET Runtime with Snap](linux-snap.md).

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## .NET releases

There are two types of supported releases, Long Term Support (LTS) releases or Standard Term Support (STS). The quality of all releases is the same. The only difference is the length of support. LTS releases get free support and patches for 3 years. STS releases get free support and patches for 18 months. For more information, see [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

The following table lists the support status of each version of .NET (and .NET Core):

| ✔️ Supported | ❌ Unsupported |
|-------------|---------------|
| 7 (STS)     | 5             |
| 6 (LTS)     | 3.0           |
| 3.1 (LTS)   | 2.2           |
|             | 2.1           |
|             | 2.0           |
|             | 1.1           |
|             | 1.0           |

## Dependencies

It's possible that when you install .NET, specific dependencies may not be installed, such as when [manually installing](#manual-install). The following list details Linux distributions that are supported by Microsoft and have dependencies you may need to install. Check the distribution page for more information:

- [Alpine](linux-alpine.md#dependencies)
- [Debian](linux-debian.md#dependencies)
- [CentOS](linux-centos.md#dependencies)
- [Fedora](linux-fedora.md#dependencies)
- [RHEL and CentOS Stream](linux-rhel.md#dependencies)
- [SLES](linux-sles.md#dependencies)
- [Ubuntu](linux-ubuntu.md#dependencies)

For generic information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/main/Documentation/self-contained-linux-apps.md).

### RPM dependencies

If your distribution wasn't previously listed, and is RPM-based, you may need the following dependencies:

- krb5-libs
- libicu
- openssl-libs

If the target runtime environment's OpenSSL version is 1.1 or newer, you'll need to install **compat-openssl10**.

### DEB dependencies

If your distribution wasn't previously listed, and is debian-based, you may need the following dependencies:

- libc6
- libgcc1
- libgssapi-krb5-2
- libicu67
- libssl1.1
- libstdc++6
- zlib1g

### Common dependencies

For .NET apps that use the *System.Drawing.Common* assembly, you'll also need the following dependency:

- [libgdiplus (version 6.0.1 or later)](https://www.mono-project.com/docs/gui/libgdiplus/)

  > [!WARNING]
  > You can install a recent version of *libgdiplus* by adding the Mono repository to your system. For more information, see <https://www.mono-project.com/download/stable/>.

## Scripted install

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the **SDK** and **Runtime**. You can download the script from <https://dot.net/v1/dotnet-install.sh>.

> [!IMPORTANT]
> Bash is required to run the script.

Before running this script, you'll need to grant permission for this script to run as an executable:

```bash
sudo chmod +x ./dotnet-install.sh
```

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) SDK version, which is .NET 6. To install the latest release, which may not be an (LTS) version, use the `--version latest` parameter.

```bash
./dotnet-install.sh --version latest
```

To install .NET Runtime instead of the SDK, use the `--runtime` parameter.

```bash
./dotnet-install.sh --version latest --runtime aspnetcore
```

You can install a specific major version with the `--channel` parameter to indicate the specific version. The following command installs .NET 7.0 SDK.

```bash
./dotnet-install.sh --channel 7.0
```

For more information, see [dotnet-install scripts reference](../tools/dotnet-install-script.md).

## Manual install

<!-- Note, this content is copied in macos.md. Any fixes should be applied there too, though content may be different -->

As an alternative to the package managers, you can download and manually install the SDK and runtime. Manual installation is commonly used as part of continuous integration testing or on an unsupported Linux distribution. For a developer or user, it's better to use a package manager.

First, download a **binary** release for either the SDK or the runtime from one of the following sites. If you install the .NET SDK, you will not need to install the corresponding runtime:

- ✔️ [.NET 7 downloads](https://dotnet.microsoft.com/download/dotnet/7.0)
- ✔️ [.NET 6 downloads](https://dotnet.microsoft.com/download/dotnet/6.0)
- ✔️ [.NET Core 3.1 downloads](https://dotnet.microsoft.com/download/dotnet/3.1)
- [All .NET Core downloads](https://dotnet.microsoft.com/download/dotnet)

Next, extract the downloaded file and use the `export` command to set `DOTNET_ROOT` to the extracted folder's location and then ensure .NET is in PATH. This should make the .NET CLI commands available at the terminal.

Alternatively, after downloading the .NET binary, the following commands may be run from the directory where the file is saved to extract the runtime. This will also make the .NET CLI commands available at the terminal and set the required environment variables. **Remember to change the `DOTNET_FILE` value to the name of the downloaded binary**:

```bash
DOTNET_FILE=dotnet-sdk-7.0.100-linux-x64.tar.gz
export DOTNET_ROOT=$(pwd)/.dotnet

mkdir -p "$DOTNET_ROOT" && tar zxf "$DOTNET_FILE" -C "$DOTNET_ROOT"

export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
```

This approach lets you install different versions into separate locations and choose explicitly which one to use by which application.

### Set environment variables system-wide

If you used the previous install script, the variables set only apply to your current terminal session. Add them to your shell profile. There are a number of different shells available for Linux and each has a different profile. For example:

- **Bash Shell**: *~/.bash_profile*, *~/.bashrc*
- **Korn Shell**: *~/.kshrc* or *.profile*
- **Z Shell**: *~/.zshrc* or *.zprofile*

Set the following two environment variables in your shell profile:

- `DOTNET_ROOT`

  This variable is set to the folder .NET was installed to, such as `$HOME/.dotnet`:

  ```bash
  export DOTNET_ROOT=$HOME/.dotnet
  ```

- `PATH`

  This variable should include both the `DOTNET_ROOT` folder and the user's _.dotnet/tools_ folder:

  ```bash
  export PATH=$PATH:$HOME/.dotnet:$HOME/.dotnet/tools
  ```

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
