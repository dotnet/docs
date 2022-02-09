---
title: "Breaking change: Virtual method call optimized"
description: Learn about the breaking change in .NET 6 for Windows Forms where ScaleControl is only called if scaling is needed.
ms.date: 02/08/2022
---
# ScaleControl called only when needed

Scaling is usually needed only when an application is running in `SystemAware /PermonitorV2` modes, and the monitor where the app is going to render has custom DPI settings that differ from the machine where the app was designed. In these scenarios, the Windows Forms runtime calculates the scale factor, based on custom DPI settings of the monitor, and calls <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> with the new scale factor. To improve performance, `ScaleControl` is now called only when the calculated scale factor is other than 1.0F (that is, scaling is needed).

## Version introduced

.NET 6 servicing

## Old behavior

In .NET 6 GA release and earlier versions, the virtual, public API <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> was called every time <xref:System.Windows.Forms.ContainerControl.PerformAutoScale> was called on the container control of the application. That is, the method was called every time there way a layout or font change. <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> was called regardless of whether scaling was needed.

## New behavior

Starting in .NET 6 servicing releases, <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> is called only when there's a need to scale the form or control. The Windows Forms runtime calculates the scale factor based on the custom DPI settings of the monitor and the DPI settings of the monitor on which the application was designed. <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> is called only if the scale factor indicates that scaling is required.

## Change category

This change affects [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

This change was made to improve performance and avoid unnecessary layouts.

## Recommended action

Revisit your code and use alternative if they are performing any non scaling custom actions in these overridable methods.

## Affected APIs

N/A
