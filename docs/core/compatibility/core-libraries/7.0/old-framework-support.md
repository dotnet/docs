---
title: ".NET 7 breaking change: Library support for older frameworks"
description: Learn about the .NET 7 breaking change in core .NET libraries where core libraries packages are no longer supported on some older frameworks.
ms.date: 09/29/2022
ms.topic: article
---
# Library support for older frameworks

Installing the core libraries packages into projects whose target framework is older than the following versions is no longer supported:

- .NET Framework 4.6.2
- .NET 6
- .NET Standard 2.0

## Previous behavior

The latest non-prerelease core libraries packages that were part of the ".NET 6" wave were supported when used from projects targeting .NET Framework 4.6.1 or later, .NET Core 3.1 and later, or .NET Standard 2.0 or later.

## New behavior

.NET 7 core libraries packages are supported for use in projects targeting .NET Framework 4.6.2 and later, .NET 6 and later, or .NET Standard 2.0 or later.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Building packages for all existing frameworks increases the complexity and size of a package. The following frameworks are now out-of-support and we no longer build packages for these frameworks:

- .NET Framework 4.6.1
- .NET Core 3.1
- .NET 5

## Recommended action

- If your project is no longer being evolved and only maintained, simply don't upgrade the impacted packages.
- If your project is actively developed, upgrade it to one of the following frameworks:

  - .NET Framework 4.6.2
  - .NET Core 6
  - .NET Standard 2.0

## Affected APIs

The following packages no longer ship old frameworks:

