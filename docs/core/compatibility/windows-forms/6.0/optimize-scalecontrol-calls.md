---
title: "Breaking change: Virtual method call optimized"
description: Learn about the breaking change in .NET 6 for Windows Forms where ScaleControl is only called if scaling is needed.
ms.date: 02/08/2022
ms.topic: concept-article
---
# ScaleControl called only when needed

Scaling is usually needed only when an application is running in <xref:System.Windows.Forms.HighDpiMode.SystemAware> or <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2> mode and the monitor has custom DPI settings that differ from the machine where the app was designed. In these scenarios, the Windows Forms runtime calculates the scale factor, based on custom DPI settings of the monitor, and calls <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> with the new scale factor. To improve performance, `ScaleControl` is now called only when the calculated scale factor is something other than 1.0F (that is, scaling is needed). This change can break your app if it overrides `ScaleControl` and performs any custom actions in the override.

## Version introduced

.NET 6 servicing 6.0.101

## Old behavior

In .NET 6 GA release and earlier versions, the virtual, public API <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> was called every time <xref:System.Windows.Forms.ContainerControl.PerformAutoScale> was called on the container control of the application. That is, the method was called every time there is a layout or font change, regardless of whether scaling was needed.

## New behavior

Starting in .NET 6 servicing releases, <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> is called only when there's a need to scale the form or control. The Windows Forms runtime calculates the scale factor based on the custom DPI settings of the monitor and the DPI settings of the monitor on which the application was designed. <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)> is called only if the scale factor indicates that scaling is required.

## Change category

This change affects [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

This change was made to improve performance and avoid unnecessary layouts.

## Recommended action

Check if your code performs any custom, non-scaling actions in these overridable methods.

## Affected APIs

- <xref:System.Windows.Forms.Form.ScaleControl(System.Drawing.SizeF,System.Windows.Forms.BoundsSpecified)?displayProperty=fullName>
