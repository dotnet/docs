---
title: "Breaking change: CreateEncryptor methods throw exception for incorrect feedback size"
description: Learn about the breaking change in .NET 6 where the `CreateEncryptor` and `CreateDecryptor` methods for `AesCng` and `TripleDESCng` throw an exception for an incorrect feedback size when used with a persisted key for CFB mode.
ms.date: 10/01/2021
---
# CreateEncryptor methods throw exception for incorrect feedback size

The `CreateEncryptor` and `CreateDecryptor` methods for <xref:System.Security.Cryptography.AesCng> and <xref:System.Security.Cryptography.TripleDESCng> now throw a <xref:System.Security.Cryptography.CryptographicException> when the object instance is being used with a CNG persisted (or named) key for Cipher Feedback (CFB) mode, with a feedback size other than eight (CFB8).

## Previous behavior

Previously, these classes allowed CFB128 (`AesCng`) or CFB64 (`TripleDESCng`) to be selected. However, if the key was a persisted key, then the computation was always done as if CFB8 was selected.

## New behavior

The `CreateEncryptor` and `CreateDecryptor` methods throw a <xref:System.Security.Cryptography.CryptographicException> when both of the following conditions are met:

- CFB128 or CFB64 mode is selected (that is, <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize?displayProperty=nameWithType> is set to 128 or 64).
- The instance is backed by a persisted key.

## Version introduced

.NET 6

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was introduced to indicate that the requested work cannot be performed correctly.

## Recommended action

If you encounter this exception, consider switching from CFB128 or CFB64 to CFB8. Making that switch will produce results compatible with the behavior in previous releases.

## Affected APIs

- <xref:System.Security.Cryptography.AesCng.CreateEncryptor?displayProperty=fullName>
- <xref:System.Security.Cryptography.AesCng.CreateDecryptor?displayProperty=fullName>
- <xref:System.Security.Cryptography.TripleDESCng.CreateEncryptor?displayProperty=fullName>
- <xref:System.Security.Cryptography.TripleDESCng.CreateDecryptor?displayProperty=fullName>
