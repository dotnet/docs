---
title: "Breaking change: DataGridViewRowAccessibleObject.Name starting row index"
description: Learn about the breaking change in .NET 9 for Windows Forms where the starting index for the DataGridViewRowAccessibleObject.Name property is now 1 instead of 0.
ms.date: 01/16/2024
---
# DataGridViewRowAccessibleObject.Name starting row index

<xref:System.Windows.Forms.DataGridViewRow.DataGridViewRowAccessibleObject> has undergone a modification that affects the <xref:System.Windows.Forms.DataGridViewRow.DataGridViewRowAccessibleObject.Name> property. The row index in the `Name` property now starts at 1 instead of 0 by default.

As a result of this change, screen readers announce the selected row of a <xref:System.Windows.Forms.DataGridView> based on a starting index of 1.

## Version introduced

.NET 9 Preview 1

## Previous behavior

Previously, the <xref:System.Windows.Forms.DataGridViewRow.DataGridViewRowAccessibleObject.Name> property based the row index on a starting index of *0*. Screen readers announced the selected row of a <xref:System.Windows.Forms.DataGridView> based on a starting index of 0.

## New behavior

Starting in .NET 9, the index for the <xref:System.Windows.Forms.DataGridViewRow.DataGridViewRowAccessibleObject.Name> property starts at *1*. Screen readers announce the selected row of a <xref:System.Windows.Forms.DataGridView> based on a starting index of 1.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

This modification addresses an accessibility concern highlighted in [GitHub issue #7154](https://github.com/dotnet/winforms/issues/7154). The issue pertains to the row counting in the <xref:System.Windows.Forms.DataGridViewRow.DataGridViewRowAccessibleObject> starting at 0, which creates a discrepancy with user expectations and screen readers.

The change ensures a more intuitive and inclusive experience for users that rely on screen readers and accessibility tools. It also provides developers with the flexibility to maintain the original behavior if necessary.

## Recommended action

If your application relied on the previous behavior and you prefer the row index to start at 0, you can set the new switch `System.Windows.Forms.DataGridViewUIAStartRowCountAtZero`. To maintain the original functionality, create a *runtimeconfig.template.json* file at the root folder of your project and set this switch to `true`. Update your codebase accordingly to accommodate this change and ensure that the <xref:System.Windows.Forms.DataGridViewRow.DataGridViewRowAccessibleObject> displays the row index with a starting point at 0.

Snippet of a *runtimeconfig.template.json* file that sets a switch to revert to the previous behavior:

```json
{
    "configProperties": {
      "System.Windows.Forms.DataGridViewUIAStartRowCountAtZero": true
    }
}
```

## Affected APIs

- <xref:System.Windows.Forms.DataGridViewRow.DataGridViewRowAccessibleObject.Name?displayProperty=fullName>
