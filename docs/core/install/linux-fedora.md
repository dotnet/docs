---
title: Install .NET Core on Fedora - .NET Core
description: Demonstrates the various ways to install .NET Core SDK and .NET Core Runtime on Fedora.
author: thraka
ms.author: adegeo
ms.date: 06/01/2020
---

# Install .NET Core SDK and .NET Core Runtime on Fedora

.NET Core is supported on Fedora. This article describes how to install .NET Core on Fedora. When a Fedora version falls out of support, .NET Core is no longer supported with that version. However, these instructions may help you to get .NET Core running on those versions, even though it isn't supported.

## Supported distributions

The following is a list of currently supported .NET Core releases and the versions of Fedora they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Fedora reaches end-of-life](https://fedoraproject.org/wiki/End_of_life).

For the best compatibility, choose a long-term release (LTS) version of .NET Core.

| .NET Core   | Fedora version |
|-------------|----------------|
| 2.1 (LTS)   | [30*](#fedora-30-), [31](#fedora-31-)        |
| 3.1 (LTS)   | [30*](#fedora-30-), [31](#fedora-31-), [32](#fedora-32-)    |
| 5.0 Preview | [31](#fedora-31-), [32](#fedora-32-)         |

*Fedora version 30 is currently end-of-life.

The following table is a list of .NET Core versions which are ❌ no longer supported. The downloads for these still remain. The Ubuntu version listed is the *last* LTS release they were supported on:

| .NET Core | Fedora version |
|-----------|----------------|
| 3.0       | [30](#fedora-30-), [31](#fedora-31-)         |
| 2.2       | [29](#fedora-29-), [30](#fedora-30-)         |
| 2.0       | [27](#fedora-27-), [28](#fedora-28-)         |

## Fedora 32 ✔️

.NET Core 3.1 is available in the default package repositories in Fedora.

[!INCLUDE [linux-dnf-install-31](includes/linux-install-31-dnf.md)]

## Fedora 31 ✔️

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo wget -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/31/prod.repo
```

[!INCLUDE [linux-dnf-install-31](includes/linux-install-31-dnf.md)]

## Fedora 30 ❌

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo wget -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/30/prod.repo
```

[!INCLUDE [linux-dnf-install-31](includes/linux-install-31-dnf.md)]

## Fedora 29 ❌

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo wget -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/29/prod.repo
```

[!INCLUDE [linux-dnf-install-30](includes/linux-install-30-dnf.md)]

## Fedora 28 ❌

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo wget -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/28/prod.repo
```

[!INCLUDE [linux-dnf-install-20](includes/linux-install-20-dnf.md)]

## Fedora 27 ❌

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo wget -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/27/prod.repo
```

[!INCLUDE [linux-dnf-install-20](includes/linux-install-20-dnf.md)]

## Snap

[!INCLUDE [linux-install-snap](includes/linux-install-snap.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET Core or you publish a self-contained app, you'll need to make sure these libraries are installed:

- lttng-ust
- libcurl
- openssl-libs
- krb5-libs
- libicu
- zlib
- libunwind
- libuuid

If your OpenSSL's version >= 1.1, you'll need to install **compat-openssl10**.

For more information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/master/Documentation/self-contained-linux-apps.md).

For .NET Core apps that use the *System.Drawing.Common* assembly, you'll also need the following dependency:

- libgdiplus (version 6.0.1 or later)

> [!WARNING]
> Most versions of Fedora use an earlier version of *libgdiplus*. You can install a recent version
> of *libgdiplus* by adding the Mono repository to your system. For more information,
> see <https://www.mono-project.com/download/stable/>.

## Scripted install

[!INCLUDE [linux-install-scripted](includes/linux-install-scripted.md)]

## Manual install

[!INCLUDE [linux-install-manual](includes/linux-install-manual.md)]

## Next steps

- [Tutorial: Create a console application with .NET Core using Visual Studio Code](../tutorials/with-visual-studio-code.md)
