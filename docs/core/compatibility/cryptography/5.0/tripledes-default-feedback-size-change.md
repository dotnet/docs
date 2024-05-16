---
title: "Breaking change: Default FeedbackSize value for instances created by TripleDES.Create changed"
description: Learn about the breaking change in .NET 5 where the default value for the FeedbackSize property on the TripleDES instance returned from TripleDES.Create() has changed from 64 to 8.
ms.date: 10/16/2020
---
# Default FeedbackSize value for instances created by TripleDES.Create changed

The default value for the <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize?displayProperty=nameWithType> property on the <xref:System.Security.Cryptography.TripleDES> instance returned from <xref:System.Security.Cryptography.TripleDES.Create?displayProperty=nameWithType> has changed from 64 to 8 to make migration from .NET Framework easier. This property, unless used directly in caller code, is used only when the <xref:System.Security.Cryptography.SymmetricAlgorithm.Mode> property is <xref:System.Security.Cryptography.CipherMode.CFB?displayProperty=nameWithType>.

Support for the <xref:System.Security.Cryptography.CipherMode.CFB> mode was first added to .NET for the 5.0 RC1 release, so only .NET 5 RC1 and .NET 5 RC2 applications should be impacted by this change.

## Change description

In .NET Core and previous pre-release versions of .NET 5, `TripleDES.Create().FeedbackSize` has a default value of 64. Starting in the RTM version of .NET 5, `TripleDES.Create().FeedbackSize` has a default value of 8.

## Reason for change

In .NET Framework, the <xref:System.Security.Cryptography.TripleDES> base class defaults the value of <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize> to 64, but the <xref:System.Security.Cryptography.TripleDESCryptoServiceProvider> class overwrites the default to 8. When the <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize> property was introduced to .NET Core in version 2.0, this same behavior was preserved. However, in .NET Framework, <xref:System.Security.Cryptography.TripleDES.Create?displayProperty=nameWithType> returns an instance of <xref:System.Security.Cryptography.TripleDESCryptoServiceProvider>, so the default value from the algorithm factory is 8. For .NET Core and .NET 5+, the algorithm factory returns a non-public implementation, which, until now, had a default value of 64.

Changing the <xref:System.Security.Cryptography.TripleDES> implementation class' <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize> value to 8 allows for applications written for .NET Framework that specified the cipher mode as <xref:System.Security.Cryptography.CipherMode.CFB> but didn't explicitly assign the <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize> property, to continue to function on .NET 5.

## Version introduced

5.0

## Recommended action

Applications that encrypt or decrypt data in the RC1 or RC2 versions of .NET 5 do so with CFB64, when the following conditions are met:

- With a <xref:System.Security.Cryptography.TripleDES> instance from <xref:System.Security.Cryptography.TripleDES.Create?displayProperty=nameWithType>.
- Using the default value for <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize>.
- With the <xref:System.Security.Cryptography.SymmetricAlgorithm.Mode> property set to <xref:System.Security.Cryptography.CipherMode.CFB?displayProperty=nameWithType>.

To maintain this behavior, assign the <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize> property to `64`.

Not all `TripleDES` implementations use the same default for <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize>. We recommend that if you use the <xref:System.Security.Cryptography.CipherMode.CFB> cipher mode on <xref:System.Security.Cryptography.TripleDES> instances, you should always explicitly assign the <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize> property value.

```csharp
TripleDES cipher = TripleDES.Create();
cipher.Mode = CipherMode.CFB;
// Explicitly set the FeedbackSize for CFB to control between CFB8 and CFB64.
cipher.FeedbackSize = 8;
```

## Affected APIs

- <xref:System.Security.Cryptography.TripleDES.Create?displayProperty=fullName>
- <xref:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize?displayProperty=fullName>

<!--

### Affected APIs

- `M:System.Security.Cryptography.TripleDES.Create`
- `P:System.Security.Cryptography.SymmetricAlgorithm.FeedbackSize`

### Category

- Cryptography

-->
