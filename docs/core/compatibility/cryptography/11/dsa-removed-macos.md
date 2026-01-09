---
title: "Breaking change - DSA removed from macOS"
description: "Learn about the breaking change in .NET 11 where the Digital Signature Algorithm (DSA) is no longer supported on macOS."
ms.date: 01/07/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/48201
---

# DSA removed from macOS

Starting in .NET 11, the Digital Signature Algorithm (DSA) is no longer supported on macOS. This removal only impacts "finite field" DSA. Elliptic Curve DSA (EC-DSA) isn't affected. Attempts to use <xref:System.Security.Cryptography.DSA>, <xref:System.Security.Cryptography.DSACryptoServiceProvider>, or other APIs that interact with DSA throw a <xref:System.PlatformNotSupportedException> on macOS.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, the DSA algorithm and its supporting types, <xref:System.Security.Cryptography.DSA>, <xref:System.Security.Cryptography.DSACryptoServiceProvider>, and X.509 certificates with DSA keys functioned on macOS.

## New behavior

DSA is no longer functional on macOS. Attempts to use <xref:System.Security.Cryptography.DSA>, <xref:System.Security.Cryptography.DSACryptoServiceProvider>, or other APIs that interact with DSA throw a <xref:System.PlatformNotSupportedException>.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

.NET on macOS relies on the operating system to provide an implementation of DSA. Apple did this through a now obsolete library called SecurityTransforms, with no replacement. The implementation that Apple did offer was also limited in functionality. It only supported DSA-1024 with SHA-1, which is considered weak. Further, it never supported generating DSA keys.

iOS, tvOS, and MacCatalyst never supported DSA.

## Recommended action

Migrate away from the DSA algorithm and use a modern cryptographic digital signature algorithm such as EC-DSA (Elliptic Curve DSA).

## Affected APIs

* <xref:System.Security.Cryptography.DSA.Create*?displayProperty=nameWithType>
* [DSACryptoServiceProvider constructors](xref:System.Security.Cryptography.DSACryptoServiceProvider.%23ctor*)
* <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPrivateKey(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType>
* <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPublicKey(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType>
* <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.CopyWithPrivateKey(System.Security.Cryptography.X509Certificates.X509Certificate2,System.Security.Cryptography.DSA)?displayProperty=nameWithType>

Additionally, any APIs that interact with DSA keys are affected.
