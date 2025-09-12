---
title: "Breaking change - MLDsa and SlhDsa 'SecretKey' members renamed"
description: "Learn about the breaking change in .NET 10 where MLDsa and SlhDsa members were renamed from using 'SecretKey' to using 'PrivateKey'."
ms.date: 09/05/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47691
---

# MLDsa and SlhDsa 'SecretKey' members renamed

Some methods and properties in the `[Experimental]` post-quantum cryptography (PQC) classes <xref:System.Security.Cryptography.MLDsa?displayProperty=fullName> and <xref:System.Security.Cryptography.SlhDsa?displayProperty=fullName> have been renamed. APIs that involve the `sk` value from their respective specifications now have `PrivateKey` in their names instead of `SecretKey`.

## Version introduced

.NET 10 RC 1

## Previous behavior

Previously, you could call methods like `ImportMLDsaSecretKey` and `ImportSlhDsaSecretKey`, and you could access properties like `SecretKeySizeInBytes`.

## New behavior

Starting in .NET 10 RC 1, you must call methods like `ImportMLDsaPrivateKey` or `ImportSlhDsaPrivateKey`, and access properties like `PrivateKeySizeInBytes`.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The change was made to align with existing asymmetric cryptography types in .NET and with related members such as <xref:System.Security.Cryptography.MLDsa.ExportPkcs8PrivateKey>.

## Recommended action

Resolve any compile breaks from this change by replacing instances of `SecretKey` with `PrivateKey` in the called member names:

```diff
-int targetSize = key.Algorithm.SecretKeySizeInBytes;
+int targetSize = key.Algorithm.PrivateKeySizeInBytes;
byte[] output = new byte[targetSize];
-key.ExportMLDsaSecretKey(output);
+key.ExportMLDsaPrivateKey(output);
```

## Affected APIs

- `System.Security.Cryptography.MLDsa.ImportMLDsaSecretKey()`
- `System.Security.Cryptography.MLDsa.ExportMLDsaSecretKey()`
- `System.Security.Cryptography.MLDsaAlgorithm.SecretKeySizeInBytes`
- `System.Security.Cryptography.SlhDsa.ImportSlhDsaSecretKey()`
- `System.Security.Cryptography.SlhDsa.ExportSlhDsaSecretKey()`
- `System.Security.Cryptography.SlhDsaAlgorithm.SecretKeySizeInBytes`
