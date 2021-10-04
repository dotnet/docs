---
title: dotnet-install scripts
description: Learn about the dotnet-install scripts to install the .NET SDK and the shared runtime.
ms.date: 08/25/2021
---
# dotnet-install scripts reference

## Name

`dotnet-install.ps1` | `dotnet-install.sh` - Script used to install the .NET SDK and the shared runtime.

## Synopsis

Windows:

```powershell
dotnet-install.ps1 [-Architecture <ARCHITECTURE>] [-AzureFeed]
    [-Channel <CHANNEL>] [-DryRun] [-FeedCredential]
    [-InstallDir <DIRECTORY>] [-JSonFile <JSONFILE>]
    [-NoCdn] [-NoPath] [-ProxyAddress] [-ProxyBypassList <LIST_OF_URLS>]
    [-ProxyUseDefaultCredentials] [-Quality <QUALITY>] [-Runtime <RUNTIME>]
    [-SkipNonVersionedFiles] [-UncachedFeed] [-Verbose]
    [-Version <VERSION>]

Get-Help ./dotnet-install.ps1
```

Linux/macOS:

```bash
dotnet-install.sh  [--architecture <ARCHITECTURE>] [--azure-feed]
    [--channel <CHANNEL>] [--dry-run] [--feed-credential]
    [--install-dir <DIRECTORY>] [--jsonfile <JSONFILE>]
    [--no-cdn] [--no-path] [--quality <QUALITY>]
    [--runtime <RUNTIME>] [--runtime-id <RID>]
    [--skip-non-versioned-files] [--uncached-feed] [--verbose]
    [--version <VERSION>]

dotnet-install.sh --help
```

The bash script also reads PowerShell switches, so you can use PowerShell switches with the script on Linux/macOS systems.

## Description

The `dotnet-install` scripts perform a non-admin installation of the .NET SDK, which includes the .NET CLI and the shared runtime. There are two scripts:

* A PowerShell script that works on Windows.
* A bash script that works on Linux/macOS.

> [!NOTE]
> .NET collects telemetry data. To learn more and how to opt out, see [.NET SDK telemetry](telemetry.md).

### Purpose

 The intended use of the scripts is for Continuous Integration (CI) scenarios, where:

* The SDK needs to be installed without user interaction and without admin rights.
* The SDK installation doesn't need to persist across multiple CI runs.

  The typical sequence of events:
  * CI is triggered.
  * CI installs the SDK using one of these scripts.
  * CI finishes its work and clears temporary data including the SDK installation.

To set up a development environment or to run apps, use the installers rather than these scripts.

### Recommended version

We recommend that you use the stable version of the scripts:

- Bash (Linux/macOS): <https://dot.net/v1/dotnet-install.sh>
- PowerShell (Windows): <https://dot.net/v1/dotnet-install.ps1>

### Script behavior

Both scripts have the same behavior. They download the ZIP/tarball file from the CLI build drops and proceed to install it in either the default location or in a location specified by `-InstallDir|--install-dir`.

By default, the installation scripts download the SDK and install it. If you wish to only obtain the shared runtime, specify the `-Runtime|--runtime` argument.

By default, the script adds the install location to the $PATH for the current session. Override this default behavior by specifying the `-NoPath|--no-path` argument. The script doesn't set the `DOTNET_ROOT` environment variable.

