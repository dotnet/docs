---
title: PrepareHeaderDrag method (System.Windows.Controls.GridViewHeaderRowPresenter)
description: Learn about the private WPF method called PrepareHeaderDrag.
ms.date: 09/25/2020
ms.subservice: wpf
topic_type:
  - apiref
api_name:
  - System.Windows.Controls.GridViewHeaderRowPresenter.PrepareHeaderDrag
api_location:
  - PresentationFramework.dll
api_type:
  - Assembly
---
# PrepareHeaderDrag method

Prepares the specified column header for reordering.

```csharp
private void PrepareHeaderDrag(GridViewColumnHeader header, Point pos, Point relativePos, bool cancelInvoke)
```

> [!WARNING]
> This method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Parameters

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
