---
title: "Breaking change: System.Drawing.Common only supported on Windows"
description: Learn about the .NET 6 breaking change where the System.Drawing.Common package is no longer support on non-Windows operating systems.
ms.date: 07/27/2021
---
# System.Drawing.Common only supported on Windows

The [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet package is now attributed as a Windows-specific library. The platform analyzer emits warning at compile time when compiling for non-Windows operating systems.

On non-Windows operating systems, unless you set a runtime configuration switch, a <xref:System.TypeInitializationException> exception is thrown with <xref:System.PlatformNotSupportedException> as the inner exception.

## Old behavior

Prior to .NET 6, using the System.Drawing.Common package did not produce any compile-time warnings, and no run-time exceptions were thrown.

## New behavior

Starting in .NET 6, the platform analyzer emits compile-time warnings when referencing code is compiled for non-Windows operating systems. In addition, the following run-time exception is thrown unless you set a configuration option:

```
System.TypeInitializationException : The type initializer for 'Gdip' threw an exception.
      ---- System.PlatformNotSupportedException : System.Drawing.Common is not supported on non-Windows platforms. See https://aka.ms/systemdrawingnonwindows for more information.
      Stack Trace:
           at System.Drawing.SafeNativeMethods.Gdip.GdipCreateBitmapFromFile(String filename, IntPtr& bitmap)
        /_/src/libraries/System.Drawing.Common/src/System/Drawing/Bitmap.cs(42,0): at System.Drawing.Bitmap..ctor(String filename, Boolean useIcm)
        /_/src/libraries/System.Drawing.Common/src/System/Drawing/Bitmap.cs(25,0): at System.Drawing.Bitmap..ctor(String filename)
        /_/src/libraries/System.Resources.ResourceManager/tests/ResourceManagerTests.cs(270,0): at System.Resources.Tests.ResourceManagerTests.EnglishImageResourceData()+MoveNext()
        /_/src/libraries/System.Linq/src/System/Linq/Select.cs(136,0): at System.Linq.Enumerable.SelectEnumerableIterator`2.MoveNext()
        ----- Inner Stack Trace -----
        /_/src/libraries/System.Drawing.Common/src/System/Drawing/LibraryResolver.cs(31,0): at System.Drawing.LibraryResolver.EnsureRegistered()
        /_/src/libraries/System.Drawing.Common/src/System/Drawing/GdiplusNative.Unix.cs(65,0): at System.Drawing.SafeNativeMethods.Gdip.PlatformInitialize()
        /_/src/libraries/System.Drawing.Common/src/System/Drawing/Gdiplus.cs(27,0): at System.Drawing.SafeNativeMethods.Gdip..cctor()
```

## Version introduced

.NET 6

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Because `System.Drawing.Common` was designed to be a thin wrapper over Windows technologies, its cross-platform implementation is subpar.

`libgdiplus` is the main provider of the cross-platform implementation of `System.Drawing.Common` on the native side. `libgdiplus` is effectively a reimplementation of the parts of Windows that `System.Drawing.Common` depends on. That implementation makes `libgdiplus` a non-trivial component. It's around 30,000 lines of C code that's largely untested, and it lacks a lot of functionality. `libgdiplus` also has numerous external dependencies for image processing and text rendering, such as `cairo`, `pango`, and other native libraries. Those dependencies make maintaining and shipping the component even more challenging. Since the inclusion of the Mono cross-platform implementation, we have redirected numerous issues to `libgdiplus` that never got fixed. In comparison, other external dependencies we have taken, such as `icu` or `openssl`, are high-quality libraries. It's not viable to get `libgdiplus` to the point where its feature set and quality is on par with the rest of the .NET stack.

From analysis of NuGet packages, we've observed that `System.Drawing.Common` is used cross-platform mostly for image manipulation, such as QR code generators and text rendering. We haven't noticed heavy graphics usage, as our cross-platform graphics support is incomplete. The usages we see of `System.Drawing.Common` in non-Windows environments are typically well supported with SkiaSharp and ImageSharp.

`System.Drawing.Common` will continue to evolve only in the context of Windows Forms and GDI+.

## Recommended action

To use these APIs for cross-platform apps, migrate to one of the following libraries:

- [ImageSharp](https://github.com/SixLabors/ImageSharp)
- [SkiaSharp](https://github.com/mono/SkiaSharp)
- [Microsoft.Maui.Graphics](https://github.com/dotnet/Microsoft.Maui.Graphics)

Alternatively, you can enable support for non-Windows platforms by setting the `System.Drawing.EnableUnixSupport` [runtime configuration switch](../../../run-time-config/index.md) to `true` in the *runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Drawing.EnableUnixSupport": true
      }
   }
}
```

This configuration switch was added to give cross-platform apps that depend heavily on this package time to migrate to more modern libraries. However, non-Windows bugs will not be fixed. In addition, we may completely remove support for non-Windows platforms in a future release, even if you enable it using the runtime configuration switch.

> [!NOTE]
> Despite the name of the runtime switch, `System.Drawing.EnableUnixSupport`, it applies to various non-Windows platforms, such as macOS and Android, which can generally be considered flavors of Unix.

## Affected APIs

<xref:System.Drawing?displayProperty=fullName> namespace:

- <xref:System.Drawing.Bitmap>
- <xref:System.Drawing.Brush>
- <xref:System.Drawing.Brushes>
- <xref:System.Drawing.BufferedGraphics>
- <xref:System.Drawing.BufferedGraphicsContext>
- <xref:System.Drawing.Font>
- <xref:System.Drawing.FontFamily>
- <xref:System.Drawing.FontConverter>
- <xref:System.Drawing.Graphics>
- <xref:System.Drawing.Icon>
- <xref:System.Drawing.IconConverter>
- <xref:System.Drawing.Image>
- <xref:System.Drawing.ImageAnimator>
- <xref:System.Drawing.Pen>
- <xref:System.Drawing.Pens>
- <xref:System.Drawing.Region>
- <xref:System.Drawing.SolidBrush>
- <xref:System.Drawing.StringFormat>
- <xref:System.Drawing.SystemBrushes>
- <xref:System.Drawing.SystemFonts>
- <xref:System.Drawing.SystemIcons>
- <xref:System.Drawing.SystemPens>
- <xref:System.Drawing.TextureBrush>

<xref:System.Drawing.Drawing2D?displayProperty=fullName> namespace:

- <xref:System.Drawing.Drawing2D.AdjustableArrowCap>
- <xref:System.Drawing.Drawing2D.CustomLineCap>
- <xref:System.Drawing.Drawing2D.GraphicsPath>
- <xref:System.Drawing.Drawing2D.GraphicsPathIterator>
- <xref:System.Drawing.Drawing2D.GraphicsState>
- <xref:System.Drawing.Drawing2D.HatchBrush>
- <xref:System.Drawing.Drawing2D.LinearGradientBrush>
- <xref:System.Drawing.Drawing2D.Matrix>
- <xref:System.Drawing.Drawing2D.PathGradientBrush>

<xref:System.Drawing.Imaging?displayProperty=fullName> namespace:

- <xref:System.Drawing.Imaging.Encoder>
- <xref:System.Drawing.Imaging.EncoderParameter>
- <xref:System.Drawing.Imaging.EncoderParameters>
- <xref:System.Drawing.Imaging.ImageAttributes>
- <xref:System.Drawing.Imaging.ImageCodecInfo>
- <xref:System.Drawing.Imaging.ImageFormat>
- <xref:System.Drawing.Imaging.Metafile>
- <xref:System.Drawing.Imaging.MetafileHeader>
- <xref:System.Drawing.Imaging.PlayRecordCallback>

<xref:System.Drawing.Printing?displayProperty=fullName> namespace:

- <xref:System.Drawing.Printing.PageSettings>
- <xref:System.Drawing.Printing.PreviewPageInfo>
- <xref:System.Drawing.Printing.PrintController>
- <xref:System.Drawing.Printing.PrintDocument>
- <xref:System.Drawing.Printing.PrinterSettings>
- <xref:System.Drawing.Printing.PrintEventArgs>
- <xref:System.Drawing.Printing.PrintEventHandler>
- <xref:System.Drawing.Printing.PrintPageEventArgs>
- <xref:System.Drawing.Printing.PrintPageEventHandler>

<xref:System.Drawing.Text?displayProperty=fullName> namespace:

- <xref:System.Drawing.Text.FontCollection>
- <xref:System.Drawing.Text.InstalledFontCollection>
- <xref:System.Drawing.Text.PrivateFontCollection>

## See also

- [`System.Drawing.Common` only supported on Windows - dotnet/designs](https://github.com/dotnet/designs/blob/main/accepted/2021/system-drawing-win-only/system-drawing-win-only.md)
