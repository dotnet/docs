---
title: "Breaking change: X500DistinguishedName validation is stricter"
description: Learn about the .NET 10 breaking change in core .NET libraries where X500DistinguishedName validation is stricter.
ms.date: 01/30/2025
---
# X500DistinguishedName validation is stricter

Starting in .NET 10, the <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedName.%23ctor*> constructor that accepts a string-encoded distinguished name may reject previously accepted invalid input or encode it differently on non-Windows systems. This aligns with encoding specifications and Windows behavior.

## Previous behavior

Previous versions of .NET on non-Windows systems would permit incorrect distinguished names or encode them in a way not permitted by X.520 encoding rules. The <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags.ForceUTF8Encoding?displayProperty=nameWithType> flag would force components to use a UTF8String even if it was not a valid representation.

## New behavior

Starting in .NET 10, components violating encoding rules will throw a `CryptographicException` on non-Windows systems, matching Windows behavior. The <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags.ForceUTF8Encoding?displayProperty=nameWithType> flag will only UTF-8 encode components when permissible.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Different X.500 components have specific encoding rules. For example, `id-at-telephoneNumber` must be encoded as an ASN.1 <xref:System.Formats.Asn1.UniversalTagNumber.PrintableString>. The exclamation point character is invalid for a PrintableString, so:

```C#
new X500DistinguishedName("Phone=!!");
```

This would throw an exception on Windows but was encoded as a UTF8String on non-Windows. Similarly, using <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags.ForceUTF8Encoding?displayProperty=nameWithType> would force UTF8String encoding even when not permitted:

```C#
new X500DistinguishedName("Phone=000-555-1234", X500DistinguishedNameFlags.ForceUTF8Encoding);
```

This change ensures encoding aligns with specifications and Windows behavior.

## Recommended action

Generally, no action is needed unless compatibility with incorrect encoding is required. Use <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameBuilder?displayProperty=nameWithType> to create instances with desired encoding:

```C#
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

X500DistinguishedNameBuilder builder = new();
builder.Add("2.5.4.20", "000-555-1234", UniversalTagNumber.UTF8String);
X500DistinguishedName dn = builder.Build();
```

## Affected APIs

- <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedName.%23ctor(System.String)>
- <xref:System.Security.Cryptography.X509Certificates.X500DistinguishedName.%23ctor(System.String,System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags)>
