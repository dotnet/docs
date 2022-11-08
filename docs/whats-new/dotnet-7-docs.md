---
title: ".NET docs: What's new for .NET 7"
description: "What's new in the .NET docs for the .NET 7 release."
ms.date: 11/08/2022
---

# .NET docs: What's new for the .NET 7 release

Welcome to what's new in the .NET docs for the .NET 7 release. This article lists some of the major changes to docs related to .NET feature updates.

## .NET breaking changes

### New articles

- [AuthenticateAsync for remote auth providers](../core/compatibility/aspnet-core/7.0/authenticateasync-anonymous-request.md)
- [BinaryFormatter serialization APIs produce compiler errors](../core/compatibility/core-libraries/7.0/binaryformatter-apis-produce-errors.md)
- [Maximum precision for numeric format strings](../core/compatibility/core-libraries/7.0/max-precision-numeric-format-strings.md)
- [Tracking linked cache entries](../core/compatibility/core-libraries/7.0/memorycache-tracking.md)
- [Library support for older frameworks](../core/compatibility/core-libraries/7.0/old-framework-support.md)
- [SerializationFormat.Binary is obsolete](../core/compatibility/core-libraries/7.0/serializationformat-binary.md)
- [Dynamic X509ChainPolicy verification time](../core/compatibility/cryptography/7.0/x509chainpolicy-verification-time.md)
- [All assemblies trimmed by default](../core/compatibility/deployment/7.0/trim-all-assemblies.md)
- [x86 host path on 64-bit Windows](../core/compatibility/deployment/7.0/x86-host-path.md)
- [ContentRootPath for apps launched by Windows Shell](../core/compatibility/extensions/7.0/contentrootpath-hosted-app.md)
- [Globalization APIs use ICU libraries on Windows Server](../core/compatibility/globalization/7.0/icu-globalization-api.md)
- [Socket.End methods don't throw ObjectDisposedException](../core/compatibility/networking/7.0/socket-end-closed-sockets.md)
- [DataContractSerializer retains sign when deserializing -0](../core/compatibility/serialization/7.0/datacontractserializer-negative-sign.md)
- [XmlSecureResolver is obsolete](../core/compatibility/xml/7.0/xmlsecureresolver-obsolete.md)
- [System.diagnostics entry in app.config](../core/compatibility/configuration/7.0/diagnostics-config-section.md)
- [API obsoletions with default diagnostic ID (.NET 7)](../core/compatibility/core-libraries/7.0/obsolete-apis-with-default-diagnostic.md)
- [System.Runtime.CompilerServices.Unsafe NuGet package](../core/compatibility/core-libraries/7.0/unsafe-package.md)
- [Environment variable prefixes](../core/compatibility/extensions/7.0/environment-variable-prefix.md)
- [Legacy FileStream strategy removed](../core/compatibility/core-libraries/7.0/filestream-compat-switch.md)
- [Time fields on symbolic links](../core/compatibility/core-libraries/7.0/symbolic-link-timestamps.md)
- [ClientWebSocket.ConnectAsync throws new exception](../core/compatibility/networking/7.0/connectasync-argumentexception.md)
- [RuntimeInformation.OSArchitecture under emulation](../core/compatibility/interop/7.0/osarchitecture-emulation.md)
- [Windows Forms obsoletions and warnings (.NET 7)](../core/compatibility/windows-forms/7.0/obsolete-apis.md)
- [Default authentication scheme](../core/compatibility/aspnet-core/7.0/default-authentication-scheme.md)
- [Middleware no longer defers to endpoint with null request delegate](../core/compatibility/aspnet-core/7.0/middleware-null-requestdelegate.md)
- [Kestrel: Default HTTPS binding removed](../core/compatibility/aspnet-core/7.0/https-binding-kestrel.md)
- [IHubClients and IHubCallerClients hide members](../core/compatibility/aspnet-core/7.0/ihubclients-ihubcallerclients.md)
- [MVC's detection of an empty body in model binding changed](../core/compatibility/aspnet-core/7.0/mvc-empty-body-model-binding.md)
- [Event IDs for some Microsoft.AspNetCore.Mvc.Core log messages changed](../core/compatibility/aspnet-core/7.0/microsoft-aspnetcore-mvc-core-log-event-ids.md)
- [Microsoft.Data.SqlClient updated to 4.0.1](../core/compatibility/aspnet-core/7.0/microsoft-data-sqlclient-updated-to-4-0-1.md)
- [API controller actions try to infer parameters from DI](../core/compatibility/aspnet-core/7.0/api-controller-action-parameters-di.md)
- [SignalR Hub methods try to resolve parameters from DI](../core/compatibility/aspnet-core/7.0/signalr-hub-method-parameters-di.md)
- [Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv and libuv.dll removed](../core/compatibility/aspnet-core/7.0/libuv-transport-dll-removed.md)

### Updated articles

- [AuthenticateAsync for remote auth providers](../core/compatibility/aspnet-core/7.0/authenticateasync-anonymous-request.md)
  - Merge .NET 7 release branch into main
  - Remote auth provider breaking change
- [Authentication in WebAssembly apps](../core/compatibility/aspnet-core/7.0/wasm-app-authentication.md) - Merge .NET 7 release branch into main
- [BinaryFormatter serialization APIs produce compiler errors](../core/compatibility/core-libraries/7.0/binaryformatter-apis-produce-errors.md)
  - Merge .NET 7 release branch into main
  - BinaryFormatter APIs obsolete as error
- [Collectible Assembly in non-collectible AssemblyLoadContext](../core/compatibility/core-libraries/7.0/collectible-assemblies.md) - Merge .NET 7 release branch into main
- [Validate CompressionLevel for BrotliStream](../core/compatibility/core-libraries/7.0/compressionlevel-validation.md) - Merge .NET 7 release branch into main
- [C++/CLI projects in Visual Studio](../core/compatibility/core-libraries/7.0/cpluspluscli-compiler-version.md) - Merge .NET 7 release branch into main
- [Equals method behavior change for NaN](../core/compatibility/core-libraries/7.0/equals-nan.md) - Merge .NET 7 release branch into main
- [Maximum precision for numeric format strings](../core/compatibility/core-libraries/7.0/max-precision-numeric-format-strings.md)
  - Merge .NET 7 release branch into main
  - Limit precision to 999,999,999
- [Tracking linked cache entries](../core/compatibility/core-libraries/7.0/memorycache-tracking.md)
  - Merge .NET 7 release branch into main
  - MemoryCache breaking change
- [Library support for older frameworks](../core/compatibility/core-libraries/7.0/old-framework-support.md)
  - Merge .NET 7 release branch into main
  - Library support breaking change
- [Generic type constraint on PatternContext\<T>](../core/compatibility/core-libraries/7.0/patterncontext-generic-constraint.md) - Merge .NET 7 release branch into main
- [Changes to reflection invoke API exceptions](../core/compatibility/core-libraries/7.0/reflection-invoke-exceptions.md)
  - Merge .NET 7 release branch into main
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [SerializationFormat.Binary is obsolete](../core/compatibility/core-libraries/7.0/serializationformat-binary.md)
  - Merge .NET 7 release branch into main
  - Add syslib0038 and syslib0039
- [Decrypting EnvelopedCms doesn't double unwrap](../core/compatibility/cryptography/7.0/decrypt-envelopedcms.md) - Merge .NET 7 release branch into main
- [X500DistinguishedName parsing of friendly names](../core/compatibility/cryptography/7.0/x500-distinguished-names.md) - Merge .NET 7 release branch into main
- [Dynamic X509ChainPolicy verification time](../core/compatibility/cryptography/7.0/x509chainpolicy-verification-time.md)
  - Merge .NET 7 release branch into main
  - X509ChainPolicy verification time
- [MSBuild property `TrimmerDefaultAction` is deprecated](../core/compatibility/deployment/7.0/deprecated-trimmer-default-action.md) - Merge .NET 7 release branch into main
- [Multi-level lookup is disabled](../core/compatibility/deployment/7.0/multilevel-lookup.md) - Merge .NET 7 release branch into main
- [All assemblies trimmed by default](../core/compatibility/deployment/7.0/trim-all-assemblies.md)
  - Merge .NET 7 release branch into main
  - Add trimming breaking change
- [x86 host path on 64-bit Windows](../core/compatibility/deployment/7.0/x86-host-path.md)
  - Merge .NET 7 release branch into main
  - x86 host path on x64/arm64
- [ContentRootPath for apps launched by Windows Shell](../core/compatibility/extensions/7.0/contentrootpath-hosted-app.md)
  - Merge .NET 7 release branch into main
  - ContentRootPath breaking change
- [Globalization APIs use ICU libraries on Windows Server](../core/compatibility/globalization/7.0/icu-globalization-api.md)
  - Merge .NET 7 release branch into main
  - Add ICU breaking change
- [AllowRenegotiation default is false](../core/compatibility/networking/7.0/allowrenegotiation-default.md) - Merge .NET 7 release branch into main
- [Custom ping payloads on Linux](../core/compatibility/networking/7.0/ping-custom-payload-linux.md) - Merge .NET 7 release branch into main
- [Socket.End methods don't throw ObjectDisposedException](../core/compatibility/networking/7.0/socket-end-closed-sockets.md)
  - Merge .NET 7 release branch into main
  - Socket.End* breaking change
- [DataContractSerializer retains sign when deserializing -0](../core/compatibility/serialization/7.0/datacontractserializer-negative-sign.md)
  - Merge .NET 7 release branch into main
  - Note break for .NET 6 servicing
  - DataContractSerializer breaking change
- [Deserialize Version type with leading or trailing whitespace](../core/compatibility/serialization/7.0/deserialize-version-with-whitespace.md) - Merge .NET 7 release branch into main
- [JsonSerializerOptions copy constructor includes JsonSerializerContext](../core/compatibility/serialization/7.0/jsonserializeroptions-copy-constructor.md) - Merge .NET 7 release branch into main
- [Polymorphic serialization for object types](../core/compatibility/serialization/7.0/polymorphic-serialization.md) - Merge .NET 7 release branch into main
- [System.Text.Json source generator fallback](../core/compatibility/serialization/7.0/reflection-fallback.md) - Merge .NET 7 release branch into main
- [XmlSecureResolver is obsolete](../core/compatibility/xml/7.0/xmlsecureresolver-obsolete.md)
  - Merge .NET 7 release branch into main
  - XmlSecureResolver breaking change
- [API obsoletions with non-default diagnostic IDs (.NET 7)](../core/compatibility/core-libraries/7.0/obsolete-apis-with-custom-diagnostics.md)
  - Add two new SYSLIB warnings
  - XmlSecureResolver breaking change
  - Add SYSLIB0041
  - Add SYSLIB0040
  - Add syslib0038 and syslib0039
- [Breaking changes in .NET 7](../core/compatibility/7.0.md)
  - system.diagnostics config entry breaking change
  - .NET 7 obsoletions
  - MemoryCache breaking change
  - Unsafe package breaking change
  - Environment variable prefix breaking change
  - Legacy FileStream mode and symlink breaking changes
  - Networking breaking change
  - Library support breaking change
  - Socket.End* breaking change
  - Remote auth provider breaking change
  - Breaking change for OSArchitecture value
  - WinForms obsoletions breaking change
  - DataContractSerializer breaking change
  - XmlSecureResolver breaking change
  - Limit precision to 999,999,999
  - Add ICU breaking change
  - BinaryFormatter APIs obsolete as error
  - Add trimming breaking change
  - Default auth scheme handling
  - X509ChainPolicy verification time
  - Middleware deferral breaking change
  - Kestrel HTTPS breaking change
  - SignalR breaking change
  - ContentRootPath breaking change
  - x86 host path on x64/arm64
  - ASP.NET Core 7 breaking change for MVC empty body detection
  - ASP.NET Core 7 breaking change for MVC Logger Event IDs
  - Add syslib0038 and syslib0039
  - ASP.NET Core 7 breaking change for Microsoft.Data.SqlClient
  - ASP.NET Core 7 breaking change for API Controller Actions DI
  - ASP.NET Core 7 breaking change for SignalR Hub DI
  - ASP.NET Core 7 breaking change for libuv
- [Changes that affect compatibility](../core/compatibility/index.md) - Retire the "What's new in C# 8" article
- [Breaking changes in .NET 6](../core/compatibility/6.0.md)
  - Note break for .NET 6 servicing
  - XmlSecureResolver breaking change
  - x86 host path on x64/arm64
- [FileStream no longer synchronizes file offset with OS](../core/compatibility/core-libraries/6.0/filestream-doesnt-sync-offset-with-os.md) - Legacy FileStream mode and symlink breaking changes
- [FileStream.Position updates after ReadAsync or WriteAsync completes](../core/compatibility/core-libraries/6.0/filestream-position-updates-after-readasync-writeasync-completion.md) - Legacy FileStream mode and symlink breaking changes
- [Static abstract members declared in interfaces](../core/compatibility/core-libraries/6.0/static-abstract-interface-methods.md)
  - Publish C# 11 speclets
  - Generic math docs
- [Standard numeric format parsing precision](../core/compatibility/core-libraries/6.0/numeric-format-parsing-handles-higher-precision.md) - Limit precision to 999,999,999
- [Globalization APIs use ICU libraries on Windows 10](../core/compatibility/globalization/5.0/icu-globalization-api.md) - Add ICU breaking change
- [BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps](../core/compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete.md)
  - BinaryFormatter APIs obsolete as error
  - Add syslib0038 and syslib0039
- [Breaking changes in .NET Core 3.1](../core/compatibility/3.1.md) - x86 host path on x64/arm64
- [APIs that always throw exceptions on .NET Core and .NET 5+](../core/compatibility/unsupported-apis.md) - Add SYSLIB0041

## .NET Framework

### Updated articles

- [What's new in .NET Framework](../framework/whats-new/index.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.

## .NET fundamentals

### New articles

- [SYSLIB diagnostics for regex source generation](../fundamentals/syslib-diagnostics/syslib1040-1049.md)
- [SYSLIB diagnostics for p/invoke source generation](../fundamentals/syslib-diagnostics/syslib1050-1069.md)
- [SYSLIB diagnostics for JavaScript interop source generation](../fundamentals/syslib-diagnostics/syslib1070-1089.md)
- [.NET regular expression source generators](../standard/base-types/regular-expression-source-generators.md)
- [Source generation for platform invokes](../standard/native-interop/pinvoke-source-generation.md)
- [NuGet signed package verification](../core/tools/nuget-signed-package-verification.md)
- [AuthenticateAsync for remote auth providers](../core/compatibility/aspnet-core/7.0/authenticateasync-anonymous-request.md)
- [BinaryFormatter serialization APIs produce compiler errors](../core/compatibility/core-libraries/7.0/binaryformatter-apis-produce-errors.md)
- [Maximum precision for numeric format strings](../core/compatibility/core-libraries/7.0/max-precision-numeric-format-strings.md)
- [Tracking linked cache entries](../core/compatibility/core-libraries/7.0/memorycache-tracking.md)
- [Library support for older frameworks](../core/compatibility/core-libraries/7.0/old-framework-support.md)
- [SerializationFormat.Binary is obsolete](../core/compatibility/core-libraries/7.0/serializationformat-binary.md)
- [Dynamic X509ChainPolicy verification time](../core/compatibility/cryptography/7.0/x509chainpolicy-verification-time.md)
- [All assemblies trimmed by default](../core/compatibility/deployment/7.0/trim-all-assemblies.md)
- [x86 host path on 64-bit Windows](../core/compatibility/deployment/7.0/x86-host-path.md)
- [ContentRootPath for apps launched by Windows Shell](../core/compatibility/extensions/7.0/contentrootpath-hosted-app.md)
- [Globalization APIs use ICU libraries on Windows Server](../core/compatibility/globalization/7.0/icu-globalization-api.md)
- [Socket.End methods don't throw ObjectDisposedException](../core/compatibility/networking/7.0/socket-end-closed-sockets.md)
- [DataContractSerializer retains sign when deserializing -0](../core/compatibility/serialization/7.0/datacontractserializer-negative-sign.md)
- [XmlSecureResolver is obsolete](../core/compatibility/xml/7.0/xmlsecureresolver-obsolete.md)
- [Rate limit an HTTP handler in .NET](../core/extensions/http-ratelimiter.md)
- [Upgrade a WCF Server-side Project to use CoreWCF on .NET 6](../core/porting/upgrade-assistant-wcf.md)
- [What's new in .NET 7](../core/whats-new/dotnet-7.md)
- [Tutorial: Use custom marshallers in source-generated P/Invokes](../standard/native-interop/tutorial-custom-marshaller.md)
- [SYSLIB0044: AssemblyName.CodeBase and AssemblyName.EscapedCodeBase are obsolete](../fundamentals/syslib-diagnostics/syslib0044.md)
- [SYSLIB0046: ControlledExecution.Run should not be used](../fundamentals/syslib-diagnostics/syslib0046.md)
- [CA2019: `ThreadStatic` fields should not use inline initialization](../fundamentals/code-analysis/quality-rules/ca2019.md)
- [CA2259: Ensure `ThreadStatic` is only used with static fields](../fundamentals/code-analysis/quality-rules/ca2259.md)
- [CA1420: Property, type, or attribute requires runtime marshalling](../fundamentals/code-analysis/quality-rules/ca1420.md)
- [CA1422: Validate platform compatibility - obsoleted APIs](../fundamentals/code-analysis/quality-rules/ca1422.md)
- [System.diagnostics entry in app.config](../core/compatibility/configuration/7.0/diagnostics-config-section.md)
- [.NET SDK error list](../core/tools/sdk-errors/index.md)
- [dotnet workload command](../core/tools/dotnet-workload.md)
- [NETSDK1100: Set the EnableWindowsTargeting property to true](../core/tools/sdk-errors/netsdk1100.md)
- [API obsoletions with default diagnostic ID (.NET 7)](../core/compatibility/core-libraries/7.0/obsolete-apis-with-default-diagnostic.md)
- [Containerize a .NET app with dotnet publish](../core/docker/publish-as-container.md)
- [System.Runtime.CompilerServices.Unsafe NuGet package](../core/compatibility/core-libraries/7.0/unsafe-package.md)
- [Environment variable prefixes](../core/compatibility/extensions/7.0/environment-variable-prefix.md)
- [CA2260: Implement generic math interfaces correctly](../fundamentals/code-analysis/quality-rules/ca2260.md)
- [Legacy FileStream strategy removed](../core/compatibility/core-libraries/7.0/filestream-compat-switch.md)
- [Time fields on symbolic links](../core/compatibility/core-libraries/7.0/symbolic-link-timestamps.md)
- [ClientWebSocket.ConnectAsync throws new exception](../core/compatibility/networking/7.0/connectasync-argumentexception.md)
- [Customize a JSON contract](../standard/serialization/system-text-json/custom-contracts.md)
- [RuntimeInformation.OSArchitecture under emulation](../core/compatibility/interop/7.0/osarchitecture-emulation.md)
- [Windows Forms obsoletions and warnings (.NET 7)](../core/compatibility/windows-forms/7.0/obsolete-apis.md)
- [SYSLIB0043: ECDiffieHellmanPublicKey.ToByteArray is obsolete](../fundamentals/syslib-diagnostics/syslib0043.md)
- [SYSLIB0047: XmlSecureResolver is obsolete](../fundamentals/syslib-diagnostics/syslib0047.md)
- [Introduction to AOT warnings](../core/deploying/native-aot/fixing-warnings.md)
- [IL3050: Avoid calling members annotated with 'RequiresDynamicCodeAttribute' when publishing as native AOT](../core/deploying/native-aot/warnings/il3050.md)
- [IL3051: 'RequiresDynamicCodeAttribute' attribute must be consistently applied on virtual and interface methods](../core/deploying/native-aot/warnings/il3051.md)
- [IL3052: COM interop is not supported with full ahead of time compilation](../core/deploying/native-aot/warnings/il3052.md)
- [IL3053: Assembly produced AOT warnings](../core/deploying/native-aot/warnings/il3053.md)
- [IL3054: Generic expansion to a method or type was aborted due to generic recursion](../core/deploying/native-aot/warnings/il3054.md)
- [IL3055: P/Invoke method declares a parameter with an abstract delegate](../core/deploying/native-aot/warnings/il3055.md)
- [IL3056: `RequiresDynamicCodeAttribute` cannot be placed directly on a static constructor](../core/deploying/native-aot/warnings/il3056.md)
- [Source generation for custom marshalling](../standard/native-interop/custom-marshalling-source-generation.md)
- [Title not found in: #30543](../fundamentals/networking/httpclient.md)
- [System.Threading.Channels library](../core/extensions/channels.md)
- [Generic math](../standard/generics/math.md)
- [Default authentication scheme](../core/compatibility/aspnet-core/7.0/default-authentication-scheme.md)
- [Middleware no longer defers to endpoint with null request delegate](../core/compatibility/aspnet-core/7.0/middleware-null-requestdelegate.md)
- [Title not found in: #30244#30062#29792](../core/deploying/native-aot.md)
- [NETSDK1082: PackageReference to Microsoft.AspNetCore.App is not necessary](../core/tools/sdk-errors/netsdk1082.md)
- [NETSDK1112: The runtime pack was not downloaded](../core/tools/sdk-errors/netsdk1112.md)
- [NETSDK1135: SupportedOSPlatformVersion can't be higher than TargetPlatformVersion](../core/tools/sdk-errors/netsdk1135.md)
- [NETSDK1136: The target framework must be Windows](../core/tools/sdk-errors/netsdk1136.md)
- [NETSDK1137: Don't use the Microsoft.NET.Sdk.WindowsDesktop SDK](../core/tools/sdk-errors/netsdk1137.md)
- [NETSDK1138: The target framework is out of support](../core/tools/sdk-errors/netsdk1138.md)
- [NETSDK1182: Targeting .NET 6.0 or higher in Visual Studio 2019 is not supported](../core/tools/sdk-errors/netsdk1182.md)
- [Prefer 'null' check over type check (IDE0150)](../fundamentals/code-analysis/style-rules/ide0150.md)
- [Simplify property pattern (IDE0170)](../fundamentals/code-analysis/style-rules/ide0170.md)
- [Use tuple to swap values (IDE0180)](../fundamentals/code-analysis/style-rules/ide0180.md)
- [Namespace declaration preferences (IDE0160 and IDE0161)](../fundamentals/code-analysis/style-rules/ide0160-ide0161.md)
- [Kestrel: Default HTTPS binding removed](../core/compatibility/aspnet-core/7.0/https-binding-kestrel.md)
- [IHubClients and IHubCallerClients hide members](../core/compatibility/aspnet-core/7.0/ihubclients-ihubcallerclients.md)
- [Diagnostic monitoring and collection utility (dotnet-monitor)](../core/diagnostics/dotnet-monitor.md)
- [CA1854: Prefer the `IDictionary.TryGetValue(TKey, out TValue)` method](../fundamentals/code-analysis/quality-rules/ca1854.md)
- [SYSLIB0041: Some Rfc2898DeriveBytes constructors are obsolete](../fundamentals/syslib-diagnostics/syslib0041.md)
- [SYSLIB0042: FromXmlString and ToXmlString on ECC types are obsolete](../fundamentals/syslib-diagnostics/syslib0042.md)
- [MVC's detection of an empty body in model binding changed](../core/compatibility/aspnet-core/7.0/mvc-empty-body-model-binding.md)
- [Event IDs for some Microsoft.AspNetCore.Mvc.Core log messages changed](../core/compatibility/aspnet-core/7.0/microsoft-aspnetcore-mvc-core-log-event-ids.md)
- [SYSLIB0040: EncryptionPolicy.NoEncryption and EncryptionPolicy.AllowNoEncryption are obsolete](../fundamentals/syslib-diagnostics/syslib0040.md)
- [SYSLIB0038: SerializationFormat.Binary is obsolete](../fundamentals/syslib-diagnostics/syslib0038.md)
- [SYSLIB0039: SslProtocols.Tls and SslProtocols.Tls11 are obsolete](../fundamentals/syslib-diagnostics/syslib0039.md)
- [CA1851: Possible multiple enumerations of `IEnumerable` collection](../fundamentals/code-analysis/quality-rules/ca1851.md)
- [Microsoft.Data.SqlClient updated to 4.0.1](../core/compatibility/aspnet-core/7.0/microsoft-data-sqlclient-updated-to-4-0-1.md)
- [API controller actions try to infer parameters from DI](../core/compatibility/aspnet-core/7.0/api-controller-action-parameters-di.md)
- [SignalR Hub methods try to resolve parameters from DI](../core/compatibility/aspnet-core/7.0/signalr-hub-method-parameters-di.md)
- [Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv and libuv.dll removed](../core/compatibility/aspnet-core/7.0/libuv-transport-dll-removed.md)

### Updated articles

- [Source-generator diagnostics in .NET 6+](../fundamentals/syslib-diagnostics/source-generator-overview.md) - Add SYSLIB diagnostics for .NET 7 source generators
- [.NET regular expression source generators](../standard/base-types/regular-expression-source-generators.md)
  - Add SYSLIB diagnostics for .NET 7 source generators
  - Ported as conceptual article from .NET dev blog: `Regex` enhancements with .NET 7
- [Source generation for platform invokes](../standard/native-interop/pinvoke-source-generation.md)
  - Add SYSLIB diagnostics for .NET 7 source generators
  - Custom marshaller tutorial
  - Basic overview of p/invoke source generation
- [dotnet nuget sign](../core/tools/dotnet-nuget-sign.md) - Document .NET 7 SDK changes to NuGet signed package verification
- [dotnet nuget trust](../core/tools/dotnet-nuget-trust.md) - Document .NET 7 SDK changes to NuGet signed package verification
- [dotnet nuget verify](../core/tools/dotnet-nuget-verify.md) - Document .NET 7 SDK changes to NuGet signed package verification
- [dotnet restore](../core/tools/dotnet-restore.md) - Document .NET 7 SDK changes to NuGet signed package verification
- [AuthenticateAsync for remote auth providers](../core/compatibility/aspnet-core/7.0/authenticateasync-anonymous-request.md)
  - Merge .NET 7 release branch into main
  - Remote auth provider breaking change
- [Authentication in WebAssembly apps](../core/compatibility/aspnet-core/7.0/wasm-app-authentication.md) - Merge .NET 7 release branch into main
- [BinaryFormatter serialization APIs produce compiler errors](../core/compatibility/core-libraries/7.0/binaryformatter-apis-produce-errors.md)
  - Merge .NET 7 release branch into main
  - BinaryFormatter APIs obsolete as error
- [Collectible Assembly in non-collectible AssemblyLoadContext](../core/compatibility/core-libraries/7.0/collectible-assemblies.md) - Merge .NET 7 release branch into main
- [Validate CompressionLevel for BrotliStream](../core/compatibility/core-libraries/7.0/compressionlevel-validation.md) - Merge .NET 7 release branch into main
- [C++/CLI projects in Visual Studio](../core/compatibility/core-libraries/7.0/cpluspluscli-compiler-version.md) - Merge .NET 7 release branch into main
- [Equals method behavior change for NaN](../core/compatibility/core-libraries/7.0/equals-nan.md) - Merge .NET 7 release branch into main
- [Maximum precision for numeric format strings](../core/compatibility/core-libraries/7.0/max-precision-numeric-format-strings.md)
  - Merge .NET 7 release branch into main
  - Limit precision to 999,999,999
- [Tracking linked cache entries](../core/compatibility/core-libraries/7.0/memorycache-tracking.md)
  - Merge .NET 7 release branch into main
  - MemoryCache breaking change
- [Library support for older frameworks](../core/compatibility/core-libraries/7.0/old-framework-support.md)
  - Merge .NET 7 release branch into main
  - Library support breaking change
- [Generic type constraint on PatternContext\<T>](../core/compatibility/core-libraries/7.0/patterncontext-generic-constraint.md) - Merge .NET 7 release branch into main
- [Changes to reflection invoke API exceptions](../core/compatibility/core-libraries/7.0/reflection-invoke-exceptions.md)
  - Merge .NET 7 release branch into main
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [SerializationFormat.Binary is obsolete](../core/compatibility/core-libraries/7.0/serializationformat-binary.md)
  - Merge .NET 7 release branch into main
  - Add syslib0038 and syslib0039
- [Decrypting EnvelopedCms doesn't double unwrap](../core/compatibility/cryptography/7.0/decrypt-envelopedcms.md) - Merge .NET 7 release branch into main
- [X500DistinguishedName parsing of friendly names](../core/compatibility/cryptography/7.0/x500-distinguished-names.md) - Merge .NET 7 release branch into main
- [Dynamic X509ChainPolicy verification time](../core/compatibility/cryptography/7.0/x509chainpolicy-verification-time.md)
  - Merge .NET 7 release branch into main
  - X509ChainPolicy verification time
- [MSBuild property `TrimmerDefaultAction` is deprecated](../core/compatibility/deployment/7.0/deprecated-trimmer-default-action.md) - Merge .NET 7 release branch into main
- [Multi-level lookup is disabled](../core/compatibility/deployment/7.0/multilevel-lookup.md) - Merge .NET 7 release branch into main
- [All assemblies trimmed by default](../core/compatibility/deployment/7.0/trim-all-assemblies.md)
  - Merge .NET 7 release branch into main
  - Add trimming breaking change
- [x86 host path on 64-bit Windows](../core/compatibility/deployment/7.0/x86-host-path.md)
  - Merge .NET 7 release branch into main
  - x86 host path on x64/arm64
- [ContentRootPath for apps launched by Windows Shell](../core/compatibility/extensions/7.0/contentrootpath-hosted-app.md)
  - Merge .NET 7 release branch into main
  - ContentRootPath breaking change
- [Globalization APIs use ICU libraries on Windows Server](../core/compatibility/globalization/7.0/icu-globalization-api.md)
  - Merge .NET 7 release branch into main
  - Add ICU breaking change
- [AllowRenegotiation default is false](../core/compatibility/networking/7.0/allowrenegotiation-default.md) - Merge .NET 7 release branch into main
- [Custom ping payloads on Linux](../core/compatibility/networking/7.0/ping-custom-payload-linux.md) - Merge .NET 7 release branch into main
- [Socket.End methods don't throw ObjectDisposedException](../core/compatibility/networking/7.0/socket-end-closed-sockets.md)
  - Merge .NET 7 release branch into main
  - Socket.End* breaking change
- [DataContractSerializer retains sign when deserializing -0](../core/compatibility/serialization/7.0/datacontractserializer-negative-sign.md)
  - Merge .NET 7 release branch into main
  - Note break for .NET 6 servicing
  - DataContractSerializer breaking change
- [Deserialize Version type with leading or trailing whitespace](../core/compatibility/serialization/7.0/deserialize-version-with-whitespace.md) - Merge .NET 7 release branch into main
- [JsonSerializerOptions copy constructor includes JsonSerializerContext](../core/compatibility/serialization/7.0/jsonserializeroptions-copy-constructor.md) - Merge .NET 7 release branch into main
- [Polymorphic serialization for object types](../core/compatibility/serialization/7.0/polymorphic-serialization.md) - Merge .NET 7 release branch into main
- [System.Text.Json source generator fallback](../core/compatibility/serialization/7.0/reflection-fallback.md) - Merge .NET 7 release branch into main
- [XmlSecureResolver is obsolete](../core/compatibility/xml/7.0/xmlsecureresolver-obsolete.md)
  - Merge .NET 7 release branch into main
  - XmlSecureResolver breaking change
- [Prepare .NET libraries for trimming](../core/deploying/trimming/prepare-libraries-for-trimming.md)
  - Merge .NET 7 release branch into main
  - Update trimming libraries docs
- [Rate limit an HTTP handler in .NET](../core/extensions/http-ratelimiter.md)
  - Merge .NET 7 release branch into main
  - New `RateLimiter` article showing a custom HTTP handler
- [Overview of the .NET Upgrade Assistant](../core/porting/upgrade-assistant-overview.md) - Merge .NET 7 release branch into main
- [Upgrade a WCF Server-side Project to use CoreWCF on .NET 6](../core/porting/upgrade-assistant-wcf.md)
  - Merge .NET 7 release branch into main
  - Add documentation for CoreWCF extension on Upgrade Assistant
- [MSBuild reference for .NET SDK projects](../core/project-sdk/msbuild-props.md)
  - Merge .NET 7 release branch into main
  - Add three new properties
  - Add docs for project properties that control PDBs and XML publishing
  - Update the documentation for PublishRelease and PackRelease
  - Add DisableTransitiveProjectReferences
  - Cleanup trimming options and document TrimMode=full,partial
  - Document new PublishRelease and PackRelease properties
- [How to enable tab completion for the .NET CLI](../core/tools/enable-tab-autocomplete.md) - Merge .NET 7 release branch into main
- [What's new in .NET 6](../core/whats-new/dotnet-6.md) - Merge .NET 7 release branch into main
- [Overview of .NET source code analysis](../fundamentals/code-analysis/overview.md) - Merge .NET 7 release branch into main
- [.NET documentation](../fundamentals/index.yml) - Merge .NET 7 release branch into main
- [Target frameworks in SDK-style projects](../standard/frameworks.md)
  - Merge .NET 7 release branch into main
  - Update TFMs for .NET 7
- [Tutorial: Use custom marshallers in source-generated P/Invokes](../standard/native-interop/tutorial-custom-marshaller.md)
  - Merge .NET 7 release branch into main
  - Custom marshaller tutorial
- [.NET Standard](../standard/net-standard.md) - Merge .NET 7 release branch into main
- [API obsoletions with non-default diagnostic IDs (.NET 7)](../core/compatibility/core-libraries/7.0/obsolete-apis-with-custom-diagnostics.md)
  - Add two new SYSLIB warnings
  - XmlSecureResolver breaking change
  - Add SYSLIB0041
  - Add SYSLIB0040
  - Add syslib0038 and syslib0039
- [Obsolete features in .NET 5+](../fundamentals/syslib-diagnostics/obsoletions-overview.md)
  - Add two new SYSLIB warnings
  - XmlSecureResolver breaking change
  - Add SYSLIB0041
  - Add SYSLIB0040
  - Add syslib0038 and syslib0039
- [SYSLIB0012: Assembly.CodeBase and Assembly.EscapedCodeBase are obsolete](../fundamentals/syslib-diagnostics/syslib0012.md) - Add two new SYSLIB warnings
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
- [Breaking changes in .NET 7](../core/compatibility/7.0.md)
  - system.diagnostics config entry breaking change
  - .NET 7 obsoletions
  - MemoryCache breaking change
  - Unsafe package breaking change
  - Environment variable prefix breaking change
  - Legacy FileStream mode and symlink breaking changes
  - Networking breaking change
  - Library support breaking change
  - Socket.End* breaking change
  - Remote auth provider breaking change
  - Breaking change for OSArchitecture value
  - WinForms obsoletions breaking change
  - DataContractSerializer breaking change
  - XmlSecureResolver breaking change
  - Limit precision to 999,999,999
  - Add ICU breaking change
  - BinaryFormatter APIs obsolete as error
  - Add trimming breaking change
  - Default auth scheme handling
  - X509ChainPolicy verification time
  - Middleware deferral breaking change
  - Kestrel HTTPS breaking change
  - SignalR breaking change
  - ContentRootPath breaking change
  - x86 host path on x64/arm64
  - ASP.NET Core 7 breaking change for MVC empty body detection
  - ASP.NET Core 7 breaking change for MVC Logger Event IDs
  - Add syslib0038 and syslib0039
  - ASP.NET Core 7 breaking change for Microsoft.Data.SqlClient
  - ASP.NET Core 7 breaking change for API Controller Actions DI
  - ASP.NET Core 7 breaking change for SignalR Hub DI
  - ASP.NET Core 7 breaking change for libuv
- [Changes that affect compatibility](../core/compatibility/index.md) - Retire the "What's new in C# 8" article
- [What's new in .NET Core 3.0](../core/whats-new/dotnet-core-3-0.md) - Retire the "What's new in C# 8" article
- [Implement a DisposeAsync method](../standard/garbage-collection/implementing-disposeasync.md) - Retire the "What's new in C# 8" article
- [Using objects that implement IDisposable](../standard/garbage-collection/using-objects.md) - Retire the "What's new in C# 8" article
- [.NET SDK error list](../core/tools/sdk-errors/index.md)
  - Add new errors/warnings to NETSDK error index
  - Document selected NETSDK error messages
  - List of NETSDK error messages
- [dotnet publish](../core/tools/dotnet-publish.md) - Document Publish UseCurrentRuntime
- [How to choose reflection or source generation in System.Text.Json](../standard/serialization/system-text-json/source-generation-modes.md) - Source generation for STJ update
- [How to use source generation in System.Text.Json](../standard/serialization/system-text-json/source-generation.md) - Source generation for STJ update
- [dotnet build](../core/tools/dotnet-build.md) - Document UseCurrentRuntime
- [Manage package dependencies in .NET applications](../core/tools/dependencies.md) - Add three new properties
- [NETSDK1100: Set the EnableWindowsTargeting property to true](../core/tools/sdk-errors/netsdk1100.md)
  - Add three new properties
  - Document selected NETSDK error messages
- [Breaking changes in .NET 6](../core/compatibility/6.0.md)
  - Note break for .NET 6 servicing
  - XmlSecureResolver breaking change
  - x86 host path on x64/arm64
- [How to write custom converters for JSON serialization (marshalling) in .NET](../standard/serialization/system-text-json/converters-how-to.md)
  - Add section on Utf8JsonReader.CopyString
  - Add contract customization article
- [How to use a JSON document, Utf8JsonReader, and Utf8JsonWriter in System.Text.Json](../standard/serialization/system-text-json/use-dom-utf8jsonreader-utf8jsonwriter.md) - Add section on Utf8JsonReader.CopyString
- [Tutorial: Containerize a .NET app](../core/docker/build-container.md) - Add `dotnet publish` article for .NET 7 containerization support.
- [Configuration providers in .NET](../core/extensions/configuration-providers.md) - Environment variable prefix breaking change
- [FileStream no longer synchronizes file offset with OS](../core/compatibility/core-libraries/6.0/filestream-doesnt-sync-offset-with-os.md) - Legacy FileStream mode and symlink breaking changes
- [FileStream.Position updates after ReadAsync or WriteAsync completes](../core/compatibility/core-libraries/6.0/filestream-position-updates-after-readasync-writeasync-completion.md) - Legacy FileStream mode and symlink breaking changes
- [.NET regular expressions](../standard/base-types/regular-expressions.md) - Ported as conceptual article from .NET dev blog: `Regex` enhancements with .NET 7
- [Use HTTP/3 with HttpClient](../core/extensions/httpclient-http3.md) - Update HTTP/3 support for HttpClient in .NET 7
- [Compare Newtonsoft.Json to System.Text.Json, and migrate to System.Text.Json](../standard/serialization/system-text-json/migrate-from-newtonsoft.md) - Add contract customization article
- [How to preserve references and handle or ignore circular references in System.Text.Json](../standard/serialization/system-text-json/preserve-references.md) - Add contract customization article
- [Static abstract members declared in interfaces](../core/compatibility/core-libraries/6.0/static-abstract-interface-methods.md)
  - Publish C# 11 speclets
  - Generic math docs
- [How to serialize properties of derived classes with System.Text.Json](../standard/serialization/system-text-json/polymorphism.md) - `System.Text.Json` polymorphism updates for .NET 7
- [dotnet watch](../core/tools/dotnet-watch.md) - Note that --non-interactive is .NET 7
- [Overview of .NET, MSBuild, and Visual Studio versioning](../core/porting/versioning-sdk-msbuild-vs.md)
  - Add preview SDK table
  - Formalize versioning support policy
- [SYSLIB0043: ECDiffieHellmanPublicKey.ToByteArray is obsolete](../fundamentals/syslib-diagnostics/syslib0043.md)
  - XmlSecureResolver breaking change
  - Add SYSLIB0041
- [Standard numeric format parsing precision](../core/compatibility/core-libraries/6.0/numeric-format-parsing-handles-higher-precision.md) - Limit precision to 999,999,999
- [Standard numeric format strings](../standard/base-types/standard-numeric-format-strings.md) - Limit precision to 999,999,999
- [Globalization APIs use ICU libraries on Windows 10](../core/compatibility/globalization/5.0/icu-globalization-api.md) - Add ICU breaking change
- [Native AOT Deployment](../core/deploying/native-aot/index.md) - Document AOT analysis warnings
- ['var' preferences (IDE0007 and IDE0008)](../fundamentals/code-analysis/style-rules/ide0007-ide0008.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Work with Buffers in .NET](../standard/io/buffers.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Title not found in: #30912](../standard/serialization/system-text-json-how-to.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Title not found in: #30912](../standard/serialization/system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Character encoding in .NET](../standard/base-types/character-encoding-introduction.md) - Write content for UTF-8 string literals for C# 11.
- [IHttpClientFactory with .NET](../core/extensions/httpclient-factory.md) - New `HttpClient` article
- [Title not found in: #30543](../fundamentals/networking/httpclient-guidelines.md) - New `HttpClient` article
- [Runtime libraries overview](../standard/runtime-libraries-overview.md) - New `HttpClient` article
- [BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps](../core/compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete.md)
  - BinaryFormatter APIs obsolete as error
  - Add syslib0038 and syslib0039
- [.NET runtime contention events](../fundamentals/diagnostics/runtime-contention-events.md) - Update the doc with the new version of ContentionStart
- [.NET default templates for dotnet new](../core/tools/dotnet-new-sdk-templates.md) - Added the two new Blazor empty templates
- [Parsing numeric strings in .NET](../standard/base-types/parsing-numeric.md) - Generic math docs
- [Generics in .NET](../standard/generics/index.md) - Generic math docs
- [Generic interfaces in .NET](../standard/generics/interfaces.md) - Generic math docs
- [Trimming options](../core/deploying/trimming/trimming-options.md) - Cleanup trimming options and document TrimMode=full,partial
- [Title not found in: #30244#30062#29792](../core/deploying/native-aot.md)
  - Document StripSymbols property for native AOT
  - Update native publishing AOT documentation
  - Documenting Native AOT deployment
- [Single-file deployment and executable](../core/deploying/single-file/overview.md) - Update single file incompatibility docs
- [Code-style rule options](../fundamentals/code-analysis/code-style-rule-options.md) - Add missing code-style rules
- [Expression-level preferences](../fundamentals/code-analysis/style-rules/expression-level-preferences.md) - Add missing code-style rules
- [Use local function instead of lambda (IDE0039)](../fundamentals/code-analysis/style-rules/ide0039.md) - Add missing code-style rules
- [Code-style rules](../fundamentals/code-analysis/style-rules/index.md)
  - Add missing code-style rules
  - Add IDE0160 and IDE0161.
- [Language rules](../fundamentals/code-analysis/style-rules/language-rules.md)
  - Add missing code-style rules
  - Add IDE0160 and IDE0161.
- [Null-checking preferences](../fundamentals/code-analysis/style-rules/null-checking-preferences.md) - Add missing code-style rules
- [Pattern matching preferences](../fundamentals/code-analysis/style-rules/pattern-matching-preferences.md) - Add missing code-style rules
- [.NET SDK and .NET CLI telemetry](../core/tools/telemetry.md)
  - Add the PublishProtocol property to the list of telemetry data disclosures
  - document SDK telemetry from prior and upcoming versions
- [Error codes returned by package validation](../fundamentals/package-validation/diagnostic-ids.md)
  - add docs for diagnostics CP0012 and CP0013
  - add docs for diagnostics CP0010 and CP0011
- [Breaking changes in .NET Core 3.1](../core/compatibility/3.1.md) - x86 host path on x64/arm64
- [.NET additional tools overview](../core/additional-tools/index.md) - Add dotnet-monitor .NET tool documentation
- [Diagnostics client library](../core/diagnostics/diagnostics-client-library.md) - Add dotnet-monitor .NET tool documentation
- [Collect diagnostics in containers](../core/diagnostics/diagnostics-in-containers.md) - Add dotnet-monitor .NET tool documentation
- [What diagnostic tools are available in .NET Core?](../core/diagnostics/index.md) - Add dotnet-monitor .NET tool documentation
- [Performance rules](../fundamentals/code-analysis/quality-rules/performance-warnings.md)
  - Add documentation for rule CA1854
  - Add document for CA1851
- [.NET RID Catalog](../core/rid-catalog.md) - Add iOS and Android RIDs
- [Runtime configuration options for threading](../core/runtime-config/threading.md) - Document a new config switch added to the portable thread pool
- [dotnet-coverage code coverage utility](../core/additional-tools/dotnet-coverage.md) - Adding new options and example scenarios
- [APIs that always throw exceptions on .NET Core and .NET 5+](../core/compatibility/unsupported-apis.md) - Add SYSLIB0041
- [dotnet new install](../core/tools/dotnet-new-install.md) - New syntax for `dotnet new`
- [dotnet new list](../core/tools/dotnet-new-list.md) - New syntax for `dotnet new`
- [dotnet new search](../core/tools/dotnet-new-search.md) - New syntax for `dotnet new`
- [dotnet new uninstall](../core/tools/dotnet-new-uninstall.md) - New syntax for `dotnet new`
- [dotnet new update](../core/tools/dotnet-new-update.md) - New syntax for `dotnet new`
- [dotnet new &lt;TEMPLATE&gt;](../core/tools/dotnet-new.md) - New syntax for `dotnet new`
- [Title not found in: #28838](../standard/serialization/system-text-json-configure-options.md) - Document new STJ Options Default property

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

- [file (C# Reference)](../csharp/language-reference/keywords/file.md)
- [required modifier (C# Reference)](../csharp/language-reference/keywords/required.md)
- [`ref` structure types (C# reference)](../csharp/language-reference/builtin-types/ref-struct.md)
- [Declaration statements](../csharp/language-reference/statements/declarations.md)

### Updated articles

- [What's new in C# 11](../csharp/whats-new/csharp-11.md)
  - Merge .NET 7 release branch into main
  - Language reference updates for `file` scoped types
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
  - Write content for UTF-8 string literals for C# 11.
  - Generic math docs
  - C# 11: required members
  - Add information on static virtual interface members
  - Add updates for numeric IntPtr
  - Operator updates to support generic math
  - Extended nameof parameter scope
  - Document new method group conversion
  - C# 11 preview features: newlines in string interpolation
- [Interfaces - define behavior for multiple types](../csharp/fundamentals/types/interfaces.md) - Retire the "What's new in C# 8" article
- [using statement (C# Reference)](../csharp/language-reference/keywords/using-statement.md) - Retire the "What's new in C# 8" article
- [await operator (C# reference)](../csharp/language-reference/operators/await.md) - Retire the "What's new in C# 8" article
- [Member access operators and expressions (C# reference)](../csharp/language-reference/operators/member-access-operators.md) - Retire the "What's new in C# 8" article
- [! (null-forgiving) operator (C# reference)](../csharp/language-reference/operators/null-forgiving.md) - Retire the "What's new in C# 8" article
- [Iteration statements (C# reference)](../csharp/language-reference/statements/iteration-statements.md)
  - Retire the "What's new in C# 8" article
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Nullable reference types](../csharp/nullable-references.md) - Retire the "What's new in C# 8" article
- [How to write to a text file (C# Programming Guide)](../csharp/programming-guide/file-system/how-to-write-to-a-text-file.md) - Retire the "What's new in C# 8" article
- [Tutorial: Update interfaces with default interface methods](../csharp/tutorials/default-interface-methods-versions.md) - Retire the "What's new in C# 8" article
- [Tutorial: Generate and consume async streams using C# and .NET](../csharp/tutorials/generate-consume-asynchronous-stream.md) - Retire the "What's new in C# 8" article
- [Tutorial: Mix functionality in when creating classes using interfaces with default interface methods](../csharp/tutorials/mixins-with-default-interface-methods.md) - Retire the "What's new in C# 8" article
- [Tutorial: Express your design intent more clearly with nullable and non-nullable reference types](../csharp/tutorials/nullable-reference-types.md) - Retire the "What's new in C# 8" article
- [Indices and ranges](../csharp/tutorials/ranges-indexes.md) - Retire the "What's new in C# 8" article
- [The history of C\#](../csharp/whats-new/csharp-version-history.md)
  - Retire the "What's new in C# 8" article
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
  - Operator updates to support generic math
- [Sorry, we don't have specifics on this C# error](../csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-error.md) - add all C# 11 error codes
- [Default values of C# types (C# reference)](../csharp/language-reference/builtin-types/default-values.md) - Publish C# 11 speclets
- [Integral numeric types  (C# reference)](../csharp/language-reference/builtin-types/integral-numeric-types.md)
  - Publish C# 11 speclets
  - Add updates for numeric IntPtr
- [Built-in reference types (C# reference)](../csharp/language-reference/builtin-types/reference-types.md)
  - Publish C# 11 speclets
  - Write content for UTF-8 string literals for C# 11.
- [Structure types (C# reference)](../csharp/language-reference/builtin-types/struct.md)
  - Publish C# 11 speclets
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [file (C# Reference)](../csharp/language-reference/keywords/file.md)
  - Publish C# 11 speclets
  - Language reference updates for `file` scoped types
- [:::no-loc text=interface::: (C# Reference)](../csharp/language-reference/keywords/interface.md)
  - Publish C# 11 speclets
  - Generic math docs
  - Add information on static virtual interface members
- [required modifier (C# Reference)](../csharp/language-reference/keywords/required.md)
  - Publish C# 11 speclets
  - C# 11: required members
- [Bitwise and shift operators (C# reference)](../csharp/language-reference/operators/bitwise-and-shift-operators.md)
  - Publish C# 11 speclets
  - Operator updates to support generic math
- [nameof expression (C# reference)](../csharp/language-reference/operators/nameof.md)
  - Publish C# 11 speclets
  - Extended nameof parameter scope
- [Patterns (C# reference)](../csharp/language-reference/operators/patterns.md)
  - Publish C# 11 speclets
  - Add missing code-style rules
- [checked and unchecked statements (C# reference)](../csharp/language-reference/statements/checked-and-unchecked.md) - Publish C# 11 speclets
- [$ - string interpolation (C# reference)](../csharp/language-reference/tokens/interpolated.md)
  - Publish C# 11 speclets
  - C# 11 preview features: newlines in string interpolation
- [Access Modifiers (C# Reference)](../csharp/language-reference/keywords/access-modifiers.md) - Language reference updates for `file` scoped types
- [C# Keywords](../csharp/language-reference/keywords/index.md)
  - Language reference updates for `file` scoped types
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
  - C# 11: required members
  - Add updates for numeric IntPtr
- [C# Coding Conventions](../csharp/fundamentals/coding-style/coding-conventions.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Overview of classes, structs, and records in C\#](../csharp/fundamentals/object-oriented/index.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Anonymous types](../csharp/fundamentals/types/anonymous-types.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [The C# type system](../csharp/fundamentals/types/index.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Compiler Error CS0269](../csharp/language-reference/compiler-messages/cs0269.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Compiler Error CS1942](../csharp/language-reference/compiler-messages/cs1942.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [async (C# Reference)](../csharp/language-reference/keywords/async.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [from clause (C# Reference)](../csharp/language-reference/keywords/from-clause.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Method Parameters (C# Reference)](../csharp/language-reference/keywords/method-parameters.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [ref (C# Reference)](../csharp/language-reference/keywords/ref.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Assignment operators (C# reference)](../csharp/language-reference/operators/assignment-operator.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [?: operator (C# reference)](../csharp/language-reference/operators/conditional-operator.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [new operator (C# reference)](../csharp/language-reference/operators/new-operator.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Jump statements (C# reference)](../csharp/language-reference/statements/jump-statements.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Query expression basics](../csharp/linq/query-expression-basics.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Write LINQ queries in C\#](../csharp/linq/write-linq-queries.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Methods in C\#](../csharp/methods.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Compiler Error CS0177](../csharp/misc/cs0177.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Compiler Error CS0199](../csharp/misc/cs0199.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Compiler Error CS0206](../csharp/misc/cs0206.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Compiler Error CS0241](../csharp/misc/cs0241.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Compiler Error CS1949](../csharp/misc/cs1949.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Implicitly Typed Arrays (C# Programming Guide)](../csharp/programming-guide/arrays/implicitly-typed-arrays.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [How to use implicitly typed local variables and arrays in a query expression (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/how-to-use-implicitly-typed-local-variables-and-arrays-in-a-query-expression.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Implicitly typed local variables (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Methods (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/methods.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [C# Features That Support LINQ](../csharp/programming-guide/concepts/linq/features-that-support-linq.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [LINQ and Generic Types (C#)](../csharp/programming-guide/concepts/linq/linq-and-generic-types.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Type Relationships in LINQ Query Operations (C#)](../csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Walkthrough: Writing Queries in C# (LINQ)](../csharp/programming-guide/concepts/linq/walkthrough-writing-queries-linq.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Console app](../csharp/tutorials/console-teleprompter.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
- [Write safe and efficient C# code](../csharp/write-safe-efficient-code.md)
  - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.
  - Add updates for numeric IntPtr
- [+ and += operators (C# reference)](../csharp/language-reference/operators/addition-operator.md) - Write content for UTF-8 string literals for C# 11.
- [Tutorial: Explore C# 11 feature - static virtual members in interfaces](../csharp/whats-new/tutorials/static-virtual-interface-members.md) - Generic math docs
- [Miscellaneous attributes interpreted by the C# compiler](../csharp/language-reference/attributes/general.md) - C# 11: required members
- [Auto-Implemented Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md) - C# 11: required members
- [Fields (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/fields.md) - C# 11: required members
- [How to declare and use read write properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/how-to-declare-and-use-read-write-properties.md) - C# 11: required members
- [How to implement a lightweight class with auto-implemented properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties.md) - C# 11: required members
- [Interface Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/interface-properties.md) - C# 11: required members
- [Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/properties.md) - C# 11: required members
- [Restricting Accessor Accessibility (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility.md) - C# 11: required members
- [Using Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/using-properties.md) - C# 11: required members
- [Properties](../csharp/properties.md) - C# 11: required members
- [Constraints on type parameters (C# Programming Guide)](../csharp/programming-guide/generics/constraints-on-type-parameters.md) - Add information on static virtual interface members
- [Generic Interfaces (C# Programming Guide)](../csharp/programming-guide/generics/generic-interfaces.md) - Add information on static virtual interface members
- [Title not found in: #30129](../csharp/whats-new/tutorials/static-abstract-interface-methods.md) - Add information on static virtual interface members
- [namespace](../csharp/language-reference/keywords/namespace.md) - Add IDE0160 and IDE0161.
- [Built-in types (C# reference)](../csharp/language-reference/builtin-types/built-in-types.md) - Add updates for numeric IntPtr
- [Built-in numeric conversions (C# reference)](../csharp/language-reference/builtin-types/numeric-conversions.md) - Add updates for numeric IntPtr
- [What's new in C# 9.0](../csharp/whats-new/csharp-9.md) - Add updates for numeric IntPtr
- [Title not found in: #29794](../csharp/language-reference/keywords/checked-and-unchecked.md) - Operator updates to support generic math
- [Title not found in: #29794](../csharp/language-reference/keywords/checked.md) - Operator updates to support generic math
- [Title not found in: #29794](../csharp/language-reference/keywords/unchecked.md) - Operator updates to support generic math
- [Arithmetic operators (C# reference)](../csharp/language-reference/operators/arithmetic-operators.md) - Operator updates to support generic math
- [Determine caller information using attributes interpreted by the C# compiler](../csharp/language-reference/attributes/caller-information.md) - Extended nameof parameter scope
- [Attributes for null-state static analysis interpreted by the C# compiler](../csharp/language-reference/attributes/nullable-analysis.md) - Extended nameof parameter scope
- [delegate operator (C# reference)](../csharp/language-reference/operators/delegate-operator.md) - Document new method group conversion
- [Generics and Attributes (C# Programming Guide)](../csharp/programming-guide/generics/generics-and-attributes.md) - generic attributes are allowed in C# 11

## F# language

### Updated articles

- [F# docs - get started, tutorials, reference.](../fsharp/index.yml) - Merge .NET 7 release branch into main
- [What's new in F# 6](../fsharp/whats-new/fsharp-6.md)
  - Merge .NET 7 release branch into main
  - Retire the "What's new in C# 8" article
- [What's new in F# 5](../fsharp/whats-new/fsharp-50.md) - Retire the "What's new in C# 8" article

## Home

### Updated articles

- [.NET documentation](index.yml) - Merge .NET 7 release branch into main
- [Welcome to .NET](welcome.md) - Merge .NET 7 release branch into main
- [Windows](zone-pivot-groups.yml) - Merge .NET 7 release branch into main

## Microsoft Orleans

### New articles

- [What's new in Orleans 7.0](../orleans/whats-new-in-orleans.md)

### Updated articles

- [Orleans transactions](../orleans/grains/transactions.md) - Merge .NET 7 release branch into main
- [Microsoft Orleans documentation](../orleans/index.yml) - What is new Orleans

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [CollinAlpert](https://github.com/CollinAlpert) - Collin Alpert ![There were 1 pull requests merged by Collin Alpert.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [gleocadie](https://github.com/gleocadie) - Gregory LEOCADIE ![There were 1 pull requests merged by Gregory LEOCADIE.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [michaelstonis](https://github.com/michaelstonis) - Michael Stonis ![There were 1 pull requests merged by Michael Stonis.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
