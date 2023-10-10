---
title: "NETSDK1202: workload is out of support and will not receive security updates in the future"
description: Learn about .NET SDK warning NETSDK1202, which occurs when a project depends on an optional workload that is out of support.
ms.topic: error-reference
ms.date: 10/10/2023
f1_keywords:
- NETSDK1202
---
# NETSDK1202: workload is out of support and will not receive security updates in the future

NETSDK1202 indicates your project is using an optional workload that is out of
support. An example of this would be using `net6.0` target frameworks in a .NET
MAUI application:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net6.0-android;net6.0-ios;net6.0-maccatalyst;net6.0-windows10.0.19041.0</TargetFrameworks>
```

The best solution would be to update to a newer, supported `TargetFramework`
such as `net7.0` or `net8.0`. Note that using a .NET 8 SDK and .NET 8 MAUI
optional workload does not support building `net6.0` applications in any form,
and so this is a hard requirement when using the latest .NET SDK.

You can continue building `net6.0` .NET MAUI applications with a .NET 6 or .NET
7 SDK in an unsupported fashion. Additionally, you can opt out of the warning in
a project with the setting:

```xml
<PropertyGroup>
  <CheckEolWorkloads>false</CheckEolWorkloads>
</PropertyGroup>
```

See the [.NET MAUI support policy](https://aka.ms/maui-support-policy) for
details about the .NET MAUI product lifecycle.
