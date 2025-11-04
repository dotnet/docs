---
title: "Breaking change - CompositeMLDsa updated to draft-08"
description: "Learn about the breaking change in .NET 10 where CompositeMLDsa was updated from draft-07 to draft-08 of the Composite ML-DSA for use in X.509 Public Key Infrastructure specification."
ms.date: 11/04/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issue/48901
---

# CompositeMLDsa updated to draft-08

<xref:System.Security.Cryptography.CompositeMLDsa> has moved from draft-07 to draft-08 of the [Composite ML-DSA for use in X.509 Public Key Infrastructure](https://datatracker.ietf.org/doc/draft-ietf-lamps-pq-composite-sigs/) specification. The draft-08 format is not compatible with the draft-07 signatures, and key export/import formats are also incompatible across the draft-07/draft-08 boundary. draft-08 and draft-09 are compatible.

## Version introduced

.NET 10 GA

## Previous behavior

In preview and RC releases of .NET 10, signatures were generated and validated according to draft-07 of Composite ML-DSA for use in X.509 Public Key Infrastructure.

Public key and private key export and import used the format from draft-07 of Composite ML-DSA for use in X.509 Public Key Infrastructure.

## New behavior

Starting in .NET 10 GA release, signatures are generated and validated according to draft-08 of Composite ML-DSA for use in X.509 Public Key Infrastructure.

Public key and private key export and import use the format from draft-08 of Composite ML-DSA for use in X.509 Public Key Infrastructure.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to stay current with the underlying specification.

## Recommended action

The <xref:System.Security.Cryptography.CompositeMLDsa> class is marked as `[Experimental]`, partly because the specification is not yet complete. Do not depend on this class in production.

Discard any previously generated keys and signatures.

## Affected APIs

- <xref:System.Security.Cryptography.CompositeMLDsa?displayProperty=fullName>
