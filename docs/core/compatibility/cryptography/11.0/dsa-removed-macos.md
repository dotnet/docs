---
title: "Breaking change - DSA has been removed from macOS"
description: "Learn about the breaking change in .NET 11 where the Digital Signature Algorithm (DSA) is no longer supported on macOS."
ms.date: 01/07/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/543460
---

# DSA has been removed from macOS

Starting in .NET 11, the Digital Signature Algorithm (DSA) is no longer supported on macOS. This only impacts "finite field" DSA. Elliptic Curve DSA (EC-DSA) isn't affected. Attempts to use <xref:System.Security.Cryptography.DSA>, <xref:System.Security.Cryptography.DSACryptoServiceProvider>, or other APIs that interact with DSA throw a <xref:System.PlatformNotSupportedException> on macOS.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, the DSA algorithm and its supporting types, <xref:System.Security.Cryptography.DSA>, <xref:System.Security.Cryptography.DSACryptoServiceProvider>, and X.509 certificates with DSA keys functioned on macOS.

## New behavior

DSA is no longer functional on macOS. Attempts to use <xref:System.Security.Cryptography.DSA>, <xref:System.Security.Cryptography.DSACryptoServiceProvider>, or other APIs that interact with DSA throw a <xref:System.PlatformNotSupportedException>.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

.NET on macOS relies on the operating system to provide an implementation of DSA. Apple did this through a now obsolete library called SecurityTransforms, with no replacement. The implementation that Apple did offer was also limited in functionality. It only supported DSA-1024 with SHA-1, which is considered weak. Further, it never supported generating DSA keys.

iOS, tvOS, and MacCatalyst never supported DSA.

## Recommended action

Migrate away from the DSA algorithm and use a modern cryptographic digital signature algorithm such as EC-DSA (Elliptic Curve DSA).

If you're using DSA, you can use <xref:System.Security.Cryptography.ECDsa> instead:

* `DSA.Create(...)` -> `ECDsa.Create(...)`
* `new DSACryptoServiceProvider(...)` -> `ECDsa.Create(...)`

## Affected APIs

* <xref:System.Security.Cryptography.DSA.Create?displayProperty=fullName> (all overloads)
* <xref:System.Security.Cryptography.DSACryptoServiceProvider.%23ctor?displayProperty=fullName> (all overloads)
* <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPrivateKey%2A?displayProperty=fullName> (all overloads)
* <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPublicKey%2A?displayProperty=fullName> (all overloads)
* <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.CopyWithPrivateKey%2A?displayProperty=fullName> (all overloads)

Additionally, any APIs that interact with DSA keys are affected.
