---
title: "Breaking change: Some TableLayoutSettings properties throw InvalidEnumArgumentException"
description: Learn about the breaking change in .NET 6 where some TableLayoutSettings APIs now throw an InvalidEnumArgumentException for invalid arguments.
ms.date: 01/18/2021
---
# Selected TableLayoutSettings properties throw InvalidEnumArgumentException

Selected <xref:System.Windows.Forms.TableLayoutSettings> properties now throw an <xref:System.ComponentModel.InvalidEnumArgumentException> if you attempt to assign an incorrect value.

## Change description

In previous .NET versions, these properties throw an <xref:System.ArgumentOutOfRangeException> if you attempt to assign an incorrect value. Starting in .NET 6, these properties throw an <xref:System.ComponentModel.InvalidEnumArgumentException> in such cases.

## Reason for change

Throwing <xref:System.ComponentModel.InvalidEnumArgumentException> is in line with the existing Windows Forms API in similar situations. Throwing this exception also provides developers with a better debug experience.

## Version introduced

.NET 6.0

## Recommended action

- Update the code to prevent assigning incorrect values.
- If necessary, handle an <xref:System.ComponentModel.InvalidEnumArgumentException> when accessing these APIs.

## Affected APIs

The following table lists the affected properties:

| Property | Version changed |
|-|-|-|-|
| <xref:System.Windows.Forms.TableLayoutPanel.CellBorderStyle?displayProperty=fullName> | Preview 1 |
| <xref:System.Windows.Forms.TableLayoutPanel.GrowStyle?displayProperty=fullName> | Preview 1 |

<!--

### Affected APIs

- `P:System.Windows.Forms.TableLayoutPanel.CellBorderStyle`
- `P:System.Windows.Forms.TableLayoutPanel.GrowStyle`

### Category

Windows Forms

-->
