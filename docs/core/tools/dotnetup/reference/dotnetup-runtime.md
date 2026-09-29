---
title: dotnetup runtime command
description: Command reference for the dotnetup runtime command group.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup runtime command

## Name

`dotnetup runtime` - Manage .NET runtime installations.

## Synopsis

```console
dotnetup runtime <command> [options]
```

## Commands

| Command | Description |
| --- | --- |
| [`install`](dotnetup-runtime-install.md) | Install one or more runtime requirements. |
| [`update`](dotnetup-runtime-update.md) | Update tracked runtime requirements. |
| [`uninstall`](dotnetup-runtime-uninstall.md) | Remove a runtime requirement and unused files. |

## Options

| Option | Description |
| --- | --- |
| `-?`, `-h`, `--help` | Show command help. |

## Runtime components

| Name | Component |
| --- | --- |
| `runtime` | Core .NET runtime |
| `aspnetcore` or `aspnet` | ASP.NET Core runtime |
| `windowsdesktop` or `desktop` | Windows Desktop runtime. Windows only. |
