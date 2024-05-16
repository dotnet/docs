---
title: SYSLIB0032 warning - Recovery from corrupted process state exceptions is not supported
description: Learn about the obsoletion of HandleProcessCorruptedStateExceptionsAttribute that generates compile-time warning SYSLIB0032.
ms.date: 09/07/2021
f1_keywords:
  - syslib0032
---
# SYSLIB0032: Recovery from corrupted process state exceptions is not supported

Recovery from corrupted process state exceptions is not supported, and the <xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute> type is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0032` at compile time.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0032

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0032
```

To suppress all the `SYSLIB0032` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0032</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
