---
title: dotnetup list command
description: Command reference for listing and verifying dotnetup installations.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup list command

## Name

`dotnetup list` - List tracked .NET requirements and installations.

## Synopsis

```console
dotnetup list [options]
```

## Description

The text output groups tracked channels and installed versions by
installation root. Each specification includes its source. Each installation
includes its architecture and, by default, its validation state.

JSON output has two arrays:

- `installSpecs`
- `installations`

Property names use camel case. Enum values use their names.

## Options

| Option | Description |
| --- | --- |
| `--format <text\|json>` | Select text or JSON output. The default is `text`. |
| `--no-verify [<true\|false>]` | Do not validate each recorded installation on disk. |
| `--manifest-path <MANIFEST_PATH>` | Use a custom manifest file. |
| `--install-path <INSTALL_PATH>` | Show only the matching installation root. |
| `-?`, `-h`, `--help` | Show command help. |

## Examples

List and verify all tracked installations:

```dotnetcli
dotnetup list
```

Create JSON output without file validation:

```dotnetcli
dotnetup list --format json --no-verify
```
