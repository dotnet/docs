---
title: What's new in .NET 6
description: Learn about the new features introduced in .NET 6.
ms.date: 11/03/2021
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 6

.NET 6 delivers the final parts of the .NET unification plan that started with [.NET 5](dotnet-5.md). .NET 6 unifies the SDK, base libraries, and runtime across mobile, desktop, IoT, and cloud apps. In addition to this unification, the .NET 6 ecosystem offers:

- **Simplified development**: Getting started is easy. New language features in [C# 10](../../csharp/whats-new/csharp-10.md) reduce the amount of code you need to write. And investments in the web stack and minimal APIs make it easy to quickly write smaller, faster microservices.

- **Better performance**: .NET 6 is the fastest full stack web framework, which lowers compute costs if you're running in the cloud.

- **Ultimate productivity**: .NET 6 and [Visual Studio 2022](/visualstudio/releases/2022/release-notes) provide hot reload, new git tooling, intelligent code editing experiences, robust diagnostics and testing tools, and better team collaboration.

.NET 6 will be [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release.

For features that are noted as being in *preview*, this means that they are disabled by default. They are also not supported for use in production and may be removed in a future version. The new <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute> is used to annotate preview APIs, and a corresponding analyzer alerts you if you're using these preview APIs.

## Performance

.NET 6 includes numerous performance improvements. This section lists some of the improvements. For detailed information, see the [Performance improvements in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/) blog post.

### FileStream

The <xref:System.IO.FileStream?displayProperty=fullName> type has been rewritten for .NET 6 to provide better performance and reliability on Windows. Now, <xref:System.IO.FileStream> never blocks when created for asynchronous I/O on Windows. For more information, see the [File IO improvements in .NET 6](https://devblogs.microsoft.com/dotnet/file-io-improvements-in-dotnet-6/) blog post.

### Profile-guided optimization

Profile-guided optimization (PGO) is where the JIT compiler generates optimized code in terms of the types and code paths that are most frequently used. .NET 6 introduces *dynamic* PGO. Dynamic PGO works hand-in-hand with tiered compilation to further optimize code based on additional instrumentation that's put in place during tier 0. Dynamic PGO is disabled by default, but you can enable it with the `DOTNET_TieredPGO` [environment variable](../run-time-config/compilation.md#profile-guided-optimization). For more information, see [JIT performance improvements](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#jit).

### Crossgen2

.NET 6 introduces Crossgen2, the successor to Crossgen, which has been removed. Crossgen and Crossgen2 are tools that provide ahead-of-time (AOT) compilation to improve the startup time of an app. Crossgen2 is written in C# instead of C++, and can perform analysis and optimization that weren't possible with the previous version. For more information, see [Conversation about Crossgen2](https://devblogs.microsoft.com/dotnet/conversation-about-crossgen2/).

## Arm64 support

The .NET 6 release includes support for macOS Arm64 (or "Apple Silicon") and Windows Arm64 operating systems, for both native Arm64 execution and x64 emulation. In addition, the x64 and Arm64 .NET installers now install side-by-side. For more information, see [.NET Support for macOS 11 and Windows 11 for Arm64 and x64](https://github.com/dotnet/sdk/issues/22380).

## Hot reload

*Hot reload* is a feature that lets you modify your app's source code and instantly apply those changes to your running app. The feature's purpose is to increase your productivity by avoiding app restarts between edits. Hot reload is available in Visual Studio 2022, through the **Apply code changes** button, and through the `dotnet watch` command-line tool. Hot reload works with most types of .NET apps, and for C#, Visual Basic, and C++ source code. For more information, see the [Hot reload blog post](https://devblogs.microsoft.com/dotnet/update-on-net-hot-reload-progress-and-visual-studio-2022-highlights/).

## .NET MAUI

.NET Multi-platform App UI (.NET MAUI) is still in *preview*, with a release candidate coming in the first quarter of 2022, and general availability (GA) in the second quarter of 2022. .NET MAUI makes it possible to build native client apps for Windows, macOS, iOS, and Android with a single codebase. For more information, see [Update on .NET Multi-platform App UI](https://devblogs.microsoft.com/dotnet/update-on-dotnet-maui/).

## C# 10 and templates

C# 10 includes innovations such as `global using` directives, file-scoped namespace declarations, and record structs. For more information, see [What's new in C# 10](../../csharp/whats-new/csharp-10.md).

In concert with that work, the .NET SDK project templates for C# have been modernized to use some of the new language features:

- `async main` method
- Top-level statements
- Target-typed new expressions
- `global using` directives
- File-scoped namespaces
- Nullable reference types

By adding these new language features to the project templates, new code starts with the features enabled. However, existing code isn't affected when you upgrade to .NET 6. For more information about these template changes, see [.NET SDK: C# project templates modernized](https://devblogs.microsoft.com/dotnet/announcing-net-6-release-candidate-2/#net-sdk-c-project-templates-modernized).

## Visual Basic and F#

Visual Basic has improvements in the Visual Studio experience and Windows Forms project startup.

F# 6 adds several improvements to the F# language and F# Interactive. For more information, see [What's new in F# 6](../../fsharp/whats-new/fsharp-6.md).

## SDK Workloads

To keep the size of the .NET SDK smaller, some components have been placed in new, optional *SDK workloads*, which you install on top of the .NET SDK. These components include .NET MAUI, Android, iOS, and WebAssembly. SDK workloads are the foundation for the unification of .NET and enable support for more application types.

In addition, new `dotnet workload` commands were added for better discovery, acquisition, and management:

| Command | Description |
| - | - |
| [dotnet workload search](../tools/dotnet-workload-search.md) | Searches for available workloads. |
| [dotnet workload install](../tools/dotnet-workload-install.md) | Installs a specified workload. |
| [dotnet workload uninstall](../tools/dotnet-workload-uninstall.md) | Removes a specified workload. |
| [dotnet workload update](../tools/dotnet-workload-update.md) | Updates installed workloads. |
| [dotnet workload repair](../tools/dotnet-workload-repair.md) | Reinstalls all installed workloads to repair a broken installation. |
| [dotnet workload list](../tools/dotnet-workload-list.md) | Lists installed workloads. |

For more information, see [Optional SDK workloads](https://github.com/dotnet/designs/blob/main/accepted/2020/workloads/workloads.md).

## System.Text.Json APIs

Many improvements have been made in <xref:System.Text.Json?displayProperty=fullName> in .NET 6, such that it is now an "industrial strength" serialization solution.

### Writeable DOM

A new, writeable document object model (DOM) has been added, which improves the pre-existing read-only DOM. The new API provides a lightweight serialization alternative for cases when use of plain old CLR object (POCO) types isn't possible. It also allows you to efficiently navigate to a subsection of a large JSON tree and read an array or deserialize a POCO from that subsection. The following new types have been added to support the writeable DOM:

- <xref:System.Text.Json.Nodes.JsonNode>
- <xref:System.Text.Json.Nodes.JsonArray>
- <xref:System.Text.Json.Nodes.JsonObject>
- <xref:System.Text.Json.Nodes.JsonValue>

For more information, see [Writeable DOM design](https://github.com/dotnet/designs/blob/main/accepted/2020/serializer/WriteableDomAndDynamic.md).

### IAsyncEnumerable serialization

<xref:System.Text.Json?displayProperty=fullName> now supports serialization and deserialization with <xref:System.Collections.Generic.IAsyncEnumerable%601> instances. Asynchronous serialization methods enumerate any <xref:System.Collections.Generic.IAsyncEnumerable%601> instances in an object graph and then serialize them as JSON arrays. For deserialization, the new method <xref:System.Text.Json.JsonSerializer.DeserializeAsyncEnumerable%60%601(System.IO.Stream,System.Text.Json.JsonSerializerOptions,System.Threading.CancellationToken)?displayProperty=nameWithType> was added. For more information, see [IAsyncEnumerable serialization](../compatibility/serialization/6.0/iasyncenumerable-serialization.md).

### Other new APIs

New serialization interfaces for validation and defaulting values:

- <xref:System.Text.Json.Serialization.IJsonOnDeserialized>
- <xref:System.Text.Json.Serialization.IJsonOnDeserializing>
- <xref:System.Text.Json.Serialization.IJsonOnSerialized>
- <xref:System.Text.Json.Serialization.IJsonOnSerializing>

New property ordering attribute:

- <xref:System.Text.Json.Serialization.JsonPropertyOrderAttribute>

New method to write "raw" JSON:

- <xref:System.Text.Json.Utf8JsonWriter.WriteRawValue%2A?displayProperty=nameWithType>

Synchronous serialization and deserialization to a stream:

- <xref:System.Text.Json.JsonSerializer.Deserialize(System.IO.Stream,System.Type,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType>
- <xref:System.Text.Json.JsonSerializer.Deserialize(System.IO.Stream,System.Type,System.Text.Json.Serialization.JsonSerializerContext)?displayProperty=nameWithType>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.IO.Stream,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.IO.Stream,System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600})?displayProperty=nameWithType>
- <xref:System.Text.Json.JsonSerializer.Serialize(System.IO.Stream,System.Object,System.Type,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType>
- <xref:System.Text.Json.JsonSerializer.Serialize(System.IO.Stream,System.Object,System.Type,System.Text.Json.Serialization.JsonSerializerContext)?displayProperty=nameWithType>
- <xref:System.Text.Json.JsonSerializer.Serialize%60%601(System.IO.Stream,%60%600,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType>
- <xref:System.Text.Json.JsonSerializer.Serialize%60%601(System.IO.Stream,%60%600,System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600})?displayProperty=nameWithType>

New option to ignore an object when a reference cycle is detected during serialization:

- <xref:System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles?displayProperty=nameWithType>

For more information about serializing and deserializing with `System.Text.Json`, see [JSON serialization and deserialization in .NET](../../standard/serialization/system-text-json-overview.md).

## HTTP/3

.NET 6 includes preview support for HTTP/3, a new version of HTTP. HTTP/3 solves some existing functional and performance challenges by using a new underlying connection protocol called QUIC. QUIC establishes connections more quickly, and connections are independent of the IP address, allowing mobile clients to roam between Wi-fi and cellular networks. For more information, see [Use HTTP/3 with HttpClient](../extensions/httpclient-http3.md).

## ASP.NET Core

ASP.NET Core includes improvements in minimal APIs, ahead-of-time (AOT) compilation for Blazor WebAssembly apps, and single-page apps. In addition, Blazor components can now be rendered from JavaScript and integrated with existing JavaScript based apps. <!--For more information, see [What's new in ASP.NET Core 6](/aspnet/core/release-notes/aspnetcore-6.0).-->

### OpenTelemetry

.NET 6 brings improved support for [OpenTelemetry](https://opentelemetry.io/), which is a collection of tools, APIs, and SDKs that help you analyze your software's performance and behavior. APIs in the <xref:System.Diagnostics.Metrics?displayProperty=fullName> namespace implement the [OpenTelemetry Metrics API specification](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/metrics/api.md). For example, there are four instrument classes to support different metrics scenarios. The instrument classes are:

- <xref:System.Diagnostics.Metrics.Counter%601>
- <xref:System.Diagnostics.Metrics.Histogram%601>
- <xref:System.Diagnostics.Metrics.ObservableCounter%601>
- <xref:System.Diagnostics.Metrics.ObservableGauge%601>

## Security

.NET 6 adds preview support for two key security mitigations: Control-flow Enforcement Technology (CET) and "write exclusive execute" (W^X).

CET is an Intel technology available in some newer Intel and AMD processors. It adds capabilities to the hardware that protect against some control-flow hijacking attacks. .NET 6 provides support for CET for Windows x64 apps, and you must explicitly enable it. For more information, see [.NET 6 compatibility with Intel CET shadow stacks](https://github.com/dotnet/runtime/blob/release/6.0/docs/design/features/intel-cet-dotnet6.md).

W^X is available all operating systems with .NET 6 but only enabled by default on Apple Silicon. W^X blocks the simplest attack path by disallowing memory pages to be writeable and executable at the same time.

Support for OpenSSL 3, support for new algorithms (e.g. Poly1305).

## IL trimming

Trimming of self-contained deployments is improved. In .NET 5, only unused assemblies were trimmed. .NET 6 adds trimming of unused types and members too. In addition, trim warnings, which alert you to places where trimming may remove code that's used at run time, are now *enabled* by default. For more information, see [Trim self-contained deployments and executables](../deploying/trimming/trim-self-contained.md).

## Source generators

.NET 6 adds a new [source generator](../../csharp/roslyn-sdk/source-generators-overview.md) for <xref:System.Text.Json?displayProperty=fullName>. The JSON source generator works in conjunction with <xref:System.Text.Json.JsonSerializer> and can be configured in multiple ways. It can improve performance, reduce memory usage, and facilitate assembly trimming. To help you decide whether to use reflection or source generation, see [How to choose reflection or source generation in System.Text.Json](../../standard/serialization/system-text-json-source-generation-modes.md). For more information, see [How to use source generation in System.Text.Json](../../standard/serialization/system-text-json-source-generation.md).

<xref:Microsoft.Extensions.Logging?displayProperty=fullName> also has a new source generator for performant logging APIs. The source generator is triggered if you add the new <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> to a `partial` logging method. At compile time, the generator generates the implementation of the `partial` method, which is typically faster at run time than existing logging solutions. For more information, see [Compile-time logging source generation](../extensions/logger-message-generator.md).

## Code analysis

The .NET 6 SDK includes a handful of new code analyzers that concern API compatibility, platform compatibility, trimming safety, use of span in string concatenation and splitting, faster string APIs, and faster collection APIs. For a full list of new (and removed) analyzers, see [Analyzer releases - .NET 6](https://github.com/dotnet/roslyn-analyzers/blob/main/src/NetAnalyzers/Core/AnalyzerReleases.Shipped.md#release-60).

## Custom platform guards

The [Platform compatibility analyzer](../../standard/analyzers/platform-compat-analyzer.md) recognizes the `Is<platform>` methods in the <xref:System.OperatingSystem> class, for example, <xref:System.OperatingSystem.IsWindows?displayProperty=nameWithType>, as platform guards. To allow for custom platform guards, .NET 6 introduces two new attributes that you can use to annotate fields, properties, or methods with a supported or unsupported platform name:

- <xref:System.Runtime.Versioning.SupportedOSPlatformGuardAttribute>
- <xref:System.Runtime.Versioning.UnsupportedOSPlatformGuardAttribute>

## Windows Forms

<xref:System.Windows.Forms.Application.SetDefaultFont(System.Drawing.Font)?displayProperty=nameWithType> is a new method in .NET 6 that sets the default font across your application.

The templates for C# Windows Forms apps have been updated to support `global using` directives, file-scoped namespaces, and nullable reference types. In addition, they include application bootstrap code, which reduces boilerplate code and allows the Windows Forms designer to render the design surface in the preferred font. The bootstrap code is a call to `ApplicationConfiguration.Initialize()`, which is a source-generated method that emits calls to other configuration methods, such as <xref:System.Windows.Forms.Application.EnableVisualStyles?displayProperty=nameWithType>. Additionally, if you set a non-default font via the [ApplicationDefaultFont](../project-sdk/msbuild-props-desktop.md#applicationdefaultfont) MSBuild property, `ApplicationConfiguration.Initialize()` emits a call to <xref:System.Windows.Forms.Application.SetDefaultFont(System.Drawing.Font)>.

For more information, see the [What's new in Windows Forms](https://devblogs.microsoft.com/dotnet/whats-new-in-windows-forms-in-net-6-0-preview-5/) blog post.

## Source build

The *source tarball*, which contains all the source for the .NET SDK, is a now a product of the .NET SDK build. Other organizations, such as Red Hat, can build their own version of the SDK using this source tarball.

## Target framework monikers

Additional OS-specific target framework monikers (TFMs) have been added for .NET 6, for example, `net6.0-android`, `net6.0-ios`, and `net6.0-macos`. For more information, see [.NET 5+ OS-specific TFMs](../../standard/frameworks.md#net-5-os-specific-tfms).

## Generic math

Another new *preview* feature is the ability to use operators on generic types in .NET 6. .NET 6 introduces numerous interfaces that make use of C# 10's new preview feature, `static abstract` interface members. These interfaces correspond to different operators, for example, `IAdditionOperators` represents the `+` operator. The interfaces are available in the [System.Runtime.Experimental](https://www.nuget.org/packages/System.Runtime.Experimental) NuGet package. For more information, see the [Generic math](https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/) blog post.

## NuGet package validation

If you're a NuGet library developer, new [package-validation tooling](../../compatibility/package-validation.md) enables you to validate that your packages are consistent and well-formed. You can determine if:

- There are any breaking changes across package versions.
- The package has the same set of publics APIs for all runtime-specific implementations.
- There are any gaps for target-framework or runtime applicability.

For more information, see the [Package Validation](https://devblogs.microsoft.com/dotnet/package-validation/) blog post.

## Reflection APIs

.NET 6 introduces the following new APIs that inspect code and provide nullability information:

- <xref:System.Reflection.NullabilityInfo?displayProperty=fullName>
- <xref:System.Reflection.NullabilityInfoContext?displayProperty=fullName>
- <xref:System.Reflection.NullabilityState?displayProperty=fullName>

These APIs are useful for reflection-based tools and serializers.

## Microsoft.Extensions APIs

Several extensions namespaces have improvements in .NET 6, as the following table shows.

| Namespace | Improvements |
| - | - |
| <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> | <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.CreateAsyncScope%2A> lets you safely use a `using` statement for a service provider that registers an <xref:System.IAsyncDisposable> service. |
| <xref:Microsoft.Extensions.Hosting?displayProperty=fullName> | New <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.ConfigureHostOptions%2A> methods simplify application setup. |
| <xref:Microsoft.Extensions.Logging?displayProperty=fullName> | New <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> for source generation. |

## New LINQ APIs

Numerous LINQ methods have been added in .NET 6. Most of the new methods listed in the following table have equivalent methods in the <xref:System.Linq.Queryable?displayProperty=fullName> type.

| Method | Description |
| - | - |
| <xref:System.Linq.Enumerable.TryGetNonEnumeratedCount%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Int32@)?displayProperty=nameWithType> | Attempts to determine the number of elements in a sequence without forcing an enumeration. |
| <xref:System.Linq.Enumerable.Chunk%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Int32)?displayProperty=nameWithType> | Splits the elements of a sequence into chunks of a specified size. |
| <xref:System.Linq.Enumerable.MaxBy%2A?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.MinBy%2A?displayProperty=nameWithType> | Finds maximal or minimal elements using a key selector. |
| <xref:System.Linq.Enumerable.DistinctBy%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.ExceptBy%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.IntersectBy%2A?displayProperty=nameWithType>, and <xref:System.Linq.Enumerable.UnionBy%2A?displayProperty=nameWithType> | These new variations of methods that perform set-based operations let you specify equality using a key selector function. |
| <xref:System.Linq.Enumerable.ElementAt%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Index)?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.ElementAtOrDefault%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Index)?displayProperty=nameWithType> | Accepts indexes counted from the beginning or end of the sequence&mdash;for example, `Enumerable.Range(1, 10).ElementAt(^2)` returns `9`. |
| <xref:System.Linq.Enumerable.FirstOrDefault%60%601(System.Collections.Generic.IEnumerable{%60%600},%60%600)?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.FirstOrDefault%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Func{%60%600,System.Boolean},%60%600)?displayProperty=nameWithType><br/><xref:System.Linq.Enumerable.LastOrDefault%60%601(System.Collections.Generic.IEnumerable{%60%600},%60%600)?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.LastOrDefault%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Func{%60%600,System.Boolean},%60%600)?displayProperty=nameWithType><br/><xref:System.Linq.Enumerable.SingleOrDefault%60%601(System.Collections.Generic.IEnumerable{%60%600},%60%600)?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.SingleOrDefault%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Func{%60%600,System.Boolean},%60%600)?displayProperty=nameWithType> | New overloads let you specify a default value to use if the sequence is empty. |
| <xref:System.Linq.Enumerable.Max%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Collections.Generic.IComparer{%60%600})?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.Min%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Collections.Generic.IComparer{%60%600})?displayProperty=nameWithType> | New overloads let you specify a comparer. |
| <xref:System.Linq.Enumerable.Take%60%601(System.Collections.Generic.IEnumerable{%60%600},System.Range)?displayProperty=nameWithType> | Accepts a <xref:System.Range> argument to simplify taking a slice of a sequence&mdash;for example, you can use `source.Take(2..7)` instead of `source.Take(7).Skip(2)`. |
| <xref:System.Linq.Enumerable.Zip%60%603(System.Collections.Generic.IEnumerable{%60%600},System.Collections.Generic.IEnumerable{%60%601},System.Collections.Generic.IEnumerable{%60%602})?displayProperty=nameWithType> | Produces a sequence of tuples with elements from *three* specified sequences. |

## Date, time, and time zone improvements

The following two structs were added in .NET 6: <xref:System.DateOnly?displayProperty=fullName> and <xref:System.TimeOnly?displayProperty=fullName>. These represent the date part and the time part of a <xref:System.DateTime>, respectively. <xref:System.DateOnly> is useful for birthdays and anniversaries, and <xref:System.TimeOnly> is useful for daily alarms and weekly business hours.

You can now use either IANA or Windows time zone IDs on any operating system that has time zone data installed. The <xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)?displayProperty=nameWithType> method has been updated to automatically convert its input from a Windows time zone to an Internet Assigned Numbers Authority (IANA) time zone (or vice versa) if the requested time zone is not found on the system. In addition, the new methods <xref:System.TimeZoneInfo.TryConvertIanaIdToWindowsId(System.String,System.String@)> and <xref:System.TimeZoneInfo.TryConvertWindowsIdToIanaId%2A> have been added for scenarios when you still need to manually convert from one time zone format to another.

There are a few other time zone improvements as well. For more information, see [Date, Time, and Time Zone Enhancements in .NET 6](https://devblogs.microsoft.com/dotnet/date-time-and-time-zone-enhancements-in-net-6/).

## New PriorityQueue collection

The new <xref:System.Collections.Generic.PriorityQueue%602> class represents a collection of items that have both a value and a priority. Items are dequeued in increasing priority order&mdash;that is, the item with the lowest priority value is dequeued first. This class implements a [min heap](https://en.wikipedia.org/wiki/Heap_(data_structure)) data structure.

## See also

- [What's new in C# 10.0](../../csharp/whats-new/csharp-10.md)
- [What's new in F# 6](../../fsharp/whats-new/fsharp-6.md)
- [What's new in EF Core 6](/ef/core/what-is-new/ef-core-6.0/whatsnew)
- [Release notes for .NET 6](https://github.com/dotnet/core/tree/main/release-notes/6.0)
- [Release notes for Visual Studio 2022](/visualstudio/releases/2022/release-notes)
- [Blog: Announcing .NET 6 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-1/)
- [Blog: Announcing .NET 6 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-2/)
- [Blog: Announcing .NET 6 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-3/)
- [Blog: Announcing .NET 6 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-4/)
- [Blog: Announcing .NET 6 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-5/)
- [Blog: Announcing .NET 6 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-6/)
- [Blog: Announcing .NET 6 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-7/)
- [Blog: Announcing .NET 6 Release Candidate 1](https://devblogs.microsoft.com/dotnet/announcing-net-6-release-candidate-1/)
- [Blog: Announcing .NET 6 Release Candidate 2](https://devblogs.microsoft.com/dotnet/announcing-net-6-release-candidate-2/)
