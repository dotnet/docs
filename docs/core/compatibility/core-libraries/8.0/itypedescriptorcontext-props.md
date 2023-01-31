---
title: ".NET 8 breaking change: ITypeDescriptorContext nullable annotations"
description: Learn about the .NET 8 breaking change in core .NET libraries where the nullable annotations on three ITypeDescriptorContext properties have changed.
ms.date: 01/31/2023
---
# ITypeDescriptorContext nullable annotations

<xref:System.ComponentModel.ITypeDescriptorContext?displayProperty=fullName> has three properties that were previously annotated as being non-nullable, but they were actually nullable in practice. The nullable annotations for these properties have been updated to indicate that they're nullable. This change can result in new build warnings related to use of nullable members.

## Previous behavior

Previously, the [affected properties](#affected-apis) were annotated as not being nullable. You could consume their values and assume they couldn't be null without any compile-time warnings.

## New behavior

Starting in .NET 8, the [affected properties](#affected-apis) are annotated as being nullable. If you consume their values without null checks, you'll get warnings at compile time.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The previous annotations of these properties were incorrect. This change applies the appropriate behavior for the properties and ensures callers understand that the values can be null.

## Recommended action

Update calling code to guard against null for these properties.

## Affected APIs

- <xref:System.ComponentModel.ITypeDescriptorContext.Container?displayProperty=fullName>
- <xref:System.ComponentModel.ITypeDescriptorContext.Instance?displayProperty=fullName>
- <xref:System.ComponentModel.ITypeDescriptorContext.PropertyDescriptor?displayProperty=fullName>
