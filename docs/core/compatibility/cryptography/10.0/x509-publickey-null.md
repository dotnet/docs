---
title: "Breaking change - X509Certificate and PublicKey key parameters can be null"
description: "Learn about the breaking change in .NET 10 Preview 3 where key parameters in X509Certificate and PublicKey can be null."
ms.date: 3/13/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45325
---

# X509Certificate and PublicKey key parameters can be null

In .NET 10, the behavior of <xref:System.Security.Cryptography.X509Certificates.X509Certificate> and <xref:System.Security.Cryptography.X509Certificates.PublicKey> has changed. When these objects contain a key without algorithm parameters, they now return `null` instead of an empty array.

## Version introduced

.NET 10 Preview 3

## Previous behavior

<xref:System.Security.Cryptography.X509Certificates.X509Certificate> or <xref:System.Security.Cryptography.X509Certificates.PublicKey> objects that contained a key without algorithm parameters would return an empty array when accessing the key algorithm parameters.

```csharp
byte[] parameters = certificate.GetKeyAlgorithmParameters();
// parameters would be an empty array if no algorithm parameters were present
```

## New behavior

<xref:System.Security.Cryptography.X509Certificates.X509Certificate> or <xref:System.Security.Cryptography.X509Certificates.PublicKey> objects that contain a key without algorithm parameters will return `null` when accessing the key algorithm parameters.

```csharp
byte[] parameters = certificate.GetKeyAlgorithmParameters();
// parameters will be null if no algorithm parameters are present
```

## Type of breaking change

This is both a [behavioral](../../categories.md#behavioral-change) and [source compatibility](../../categories.md#source-compatibility) change.

## Reason for change

The <xref:System.Security.Cryptography.X509Certificates.X509Certificate>, <xref:System.Security.Cryptography.X509Certificates.X509Certificate2>, and <xref:System.Security.Cryptography.X509Certificates.PublicKey> classes expose information about the *Subject Public Key Info*. One of the properties of the *Subject Public Key Info* is the parameters for the algorithm. A *Subject Public Key Info* is not required to contain algorithm parameters. Previously, this was represented as an empty byte array, which is not valid ASN.1. Attempting to encode or decode it would result in an exception. To more clearly represent absent key parameters, `null` is now returned, and the members that return algorithm parameters have been annotated to return nullable values.

## Recommended action

When accessing a member that returns information about a subject public key info's algorithm parameters, expect the member to possibly return `null` and handle the `null` value accordingly.

```csharp
byte[] parameters = certificate.GetKeyAlgorithmParameters();
if (parameters == null)
{
    // Handle the absence of algorithm parameters
}
```

## Affected APIs

- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.GetKeyAlgorithmParameters?displayProperty=fullName>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.GetKeyAlgorithmParametersString?displayProperty=fullName>
- <xref:System.Security.Cryptography.X509Certificates.PublicKey.%23ctor(System.Security.Cryptography.Oid,System.Security.Cryptography.AsnEncodedData,System.Security.Cryptography.AsnEncodedData)?displayProperty=fullName>
- <xref:System.Security.Cryptography.X509Certificates.PublicKey.EncodedParameters?displayProperty=fullName>
