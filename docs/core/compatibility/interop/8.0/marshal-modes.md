---
title: "Breaking change: Custom marshallers require additional members"
description: Learn about the breaking change in interop in .NET 8 where custom marshallers with MarshalMode.ElementIn or MarshalMode.ElementOut now must have both managed-to-unmanaged and unmanaged-to-managed shapes.
ms.date: 09/06/2023
ms.topic: concept-article
---
# Custom marshallers require additional members

The custom marshaller analyzer has changed to require all element-focused marshal modes to satisfy both the managed-to-unmanaged and unmanaged-to-managed shapes.

## Previous behavior

Custom marshallers with `MarshalMode.ElementIn` only needed a `ConvertToUnmanaged` method. Custom marshallers with `MarshalMode.ElementOut` only needed a `ConvertToManaged` method.

## New behavior

Starting in .NET 8, [SYSLIB1057](../../../../fundamentals/syslib-diagnostics/syslib1050-1069.md) is reported for custom marshallers with `MarshalMode.ElementIn` or `MarshalMode.ElementOut` that don't have both a `ConvertToUnmanaged` and `ConvertToManaged` method.

## Version introduced

.NET 8 RC 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

With the introduction of source-generated COM, the marshallers can be used in element scenarios in both managed-to-unmanaged and unmanaged-to-managed scenarios. This change updates the analyzer to ensure that user-defined marshallers have the required members for all scenarios where the marshaller might be used.

## Recommended action

Add both a `ConvertToManaged` and `ConvertToUnmanaged` method to the marshaller type.

## Affected APIs

- <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute?displayProperty=fullName>
