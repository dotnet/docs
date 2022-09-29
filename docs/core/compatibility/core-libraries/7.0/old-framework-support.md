---
title: ".NET 7 breaking change: Library support for older frameworks"
description: Learn about the .NET 7 breaking change in core .NET libraries where core libraries packages are no longer supported on some older frameworks.
ms.date: 09/29/2022
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

.NET 7 Preview 1

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

- Microsoft.Bcl.AsyncInterfaces
- Microsoft.Extensions.Caching.Abstractions
- Microsoft.Extensions.Caching.Memory
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.Abstractions
- Microsoft.Extensions.Configuration.Binder
- Microsoft.Extensions.Configuration.CommandLine
- Microsoft.Extensions.Configuration.EnvironmentVariables
- Microsoft.Extensions.Configuration.FileExtensions
- Microsoft.Extensions.Configuration.Ini
- Microsoft.Extensions.Configuration.Json
- Microsoft.Extensions.Configuration.UserSecrets
- Microsoft.Extensions.Configuration.Xml
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.DependencyInjection.Abstractions
- Microsoft.Extensions.DependencyInjection.Specification.Tests
- Microsoft.Extensions.DependencyModel
- Microsoft.Extensions.FileProviders.Abstractions
- Microsoft.Extensions.FileProviders.Composite
- Microsoft.Extensions.FileProviders.Physical
- Microsoft.Extensions.FileSystemGlobbing
- Microsoft.Extensions.Hosting
- Microsoft.Extensions.Hosting.Abstractions
- Microsoft.Extensions.Hosting.Systemd
- Microsoft.Extensions.Hosting.WindowsServices
- Microsoft.Extensions.Http
- Microsoft.Extensions.Logging
- Microsoft.Extensions.Logging.Abstractions
- Microsoft.Extensions.Logging.Configuration
- Microsoft.Extensions.Logging.Console
- Microsoft.Extensions.Logging.Debug
- Microsoft.Extensions.Logging.EventLog
- Microsoft.Extensions.Logging.EventSource
- Microsoft.Extensions.Logging.TraceSource
- Microsoft.Extensions.Options
- Microsoft.Extensions.Options.ConfigurationExtensions
- Microsoft.Extensions.Options.DataAnnotations
- Microsoft.Extensions.Primitives
- Microsoft.NET.WebAssembly.Threading
- Microsoft.NETCore.Platforms
- Microsoft.Win32.Registry.AccessControl
- Microsoft.Win32.SystemEvents
- Microsoft.Windows.Compatibility
- Microsoft.XmlSerializer.Generator
- System.CodeDom
- System.Collections.Immutable
- System.ComponentModel.Composition
- System.ComponentModel.Composition.Registration
- System.Composition
- System.Composition.AttributedModel
- System.Composition.Convention
- System.Composition.Hosting
- System.Composition.Runtime
- System.Composition.TypedParts
- System.Configuration.ConfigurationManager
- System.Data.Odbc
- System.Data.OleDb
- System.Diagnostics.DiagnosticSource
- System.Diagnostics.EventLog
- System.Diagnostics.PerformanceCounter
- System.DirectoryServices
- System.DirectoryServices.AccountManagement
- System.DirectoryServices.Protocols
- System.Drawing.Common
- System.Formats.Asn1
- System.Formats.Cbor
- System.IO.Hashing
- System.IO.Packaging
- System.IO.Pipelines
- System.IO.Ports
- System.Management
- System.Memory.Data
- System.Net.Http.Json
- System.Net.Http.WinHttpHandler
- System.Numerics.Tensors
- System.Reflection.Context
- System.Reflection.Metadata
- System.Reflection.MetadataLoadContext
- System.Resources.Extensions
- System.Runtime.Caching
- System.Runtime.Serialization.Schema
- System.Security.Cryptography.Cose
- System.Security.Cryptography.Pkcs
- System.Security.Cryptography.ProtectedData
- System.Security.Cryptography.Xml
- System.Security.Permissions
- System.ServiceModel.Syndication
- System.ServiceProcess.ServiceController
- System.Speech
- System.Text.Encoding.CodePages
- System.Text.Encodings.Web
- System.Text.Json
- System.Threading.AccessControl
- System.Threading.Channels
- System.Threading.RateLimiting
- System.Threading.Tasks.Dataflow
- System.Windows.Extensions
