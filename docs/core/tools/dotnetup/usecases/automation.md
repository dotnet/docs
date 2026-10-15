---
title: Use dotnetup in automation
description: Use deterministic dotnetup commands and machine-readable output in scripts and CI.
ms.topic: how-to
ms.date: 09/30/2026
ai-usage: ai-assisted
---

# Use dotnetup in automation

[!INCLUDE [public-preview](../includes/public-preview.md)]

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

## Use dotnetup in GitHub Actions

The following workflow installs `dotnetup`, installs the SDK that the
repository's `global.json` file requires, and then builds and tests the code:

```yaml
name: build

on: [push, pull_request]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4

      - name: Install dotnetup
        run: |
          curl -fsSL https://aka.ms/dotnetup/get-dotnetup.sh | bash
          echo "$HOME/.dotnetup" >> "$GITHUB_PATH"

      - name: Install the .NET SDK
        run: dotnetup sdk install --no-progress --interactive false

      - name: Build and test
        run: dotnetup dotnet test
```

The download script doesn't change `PATH`. The workflow adds the `dotnetup`
directory to `GITHUB_PATH` so that later steps can run `dotnetup`.

When you omit the channel, `dotnetup sdk install` uses the nearest
`global.json` file. If it can't find a requirement, it installs `latest`. For
more information, see
[Manage repository SDK requirements](install-with-global-json.md).

`dotnetup dotnet` sets `PATH` and `DOTNET_ROOT` for the command that it starts.
Other steps that run `dotnet` directly don't use the dotnetup-managed
installation.

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
