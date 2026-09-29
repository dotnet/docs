---
title: dotnetup sdk install command
description: Command reference for installing .NET SDKs with dotnetup sdk install.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup sdk install command

## Name

`dotnetup sdk install` - Install one or more .NET SDK requirements.

## Synopsis

```console
dotnetup sdk install [<CHANNEL>...] [options]
```

## Arguments

`CHANNEL`

One or more SDK channels or exact versions. Multiple values are resolved
before installation and can be installed concurrently.

When no value is present, `dotnetup` derives the channel from the nearest
`global.json`. If no usable file exists, it selects `latest`.

## Options

| Option | Description |
| --- | --- |
| `--install-path <INSTALL_PATH>` | Select the installation root. |
| `--set-default-install [<true\|false>]` | The current parser accepts this option. The current install handler does not apply its environment changes. Use `dotnetup env set` after installation. |
| `--migrate-from-system [<true\|false>]` | Install matching native-architecture SDKs from a system-managed installation into the selected installation root. |
| `--update-global-json [<true\|false>]` | Replace `sdk.version` in the applicable `global.json` with the installed version. |
| `--manifest-path <MANIFEST_PATH>` | Use a custom manifest file. |
| `--interactive [<true\|false>]` | Allow first-use onboarding to wait for input. |
| `--no-progress [<true\|false>]` | Disable progress display. |
| `-v`, `--verbosity <normal\|detailed>` | Set output verbosity. The default is `normal`. |
| `--require-muxer-update [<true\|false>]` | Fail if the command cannot update the `dotnet` executable. By default, installation continues with a warning. |
| `--untracked [<true\|false>]` | Install without adding a manifest record. |
| `-?`, `-h`, `--help` | Show command help. |

## Examples

```dotnetcli
dotnetup sdk install latest
dotnetup sdk install 10 10.0.1xx
dotnetup sdk install 10.0.103
dotnetup sdk install preview --no-progress
```
