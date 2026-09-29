---
title: dotnetup runtime uninstall command
description: Command reference for removing tracked .NET runtime requirements.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup runtime uninstall command

## Name

`dotnetup runtime uninstall` - Remove a runtime specification and unused
files.

## Synopsis

```console
dotnetup runtime uninstall <COMPONENT_SPEC> [options]
```

## Arguments

`COMPONENT_SPEC`

The stored runtime requirement to remove. Use
`component@version-or-channel` to select a component. A value without a
component selects the core .NET runtime.

## Options

| Option | Description |
| --- | --- |
| `--source <explicit\|globaljson\|all>` | Remove specifications from the selected source. The default is `explicit`. Runtime specifications are normally explicit. |
| `--manifest-path <MANIFEST_PATH>` | Use a custom manifest file. |
| `--install-path <INSTALL_PATH>` | Select the installation root. |
| `-?`, `-h`, `--help` | Show command help. |

## Examples

```dotnetcli
dotnetup runtime uninstall 10.0
dotnetup runtime uninstall aspnetcore@10.0
dotnetup runtime uninstall windowsdesktop@10.0 --install-path .\.dotnet
```
