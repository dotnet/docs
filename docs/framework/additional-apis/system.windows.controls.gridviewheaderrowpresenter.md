---
title: GridViewHeaderRowPresenter methods (System.Windows.Controls)
ms.date: 09/25/2020
ms.technology: dotnet-networking
topic_type:
  - apiref
api_name:
  - System.Windows.Controls.GridViewHeaderRowPresenter.FindHeaderByColumn
  - System.Windows.Controls.GridViewHeaderRowPresenter.MakeParentItemsControlGotFocus
  - System.Windows.Controls.GridViewHeaderRowPresenter.PrepareHeaderDrag
api_location:
  - PresentationFramework.dll
api_type:
  - Assembly
---
# GridViewHeaderRowPresenter methods

## FindHeaderByColumn method

Finds the column header for the specified column in the visual tree.

```csharp
private GridViewColumnHeader FindHeaderByColumn(GridViewColumn column)
```

> [!WARNING]
> This method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

### Parameters

`column` <xref:System.Windows.Controls.GridViewColumn>\
The column whose header should be found and returned.

### Return value

<xref:System.Windows.Controls.GridViewColumnHeader>

The header of the specified column, or `null` if the specified column doesn't exist.

## MakeParentItemsControlGotFocus method

Gives focus to the parent control of the item. If the parent control is a <xref:System.Windows.Controls.ListBox>, gives focus to the most recently accessed item in the <xref:System.Windows.Controls.ListBox>.

```csharp
internal void MakeParentItemsControlGotFocus()
```

> [!WARNING]
> This method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## PrepareHeaderDrag method

Prepares the specified column header for reordering.

```csharp
private void PrepareHeaderDrag(GridViewColumnHeader header, Point pos, Point relativePos, bool cancelInvoke)
```

> [!WARNING]
> This method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

### Parameters

`header` <xref:System.Windows.Controls.GridViewColumnHeader>\
The column header to prepare for reordering.

`pos` <xref:System.Windows.Point>\
The position, relative to <xref:System.Windows.Controls.GridViewHeaderRowPresenter>, where the dragging starts.

`relativePos` <xref:System.Windows.Point>\
The position, relative to `header`, where the dragging starts.

`cancelInvoke` <xref:System.Boolean>\
`true` to cancel the reordering; otherwise, `false`.

## Requirements

**Namespace:** <xref:System.Windows.Controls>

**Assembly:** PresentationFramework.dll

## See also

- <xref:System.Windows.Controls.GridViewHeaderRowPresenter>
