---
title: dotnetup env command
description: Command reference for the dotnetup environment command group.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup env command

## Name

`dotnetup env` - Manage `PATH` and `DOTNET_ROOT` configuration.

## Synopsis

```console
dotnetup env <command> [options]
```

## Commands

| Command | Description |
| --- | --- |
| [`set`](dotnetup-env-set.md) | Apply or reapply environment settings. |
| [`clear`](dotnetup-env-clear.md) | Remove all dotnetup environment wiring. |
| [`show`](dotnetup-env-show.md) | Show stored settings and detected drift. |
| [`script`](dotnetup-env-script.md) | Generate a shell activation script. |

## Options

| Option | Description |
| --- | --- |
| `-?`, `-h`, `--help` | Show command help. |

For the access-mode model, see
[Environment configuration](../concepts/environment.md).
