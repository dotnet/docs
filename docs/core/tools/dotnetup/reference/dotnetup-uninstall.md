---
title: dotnetup uninstall command
description: Command reference for removing a tracked .NET SDK requirement.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup uninstall command

## Name

`dotnetup uninstall` - Remove an SDK install specification and unused files.

This command is an alias for
[`dotnetup sdk uninstall`](dotnetup-sdk-uninstall.md).

## Synopsis

```console
dotnetup uninstall <CHANNEL> [options]
```

## Arguments

`CHANNEL`

The stored SDK channel or exact version to remove. Use `dotnetup list` to
find the stored value.

## Options

| Option | Description |
| --- | --- |
| `--source <explicit\|globaljson\|all>` | Remove specifications from the selected source. The default is `explicit`. |
| `--manifest-path <MANIFEST_PATH>` | Use a custom manifest file. |
| `--install-path <INSTALL_PATH>` | Select the installation root. Without this option, use the current managed root or the default installation root. |
| `-?`, `-h`, `--help` | Show command help. |

## Examples

Remove an explicit feature-band requirement:

```dotnetcli
dotnetup uninstall 10.0.1xx
```

Remove matching requirements from any source:

```dotnetcli
dotnetup uninstall 10.0.1xx --source all
```

An installation remains when another specification still refers to it.
