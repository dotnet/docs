---
title: SYSLIB0063 warning - NamedPipeClientStream constructor with isConnected is obsolete
description: Learn about the obsoletion of the NamedPipeClientStream constructor that includes an isConnected argument. Use of this constructor generates compile-time warning SYSLIB0063.
ms.date: 07/06/2026
ai-usage: ai-assisted
f1_keywords:
  - SYSLIB0063
---

# SYSLIB0063: NamedPipeClientStream constructor with isConnected is obsolete

Starting in .NET 11, the <xref:System.IO.Pipes.NamedPipeClientStream.%23ctor(System.IO.Pipes.PipeDirection,System.Boolean,System.Boolean,Microsoft.Win32.SafeHandles.SafePipeHandle)?displayProperty=nameWithType> constructor is obsolete. Calling this constructor in code generates warning `SYSLIB0063` at compile time.

## Reason for obsoletion

The `isConnected` argument on this constructor has no effect. To avoid confusion, use the constructor that omits this argument.

## Workaround

Use <xref:System.IO.Pipes.NamedPipeClientStream.%23ctor(System.IO.Pipes.PipeDirection,System.Boolean,Microsoft.Win32.SafeHandles.SafePipeHandle)?displayProperty=nameWithType> instead.

## Suppress a warning

If you must use the obsolete API, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0063

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0063
```

To suppress all the `SYSLIB0063` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0063</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
