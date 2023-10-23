---
title: dotnet-install scripts
description: Learn about the dotnet-install scripts to install the .NET SDK and the shared runtime.
ms.date: 08/01/2023
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

* A PowerShell script that works on Windows. For installation instructions, see [Install on Windows](../install/windows.md#install-with-powershell-automation).
* A bash script that works on Linux/macOS. For installation instructions, see [Install on Linux](../install/linux-scripted-manual.md#scripted-install) and [Install on macOS](../install/macos.md#install-with-bash-automation).

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

> [!IMPORTANT]
> The script doesn't add the install location to the user's `PATH` environment variable, you must manually add it.

Before running the script, install the required [dependencies](../install/windows.md#dependencies).

You can install a specific version using the `-Version|--version` argument. The version must be specified as a three-part version number, such as `2.1.0`. If the version isn't specified, the script installs the `latest` version.

The install scripts do not update the registry on Windows. They just download the zipped binaries and copy them to a folder. If you want registry key values to be updated, use the .NET installers.

## Options

- **`-Architecture|--architecture <ARCHITECTURE>`**

  Architecture of the .NET binaries to install. Possible values are `<auto>`, `amd64`, `x64`, `x86`, `arm64`, `arm`, `s390x`, and `ppc64le`. The default value is `<auto>`, which represents the currently running OS architecture.

- **`-AzureFeed|--azure-feed`**

  For internal use only. Allows using a different storage to download SDK archives from. This parameter is only used if --no-cdn is false. The default is `https://dotnetcli.azureedge.net/dotnet`.

- **`-Channel|--channel <CHANNEL>`**

  Specifies the source channel for the installation. The possible values are:

  - `STS`: The most recent Standard Term Support release.
  - `LTS`: The most recent Long Term Support release.
  - Two-part version in A.B format, representing a specific release (for example, `3.1` or `6.0`).
  - Three-part version in A.B.Cxx format, representing a specific SDK release (for example, 6.0.1xx or 6.0.2xx). Available since the 5.0 release.

  The `version` parameter overrides the `channel` parameter when any version other than `latest` is used.

  The default value is `LTS`. For more information on .NET support channels, see the [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) page.

- **`-DryRun|--dry-run`**

  If set, the script won't perform the installation. Instead, it displays what command line to use to consistently install the currently requested version of the .NET CLI. For example, if you specify version `latest`, it displays a link with the specific version so that this command can be used deterministically in a build script. It also displays the binary's location if you prefer to install or download it yourself.

- **`-FeedCredential|--feed-credential`**

  Used as a query string to append to the Azure feed. It allows changing the URL to use non-public blob storage accounts.

- **`--help`**

  Prints out help for the script. Applies only to bash script. For PowerShell, use `Get-Help ./dotnet-install.ps1`.

- **`-InstallDir|--install-dir <DIRECTORY>`**

  Specifies the installation path. The directory is created if it doesn't exist. The default value is *%LocalAppData%\Microsoft\dotnet* on Windows and *$HOME/.dotnet* on Linux/macOS. Binaries are placed directly in this directory.

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

- **`-ProxyUseDefaultCredentials`**

  If set, the installer uses the credentials of the current user when using proxy address. (Only valid for Windows.)

- **`-Quality|--quality <QUALITY>`**

  Downloads the latest build of the specified quality in the channel. The possible values are: `daily`, `signed`, `validated`, `preview`, and `GA`. Most users should use `daily`, `preview`, or `GA` qualities.

  The different quality values signal different stages of the release process of the SDK or Runtime installed.

  * `daily`: The latest builds of the SDK or Runtime. They're built every day and aren't tested. They aren't recommended for production use but can often be used to test specific features or fixes immediately after they are merged into the product. These builds are from the `dotnet/installer` repo, and so if you're looking for fixes from `dotnet/sdk` you must wait for code to flow and be merged from SDK to Installer before it appears in a daily build.
  * `signed`: Microsoft-signed builds that aren't validated or publicly released. Signed builds are candidates for validation, preview, and GA release. This quality level is not intended for public use.
  * `validated`: Builds that have had some internal testing done on them but are not yet released as preview or GA. This quality level is not intended for public use.
  * `preview`: The monthly public releases of the next version of .NET, intended for public use. Not recommended for production use. Intended to allow users to experiment and test the new major version before release.
  * `GA`: The final stable releases of the .NET SDK and Runtime. Intended for public use as well as production support.
  
  The `--quality` option works only in combination with `--channel`, but is not applicable for the `STS` and `LTS` channels and will be ignored if one of those channels is used.

  For an SDK installation, use a `channel` value that is in `A.B` or `A.B.Cxx` format.
  For a runtime installation, use `channel` in `A.B` format.

  Don't use both `version` and `quality` parameters. When `quality` is specified, the script determines the proper version on its own.

  Available since the 5.0 release.

- **`-Runtime|--runtime <RUNTIME>`**

  Installs just the shared runtime, not the entire SDK. The possible values are:

  - `dotnet`: The `Microsoft.NETCore.App` shared runtime.
  - `aspnetcore`: The `Microsoft.AspNetCore.App` shared runtime.
  - `windowsdesktop` The `Microsoft.WindowsDesktop.App` shared runtime.

- **`--os <OPERATING_SYSTEM>`**

  Specifies the operating system for which the tools are being installed. Possible values are: `osx`, `linux`, `linux-musl`, `freebsd`.

  The parameter is optional and should only be used when it's required to override the operating system that is detected by the script.

- **`-SharedRuntime|--shared-runtime`**

  > [!NOTE]
  > This parameter is obsolete and may be removed in a future version of the script. The recommended alternative is the `-Runtime|--runtime` option.

  Installs just the shared runtime bits, not the entire SDK. This option is equivalent to specifying `-Runtime|--runtime dotnet`.

- **`-SkipNonVersionedFiles|--skip-non-versioned-files`**

  Skips installing non-versioned files, such as *dotnet.exe*, if they already exist.

- **`-UncachedFeed|--uncached-feed`**

  For internal use only. Allows using a different storage to download SDK archives from. This parameter is only used if --no-cdn is true.

- **`-Verbose|--verbose`**

  Displays diagnostics information.

- **`-Version|--version <VERSION>`**

  Represents a specific build version. The possible values are:

  - `latest`: Latest build on the channel (used with the `-Channel` option).
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

- Install the 6.0.0 version of the shared runtime:

  Windows:

  ```powershell
  ./dotnet-install.ps1 -Runtime dotnet -Version 6.0.0
  ```

  macOS/Linux:

  ```bash
  ./dotnet-install.sh --runtime dotnet --version 6.0.0
  ```

- Obtain script and install the 6.0.2 version behind a corporate proxy (Windows only):

  ```powershell
  Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -Proxy $env:HTTP_PROXY -ProxyUseDefaultCredentials -OutFile 'dotnet-install.ps1';
  ./dotnet-install.ps1 -InstallDir '~/.dotnet' -Version '6.0.2' -Runtime 'dotnet' -ProxyAddress $env:HTTP_PROXY -ProxyUseDefaultCredentials;
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

## Set environment variables

Manually installing .NET doesn't add the environment variables system-wide, and generally only works for the session in which .NET was installed. There are two environment variables you should set for your operating system:

- `DOTNET_ROOT`

  This variable is set to the folder .NET was installed to, such as `$HOME/.dotnet` for Linux and macOS, and `$HOME\.dotnet` in PowerShell for Windows.

- `PATH`

  This variable should include both the `DOTNET_ROOT` folder and the user's _.dotnet/tools_ folder. Generally this is `$HOME/.dotnet/tools` on Linux and macOS, and `$HOME\.dotnet\tools` in PowerShell on Windows.

> [!TIP]
> For Linux and macOS, use the `echo` command to set the variables in your shell profile, such as _.bashrc_:
>
> ```bash
> echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
> echo 'export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools' >> ~/.bashrc
> ```

## Uninstall

There is no uninstall script. For information about manually uninstalling .NET, see [How to remove the .NET Runtime and SDK](../install/remove-runtime-sdk-versions.md#scripted-or-manual).

## Signature validation of dotnet-install.sh

Signature validation is an important security measure that helps ensure the authenticity and integrity of a script. By verifying the signature of a script, you can be sure that it has not been tampered with and that it comes from a trusted source.

Here is a step-by-step guide on how to verify the authenticity of the `dotnet-install.sh` script using GPG:

1. **Install GPG**: GPG (GNU Privacy Guard) is a free and open-source tool for encrypting and signing data. You can install it on your system using your package manager. For example, on Ubuntu or Debian, you can use the command `sudo apt-get install gnupg`.
2. **Import our public key**: Download [public key](https://dot.net/v1/dotnet-install.asc) file, and you can then import it into your GPG keyring by running the command `gpg --import dotnet-install.asc`.
3. **Download the signature file**: The signature file for our bash script is available at `https://dot.net/v1/dotnet-install.sig`. You can download it using a tool like `wget` or `curl`.
4. **Verify the signature**: To verify the signature of our bash script, run the command `gpg --verify dotnet-install.sig dotnet-install.sh`. This will check the signature of the `dotnet-install.sh` file against the signature in the `dotnet-install.sig` file.
5. **Check the result**: If the signature is valid, you will see a message containing `Good signature from "Microsoft DevUXTeamPrague <devuxteamprague@microsoft.com>"`. This means that the script has not been tampered with and can be trusted.

## See also

- [.NET releases](https://github.com/dotnet/core/releases)
- [.NET Runtime and SDK download archive](https://github.com/dotnet/core/tree/main/release-notes/download-archives)
