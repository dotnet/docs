---
description: "Learn more about: UriTemplate Table Sample"
title: "UriTemplate Table Sample"
ms.date: "03/30/2017"
ms.assetid: 5dd1d38f-1989-4c64-820d-821f5a02216a
---
# UriTemplate Table Sample

The <xref:System.UriTemplateTable> class provides a dictionary-like associative table structure for working with a set of `UriTemplate` instances. Specific Uniform Resource Identifiers (URIs) can be matched efficiently against all templates in the table, and data associated with the matched template can be retrieved.

The [UriTemplateTable sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the following key concepts related to the `UriTemplateTable` class:

- Syntax for instantiating a `UriTemplateTable`.

- Populating a `UriTemplateTable` with a set of key/value pairs.

- Matching a candidate URI against the table using <xref:System.UriTemplateTable.MatchSingle%2A>.

### To set up, build, and run the sample

1. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

2. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- [UriTemplate Table Dispatcher](uritemplate-table-dispatcher-sample.md)
- [UriTemplate](uritemplate-sample.md)
