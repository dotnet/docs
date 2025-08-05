---
title: "Breaking change - CoseSigner.Key may now be null"
description: "Learn about the breaking change in .NET 10 where CoseSigner.Key may now be null when backed by Post-Quantum Cryptography algorithms."
ms.date: 01/25/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46999
---

# CoseSigner.Key may now be null

In .NET 10, the <xref:System.Security.Cryptography.Cose.CoseSigner.Key?displayProperty=fullName> property may now return `null`. If `CoseSigner` is backed by an RSA or ECDSA key, then `CoseSigner.Key` continues to return the key and it's non-null. However, when `CoseSigner` is backed by a key that doesn't derive from `AsymmetricAlgorithm`, like `MLDsa` (a new Post-Quantum Cryptography (PQC) signing algorithm), `CoseSigner.Key` returns `null`.

## Version introduced

.NET 10 Preview 7

## Previous behavior

`CoseSigner.Key` couldn't be `null`. It had type `AsymmetricAlgorithm`.

```csharp
using RSA rsaKey = RSA.Create();
CoseSigner signer = new CoseSigner(rsaKey, RSASignaturePadding.Pss, HashAlgorithmName.SHA512);
AsymmetricAlgorithm key = signer.Key; // key was never null
```

## New behavior

`CoseSigner.Key` can be `null`. It now has type `AsymmetricAlgorithm?`.

```csharp
using RSA rsaKey = RSA.Create();

CoseSigner signer = new CoseSigner(rsaKey, RSASignaturePadding.Pss, HashAlgorithmName.SHA512);
// signer.Key is rsaKey here

// CoseKey is a new abstraction for all keys used in COSE
CoseKey coseKey = new CoseKey(rsaKey, RSASignaturePadding.Pss, HashAlgorithmName.SHA512);
signer = new CoseSigner(coseKey);
// signer.Key is rsaKey here

using MLDsa mldsa = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

coseKey = new CoseKey(mldsa);
signer = new CoseSigner(coseKey);
// signer.Key is null here
```

## Type of breaking change

This is both a [behavioral change](../../categories.md#behavioral-change) and [source compatibility](../../categories.md#source-compatibility) change.

## Reason for change

With the introduction of new signing algorithms such as ML-DSA, .NET has moved away from using `AsymmetricAlgorithm` as the universal base class for all asymmetric algorithms. Likewise, `CoseSigner` can now be constructed with a key that doesn't derive from `AsymmetricAlgorithm`. In this case `CoseSigner.Key` can't return an `AsymmetricAlgorithm` representing the underlying key and thus returns `null` instead.

This change was introduced in <https://github.com/dotnet/runtime/pull/115158>.

## Recommended action

`CoseSigner.Key` can still be used, but callers should handle `null` values.

```csharp
AsymmetricAlgorithm? key = signer.Key;
if (key != null)
{
    // Use the key for operations that require AsymmetricAlgorithm
}
else
{
    // Handle the case where the signer is backed by a non-AsymmetricAlgorithm key
}
```

## Affected APIs

- <xref:System.Security.Cryptography.Cose.CoseSigner.Key?displayProperty=fullName>
