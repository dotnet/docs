---
title: dotnetup env show command
description: Command reference for inspecting dotnetup environment configuration and drift.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup env show command

## Name

`dotnetup env show` - Show environment settings and report detected drift.

## Synopsis

```console
dotnetup env show [options]
```

## Description

The command displays the stored .NET access mode and `dotnetup` `PATH`
setting. It compares the stored configuration with the selected shell profile
and persisted environment. It also reports whether the current process has
the requested settings.

If the configuration has drifted, run `dotnetup env set` to reapply it.

For more information about access modes, see
[dotnetup environment configuration](../concepts/environment.md).

## Options

| Option | Description |
| --- | --- |
| `-s`, `--shell [<bash\|zsh\|fish\|pwsh>]` | Select the profile shell to inspect. If omitted, detect the current shell. |
| `-?`, `-h`, `--help` | Show command help. |

## Example

```dotnetcli
dotnetup env show --shell zsh
```
