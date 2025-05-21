---
title: Runtime libraries overview
description: Learn what is included in the Runtime libraries section of the table of contents.
ms.date: 05/30/2024
ms.topic: concept-article
---
# Runtime libraries overview

The [.NET runtime](../core/introduction.md) has an expansive standard set of class libraries, known as [runtime libraries](glossary.md#runtime), [framework libraries](glossary.md#framework-libraries), or the [base class library (BCL)](glossary.md#bcl). In addition, there are extensions to the runtime libraries, which are provided in NuGet packages.

These libraries provide implementations for many general and app-specific types, algorithms, and utility functionality.

## Runtime libraries

The runtime libraries provide the foundational types and utility functionality and are the base of all other .NET class libraries. An example is the <xref:System.String?displayProperty=nameWithType> class, which provides APIs for working with strings. Another example is the [serialization libraries](serialization/index.md).

## Extensions to the runtime libraries

Some libraries are provided in NuGet packages rather than as part of the runtime's [shared framework](glossary.md#shared-framework). These libraries are often made available to apps that target downlevel .NET versions, such as .NET Framework, as well.

The following table shows some examples of package-provided libraries.

| NuGet package                                         | Conceptual content                                                 |
|-------------------------------------------------------|--------------------------------------------------------------------|
| [`Microsoft.Extensions.Configuration`][configuration] | [Configuration](../core/extensions/configuration.md)               |
| [`Microsoft.Extensions.DependencyInjection`][di]      | [Dependency injection](../core/extensions/dependency-injection.md) |
| [`Microsoft.Extensions.FileSystemGlobbing`][fsg]      | [File globbing](../core/extensions/file-globbing.md)               |
| [`Microsoft.Extensions.Hosting`][host]                | [Generic Host](../core/extensions/generic-host.md)                 |
| [`Microsoft.Extensions.Http`][http]                   | [HTTP](../core/extensions/httpclient-factory.md)                   |
| [`Microsoft.Extensions.Localization`][loc]            | [Localization](../core/extensions/localization.md)                 |
| [`Microsoft.Extensions.Logging`][log]                 | [Logging](../core/extensions/logging.md)                           |

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
