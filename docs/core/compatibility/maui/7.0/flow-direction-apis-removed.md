---
title: "Breaking change: Flow direction helper methods removed"
description: Learn about the .NET 7 breaking change in .NET MAUI where flow direction helper methods have been removed.
ms.date: 11/14/2022
---
# Flow direction helper methods removed

The entire system for flow direction was rewritten and the following APIs have been removed:

- `Microsoft.Maui.IViewExtensions`
- `Microsoft.Maui.IViewExtensions.GetEffectiveFlowDirection(Microsoft.Maui.IView)`
- `Microsoft.Maui.Layouts.LayoutExtensions.ShouldArrangeLeftToRight(Microsoft.Maui.IView)`
- `Microsoft.Maui.Platform.TextAlignmentExtensions.AdjustForFlowDirection(UIKit.UITextAlignment,Microsoft.Maui.IView)`

## Version introduced

.NET 7

## Previous behavior

These helper methods existed to calculate the flow direction of test and UI components.

## New behavior

The methods have been removed.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The previous implementation was incorrect and a performance bottleneck. The entire system for flow direction was rewritten for .NET 7 and the affected APIS no longer had any value or performed any function, so they were removed.

## Recommended action

If you were calling these APIs, remove the calls.

## Affected APIs

- `Microsoft.Maui.IViewExtensions`
- `Microsoft.Maui.IViewExtensions.GetEffectiveFlowDirection(Microsoft.Maui.IView)`
- `Microsoft.Maui.Layouts.LayoutExtensions.ShouldArrangeLeftToRight(Microsoft.Maui.IView)`
- `Microsoft.Maui.Platform.TextAlignmentExtensions.AdjustForFlowDirection(UIKit.UITextAlignment,Microsoft.Maui.IView)`
