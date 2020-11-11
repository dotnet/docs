---
title: Runtime libraries overview
description: Learn what is included in the Runtime libraries section of the table of contents.
author: tdykstra
ms.date: 11/10/2020
ms.technology: dotnet-standard
---
# Runtime libraries overview

The [.NET runtime](../core/introduction.md#sdk-and-runtimes), which is installed on a machine for use by [framework-dependent apps](../core/introduction.md#deployment-models), has an expansive standard set of class libraries:

* The core set, included in the runtime and known as the [base class libraries (BCL)](glossary.md#bcl).
* The complete set, included in the runtime and known as the [runtime libraries](glossary.md#runtime) or [framework libraries](glossary.md#framework).
* Extensions to the runtime libraries, provided in NuGet packages.

These libraries provide implementations for many general and app-specific types, algorithms, and utility functionality.

## Base class libraries

The BCL provides the foundational types and utility functionality and is the base of all other .NET class libraries. An example is the <xref:System.String?displayProperty=nameWithType> class, which provides APIs for working with strings.

## Runtime libraries

Also known as the framework libraries, the runtime libraries build on the BCL to provide utility APIs for common tasks. An example is the [serialization libraries](serialization/index.md).

## Extensions to the runtime libraries

Some of the runtime libraries are provided in NuGet packages rather than built-in to the runtime that is installed for framework-dependent apps. An example is the [.NET Logging API](../core/extensions/logging.md).

## See also

* [Introduction to .NET](../core/introduction.md)
* [Install .NET SDK or runtime](../core/install/index.yml)
* [Select the installed .NET SDK or runtime version to use](../core/versions/selection.md)
* [Publish framework-dependent apps](../core/deploying/index.md#publish-framework-dependent)
