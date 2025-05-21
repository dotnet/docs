---
title: "Breaking change: Dynamic X509ChainPolicy verification time"
description: Learn about the .NET 7 breaking change in cryptography where the X509ChainPolicy verification time is the time when Build is invoked.
ms.date: 07/20/2022
ms.topic: concept-article
---
# Dynamic X509ChainPolicy verification time

In previous versions of .NET, the <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy.VerificationTime?displayProperty=nameWithType> value was assigned to <xref:System.DateTime.Now?displayProperty=nameWithType> when the <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy> object was constructed. Using the same `X509ChainPolicy` object for multiple calls to <xref:System.Security.Cryptography.X509Certificates.X509Chain.Build(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType> resulted in all chain builds using that same value as the verification time, no matter how much time had passed since the object was created.

The new default behavior is to use the value of `DateTime.Now` when `X509Chain.Build()` is invoked as the verification time. This change doesn't affect chain builds that explicitly assign `X509ChainPolicy.VerificationTime`.

## Previous behavior

The <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy.VerificationTime?displayProperty=nameWithType> value was assigned to <xref:System.DateTime.Now?displayProperty=nameWithType> when the `X509ChainPolicy` object was constructed. This value was used in all subsequent <xref:System.Security.Cryptography.X509Certificates.X509Chain.Build(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType> calls (unless or until the value was reassigned at a later time).

## New behavior

The <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy.VerificationTime?displayProperty=nameWithType> value is assigned to <xref:System.DateTime.Now?displayProperty=nameWithType> when the `X509ChainPolicy` object is constructed, but the new `X509ChainPolicy.VerificationTimeIgnored` property defaults to `true`. When this property has a value of `true`, the <xref:System.Security.Cryptography.X509Certificates.X509Chain.Build(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType> method uses `DateTime.Now` as the verification time instead of `X509ChainPolicy.VerificationTime` when building the chain.

Assigning a value to the `X509ChainPolicy.VerificationTime` property automatically sets `VerificationTimeIgnored` to `false`.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Callers who cache configured `X509ChainPolicy` objects were often surprised that their validation was slowly moving further back in time. This change makes long-lived `X509ChainPolicy` objects easier to work with and doesn't significantly impact short-lived objects.

## Recommended action

The following callers aren't impacted by the change:

- Callers that don't have long-lived `X509ChainPolicy` objects.
- Callers that explicitly assign the `X509ChainPolicy.VerificationTime` property.

Callers that have a long-lived `X509ChainPolicy` object that wish to use the previous behavior can either assign the new `X509ChainPolicy.VerificationTimeIgnored` property to `false` or assign the `X509ChainPolicy.VerificationTime` property to `DateTime.Now`.

```csharp
var policy = new X509ChainPolicy
{
   // ...
   VerificationTime = DateTime.Now,
};
```

or

```csharp
var policy = new X509ChainPolicy
{
    // ...
    VerificationTimeIgnored = false,
};
```

## Affected APIs

- <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy?displayProperty=fullName>
- <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy.VerificationTime?displayProperty=fullName>
- `System.Security.Cryptography.X509Certificates.X509ChainPolicy.VerificationTimeIgnored`
