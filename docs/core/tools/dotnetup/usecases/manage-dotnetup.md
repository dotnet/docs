---
title: Update or remove dotnetup
description: Learn how to check the dotnetup version, update dotnetup, and completely remove dotnetup and the .NET installations that it manages.
ms.topic: how-to
ms.date: 10/13/2026
ai-usage: ai-generated
---

# Update or remove dotnetup

[!INCLUDE [public-preview](../includes/public-preview.md)]

This article describes how to manage the `dotnetup` tool itself. To update or
remove the .NET SDKs and runtimes that `dotnetup` manages, see
[Update installations](update-installations.md).

## Check the dotnetup version

Show the version of `dotnetup`:

```dotnetcli
dotnetup --version
```

To also show the commit, architecture, runtime identifier, and the verified
installations, run:

```dotnetcli
dotnetup --info
```

## Update dotnetup

To update the standalone dotnetup executable in place, run:

```dotnetcli
dotnetup self update
```

This command is available in dotnetup 0.3.0 preview builds. It selects the
release channel from the installed version label.
Official daily builds also use the `preview` label, so specify the channel
explicitly to stay on daily builds:

```dotnetcli
dotnetup self update --channel daily
```

To return from a newer daily build to the latest public preview, run:

```dotnetcli
dotnetup self update --channel preview --force
```

`--force` can downgrade or reinstall the executable.
For command options and restrictions, see
[`dotnetup self update`](../reference/dotnetup-self-update.md).

An update of `dotnetup` doesn't change your .NET installations, your environment
configuration, or your tracked install specifications.

### Update an older version or recover the executable

If your version doesn't recognize `self update`, or the executable no longer
starts, run the download script again.
The script replaces the existing executable in the selected installation directory.

On macOS or Linux, run:

```bash
curl -fsSL https://aka.ms/dotnetup/get-dotnetup.sh | bash
```

On Windows, run:

```powershell
irm https://aka.ms/dotnetup/get-dotnetup.ps1 | iex
```

The script installs the latest `preview` build by default. If you use the
`daily` build or a custom installation directory, pass the same options that
you used for the first installation. For example, on macOS or Linux:

```bash
curl -fsSL https://aka.ms/dotnetup/get-dotnetup.sh |
  bash -s -- --quality daily --install-dir /opt/dotnetup
```

On Windows:

```powershell
iex "& { $(irm https://aka.ms/dotnetup/get-dotnetup.ps1) } -Quality daily -InstallDir C:\tools\dotnetup"
```

### Configure update notifications

After successful interactive install and update commands, dotnetup can notify
you that a newer build is available. The notice doesn't install the update.

To disable notifications, run:

```dotnetcli
dotnetup self update --update-notifications false
```

To enable notifications again, use `--update-notifications true`.
For the check frequency and output behavior, see
[Update notifications](../reference/dotnetup-self-update.md#update-notifications).

## Remove dotnetup

To remove `dotnetup` and everything that it manages, complete these steps in
order.

### 1. Find your installation roots

List the installation roots that `dotnetup` tracks:

```dotnetcli
dotnetup list
```

Record each installation root that isn't in the dotnetup data directory. You
delete these folders in a later step.

### 2. Remove the environment configuration

Remove the `PATH` and `DOTNET_ROOT` changes that `dotnetup` made:

```dotnetcli
dotnetup env clear
```

In `shell` mode, run this command from the shell whose profile `dotnetup`
changed, or select that shell with the `--shell` option. In `everywhere` mode
on Windows, this command changes the system `PATH` and requires elevation.

This command doesn't remove SDKs or runtimes. For more information, see
[Remove environment configuration](../concepts/environment.md#remove-environment-configuration).

### 3. Delete the installation roots and data directory

Delete each installation root that you recorded in step 1.

Then delete the dotnetup data directory. This directory contains the default
installation root, the manifest, the configuration file, and the download
cache.

| Operating system | Default data directory |
| --- | --- |
| Windows | `%LOCALAPPDATA%\dotnetup` |
| macOS | `~/Library/Application Support/dotnetup` |
| Linux | `$XDG_DATA_HOME/dotnetup`, or `~/.local/share/dotnetup` when `XDG_DATA_HOME` isn't set |

If you set the `DOTNET_DOTNETUP_DATA_DIR` environment variable, delete that
directory instead, and then remove the variable.

### 4. Delete the dotnetup executable

Delete the directory that contains the `dotnetup` executable. By default, the
download script installs `dotnetup` in `~/.dotnetup`. If you added this
directory to `PATH` manually, remove that entry from your shell profile or
from your user environment variables.

Open a new terminal to use the updated environment.

## See also

- [How dotnetup works](../concepts/how-dotnetup-works.md)
- [dotnetup environment configuration](../concepts/environment.md)
- [Get started with dotnetup](../getting-started.md)
