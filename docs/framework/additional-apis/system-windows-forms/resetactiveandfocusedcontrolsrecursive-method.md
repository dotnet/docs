---
description: Learn more about the ResetActiveAndFocusedControlsRecursive method
title: ResetActiveAndFocusedControlsRecursive method
ms.date: 11/10/2021
ms.technology: dotnet-winforms
api_name:
  - System.Windows.Forms.ContainerControl.ResetActiveAndFocusedControlsRecursive
api_location:
  - System.Windows.Forms.dll
api_type:
  - Assembly
topic_type:
  - apiref
---

# ResetActiveAndFocusedControlsRecursive method

Resets the active control and the control that has focus. If the active control is itself a container control, this method is called on the active control before it's reset.

## Syntax

```csharp
internal void ResetActiveAndFocusedControlsRecursive()
```

> [!WARNING]
> The `ResetActiveAndFocusedControlsRecursive` method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Windows.Forms?displayProperty=fullName>

**Assembly:** System.Windows.Forms (in System.Windows.Forms.dll)

**.NET Framework versions:** Available since 1.0.

## See also

- <xref:System.Windows.Forms.ContainerControl>
