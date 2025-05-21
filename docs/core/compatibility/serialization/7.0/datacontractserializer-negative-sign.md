---
title: "Breaking change: DataContractSerializer retains sign when deserializing -0"
description: Learn about the .NET 6/7 breaking change in serialization where DataContractSerializer retains the negative sign when deserializing the value "-0" as a float or double.
ms.date: 09/08/2022
ms.topic: concept-article
---
# DataContractSerializer retains sign when deserializing -0

<xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> previously discarded the sign when deserializing the input "-0" as a float or double. Both serializers have always done the right thing when given "-0.0" as an input, but with an input of "-0", the sign was lost. This behavior is both inconsistent and results in data loss. In addition, these serializers write a value of negative zero out as "-0" during serialization.

## Previous behavior

Previously, the negative sign was lost when deserializing "-0" (but *not* "-0.0") as a float or double using <xref:System.Runtime.Serialization.DataContractSerializer>.

## New behavior

The negative sign is now preserved when deserializing "-0" as a float or double.

## Version introduced

- .NET 6.0.11 (servicing release)
- .NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The previous behavior was inconsistent and resulted in data loss.

## Recommended action

In most cases, no action is needed. If your code was affected by the bug, then this is a good change. Or, you've already worked around the bug in a way that's unlikely to be broken by this change.

## Affected APIs

- <xref:System.Runtime.Serialization.DataContractSerializer.ReadObject%2A?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.ReadObject%2A?displayProperty=fullName>
