---
title: SYSLIB0014 warning
description: Learn about the System.Net obsoletions that generate compile-time warning SYSLIB0014.
ms.date: 04/24/2021
---
# SYSLIB0014: WebRequest, HttpWebRequest, ServicePoint, WebClient are obsolete

The following APIs are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0014` at compile time.

- <xref:System.Net.WebRequest.%23ctor>
- <xref:System.Net.WebRequest.Create%2A?displayProperty=fullName>
- <xref:System.Net.WebRequest.CreateHttp%2A?displayProperty=fullName>
- <xref:System.Net.WebRequest.CreateDefault(System.Uri)?displayProperty=fullName>
- <xref:System.Net.HttpWebRequest.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)>
- <xref:System.Net.ServicePointManager.FindServicePoint%2A?displayProperty=fullName>
- <xref:System.Net.WebClient.%23ctor>

## Workarounds

Use <xref:System.Net.Http.HttpClient> instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0014

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0014
```

To suppress all the `SYSLIB0014` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0014</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [WebRequest, WebClient, and ServicePoint are obsolete](../../core/compatibility/networking/6.0/webrequest-deprecated.md)
