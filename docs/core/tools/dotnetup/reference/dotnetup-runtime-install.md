---
title: dotnetup runtime install command
description: Command reference for installing .NET runtimes with dotnetup.
ms.topic: reference
ms.date: 08/07/2026
---

# dotnetup runtime install command

## Name

`dotnetup runtime install` - Install one or more .NET runtime requirements.

## Synopsis

```console
dotnetup runtime install [<COMPONENT_SPEC>...] [options]
```

## Arguments

`COMPONENT_SPEC`

One or more runtime channels or versions. Use
`component@version-or-channel` to select a component. A value without a
component selects the core .NET runtime.

If you omit all values, the command installs the latest core runtime.

Valid components are `runtime`, `aspnetcore`, and `windowsdesktop`.
`aspnet` and `desktop` are accepted aliases. Windows Desktop is available
only on Windows.

## Options

| Option | Description |
| --- | --- |
| `--install-path <INSTALL_PATH>` | Select the installation root. |
| `--set-default-install [<true\|false>]` | The current parser accepts this option. The current install handler does not apply its environment changes. Use `dotnetup env set` after installation. |
| `--migrate-from-system [<true\|false>]` | Install matching native-architecture runtimes from a system-managed installation into the selected installation root. |
| `--manifest-path <MANIFEST_PATH>` | Use a custom manifest file. |
| `--interactive [<true\|false>]` | Allow first-use onboarding to wait for input. |
| `--no-progress [<true\|false>]` | Disable progress display. |
| `-v`, `--verbosity <normal\|detailed>` | Set output verbosity. The default is `normal`. |
| `--require-muxer-update [<true\|false>]` | Fail if the command cannot update the `dotnet` executable. By default, installation continues with a warning. |
| `--untracked [<true\|false>]` | Install without adding a manifest record. |
| `-?`, `-h`, `--help` | Show command help. |

SDK feature bands and SDK patch versions are not valid runtime versions. For
example, use `10.0` or `10.0.3`, not `10.0.1xx` or `10.0.103`.

## Examples

```dotnetcli
dotnetup runtime install
dotnetup runtime install 10.0
dotnetup runtime install aspnetcore@10.0
dotnetup runtime install runtime@9.0 aspnetcore@9.0
```
