---
title: "Breaking change: Some APIs throw ArgumentNullException"
description: Learn about the breaking change in .NET 6.0 where some APIs validate arguments and now throw an ArgumentNullException.
ms.date: 01/29/2021
---
# Some APIs throw ArgumentNullException

Some APIs now validate input parameters and throw an <xref:System.ArgumentNullException> where previously they threw a <xref:System.NullReferenceException>, if invoked with `null` input arguments.

## Change description

In previous .NET versions, the affected APIs throw a <xref:System.NullReferenceException> if invoked with an argument that's `null`.

Starting in .NET 6.0, the affected APIs throw an <xref:System.ArgumentNullException> if invoked with an argument that's `null`.

## Reason for change

Throwing <xref:System.ArgumentNullException> conforms to .NET Runtime behavior. It provides a better debug experience by clearly communicating which argument caused the exception.

## Version introduced

.NET 6.0

## Recommended action

- Review and, if necessary, update your code to prevent passing `null` input arguments to the affected APIs.
- If your code handles <xref:System.NullReferenceException>, replace or add an additional handler for <xref:System.ArgumentNullException>.

## Affected APIs

The following table lists the affected properties:

| Property | Version changed |
|-|-|-|-|
| <xref:System.Windows.Forms.TreeNodeCollection.Item(System.Int32)?displayProperty=fullName> | Preview 1 |

<!--

### Affected APIs

- `P:System.Windows.Forms.TreeNodeCollection.Item(System.Int32)`

### Category

Windows Forms

-->
