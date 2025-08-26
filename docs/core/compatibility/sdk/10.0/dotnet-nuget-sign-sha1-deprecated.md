---
title: "Breaking change - SHA-1 fingerprint support deprecated in dotnet nuget sign"
description: "Learn about the breaking change in .NET 10 where SHA-1 fingerprint support is deprecated in dotnet nuget sign command, promoting NU3043 warning to error."
ms.date: 08/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47449
---

# SHA-1 fingerprint support deprecated in `dotnet nuget sign`

Starting in .NET 10, the [NU3043](/nuget/reference/errors-and-warnings/nu3043) warning is promoted to an error when using SHA-1 fingerprints with the [`dotnet nuget sign` command](../../../tools/dotnet-nuget-sign.md). This change enforces the use of only strong, approved hash algorithms (SHA-2 family) for signing operations.

## Version introduced

.NET 10 Preview 1

## Previous behavior

In .NET 9 SDK, the `dotnet nuget sign` command accepted certificate fingerprints using SHA-1 and SHA-2 family algorithms (SHA256, SHA384, SHA512). If a SHA-1 fingerprint was used, a warning (NU3043) was issued, indicating the use of an insecure hashing algorithm, but the operation continued successfully.

## New behavior

Starting in .NET 10, the NU3043 warning is elevated to an error. This change blocks the use of SHA-1 fingerprints with the `--certificate-fingerprint` option in the `dotnet nuget sign` command, improving overall signing security.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to enforce stronger security standards by disallowing the use of SHA-1 for certificate fingerprinting. SHA-1 is considered cryptographically weak and vulnerable to collision attacks.

## Recommended action

Update the usage of `dotnet nuget sign` to use fingerprints from the SHA-2 family only:

- SHA256 (recommended)
- SHA384
- SHA512

## Affected APIs

None.

## See also

- [dotnet nuget sign](../../../tools/dotnet-nuget-sign.md)
- [NuGet warning NU3043](/nuget/reference/errors-and-warnings/nu3043)
