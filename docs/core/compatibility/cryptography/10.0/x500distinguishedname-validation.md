---
title: "Breaking change: X500DistinguishedName validation is stricter"
description: Learn about the .NET 10 breaking change in cryptography where X500DistinguishedName validation is stricter.
ms.date: 01/30/2025
ai-usage: ai-assisted
---
# X500DistinguishedName validation is stricter

Starting in .NET 10, the <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedName.%23ctor*> constructor that accepts a string-encoded distinguished name might reject previously accepted invalid input or encode it differently on non-Windows systems. This aligns with encoding specifications and Windows behavior.

## Previous behavior

Previous versions of .NET on non-Windows systems permitted incorrect distinguished names or encoded them in a way not permitted by X.520 encoding rules. The <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags.ForceUTF8Encoding?displayProperty=nameWithType> flag forced components to use a UTF8String even if it wasn't a valid representation.

## New behavior

Starting in .NET 10, components that violate encoding rules throw a <xref:System.Security.Cryptography.CryptographicException> on non-Windows systems, matching Windows behavior. The <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags.ForceUTF8Encoding?displayProperty=nameWithType> flag only UTF-8 encodes components when permissible.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Different X.500 components have specific encoding rules. For example, `id-at-telephoneNumber` must be encoded as an ASN.1 <xref:System.Formats.Asn1.UniversalTagNumber.PrintableString>. The exclamation point character is invalid for a PrintableString. Consider the following code:

```csharp
new X500DistinguishedName("Phone=!!");
```

This code threw an exception on Windows but was encoded as a UTF8String on non-Windows. Similarly, using <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags.ForceUTF8Encoding?displayProperty=nameWithType> forced UTF8String encoding even when not permitted:

```csharp
new X500DistinguishedName("Phone=000-555-1234", X500DistinguishedNameFlags.ForceUTF8Encoding);
```

This change ensures encoding aligns with specifications and Windows behavior.

## Recommended action

Generally, no action is needed unless compatibility with incorrect encoding is required. Use <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameBuilder?displayProperty=nameWithType> to create instances with desired encoding:

```csharp
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

X500DistinguishedNameBuilder builder = new();
builder.Add("2.5.4.20", "000-555-1234", UniversalTagNumber.UTF8String);
X500DistinguishedName dn = builder.Build();
```

## Affected APIs

- <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedName.%23ctor(System.String)>
- <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedName.%23ctor(System.String,System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags)>
