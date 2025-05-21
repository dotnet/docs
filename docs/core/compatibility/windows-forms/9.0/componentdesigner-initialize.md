---
title: "Breaking change: ComponentDesigner.Initialize throws ArgumentNullException"
description: Learn about the breaking change in .NET 9 for Windows Forms where ComponentDesigner.Initialize now throws ArgumentNullException if the component argument is null.
ms.date: 01/16/2024
ms.topic: concept-article
---
# ComponentDesigner.Initialize throws ArgumentNullException

<xref:System.ComponentModel.Design.ComponentDesigner.Initialize%2A?displayProperty=nameWithType> was updated to throw an <xref:System.ArgumentNullException> if the component argument is `null`.

## Version introduced

.NET 9 Preview 1

## Previous behavior

Previously, <xref:System.ComponentModel.Design.ComponentDesigner.Initialize%2A?displayProperty=nameWithType> accepted a `null` argument, but resulted in a <xref:System.NullReferenceException> or other exception later on.

## New behavior

Starting in .NET 9, <xref:System.ComponentModel.Design.ComponentDesigner.Initialize%2A?displayProperty=nameWithType> throws an <xref:System.ArgumentNullException> if the argument is `null`.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

During the process of enabling nullability in the code file, it was discovered that many methods and properties, both in <xref:System.ComponentModel.Design.ComponentDesigner> and its subclasses, relied on the passed-in component to be initialized to non-`null`. These methods and properties resulted in a <xref:System.NullReferenceException> or another exception later on if they were initialized with a `null` value.

## Recommended action

Make sure you don't call <xref:System.ComponentModel.Design.ComponentDesigner.Initialize%2A?displayProperty=nameWithType> with a `null` argument.

## Affected APIs

- <xref:System.ComponentModel.Design.ComponentDesigner.Initialize%2A?displayProperty=fullName>
