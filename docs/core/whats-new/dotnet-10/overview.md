---
title: What's new in .NET 10
description: Learn about the new features introduced in .NET 10 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 04/09/2025
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in .NET 10

Learn about the new features in .NET 10 and find links to further documentation. This page is updated for Preview 3.

.NET 10, the successor to [.NET 9](../dotnet-9/overview.md), is [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release. You can [download .NET 10 here](https://get.dot.net/10).

Your feedback is important and appreciated. If you have questions or comments, use the discussion on [GitHub](https://github.com/dotnet/core/discussions/categories/news).

## .NET runtime

The .NET 10 runtime introduces new features and performance improvements. Key updates include:

- **Array interface method devirtualization**: The JIT can now devirtualize and inline array interface methods, improving performance for array enumerations.
- **Array enumeration de-abstraction**: Enhancements to reduce abstraction overhead for array iteration via enumerators, enabling better inlining and stack allocation.
- **Inlining of late devirtualized methods**: The JIT can now inline methods that become eligible for devirtualization due to previous inlining.
- **Devirtualization based on inlining observations**: The JIT uses precise type information from inlining to devirtualize subsequent calls.
- **Stack allocation of arrays of value types**: Small, fixed-sized arrays of value types without GC pointers can now be stack-allocated.
- **AVX10.2 support**: Introduced support for Advanced Vector Extensions (AVX) 10.2 for x64-based processors, though currently disabled by default.
- **NativeAOT enhancements**: Support for casting and negation in NativeAOT's type preinitializer.

For more information, see [What's new in the .NET 10 runtime](runtime.md).

## .NET libraries

The .NET 10 libraries introduce several new features and improvements, including:

- **Find certificates by thumbprints other than SHA-1**: A new method allows finding certificates using hash algorithms like SHA-256.
- **Find PEM-encoded data in ASCII/UTF-8**: PEM encoding APIs now support reading directly from ASCII/UTF-8 data.
- **ISOWeek support for DateOnly**: New overloads in the <xref:System.Globalization.ISOWeek> class support the <xref:System.DateOnly> type.
- **String normalization APIs for spans**: New APIs allow Unicode string normalization to work with spans of characters, reducing allocations.
- **Numeric ordering for string comparison**: A new <xref:System.Globalization.CompareOptions.NumericOrdering?displayProperty=nameWithType> option enables numerical string comparisons.
- **New TimeSpan.FromMilliseconds overload**: A single-parameter overload resolves issues with LINQ expressions.
- **ZipArchive performance improvements**: Optimizations reduce memory usage and improve performance for <xref:System.IO.Compression.ZipArchive> in `Update` mode and parallel extraction.
- **OrderedDictionary enhancements**: New `TryAdd` and `TryGetValue` overloads return an index for fast access.
- **JSON serialization updates**: Source generators now allow specifying `ReferenceHandler` in <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute>.
- **Left-handed matrix transformations**: New APIs for creating left-handed transformation matrices.
- **PKCS#12 export enhancements**: New methods allow specifying encryption and digest algorithms for PKCS#12/PFX export.

For more information, see [What's new in the .NET 10 libraries](libraries.md).

## .NET SDK

The .NET 10 SDK introduces the following new features and enhancements, including:

- **Pruning of framework-provided package references**: Automatically removes unused framework-provided package references, reducing build times and disk usage.
- **More consistent command order**: New noun-first aliases for `dotnet` CLI commands improve readability and consistency.

For more information, see [What's new in the SDK for .NET 10](sdk.md).

## .NET Aspire

.NET Aspire releases version 9.1, which focuses on quality-of-life fixes.

For more information, see [What's new in .NET Aspire 9.1](/dotnet/aspire/whats-new/dotnet-aspire-9.1).

## ASP.NET Core

The ASP.NET Core 10.0 release introduces several new features and enhancements, including:

- **Blazor enhancements**:
  - Added the `ReconnectModal` component to the Blazor Web App project template for improved reconnection UI control.
  - The `NavigateTo` method no longer scrolls to the top for same-page navigation.
  - The `NavLink` component now ignores query strings and fragments when using `NavLinkMatch.All`.
  - Added the `RowClass` parameter to `QuickGrid` for applying styles to rows based on their data.
  - Added the `CloseColumnOptionsAsync` method to `QuickGrid` for programmatically closing column options.
  - Blazor framework script is now served as a static web asset with precompression and fingerprinting enabled.

- **OpenAPI improvements**:
  - Added support for generating OpenAPI version 3.1 documents.
  - Added support for serving OpenAPI documents in YAML format.
  - Populated XML doc comments into OpenAPI documents.

- **Minimal APIs**:
  - Improved integration testing for apps using top-level statements.
  - Empty strings in form posts are now treated as `null` for nullable value types.
  - Built-in validation support for query, header, route parameters, and request bodies, with customizable behavior.

- **Authentication and authorization**:
  - Added new metrics for authentication and authorization events.

- **Miscellaneous**:
  - Added the `RedirectHttpResult.IsLocalUrl` helper method for detecting local URLs.
  - Added support for route syntax highlighting in the <xref:Microsoft.AspNetCore.Components.RouteAttribute>.
  - New `TypedResults.ServerSentEvents` API for streaming event messages to clients in minimal APIs and controller-based apps.
  - Declarative state persistence simplifies state persistence in components and services during prerendering using the `SupplyParameterFromPersistentComponentState` attribute.
  - Standalone Blazor WebAssembly apps now support referencing fingerprinted static web assets and import maps.
  - <xref:System.Net.Http.HttpClient> response streaming is enabled by default on WebAssembly, improving performance and reducing memory usage for large responses.
  - The app context switch `DisableMatchAllIgnoresLeftUriPart` is now renamed to `EnableMatchAllForQueryStringAndFragment`.
  - Specify the environment for standalone Blazor WebAssembly apps at build time using the `<WasmApplicationEnvironmentName>` property.
  - The ASP.NET Core Web API (native AOT) template now includes OpenAPI support by default.

For more information, see [What's new in ASP.NET Core for .NET 10](/aspnet/core/release-notes/aspnetcore-10.0).

## C# 14

C# 14 introduces several new features and enhancements to improve developer productivity and code quality. Key updates include:

- **Field-backed properties**: Provides a smoother path from auto-implemented properties to writing custom `get` and `set` accessors. The compiler-generated backing field can now be accessed using the `field` contextual keyword.
- **Unbound generic support for `nameof`**: The `nameof` expression now supports unbound generic types, such as `List<>`, returning the name of the type without requiring type arguments.
- **Implicit span conversions**: Introduces first-class support for `Span<T>` and `ReadOnlySpan<T>` with new implicit conversions, enabling more natural programming with these types.
- **Modifiers on simple lambda parameters**: Allows parameter modifiers like `ref`, `in`, or `out` in lambda expressions without specifying parameter types.
- **Experimental feature - String literals in data section**: Enables emitting string literals as UTF-8 data into a separate section of the PE file, improving efficiency for certain scenarios.
- **Partial events and constructors**: Adds support for partial instance constructors and partial events, complementing partial methods and properties introduced in C# 13.
- **Extension members**: Extension methods now support static methods, instance properties, and static properties through `extension` blocks, enabling more flexible and powerful extensions.
- **Null-conditional assignment**: Simplifies conditional assignments by allowing properties or fields to be updated only if the containing instance exists, using the `?.` operator.

For more information, see [What's new in C# 14](../../../csharp/whats-new/csharp-14.md).

## .NET MAUI

The .NET MAUI updates in .NET 10 include several new features and quality improvements for .NET MAUI, .NET for Android, and .NET for iOS, Mac Catalyst, macOS, and tvOS. Key updates include:

- **General improvements**:
  - New `ShadowTypeConverter` for converting formatted strings to `Shadow` on `VisualElement`.
  - Added `SpeechOptions.Rate` for controlling the playback rate in Text-to-Speech.
  - Support for styling modals as popovers on iOS and Mac Catalyst.
  - Added `Switch.OffColor` for customizing the color of the `Switch` control when off.
  - Added `SearchBar.SearchIconColor` for customizing the search icon color.
  - New `HybridWebView.InvokeJavascriptAsync` method for invoking JavaScript without requiring generic arguments.
  - Support for fullscreen video playback in `WebView` on Android when the `iframe` includes `allowfullscreen`.
  - Added `Geolocation.IsEnabled` to check if geolocation services are enabled without requesting location details.
  - A `CancellationToken` can now be passed to `WebAuthenticator.AuthenticateAsync` for programmatically canceling authentication.

- **Deprecations**:
  - The `FontImageExtension` XAML markup extension is deprecated. Use `FontImageSource` instead.
  - `MessagingCenter` is now internal. Replace it with `WeakReferenceMessenger` from the `CommunityToolkit.Mvvm` package.
  - Deprecation of `ListView`, `Cell`, and `TableView`, which will be removed in a future release.

- **Performance improvements**:
  - Property mapping improvements with new caching and optimized property application order, reducing race conditions and repetitive calls.
  - CollectionView optimizations on iOS, eliminating `MeasureInvalidated` subscriptions and improving templated cell responsiveness.
  - Optimized `Label` rendering for `FormattedString` on Windows, achieving a ~56% performance improvement.

- **.NET for Android**:
  - Support for Android 16 (API-36) Beta 1.
  - Updated recommended minimum supported Android API to 24 (Nougat).
  - Support for building with JDK-21.
  - Added support for `dotnet run` for Android projects.
  - Enabled marshal methods by default for improved startup performance.
  - Design-time builds no longer invoke `aapt2`, reducing build times.

- **.NET for iOS, Mac Catalyst, macOS, tvOS**:
  - Trimmer warnings are now enabled by default.
  - Bundling of original resources in libraries is now opt-out.
  - Support for Xcode 16.3 Release Candidate

For more information, see [What's new in .NET MAUI in .NET 10](/dotnet/maui/whats-new/dotnet-10).

## EF Core

The EF Core 10 release introduces several new features and improvements, including:

- **LINQ enhancements**:
  - Added support for the `LeftJoin` operator, simplifying LINQ queries that require `LEFT JOIN` operations.
  - Added support for the `RightJoin` operator, enabling LINQ queries that require `RIGHT JOIN` operations.

- **ExecuteUpdateAsync improvements**:
  - `ExecuteUpdateAsync` now accepts a regular, non-expression lambda, reducing verbosity when updating entities.

- **Performance optimizations**:
  - Improved translation for `DateOnly.ToDateTime(timeOnly)`.
  - Optimized multiple consecutive `LIMIT` operations.
  - Enhanced performance for `Count` operations on `ICollection<T>`.
  - Optimized `MIN`/`MAX` operations over `DISTINCT`.

- **Improved experience with Azure Cosmos DB for NoSQL**:
  - EF Core now materializes a default value for required properties when no data is present in the document, simplifying model evolution.

- **Small improvements**:
  - Redacted inlined constants from logs when sensitive logging is off.
  - Enhanced <xref:Microsoft.Data.Sqlite.SqliteConnection.LoadExtension(System.String,System.String)> to work correctly with `dotnet run` and libraries named with `lib*`.

- **Miscellaneous**:
  - Simplified parameter names in SQL queries (for example, from `@__city_0` to `city`).
  - Added translation for date/time functions using `DatePart.Microsecond` and `DatePart.Nanosecond`.
  - Made SQL Server scaffolding compatible with Azure Data Explorer.
  - Additional minor bug fixes and improvements.

For more information, see [What's new in EF Core for .NET 10](/ef/core/what-is-new/ef-core-10.0/whatsnew).

## F\#

The F# updates in .NET 10 include several new features and improvements across the language, standard library, and compiler service. Key updates include:

- **F# Language**:
  - New language features require enabling the `<LangVersion>preview</LangVersion>` project property in `.fsproj` files. These features become the default with the .NET 10 release.

- **FSharp.Core Standard Library**:
  - Changes to the `FSharp.Core` standard library are applied automatically to projects compiled with the new SDK unless a lower `FSharp.Core` version is explicitly pinned.

- **FSharp.Compiler.Service**:
  - General improvements and bug fixes in the compiler implementation.

For more information, see the [F# release notes](https://fsharp.github.io/fsharp-compiler-docs/release-notes/About.html).

## Visual Basic

The Visual Basic updates in .NET 10 include the following features and enhancements:

- **`unmanaged` constraint support**: The Visual Basic compiler now interprets and enforces the `unmanaged` generic constraint, enabling better compatibility with runtime APIs.
- **Honor overload resolution priority**: The Visual Basic compiler respects the <xref:System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute>, ensuring faster Span-based overloads are preferred and resolving ambiguities among method overloads.

These updates ensure that Visual Basic can consume updated features in C# and the runtime, improving compatibility and performance.

For more information, see [What's new in Visual Basic](../../../visual-basic/whats-new/index.md).

## Windows Forms

Changes in Windows Forms for .NET 10 include:

- **Clipboard-related updates**:
  - Introduced new APIs for JSON serialization and type-safe data retrieval from the Clipboard, such as `SetDataAsJson<T>` and `TryGetData<T>`.
  - Marked several Clipboard-related APIs as obsolete to warn developers about potential `BinaryFormatter` usage.
  - Added a configuration switch (`Windows.ClipboardDragDrop.EnableUnsafeBinaryFormatterSerialization`) to explicitly enable `BinaryFormatter` for Clipboard scenarios.
  - Unified Clipboard code with WPF to enhance consistency and reliability.

- **Ported UITypeEditors**:
  - Ported several `UITypeEditors` from .NET Framework, including `ToolStripCollectionEditor` and editors related to the `DataGridView` control.

- **Quality enhancements**:
  - Expanded unit test coverage and addressed various bug fixes to improve stability and performance.

For more information, see [What's new in Windows Forms for .NET 10](/dotnet/desktop/winforms/whats-new/net100).

## WPF

The WPF updates in .NET 10 include several performance improvements, Fluent style changes, bug fixes, and engineering health updates:

- **Performance improvements**:
  - Replaced data structures like `PartialList` with `ReadOnlyCollection` to enhance performance.
  - Optimized UI automation and file dialog operations to minimize allocations.
  - Improved pixel format conversion performance.
  - Enhanced performance by optimizing cache operations and array handling.
  - Migrated font collection loader to managed code.

- **Fluent style changes**:
  - Updated the default style for `Label`.
  - Fixed animation issues for `Expander` by adjusting a `KeyTime` value.
  - Introduced new Fluent styles for controls, including `NavigationWindow`, `Frame`, `ToolBar`, `ResizeGrip`, `GroupBox`, `Hyperlink`, `GridSplitter`, and `Thumb`.
  - Fixed elevation border brushes for various controls.
  - Corrected missing `RecognizesAccessKey` property.

- **Bug fixes**:
  - Resolved issues with UI element cursor types and crashes when bitmap streams are null.
  - Fixed localization issues for `ScrollViewer` and `ContextMenu`.
  - Addressed minor bugs in `BitmapMetadata` and native dependencies.
  - Addressed memory leaks, control behavior anomalies, and property recognition issues.
  - Fixed faulty caching of `LinearGradientBrushes` when `RelativeTransform` was used with `Absolute` mapping mode.

For more information, see [What's new in WPF in .NET 10](/dotnet/desktop/wpf/whats-new/net100).
