---
title: What's new in .NET 9
description: Learn about the new .NET features introduced in .NET 9 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 11/11/2024
ms.topic: whats-new
---

# What's new in .NET 9

Learn about the new features in .NET 9 and find links to further documentation.

.NET 9, the successor to [.NET 8](../dotnet-8/overview.md), has a special focus on cloud-native apps and performance. It will be [supported for 18 months](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a standard-term support (STS) release. You can [download .NET 9 here](https://dotnet.microsoft.com/download/dotnet/9.0).

New for .NET 9, the engineering team posts .NET 9 preview updates on [GitHub Discussions](https://github.com/dotnet/core/discussions/9234). That's a great place to ask questions and provide feedback about the release.

## .NET runtime

The .NET 9 runtime includes a new attribute model for feature switches with trimming support. The new attributes make it possible to define [feature switches](https://github.com/dotnet/designs/blob/main/accepted/2020/feature-switch.md) that libraries can use to toggle areas of functionality.

Garbage collection includes a _dynamic adaptation to application size_ feature that's used by default instead of Server GC.

The runtime also includes numerous performance improvements, including loop optimizations, inlining, and Arm64 vectorization and code generation.

For more information, see [What's new in the .NET 9 runtime](runtime.md).

## .NET libraries

<xref:System.Text.Json> adds support for nullable reference type annotations and exporting JSON schemas from types. It adds new options that let you customize the indentation of written JSON and read multiple root-level JSON values from a single stream.

In LINQ, the new methods <xref:System.Linq.Enumerable.CountBy%2A> and <xref:System.Linq.Enumerable.AggregateBy%2A> make it possible to aggregate state by key without needing to allocate intermediate groupings via <xref:System.Linq.Enumerable.GroupBy%2A>.

For collection types, the <xref:System.Collections.Generic.PriorityQueue%602?displayProperty=fullName> type includes a new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})> method that you can use to _update_ the priority of an item in the queue.

For cryptography, .NET 9 adds a new one-shot hash method on the <xref:System.Security.Cryptography.CryptographicOperations> type. It also adds new classes that use the KMAC algorithm.

For reflection, the new <xref:System.Reflection.Emit.PersistedAssemblyBuilder> type lets you _save_ an emitted assembly. This new class also includes PDB support, meaning you can emit symbol info and use it to debug a generated assembly.

The <xref:System.TimeSpan> class includes new `From*` methods that let you create a `TimeSpan` object from an `int` (instead of a `double`). These methods help to avoid errors caused by inherent imprecision in floating-point calculations.

For more information, see [What's new in the .NET 9 libraries](libraries.md).

## .NET SDK

The .NET 9 SDK introduces _workload sets_, where all of your workloads stay at a single, specific version until explicitly updated. For tools, a new option for [`dotnet tool install`](../../tools/dotnet-tool-install.md) lets users (instead of tool authors) decide whether a tool is allowed to run on a newer .NET runtime version than the version the tool targets. In addition:

- Unit testing has better MSBuild integration that allows you to run tests in parallel.
- The terminal logger is enabled by default and also has improved usability. For example, the total count of failures and warnings is now summarized at the end of a build.
- New MSBuild script analyzers ("build checks") are available.
- The SDK can detect and adjust for version mismatches between the .NET SDK and MSBuild.
- The `dotnet workload history` command shows you the history of workload installations and modifications for the current .NET SDK installation.

For more information, see [What's new in the SDK for .NET 9](sdk.md).

## AI building blocks

.NET 9 introduces a unified layer of C# abstractions through the [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI.Abstractions/) and [Microsoft.Extensions.VectorData](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions/) packages. These abstractions facilitate interaction with AI services, including small and large language models (SLMs and LLMs), embeddings, vector stores, and middleware.

.NET 9 also includes new tensor types that expand AI capabilities. <xref:System.Numerics.Tensors.TensorPrimitives> and the new <xref:System.Numerics.Tensors.Tensor%601> type expand AI capabilities by enabling efficient encoding, manipulation, and computation of multi-dimensional data. You can find these types in the latest release of the [System.Numerics.Tensors package](https://www.nuget.org/packages/System.Numerics.Tensors/).

### TensorPrimitives

- Expanded method scope: Increased from 40 to nearly 200 overloads, now including numerical operations similar to `Math`, `MathF`, and `INumber<T>` but for spans of values.
- Performance enhancements: Many operations are now SIMD-optimized for better performance.
- Generic overloads: Supports any type `T` that implements a certain interface, expanding beyond just spans of float values in .NET.

### Tensor\<T>

- Builds on top of `TensorPrimitives` for efficient math operations.
- Provides efficient interop with AI libraries (ML.NET, TorchSharp, ONNX Runtime) using zero copies where possible.
- Enables easy and efficient data manipulation with indexing and slicing operations.
- Is [experimental](../../../fundamentals/runtime-libraries/preview-apis.md#experimentalattribute) in .NET 9.

### ML.NET

[ML.NET](https://www.nuget.org/packages/Microsoft.ML/) is an open-source, cross-platform framework that enables integration of custom machine-learning models into .NET applications.

ML.NET 4.0 brings the following improvements:

- New ways to programmatically configure `MLContext` options.
- Load ONNX models as `Stream`.
- DataFrame improvements.
- New capabilities for [tokenizers](#tokenizers).
- (Experimental) TorchSharp ports of Llama and Phi family of models.
- (Experimental) CausalLM pipeline APIs.

For more information, see [What's new in ML.NET](../../../machine-learning/whats-new/overview.md).

#### Tokenizers

The [Microsoft.ML.Tokenizers](https://www.nuget.org/packages/Microsoft.ML.Tokenizers) library provides .NET developers with capabilities for encoding and decoding text to tokens. For AI scenarios, this is important to manage context, calculate cost, and preprocess text when working with local models.

The latest release introduces significant new capabilities for tokenizers:

- Tiktoken for GPT (3, 3.5, 4, 4o, o1) and Llam3 models
- Llama (based on SentencePiece) for Llama and Mistral models
- CodeGen for code-generation models like codegen-350M-mono
- Phi2 (based on CodeGen) for Microsoft Phi2 model
- WordPiece
- Bert (based on WordPiece) for Bert-supported models like optimum--all-MiniLM-L6-v2

## .NET Aspire

.NET Aspire is a set of powerful tools, templates, and packages for building observable, production ready apps.​ .NET Aspire's latest release includes improvements to the dashboard and resource lifecycle management. It also adds new integrations and APIs for more flexibility during development. .NET Aspire 9 works with both .NET 9 and .NET 8 apps. For more information, see [What's new in .NET Aspire 9](/dotnet/aspire/whats-new/dotnet-aspire-9-release-candidate-1).

## ASP.NET Core

ASP.NET Core apps built with .NET 9 are secure by default, have expanded support for ahead-of-time compilation, and have improved monitoring and tracing. With the performance improvements, you'll see higher throughput and faster startup time, and all with less memory usage. ASP.NET Core in .NET 9 includes:

- Optimized handling of static files, like JavaScript and CSS, at build and publish time with automatic fingerprinted versioning.
- Blazor: New Hybrid and Web app templates, detection of component render mode, new reconnection experience with server rendering.
- APIs: Built in support for OpenAPI document generation using `Microsoft.AspNetCore.OpenAPI`, enhanced native AOT support.
- Improved security with new APIs for authentication and authorization.
- Easier setup for trusted development certificate on Linux to enable HTTPS during development.

These are just some of the features and enhancements in .NET 9. For more information, see [What's new in ASP.NET Core 9.0](/aspnet/core/release-notes/aspnetcore-9.0).

## .NET MAUI

The focus of .NET Multi-platform App UI (.NET MAUI) in .NET 9 is enhanced performance and reliability, and deeper integrations for desktop and mobile applications. .NET MAUI includes a new, more performant implementation of <xref:Microsoft.Maui.Controls.CollectionView> and <xref:Microsoft.Maui.Controls.CarouselView> for iOS and Mac Catalyst, updates to existing controls, new app lifecycle events, and Native AOT and trimming enhancements to improve app size and startup time.  In addition:

- A new <xref:Microsoft.Maui.Controls.TitleBar> desktop control is available for Windows.
- A new <xref:Microsoft.Maui.Controls.HybridWebView> control enables easier inclusion of JavaScript-enabled content from frameworks like ReactJS, Vue.js, and Angular.
- <xref:Microsoft.Maui.Controls.Entry> now supports additional keyboard modes.
- Control handlers automatically disconnect from their controls when possible.
- <xref:Microsoft.Maui.Controls.Application.MainPage> is deprecated in favor of setting the primary page of the app by overriding <xref:Microsoft.Maui.Controls.Application.CreateWindow(Microsoft.Maui.IActivationState)?displayProperty=nameWithType> class.

For more information about that these new features and more, see [What's new in .NET MAUI for .NET 9](/dotnet/maui/whats-new/dotnet-9).

## EF Core

Entity Framework Core includes significant updates to the database provider for Azure Cosmos DB for NoSQL. It also includes some steps towards AOT compilation and pre-compiled queries, among other improvements. For more information, see [What's New in EF Core 9](/ef/core/what-is-new/ef-core-9.0/whatsnew).

## C# 13

C# 13 ships with the .NET 9 SDK and includes the following new features:

- `params` collections
- New `lock` type and semantics
- New escape sequence - `\e`
- Method group natural type improvements
- Implicit indexer access in object initializers
- Enable `ref` locals and `unsafe` contexts in iterators and async methods
- Enable `ref struct` types to implement interfaces
- Allow ref struct types as arguments for type parameters in generics.
- Partial properties and indexers are now allowed in `partial` types.
- Overload resolution priority allows library authors to designate one overload as better than others.

In addition, C# 13 adds a preview feature: `field` backed properties.

For more information, see [What's new in C# 13](../../../csharp/whats-new/csharp-13.md).

## F# 9

F# 9 ships with the .NET 9 SDK and includes the following new features:

- Nullable reference types
- Discriminated union .Is* properties
- Partial active patterns can return bool instead of unit option
- Prefer extension methods to intrinsic properties when arguments are provided
- Empty-bodied computation expressions
- Hash directives are allowed to take non-string arguments
- Extended #help directive in fsi to show documentation in the read-eval-print loop (REPL)
- Allow #nowarn to support the FS prefix on error codes to disable warnings
- Warning about TailCall attribute on non-recursive functions or let-bound values
- Enforce attribute targets
- Random functions for collections
- C# collection expression support for F# lists and sets
- Various developer productivity, performance and tooling improvements

For more information, see [What's new in F# 9](../../../fsharp/whats-new/fsharp-9.md).

## Windows Presentation Foundation

WPF in .NET 9 bring enhanced support for building modern apps with several theming enhancements and more:

- Support for the Windows Fluent theme.
- Theme support for Windows light and dark modes added.
- Themes support the Windows Accent color now.
- Font render has been improved to support hyphen-based ligatures.
- `BinaryFormatter` is no longer supported.

For more information, see [What's new in WPF for .NET 9](/dotnet/desktop/wpf/whats-new/net90).

## Windows Forms

WinForms in .NET 9 brings support for new themes, enhancements for asynchronous development, and more:

- `Form` and `TaskDialog` support `ShowDialogAsync` now. (Experimental feature)
- `BinaryFormatter` is no longer supported.
- Experimental support for rendering the app in dark mode, as supported by Windows.
- `FolderBrowserDialog` and `ToolStrip` had some minor improvements.
- The **System.Drawing** library has had many improvements, including wrapping GDI+ effects, support for `ReadOnlySpan`, and better interop code generation.

For more information, see [What's new in Windows Forms for .NET 9](/dotnet/desktop/winforms/whats-new/net90).

## See also

- [Our vision for .NET 9](https://devblogs.microsoft.com/dotnet/our-vision-for-dotnet-9/) blog post
- [What's new in ASP.NET Core 9.0](/aspnet/core/release-notes/aspnetcore-9.0)
- [What's new in .NET MAUI](/dotnet/maui/whats-new/dotnet-9)
- [What's new in EF Core](/ef/core/what-is-new/ef-core-9.0/whatsnew)
