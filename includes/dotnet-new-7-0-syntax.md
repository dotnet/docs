---
author: vshubina
ms.author: vshubina
ms.date: 03/30/2022
ms.topic: include
---

Starting with .NET SDK 7.0.100, the `dotnet new` syntax has changed:

- The `--list`, `--search`, `--install`, and `--uninstall` options became `list`, `search`, `install` and `uninstall` subcommands.
- The `--update-apply` option became the `update` subcommand.
- To use `--update-check`, use the `update` subcommand with the `--check-only` option.

Other options that were available before are still available to use with their respective subcommands.
Separate help for each subcommand is available via the `-h` or `--help` option: `dotnet new <subcommand> --help` lists all supported options for the subcommand.
