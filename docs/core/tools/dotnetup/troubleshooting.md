---
title: Troubleshoot dotnetup
description: Diagnose and fix common dotnetup problems, such as missing SDKs, untracked installations, locked files, and corrupted state files.
ms.topic: troubleshooting
ms.date: 09/30/2026
ai-usage: ai-generated
---

# Troubleshoot dotnetup

[!INCLUDE [public-preview](includes/public-preview.md)]

This article describes common `dotnetup` problems and how to fix them.

## Collect diagnostic information

Before you troubleshoot a problem, collect this information:

- Show the `dotnetup` version, architecture, runtime identifier, and the
  verified installations:

  ```dotnetcli
  dotnetup --info
  ```

- Show the tracked install specifications and installations, and verify the
  files on disk:

  ```dotnetcli
  dotnetup list
  ```

- Compare the stored environment configuration with the current environment:

  ```dotnetcli
  dotnetup env show
  ```

- Run the failed command again with detailed output. For example:

  ```dotnetcli
  dotnetup sdk install 10.0 --verbosity detailed
  ```

## Projects don't build or apps don't start after setup

**Symptom:** After you set up `dotnetup` in `everywhere` mode on Windows,
projects that built before now fail to build. Or, framework-dependent apps show
this error:

```output
You must install or update .NET to run this application.
```

**Cause:** In `everywhere` mode, the dotnetup-managed installation takes
precedence over the machine-wide installation in Program Files. SDKs and
runtimes that exist only in the machine-wide installation aren't available.

**Solution:** Migrate the machine-wide SDKs and runtimes into the
dotnetup-managed installation:

```dotnetcli
dotnetup sdk install --migrate-from-system
dotnetup runtime install --migrate-from-system
```

