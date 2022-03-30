---
author: vshubina
ms.author: vshubina
ms.date: 30/03/2022
ms.topic: include
---

## .NET SDK 7.0.100 `dotnet new` syntax

Starting with .NET SDK 7.0.100 Preview 2, the `dotnet new` syntax has changed:

- `--list`, `--search`, `--install` `--uninstall` options became `list`, `search`, `install` and `uninstall` subcommand.
- `--update-apply` option became `update` subcommand.
- to use `--update-check`, use the `update` subcommand with the `--check` option.

Other options available before are still available to use with their respective subcommands.
There is a separate help for each subcommand avilable via `-h` or `--help` option: `dotnet new <subcommand> --help`, that lists all supported options for the subcommand.

Additionally, tab completion is now available for `dotnet new`. It supports completion for installed template names, as well as completion for the options a selected template provides.
To activate tab completion for .NET SDK, follow [the guideline](../docs/core/tools/enable-tab-autocomplete.md).
