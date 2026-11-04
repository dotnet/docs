---
title: dotnetup self update command
description: Command reference for updating the dotnetup executable and configuring update notifications.
ms.topic: reference
ms.date: 10/13/2026
ai-usage: ai-assisted
---

# dotnetup self update command

[!INCLUDE [public-preview](../includes/public-preview.md)]

## Name

`dotnetup self update` - Update the standalone dotnetup executable from a release channel.

## Synopsis

```console
dotnetup self update [--channel <daily|preview|stable>] [--force]
                    [--no-progress [<true|false>]]
dotnetup self update --update-notifications <true|false>
```

## Description

The command updates the running standalone `dotnetup` executable in place.
It downloads the latest available build for the selected release channel and
the current operating system and architecture.
It doesn't update managed .NET SDKs or runtimes. For those installations, use
[`dotnetup update`](dotnetup-update.md).

On the same version channel, an equal or older available version doesn't
replace the installed executable unless you specify `--force`.
The command reports that no update was applied and returns exit code `0`.
A change between version channels, such as a preview version and a stable
version, can replace the executable even when the target version is older.

The installation directory must be writable. Self-update doesn't support
execution through the `dotnet` host or an executable that's a symbolic link
or another reparse point. Use the standalone executable in its actual
installation directory.

While self-update holds its coordination locks, other dotnetup commands can
fail with a message that an update is in progress.
Retry those commands after self-update finishes.

For older versions that don't recognize `self update`, or for recovery when
the executable no longer starts, use the
[download scripts](../getting-started.md#download-dotnetup).

## Options

| Option | Description |
| --- | --- |
| `--channel <daily\|preview\|stable>` | Select the dotnetup release channel, not a .NET SDK channel. By default, versions without a prerelease label use `stable`, versions with a `preview` label use `preview`, and other prerelease versions use `daily`. |
| `--force` | Install the selected channel's latest build even when it isn't newer. This option can reinstall or downgrade dotnetup. |
| `--update-notifications <true\|false>` | Enable or disable update notifications without updating the executable. This option can't be combined with `--channel` or `--force`. |
| `--no-progress [<true\|false>]` | Disable download progress display. |
| `-?`, `-h`, `--help` | Show command help. |

Official daily builds also carry the `preview` version label, so they default
to the preview channel. To stay on daily builds, specify `--channel daily`.
The parser accepts `stable`, but no stable dotnetup release is available
during this public preview.

## Update notifications

After successful interactive install and update commands, dotnetup can write
a notice to standard output when a newer dotnetup build is available.
These commands include bare `dotnetup`, `install`, `sdk install`,
`runtime install`, `update`, `sdk update`, and `runtime update`.

Notifications are enabled by default. The check uses the running build's
default release channel and refreshes in the background at most once every
24 hours after a successful check.
It doesn't download or install the executable.
A successful refresh produces at most one notice. A short command might
finish before the refresh, so the notice can appear after a later command.

Notifications don't appear when output is redirected, even with
`--interactive true`. A failed check doesn't fail the install or update
command.

To disable notifications, run:

```dotnetcli
dotnetup self update --update-notifications false
```

To enable notifications again, run:

```dotnetcli
dotnetup self update --update-notifications true
```

## Examples

Update dotnetup from its default release channel:

```dotnetcli
dotnetup self update
```

Update to the latest daily build without download progress:

```dotnetcli
dotnetup self update --channel daily --no-progress
```

Return to the latest preview build, even if it's older than the installed
daily build:

```dotnetcli
dotnetup self update --channel preview --force
```

## See also

- [Update or remove dotnetup](../usecases/manage-dotnetup.md)
- [How dotnetup verifies downloads](../concepts/download-verification.md#the-dotnetup-executable)
- [Troubleshoot dotnetup](../troubleshooting.md)
