---
title: "Breaking change: Nullable annotation on AssociatedMetadataTypeTypeDescriptionProvider method"
description: Learn about the .NET 6 breaking change in core .NET libraries where a nullable reference type annotation was added to `AssociatedMetadataTypeTypeDescriptionProvider.GetTypeDescriptor`.
ms.date: 09/21/2021
---
# New nullable annotation in AssociatedMetadataTypeTypeDescriptionProvider

In .NET 6, a nullability annotation has been added to <xref:System.ComponentModel.DataAnnotations.AssociatedMetadataTypeTypeDescriptionProvider.GetTypeDescriptor(System.Type,System.Object)?displayProperty=nameWithType>. This method was previously unannotated for nullable reference types.

## Previous behavior

The affected method was treated as "oblivious" with regard to reference type nullability.

## New behavior

The parameters of the affected method are now annotated with accurate nullability conditions.

## Version introduced

6.0 RC 2

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This method had dependencies on other APIs that were previously unannotated. The dependencies have since been annotated, allowing this API to also be annotated. This change completes our nullable reference type annotations for the shared framework libraries.

## Recommended action

Update code that calls this method to reflect the revised nullability contract.

## Affected APIs

| API | What changed |
|-|-|
| <xref:System.ComponentModel.DataAnnotations.AssociatedMetadataTypeTypeDescriptionProvider.GetTypeDescriptor(System.Type,System.Object)?displayProperty=fullName> | `instance` parameter type is nullable |
