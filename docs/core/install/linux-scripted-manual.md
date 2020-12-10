---
title: Manually install .NET on Linux - .NET
description: Demonstrates how to install the .NET SDK and the .NET Runtime without a package manager on Linux. Use the install script or manually extract the binaries.
author: adegeo
ms.author: adegeo
ms.date: 12/10/2020
---

# Install the .NET SDK or the .NET Runtime manually

.NET is supported on Linux and this article describes how to install .NET on Linux using the install script or by extracting the binaries. For a list of distributions that support the built-in package manager, see [Install .NET on Linux](linux.md).

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## .NET releases

The following table lists the .NET (and .NET Core) releases and whether or not they're still supported by Microsoft:

| ✔️ Supported | ❌ Unsupported |
|-------------|---------------|
| 5.0         | 3.0           |
| 3.1 (LTS)   | 2.2           |
| 2.1 (LTS)   | 2.0           |
|             | 1.1           |
|             | 1.0           |

For more information about the life-cycle of .NET releases, see [.NET Core and .NET 5 Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## Dependencies

It's possible that when you install .NET, these libraries may not be installed too, such as described in the [manual install](#manual-install) section. Make sure the following libraries are installed:

- libc6
- libgcc1
- libgssapi-krb5-2
- The latest version of **libicu** supported by your distro.
- libssl1.1
- libstdc++6
- zlib1g

For .NET apps that use the *System.Drawing.Common* assembly, you also need the following dependency:

- libgdiplus (version 6.0.1 or later)

  > [!WARNING]
  > You can install a recent version of *libgdiplus* by adding the Mono repository to your system. For more information, see <https://www.mono-project.com/download/stable/>.

## Scripted install

[!INCLUDE [linux-install-scripted](includes/linux-install-scripted.md)]

## Manual install

[!INCLUDE [linux-install-manual](includes/linux-install-manual.md)]

## Next steps

- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
- [Install the .NET SDK or the .NET Runtime with Snap](linux-snap.md)
