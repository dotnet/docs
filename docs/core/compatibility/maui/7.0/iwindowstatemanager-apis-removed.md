---
title: "Breaking change: Some Windows APIs are removed"
description: Learn about the .NET 7 breaking change in .NET MAUI where the `IWindowStateManager.ActiveWindowDisplayChanged`, `IWindowStateManager.OnWindowMessage`, and `Platform.OnWindowMessage` APIs have been removed.
ms.date: 11/14/2022
ms.topic: concept-article
---
# Some Windows APIs are removed

The following APIs have been removed:

- `Microsoft.Maui.ApplicationModel.IWindowStateManager.ActiveWindowDisplayChanged` event
- `Microsoft.Maui.ApplicationModel.IWindowStateManager.OnWindowMessage(System.IntPtr,uint,System.IntPtr,System.IntPtr)` method
- `Microsoft.Maui.ApplicationModel.Platform.OnWindowMessage(System.IntPtr,uint,System.IntPtr,System.IntPtr)` method

## Version introduced

.NET 7

## Previous behavior

Previously, the `IWindowStateManager.OnWindowMessage()` method was an implementation detail that ran a check on the parameters to determine if the `ActiveWindowDisplayChanged` event should be raised. The `ActiveWindowDisplayChanged` event could be invoked if the concrete type was able to observe changes of the display that contained the currently active window.

You could call the `Platform.OnWindowMessage()` method to pass messages. This method called into `IWindowStateManager.OnWindowMessage()` and then that would optionally cause the `ActiveWindowDisplayChanged` event to fire.

## New behavior

The APIs are now removed.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The `ActiveWindowDisplayChanged` event should never have been public because it was an implementation detail and provided no additional information that "something had changed". We removed it to avoid confusion with the `MainDisplayInfoChanged` event and to reduce potential implementation complexity for both users and the SDK itself.

The `IWindowStateManager.OnWindowMessage()` method was also an implementation detail and should never have been public. This API no longer does anything and thus was removed.

The `Platform.OnWindowMessage()` method was implemented to work around a limitation of Xamarin.Forms and Xamarin.Essentials. It was brought forward into .NET MAUI to aid migration and used in .NET 6. However, in .NET 7, this API no longer does anything and was removed.

## Recommended action

- If you're not building your app for Windows, no action is necessary.
- If you were using `ActiveWindowDisplayChanged`, use `Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfoChanged` instead.
- If you were calling either of the `OnWindowMessage()` methods, remove the call.

## Affected APIs

- `Microsoft.Maui.ApplicationModel.IWindowStateManager.ActiveWindowDisplayChanged`
- `Microsoft.Maui.ApplicationModel.IWindowStateManager.OnWindowMessage(System.IntPtr,uint,System.IntPtr,System.IntPtr)`
- `Microsoft.Maui.ApplicationModel.Platform.OnWindowMessage(System.IntPtr,uint,System.IntPtr,System.IntPtr)`
