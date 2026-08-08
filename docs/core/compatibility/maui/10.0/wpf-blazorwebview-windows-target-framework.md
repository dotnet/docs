---
title: "Breaking change: WPF BlazorWebView requires a Windows 10 target framework"
description: "Learn about the .NET 10 breaking change where WPF BlazorWebView requires a target framework that specifies Windows 10 or later."
ms.date: 08/08/2026
ai-usage: ai-assisted
---

# WPF BlazorWebView requires a Windows 10 target framework

WPF Blazor Hybrid apps that use `BlazorWebView` must now target Windows 10 or later.

## Version introduced

.NET 10 RC 2

## Previous behavior

Previously, WPF Blazor Hybrid apps could target Windows without a platform version. For example, a project could use the `net9.0-windows` target framework.

In addition, the `BlazorWebView.WebView` and `BlazorWebViewInitializedEventArgs.WebView` properties returned a `Microsoft.Web.WebView2.Wpf.WebView2` control.

## New behavior

Starting in .NET 10 RC 2, WPF `BlazorWebView` uses `Microsoft.Web.WebView2.Wpf.WebView2CompositionControl`. The `BlazorWebView.WebView` and `BlazorWebViewInitializedEventArgs.WebView` properties now return this control type.

Because `WebView2CompositionControl` requires Windows 10 or later, specify Windows 10 build 17763 or a later version in the target framework. For example:

```xml
<TargetFramework>net10.0-windows10.0.17763.0</TargetFramework>
```

A target framework such as `net10.0-windows` doesn't meet this requirement because it doesn't specify Windows 10 or later.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

`WebView2CompositionControl` avoids the WPF airspace limitation and allows WPF elements to appear above WebView2 content.

## Recommended action

Update the target framework to specify Windows 10 build 17763 or a later version, as shown in the [New behavior](#new-behavior) section.

If your source code explicitly declares, casts, or checks for `Microsoft.Web.WebView2.Wpf.WebView2`, update it to use `Microsoft.Web.WebView2.Wpf.WebView2CompositionControl`. Where appropriate, use `Microsoft.Web.WebView2.Wpf.IWebView2` to support both control types.

## Affected APIs

- <xref:Microsoft.AspNetCore.Components.WebView.Wpf.BlazorWebView.WebView?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Components.WebView.BlazorWebViewInitializedEventArgs.WebView?displayProperty=fullName>
