---
title: "Breaking change - CompositeMLDsa updated to draft-08"
description: "Learn about the breaking change in .NET 10 where CompositeMLDsa was updated from draft-07 to draft-08 of the Composite ML-DSA for use in X.509 Public Key Infrastructure specification."
ms.date: 11/04/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/runtime/pull/120077
---

# CompositeMLDsa updated to draft-08

`CompositeMLDsa` has moved from draft-07 to draft-08 of the [Composite ML-DSA for use in X.509 Public Key Infrastructure](https://datatracker.ietf.org/doc/draft-ietf-lamps-pq-composite-sigs/) specification. The draft-08 format is not compatible with the draft-07 signatures, and key export/import formats are also incompatible across the draft-07/draft-08 boundary. draft-08 and draft-09 are compatible.

## Version introduced

.NET 10.0.0

## Previous behavior

Signatures were generated and validated according to draft-07 of Composite ML-DSA for use in X.509 Public Key Infrastructure.

Public key and private key export and import used the format from draft-07 of Composite ML-DSA for use in X.509 Public Key Infrastructure.

## New behavior

Signatures are generated and validated according to draft-08 of Composite ML-DSA for use in X.509 Public Key Infrastructure.

Public key and private key export and import use the format from draft-08 of Composite ML-DSA for use in X.509 Public Key Infrastructure.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Staying current with the underlying specification.

## Recommended action

The <xref:System.Security.Cryptography.CompositeMLDsa> class is marked as `[Experimental]`, in part, because the specification is not yet complete. Developers should not yet be depending on this class in production.

Any previously generated keys and signatures should be discarded.

## Affected APIs

- <xref:System.Security.Cryptography.CompositeMLDsa?displayProperty=fullName>
