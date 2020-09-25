---
title: Configuration providers in .NET
description: Learn how the Configuration provider API is used to configure .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 09/24/2020
---

# Logging providers in .NET

Logging providers persist logs, except for the `Console` provider which only displays logs as standard output. For example, the Azure Application Insights provider stores logs in Azure Application Insights. Multiple providers can be enabled.

The default .NET Worker app templates:

- Use the [Generic Host](generic-host.md).
- Call <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A>, which adds the following logging providers:
  - [Console](#console)
  - [Debug](#debug)
  - [EventSource](#event-source)
  - [EventLog](#welog): Windows only

[!code-csharp[](index/samples/3.x/TodoApiDTO/Program.cs?name=snippet_TemplateCode&highlight=9)]

The preceding code shows the `Program` class created with the .NET Worker app templates. The next several sections provide samples based on the .NET Worker app templates, which use the Generic Host. [Non-host console apps](#non-host-console-app) are discussed later in this article.

To override the default set of logging providers added by `Host.CreateDefaultBuilder`, call `ClearProviders` and add the required logging providers. For example, the following code:

- Calls <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> to remove all the <xref:Microsoft.Extensions.Logging.ILoggerProvider> instances from the builder.
- Adds the [Console](#console) logging provider.

[!code-csharp[](index/samples/3.x/TodoApiDTO/Program.cs?name=snippet_AddProvider&highlight=5-6)]

For additional providers, see:

- [Built-in logging providers](#built-in-logging-providers).
- [Third-party logging providers](#third-party-logging-providers).

## See also
