---
title: "Breaking change - MLDsa and SlhDsa members renamed from using 'SecretKey' to using 'PrivateKey'"
description: "Learn about the breaking change in .NET 10 where MLDsa and SlhDsa members were renamed from using 'SecretKey' to using 'PrivateKey'."
ms.date: 12/21/2024
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47691
---

# MLDsa and SlhDsa members renamed from using "SecretKey" to using "PrivateKey"

In .NET 10, for the `[Experimental]` Post-Quantum Cryptography (PQC) classes <xref:System.Security.Cryptography.MLDsa?displayProperty=fullName> and <xref:System.Security.Cryptography.SlhDsa?displayProperty=fullName>, method and property names involving the `sk` value from their respective specifications were renamed from using "SecretKey" to using "PrivateKey".

## Version introduced

.NET 10 RC 1

## Previous behavior

In .NET 10 Preview 7, users could call methods like `ImportMLDsaSecretKey` or `ImportSlhDsaSecretKey`, and access properties like `SecretKeySizeInBytes`.

```csharp
using System.Security.Cryptography;

using MLDsa key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
int targetSize = key.Algorithm.SecretKeySizeInBytes;
byte[] output = new byte[targetSize];
key.ExportMLDsaSecretKey(output);
```

## New behavior

In .NET 10 RC 1, users should call methods like `ImportMLDsaPrivateKey` or `ImportSlhDsaPrivateKey`, and access properties like `PrivateKeySizeInBytes`.

```csharp
using System.Security.Cryptography;

using MLDsa key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
int targetSize = key.Algorithm.PrivateKeySizeInBytes;
byte[] output = new byte[targetSize];
key.ExportMLDsaPrivateKey(output);
```

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The change was made to align with existing asymmetric cryptography types in .NET and with related members such as `ExportPkcs8PrivateKey`.

## Recommended action

Any compile breaks from this change can be resolved by replacing instances of "SecretKey" with "PrivateKey" in the called member names:

```diff
-int targetSize = key.Algorithm.SecretKeySizeInBytes;
+int targetSize = key.Algorithm.PrivateKeySizeInBytes;
byte[] output = new byte[targetSize];
-key.ExportMLDsaSecretKey(output);
+key.ExportMLDsaPrivateKey(output);
```

## Affected APIs

- <xref:System.Security.Cryptography.MLDsa.ImportMLDsaSecretKey(System.ReadOnlySpan{System.Byte})?displayProperty=fullName>
- <xref:System.Security.Cryptography.MLDsa.ExportMLDsaSecretKey(System.Span{System.Byte})?displayProperty=fullName>
- <xref:System.Security.Cryptography.MLDsaAlgorithm.SecretKeySizeInBytes?displayProperty=fullName>
- <xref:System.Security.Cryptography.SlhDsa.ImportSlhDsaSecretKey(System.ReadOnlySpan{System.Byte})?displayProperty=fullName>
- <xref:System.Security.Cryptography.SlhDsa.ExportSlhDsaSecretKey(System.Span{System.Byte})?displayProperty=fullName>
- <xref:System.Security.Cryptography.SlhDsaAlgorithm.SecretKeySizeInBytes?displayProperty=fullName>