Or, change to the `shell` or `none` access mode. For more information, see
[Everywhere mode considerations](concepts/environment.md#everywhere-mode-considerations).

## dotnet doesn't use the dotnetup-managed installation

**Symptom:** The `dotnet` command in your terminal doesn't use the SDKs that
`dotnetup` installed.

**Cause:** The terminal was open before `dotnetup` changed the environment, or
the environment configuration doesn't match the stored configuration.

**Solution:**

1. Open a new terminal. Changes to the shell profile or to Windows environment
   variables don't affect terminals that are already open.
1. Run `dotnetup env show`. If it reports drift, run `dotnetup env set` to
   apply the stored configuration again.
1. To configure only the current terminal, evaluate the output of
   `dotnetup env script`. For example, in Bash or zsh:

   ```bash
   eval "$(dotnetup env script)"
   ```

   In PowerShell:

   ```powershell
   dotnetup env script --shell pwsh | Invoke-Expression
   ```

For more information, see
[Manage the dotnetup environment](usecases/manage-environment.md).

## Install path already contains an untracked installation

**Symptom:** An install command fails with this error:

```output
The install path '<path>' already contains a .NET installation that is not tracked by dotnetup. To avoid conflicts, use a different install path, remove the existing installation first, or use the --untracked option to install without tracking.
```

**Cause:** `dotnetup` doesn't install tracked files into a folder that contains
a .NET installation that it doesn't track. This check prevents `dotnetup` from
mixing its files with files that another tool owns.

**Solution:** Do one of the following:

- Select a different folder with the `--install-path` option.
- Remove the existing installation from the folder.
- If another tool owns the folder, use the `--untracked` option. `dotnetup`
  doesn't list, update, or remove untracked files.

For more information, see
[Manage custom installation roots](usecases/manage-custom-installation-roots.md).

## The dotnet executable is in use

**Symptom:** On Windows, an install command shows a warning similar to this
message:

```output
Warning: Could not update dotnet executable at '<path>' - it is currently in use by another process. Close all running .NET applications and try again. The existing muxer will be retained. ...
```

**Cause:** A running process uses the `dotnet` executable, so `dotnetup` can't
replace it. The installation continues with the existing `dotnet` executable.
A new runtime might require a newer `dotnet` executable.

**Solution:** Close all running .NET apps, IDEs, and build servers. Then, run
the install command again. To make the command fail instead of continuing with
a warning, use the `--require-muxer-update` option.

## Another dotnetup process is running

**Symptom:** A command shows this message and waits:

```output
Another dotnetup process is running. Waiting for it to finish...
```

**Cause:** `dotnetup` serializes changes to shared installation state. Another
`dotnetup` command is changing the same state.

**Solution:** Wait for the other command to finish. If no other `dotnetup`
process runs, look for `dotnetup` processes that stopped responding, and end
them.

## The manifest is corrupt

**Symptom:** A command fails with this error:

```output
The dotnetup manifest at <path> is corrupt. Consider deleting it and re-running the install.
```

The message can also say that the file was modified outside of `dotnetup`.

**Cause:** The `dotnetup_manifest.json` file isn't valid. Another process or a
manual edit might have changed the file.

**Solution:** Delete the manifest file and its `.sha256` file from the dotnetup
data directory. Then, reinstall the SDKs and runtimes that you need. Because the
manifest no longer tracks the existing installation root, you might also need
to delete that folder first. For the location of the data directory, see
[Update or remove dotnetup](usecases/manage-dotnetup.md#3-delete-the-installation-roots-and-data-directory).

> [!NOTE]
> Don't edit the manifest file. Use `dotnetup` commands to change the tracked
> state.

## The configuration file is corrupt

**Symptom:** A command shows this warning:

```output
Warning: The dotnetup config file at <path> appears to be corrupted and could not be read: ...
```

**Cause:** The `dotnetup.config.json` file isn't valid. `dotnetup` ignores the
file.

**Solution:** Run `dotnetup env set` with the access mode that you want, or run
`dotnetup init` again. These commands write a new configuration.

## A shell profile contains a malformed dotnetup block

**Symptom:** An `env` command fails with an error similar to this message:

```output
The shell profile '<path>' contains a malformed dotnetup block: '<begin marker>' does not have a matching '<end marker>'. Remove or repair the block manually and try again.
```

**Cause:** `dotnetup` marks the lines that it adds to a shell profile with begin
and end comments. One of these comments is missing.

**Solution:** Open the shell profile in a text editor. Remove the incomplete
dotnetup block, or add the missing marker. Then, run the command again.

## Elevation was canceled

**Symptom:** On Windows, a command that turns `everywhere` mode on or off shows
this message:

```output
Elevation was cancelled. The system PATH was not modified.
```

**Cause:** Changes to the system `PATH` require elevation. The User Account
Control (UAC) prompt was canceled.

**Solution:** Run the command again and approve the UAC prompt. Or, select the
`shell` or `none` access mode, which doesn't require elevation.

## A release manifest has expired

**Symptom:** An install or update fails during release-manifest verification
with the `ExpiredNow` failure code.

**Cause:** The current system time is at or after the manifest's expiration
time. The manifest might be expired, or the system clock might be incorrect.
A valid signature doesn't make an expired manifest acceptable.

**Solution:**

1. Check your system's date and time. Correct the clock if necessary.
1. Retry the command. If a proxy serves cached release metadata, ask your
   administrator to check whether it serves an expired manifest.
1. If the clock is correct and the failure persists, report the problem with
   the command's detailed output.

Don't edit the manifest or change the clock to bypass expiration checks.
For more information, see
[Manifest expiration](concepts/download-verification.md#manifest-expiration).

## An installation is blocked by an IT policy

**Symptom:** An install of a daily or prerelease build fails with a message
that says that an IT policy requires code-signed downloads.

**Cause:** An administrator blocked unsigned downloads on the machine.

**Solution:** Install a released version, or ask your administrator to clear
the policy. For more information, see
[How dotnetup verifies downloads](concepts/download-verification.md#block-unsigned-downloads).

## Report a problem

If this article doesn't solve your problem, search the
[existing dotnetup issues](https://github.com/dotnet/sdk/issues?q=is%3Aissue%20label%3AArea-dotnetup).
If you don't find a match, open a new issue in the
[dotnet/sdk repository](https://github.com/dotnet/sdk/issues/new/choose) with
the **dotnetup issue** template. Include the output of `dotnetup --info` and
the output of the failed command with `--verbosity detailed`.

For questions and suggestions, use
[dotnetup discussions](https://github.com/dotnet/sdk/discussions/categories/dotnetup).

## See also

- [How dotnetup works](concepts/how-dotnetup-works.md)
- [dotnetup environment configuration](concepts/environment.md)
- [dotnetup command reference](reference/dotnetup.md)
