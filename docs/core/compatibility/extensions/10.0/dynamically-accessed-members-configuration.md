---
title: "Breaking change: DynamicallyAccessedMembers annotation removed from trim-unsafe configuration APIs"
description: "Learn about the breaking change in .NET 10 where DynamicallyAccessedMembers annotations were removed from trim-unsafe Microsoft.Extensions.Configuration APIs."
ms.date: 07/22/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47433
---

# DynamicallyAccessedMembers annotation removed from trim-unsafe configuration APIs

[Certain APIs](#affected-apis) related to <xref:Microsoft.Extensions.Configuration> that were marked as <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute> were also annotated to preserve at least some of the necessary members when trimming. This made the API partially work when trimming, while still generating trimming warnings. The annotations are now removed completely. Users are encouraged to migrate to the source generator that works reliably with trimming.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously, the [affected APIs](#affected-apis) worked with some limited use cases while generating trimming warnings at publish time. These APIs were annotated to preserve at least some of the necessary members when trimming, making the API partially functional in trimmed scenarios.

## New behavior

Starting in .NET 10, the [affected APIs](#affected-apis) now work with even more limited use cases while still generating trimming warnings at publish time.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The annotations were removed as part of an effort to remove uses of <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType> from the product.

## Recommended action

Use the binding configuration source generator, which works reliably with trimming and provides a trim-safe alternative to these APIs.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get(Microsoft.Extensions.Configuration.IConfiguration,System.Type,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue(Microsoft.Extensions.Configuration.IConfiguration,System.Type,System.String)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue(Microsoft.Extensions.Configuration.IConfiguration,System.Type,System.String,System.Object)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue``1(Microsoft.Extensions.Configuration.IConfiguration,System.String)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue``1(Microsoft.Extensions.Configuration.IConfiguration,System.String,``0)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get``1(Microsoft.Extensions.Configuration.IConfiguration)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get``1(Microsoft.Extensions.Configuration.IConfiguration,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.Configuration.LoggerProviderOptions.RegisterProviderOptions``2(Microsoft.Extensions.DependencyInjection.IServiceCollection)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsoleFormatter``2(Microsoft.Extensions.Logging.ILoggingBuilder)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsoleFormatter``2(Microsoft.Extensions.Logging.ILoggingBuilder,System.Action{``1})?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderConfigurationExtensions.BindConfiguration``1(Microsoft.Extensions.Options.OptionsBuilder{``0},System.String,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderConfigurationExtensions.Bind``1(Microsoft.Extensions.Options.OptionsBuilder{``0},Microsoft.Extensions.Configuration.IConfiguration)?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderConfigurationExtensions.Bind``1(Microsoft.Extensions.Options.OptionsBuilder{``0},Microsoft.Extensions.Configuration.IConfiguration,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Options.ConfigureFromConfigurationOptions`1?displayProperty=fullName>
- <xref:Microsoft.Extensions.Options.NamedConfigureFromConfigurationOptions`1?displayProperty=fullName>
