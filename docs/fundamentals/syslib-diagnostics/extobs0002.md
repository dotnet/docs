---
title: EXTOBS0002 warning
description: Learn about the obsoletions that generate compile-time warning EXTOBS0002.
ms.date: 11/12/2025
f1_keywords:
  - extobs0002
ai-usage: ai-assisted
---
# EXTOBS0002: AddServiceLogEnricher is obsolete

The `AddServiceLogEnricher` extension methods have been marked as obsolete. These methods had incorrect naming that didn't accurately reflect their functionality. The methods enrich application logs, not service logs, so they have been replaced with correctly named `AddApplicationLogEnricher` methods.

The following APIs are marked obsolete. Use of these APIs generates warning `EXTOBS0002` at compile time.

- <xref:Microsoft.Extensions.DependencyInjection.ApplicationEnricherServiceCollectionExtensions.AddServiceLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection)?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.DependencyInjection.ApplicationEnricherServiceCollectionExtensions.AddServiceLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfigurationSection)?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.DependencyInjection.ApplicationEnricherServiceCollectionExtensions.AddServiceLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.Extensions.Telemetry.Enrichment.ApplicationLogEnricherOptions})?displayProperty=nameWithType>

## Workarounds

Replace calls to `AddServiceLogEnricher` with the equivalent `AddApplicationLogEnricher` methods. The functionality remains the same, only the method names have been corrected to accurately reflect that they enrich application logs.

### Migration example

**Old approach using AddServiceLogEnricher:**

```csharp
services.AddServiceLogEnricher();

// Or with configuration:
services.AddServiceLogEnricher(configuration.GetSection("ambientmetadata:application"));

// Or with options:
services.AddServiceLogEnricher(options =>
{
    options.ApplicationName = "MyApp";
});
```

**New approach using AddApplicationLogEnricher:**

```csharp
services.AddApplicationLogEnricher();

// Or with configuration:
services.AddApplicationLogEnricher(configuration.GetSection("ambientmetadata:application"));

// Or with options:
services.AddApplicationLogEnricher(options =>
{
    options.ApplicationName = "MyApp";
});
```

For more information, see [Application log enricher](../../../core/enrichment/application-log-enricher.md).

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable EXTOBS0002

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore EXTOBS0002
```

To suppress all the `EXTOBS0002` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);EXTOBS0002</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [Application log enricher](../../../core/enrichment/application-log-enricher.md)
