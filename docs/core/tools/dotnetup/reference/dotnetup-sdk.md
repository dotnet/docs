---
title: dotnetup sdk command
description: Command reference for the dotnetup SDK command group.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup sdk command

## Name

`dotnetup sdk` - Manage .NET SDK installations.

## Synopsis

```console
dotnetup sdk <command> [options]
```

## Commands

| Command | Description |
| --- | --- |
| [`install`](dotnetup-sdk-install.md) | Install one or more SDK requirements. |
| [`update`](dotnetup-sdk-update.md) | Update tracked SDK requirements. |
| [`uninstall`](dotnetup-sdk-uninstall.md) | Remove an SDK requirement and unused files. |

## Options

| Option | Description |
| --- | --- |
| `-?`, `-h`, `--help` | Show command help. |

## Example

```dotnetcli
dotnetup sdk install 10.0.1xx
dotnetup sdk update
dotnetup sdk uninstall 10.0.1xx
```
