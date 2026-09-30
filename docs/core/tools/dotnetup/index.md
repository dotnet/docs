---
title: dotnetup overview
description: Learn how dotnetup installs and manages user-level .NET SDKs and runtimes.
ms.topic: overview
ms.date: 09/30/2026
ai-usage: ai-assisted
---

# dotnetup overview

[!INCLUDE [public-preview](includes/public-preview.md)]

`dotnetup` is a cross-platform toolchain manager for user-level .NET
installations. It installs .NET SDKs and runtimes without writing to a
system-managed .NET directory. It also tracks the installation requirements
that you select so that it can update or remove the related files later.

Use `dotnetup` to:

- Install stable, preview, daily, or exact .NET versions.
- Keep multiple SDK and runtime requirements in one managed installation.
- Install the SDK required by the nearest `global.json` file.
- Update tracked channels without changing exact-version requirements.
- Configure how terminals and applications find the managed `dotnet`.
- Run the managed `dotnet` without changing `PATH`.

## Start

Run the interactive setup:

```dotnetcli
> dotnetup init
Welcome to dotnetup!

SDK Channel: latest
Mode: Terminal Mode (Suggested)

Would you like to install .NET with the recommended settings?
> Yes, proceed with defaults and install

Downloading SDK <resolved-version>
Installing SDK <resolved-version>
Installed SDK <resolved-version>
Setup complete!
```

The setup asks which SDK channel to install and how you want to access the
managed `dotnet` command.

For a concise, noninteractive setup, install an SDK and configure the current
shell:

```dotnetcli
> dotnetup install latest
Downloading SDK <resolved-version>
Installing SDK <resolved-version>
Installed SDK <resolved-version>

> dotnetup env set shell
dotnet and dotnetup are on your PATH.
To apply the change to this terminal now, run:
<shell-specific command>
Or open a new terminal.

> dotnetup list
Installations (managed by dotnetup):

  <default-installation-root>

    Tracked channels:
      SDK latest  (source: explicit)

    Installed versions:
      SDK <resolved-version>  (<architecture>)

Total: 1

> dotnet --version
<resolved-version>
```

If you do not want to change your shell profile, use the forwarding command:

```dotnetcli
> dotnetup install latest
Downloading SDK <resolved-version>
Installing SDK <resolved-version>
Installed SDK <resolved-version>

> dotnetup env set none
dotnetup is on your PATH. dotnet is not — run it with 'dotnetup dotnet <command>'.
Open a new terminal for the change to take effect.

> dotnetup dotnet --version
<resolved-version>
```

The mode, resolved version, architecture, installation path, and shell command
depend on your system and the available releases.

## How dotnetup manages .NET

`dotnetup` tracks the SDK installations that you request. This tracking lets
`dotnetup` update many installations at the same time. It also lets `dotnetup`
safely remove unused or out-of-support installations.

For more information, see [How dotnetup works](concepts/how-dotnetup-works.md).

## Choose what to read next

| Goal | Article |
| --- | --- |
| Install dotnetup and run the first setup | [Get started with dotnetup](getting-started.md) |
| Understand channels, installation roots, and tracking | [How dotnetup works](concepts/how-dotnetup-works.md) |
| Use a repository's `global.json` | [Manage repository SDK requirements](usecases/install-with-global-json.md) |
| Install SDKs and runtimes | [Install .NET components](usecases/install-components.md) |
| Update or remove installations | [Update installations](usecases/update-installations.md) |
| Configure `PATH` and `DOTNET_ROOT` | [Manage the dotnetup environment](usecases/manage-environment.md) |
| Try preview or daily builds | [Use preview and daily builds](usecases/try-daily-builds.md) |
| Look up command syntax | [dotnetup command reference](reference/dotnetup.md) |

## Availability

`dotnetup` is available as a public preview. Commands, options, and behavior
might change between preview releases, and the support lifecycle for the
generally available release isn't final.

To install `dotnetup`, see [Get started with dotnetup](getting-started.md).
After you install it, run `dotnetup --version` to confirm the version and
`dotnetup --help` to see the available commands.
