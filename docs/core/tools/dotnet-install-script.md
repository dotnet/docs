---
title: dotnet-install scripts
description: Learn about the dotnet-install scripts to install the .NET Core CLI tools and the shared runtime.
ms.date: 01/16/2019
---
# dotnet-install scripts reference

## Name

`dotnet-install.ps1` | `dotnet-install.sh` - Script used to install the .NET Core CLI tools and the shared runtime.

## Synopsis

Windows:

`dotnet-install.ps1 [-Channel] [-Version] [-InstallDir] [-Architecture] [-SharedRuntime] [-Runtime] [-DryRun] [-NoPath] [-Verbose] [-AzureFeed] [-UncachedFeed] [-NoCdn] [-FeedCredential] [-ProxyAddress] [-ProxyUseDefaultCredentials] [-SkipNonVersionedFiles] [-Help]`

macOS/Linux:

`dotnet-install.sh [--channel] [--version] [--install-dir] [--architecture] [--runtime] [--dry-run] [--no-path] [--verbose] [--azure-feed] [--uncached-feed] [--no-cdn] [--feed-credential] [--runtime-id] [--skip-non-versioned-files] [--help]`

## Description

The `dotnet-install` scripts are used to perform a non-admin installation of the .NET Core SDK, which includes the .NET Core CLI tools and the shared runtime.

