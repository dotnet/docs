---
title: "Breaking change: LDAP DirectoryControl parsing is now more stringent"
description: Learn about the .NET 10 breaking change in core .NET libraries where LDAP DirectoryControl parsing is now more stringent.
ms.date: 01/30/2025
ai-usage: ai-assisted
ms.topic: concept-article
---

# LDAP DirectoryControl parsing is now more stringent

Previously, .NET used <xref:System.DirectoryServices.Protocols.BerConverter?displayProperty=nameWithType> to parse the <xref:System.DirectoryServices.Protocols.DirectoryControl?displayProperty=nameWithType> objects it received over the network and to generate the <xref:System.DirectoryServices.Protocols.DirectoryControl?displayProperty=nameWithType> byte arrays it sent. <xref:System.DirectoryServices.Protocols.BerConverter?displayProperty=nameWithType> used the OS-specific BER parsing functionality. This parsing functionality is now implemented in managed code.

## Previous behavior

As a result of using <xref:System.DirectoryServices.Protocols.BerConverter?displayProperty=nameWithType>, the parsing of <xref:System.DirectoryServices.Protocols.DirectoryControl?displayProperty=nameWithType> objects was fairly loose:

- The ASN.1 tags of each value weren't checked.
- Trailing data after the end of the parsed DirectoryControl was ignored, as was trailing data within an ASN.1 SEQUENCE.
- On Linux, OCTET STRING lengths that extended beyond the end of their parent sequence returned data outside the parent sequence.
- On earlier versions of Windows, a zero-length OCTET STRING returned `null` rather than an empty string.
- When reading the contents of a <xref:System.DirectoryServices.Protocols.DirectoryControl?displayProperty=nameWithType> as a UTF8-encoded string, an invalid UTF8 sequence did not throw an exception.
- When passing an invalid UTF8 string to the constructor of [VlvRequestControl](xref:System.DirectoryServices.Protocols.VlvRequestControl), no exception was thrown.

While not a breaking change, Windows always encoded ASN.1 tags with a four-byte length while Linux only used as many bytes for the tag length as it needed. Both representations were valid, but this behavioral difference between platforms is now gone; the Linux behavior now also appears on Windows.

## New behavior

The DirectoryControl parsing is much more stringent, and is now consistent across platforms and versions:

- ASN.1 tags are now checked.
- Trailing data is no longer permitted.
- The length of `OCTET STRING`s and `SEQUENCE`s is now checked.
- Zero-length `OCTET STRING`s now always return an empty string.
- If the server sends an invalid UTF8 byte sequence, the <xref:System.DirectoryServices.Protocols.DirectoryControl?displayProperty=nameWithType> parsing logic now throws an exception rather than silently substituting the invalid characters with a known value.

We also validate errors more thoroughly when calling the <xref:System.DirectoryServices.Protocols.VlvRequestControl> constructor. Passing a string which cannot be encoded as a UTF8 value now throws an <xref:System.Text.EncoderFallbackException>.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made for RFC and specification compliance. In the various RFCs and sections of MS-ADTS, the controlValue is specified as the BER encoding of an ASN.1 structure with wording similar to the following (from [RFC2891, section 1.2](https://datatracker.ietf.org/doc/html/rfc2891#section-1.2)):

> The controlType is set to "1.2.840.113556.1.4.474". The criticality is FALSE (MAY be absent). The controlValue is an OCTET STRING, whose value is the BER encoding of a value of the following SEQUENCE:

This precludes trailing data. It also rules out BER encodings of ASN.1 structures with differing ASN.1 tags, and of invalid BER encodings (such as OCTET STRINGs which are longer than their containing SEQUENCE.)

For the <xref:System.DirectoryServices.Protocols.VlvRequestControl> constructor, throwing the exception early means that users can trust that only the values they explicitly specify are sent to the server. There are no circumstances where they can accidentally send `EF BF BD` to the server because they've passed a string that can't be encoded to valid UTF8 bytes.

## Recommended action

Servers should comply with the RFCs and specifications. Make sure to handle an <xref:System.Text.EncoderFallbackException> when calling the <xref:System.DirectoryServices.Protocols.VlvRequestControl> constructor.

## Affected APIs

- <xref:System.DirectoryServices.Protocols.LdapConnection.SendRequest*?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.LdapConnection.EndSendRequest*?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.VlvRequestControl.%23ctor*>
