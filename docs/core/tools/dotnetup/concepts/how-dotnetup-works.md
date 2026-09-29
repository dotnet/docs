---
title: How dotnetup works
description: Learn about dotnetup installation roots, components, install specifications, installations, and state files.
ms.topic: conceptual
ms.date: 08/07/2026
---

# How dotnetup works

`dotnetup` separates what you request from the files that it installs. This
model lets several requirements share one .NET installation and lets
`dotnetup` remove files that are no longer required.

## Installation roots

A **.NET installation root** is a directory that `dotnetup` tracks. An
installation root has:

- A fully qualified directory path.
- An architecture: `x86`, `x64`, or `arm64`.
- Zero or more install specifications, specified as `channels`.
- Zero or more concrete installations.

The current CLI installs for the architecture of the running `dotnetup`
process. It does not have an architecture option.

The default dotnetup-managed .NET installation root is the `dotnet`
subdirectory of the dotnetup data directory:

| Platform | Default installation root |
| --- | --- |
| Windows | `%LOCALAPPDATA%\dotnetup\dotnet` |
| macOS | `~/Library/Application Support/dotnetup/dotnet` |
| Linux | `$XDG_DATA_HOME/dotnetup/dotnet`, or `~/.local/share/dotnetup/dotnet` when `XDG_DATA_HOME` is not set |

Use `--install-path` to select another installation root. An explicit install path takes
precedence over a path from `global.json`, which takes precedence over the
default installation root.

`dotnetup` does not write to a system-managed .NET directory, such as
`Program Files\dotnet` or `/usr/share/dotnet`.

## Components

`dotnetup` manages these component types:

| Component | Runtime specification name | Installed content |
| --- | --- | --- |
| .NET SDK | Not applicable | SDK, host, runtime, targeting packs, and related SDK content |
| .NET runtime | `runtime` | `Microsoft.NETCore.App` runtime |
| ASP.NET Core runtime | `aspnetcore` | `Microsoft.AspNetCore.App` runtime |
| Windows Desktop runtime | `windowsdesktop` | `Microsoft.WindowsDesktop.App` runtime on Windows |

The ASP.NET Core aliases `aspnet` and the Windows Desktop alias `desktop` are
accepted in runtime component specifications.

## Install specifications

An **install specification** records a component and a channel or exact
version. For example, an SDK specification for `10.0.1xx` means "keep the
latest SDK in the 10.0.1xx feature band."

You can learn more about the different kinds of supported channels and versions in [Channels and versions](channels.md).

Each specification has one of these sources:

- `Explicit`: You supplied the channel or version on the command line.
- `GlobalJson`: `dotnetup` derived the SDK requirement from a `global.json`
  file.

`All` is an uninstall filter. It is not stored as a specification source.

An exact version is a pinned specification. Update commands do not advance it.
A channel specification can resolve to a newer version during an update.

## Installations and shared files

An **installation** records one concrete component version and the
subcomponent directories that it uses. Two specifications can resolve to the
same installation.

Uninstall commands first remove matching specifications. Garbage collection
then keeps the newest installed version that matches each remaining
specification. It removes an installation and its unshared subcomponents only
when no remaining specification needs them.

## Tracked and untracked installs

By default, an install command records its specification and result in the
manifest. A tracked install can be listed, updated, and removed by
`dotnetup`.

The `--untracked` option installs files without recording them. `dotnetup`
does not list, update, or remove those files. Use this option only when another
process owns the target directory.

To prevent accidental mixing, a tracked install fails if the target contains
an existing .NET installation that is not in the selected manifest. Select a
different directory, remove the existing installation, or use `--untracked`.

## State files

The dotnetup data directory contains these user-level state files:

| File | Purpose |
| --- | --- |
| `dotnetup_manifest.json` | Tracks installation roots, install specifications, installations, and shared subcomponents. |
| `dotnetup_manifest.json.sha256` | Detects changes to manifest content that dotnetup did not write. |
| `dotnetup.config.json` | Stores the .NET access mode and whether the `dotnetup` directory is on `PATH`. |

Do not edit these files. Use `dotnetup install`, `update`, `uninstall`, and
`env` commands to change the related state.

The `DOTNET_DOTNETUP_DATA_DIR` environment variable changes the data
directory. The `--manifest-path` option changes only the manifest used by one
command. It does not change the configuration file or default installation root.

## Concurrent operations

Install, update, uninstall, list, and garbage-collection workflows coordinate
access to shared installation state. A command that accepts several
specifications resolves them before installation and can download them
concurrently. Manifest changes remain serialized.

## See also

- [Channels and versions](channels.md)
- [Repository SDK requirements](repositories.md)
- [Environment configuration](environment.md)
- [`dotnetup list`](../reference/dotnetup-list.md)
