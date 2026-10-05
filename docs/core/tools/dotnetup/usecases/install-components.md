---
title: Install .NET SDKs and runtimes with dotnetup
description: Install stable, preview, and exact .NET component requirements.
ms.topic: how-to
ms.date: 08/07/2026
ai-usage: ai-assisted
---

# Install .NET SDKs and runtimes with dotnetup

[!INCLUDE [public-preview](../includes/public-preview.md)]

## Install SDKs

With no channel, dotnetup uses the nearest usable `global.json` requirement.
If none exists, it uses `latest`.

```dotnetcli
dotnetup sdk install
dotnetup sdk install lts
dotnetup sdk install 10.0 11.0
dotnetup sdk install 10.0.103
```

The top-level `install` command is an alias for `dotnetup sdk install`:

```dotnetcli
dotnetup install 10.0
```

## Install runtimes

Use `component@channel` to select a runtime component:

```dotnetcli
dotnetup runtime install 10.0
dotnetup runtime install aspnetcore@10.0
dotnetup runtime install windowsdesktop@10.0
```

A value without a component selects the core .NET runtime.
`windowsdesktop` is available only on Windows.

## Install without tracking

Use `--untracked` when you want files but do not want a manifest record:

```dotnetcli
dotnetup sdk install 10.0 --untracked --install-path .\.dotnet
```

`dotnetup` does not list, update, or uninstall an untracked installation.

Tracked installation protects roots that already contain unmanaged .NET
artifacts. Use a new root, migrate the installation, or explicitly choose an
untracked install.

## Migrate native-architecture components

`dotnetup` detects SDKs and runtimes in system-managed .NET installations for
the current architecture. It derives install requirements and resolves them
through its normal download process. The resolved version might differ from
the source installation. Migration leaves the system installation unchanged.
To install the detected components into the selected root, run:

```dotnetcli
dotnetup sdk install --migrate-from-system
```

Migration considers only installations that match the running process
architecture.

## Check installed state

You can see the list of install specifications, the installed versions, and the source of each requirement with:

```dotnetcli
dotnetup list
```

## See also

- [SDK channels and versions](../concepts/channels.md)
- [dotnetup sdk install](../reference/dotnetup-sdk-install.md)
- [dotnetup runtime install](../reference/dotnetup-runtime-install.md)
