---
author: vshubina
ms.author: vshubina
ms.date: 30/03/2022
ms.topic: include
---

## .NET SDK 7.0.100 `dotnet new` syntax

Starting .NET SDK 7.0.100  Preview 2 `dotnet new` syntax has changed:

- `--list`, `--search`, `--install` `--uninstall` options became `list`, `search`, `install` and `uninstall` subcommand.
- `--update-apply` option became `update` subcommand.
- to use `--update-check`, use `update` subcommand with `--check` option.

Other options available before are still available to use with respective subcommands.
There is a separate help for each subcommand avilable via `-h` or `--help` option: `dotnet new <subcommand> --help`, that lists all supported options for the subcommand.

Additionally, the tab completion is now available for `dotnet new`.
To activate tab completion for .NET SDK, follow [the guideline](../docs/core/tools/enable-tab-autocomplete.md).
