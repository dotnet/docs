---
title: SYSLIB0059 warning - SystemEvents.EventsThreadShutdown callbacks aren't run before the process exits
description: Learn about the obsoletion of SystemEvents.EventsThreadShutdown that generates compile-time warning SYSLIB0059.
ms.date: 08/01/2024
f1_keywords:
  - SYSLIB0059
---
# SYSLIB0059: SystemEvents.EventsThreadShutdown callbacks aren't run before the process exits

The <xref:Microsoft.Win32.SystemEvents.EventsThreadShutdown?displayProperty=nameWithType> event is obsolete, starting in .NET 10. Referencing this event in code generates warning `SYSLIB0059` at compile time.

## Reason for obsoletion

The previous shutdown handling in <xref:Microsoft.Win32.SystemEvents> could block the finalizer thread during app shutdown. To avoid blocking the finalizer thread, <xref:Microsoft.Win32.SystemEvents> no longer has shutdown handling, which means that the <xref:Microsoft.Win32.SystemEvents.EventsThreadShutdown?displayProperty=nameWithType> event is no longer called. To surface this behavior change, the event was marked obsolete.

## Workaround

Use <xref:System.AppDomain.ProcessExit?displayProperty=nameWithType> instead.

## Suppress a warning

If you must use the obsolete API, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0059

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0059
```

To suppress all the `SYSLIB0059` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0059</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
