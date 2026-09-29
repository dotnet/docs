---
title: Install an SDK for a repository with dotnetup
description: Use global.json to install and track the SDK requirement for a repository.
ms.topic: how-to
ms.date: 08/07/2026
---

# Install an SDK for a repository with dotnetup

When you do not supply an SDK channel, `dotnetup sdk install` searches from
the current directory toward the file system root. It uses the first usable
`global.json` file that it finds.

## Install the repository requirement

From the repository directory, run:

```dotnetcli
dotnetup sdk install
```

For this `global.json` file, dotnetup tracks the `10.0.1xx` feature band:

```json
{
  "sdk": {
    "version": "10.0.103",
    "rollForward": "latestPatch"
  }
}
```

The `global.json` path is the source of the stored requirement. You can see
the source and installed version with:

```dotnetcli
dotnetup list
```

## Understand roll-forward mapping

For an SDK version such as `10.0.103`, dotnetup maps `rollForward` as follows:

| `rollForward` value | Stored dotnetup channel |
| --- | --- |
| Omitted or `latestPatch` | `10.0.1xx` |
| `latestFeature` | `10.0` |
| `latestMinor` | `10` |
| `latestMajor` | `latest` |
| `disable`, `patch`, `feature`, `minor`, or `major` | Exact version `10.0.103` |

An exact requirement is pinned and is not changed by `dotnetup update`.

## Use `sdk.paths`

If `global.json` contains `sdk.paths`, dotnetup uses the first path when no
`--install-path` option is present. It resolves a relative value from the
directory that contains `global.json`.

The install-path precedence is:

1. `--install-path`
2. The first `sdk.paths` entry
3. The default dotnetup-managed .NET installation root

### The `$host$` sentinel

`$host$` is **not** a literal directory. It is a sentinel the .NET host resolver understands to mean "use the default host location." dotnetup treats it the same way, and skips empty, null, or whitespace entries while looking for the first meaningful entry:

| First meaningful `sdk.paths` entry | Where dotnetup installs |
|------------------------------------|-------------------------|
| A relative or absolute path (e.g. `.dotnet`) | That path, resolved relative to the directory containing `global.json` |
| `$host$` | The default dotnetup-managed .NET installation root |
| *(no usable entry — empty, or only null/whitespace)* | The default dotnetup-managed .NET installation root |

Because `sdk.paths` is ordered, the first meaningful entry wins. `["$host$", ".dotnet"]` installs to the default installation root and ignores `.dotnet`, while `[".dotnet", "$host$"]` installs to `.dotnet`. A literal path does *not* take precedence over `$host$` unless it appears first.

## Update `global.json`

To install the newest version in the derived channel and write that version
back to `global.json`, run:

```dotnetcli
dotnetup sdk install --update-global-json
```

Later, update all tracked repository requirements and their files with:

```dotnetcli
dotnetup sdk update --update-global-json
```

The update changes only `sdk.version`. It preserves the existing formatting,
other properties, and detected text encoding.

## Remove a repository requirement

Run the uninstall command from any directory and select `globaljson` as the
source:

```dotnetcli
dotnetup sdk uninstall 10.0.1xx --source globaljson
```

`dotnetup` removes files only when no remaining requirement needs them.

## See also

- [Repository and global.json integration](../concepts/repositories.md)
- [dotnetup sdk install](../reference/dotnetup-sdk-install.md)
- [Update tracked installations](update-installations.md)
