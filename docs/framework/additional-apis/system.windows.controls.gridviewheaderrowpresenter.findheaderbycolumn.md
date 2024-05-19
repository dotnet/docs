---
title: FindHeaderByColumn method (System.Windows.Controls.GridViewHeaderRowPresenter)
description: Learn about the private WPF method called FindHeaderByColumn.
ms.date: 09/25/2020
ms.subservice: wpf
topic_type:
  - apiref
api_name:
  - System.Windows.Controls.GridViewHeaderRowPresenter.FindHeaderByColumn
api_location:
  - PresentationFramework.dll
api_type:
  - Assembly
---
# FindHeaderByColumn method

Finds the column header for the specified column in the visual tree.

```csharp
private GridViewColumnHeader FindHeaderByColumn(GridViewColumn column)
```

> [!WARNING]
> This method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Parameters

`column` <xref:System.Windows.Controls.GridViewColumn>\
The column whose header should be found and returned.

## Return value

<xref:System.Windows.Controls.GridViewColumnHeader>\
The header of the specified column, or `null` if the specified column doesn't exist.

## Requirements

**Namespace:** <xref:System.Windows.Controls>

**Assembly:** PresentationFramework.dll

## See also

- <xref:System.Windows.Controls.GridViewHeaderRowPresenter>
