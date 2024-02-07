---
title: What's new in .NET 8
description: Learn about the new .NET features introduced in .NET 8.
titleSuffix: ""
ms.date: 11/14/2023
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 8

.NET 8 is the successor to [.NET 7](../dotnet-7.md). It will be [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release. You can [download .NET 8 here](https://dotnet.microsoft.com/download/dotnet).

## .NET runtime

The .NET 8 runtime includes improvements to performance, garbage collection, and the core and extension libraries. It also includes a new globalization mode for mobile apps and new source generators for COM interop and configuration binding. For more information, see [What's new in the .NET 8 runtime](runtime.md).

## .NET SDK

For information about what's new in the .NET SDK, containers, Native AOT, code analysis, and diagnostics, see [What's new in the SDK and containers for .NET 8](sdk-containers.md).

## .NET Aspire

.NET Aspire is an opinionated, cloud-ready stack for building observable, production ready, distributed applications.​ .NET Aspire is delivered through a collection of NuGet packages that handle specific cloud-native concerns, and is available in preview for .NET 8. For more information, see [.NET Aspire (Preview)](/dotnet/aspire).

## ASP.NET Core

ASP.NET Core includes improvements to Blazor, SignalR, minimal APIs, Native AOT, Kestrel and HTTP.sys servers, and authentication and authorization. For more information, see [What's new in ASP.NET Core 8.0](/aspnet/core/release-notes/aspnetcore-8.0).

## .NET MAUI

.NET MAUI includes new functionality for controls, gesture recognizers, Windows apps, navigation, and platform integration. It also includes some behavior changes and many performance enhancements. For more information, see [What's new in .NET MAUI for .NET 8](/dotnet/maui/whats-new/dotnet-8).

## EF Core

Entity Framework Core includes improvements to complex type objects, collections of primitive types, JSON column mapping, raw SQL queries, lazy loading, tracked-entity access, model building, math translations, and other features. It also includes a new `HierarchyId` type. For more information, see [What's New in EF Core 8](/ef/core/what-is-new/ef-core-8.0/whatsnew).

## Windows Forms

Windows Forms includes improvements to data binding, Visual Studio DPI, and high DPI. Button commands are also fully enabled now. For more information, see [What's new for .NET 8 (Windows Forms)](/dotnet/desktop/winforms/whats-new/net80).

## Windows Presentation Foundation

Windows Presentation Foundation (WPF) adds the ability to use [hardware acceleration](#hardware-acceleration) and a new [OpenFolderDialog](#openfolderdialog) control.

### Hardware acceleration

Previously, all WPF applications that were accessed remotely had to use software rendering, even if the system had hardware rendering capabilities. .NET 8 adds an option that lets you opt into hardware acceleration for Remote Desktop Protocol (RDP).

Hardware acceleration refers to the use of a computer's graphics processing unit (GPU) to speed up the rendering of graphics and visual effects in an application. This can result in improved performance and more seamless, responsive graphics. In contrast, software rendering relies solely on the computer's central processing unit (CPU) to render graphics, which can be slower and less effective.

To opt in, set the `Switch.System.Windows.Media.EnableHardwareAccelerationInRdp` configuration property to `true` in a *runtimeconfig.json* file. For more information, see [Hardware acceleration in RDP](../../runtime-config/wpf.md#hardware-acceleration-in-rdp).

### OpenFolderDialog

WPF includes a new dialog box control called `OpenFolderDialog`. This control lets app users browse and select folders. Previously, app developers relied on third-party software to achieve this functionality.

```csharp
var openFolderDialog = new OpenFolderDialog()
{
    Title = "Select folder to open ...",
    InitialDirectory = Environment.GetFolderPath(
        Environment.SpecialFolder.ProgramFiles)
};

string folderName = "";
if (openFolderDialog.ShowDialog())
{
    folderName = openFolderDialog.FolderName;
}
```

For more information, see [WPF File Dialog Improvements in .NET 8 (.NET blog)](https://devblogs.microsoft.com/dotnet/wpf-file-dialog-improvements-in-dotnet-8/).

## See also

- [Breaking changes in .NET 8](../../compatibility/8.0.md)

### .NET preview announcements

- [Announcing .NET 8](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8/)
- [Announcing .NET 8 RC 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc2/)
- [Announcing .NET 8 RC 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc1/)
- [Announcing .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-7/)
- [Announcing .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-6/)
- [Announcing .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-5/)
- [Announcing .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/)
- [Announcing .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-3/)
- [Announcing .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-2/)
- [Announcing .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-1/)

### ASP.NET Core preview announcements

- [ASP.NET Core in .NET 8](https://devblogs.microsoft.com/dotnet/announcing-asp-net-core-in-dotnet-8)
- [ASP.NET Core updates in .NET 8 RC 2](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-rc-2/)
- [ASP.NET Core updates in .NET 8 RC 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-rc-1/)
- [ASP.NET Core updates in .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-7/)
- [ASP.NET Core updates in .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-6/)
- [ASP.NET Core updates in .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-5/)
- [ASP.NET Core updates in .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/)
- [ASP.NET Core updates in .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-3/)
- [ASP.NET Core updates in .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-2/)
- [ASP.NET Core updates in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-1/)