We recommend that you use the stable version that is hosted on [.NET Core main website](https://dot.net). The direct paths to the scripts are:

* <https://dot.net/v1/dotnet-install.sh> (bash, UNIX)
* <https://dot.net/v1/dotnet-install.ps1> (Powershell, Windows)

The main usefulness of these scripts is in automation scenarios and non-admin installations. There are two scripts: one is a PowerShell script that works on Windows, and the other is a bash script that works on Linux/macOS. Both scripts have the same behavior. The bash script also reads PowerShell switches, so you can use PowerShell switches with the script on Linux/macOS systems.

The installation scripts download the ZIP/tarball file from the CLI build drops and proceed to install it in either the default location or in a location specified by `-InstallDir|--install-dir`. By default, the installation scripts download the SDK and install it. If you wish to only obtain the shared runtime, specify the `--runtime` argument.

By default, the script adds the install location to the $PATH for the current session. Override this default behavior by specifying the `--no-path` argument.

Before running the script, install the required [dependencies](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md).

You can install a specific version using the `--version` argument. The version must be specified as a three-part version (for example, 1.0.0-13232). If not provided, it uses the `latest` version.

## Options

* **`-Channel <CHANNEL>`**

  Specifies the source channel for the installation. The possible values are:

  * `Current` - Most current release.
  * `LTS` - Long-Term Support channel (most current supported release).
  * Two-part version in X.Y format representing a specific release (for example, `2.0` or `1.0`).
  * Branch name. For example, `release/2.0.0`, `release/2.0.0-preview2`, or `master` (for nightly releases).

  The default value is `LTS`. For more information on .NET support channels, see the [.NET Support Policy](https://www.microsoft.com/net/platform/support-policy#dotnet-core) page.

* **`-Version <VERSION>`**

  Represents a specific build version. The possible values are:

  * `latest` - Latest build on the channel (used with the `-Channel` option).
  * `coherent` - Latest coherent build on the channel; uses the latest stable package combination (used with Branch name `-Channel` options).
  * Three-part version in X.Y.Z format representing a specific build version; supersedes the `-Channel` option. For example: `2.0.0-preview2-006120`.

  If not specified, `-Version` defaults to `latest`.

* **`-InstallDir <DIRECTORY>`**

  Specifies the installation path. The directory is created if it doesn't exist. The default value is *%LocalAppData%\Microsoft\dotnet*. Binaries are placed directly in this directory.

* **`-Architecture <ARCHITECTURE>`**

  Architecture of the .NET Core binaries to install. Possible values are `<auto>`, `amd64`, `x64`, `x86`, `arm64`, and `arm`. The default value is `<auto>`, which represents the currently running OS architecture.

* **`-SharedRuntime`**

  > [!NOTE]
  > This parameter is obsolete and may be removed in a future version of the script. The recommended alternative is the `Runtime` option.

  Installs just the shared runtime bits, not the entire SDK. This is equivalent to specifying `-Runtime dotnet`.

* **`-Runtime <RUNTIME>`**

  Installs just the shared runtime, not the entire SDK. The possible values are:

  * `dotnet` - the `Microsoft.NETCore.App` shared runtime.
  * `aspnetcore` - the `Microsoft.AspNetCore.App` shared runtime.

* **`-DryRun`**

  If set, the script won't perform the installation. Instead, it displays what command line to use to consistently install the currently requested version of the .NET Core CLI. For example, if you specify version `latest`, it displays a link with the specific version so that this command can be used deterministically in a build script. It also displays the binary's location if you prefer to install or download it yourself.

* **`-NoPath`**

  If set, the installation folder isn't exported to the path for the current session. By default, the script modifies the PATH, which makes the CLI tools available immediately after install.

* **`-Verbose`**

  Displays diagnostics information.

* **`-AzureFeed`**

  Specifies the URL for the Azure feed to the installer. We recommended that you don't change this value. The default value is `https://dotnetcli.azureedge.net/dotnet`.

* **`-UncachedFeed`**

  Allows changing the URL for the uncached feed used by this installer. We recommended that you don't change this value.

* **`-NoCdn`**

  Disables downloading from the [Azure Content Delivery Network (CDN)](https://docs.microsoft.com/azure/cdn/cdn-overview) and uses the uncached feed directly.

* **`-FeedCredential`**

  Used as a query string to append to the Azure feed. It allows changing the URL to use non-public blob storage accounts.

* **`-ProxyAddress`**

  If set, the installer uses the proxy when making web requests. (Only valid for Windows)

* **`ProxyUseDefaultCredentials`**

  If set, the installer uses the credentials of the current user when using proxy address. (Only valid for Windows)

* **`-SkipNonVersionedFiles`**

  Skips installing non-versioned files, such as *dotnet.exe*, if they already exist.

* **`-Help`**

  Prints out help for the script.

## Examples

* Install the latest long-term supported (LTS) version to the default location:

  Windows:

  ```powershell
  ./dotnet-install.ps1 -Channel LTS
  ```

  macOS/Linux:

  ```bash
  ./dotnet-install.sh --channel LTS
  ```

* Install the latest version from 2.0 channel to the specified location:

  Windows:

  ```powershell
  ./dotnet-install.ps1 -Channel 2.0 -InstallDir C:\cli
  ```

  macOS/Linux:

  ```bash
  ./dotnet-install.sh --channel 2.0 --install-dir ~/cli
  ```

* Install the 1.1.0 version of the shared runtime:

  Windows:

  ```powershell
  ./dotnet-install.ps1 -Runtime dotnet -Version 1.1.0
  ```

  macOS/Linux:

  ```bash
  ./dotnet-install.sh --runtime dotnet --version 1.1.0
  ```

* Obtain script and install the 2.1.2 version behind a corporate proxy (Windows only):

  ```powershell
  Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -Proxy $env:HTTP_PROXY -ProxyUseDefaultCredentials -OutFile 'dotnet-install.ps1';
  ./dotnet-install.ps1 -InstallDir '~/.dotnet' -Version '2.1.2' -ProxyAddress $env:HTTP_PROXY -ProxyUseDefaultCredentials;
  ```

* Obtain script and install .NET Core CLI one-liner examples:

  Windows:

  ```powershell
  @powershell -NoProfile -ExecutionPolicy unrestricted -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; &([scriptblock]::Create((Invoke-WebRequest -useb 'https://dot.net/v1/dotnet-install.ps1'))) <additional install-script args>"
  ```

  macOS/Linux:

  ```bash
  curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin <additional install-script args>
  ```

## See also

- [.NET Core releases](https://github.com/dotnet/core/releases)
- [.NET Core Runtime and SDK download archive](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md)
