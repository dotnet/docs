---
title: "Breaking change: Windows private key lifetime simplified"
description: Learn about the .NET 9 breaking change in cryptography where the lifetime of a Windows private key has been simplified.
ms.date: 10/04/2024
ms.topic: concept-article
---
# Windows private key lifetime simplified

When a workload loads a PKCS#12/PFX on Windows without setting either the <xref:System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.PersistKeySet> or <xref:System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.EphemeralKeySet> storage options, .NET determines when the private key is no longer needed and should be erased. In previous versions of .NET (and in .NET Framework), two different sets of logic were used. In .NET 9, there's a single set of logic.

## Previous behavior

Previously, when loading a certificate (and its private key) from a PKCS#12/PFX with `new X509Certificate2(pfx, password, flags)`, the loaded certificate represented the lifetime of the private key. When this certificate object was disposed (or finalized if it was garbage-collected without being disposed), the associated private key was deleted. No shared ownership or transfer of ownership occurred.

When loading a certificate (and its private key) from a PKCS#12/PFX with `X509Certificate2Collection.Import(pfx, password, flags)`, each loaded certificate that had a private key tracked the lifetime, as with the single certificate load. But, in addition, a marker was placed on the native copy of the certificate to indicate that any copies should also track the private key lifetime. If a second <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> object was created in terms of the same underlying `PCERT_CONTEXT` value, then whichever copy was disposed (or finalized) first erased the private key out from under the other copy.

The following code failed (either with a <xref:System.Security.Cryptography.CryptographicException> or a <xref:System.NullReferenceException>) because the private key was deleted:

```csharp
X509Certificate2Collection coll = new X509Certificate2Collection(pfx, password, X509KeyStorageFlags.DefaultKeySet);
X509Certificate2Collection coll2 = coll.Find(X509FindType.FindBySubjectName, "", false);

coll2 = null;
GC.Collect();
GC.WaitForPendingFinalizers();

using (RSA key = coll[0].GetRSAPrivateKey())
{
    key.SignData(pfx, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
}
```

## New behavior

Starting in .NET 9, the lifetime is always associated with the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> instance that was directly produced from the PKCS#12/PFX load.

The same code snippet in the [Previous behavior](#previous-behavior) section now succeeds.

## Version introduced

.NET 9 Preview 7

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Most workloads that load a PKCS#12/PFX use the single certificate load and understand the lifetime mechanics associated with that method. The mechanics associated with the collection load were often surprising, and sometimes lead to premature key erasure.

## Recommended action

If you understood the collection-load lifetime management and depended on calling `Dispose` on a clone to cause key erasure, ensure that you're also (or instead) calling `Dispose` on the original loaded object.

## Affected APIs

- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import*?displayProperty=fullName>
