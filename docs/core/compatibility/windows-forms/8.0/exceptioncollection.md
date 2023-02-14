---
title: "Breaking change: ExceptionCollection constructor throws ArgumentException"
description: Learn about the breaking change in .NET 8 for Windows Forms where the ExceptionCollection constructor now throws an exception if the input is not of type Exception.
ms.date: 02/06/2023
---
# ExceptionCollection ctor throws ArgumentException

The <xref:System.ComponentModel.Design.ExceptionCollection> constructor now throws an <xref:System.ArgumentException> if the elements in the input array are not of type <xref:System.Exception>.

## Version introduced

.NET 8 Preview 1

## Previous behavior

Previously, the <xref:System.ComponentModel.Design.ExceptionCollection> constructor did not check the type passed in, which could delay failure until later in the process. No exceptions were thrown during object creation.

## New behavior

Starting in .NET 8, if the elements in the input array are not of type <xref:System.Exception>, an <xref:System.ArgumentException> is thrown.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

This change helps to make exception types consistent across the code base.

## Recommended action

For most scenarios, this change should not have a significant impact. However, consider updating your code to handle <xref:System.ArgumentException> at constructor call sites.

## Affected APIs

- <xref:System.ComponentModel.Design.ExceptionCollection.%23ctor(System.Collections.ArrayList)> constructor
