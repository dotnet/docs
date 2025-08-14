---
title: "Breaking change: System.Drawing OutOfMemoryException changed to ExternalException"
description: "Learn about the breaking change in .NET 10 where System.Drawing GDI+ OutOfMemory errors now throw ExternalException instead of OutOfMemoryException."
ms.date: 08/15/2025
ai-usage: ai-assisted
dev_langs:
- CSharp
- VB
---

# System.Drawing OutOfMemoryException changed to ExternalException

GDI+ error handling in System.Drawing has been updated to throw <xref:System.Runtime.InteropServices.ExternalException> instead of <xref:System.OutOfMemoryException> for `Status.OutOfMemory` errors.

## Version introduced

.NET 10 Preview 5

## Previous behavior

When GDI+ encountered `Status.OutOfMemory` errors (often due to invalid input rather than actual memory issues), System.Drawing APIs threw <xref:System.OutOfMemoryException>.

## New behavior

When GDI+ encounters `Status.OutOfMemory` errors, System.Drawing APIs now throw <xref:System.Runtime.InteropServices.ExternalException> instead.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

GDI+ isn't particularly good at returning errors when it's unable to create internal objects. There are many cases where object creation fails due to invalid input, and higher-level code gets a null and turns it into `Status.OutOfMemory`. This is frequently a source of confusion since the error is often not related to actual memory issues.

The change to `ExternalException` provides more accurate error reporting, as this exception type is already thrown in other System.Drawing code paths for similar GDI+ errors.

## Recommended action

If your code catches `OutOfMemoryException` when using System.Drawing APIs, ensure you also catch `ExternalException` to handle these GDI+ errors.

```csharp
try
{
    // System.Drawing operations
}
catch (ExternalException ex)
{
    // Handle GDI+ errors (including former OutOfMemoryException cases)
}
catch (OutOfMemoryException ex)
{
    // Handle actual memory issues
}
```

```vb
Try
    ' System.Drawing operations
Catch ex As ExternalException
    ' Handle GDI+ errors (including former OutOfMemoryException cases)
Catch ex As OutOfMemoryException
    ' Handle actual memory issues
End Try
```

## Affected APIs

All System.Drawing APIs that interact with GDI+ and previously could throw `OutOfMemoryException` for `Status.OutOfMemory` errors, including but not limited to:

- <xref:System.Drawing.Bitmap?displayProperty=fullName> constructors and methods
- <xref:System.Drawing.Graphics?displayProperty=fullName> methods
- <xref:System.Drawing.Image?displayProperty=fullName> methods
- <xref:System.Drawing.Icon?displayProperty=fullName> constructors and methods
- Other System.Drawing types that use GDI+ internally
