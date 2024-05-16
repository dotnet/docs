---
title: "Breaking change: Optional parameter on UpdateBackground"
description: Learn about the .NET 7 breaking change in .NET MAUI where an optional parameter was added to the UpdateBackground method.
ms.date: 11/14/2022
---
# New UpdateBackground parameter

When updating the button background on iOS, the border was also required to be drawn. This change adds a new parameter to `ViewExtensions.UpdateBackground()` to pass in the stroke information.

## Version introduced

.NET 7

## Previous behavior

Previously there was no way to draw the border on buttons if there was a gradient or complex background.

## New behavior

The new, optional parameter now allows for additional border information.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

We need more information when drawing the button background or border, so we added a new parameter to pass this information.

## Recommended action

No action is required if you're calling from source. Otherwise, multi-target to support `net6.0-ios` or `net6.0-maccatalyst`.

## Affected APIs

- `Microsoft.Maui.Platform.ViewExtensions.UpdateBackground(UIKit.UIView,Microsoft.Maui.Graphics.Paint)`
