---
title: "Breaking change: HKDF on Windows uses CNG implementation"
description: "Learn about the breaking change in .NET 11 where HKDF on Windows uses the Windows Cryptography API: Next Generation (CNG) implementation, which restricts some input sizes."
ms.date: 09/10/2026
ai-usage: ai-assisted
---

# HKDF on Windows uses CNG implementation

Starting in .NET 11, <xref:System.Security.Cryptography.HKDF> on Windows uses Windows' built-in Cryptography API: Next Generation (CNG) implementation. The Windows implementation restricts some input sizes more than the previous .NET implementation, so some inputs that worked in earlier .NET versions now throw <xref:System.Security.Cryptography.CryptographicException>.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, on Windows, <xref:System.Security.Cryptography.HKDF.DeriveKey*> and <xref:System.Security.Cryptography.HKDF.Expand*> accepted inputs of arbitrary size as long as the inputs were permitted by the HKDF specification.

## New behavior

Starting in .NET 11, on Windows, <xref:System.Security.Cryptography.HKDF.DeriveKey*> and <xref:System.Security.Cryptography.HKDF.Expand*> limit the maximum input length for input keying material and pseudorandom keys. If the input keying material passed to `DeriveKey` or the pseudorandom key passed to `Expand` exceeds the limit, the method throws <xref:System.Security.Cryptography.CryptographicException>.

Both limits are currently 2,048 bytes.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

On Windows, .NET 11 changed from a managed HKDF implementation to the implementation provided by Windows CNG. The .NET cryptography libraries prefer platform implementations for cryptographic algorithms.

## Recommended action

Typical uses of HKDF shouldn't reach these limits. If your application passes input keying material or pseudorandom keys larger than 2,048 bytes on Windows, consider smaller inputs.

## Affected APIs

- <xref:System.Security.Cryptography.HKDF.DeriveKey*?displayProperty=fullName>
- <xref:System.Security.Cryptography.HKDF.Expand*?displayProperty=fullName>
