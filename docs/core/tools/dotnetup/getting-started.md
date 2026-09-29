---
title: Get started with dotnetup
description: Install dotnetup, choose an SDK channel, and configure access to .NET installations.
ms.topic: tutorial
ms.date: 09/29/2026
ai-usage: ai-assisted
---

# Get started with dotnetup

[!INCLUDE [public-preview](includes/public-preview.md)]

`dotnetup` is a cross-platform toolchain manager for user-level .NET
installations. It installs, updates, and removes .NET SDKs and runtimes without
using a system package manager.

## Prerequisites

- Windows, macOS, or Linux.
- A terminal.
- Bash on macOS or Linux, or PowerShell on Windows, to run the download script.

On Windows, the default setup uses the `everywhere` access mode and requires
elevation to update the system `PATH`. Choose `none` or `shell` to avoid this
requirement. For details, see
[dotnetup environment configuration](concepts/environment.md).

## Download dotnetup

The download scripts install the latest `preview` build by default. They verify
the downloaded executable with its SHA-512 checksum and install it in
`~/.dotnetup`.

On macOS or Linux, run:

```bash
curl -fsSL https://aka.ms/dotnetup/get-dotnetup.sh | bash
```

On Windows, run:

```powershell
irm https://aka.ms/dotnetup/get-dotnetup.ps1 | iex
```

To install the latest `daily` build on macOS or Linux, run:

```bash
curl -fsSL https://aka.ms/dotnetup/get-dotnetup.sh |
  bash -s -- --quality daily
```

To install the latest `daily` build on Windows, run:

```powershell
iex "& { $(irm https://aka.ms/dotnetup/get-dotnetup.ps1) } -Quality daily"
```

> [!IMPORTANT]
> Daily builds have not completed release validation and are not code-signed.
> Use daily builds only for short-lived testing.

The scripts print instructions to add `dotnetup` to `PATH`. Open a new terminal
after you apply the instructions.

## Run first-time setup

Run the interactive setup:

```dotnetcli
> dotnetup init
Welcome to dotnetup!

SDK Channel: latest
Mode: <recommended-mode> (Suggested)

<recommended-mode> modifies <configuration-target> to set PATH and DOTNET_ROOT to prefer <install-path>.

Would you like to install .NET with the recommended settings?
> Yes, proceed with defaults and install

Installing SDK <resolved-version> to <install-path>...
<download and installation progress>
Installed at <install-path>:
  SDK <resolved-version>
<mode-specific environment guidance>
Setup complete!
```

The paths, progress display, and environment guidance depend on your system and
the selected mode.

The recommended access mode is `everywhere` on Windows. On macOS and Linux, it
is `shell` when `dotnetup` detects a supported shell and `none` otherwise.

Select **No, customize setup** to choose the SDK channel, access mode, and
migration options.

### Choose an SDK channel

An SDK channel tells `dotnetup` which SDK to install and how to update it.

| Channel form | Example | Result |
| --- | --- | --- |
| Latest stable | `latest` | Latest active stable SDK |
| Latest LTS | `lts` | Latest active stable LTS SDK |
| Latest preview | `preview` | Latest preview SDK |
| Latest daily | `daily` | Latest available daily SDK |
| Major | `10` | Latest SDK for the specified major version |
| Major and minor | `10.0` | Latest SDK for the specified major and minor version |
| Feature band | `10.0.1xx` | Latest SDK in the specified feature band |
| Exact version | `10.0.103` | Only the specified SDK version |
| No initial SDK | `none` | Skip installation during setup |

Exact versions do not advance during updates. For all accepted forms, see
[dotnetup channels and versions](concepts/channels.md).

### Choose how to access .NET

The access mode controls how terminals and applications find the
dotnetup-managed .NET installation.

| Access mode | Behavior |
| --- | --- |
| `none` | Does not modify these environment variables. Run .NET with `dotnetup dotnet`. |
| `shell` | Modifies the shell profile to set these environment variables. Processes started from that shell use the .NET SDKs and Runtimes installed by dotnetup. |
| `everywhere` | Modifies the system `PATH` and sets the user-level `DOTNET_ROOT` environment variable. Only available on Windows. |

For more details and considerations for `everywhere` mode, see
[dotnetup environment configuration](concepts/environment.md).

### Migrate existing installations

Setup can offer to migrate existing machine-wide .NET SDK and Runtime
installations into the dotnetup-managed installation. See
[Everywhere mode considerations](concepts/environment.md#everywhere-mode-considerations)
for why migration is especially important with `everywhere` mode.

## Verify setup

Open a new terminal after setup changes your environment.

For `shell` or `everywhere` mode, run:

```dotnetcli
dotnet --version
dotnetup list
```

For `none` mode, run:

```dotnetcli
dotnetup dotnet -- --version
dotnetup list
```

Run `dotnetup init` again to change the setup.

The command reference follows the generated runtime help. Command handlers and
tests verify product behavior. Hidden compatibility and elevation commands are
implementation details. They are not part of the public command reference.
