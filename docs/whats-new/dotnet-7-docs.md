---
title: ".NET docs: What's new for .NET 7"
description: "What's new in the .NET docs for the .NET 7 release."
ms.date: 11/08/2022
---

# .NET docs: What's new for the .NET 7 release

Welcome to what's new in the .NET docs for the .NET 7 release. This article lists some of the major changes to docs related to .NET feature updates.

## .NET breaking changes

- [Breaking changes in .NET 7](../core/compatibility/7.0.md)

## .NET fundamentals

### New articles

- [What's new in .NET 7](../core/whats-new/dotnet-7.md)
- [Introduction to AOT warnings](../core/deploying/native-aot/fixing-warnings.md)
- [Diagnostic monitoring and collection utility (dotnet-monitor)](../core/diagnostics/dotnet-monitor.md)
- [Containerize a .NET app with dotnet publish](../core/docker/publish-as-container.md)
- [System.Threading.Channels library](../core/extensions/channels.md)
- [Rate limit an HTTP handler in .NET](../core/extensions/http-ratelimiter.md)
- [Upgrade a WCF Server-side Project to use CoreWCF on .NET 6](../core/porting/upgrade-assistant-wcf.md)
- [dotnet workload command](../core/tools/dotnet-workload.md)
- [NuGet signed package verification](../core/tools/nuget-signed-package-verification.md)
- [.NET SDK error list](../core/tools/sdk-errors/index.md)
- [SYSLIB diagnostics for regex source generation](../fundamentals/syslib-diagnostics/syslib1040-1049.md)
- [SYSLIB diagnostics for p/invoke source generation](../fundamentals/syslib-diagnostics/syslib1050-1069.md)
- [SYSLIB diagnostics for JavaScript interop source generation](../fundamentals/syslib-diagnostics/syslib1070-1089.md)
- [SYSLIB0038: SerializationFormat.Binary is obsolete](../fundamentals/syslib-diagnostics/syslib0038.md)
- [SYSLIB0039: SslProtocols.Tls and SslProtocols.Tls11 are obsolete](../fundamentals/syslib-diagnostics/syslib0039.md)
- [SYSLIB0040: EncryptionPolicy.NoEncryption and EncryptionPolicy.AllowNoEncryption are obsolete](../fundamentals/syslib-diagnostics/syslib0040.md)
- [SYSLIB0041: Some Rfc2898DeriveBytes constructors are obsolete](../fundamentals/syslib-diagnostics/syslib0041.md)
- [SYSLIB0042: FromXmlString and ToXmlString on ECC types are obsolete](../fundamentals/syslib-diagnostics/syslib0042.md)
- [SYSLIB0043: ECDiffieHellmanPublicKey.ToByteArray is obsolete](../fundamentals/syslib-diagnostics/syslib0043.md)
- [SYSLIB0044: AssemblyName.CodeBase and AssemblyName.EscapedCodeBase are obsolete](../fundamentals/syslib-diagnostics/syslib0044.md)
- [SYSLIB0046: ControlledExecution.Run should not be used](../fundamentals/syslib-diagnostics/syslib0046.md)
- [SYSLIB0047: XmlSecureResolver is obsolete](../fundamentals/syslib-diagnostics/syslib0047.md)
- [CA2019: `ThreadStatic` fields should not use inline initialization](../fundamentals/code-analysis/quality-rules/ca2019.md)
- [CA2259: Ensure `ThreadStatic` is only used with static fields](../fundamentals/code-analysis/quality-rules/ca2259.md)
- [CA1420: Property, type, or attribute requires runtime marshalling](../fundamentals/code-analysis/quality-rules/ca1420.md)
- [CA1422: Validate platform compatibility - obsoleted APIs](../fundamentals/code-analysis/quality-rules/ca1422.md)
- [CA2260: Implement generic math interfaces correctly](../fundamentals/code-analysis/quality-rules/ca2260.md)
- [CA1854: Prefer the `IDictionary.TryGetValue(TKey, out TValue)` method](../fundamentals/code-analysis/quality-rules/ca1854.md)
- [CA1851: Possible multiple enumerations of `IEnumerable` collection](../fundamentals/code-analysis/quality-rules/ca1851.md)
- [Prefer 'null' check over type check (IDE0150)](../fundamentals/code-analysis/style-rules/ide0150.md)
- [Simplify property pattern (IDE0170)](../fundamentals/code-analysis/style-rules/ide0170.md)
- [Use tuple to swap values (IDE0180)](../fundamentals/code-analysis/style-rules/ide0180.md)
- [Namespace declaration preferences (IDE0160 and IDE0161)](../fundamentals/code-analysis/style-rules/ide0160-ide0161.md)
- [.NET regular expression source generators](../standard/base-types/regular-expression-source-generators.md)
- [Generic math](../standard/generics/math.md)
- [Source generation for platform invokes](../standard/native-interop/pinvoke-source-generation.md)
- [Source generation for custom marshalling](../standard/native-interop/custom-marshalling-source-generation.md)
- [Tutorial: Use custom marshallers in source-generated P/Invokes](../standard/native-interop/tutorial-custom-marshaller.md)
- [Customize a JSON contract](../standard/serialization/system-text-json/custom-contracts.md)

### Updated articles

- [.NET introduction](../core/introduction.md) - Add new information for .NET 7.
- [.NET SDK](../core/sdk.md) - Add new tools and libraries for .NET 7.
- [Native AOT Deployment](../core/deploying/native-aot/index.md) - Document AOT analysis warnings
- [Single-file deployment and executable](../core/deploying/single-file/overview.md) - Update single file incompatibility docs
- [Prepare .NET libraries for trimming](../core/deploying/trimming/prepare-libraries-for-trimming.md)- Update trimming libraries docs
- [Trimming options](../core/deploying/trimming/trimming-options.md) - Cleanup trimming options and document TrimMode=full,partial
- [Tutorial: Containerize a .NET app](../core/docker/build-container.md) - Add `dotnet publish` article for .NET 7 containerization support.
- [Rate limit an HTTP handler in .NET](../core/extensions/http-ratelimiter.md) - New `RateLimiter` article showing a custom HTTP handler
- [Configuration providers in .NET](../core/extensions/configuration-providers.md) - Environment variable prefix breaking change
- [Use HTTP/3 with HttpClient](../core/extensions/httpclient-http3.md) - Update HTTP/3 support for HttpClient in .NET 7
- [IHttpClientFactory with .NET](../core/extensions/httpclient-factory.md) - New `HttpClient` article
- [Overview of .NET, MSBuild, and Visual Studio versioning](../core/porting/versioning-sdk-msbuild-vs.md)
  - Add preview SDK table
  - Formalize versioning support policy
- [Upgrade a WCF Server-side Project to use CoreWCF on .NET 6](../core/porting/upgrade-assistant-wcf.md) - Add documentation for CoreWCF extension on Upgrade Assistant
- [.NET RID Catalog](../core/rid-catalog.md) - Add iOS and Android RIDs
- [Runtime configuration options for threading](../core/runtime-config/threading.md) - Document a new config switch added to the portable thread pool
- [MSBuild reference for .NET SDK projects](../core/project-sdk/msbuild-props.md)
  - Add three new properties
  - Add docs for project properties that control PDBs and XML publishing
  - Update the documentation for PublishRelease and PackRelease
  - Add DisableTransitiveProjectReferences
  - Cleanup trimming options and document TrimMode=full,partial
  - Document new PublishRelease and PackRelease properties
- [Manage package dependencies in .NET applications](../core/tools/dependencies.md) - Add three new properties
- [.NET default templates for dotnet new](../core/tools/dotnet-new-sdk-templates.md) - Added the two new Blazor empty templates
- [.NET SDK and .NET CLI telemetry](../core/tools/telemetry.md)
  - Add the PublishProtocol property to the list of telemetry data disclosures
  - document SDK telemetry from prior and upcoming versions
- [dotnet new install](../core/tools/dotnet-new-install.md) - New syntax for `dotnet new`
- [dotnet new list](../core/tools/dotnet-new-list.md) - New syntax for `dotnet new`
- [dotnet new search](../core/tools/dotnet-new-search.md) - New syntax for `dotnet new`
- [dotnet new uninstall](../core/tools/dotnet-new-uninstall.md) - New syntax for `dotnet new`
- [dotnet new update](../core/tools/dotnet-new-update.md) - New syntax for `dotnet new`
- [dotnet new &lt;TEMPLATE&gt;](../core/tools/dotnet-new.md) - New syntax for `dotnet new`
- [dotnet restore](../core/tools/dotnet-restore.md) - Document .NET 7 SDK changes to NuGet signed package verification
- [dotnet publish](../core/tools/dotnet-publish.md) - Document Publish UseCurrentRuntime
- [dotnet build](../core/tools/dotnet-build.md) - Document UseCurrentRuntime
- [dotnet watch](../core/tools/dotnet-watch.md) - Note that --non-interactive is .NET 7
- [dotnet nuget sign](../core/tools/dotnet-nuget-sign.md) - Document .NET 7 SDK changes to NuGet signed package verification
- [dotnet nuget trust](../core/tools/dotnet-nuget-trust.md) - Document .NET 7 SDK changes to NuGet signed package verification
- [dotnet nuget verify](../core/tools/dotnet-nuget-verify.md) - Document .NET 7 SDK changes to NuGet signed package verification
- [.NET SDK error list](../core/tools/sdk-errors/index.md)
  - Add new errors/warnings to NETSDK error index
  - Document selected NETSDK error messages
  - List of NETSDK error messages
- [NETSDK1100: Set the EnableWindowsTargeting property to true](../core/tools/sdk-errors/netsdk1100.md)
  - Add three new properties
  - Document selected NETSDK error messages
- [dotnet-coverage code coverage utility](../core/additional-tools/dotnet-coverage.md) - Adding new options and example scenarios
- [.NET additional tools overview](../core/additional-tools/index.md) - Add dotnet-monitor .NET tool documentation
- [Diagnostics client library](../core/diagnostics/diagnostics-client-library.md) - Add dotnet-monitor .NET tool documentation
- [Collect diagnostics in containers](../core/diagnostics/diagnostics-in-containers.md) - Add dotnet-monitor .NET tool documentation
- [What diagnostic tools are available in .NET Core?](../core/diagnostics/index.md) - Add dotnet-monitor .NET tool documentation
- [Source-generator diagnostics in .NET 6+](../fundamentals/syslib-diagnostics/source-generator-overview.md) - Add SYSLIB diagnostics for .NET 7 source generators
- [Obsolete features in .NET 5+](../fundamentals/syslib-diagnostics/obsoletions-overview.md)
  - Add two new SYSLIB warnings
  - XmlSecureResolver breaking change
  - Add SYSLIB0041
  - Add SYSLIB0040
  - Add syslib0038 and syslib0039
- [SYSLIB0012: Assembly.CodeBase and Assembly.EscapedCodeBase are obsolete](../fundamentals/syslib-diagnostics/syslib0012.md) - Add two new SYSLIB warnings
- [SYSLIB0043: ECDiffieHellmanPublicKey.ToByteArray is obsolete](../fundamentals/syslib-diagnostics/syslib0043.md)
  - XmlSecureResolver breaking change
  - Add SYSLIB0041
- [Code quality rules](../fundamentals/code-analysis/quality-rules/index.md)
  - Add docs for CA2019 and CA2259
  - Add docs for CA1420 and CA1422
  - Add doc for CA2260
  - Add documentation for rule CA1854
  - Add document for CA1851
- [Reliability rules](../fundamentals/code-analysis/quality-rules/reliability-warnings.md) - Add docs for CA2019 and CA2259
- [Usage rules](../fundamentals/code-analysis/quality-rules/usage-warnings.md)
  - Add docs for CA2019 and CA2259
  - Add doc for CA2260
- [CA1416: Validate platform compatibility](../fundamentals/code-analysis/quality-rules/ca1416.md) - Add docs for CA1420 and CA1422
- [CA1418: Validate platform compatibility](../fundamentals/code-analysis/quality-rules/ca1418.md) - Add docs for CA1420 and CA1422
- [Portability and interoperability rules](../fundamentals/code-analysis/quality-rules/interoperability-warnings.md) - Add docs for CA1420 and CA1422
- [Code-style rule options](../fundamentals/code-analysis/code-style-rule-options.md) - Add missing code-style rules
- [Use local function instead of lambda (IDE0039)](../fundamentals/code-analysis/style-rules/ide0039.md) - Add missing code-style rules
- [Code-style rules](../fundamentals/code-analysis/style-rules/index.md)
  - Add missing code-style rules
  - Add IDE0160 and IDE0161.
- [Performance rules](../fundamentals/code-analysis/quality-rules/performance-warnings.md)
  - Add documentation for rule CA1854
  - Add document for CA1851
- [Language rules](../fundamentals/code-analysis/style-rules/language-rules.md)
  - Add missing code-style rules
  - Add IDE0160 and IDE0161.
- [.NET runtime contention events](../fundamentals/diagnostics/runtime-contention-events.md) - Update the doc with the new version of ContentionStart
- [Error codes returned by package validation](../fundamentals/package-validation/diagnostic-ids.md)
  - add docs for diagnostics CP0012 and CP0013
  - add docs for diagnostics CP0010 and CP0011
- [.NET regular expressions](../standard/base-types/regular-expressions.md) - Ported as conceptual article from .NET dev blog: `Regex` enhancements with .NET 7
- [Standard numeric format strings](../standard/base-types/standard-numeric-format-strings.md) - Limit precision to 999,999,999
- [Character encoding in .NET](../standard/base-types/character-encoding-introduction.md) - Write content for UTF-8 string literals for C# 11.
- [Parsing numeric strings in .NET](../standard/base-types/parsing-numeric.md) - Generic math docs
- [Generics in .NET](../standard/generics/index.md) - Generic math docs
- [Generic interfaces in .NET](../standard/generics/interfaces.md) - Generic math docs
- [Runtime libraries overview](../standard/runtime-libraries-overview.md) - New `HttpClient` article
- [Target frameworks in SDK-style projects](../standard/frameworks.md) - Update TFMs for .NET 7
- [Source generation for platform invokes](../standard/native-interop/pinvoke-source-generation.md)
  - Add SYSLIB diagnostics for .NET 7 source generators
  - Custom marshaller tutorial
  - Basic overview of p/invoke source generation
- [Tutorial: Use custom marshallers in source-generated P/Invokes](../standard/native-interop/tutorial-custom-marshaller.md) - Custom marshaller tutorial
- [How to choose reflection or source generation in System.Text.Json](../standard/serialization/system-text-json/source-generation-modes.md) - Source generation for STJ update
- [How to use source generation in System.Text.Json](../standard/serialization/system-text-json/source-generation.md) - Source generation for STJ update
- [How to write custom converters for JSON serialization (marshalling) in .NET](../standard/serialization/system-text-json/converters-how-to.md)
  - Add section on Utf8JsonReader.CopyString
  - Add contract customization article
- [How to use Utf8JsonReader in System.Text.Json](../standard/serialization/system-text-json/use-utf8jsonreader.md) - Add section on Utf8JsonReader.CopyString
- [Compare Newtonsoft.Json to System.Text.Json, and migrate to System.Text.Json](../standard/serialization/system-text-json/migrate-from-newtonsoft.md) - Add contract customization article
- [How to preserve references and handle or ignore circular references in System.Text.Json](../standard/serialization/system-text-json/preserve-references.md) - Add contract customization article
- [How to serialize properties of derived classes with System.Text.Json](../standard/serialization/system-text-json/polymorphism.md) - `System.Text.Json` polymorphism updates for .NET 7

## .NET IoT libraries

### Updated articles

- [Read values from an analog-to-digital converter](../iot/tutorials/adc.md) - Retire the "What's new in C# 8" article
- [Blink an LED](../iot/tutorials/blink-led.md) - Retire the "What's new in C# 8" article
- [Display text on an LCD](../iot/tutorials/lcd-display.md) - Retire the "What's new in C# 8" article
- [Read environmental conditions from a sensor](../iot/tutorials/temp-sensor.md) - Retire the "What's new in C# 8" article

## Architecture guides

### New articles

- [Accessing remote data](../architecture/maui/accessing-remote-data.md)
- [Authentication and Authorization](../architecture/maui/authentication-and-authorization.md)
- [Communicating between loosely coupled components](../architecture/maui/communicating-between-components.md)
- [Configuration management](../architecture/maui/configuration-management.md)
- [Dependency injection](../architecture/maui/dependency-injection.md)
- [Enterprise Application Patterns Using .NET MAUI](../architecture/maui/index.md)
- [Introduction to .NET MAUI](../architecture/maui/introduction.md)
- [Containerized Microservices](../architecture/maui/micro-services.md)
- [Model-View-ViewModel (MVVM)](../architecture/maui/mvvm.md)
- [Navigation](../architecture/maui/navigation.md)
- [Purpose](../architecture/maui/preface.md)
- [Unit testing](../architecture/maui/unit-testing.md)
- [Validation](../architecture/maui/validation.md)

### Updated articles

- [.NET application architecture documentation](../architecture/index.yml) - .NET MAUI eBook

## Azure SDK for .NET

### Updated articles

- [Pagination with the Azure SDK for .NET](../azure/sdk/pagination.md) - Retire the "What's new in C# 8" article

## C# language

### New articles

- [What's new in C# 11](../csharp/whats-new/csharp-11.md)
- [file (C# Reference)](../csharp/language-reference/keywords/file.md)
- [required modifier (C# Reference)](../csharp/language-reference/keywords/required.md)
- [`ref` structure types (C# reference)](../csharp/language-reference/builtin-types/ref-struct.md)
- [Declaration statements](../csharp/language-reference/statements/declarations.md)

### Updated articles

- [Integral numeric types  (C# reference)](../csharp/language-reference/builtin-types/integral-numeric-types.md) - Add updates for numeric IntPtr
- [Built-in reference types (C# reference)](../csharp/language-reference/builtin-types/reference-types.md) - Write content for UTF-8 string literals for C# 11.
- [Structure types (C# reference)](../csharp/language-reference/builtin-types/struct.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [file (C# Reference)](../csharp/language-reference/keywords/file.md) - Language reference updates for `file` scoped types
- [Interface (C# Reference)](../csharp/language-reference/keywords/interface.md)
  - Generic math docs
  - Add information on static virtual interface members
- [required modifier (C# Reference)](../csharp/language-reference/keywords/required.md) - C# 11: required members
- [Bitwise and shift operators (C# reference)](../csharp/language-reference/operators/bitwise-and-shift-operators.md) - Operator updates to support generic math
- [nameof expression (C# reference)](../csharp/language-reference/operators/nameof.md)- Extended nameof parameter scope
- [checked and unchecked statements (C# reference)](../csharp/language-reference/statements/checked-and-unchecked.md) - Publish C# 11 speclets
- [$ - string interpolation (C# reference)](../csharp/language-reference/tokens/interpolated.md) - C# 11 preview features: newlines in string interpolation
- [Access Modifiers (C# Reference)](../csharp/language-reference/keywords/access-modifiers.md) - Language reference updates for `file` scoped types
- [ref (C# Reference)](../csharp/language-reference/keywords/ref.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Assignment operators (C# reference)](../csharp/language-reference/operators/assignment-operator.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Avoid allocations](../csharp//advanced-topics/performance/index.md)
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
  - Add updates for numeric IntPtr
- [+ and += operators (C# reference)](../csharp/language-reference/operators/addition-operator.md) - Write content for UTF-8 string literals for C# 11.
- [Tutorial: Explore C# 11 feature - static virtual members in interfaces](../csharp/whats-new/tutorials/static-virtual-interface-members.md) - Generic math docs
- [Miscellaneous attributes interpreted by the C# compiler](../csharp/language-reference/attributes/general.md) - C# 11: required members
- [Auto-Implemented Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md) - C# 11: required members
- [Fields (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/fields.md) - C# 11: required members
- [How to declare and use read write properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/how-to-declare-and-use-read-write-properties.md) - C# 11: required members
- [How to implement a lightweight class with auto-implemented properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties.md) - C# 11: required members
- [Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/properties.md) - C# 11: required members
- [Using Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/using-properties.md) - C# 11: required members
- [Properties](../csharp/properties.md) - C# 11: required members
- [Constraints on type parameters (C# Programming Guide)](../csharp/programming-guide/generics/constraints-on-type-parameters.md) - Add information on static virtual interface members
- [Generic Interfaces (C# Programming Guide)](../csharp/programming-guide/generics/generic-interfaces.md) - Add information on static virtual interface members
- [Built-in types (C# reference)](../csharp/language-reference/builtin-types/built-in-types.md) - Add updates for numeric `IntPtr`
- [Built-in numeric conversions (C# reference)](../csharp/language-reference/builtin-types/numeric-conversions.md) - Add updates for numeric `IntPtr`
- [Arithmetic operators (C# reference)](../csharp/language-reference/operators/arithmetic-operators.md) - Operator updates to support generic math
- [Determine caller information using attributes interpreted by the C# compiler](../csharp/language-reference/attributes/caller-information.md) - Extended `nameof` parameter scope
- [Attributes for null-state static analysis interpreted by the C# compiler](../csharp/language-reference/attributes/nullable-analysis.md) - Extended `nameof` parameter scope
- [delegate operator (C# reference)](../csharp/language-reference/operators/delegate-operator.md) - Document new method group conversion
- [Generics and Attributes (C# Programming Guide)](../csharp/advanced-topics/reflection-and-attributes/generics-and-attributes.md) - generic attributes are allowed in C# 11

## Microsoft Orleans

### New articles

- [Migrate from Orleans 3.x to 7.0](../orleans/migration-guide.md)

### Updated articles

- [Orleans transactions](../orleans/grains/transactions.md) - Describe new APIs for .NET 7
- [Microsoft Orleans documentation](../orleans/index.yml) - What's new Orleans

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [CollinAlpert](https://github.com/CollinAlpert) - Collin Alpert ![There were 1 pull requests merged by Collin Alpert.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [gleocadie](https://github.com/gleocadie) - Gregory LEOCADIE ![There were 1 pull requests merged by Gregory LEOCADIE.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [michaelstonis](https://github.com/michaelstonis) - Michael Stonis ![There were 1 pull requests merged by Michael Stonis.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
