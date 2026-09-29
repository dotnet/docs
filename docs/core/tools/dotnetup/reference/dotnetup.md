---
title: dotnetup command
description: Command reference for the dotnetup toolchain manager.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup command

## Name

`dotnetup` - Install and manage user-level .NET SDKs and runtimes.

## Synopsis

```console
dotnetup [command] [options]
dotnetup
dotnetup --info [--format <text|json>] [--no-list]
```

## Description

`dotnetup` tracks .NET installation requirements and the concrete SDK or
runtime versions that satisfy them. A bare `dotnetup` invocation runs the SDK
install workflow. When interactive input is available and no configuration
exists, it can start first-use onboarding.

## Commands

| Command | Description |
| --- | --- |
| [`sdk`](dotnetup-sdk.md) | Manage .NET SDK installations. |
| [`runtime`](dotnetup-runtime.md) | Manage .NET runtime installations. |
| [`install`](dotnetup-install.md) | Install a component. |
| [`update`](dotnetup-update.md) | Update all tracked components. |
| [`uninstall`](dotnetup-uninstall.md) | Remove a tracked component. |
| [`list`](dotnetup-list.md) | List tracked specifications and installations. |
| [`init`](dotnetup-init.md) | Run interactive setup. |
| [`env`](dotnetup-env.md) | Manage environment configuration. |
| [`dotnet`](dotnetup-dotnet.md) | Run the dotnetup-managed `dotnet`. |

## Options

| Option | Description |
| --- | --- |
| `--info` | Display the dotnetup version, commit, process architecture, runtime identifier, and verified installation information. |
| `--version` | Display the dotnetup version. |
| `--interactive [<true\|false>]` | Allow a bare invocation to wait for user input. The default is `true` in an interactive terminal and `false` in CI or when output is redirected. |
| `-h`, `/h`, `-?`, `/?`, `--help` | Show root help. |

### --info options

| Option | Description |
| --- | --- |
| `--format <text\|json>` | Select text or JSON output. The default is `text`. |
| `--no-list [<true\|false>]` | Omit tracked specifications and installations. Without this option, `--info` verifies installations. |

## Examples

Show help and version information:

```dotnetcli
dotnetup --help
dotnetup --version
dotnetup --info
dotnetup --info --format json --no-list
```

Start first-use installation:

```dotnetcli
dotnetup
```

For predictable automation, select an explicit command and channel:

```dotnetcli
dotnetup install latest --interactive false --no-progress
```
