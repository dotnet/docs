---
title: How dotnetup verifies downloads
description: Learn how dotnetup verifies .NET release manifests and archives, how daily builds differ, and how administrators can block unsigned downloads.
ms.topic: concept-article
ms.date: 09/30/2026
ai-usage: ai-generated
---

# How dotnetup verifies downloads

[!INCLUDE [public-preview](../includes/public-preview.md)]

`dotnetup` verifies the .NET SDKs and runtimes that it downloads before it
extracts them. The type of verification depends on where the build comes
from.

## Released builds

For released builds, `dotnetup` uses a chain of trust that starts with a signed
release manifest:

1. `dotnetup` downloads the .NET release manifests. These manifests are the
   releases index and the `releases.json` file for each channel.
1. `dotnetup` verifies the detached code signature (`.p7s` file) of each
   manifest. If the signature is missing or isn't valid, the command fails.
1. The verified manifest contains the SHA-512 hash of each archive.
1. `dotnetup` downloads the archive and compares its SHA-512 hash to the hash in
   the manifest. If the hashes don't match, the command fails, and `dotnetup`
   doesn't extract the archive.

Because the signed manifest pins each archive's hash, `dotnetup` doesn't verify
a separate signature for each archive.

Signature verification also checks certificate revocation status online. Allow
access to the required certificate revocation endpoints. If the network blocks
these checks, verification fails and `dotnetup` stops the installation, even
when the signature is valid.

### Manifest expiration

Release manifests contain an expiration time. `dotnetup` checks that the
manifest hasn't expired, even if its signature and archive hashes are valid.
It also checks that the manifest was signed before its expiration time.

An incorrect system clock or an expired manifest can cause verification to
fail. For recovery guidance, see
[A release manifest has expired](../troubleshooting.md#a-release-manifest-has-expired).

### Trusted certificates

For manifest signatures and their timestamps, `dotnetup` uses trusted root
certificates bundled with the tool. It doesn't add certificates from the
operating system's trust store to those trust roots.

Adding a certificate to the operating system's trust store doesn't make
`dotnetup` trust a release-manifest signature from that certificate's chain.
The signature must satisfy dotnetup's verification policy and chain to a
bundled trusted root.

## Daily and unlisted prerelease builds

Daily builds, and prerelease versions that aren't in the signed release
manifest, come from a different feed. These builds have a SHA-512 hash file but
no code signature. For these builds, `dotnetup` verifies only the SHA-512 hash.

`dotnetup` uses this path when you install:

- A daily channel, such as `daily` or `10.0-daily`.
- A fully specified prerelease version, such as `10.0.100-preview.4.25216.37`,
  that isn't in the release manifest.

Before the installation starts, `dotnetup` shows this warning:

```output
⚠ Daily builds are not code-signed. Only the SHA-512 hash is verified.
```

For more information about daily builds, see
[Use preview and daily builds](../usecases/try-daily-builds.md).

## Block unsigned downloads

Administrators can block the installation of builds that aren't code-signed.
When this policy is in effect, `dotnetup` still installs released builds, but
installations of daily and unlisted prerelease builds fail.

### Windows

Create the `BlockUnsignedDownloads` registry value as a `REG_DWORD` with a
non-zero value under `HKLM\SOFTWARE\Policies\Microsoft\dotnet\Dotnetup`. For
example, run these commands in an elevated PowerShell session:

```powershell
$key = 'HKLM:\SOFTWARE\Policies\Microsoft\dotnet\Dotnetup'
New-Item -Path $key -Force | Out-Null
New-ItemProperty -Path $key -Name 'BlockUnsignedDownloads' -PropertyType DWord -Value 1 -Force | Out-Null
```

To clear the policy, delete the value or set it to `0`.

### Linux and macOS

Create the `/etc/dotnet/dnup-block-unsigned-downloads` file. The file's content
doesn't matter. For example:

```bash
sudo mkdir -p /etc/dotnet
sudo touch /etc/dotnet/dnup-block-unsigned-downloads
```

To clear the policy, delete the file.

### Blocked installations

When the policy blocks an installation, `dotnetup` shows an error similar to
the following message:

```output
An IT policy on this machine requires code-signed downloads. Installing daily or unsigned prerelease builds of SDK <version> is blocked. Choose a released version, or have an administrator clear the policy ...
```

To continue, install a released version, or ask your administrator to clear
the policy.

## The dotnetup executable

The `get-dotnetup` download scripts verify the downloaded `dotnetup`
executable with its SHA-512 checksum file. For more information, see
[Get started with dotnetup](../getting-started.md).

## See also

- [How dotnetup works](how-dotnetup-works.md)
- [Channels and versions](channels.md)
- [Daily channels](../channels/daily.md)
