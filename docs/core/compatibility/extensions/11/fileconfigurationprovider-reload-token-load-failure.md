---
title: "Breaking change: FileConfigurationProvider doesn't raise reload token after ignored load failure"
description: "Learn about the breaking change in .NET 11 where FileConfigurationProvider doesn't raise its reload token after an ignored load failure."
ms.date: 08/05/2026
ai-usage: ai-assisted
---

# FileConfigurationProvider doesn't raise reload token after ignored load failure

<xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> no longer calls `OnReload` or fires its reload token after <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider.Load> fails and its <xref:Microsoft.Extensions.Configuration.FileConfigurationSource.OnLoadException> callback ignores the exception.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, after `Load` failed and the `OnLoadException` callback set <xref:Microsoft.Extensions.Configuration.FileLoadExceptionContext.Ignore> to `true`, <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> called `OnReload`. The reload token returned by <xref:Microsoft.Extensions.Configuration.IConfiguration.GetReloadToken> fired even though the provider didn't load data.

## New behavior

Starting in .NET 11, <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> doesn't call `OnReload` after `Load` fails and the `OnLoadException` callback sets <xref:Microsoft.Extensions.Configuration.FileLoadExceptionContext.Ignore> to `true`. The reload token doesn't fire because the provider didn't load data.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To avoid a notification when no data changes, <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> calls `OnReload` only after it loads data. This behavior resulted from a control-flow fix in [dotnet/runtime#126093](https://github.com/dotnet/runtime/pull/126093).

## Recommended action

Don't depend on the reload token when the provider doesn't load data. If your application must run code after an ignored load failure, call that code from your `OnLoadException` callback.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider.Load?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.Load(System.IO.Stream)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.Load(System.IO.Stream)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.Load(System.IO.Stream)?displayProperty=fullName>