Before running the script, install the required [dependencies](../install/windows.md#dependencies).

You can install a specific version using the `-Version|--version` argument. The version must be specified as a three-part version number, such as `2.1.0`. If the version isn't specified, the script installs the `latest` version.

The install scripts do not update the registry on Windows. They just download the zipped binaries and copy them to a folder. If you want registry key values to be updated, use the .NET installers.

## Options

- **`-Architecture|--architecture <ARCHITECTURE>`**

  Architecture of the .NET binaries to install. Possible values are `<auto>`, `amd64`, `x64`, `x86`, `arm64`, and `arm`. The default value is `<auto>`, which represents the currently running OS architecture.

- **`-AzureFeed|--azure-feed`**

  Specifies the URL for the Azure feed to the installer. We recommended that you don't change this value. The default value is `https://dotnetcli.azureedge.net/dotnet`.

- **`-Channel|--channel <CHANNEL>`**

  Specifies the source channel for the installation. The possible values are:

  - `Current` - Most current release.
  - `LTS` - Long-Term Support channel (most current supported release).
  - Two-part version in A.B format, representing a specific release (for example, `2.1` or `3.0`).
  - Three-part version in A.B.Cxx format, representing a specific SDK release (for example, 5.0.1xx or 5.0.2xx). Available since the 5.0 release.

  The `version` parameter overrides the `channel` parameter when any version other than `latest` is used.

  The default value is `LTS`. For more information on .NET support channels, see the [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) page.

- **`-DryRun|--dry-run`**

  If set, the script won't perform the installation. Instead, it displays what command line to use to consistently install the currently requested version of the .NET CLI. For example, if you specify version `latest`, it displays a link with the specific version so that this command can be used deterministically in a build script. It also displays the binary's location if you prefer to install or download it yourself.

- **`-FeedCredential|--feed-credential`**

  Used as a query string to append to the Azure feed. It allows changing the URL to use non-public blob storage accounts.

- **`--help`**

  Prints out help for the script. Applies only to bash script. For PowerShell, use `Get-Help ./dotnet-install.ps1`.

- **`-InstallDir|--install-dir <DIRECTORY>`**

  Specifies the installation path. The directory is created if it doesn't exist. The default value is *%LocalAppData%\Microsoft\dotnet* on Windows and */usr/share/dotnet* on Linux/macOS. Binaries are placed directly in this directory.

- **`-JSonFile|--jsonfile <JSONFILE>`**

  Specifies a path to a [global.json](global-json.md) file that will be used to determine the SDK version. The *global.json* file must have a value for `sdk:version`.

- **`-NoCdn|--no-cdn`**

  Disables downloading from the [Azure Content Delivery Network (CDN)](/azure/cdn/cdn-overview) and uses the uncached feed directly.

- **`-NoPath|--no-path`**

  If set, the installation folder isn't exported to the path for the current session. By default, the script modifies the PATH, which makes the .NET CLI available immediately after install.

- **`-ProxyAddress`**

  If set, the installer uses the proxy when making web requests. (Only valid for Windows.)

- **`-ProxyBypassList <LIST_OF_URLS>`**

  If set with `ProxyAddress`, provides a list of comma-separated urls that will bypass the proxy. (Only valid for Windows.)

- **`ProxyUseDefaultCredentials`**

  If set, the installer uses the credentials of the current user when using proxy address. (Only valid for Windows.)

- **`-Quality|--quality <QUALITY>`**

  Downloads the latest build of the specified quality in the channel. The possible values are: `daily`, `signed`, `validated`, `preview`, `GA`. Works only in combination with `channel`. Not applicable for current and LTS channels and will be ignored if one of those channels is used.

  For an SDK installation, use `channel` in `A.B` or `A.B.Cxx` format.
  For a runtime installation, use `channel` in `A.B` format.

  The `version` parameter overrides the `channel` and `quality` parameters when any `version` other than `latest` is used.

  Available since since the 5.0 release.

- **`-Runtime|--runtime <RUNTIME>`**

  Installs just the shared runtime, not the entire SDK. The possible values are:

  - `dotnet` - the `Microsoft.NETCore.App` shared runtime.
  - `aspnetcore` - the `Microsoft.AspNetCore.App` shared runtime.
  - `windowsdesktop` - the `Microsoft.WindowsDesktop.App` shared runtime.

- **`--runtime-id <RID>` [Deprecated]**

  Specifies the [runtime identifier](../rid-catalog.md) for which the tools are being installed. Use `linux-x64` for portable Linux. (Only valid for Linux/macOS and for versions earlier than .NET Core 2.1.)

  **`--os <OPERATING_SYSTEM>`**

  Specifies the operating system for which the tools are being installed. Possible values are: `osx`, `linux`, `linux-musl`, `freebsd`, `rhel.6`. (Valid for .NET Core 2.1 and later.)

  The parameter is optional and should only be used when it's required to override the operating system that is detected by the script.

- **`-SharedRuntime|--shared-runtime`**

  > [!NOTE]
  > This parameter is obsolete and may be removed in a future version of the script. The recommended alternative is the `-Runtime|--runtime` option.

  Installs just the shared runtime bits, not the entire SDK. This option is equivalent to specifying `-Runtime|--runtime dotnet`.

- **`-SkipNonVersionedFiles|--skip-non-versioned-files`**

  Skips installing non-versioned files, such as *dotnet.exe*, if they already exist.

- **`-UncachedFeed|--uncached-feed`**

  Allows changing the URL for the uncached feed used by this installer. We recommended that you don't change this value.

- **`-Verbose|--verbose`**

  Displays diagnostics information.

- **`-Version|--version <VERSION>`**

  Represents a specific build version. The possible values are:

  - `latest` - Latest build on the channel (used with the `-Channel` option).
  - Three-part version in X.Y.Z format representing a specific build version; supersedes the `-Channel` option. For example: `2.0.0-preview2-006120`.

  If not specified, `-Version` defaults to `latest`.

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

- Install the latest preview version of the 6.0.1xx SDK to the specified location:

  Windows:

  ```powershell
  ./dotnet-install.ps1 -Channel 6.0.1xx -Quality preview -InstallDir C:\cli
  ```

  macOS/Linux:

  ```bash
  ./dotnet-install.sh --channel 6.0.1xx --quality preview --install-dir ~/cli
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

- Obtain script and install .NET CLI one-liner examples:

  Windows:

  ```powershell
  # Run a separate PowerShell process because the script calls exit, so it will end the current PowerShell session.
  &powershell -NoProfile -ExecutionPolicy unrestricted -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; &([scriptblock]::Create((Invoke-WebRequest -UseBasicParsing 'https://dot.net/v1/dotnet-install.ps1'))) <additional install-script args>"
  ```

  macOS/Linux:

  ```bash
  curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin <additional install-script args>
  ```

## See also

- [.NET releases](https://github.com/dotnet/core/releases)
- [.NET Runtime and SDK download archive](https://github.com/dotnet/core/tree/main/release-notes/download-archives)
