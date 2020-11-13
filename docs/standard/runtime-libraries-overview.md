---
title: Runtime libraries overview
description: Learn what is included in the Runtime libraries section of the table of contents.
author: tdykstra
ms.date: 11/12/2020
ms.technology: dotnet-standard
---
# Runtime libraries overview

The [.NET runtime](../core/introduction.md#sdk-and-runtimes), which is installed on a machine for use by [framework-dependent apps](../core/introduction.md#deployment-models), has an expansive standard set of class libraries, known as [runtime libraries](glossary.md#runtime), [framework libraries](glossary.md#framework-libraries), or [base class libraries (BCL)](glossary.md#bcl). In addition, there are extensions to the runtime libraries, provided in NuGet packages.

These libraries provide implementations for many general and app-specific types, algorithms, and utility functionality.

## Runtime libraries

These libraries provide the foundational types and utility functionality and are the base of all other .NET class libraries. An example is the <xref:System.String?displayProperty=nameWithType> class, which provides APIs for working with strings. Another example is the [serialization libraries](serialization/index.md).

## Extensions to the runtime libraries

Some libraries are provided in NuGet packages rather than built-in to the runtime. An example is the [.NET Logging API](../core/extensions/logging.md). Documentation on how to use these libraries is included in this **Runtime libraries** section of the table of contents.

## See also

* [Introduction to .NET](../core/introduction.md)
* [Install .NET SDK or runtime](../core/install/index.yml)
* [Select the installed .NET SDK or runtime version to use](../core/versions/selection.md)
* [Publish framework-dependent apps](../core/deploying/index.md#publish-framework-dependent)
