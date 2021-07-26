---
description: "Learn more about: UriTemplate Table Dispatcher Sample"
title: "UriTemplate Table Dispatcher Sample"
ms.date: "03/30/2017"
ms.assetid: 3b32975d-ba90-4c5c-83bc-2fbb48f11c0c
---
# UriTemplate Table Dispatcher Sample

The [UriTemplateDispatcher sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates a basic dispatching engine built using `UriTemplateTable`, a common usage scenario for the `UriTemplateTable` class. The <xref:System.UriTemplateTable> class provides a dictionary-like associative table structure for working with a set of <xref:System.UriTemplate> instances.

This sample demonstrates the following key concepts for the `UriTemplateTable` class:

- Associating delegates with `UriTemplates` in a `UriTemplateTable`.

- Using <xref:System.UriTemplateTable.MatchSingle%2A> to obtain the correct handler delegate for a particular URI.

- Invoking the handler delegate to process the request.

### To set up, build, and run the sample

1. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

2. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- [UriTemplate Table](uritemplate-table-sample.md)
- [UriTemplate](uritemplate-sample.md)
