---
title: Manually install .NET on Linux - .NET
description: Demonstrates how to install the .NET SDK and the .NET Runtime without a package manager on Linux. Use the install script or manually extract the binaries.
author: adegeo
ms.author: adegeo
ms.date: 01/06/2021
---

# Install the .NET SDK or the .NET Runtime manually

.NET is supported on Linux and this article describes how to install .NET on Linux using the install script or by extracting the binaries. For a list of distributions that support the built-in package manager, see [Install .NET on Linux](linux.md).

You can also install .NET with snap. For more information, see [Install the .NET SDK or the .NET Runtime with Snap](linux-snap.md).

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## .NET releases

The following table lists the .NET (and .NET Core) releases:

| ✔️ Supported | ❌ Unsupported |
|-------------|---------------|
| 5.0         | 3.0           |
| 3.1 (LTS)   | 2.2           |
| 2.1 (LTS)   | 2.0           |
|             | 1.1           |
|             | 1.0           |

For more information about the life cycle of .NET releases, see [.NET Core and .NET 5 Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## Dependencies

It's possible that when you install .NET, specific dependencies may not be installed, such as when [manually installing](#manual-install). The following list details Linux distributions that are supported by Microsoft and have dependencies you may need to install. Check the distribution page for more information:

- [Alpine](linux-alpine.md#dependencies)
- [Debian](linux-debian.md#dependencies)
- [CentOS](linux-centos.md#dependencies)
- [Fedora](linux-fedora.md#dependencies)
- [RHEL](linux-rhel.md#dependencies)
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

> ![IMPORTANT]
> Bash is required to run the script.

The script defaults to installing the latest SDK [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. To install the current release, which may not be an (LTS) version, use the `-c Current` parameter.

```bash
./dotnet-install.sh -c Current
```

To install .NET Runtime instead of the SDK, use the `--runtime` parameter.

```bash
./dotnet-install.sh -c Current --runtime aspnetcore
```

You can install a specific version by altering the `-c` parameter to indicate the specific version. The following command installs .NET SDK 5.0.

```bash
./dotnet-install.sh -c 5.0
```

For more information, see [dotnet-install scripts reference](../tools/dotnet-install-script.md).

## Manual install

<!-- Note, this content is copied in macos.md. Any fixes should be applied there too, though content may be different -->

As an alternative to the package managers, you can download and manually install the SDK and runtime. Manual install is commonly used as part of continuous integration testing or on an unsupported Linux distribution. For a developer or user, it's better to use a package manager.

If you install .NET SDK, you don't need to install the corresponding runtime. First, download a **binary** release for either the SDK or the runtime from one of the following sites:

- ✔️ [.NET 5.0 downloads](https://dotnet.microsoft.com/download/dotnet/5.0)
- ✔️ [.NET Core 3.1 downloads](https://dotnet.microsoft.com/download/dotnet/3.1)
- ✔️ [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet/2.1)
- [All .NET Core downloads](https://dotnet.microsoft.com/download/dotnet)

Next, extract the downloaded file and use the `export` command to set variables used by .NET and then ensure .NET is in PATH.

To extract the runtime and make the .NET CLI commands available at the terminal, first download a .NET binary release. Then, open a terminal and run the following commands from the directory where the file was saved. The archive file name may be different depending on what you downloaded.

**Use the following commands to extract the runtime or SDK that you downloaded.** Remember to change the `DOTNET_FILE` value to your file name:

```bash
DOTNET_FILE=dotnet-sdk-5.0.102-linux-x64.tar.gz
export DOTNET_ROOT=$HOME/dotnet

mkdir -p "$DOTNET_ROOT" && tar zxf "$DOTNET_FILE" -C "$DOTNET_ROOT"

export PATH=$PATH:$DOTNET_ROOT
```

> [!TIP]
> The preceding `export` commands only make the .NET CLI commands available for the terminal session in which it was run.
>
> You can edit your shell profile to permanently add the commands. There are a number of different shells available for Linux and each has a different profile. For example:
>
> - **Bash Shell**: *~/.bash_profile*, *~/.bashrc*
> - **Korn Shell**: *~/.kshrc* or *.profile*
> - **Z Shell**: *~/.zshrc* or *.zprofile*
>
> Edit the appropriate source file for your shell and add `:$HOME/dotnet` to the end of the existing `PATH` statement. If no `PATH` statement is included, add a new line with `export PATH=$PATH:$HOME/dotnet`.
>
> Also, add `export DOTNET_ROOT=$HOME/dotnet` to the end of the file.

This approach lets you install different versions into separate locations and choose explicitly which one to use by which application.

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
