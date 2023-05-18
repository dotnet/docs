---
title: "Breaking change: System.Drawing.Common config switch removed"
description: Learn about the .NET 7 breaking change where the EnableUnixSupport switch to enable System.Drawing.Common support on non-Windows operating systems was removed.
ms.date: 05/18/2023
---
# System.Drawing.Common config switch removed

The [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet package has been attributed as a Windows-specific library since .NET 6. On non-Windows operating systems, a <xref:System.TypeInitializationException> exception is thrown with <xref:System.PlatformNotSupportedException> as the inner exception. The runtime configuration switch to re-enable usage of the package on non-Windows operating systems has been removed in .NET 7.

## Old behavior

Prior to .NET 6, using the System.Drawing.Common package did not produce any compile-time warnings, and no run-time exceptions were thrown. In .NET 6, you could set the `System.Drawing.EnableUnixSupport` runtime configuration setting to re-enable non-Windows support.

## New behavior

Starting in .NET 7, the `System.Drawing.EnableUnixSupport` switch has been removed and you can no longer use the [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) package on non-Windows operating systems.

## Version introduced

.NET 7

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The switch to re-enable functionality on non-Windows operating systems was added in .NET 6 to give customers time to migrate to an alternative, modern library. Now that .NET 7 has been released, the switch has been removed. For more information, see [Reason for change (.NET 6 breaking change)](../6.0/system-drawing-common-windows-only.md#reason-for-change).

## Recommended action

To use these APIs for cross-platform apps, migrate to one of the following libraries:

- [ImageSharp](https://sixlabors.com/products/imagesharp)
- [SkiaSharp](https://github.com/mono/SkiaSharp)
- [Microsoft.Maui.Graphics](/dotnet/maui/user-interface/graphics/)

## Affected APIs

See [Affected APIs (.NET 6 breaking change)](../6.0/system-drawing-common-windows-only.md#affected-apis).

## See also

- [System.Drawing.Common only supported on Windows (.NET 6)](../6.0/system-drawing-common-windows-only.md)
- [`System.Drawing.Common` only supported on Windows - dotnet/designs](https://github.com/dotnet/designs/blob/main/accepted/2021/system-drawing-win-only/system-drawing-win-only.md)
