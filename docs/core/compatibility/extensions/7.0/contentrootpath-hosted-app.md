---
title: "Breaking change: ContentRootPath for apps launched by Windows Shell"
description: Learn about the .NET 7 breaking change in .NET extensions where the 'ContentRootPath' property no longer defaults to the current directory for apps launched by Windows Shell or services.exe.
ms.date: 06/22/2022
ms.topic: concept-article
---
# ContentRootPath for apps launched by Windows Shell

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath?displayProperty=nameWithType> property represents the default directory where *appsettings.json* and other content files are loaded in a hosted application, including ASP.NET apps. This property's value defaults to <xref:System.Environment.CurrentDirectory?displayProperty=nameWithType>, which is the current working directory of the application. This behavior allows the same app to be executed under different working directories and use the content from each directory.

When a Windows process (either application or service) is launched without specifying a working directory, the working directory of the process that [created it](/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessa) is used. The working directory of Windows Shell or *services.exe* is *%windir%\system32* (or the `System` special folder). When either of those processes launches a hosted app, the `ContentRootPath` property is set to *%windir%\system32*.

This behavior is confusing and causes hosted applications to fail, because the application tries to load files from the *%windir%\system32* directory, but it doesn't exist. For example, the *appsettings.json* file is not found at run time and the settings aren't applied.

Starting with .NET 7, when a hosted application is launched with the current directory set to the `System` special folder, it defaults the `ContentRootPath` property to <xref:System.AppContext.BaseDirectory?displayProperty=nameWithType>.

## Version introduced

.NET 7

## Previous behavior

<xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A?displayProperty=nameWithType> defaulted the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath> property to <xref:System.Environment.CurrentDirectory?displayProperty=nameWithType> regardless of the value of the current directory.

## New behavior

<xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A?displayProperty=nameWithType> no longer defaults the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath> property to the current directory if it's the `System` special folder on Windows. Instead, the base directory of the application is used.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

App developers weren't expecting <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath> to be *C:\Windows\system32* when their application was launched by Windows in certain cases (for example, when the app was packaged as an MSIX or started from the Start Menu). In these cases, it's better to default the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath> property to the base directory of the application.

## Recommended action

If you want to use the previous behavior, you can set the `ContentRootPath` property explicitly when creating the <xref:Microsoft.Extensions.Hosting.IHostBuilder>:

```csharp
Host
    .CreateDefaultBuilder()
    .UseContentRoot(Environment.CurrentDirectory)
    ....
```

## Affected APIs

- <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A?displayProperty=fullName>
