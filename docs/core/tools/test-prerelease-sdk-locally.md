---
title: Test prerelease .NET SDKs locally with global.json paths
description: Learn how to install and test prerelease .NET 11 SDKs in a project-local directory using the global.json paths feature, without affecting your system-wide installation.
author: jfversluis
ms.author: joverslu
ms.date: 04/08/2026
ms.topic: how-to
ai-usage: ai-assisted
---

# Test prerelease .NET SDKs locally with global.json paths

Starting with .NET 10, the `global.json` file supports an `sdk.paths` property that tells the .NET CLI where to look for SDK installations beyond the default system location. This feature lets you install a prerelease SDK into a project-local folder and use it only when you're working in that project. The process doesn't modify system-wide installations, and it doesn't change your machine-level or user-level `PATH` environment variable. (The install script might temporarily update `PATH` in the current shell session, but that change doesn't persist.)

Whether you want to try out a new language feature, evaluate a preview release for your team, or validate your open-source library against an upcoming SDK version in CI, `sdk.paths` gives you a safe, reversible way to do it. If anything goes wrong, you delete one folder and you're back to exactly where you started.

> [!NOTE]
> This article uses .NET 11 (the current prerelease at the time of writing) as an example throughout. The `sdk.paths` feature works with any SDK version, prerelease or stable, current or future. Replace `11.0` and `preview` in the install commands with whichever version and quality you need.

## Prerequisites

