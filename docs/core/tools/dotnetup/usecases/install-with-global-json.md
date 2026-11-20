---
title: Install an SDK for a repository with dotnetup
description: Use global.json to install and track the SDK requirement for a repository.
ms.topic: how-to
ms.date: 08/07/2026
ai-usage: ai-assisted
---

# Install an SDK for a repository with dotnetup

[!INCLUDE [public-preview](../includes/public-preview.md)]

When you do not supply an SDK channel, `dotnetup sdk install` searches from
the current directory toward the file system root. It uses the nearest
existing `global.json` file. If that file is malformed, the command fails
instead of searching a parent directory. If no file exists, it uses `latest`.

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
The `allowPrerelease` property does not affect the channel that dotnetup derives.

## Use `sdk.paths`

If `global.json` contains `sdk.paths`, dotnetup uses the first path when no
`--install-path` option is present. It resolves a relative value from the
directory that contains `global.json`.

The install-path precedence is:

1. `--install-path`
2. The first `sdk.paths` entry
3. The default dotnetup-managed .NET installation root

### Preview limitations

The current public-preview build treats the first `sdk.paths` entry as a path.
It doesn't interpret `$host$` as a sentinel or skip empty entries. To use the
default dotnetup-managed installation root, omit `sdk.paths` or set
`--install-path` explicitly.

## Update `global.json`

After you change `sdk.version` or `rollForward`, run `dotnetup sdk install`
from the repository directory to apply the new requirement. Before garbage
collection refreshes changed `global.json` sources, `dotnetup sdk update`
processes stored requirements, so its first pass might still use the previous
requirement.

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

## Remove matching repository requirements

The uninstall command removes every matching `globaljson` specification in
the selected installation root. It doesn't target one repository. To remove
matching requirements from the default root, run:

```dotnetcli
dotnetup sdk uninstall 10.0.1xx --source globaljson
```

To select a custom installation root, add `--install-path`:

```dotnetcli
dotnetup sdk uninstall 10.0.1xx --source globaljson --install-path <INSTALL_PATH>
```

`dotnetup` removes files only when no remaining requirement needs them.

## See also

- [Repository and global.json integration](../concepts/repositories.md)
- [dotnetup sdk install](../reference/dotnetup-sdk-install.md)
- [Update tracked installations](update-installations.md)
