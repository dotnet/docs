---
title: dotnetup sdk update command
description: Command reference for updating tracked .NET SDK requirements.
ms.topic: reference
ms.date: 10/13/2026
ai-usage: ai-assisted
---

# dotnetup sdk update command

[!INCLUDE [public-preview](../includes/public-preview.md)]

## Name

`dotnetup sdk update` - Update tracked .NET SDK channels.

## Synopsis

```console
dotnetup sdk update [options]
```

## Description

By default, the command processes only SDK specifications. It skips exact SDK
versions. Use `--all` to process SDK and runtime specifications.

## Options

| Option | Description |
| --- | --- |
| `--all` | Update all tracked components, including runtimes. |
| `--update-global-json` | Update applicable global.json-sourced SDK versions. |
| `--manifest-path <MANIFEST_PATH>` | Use a custom manifest file. |
| `--install-path <INSTALL_PATH>` | Update only the matching installation root. |
| `--interactive [<true\|false>]` | Allow update notifications when output isn't redirected. The default is `false` in CI or when output is redirected, and `true` otherwise. The update itself doesn't prompt for confirmation. |
| `--no-progress [<true\|false>]` | Disable progress display. |
| `-v`, `--verbosity <normal\|detailed>` | Set output verbosity. The default is `normal`. |
| `-?`, `-h`, `--help` | Show command help. |

## Examples

```dotnetcli
dotnetup sdk update
dotnetup sdk update --all
dotnetup sdk update --update-global-json
```
