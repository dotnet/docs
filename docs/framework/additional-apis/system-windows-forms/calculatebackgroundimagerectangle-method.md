---
description: Learn more about the CalculateBackgroundImageRectangle method
title: CalculateBackgroundImageRectangle method
ms.date: 11/10/2021
ms.technology: dotnet-winforms
api_name:
  - System.Windows.Forms.ControlPaint.CalculateBackgroundImageRectangle
api_location:
  - System.Windows.Forms.dll
api_type:
  - Assembly
topic_type:
  - apiref
---

# CalculateBackgroundImageRectangle method

Calculates the location and size for a background image with a specified layout, for example, stretched, centered, or zoomed.

## Syntax

```csharp
internal static Rectangle CalculateBackgroundImageRectangle(Rectangle bounds, Image backgroundImage, ImageLayout imageLayout)
```

## Parameters

`bounds`\
The client rectangle for `backgroundImage`.

`backgroundImage`\
The image whose location and size is to be calculated. If `null`, the client rectangle `bounds` is returned.

`imageLayout`\
One of the enumeration values that specifies the position of the background image relative to `bounds`.

## Returns

<xref:System.Drawing.Rectangle>\
The location and size for the specified background image with the specified layout.

> [!WARNING]
> The `CalculateBackgroundImageRectangle` method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Windows.Forms?displayProperty=fullName>

**Assembly:** System.Windows.Forms (in System.Windows.Forms.dll)

**.NET Framework versions:** Available since 1.0.

## See also

- <xref:System.Windows.Forms.ControlPaint>
