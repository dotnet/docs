---
title: "Breaking change: Template package installation verifies NuGet signatures"
description: "Learn about the behavioral change in .NET 8, .NET 9, .NET 10, and .NET 11 where template package installation verifies NuGet package signatures."
ms.date: 10/30/2026
ai-usage: ai-assisted
---

# Template package installation verifies NuGet signatures

Template package installation now verifies signed packages downloaded from NuGet sources when signature verification is enabled. Packages that fail verification aren't installed.

## Version introduced

- .NET 8 SDK 8.0.134 and 8.0.428
- .NET 9 SDK 9.0.124 and 9.0.321
- .NET 10 SDK 10.0.115 and 10.0.404
- .NET 11 SDK 11.0.100

## Previous behavior

Previously, `dotnet new install` didn't verify NuGet package signatures when downloading template packages. Packages could be installed even if their signatures were invalid or they were unsigned despite a client or repository policy requiring signatures.

## New behavior

When signature verification is enabled, signed template packages downloaded from NuGet sources are verified using `dotnet nuget verify --all` before installation. If verification fails, installation fails. The `--force` option doesn't bypass verification.

Unsigned packages are accepted only if the applicable NuGet configuration's `signatureValidationMode` is `accept` (the default) and the source doesn't declare `allRepositorySigned=true`. A client policy of `require` or a repository signing requirement causes unsigned packages to be rejected.

Verification is always enabled on Windows. On Linux, it's enabled by default and can be disabled by setting `DOTNET_NUGET_SIGNATURE_VERIFICATION=false`. On macOS, it's disabled by default and can be enabled by setting `DOTNET_NUGET_SIGNATURE_VERIFICATION=true`. See [NuGet signed-package verification](../../../tools/nuget-signed-package-verification.md) for certificate-store requirements and platform limitations.

This verification applies to packages downloaded from configured or additional NuGet sources. It doesn't apply when you install a template package directly from a local `.nupkg` file or folder.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Signature verification helps validate the authenticity and integrity of downloaded template packages and rejects unsigned packages when client or repository policy requires signing. A valid signature doesn't guarantee that template code is safe to run.

## Recommended action

If your template packages pass verification, no action is required.

If installation fails, run `dotnet new install` with `--diagnostics` to see verification details. You can also use [`dotnet nuget verify`](../../../tools/dotnet-nuget-verify.md) to verify a downloaded package explicitly.

For signature or integrity failures, obtain a valid package from a trusted source or contact the package publisher. For certificate-trust failures, review the certificate-store requirements in [NuGet signed-package verification](../../../tools/nuget-signed-package-verification.md).

If an unsigned package is rejected, check the applicable [signatureValidationMode](/nuget/reference/nuget-config-file#signaturevalidationmode) and the source's repository-signing requirements. Use a signed package that meets those requirements rather than bypassing verification.

For command behavior and configuration, see [`dotnet new install`](../../../tools/dotnet-new-install.md#package-signature-verification).

## Affected APIs

None.