- [.NET 10](https://dotnet.microsoft.com/download/dotnet/10.0) or later installed on your system so that the `dotnet` host on your `PATH` is version 10.0 or later. The *host* is the system-wide `dotnet` executable available to your entire machine. When you run any `dotnet` command, this host is what kicks in first: it reads `global.json`, decides which SDK version to use, and hands off to that SDK. In this how-to article, you use that system-wide host to steer the CLI toward a locally installed preview SDK.
- A terminal or command prompt (bash, zsh, PowerShell, or Command Prompt).
- (Optional) A Git repository where you want to scope the prerelease SDK.

> [!IMPORTANT]
> The `sdk.paths` feature requires a .NET 10 or later **host** (the `dotnet` executable on your `PATH`). If your system-wide host is .NET 8 or .NET 9, it won't recognize the `paths` property and falls back to default resolution behavior. You can still use the local SDK by invoking `./.dotnet/dotnet` (or `.\.dotnet\dotnet` on Windows) directly, which bypasses the system host.

To verify your host version, run `dotnet --info` and look for the **Host** section near the top of the output:

```output
Host:
  Version:      10.0.0
  Architecture: x64
  Commit:       abc123def4
```

The `Version` line must show `10.0` or later. The host version is **not** the same as the SDK version reported by `dotnet --version`. If the host shows an older version (for example, `8.0.x` or `9.0.x`), [install .NET 10+ system-wide](https://dotnet.microsoft.com/download/dotnet/10.0) to update the `dotnet` host on your `PATH`.

## How sdk.paths works

The `sdk.paths` property is a JSON array of folder paths where the .NET host looks for SDK installations. The host searches these paths in the order you list them, and uses the first SDK that satisfies the version constraints in `global.json`.

Two key details:

- **Paths are relative to the `global.json` file's location**, not to your current working directory. If your `global.json` is at the repo root and you specify `".dotnet"`, the host looks for an SDK in the `.dotnet` folder at the repo root — even if you run `dotnet` commands from a subdirectory.
- **`$host$` is a special token** that represents the system-wide .NET installation directory (the location of the `dotnet` executable on your `PATH`). Include `$host$` in the array when you want the system SDK as a fallback.

> [!NOTE]
> Both the `$host$` token and the entire `paths` property are only recognized by .NET 10+ hosts. Older hosts ignore them entirely — they don't produce an error, they simply skip the property and fall back to default SDK resolution.

For example, the following configuration tells the host to look for an SDK first in a local `.dotnet` folder, then fall back to the system installation:

```json
{
  "sdk": {
    "paths": [".dotnet", "$host$"]
  }
}
```

If you omit `$host$` from the array, the host only searches the directories you specify. If none of them contain a matching SDK, the command fails — which can be useful when you want to enforce that a specific SDK is present.

You can list more than two entries. For example, you could keep separate folders for a preview and a stable SDK and search them in order: `[".dotnet-preview", ".dotnet-stable", "$host$"]`.

## Step 1: Install a prerelease SDK locally

Use the official [dotnet-install scripts](dotnet-install-script.md) to download a prerelease SDK into a project-local directory. These scripts don't require administrator privileges and don't modify your system `PATH` or any system-wide installation.

### [macOS / Linux](#tab/bash)

```bash
curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 11.0 --quality preview --install-dir .dotnet
```

### [Windows (PowerShell)](#tab/powershell)

```powershell
Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile 'dotnet-install.ps1'
.\dotnet-install.ps1 -Channel 11.0 -Quality preview -InstallDir .dotnet
```

> [!NOTE]
> If script execution is blocked by your system's execution policy, run the install script with:
> `powershell -ExecutionPolicy Bypass -File .\dotnet-install.ps1 -Channel 11.0 -Quality preview -InstallDir .dotnet`

---

The `--install-dir` (or `-InstallDir`) parameter places the SDK in a `.dotnet` folder inside your current directory. No files are written anywhere else on your machine.

> [!TIP]
> The `--quality` parameter accepts three values: `daily` (latest nightly build), `preview` (latest official preview), and `GA` (latest stable release). You can also use `--version` to install an exact SDK version, such as `--version 11.0.100-preview.2.26159.112`.

## Step 2: Add .dotnet/ to .gitignore

The local SDK installation can be several hundred megabytes. Add it to your `.gitignore` to keep it out of source control:

### [macOS / Linux](#tab/bash)

```bash
echo '.dotnet/' >> .gitignore
```

### [Windows (PowerShell)](#tab/powershell)

```powershell
Add-Content -Path .gitignore -Value '.dotnet/'
```

---

If your project already has a `.gitignore`, verify that `.dotnet/` isn't being tracked before committing:

```bash
git status --ignored
```

> [!NOTE]
> Each developer (and each CI agent) runs the install script independently. The `.dotnet` folder is a local cache, not a shared artifact.

## Step 3: Configure global.json

Create or update a `global.json` file at the root of your repository. At minimum, you only need the `paths` property to get started:

```json
{
  "sdk": {
    "paths": [".dotnet", "$host$"]
  }
}
```

This tells the host to look for an SDK first in the local `.dotnet` folder, then fall back to the system installation. No version number is required — the host picks the latest SDK it finds.

For more control, you can pin a minimum version and configure roll-forward behavior:

```json
{
  "sdk": {
    "version": "11.0.100-preview.2.26159.112",
    "allowPrerelease": true,
    "rollForward": "latestFeature",
    "paths": [".dotnet", "$host$"],
    "errorMessage": "Required .NET SDK not found. Run the install-dotnet script for your platform to install it locally."
  }
}
```

Here's what each property does:

| Property | Purpose |
|---|---|
| `version` | The minimum SDK version required by the project. |
| `allowPrerelease` | Allows the host to select prerelease SDK versions during roll-forward. Set to `true` when testing previews. |
| `rollForward` | Controls how the host selects a newer SDK when the exact version isn't available. `latestFeature` allows rolling forward to a newer feature band within the same major.minor version. |
| `paths` | Directories to search for SDK installations, in order. `".dotnet"` is the local folder; `"$host$"` is the system default. |
| `errorMessage` | A custom message shown when no matching SDK is found. Use it to tell contributors exactly how to set up their environment. |

> [!TIP]
> Listing `".dotnet"` before `"$host$"` means the local prerelease SDK takes priority. Reverse the order if you want the system SDK to win when it satisfies the version constraint.

> [!TIP]
> Changed your mind? See [Clean up](#clean-up) at the end of this article. No system files are touched.

## Quick start: all-in-one command

Now that you understand what each step does, here's a single command that performs Steps 1 through 3 in one go. Paste the command for your OS into a terminal at your project root.

### [macOS / Linux](#tab/bash)

```bash
curl -sSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh \
  && bash /tmp/dotnet-install.sh --channel 11.0 --quality preview --install-dir .dotnet \
  && rm /tmp/dotnet-install.sh \
  && echo '.dotnet/' >> .gitignore \
  && cat > global.json << 'EOF'
{
  "sdk": {
    "paths": [".dotnet", "$host$"]
  }
}
EOF
echo "Installed: $(.dotnet/dotnet --version)"
```

### [Windows (PowerShell)](#tab/powershell)

```powershell
Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile "$env:TEMP\dotnet-install.ps1"
& "$env:TEMP\dotnet-install.ps1" -Channel 11.0 -Quality preview -InstallDir .dotnet
Remove-Item "$env:TEMP\dotnet-install.ps1"
Add-Content -Path .gitignore -Value '.dotnet/'
@'
{
  "sdk": {
    "paths": [".dotnet", "$host$"]
  }
}
'@ | Set-Content -Path global.json
Write-Host "Installed: $(& .\.dotnet\dotnet.exe --version)"
```

---

## Step 4: Create team install scripts (optional)

When multiple people work on the same repository, a convenience script prevents everyone from having to remember the install commands. Create one script for each platform at the root of your repo. These scripts install the SDK, create `global.json`, update `.gitignore`, and optionally install workloads — all in one step.

**install-dotnet.sh** (macOS/Linux):

### [macOS / Linux](#tab/bash)

```bash
#!/usr/bin/env bash
set -e

# -------- Configuration --------
CHANNEL="11.0"
QUALITY="preview"
# Uncomment the workloads your project needs:
# WORKLOADS="maui wasm-tools"
# --------------------------------

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
INSTALL_DIR="$SCRIPT_DIR/.dotnet"

echo "Installing .NET $CHANNEL ($QUALITY) SDK to $INSTALL_DIR ..."

curl -sSL https://dot.net/v1/dotnet-install.sh -o "$SCRIPT_DIR/dotnet-install.sh"
chmod +x "$SCRIPT_DIR/dotnet-install.sh"
"$SCRIPT_DIR/dotnet-install.sh" --channel "$CHANNEL" --quality "$QUALITY" --install-dir "$INSTALL_DIR"
rm -f "$SCRIPT_DIR/dotnet-install.sh"

# Auto-detect the installed SDK version
SDK_VERSION="$("$INSTALL_DIR/dotnet" --version)"

# Create global.json with the installed version
cat > "$SCRIPT_DIR/global.json" << EOF
{
  "sdk": {
    "version": "$SDK_VERSION",
    "allowPrerelease": true,
    "rollForward": "latestFeature",
    "paths": [".dotnet", "\$host\$"],
    "errorMessage": "Required .NET SDK not found. Run ./install-dotnet.sh (macOS/Linux) or .\\\\install-dotnet.ps1 (Windows) to install it locally."
  }
}
EOF

# Ensure .dotnet/ is in .gitignore
if ! grep -qxF '.dotnet/' "$SCRIPT_DIR/.gitignore" 2>/dev/null; then
    echo '.dotnet/' >> "$SCRIPT_DIR/.gitignore"
fi

# Install workloads if configured
if [ -n "${WORKLOADS:-}" ]; then
    echo "Installing workloads: $WORKLOADS"
    # shellcheck disable=SC2086
    "$INSTALL_DIR/dotnet" workload install $WORKLOADS
fi

echo ""
echo "Done! SDK $SDK_VERSION installed to $INSTALL_DIR"
echo "Run 'dotnet --version' to verify."
```

### [Windows (PowerShell)](#tab/powershell)

```powershell
$ErrorActionPreference = 'Stop'

# -------- Configuration --------
$Channel  = '11.0'
$Quality  = 'preview'
# Uncomment the workloads your project needs:
# $Workloads = @('maui', 'wasm-tools')
# --------------------------------

$scriptDir  = Split-Path -Parent $MyInvocation.MyCommand.Definition
$installDir = Join-Path $scriptDir '.dotnet'

Write-Host "Installing .NET $Channel ($Quality) SDK to $installDir ..."

$installerPath = Join-Path $scriptDir 'dotnet-install.ps1'
Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile $installerPath
& $installerPath -Channel $Channel -Quality $Quality -InstallDir $installDir
Remove-Item $installerPath -ErrorAction SilentlyContinue

# Auto-detect the installed SDK version
$sdkVersion = & (Join-Path $installDir 'dotnet.exe') --version

# Create global.json with the installed version
@"
{
  "sdk": {
    "version": "$sdkVersion",
    "allowPrerelease": true,
    "rollForward": "latestFeature",
    "paths": [".dotnet", "`$host`$"],
    "errorMessage": "Required .NET SDK not found. Run ./install-dotnet.sh (macOS/Linux) or .\\install-dotnet.ps1 (Windows) to install it locally."
  }
}
"@ | Set-Content -Path (Join-Path $scriptDir 'global.json') -Encoding UTF8

# Ensure .dotnet/ is in .gitignore
$gitignorePath = Join-Path $scriptDir '.gitignore'
if (!(Test-Path $gitignorePath) -or !(Select-String -Path $gitignorePath -Pattern '^\s*\.dotnet/\s*$' -Quiet)) {
    Add-Content -Path $gitignorePath -Value '.dotnet/'
}

# Install workloads if configured
if ($Workloads) {
    Write-Host "Installing workloads: $($Workloads -join ', ')"
    & (Join-Path $installDir 'dotnet.exe') workload install @Workloads
}

Write-Host ""
Write-Host "Done! SDK $sdkVersion installed to $installDir"
Write-Host "Run 'dotnet --version' to verify."
```

---

Make the shell script executable and add both scripts to your repository:

```bash
chmod +x install-dotnet.sh
git add install-dotnet.sh install-dotnet.ps1
```

With these scripts checked in, the `errorMessage` in `global.json` can direct contributors to run the appropriate one for their platform. A new team member clones the repo, runs the script, and is ready to build — no manual SDK installation steps to follow.

## Step 5: Verify the installation

From the directory that contains your `global.json` (or any subdirectory), run the following commands to confirm the host is resolving the local prerelease SDK:

```dotnetcli
dotnet --version
```

The output should show the prerelease version you installed, for example:

```output
11.0.100-preview.2.26159.112
```

For more detailed information about which SDK was resolved and where it was loaded from, run:

```dotnetcli
dotnet --info
```

Look for the **Base Path** line in the output. It should point to the `.dotnet` folder relative to your project, confirming that the local installation is in use.

> [!NOTE]
> If the output shows your system SDK version instead of the prerelease, check the following:
>
> - **Host version vs. SDK version:** The *host* version (shown in `dotnet --info` under the **Host** heading) determines whether `paths` is understood. It must be 10.0 or later. The *SDK* version (shown by `dotnet --version`) is the version resolved after the host processes `global.json`.
> - The `global.json` file is in a parent directory of your current working directory.
> - The `.dotnet` folder contains a complete SDK installation (check for a `sdk` subfolder inside it).

## Step 6: Install workloads on the local SDK (optional)

After you install a local SDK, you can install optional workloads like .NET MAUI or Blazor WebAssembly AOT on it. Workloads installed on the local SDK are completely independent of workloads on your system-wide installation.

### Install a workload

Make sure you run this from the folder that contains your `global.json` (or a subdirectory of it). Use the local `dotnet` binary directly to ensure the workload is installed in the local SDK and not your system installation:

### [macOS / Linux](#tab/bash)

```bash
./.dotnet/dotnet workload install maui
```

### [Windows (PowerShell)](#tab/powershell)

```powershell
.\.dotnet\dotnet.exe workload install maui
```

---

> [!IMPORTANT]
> Always use `./.dotnet/dotnet` (or `.\.dotnet\dotnet` on Windows) for workload commands. The `global.json` `paths` feature routes SDK resolution correctly for commands like `dotnet build` and `dotnet run`, but workload commands store metadata relative to the `dotnet` root of the host that runs them. When you use the system host, workloads end up in the system installation rather than the local one. This is a [known gap](https://github.com/dotnet/sdk/issues/49825) in how `sdk.paths` interacts with `DOTNET_ROOT`. Using the local binary directly ensures workloads are installed and tracked in the right place.

> [!NOTE]
> On macOS and Linux, you do **not** need `sudo` for workload install when using a local SDK. The `.dotnet/` folder is user-owned, so all workload files are written with your normal user permissions. This is different from system-wide installs, which might require elevated privileges.

### Common workloads

The following table lists commonly used workloads:

| Workload | Install command |
|---|---|
| .NET MAUI | `./.dotnet/dotnet workload install maui` |
| ASP.NET Core (Blazor WASM AOT) | `./.dotnet/dotnet workload install wasm-tools` |

You can install multiple workloads in a single command:

### [macOS / Linux](#tab/bash)

```bash
./.dotnet/dotnet workload install maui wasm-tools
```

### [Windows (PowerShell)](#tab/powershell)

```powershell
.\.dotnet\dotnet.exe workload install maui wasm-tools
```

---

### Verify installed workloads

To see which workloads are installed on the local SDK:

### [macOS / Linux](#tab/bash)

```bash
./.dotnet/dotnet workload list
```

### [Windows (PowerShell)](#tab/powershell)

```powershell
.\.dotnet\dotnet.exe workload list
```

---

> [!TIP]
> Workloads installed on the local SDK are stored inside the `.dotnet/` directory. Deleting the directory removes the SDK and all its workloads. Shared download caches (such as `~/.nuget/packages`) might remain but don't affect your system.

## Step 7: Use the prerelease SDK in CI (optional)

The same approach works in continuous integration pipelines. However, CI runners might not have a .NET 10+ host preinstalled, so you need to ensure the host is available before relying on `sdk.paths`.

### GitHub Actions example

The following workflow installs a .NET 10 host using `actions/setup-dotnet`, then installs the .NET 11 preview SDK locally. The `setup-dotnet` step ensures the runner has a .NET 10+ host on `PATH` that can read the `paths` property in `global.json`.

```yaml
name: Build with preview SDK

on: [push, pull_request]

jobs:
  build:
    runs-on: ${{ matrix.os }}
    strategy:
      matrix:
        os: [ubuntu-latest, windows-latest, macos-latest]

    steps:
      - uses: actions/checkout@v4

      - name: Install .NET 10 host
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '10.0.x'
          dotnet-quality: 'preview'

      - name: Cache local SDK
        uses: actions/cache@v4
        with:
          path: .dotnet
          key: dotnet-local-${{ matrix.os }}-${{ hashFiles('global.json') }}

      - name: Install .NET 11 preview SDK locally
        # Use bash shell explicitly — Windows runners default to PowerShell,
        # which doesn't support the curl/chmod/shell-script syntax below.
        shell: bash
        run: |
          curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
          chmod +x dotnet-install.sh
          ./dotnet-install.sh --channel 11.0 --quality preview --install-dir .dotnet

      - name: Build
        run: dotnet build

      - name: Test
        run: dotnet test
```

Because the `global.json` in your repository already has the `paths` configuration, the `dotnet build` and `dotnet test` steps automatically pick up the local SDK. No changes to the CI agent's system-wide installation are needed.

> [!TIP]
> The `actions/cache` step caches the `.dotnet/` directory between runs, keyed on the OS and the hash of `global.json`. The cache refreshes automatically when you update the SDK version in `global.json`.

> [!NOTE]
> The `strategy.matrix` section runs the build across multiple operating systems. You can extend the matrix to test against multiple SDK versions by adding a `sdk-version` dimension and using it in the install step.

### Fallback: use the local host directly

If you can't install .NET 10+ system-wide on the runner (for example, in a locked-down CI environment), invoke the local SDK's own host directly instead of relying on the system `dotnet`:

```yaml
- name: Install .NET 11 preview SDK locally
  run: |
    curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
    chmod +x dotnet-install.sh
    ./dotnet-install.sh --channel 11.0 --quality preview --install-dir .dotnet

- name: Build using local host
  run: ./.dotnet/dotnet build

- name: Test using local host
  run: ./.dotnet/dotnet test
```

This approach bypasses the system host entirely and doesn't require `sdk.paths` resolution — the local `dotnet` executable knows where its own SDK is.

## Limitations

The `sdk.paths` feature has a few constraints to be aware of:

- **Requires a .NET 10 or later host on `PATH`.** The `dotnet` executable that reads `global.json` must be version 10.0 or later. If the system host is older, it ignores the `paths` property entirely.
- **Applies to SDK commands only.** The `paths` property affects SDK resolution for commands like `dotnet build`, `dotnet run`, and `dotnet test`. It does not affect app host resolution or framework-dependent execution (for example, `dotnet myapp.dll`).
- **Paths are relative to the global.json location.** If you move your `global.json` file, update the paths accordingly. An absolute path also works but reduces portability across machines.

## Clean up

Removing a local prerelease SDK takes two steps:

1. Delete the local SDK folder:

   ### [macOS / Linux](#tab/bash)

   ```bash
   rm -rf .dotnet/
   ```

   ### [Windows (PowerShell)](#tab/powershell)

   ```powershell
   Remove-Item -Recurse -Force .dotnet
   ```

   ---

2. Remove the `paths` property from `global.json`, or delete the file if you no longer need it. Your project reverts to using the system-wide SDK.

Because everything is project-local — including any workloads you installed — there are no registry entries, environment variables, or system files to clean up. Removing the folder and reverting `global.json` is all it takes. Any workloads installed on the local SDK are deleted along with the `.dotnet/` folder.

## Next steps

- [global.json overview](global-json.md) — Full reference for all `global.json` properties, including `version`, `rollForward`, and `allowPrerelease`.
- [dotnet-install scripts reference](dotnet-install-script.md) — Complete list of parameters for the cross-platform install scripts.
- [.NET SDK overview](../sdk.md) — Learn about SDK versioning, roll-forward policies, and how the host resolves SDKs.
- [How to select the .NET version to use](../versions/selection.md) — Details on how the .NET host resolves SDK and runtime versions.
- [What's new in .NET 11](../whats-new/dotnet-11/overview.md) — Overview of features and improvements in .NET 11.
