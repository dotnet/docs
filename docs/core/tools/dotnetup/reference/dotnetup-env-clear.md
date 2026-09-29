---
title: dotnetup env clear command
description: Command reference for removing dotnetup environment settings.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup env clear command

## Name

`dotnetup env clear` - Remove all dotnetup environment wiring.

## Synopsis

```console
dotnetup env clear [options]
```

## Description

The command removes managed `PATH` and `DOTNET_ROOT` changes and stores the
`none` access mode with `dotnetup` removed from `PATH`. It is equivalent to:

```dotnetcli
dotnetup env set none --dotnetup-on-path false
```

It does not uninstall .NET.

For more information about access modes, see
[dotnetup environment configuration](../concepts/environment.md).

## Options

| Option | Description |
| --- | --- |
| `-s`, `--shell [<bash\|zsh\|fish\|pwsh>]` | Select the profile shell to update. If omitted, detect the current shell. |
| `-?`, `-h`, `--help` | Show command help. |

## Example

```dotnetcli
dotnetup env clear --shell pwsh
```