- [Microsoft.Bcl.AsyncInterfaces](https://www.nuget.org/packages/Microsoft.Bcl.AsyncInterfaces)
- [Microsoft.Extensions.Caching.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Abstractions)
- [Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory)
- [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration)
- [Microsoft.Extensions.Configuration.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Abstractions)
- [Microsoft.Extensions.Configuration.Binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder)
- [Microsoft.Extensions.Configuration.CommandLine](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.CommandLine)
- [Microsoft.Extensions.Configuration.EnvironmentVariables](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables)
- [Microsoft.Extensions.Configuration.FileExtensions](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions)
- [Microsoft.Extensions.Configuration.Ini](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Ini)
- [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json)
- [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets)
- [Microsoft.Extensions.Configuration.Xml](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Xml)
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection)
- [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions)
- [Microsoft.Extensions.DependencyInjection.Specification.Tests](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Specification.Tests)
- [Microsoft.Extensions.DependencyModel](https://www.nuget.org/packages/Microsoft.Extensions.DependencyModel)
- [Microsoft.Extensions.FileProviders.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Abstractions)
- [Microsoft.Extensions.FileProviders.Composite](https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Composite)
- [Microsoft.Extensions.FileProviders.Physical](https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Physical)
- [Microsoft.Extensions.FileSystemGlobbing](https://www.nuget.org/packages/Microsoft.Extensions.FileSystemGlobbing)
- [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting)
- [Microsoft.Extensions.Hosting.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.Abstractions)
- [Microsoft.Extensions.Hosting.Systemd](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.Systemd)
- [Microsoft.Extensions.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices)
- [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)
- [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging)
- [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions)
- [Microsoft.Extensions.Logging.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Configuration)
- [Microsoft.Extensions.Logging.Console](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console)
- [Microsoft.Extensions.Logging.Debug](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug)
- [Microsoft.Extensions.Logging.EventLog](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventLog)
- [Microsoft.Extensions.Logging.EventSource](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventSource)
- [Microsoft.Extensions.Logging.TraceSource](https://www.nuget.org/packages/Microsoft.Extensions.Logging.TraceSource)
- [Microsoft.Extensions.Options](https://www.nuget.org/packages/Microsoft.Extensions.Options)
- [Microsoft.Extensions.Options.ConfigurationExtensions](https://www.nuget.org/packages/Microsoft.Extensions.Options.ConfigurationExtensions)
- [Microsoft.Extensions.Options.DataAnnotations](https://www.nuget.org/packages/Microsoft.Extensions.Options.DataAnnotations)
- [Microsoft.Extensions.Primitives](https://www.nuget.org/packages/Microsoft.Extensions.Primitives)
- [Microsoft.NET.WebAssembly.Threading](https://www.nuget.org/packages/Microsoft.NET.WebAssembly.Threading)
- [Microsoft.NETCore.Platforms](https://www.nuget.org/packages/Microsoft.NETCore.Platforms)
- [Microsoft.Win32.Registry.AccessControl](https://www.nuget.org/packages/Microsoft.Win32.Registry.AccessControl)
- [Microsoft.Win32.SystemEvents](https://www.nuget.org/packages/Microsoft.Win32.SystemEvents)
- [Microsoft.Windows.Compatibility](https://www.nuget.org/packages/Microsoft.Windows.Compatibility)
- [Microsoft.XmlSerializer.Generator](https://www.nuget.org/packages/Microsoft.XmlSerializer.Generator)
- [System.CodeDom](https://www.nuget.org/packages/System.CodeDom)
- [System.Collections.Immutable](https://www.nuget.org/packages/System.Collections.Immutable)
- [System.ComponentModel.Composition](https://www.nuget.org/packages/System.ComponentModel.Composition)
- [System.ComponentModel.Composition.Registration](https://www.nuget.org/packages/System.ComponentModel.Composition.Registration)
- [System.Composition](https://www.nuget.org/packages/System.Composition)
- [System.Composition.AttributedModel](https://www.nuget.org/packages/System.Composition.AttributedModel)
- [System.Composition.Convention](https://www.nuget.org/packages/System.Composition.Convention)
- [System.Composition.Hosting](https://www.nuget.org/packages/System.Composition.Hosting)
- [System.Composition.Runtime](https://www.nuget.org/packages/System.Composition.Runtime)
- [System.Composition.TypedParts](https://www.nuget.org/packages/System.Composition.TypedParts)
- [System.Configuration.ConfigurationManager](https://www.nuget.org/packages/System.Configuration.ConfigurationManager)
- [System.Data.Odbc](https://www.nuget.org/packages/System.Data.Odbc)
- [System.Data.OleDb](https://www.nuget.org/packages/System.Data.OleDb)
- [System.Diagnostics.DiagnosticSource](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource)
- [System.Diagnostics.EventLog](https://www.nuget.org/packages/System.Diagnostics.EventLog)
- [System.Diagnostics.PerformanceCounter](https://www.nuget.org/packages/System.Diagnostics.PerformanceCounter)
- [System.DirectoryServices](https://www.nuget.org/packages/System.DirectoryServices)
- [System.DirectoryServices.AccountManagement](https://www.nuget.org/packages/System.DirectoryServices.AccountManagement)
- [System.DirectoryServices.Protocols](https://www.nuget.org/packages/System.DirectoryServices.Protocols)
- [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common)
- [System.Formats.Asn1](https://www.nuget.org/packages/System.Formats.Asn1)
- [System.Formats.Cbor](https://www.nuget.org/packages/System.Formats.Cbor)
- [System.IO.Hashing](https://www.nuget.org/packages/System.IO.Hashing)
- [System.IO.Packaging](https://www.nuget.org/packages/System.IO.Packaging)
- [System.IO.Pipelines](https://www.nuget.org/packages/System.IO.Pipelines)
- [System.IO.Ports](https://www.nuget.org/packages/System.IO.Ports)
- [System.Management](https://www.nuget.org/packages/System.Management)
- [System.Memory.Data](https://www.nuget.org/packages/System.Memory.Data)
- [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json)
- [System.Net.Http.WinHttpHandler](https://www.nuget.org/packages/System.Net.Http.WinHttpHandler)
- [System.Numerics.Tensors](https://www.nuget.org/packages/System.Numerics.Tensors)
- [System.Reflection.Context](https://www.nuget.org/packages/System.Reflection.Context)
- [System.Reflection.Metadata](https://www.nuget.org/packages/System.Reflection.Metadata)
- [System.Reflection.MetadataLoadContext](https://www.nuget.org/packages/System.Reflection.MetadataLoadContext)
- [System.Resources.Extensions](https://www.nuget.org/packages/System.Resources.Extensions)
- [System.Runtime.Caching](https://www.nuget.org/packages/System.Runtime.Caching)
- [System.Runtime.Serialization.Schema](https://www.nuget.org/packages/System.Runtime.Serialization.Schema)
- [System.Security.Cryptography.Cose](https://www.nuget.org/packages/System.Security.Cryptography.Cose)
- [System.Security.Cryptography.Pkcs](https://www.nuget.org/packages/System.Security.Cryptography.Pkcs)
- [System.Security.Cryptography.ProtectedData](https://www.nuget.org/packages/System.Security.Cryptography.ProtectedData)
- [System.Security.Cryptography.Xml](https://www.nuget.org/packages/System.Security.Cryptography.Xml)
- [System.Security.Permissions](https://www.nuget.org/packages/System.Security.Permissions)
- [System.ServiceModel.Syndication](https://www.nuget.org/packages/System.ServiceModel.Syndication)
- [System.ServiceProcess.ServiceController](https://www.nuget.org/packages/System.ServiceProcess.ServiceController)
- [System.Speech](https://www.nuget.org/packages/System.Speech)
- [System.Text.Encoding.CodePages](https://www.nuget.org/packages/System.Text.Encoding.CodePages)
- [System.Text.Encodings.Web](https://www.nuget.org/packages/System.Text.Encodings.Web)
- [System.Text.Json](https://www.nuget.org/packages/System.Text.Json)
- [System.Threading.AccessControl](https://www.nuget.org/packages/System.Threading.AccessControl)
- [System.Threading.Channels](https://www.nuget.org/packages/System.Threading.Channels)
- [System.Threading.RateLimiting](https://www.nuget.org/packages/System.Threading.RateLimiting)
- [System.Threading.Tasks.Dataflow](https://www.nuget.org/packages/System.Threading.Tasks.Dataflow)
- [System.Windows.Extensions](https://www.nuget.org/packages/System.Windows.Extensions)
