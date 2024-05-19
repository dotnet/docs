---
title: "Breaking change: Constructors accept base interface instead of concrete type"
description: Learn about the .NET 7 breaking change in .NET MAUI where the `MauiWebChromeClient` and `MauiWebViewNavigationDelegate` constructors accept the base interface instead of a specific concrete type.
ms.date: 11/14/2022
---
# Constructors accept base interface instead of concrete type

The constructors of the following types now accept the base interface (`IWebViewHandler`) instead of a specific, concrete type that implements the interface (`WebViewHandler`):

- `Microsoft.Maui.Platform.MauiWebChromeClient`
- `Microsoft.Maui.Platform.MauiWebViewNavigationDelegate`

## Version introduced

.NET 7

## Previous behavior

The constructors of `MauiWebChromeClient` and `MauiWebViewNavigationDelegate` required the caller to pass in a concrete `Microsoft.Maui.Handlers.WebViewHandler` instance.

## New behavior

The constructors of `MauiWebChromeClient` and `MauiWebViewNavigationDelegate` now accept any implementation of the interface `Microsoft.Maui.Handlers.IWebViewHandler`.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The original constructors required the caller to pass in a concrete type that's not user-controllable and could throw at any point depending on the library author or order of imports. The new implementation just requires the base interface, which is something a developer can actually use.

## Recommended action

- If you've overridden the `WKUIDelegate` mapper for the iOS or Mac Catalyst `WebViewHandler`, multi-target `net6.0-ios` and `net7.0-ios` or `net6.0-maccatalyst` and `net7.0-maccatalyst`.
- If you've overridden the `WebChromeClient` mapper for the Android `WebViewHandler`, multi-target `net6.0-android` and `net7.0-android`.
- Otherwise, no action is necessary.

## Affected APIs

- `Microsoft.Maui.Platform.MauiWebChromeClient` constructor
- `Microsoft.Maui.Platform.MauiWebViewNavigationDelegate` constructor
