---
title: Use dotnetup in automation
description: Use deterministic dotnetup commands and machine-readable output in scripts and CI.
ms.topic: how-to
ms.date: 08/07/2026
---

# Use dotnetup in automation

`dotnetup` disables first-use onboarding when it detects CI or redirected
output. Use explicit commands and options so scripts do not depend on terminal
detection.

## Install for a build

Install a rolling feature band:

```dotnetcli
dotnetup sdk install 10.0.1xx --no-progress --interactive false
dotnetup dotnet test -- --logger trx
```

Install an exact version when a build must stay pinned:

```dotnetcli
dotnetup sdk install 10.0.103 --no-progress --interactive false
```

Exact requirements are not changed by update commands.

## Use a repository-local root

```dotnetcli
dotnetup sdk install 10.0.1xx --install-path .\.dotnet --no-progress
```

Run the local executable directly or activate it with `dotnetup env script`.
The forwarding command uses the default dotnetup-managed .NET installation
root.

## Read state as JSON

```dotnetcli
dotnetup list --format json --no-verify
```

Omit `--no-verify` when the automation must check that recorded files are
present and valid.

## Keep output useful

- Use `--no-progress` when logs do not support terminal progress.
- Use `--verbosity normal` for normal automation.
- Use `--verbosity detailed` to diagnose resolution or installation.
- Check the command exit code. Update commands can continue after an
  individual failure and report failure after processing other requirements.

## Coordinate writers

Do not run concurrent install, update, or uninstall commands against the same
manifest. Use an isolated `--manifest-path` for independent jobs.

## See also

- [dotnetup list](../reference/dotnetup-list.md)
- [Manage custom installation roots](manage-custom-installation-roots.md)
- [Update tracked installations](update-installations.md)
