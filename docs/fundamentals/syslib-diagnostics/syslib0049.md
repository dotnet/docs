---
title: SYSLIB0049 warning -
description: Learn about the obsoletion of the RSA.EncryptValue and RSA.DecryptValue methods that generates compile-time warning SYSLIB0049.
ms.date: 10/09/2023
---
# SYSLIB0049

The <xref:System.Text.Json.JsonSerializerOptions.AddContext%60%601?displayProperty=nameWithType> method is obsolete, starting in .NET 8. Calling it in code generates warning `SYSLIB0049` at compile time.

The <xref:System.Text.Json.JsonSerializerOptions.AddContext%60%601?displayProperty=nameWithType> method was introduced in .NET 6 as a means to associate <xref:System.Text.Json.JsonSerializerOptions> instances with a specified <xref:System.Text.Json.Serialization.JsonSerializerContext> type. This method was largely superseded in .NET 7 with the introduction of [contract customization](../../standard/serialization/system-text-json/custom-contracts.md) and the <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver> property.

## Workaround

Use one of the following properties instead:

- <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver> - This property lets you add one or multiple resolvers all at once.
- <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> - This property lets you prepend or append resolvers at multiple call sites. It also lets you introspect the chain or remove components from it.

For more information, see [Combine source generators](../../standard/serialization/system-text-json/source-generation.md#combine-source-generators).

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0049

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0049
```

To suppress all the `SYSLIB0049` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0049</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
