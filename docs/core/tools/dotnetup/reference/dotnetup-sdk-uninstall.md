---
title: dotnetup sdk uninstall command
description: Command reference for removing tracked .NET SDK requirements.
ms.topic: reference
ms.date: 10/13/2026
ai-usage: ai-assisted
---

# dotnetup sdk uninstall command

[!INCLUDE [public-preview](../includes/public-preview.md)]

## Name

`dotnetup sdk uninstall` - Remove an SDK specification and unused files.

## Synopsis

```console
dotnetup sdk uninstall <CHANNEL> [options]
```

## Arguments

`CHANNEL`

The stored SDK channel or exact version to remove. Matching is
case-insensitive.

The command accepts one argument and matches the stored specification name,
not the version that another specification resolves to.
For example, if only `latest` is tracked, `uninstall 11.0` doesn't remove that
specification even when it selects an 11.0 SDK.
A single channel can match multiple installed versions.

## Options

| Option | Description |
| --- | --- |
| `--source <explicit\|globaljson\|all>` | Remove specifications from the selected source. The default is `explicit`. |
| `--manifest-path <MANIFEST_PATH>` | Use a custom manifest file. |
| `--install-path <INSTALL_PATH>` | Select the installation root. |
| `--interactive [<true\|false>]` | Enable confirmation for unexpected outcomes. The default is `false` in CI or when output is redirected, and `true` otherwise. Redirected input alone doesn't disable confirmation. |
| `--non-interactive` | Proceed without confirmation, even if `--interactive` is enabled. Warnings still appear. |
| `-?`, `-h`, `--help` | Show command help. |

## Behavior

Uninstall removes matching specifications, then runs garbage collection for
the whole installation root.
Another specification can keep a requested SDK installed.
Garbage collection can also remove unreferenced installations outside the
requested channel, including runtime components.

Before it changes state, the command lists requested installations that will
remain and the specifications that keep them installed.
It also lists additional installations that will be removed.
When either warning applies in interactive mode, press **Y** or **Enter** to
proceed, or **N** or **Esc** to cancel.
Cancellation doesn't remove specifications or files.
In noninteractive mode, the command prints the warnings and proceeds without confirmation.

The warning summary identifies each specification that will be removed from
tracking, including its component and source.
If another specification retains an SDK, the requested specification is
removed, but that SDK stays installed.
Removal of a `global.json`-sourced specification doesn't delete the `global.json` file.

## Examples

```dotnetcli
dotnetup sdk uninstall latest
dotnetup sdk uninstall 10.0.1xx --source globaljson
dotnetup sdk uninstall preview --source all --install-path .\.dotnet
```
