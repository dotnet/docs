---
title: When to use dotnetup
description: Compare dotnetup with other ways to install .NET, and decide which method fits your scenario.
ms.topic: concept-article
ms.date: 09/30/2026
ai-usage: ai-generated
---

# When to use dotnetup

[!INCLUDE [public-preview](includes/public-preview.md)]

You can install .NET in several ways. `dotnetup` is one option. It installs and
manages .NET SDKs and runtimes for your user account. This article helps you
decide whether `dotnetup` fits your scenario, or whether another installation
method is a better choice.

## Scenarios that fit dotnetup

Consider `dotnetup` when you want to:

- Install .NET without administrator rights and without a system package
  manager.
- Keep several SDK and runtime versions side by side, and update them together.
- Follow a channel, such as `lts`, `10.0`, or `10.0.1xx`, so that updates move
  to the newest matching version.
- Install the SDK that a repository's `global.json` file requires.
- Try preview or daily builds without changing the machine-wide installation.
- Use the same commands on Windows, macOS, and Linux.

## Scenarios that fit other methods

Another installation method might be a better choice when you:

- **Need a supported, generally available installation method.** `dotnetup` is
  in public preview. For production machines, use the .NET installers, a
  package manager, or Visual Studio.
- **Develop with Visual Studio.** Visual Studio installs and services its own
  machine-wide copy of .NET. For more information, see
  [Install .NET on Windows](../../install/windows.md).
- **Want machine-wide installations that receive updates from the OS.** Use the
  .NET installer, WinGet, Microsoft Update, or a Linux distribution package
  manager. For more information, see [Install .NET on Windows](../../install/windows.md),
  [Install .NET on macOS](../../install/macos.md), or
  [Install .NET on Linux](../../install/linux.md).
- **Manage and remove .NET installations across an organization's Windows
  devices.** Use the [.NET Install Manager](../../additional-tools/dnim-overview.md).

## Compare installation methods

| Capability | dotnetup | .NET installers and package managers | dotnet-install scripts |
| --- | --- | --- | --- |
| Installation scope | User | Machine | Any folder that you choose |
| Requires administrator rights | No, except to change the system `PATH` on Windows in `everywhere` mode | Yes | No |
| Tracks installations | Yes | Yes, through the OS | No |
| Updates installations | Yes, with `dotnetup update` | Yes, through the installer, package manager, or Microsoft Update | No. Run the script again. |
| Removes unused installations | Yes | Yes, through the OS | No |
| Reads `global.json` | Yes | No | Yes, with the `--jsonfile` option |
| Installs daily builds | Yes | No | Yes |
| Support status | Public preview | Generally available | Generally available |

## Use dotnetup with other installations

`dotnetup` doesn't remove or change machine-wide installations. How the two
installations interact depends on the access mode that you choose:

- In `none` and `shell` modes, processes that don't use the dotnetup
  environment configuration continue to use the machine-wide installation.
- In `everywhere` mode on Windows, the dotnetup-managed installation takes
  precedence over the machine-wide installation. Migrate the machine-wide SDKs
  and runtimes that you need into the dotnetup-managed installation.

For more information, see
[dotnetup environment configuration](concepts/environment.md).

## Next steps

> [!div class="nextstepaction"]
> [Get started with dotnetup](getting-started.md)
