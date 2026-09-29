---
title: Repository SDK requirements with dotnetup
description: Learn how dotnetup reads global.json and tracks repository SDK requirements.
ms.topic: conceptual
ms.date: 08/07/2026
---

# Repository SDK requirements with dotnetup

`dotnetup` uses `global.json` to associate an SDK requirement with a
repository or directory tree. From the current directory, it searches for
`global.json` and then searches each parent directory until it finds one.

## Install from global.json

Run an SDK install command without a channel:

```dotnetcli
dotnetup install
```

If the nearest `global.json` has an `sdk.version`, `dotnetup` derives an
install specification from the version and `rollForward` value. It records
the full path to the file as the specification source. If no usable
`global.json` exists, the command uses the `latest` channel.

## rollForward mapping

`dotnetup` maps `global.json` SDK selection policies to updateable channels:

| `rollForward` value | Stored dotnetup requirement for SDK `10.0.103` |
| --- | --- |
| Omitted or `latestPatch` | `10.0.1xx` |
| `latestFeature` | `10.0` |
| `latestMinor` | `10` |
| `latestMajor` | `latest` |
| `disable`, `patch`, `feature`, `minor`, or `major` | `10.0.103` |

The exact-version mappings are pinned and are not advanced by an update.

## Installation path from global.json

If `sdk.paths` contains an entry, `dotnetup` uses the first path. A relative
path is resolved from the directory that contains `global.json`.

Installation-path precedence is:

1. `--install-path`.
1. The first `sdk.paths` entry in the nearest `global.json`.
1. The default dotnetup-managed .NET installation root.

## Keep repository files current

Pass `--update-global-json` to replace `sdk.version` with the concrete SDK
version that was installed or updated:

```dotnetcli
dotnetup install --update-global-json
dotnetup sdk update --update-global-json
```

Only global.json-sourced SDK specifications are updated by the update
workflow. The modifier preserves the other JSON properties, formatting, and
detected text encoding.

## Remove a repository requirement

A tracked `global.json` specification is refreshed during garbage collection.
If the file no longer exists or no longer contains an SDK version, the
specification is removed.

You can also remove it explicitly. Match the stored channel and select the
`globaljson` source:

```dotnetcli
dotnetup sdk uninstall 10.0.1xx --source globaljson
```

Use `dotnetup list` to find the stored channel and source path.

## See also

- [Manage repository SDK requirements](../usecases/install-with-global-json.md)
- [`global.json` overview](https://learn.microsoft.com/dotnet/core/tools/global-json)
- [`dotnetup sdk install`](../reference/dotnetup-sdk-install.md)
