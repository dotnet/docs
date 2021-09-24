---
title: "Breaking change: ListViewGroupCollection methods throw new InvalidOperationException"
description: Learn about the breaking change in .NET 6 where some ListViewGroupCollection methods throw a new InvalidOperationException if the ListView is in virtual mode.
ms.date: 09/23/2021
---
# ListViewGroupCollection methods throw new InvalidOperationException

Previously, an <xref:System.InvalidOperationException> was thrown if <xref:System.Windows.Forms.ListViewGroupCollection> methods were invoked on a <xref:System.Windows.Forms.ListView> in virtual mode *and* the <xref:System.Windows.Forms.Control.Handle> had already been created. Starting in .NET 6, these <xref:System.Windows.Forms.ListViewGroupCollection> methods now only check if the <xref:System.Windows.Forms.ListView> is in virtual mode. If it is, they throw an <xref:System.InvalidOperationException> with a more descriptive message.

## Previous behavior

Consider the following code that adds a <xref:System.Windows.Forms.ListViewGroup> to a <xref:System.Windows.Forms.ListView>:

```csharp
ListViewGroup group1 = new ListViewGroup
{
    Header = "CollapsibleGroup1",
    CollapsedState = ListViewGroupCollapsedState.Expanded
};

listView.Groups.Add(group1);
```

This code produced an <xref:System.InvalidOperationException> with the following message:

**When the ListView is in virtual mode, you cannot enumerate through the ListView items collection using an enumerator or call GetEnumerator. Use the ListView items indexer instead and access an item by index value.**

## New behavior

The same code from the [Previous behavior](#previous-behavior) section produces an <xref:System.InvalidOperationException> with the following message:

**You cannot add groups to the ListView groups collection when the ListView is in virtual mode.**

## Reason for change

The new <xref:System.InvalidOperationException> message is more understandable. In addition, it closes a workaround where the developer could add a <xref:System.Windows.Forms.ListViewGroup> to the <xref:System.Windows.Forms.ListView> before the <xref:System.Windows.Forms.Control.Handle> was created.

## Version introduced

.NET 6.0 RC 2

## Recommended action

- Review and, if necessary, update your code so that it doesn't add a <xref:System.Windows.Forms.ListViewGroup> to a <xref:System.Windows.Forms.ListView> in virtual mode.
- If your code handles <xref:System.InvalidOperationException> exceptions, you may need to update the message to reflect that the <xref:System.Windows.Forms.ListView> is in virtual mode.

## Affected APIs

- <xref:System.Windows.Forms.ListViewGroupCollection.Add%2A?displayProperty=fullName>
- <xref:System.Windows.Forms.ListViewGroupCollection.AddRange%2A?displayProperty=fullName>
- <xref:System.Windows.Forms.ListViewGroupCollection.Insert(System.Int32,System.Windows.Forms.ListViewGroup)?displayProperty=fullName>
