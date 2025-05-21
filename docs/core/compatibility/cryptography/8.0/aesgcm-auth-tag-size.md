---
title: "Breaking change: AesGcm authentication tag size on macOS"
description: Learn about the .NET 8 breaking change in cryptography where AesGcm on macOS only supports 16-byte (128-bit) authentication tags.
ms.date: 01/24/2023
ms.topic: concept-article
---
# AesGcm authentication tag size on macOS

<xref:System.Security.Cryptography.AesGcm> on macOS only supports 16-byte (128-bit) authentication tags when using <xref:System.Security.Cryptography.AesGcm.Encrypt%2A> or <xref:System.Security.Cryptography.AesGcm.Decrypt%2A> in .NET 8 and later versions.

## Previous behavior

On macOS, <xref:System.Security.Cryptography.AesGcm.Encrypt%2A?nameWithType> and <xref:System.Security.Cryptography.AesGcm.Decrypt%2A?nameWithType> supported authentication tag sizes ranging from 12 to 16 bytes, provided OpenSSL was available.

In addition, the <xref:System.Security.Cryptography.AesGcm.TagByteSizes?displayProperty=nameWithType> property reported that it supported sizes ranging from 12 to 16 bytes, inclusive.

## New behavior

On macOS, <xref:System.Security.Cryptography.AesGcm.Encrypt%2A?nameWithType> and <xref:System.Security.Cryptography.AesGcm.Decrypt%2A?nameWithType> support 16-byte authentication tags only. If you use a smaller tag size on macOS, an <xref:System.ArgumentException> is thrown at run time.

The <xref:System.Security.Cryptography.AesGcm.TagByteSizes?displayProperty=nameWithType> property returns a value of 16 as the supported tag size.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The <xref:System.Security.Cryptography.AesGcm> class on macOS previously relied on OpenSSL for underlying support. OpenSSL is an external dependency that needed to be installed and configured separately from .NET. <xref:System.Security.Cryptography.AesGcm> now uses Apple's CryptoKit to provide an implementation of Advanced Encryption Standard with Galois/Counter Mode (AES-GCM) so that OpenSSL is no longer a dependency for using <xref:System.Security.Cryptography.AesGcm>.

The CryptoKit implementation of AES-GCM does not support authentication tag sizes other than 128-bits (16-bytes).

## Recommended action

Use 128-bit authentication tags with <xref:System.Security.Cryptography.AesGcm> for macOS support.

## Affected APIs

- <xref:System.Security.Cryptography.AesGcm.TagByteSizes?displayProperty=fullName>
- <xref:System.Security.Cryptography.AesGcm.Encrypt%2A?displayProperty=fullName>
- <xref:System.Security.Cryptography.AesGcm.Decrypt%2A?displayProperty=fullName>
