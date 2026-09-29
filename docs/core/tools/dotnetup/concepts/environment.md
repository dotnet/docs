---
title: dotnetup environment configuration
description: Learn how dotnetup configures PATH and DOTNET_ROOT for managed .NET installations.
ms.topic: conceptual
ms.date: 08/11/2026
---

# dotnetup environment configuration

Dotnetup can configure the environment to make the .NET SDKs and Runtimes it
installs available.  It does this by setting the following environment
variables:

- **`PATH`**: Makes the `dotnet` command available on the command line.  Dev
  tools such as Visual Studio or C# Dev Kit also use the `PATH` to locate .NET
  SDKs and Runtimes.
- **`DOTNET_ROOT`**: Tells framework-dependent application executables where to
  find a .NET installation and its shared runtimes.

Dotnetup supports different access modes which control where these environment
variables are set.  You can choose an access mode in the initial dotnetup setup
or later with the `dotnetup env` command.

| Access Mode | Behavior |
| --- | --- |
| `none` | Does not modify these environment variables. Run .NET with `dotnetup dotnet`. |
| `shell` | Modifies the shell profile to set these environment variables. Processes started from that shell use the .NET SDKs and Runtimes installed by dotnetup. |
| `everywhere` | Modifies the system `PATH` and sets the user-level `DOTNET_ROOT` environment variable. Only available on Windows. |

By default, dotnetup also adds itself to the `PATH`, regardless of the access
mode setting.  This can be controlled with
`dotnetup env set --dotnetup-on-path <true|false>`.

## Everywhere mode considerations

Everywhere mode is the default on Windows so that SDKs and runtimes installed
by dotnetup will be available from dev tools and from terminals using `cmd` as
the shell.  However, there are some things to be aware of, primarily around how
it interacts with machine-wide installations of the .NET SDK and Runtime.

Machine-wide installations of .NET are located under the Program Files folder.
They can be installed with installers that can be downloaded from the .NET
downloads page.  Visual Studio installs machine-wide installations of the .NET
SDK and Runtime, and installers for framework-dependent applications may also
install the .NET Runtime they depend on in the machine-wide location.

In everywhere mode, the user-local dotnetup-managed .NET installation root will
override the machine-wide .NET installation root.  This means that .NET SDKs
and Runtimes installed in Program Files will not be available.  Projects that
depend on those SDKs will fail to build if a matching SDK is not installed.  If
a matching runtime is not installed, framework-dependent applications will fail
to launch with an error that says "You must install or update .NET to run this
application."

To avoid these failures, the initial dotnetup setup offers the option to
migrate existing system .NET SDK and Runtime installs.  You can also migrate
them explicitly by running `dotnetup sdk install --migrate-from-system` for
SDKs or `dotnetup runtime install --migrate-from-system` for runtimes.

Turning everywhere mode on or off requires modifying the system PATH, which
requires elevation (i.e. a UAC prompt approval, or "Run as Administrator").
This is because the machine-wide installers for .NET add the Program Files .NET
installation root to the system PATH, and the system PATH takes precedence over
the user-level PATH when resolving commands.  So dotnetup needs to modify the
system PATH to make the dotnetup .NET installation root take precedence.

Because the system PATH applies to all users, these changes can impact other
users.  The path that is added to the system PATH is by default under the
user's local AppData folder.  This won't normally be accessible to other users
so it wouldn't affect which version of `dotnet` is resolved.  However, elevated
processes (i.e. running as Administrator) would be able to read the path, and
could end up unexpectedly resolving .NET SDKs or Runtimes from another user.

## Supported shells

Profile and script generation support:

- Bash
- Z shell
- Fish
- Pwsh (PowerShell Core)
- PowerShell

If you do not pass `--shell`, `dotnetup` detects the current shell. Use an
explicit shell when detection is not available or when you want to update a
different profile:

```dotnetcli
dotnetup env set shell --shell zsh
```

## Stored and observed state

`dotnetup.config.json` stores the selected access mode and whether
`dotnetup` should be on `PATH`. `dotnetup env show` compares that
configuration with the current profile and environment. It reports drift if
the observed state does not match.

Reapply the stored configuration to correct drift:

```dotnetcli
dotnetup env set
```

## Current terminal

Profile and Windows environment changes do not rewrite the environment of the
current process. Open a new terminal, source the modified profile, or evaluate
the generated script.

For Bash or Z shell:

```bash
eval "$(dotnetup env script)"
```

For PowerShell:

```powershell
dotnetup env script --shell pwsh | Invoke-Expression
```

`env script` follows the stored configuration when you do not pass selection
options. Use `--dotnet`, `--dotnetup`, or both to select the generated
content.

## Remove environment configuration

Remove all managed environment wiring:

```dotnetcli
dotnetup env clear
```

This command is equivalent to:

```dotnetcli
dotnetup env set none --dotnetup-on-path false
```

It does not uninstall SDKs or runtimes.
