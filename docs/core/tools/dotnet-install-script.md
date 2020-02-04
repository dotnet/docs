---
title: dotnet-install scripts
description: Learn about the dotnet-install scripts to install the .NET Core SDK and the shared runtime.
ms.date: 01/23/2020
---
# dotnet-install scripts reference

## Name

`dotnet-install.ps1` | `dotnet-install.sh` - Script used to install the .NET Core SDK and the shared runtime.

## Synopsis

Windows:

```powershell
dotnet-install.ps1 [-Channel] [-Version] [-JSonFile] [-InstallDir] [-Architecture]
    [-Runtime] [-DryRun] [-NoPath] [-Verbose] [-AzureFeed] [-UncachedFeed] [-NoCdn] [-FeedCredential]
    [-ProxyAddress] [-ProxyUseDefaultCredentials] [-SkipNonVersionedFiles] [-Help]
```

Linux/macOs:

```bash
dotnet-install.sh [--channel] [--version] [--jsonfile] [--install-dir] [--architecture]
    [--runtime] [--dry-run] [--no-path] [--verbose] [--azure-feed] [--uncached-feed] [--no-cdn] [--feed-credential]
    [--runtime-id] [--skip-non-versioned-files] [--help]
```

## Description

The `dotnet-install` scripts are used to perform a non-admin installation of the .NET Core SDK, which includes the .NET Core CLI tools and the shared runtime.

We recommend that you use the stable version of the scripts:

- Bash (Linux/macOS): <https://dot.net/v1/dotnet-install.sh>
- PowerShell (Windows): <https://dot.net/v1/dotnet-install.ps1>

The main usefulness of these scripts is in automation scenarios and non-admin installations. There are two scripts: one is a PowerShell script that works on Windows, and the other is a bash script that works on Linux/macOS. Both scripts have the same behavior. The bash script also reads PowerShell switches, so you can use PowerShell switches with the script on Linux/macOS systems.

The installation scripts download the ZIP/tarball file from the CLI build drops and proceed to install it in either the default location or in a location specified by `-InstallDir|--install-dir`. By default, the installation scripts download the SDK and install it. If you wish to only obtain the shared runtime, specify the `-Runtime|--runtime` argument.

By default, the script adds the install location to the $PATH for the current session. Override this default behavior by specifying the `-NoPath|--no-path` argument.

Before running the script, install the required [dependencies](../install/dependencies.md).

You can install a specific version using the `-Version|--version` argument. The version must be specified as a three-part version (for example, `2.1.0`). If not provided, it uses the `latest` version.

## Options

