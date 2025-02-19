---
title: What's new in .NET 10
description: Learn about the new features introduced in .NET 10 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 02/20/2025
ms.topic: whats-new
---

# What's new in .NET 10

Learn about the new features in .NET 10 and find links to further documentation. This page has been updated for Preview 1.

## .NET runtime

- [Array interface method devirtualization](runtime.md#array-interface-method-devirtualization)
- [Stack allocation of arrays of value types](runtime.md#stack-allocation-of-arrays-of-value-types)
- [AVX10.2 support](runtime.md#avx102-support)

For more information, see [What's new in the .NET 10 runtime](runtime.md).

## .NET libraries

- [Finding certificates by thumbprints other than SHA-1](libraries.md#finding-certificates-by-thumbprints-other-than-sha-1)
- [Finding PEM-encoded data in ASCII/UTF-8](libraries.md#finding-pem-encoded-data-in-asciiutf-8)
- [New method overloads in ISOWeek for DateOnly type](libraries.md#new-method-overloads-in-isoweek-for-dateonly-type)
- [String normalization APIs to work with span of characters](libraries.md#string-normalization-apis-to-work-with-span-of-characters)
- [Numeric ordering for string comparison](libraries.md#numeric-ordering-for-string-comparison)
- [Adding TimeSpan.FromMilliseconds overload with a single parameter](libraries.md#adding-timespanfrommilliseconds-overload-with-a-single-parameter)
- [ZipArchive performance and memory improvements](libraries.md#ziparchive-performance-and-memory-improvements)
- [Additional TryAdd and TryGetValue overloads for OrderedDictionary<TKey, TValue>](libraries.md#additional-tryadd-and-trygetvalue-overloads-for-ordereddictionarytkey-tvalue)
- [Allow specifying ReferenceHandler in JsonSourceGenerationOptions](libraries.md#allow-specifying-referencehandler-in-jsonsourcegenerationoptions)
- [More left-handed matrix transformation methods](libraries.md#more-left-handed-matrix-transformation-methods)

For more information, see [What's new in the .NET 10 libraries](libraries.md).

## .NET SDK

- [Pruning of Framework-provided Package References](sdk.md#pruning-of-framework-provided-package-references)

For more information, see [What's new in the SDK for .NET 10](sdk.md).

## .NET Aspire

TODO - Add a brief overview of the new features in .NET Aspire.

## ASP.NET Core

- [OpenAPI 3.1 support](/aspnet/core/release-notes/aspnetcore-10.0#openapi-31-support)
- [Generate OpenAPI documents in YAML format](/aspnet/core/release-notes/aspnetcore-10.0?view=aspnetcore-9.0#openapi-in-yaml)
- [Response description on `ProducesResponseType`](/aspnet/core/release-notes/aspnetcore-10.0#response-description-on-producesresponsetype)
- [Detect if URL is local using `RedirectHttpResult.IsLocalUrl`](/aspnet/core/release-notes/aspnetcore-10.0#detect-if-url-is-local-using-redirecthttpresultislocalurl)
- [Improvements to integration testing of apps with top-level statements](/aspnet/core/release-notes/aspnetcore-10.0?view=aspnetcore-9.0#better-support-for-testing-apps-with-top-level-statements)
- [QuickGrid `RowClass` parameter](/aspnet/core/release-notes/aspnetcore-10.0#quickgrid-rowclass-parameter)
- [Blazor script as a static web asset](/aspnet/core/release-notes/aspnetcore-10.0?view=aspnetcore-9.0#blazor-script)
- [Route syntax highlighting for Blazor `RouteAttribute`](/aspnet/core/release-notes/aspnetcore-10.0#route-syntax-highlighting-for-blazor-routeattribute)

For more information, see [What's new in ASP.NET Core for .NET 10](/aspnet/core/release-notes/aspnetcore-10.0).

## .NET MAUI

TODO - Add a brief overview of the new features in .NET MAUI for .NET 10.

## EF Core

- [Support for the .NET 10 LeftJoin operator](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/efcore.md#support-for-the-net-10-leftjoin-operator)
- [ExecuteUpdateAsync now accepts a regular, non-expression lambda](/ef/core/what-is-new/ef-core-10.0/whatsnew#executeupdateasync-now-accepts-a-regular-non-expression-lambda)
- [Several small improvements](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/efcore.md#small-improvements)

For more information, see [What's new in EF Core for .NET 10](/ef/core/what-is-new/ef-core-10.0/whatsnew).

## C# 14

- [`nameof` in unbound generics](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/csharp.md#unbound-generic-support-for-nameof)
- [Implicit span conversions](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/csharp.md#implicit-span-conversions)
- [`field` backed properties](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/csharp.md#field-backed-properties)
- [Modifiers on simple lambda parameters](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/csharp.md#modifiers-on-simple-lambda-parameters)
- [Experimental feature - String literals in data section](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/csharp.md#preview-feature-string-literals-in-data-section)

For more information, see [What's new in C# 14](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/csharp.md).

## Windows Forms

- [Clipboard related serialization and deserialization changes](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/winforms.md#clipboard-related-serialization-and-deserialization-changes)
- [Obsoleted Clipboard APIs](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/winforms.md#obsoleted-clipboard-apis)
- [New Clipboard related APIs](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/winforms.md#new-clipboard-related-apis)

For more information, see [What's new in Windows Forms for .NET 10](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/winforms.md).

## See also

- [.NET 10 Preview 1 container image updates](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/containers.md)
- [F# updates in .NET 10 Preview 1](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/fsharp.md)
- [Visual Basic updates in .NET 10 Preview 1](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/visualbasic.md)