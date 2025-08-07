---
title: "Breaking change - CoseSigner.Key may now be null"
description: "Learn about the breaking change in .NET 10 where CoseSigner.Key may now be null when backed by Post-Quantum Cryptography algorithms."
ms.date: 01/25/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46999
---

# CoseSigner.Key can now be null

In .NET 10, the <xref:System.Security.Cryptography.Cose.CoseSigner.Key?displayProperty=nameWithType> property can now return `null`. If `CoseSigner` is backed by an RSA or ECDSA key, then `CoseSigner.Key` returns a non-null key. However, when `CoseSigner` is backed by a key that doesn't derive from <xref:System.Security.Cryptography.AsymmetricAlgorithm>, like `MLDsa` (a new Post-Quantum Cryptography (PQC) signing algorithm), `CoseSigner.Key` returns `null`.

## Version introduced

.NET 10 Preview 7

## Previous behavior

`CoseSigner.Key` couldn't be `null`. It had type `AsymmetricAlgorithm`.

## New behavior

`CoseSigner.Key` can be `null`. Its type is `AsymmetricAlgorithm?`.

```csharp
using RSA rsaKey = RSA.Create();

CoseSigner signer = new CoseSigner(rsaKey, RSASignaturePadding.Pss, HashAlgorithmName.SHA512);
// signer.Key is rsaKey here.

// CoseKey is a new abstraction for all keys used in COSE.
CoseKey coseKey = new CoseKey(rsaKey, RSASignaturePadding.Pss, HashAlgorithmName.SHA512);
signer = new CoseSigner(coseKey);
// signer.Key is rsaKey here.

using MLDsa mldsa = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

coseKey = new CoseKey(mldsa);
signer = new CoseSigner(coseKey);
// signer.Key is null here.
```

## Type of breaking change

This is both a [behavioral change](../../categories.md#behavioral-change) but it can also affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

With the introduction of new signing algorithms such as ML-DSA, .NET has moved away from using `AsymmetricAlgorithm` as the universal base class for all asymmetric algorithms. Likewise, `CoseSigner` can now be constructed with a key that doesn't derive from `AsymmetricAlgorithm`. In this case `CoseSigner.Key` can't return an `AsymmetricAlgorithm` representing the underlying key and thus returns `null` instead.

## Recommended action

It's still okay to use `CoseSigner.Key` but be sure to handle `null` values.

## Affected APIs

- <xref:System.Security.Cryptography.Cose.CoseSigner.Key?displayProperty=fullName>