- **`-Channel|--channel <CHANNEL>`**

  Specifies the source channel for the installation. The possible values are:

  - `Current` - Most current release.
  - `LTS` - Long-Term Support channel (most current supported release).
  - Two-part version in X.Y format representing a specific release (for example, `2.1` or `3.0`).
  - Branch name: for example, `release/3.1.1xx` or `master` (for nightly releases). Use this option to install a version from a preview channel. Use the name of the channel as listed in [Installers and Binaries](https://github.com/dotnet/core-sdk#installers-and-binaries).

  The default value is `LTS`. For more information on .NET support channels, see the [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) page.

- **`-Version|--version <VERSION>`**

  Represents a specific build version. The possible values are:

  - `latest` - Latest build on the channel (used with the `-Channel` option).
  - `coherent` - Latest coherent build on the channel; uses the latest stable package combination (used with Branch name `-Channel` options).
  - Three-part version in X.Y.Z format representing a specific build version; supersedes the `-Channel` option. For example: `2.0.0-preview2-006120`.

  If not specified, `-Version` defaults to `latest`.

- **`-JSonFile|--jsonfile <JSONFILE>`**

  Specifies a path to a [global.json](global-json.md) file that will be used to determine the SDK version. The *global.json* file must have a value for `sdk:version`.

- **`-InstallDir|--install-dir <DIRECTORY>`**

  Specifies the installation path. The directory is created if it doesn't exist. The default value is *%LocalAppData%\Microsoft\dotnet*. Binaries are placed directly in this directory.

- **`-Architecture|--architecture <ARCHITECTURE>`**

  Architecture of the .NET Core binaries to install. Possible values are `<auto>`, `amd64`, `x64`, `x86`, `arm64`, and `arm`. The default value is `<auto>`, which represents the currently running OS architecture.

- **`-SharedRuntime|--shared-runtime`**

  > [!NOTE]
  > This parameter is obsolete and may be removed in a future version of the script. The recommended alternative is the `-Runtime|--runtime` option.

  Installs just the shared runtime bits, not the entire SDK. This option is equivalent to specifying `-Runtime|--runtime dotnet`.

- **`-Runtime|--runtime <RUNTIME>`**

  Installs just the shared runtime, not the entire SDK. The possible values are:

  - `dotnet` - the `Microsoft.NETCore.App` shared runtime.
  - `aspnetcore` - the `Microsoft.AspNetCore.App` shared runtime.
  - `windowsdesktop` - the `Microsoft.WindowsDesktop.App` shared runtime.

- **`-DryRun|--dry-run`**

  If set, the script won't perform the installation. Instead, it displays what command line to use to consistently install the currently requested version of the .NET Core CLI. For example, if you specify version `latest`, it displays a link with the specific version so that this command can be used deterministically in a build script. It also displays the binary's location if you prefer to install or download it yourself.

- **`-NoPath|--no-path`**

  If set, the installation folder isn't exported to the path for the current session. By default, the script modifies the PATH, which makes the CLI tools available immediately after install.

- **`-Verbose|--verbose`**

  Displays diagnostics information.

- **`-AzureFeed|--azure-feed`**

  Specifies the URL for the Azure feed to the installer. We recommended that you don't change this value. The default value is `https://dotnetcli.azureedge.net/dotnet`.

- **`-UncachedFeed|--uncached-feed`**

  Allows changing the URL for the uncached feed used by this installer. We recommended that you don't change this value.

- **`-NoCdn|--no-cdn`**

  Disables downloading from the [Azure Content Delivery Network (CDN)](https://docs.microsoft.com/azure/cdn/cdn-overview) and uses the uncached feed directly.

- **`-FeedCredential|--feed-credential`**

  Used as a query string to append to the Azure feed. It allows changing the URL to use non-public blob storage accounts.

- **`--runtime-id`**

  Specifies the [runtime identifier](../rid-catalog.md) for which the tools are being installed. Use `linux-x64` for portable Linux. (Only valid for Linux/macOS)

- **`-ProxyAddress`**

  If set, the installer uses the proxy when making web requests. (Only valid for Windows)

- **`ProxyUseDefaultCredentials`**

  If set, the installer uses the credentials of the current user when using proxy address. (Only valid for Windows)

- **`-SkipNonVersionedFiles|--skip-non-versioned-files`**

  Skips installing non-versioned files, such as *dotnet.exe*, if they already exist.

- **`-Help|--help`**

  Prints out help for the script.

## Examples

- Install the latest long-term supported (LTS) version to the default location:

  Windows:

  ```powershell
  ./dotnet-install.ps1 -Channel LTS
  ```

  macOS/Linux:

  ```bash
  ./dotnet-install.sh --channel LTS
  ```

- Install the latest version from 3.1 channel to the specified location:

  Windows:

  ```powershell
  ./dotnet-install.ps1 -Channel 3.1 -InstallDir C:\cli
  ```

  macOS/Linux:

  ```bash
  ./dotnet-install.sh --channel 3.1 --install-dir ~/cli
  ```

- Install the 3.0.0 version of the shared runtime:

  Windows:

  ```powershell
  ./dotnet-install.ps1 -Runtime dotnet -Version 3.0.0
  ```

  macOS/Linux:

  ```bash
  ./dotnet-install.sh --runtime dotnet --version 3.0.0
  ```

- Obtain script and install the 2.1.2 version behind a corporate proxy (Windows only):

  ```powershell
  Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -Proxy $env:HTTP_PROXY -ProxyUseDefaultCredentials -OutFile 'dotnet-install.ps1';
  ./dotnet-install.ps1 -InstallDir '~/.dotnet' -Version '2.1.2' -ProxyAddress $env:HTTP_PROXY -ProxyUseDefaultCredentials;
  ```

- Obtain script and install .NET Core CLI one-liner examples:

  Windows:

  ```powershell
  # Run a separate PowerShell process because the script calls exit, so it will end the current PowerShell session.
  &powershell -NoProfile -ExecutionPolicy unrestricted -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; &([scriptblock]::Create((Invoke-WebRequest -UseBasicParsing 'https://dot.net/v1/dotnet-install.ps1'))) <additional install-script args>"
  ```

  macOS/Linux:

  ```bash
  curl -ssl https://dot.net/v1/dotnet-install.sh | bash /dev/stdin <additional install-script args>
  ```

## See also

- [.NET Core releases](https://github.com/dotnet/core/releases)
- [.NET Core Runtime and SDK download archive](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md)
