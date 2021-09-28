---
title: Runtime libraries overview
description: Learn what is included in the Runtime libraries section of the table of contents.
author: tdykstra
ms.date: 08/24/2021
---
# Runtime libraries overview

The [.NET runtime](../core/introduction.md#sdk-and-runtimes), which is installed on a machine for use by [framework-dependent apps](../core/introduction.md#deployment-models), has an expansive standard set of class libraries, known as [runtime libraries](glossary.md#runtime), [framework libraries](glossary.md#framework-libraries), or the [base class library (BCL)](glossary.md#bcl). In addition, there are extensions to the runtime libraries, provided in NuGet packages.

These libraries provide implementations for many general and app-specific types, algorithms, and utility functionality.

## Runtime libraries

These libraries provide the foundational types and utility functionality and are the base of all other .NET class libraries. An example is the <xref:System.String?displayProperty=nameWithType> class, which provides APIs for working with strings. Another example is the [serialization libraries](serialization/index.md).

## Extensions to the runtime libraries

Some libraries are provided in NuGet packages rather than included in the runtime's [shared framework](glossary.md#shared-framework). For example:

| Conceptual content                                                 | NuGet package                                         |
|--------------------------------------------------------------------|-------------------------------------------------------|
| [Configuration](../core/extensions/configuration.md)               | [`Microsoft.Extensions.Configuration`][configuration] |
| [Dependency injection](../core/extensions/dependency-injection.md) | [`Microsoft.Extensions.DependencyInjection`][di]      |
| [File globbing](../core/extensions/file-globbing.md)               | [`Microsoft.Extensions.FileSystemGlobbing`][fsg]      |
| [Generic Host](../core/extensions/generic-host.md)                 | [`Microsoft.Extensions.Hosting`][host]                |
| [HTTP](../core/extensions/http-client.md)                          | [`Microsoft.Extensions.Http`][http]                   |
| [Localization](../core/extensions/localization.md)                 | [`Microsoft.Extensions.Localization`][loc]            |
| [Logging](../core/extensions/logging.md)                           | [`Microsoft.Extensions.Logging`][log]                 |

[configuration]: https://www.nuget.org/packages/Microsoft.Extensions.Configuration
[di]: https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection
[fsg]: https://www.nuget.org/packages/Microsoft.Extensions.FileSystemGlobbing
[host]: https://www.nuget.org/packages/Microsoft.Extensions.Hosting
[http]: https://www.nuget.org/packages/Microsoft.Extensions.Http
[loc]: https://www.nuget.org/packages/Microsoft.Extensions.Localization
[log]: https://www.nuget.org/packages/Microsoft.Extensions.Logging

## See also

* [Introduction to .NET](../core/introduction.md)
* [Install .NET SDK or runtime](../core/install/index.yml)
* [Select the installed .NET SDK or runtime version to use](../core/versions/selection.md)
* [Publish framework-dependent apps](../core/deploying/index.md#publish-framework-dependent)
