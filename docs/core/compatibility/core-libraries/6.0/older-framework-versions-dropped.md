---
title: "Breaking change: Older framework versions dropped from packages"
description: Learn about the .NET 6 breaking change in core .NET libraries where older framework versions have been dropped from the core libraries packages.
ms.date: 06/23/2021
---
# Older framework versions dropped from package

Starting with .NET 6, the core libraries packages can no longer be installed into projects whose target framework is older than:

- .NET Framework 4.6.1
- .NET Core 3.1
- .NET Standard 2.0

## Change description

Previously, you were able to upgrade the packages to the latest version, even if you were using them from a framework older than .NET Framework 4.6.1, .NET Core 3.1, or .NET Standard 2.0. Starting in .NET 6, if you're referencing an impacted package from an earlier framework, you can no longer update the referenced package to the latest version.

## Version introduced

.NET 6

## Reason for change

Continuing to build for all frameworks increases the complexity and size of a package. In the past, .NET solved this issue by building only for current frameworks and *harvesting* binaries for older frameworks. Harvesting means that during build, the earlier version of the package is downloaded and the binaries are extracted.

While consuming a harvested binary means that you can always update without worrying that a framework is dropped, it also means that you don't get any bug fixes or new features. In other words, harvested assets can't be serviced. That's hidden from you because you're able to keep updating the package to a later version even though you're consuming the same old binary that's no longer updated.

Starting with .NET 6, .NET no longer performs any form of harvesting to ensure that all shipped assets can be serviced.

## Recommended action

If your project is maintained but not evolving, simply don't upgrade the impacted packages. This is generally not a huge take back because you're already consuming a frozen binary.

If your project is evolving, upgrade it to a later framework version, such as:

- .NET Framework 4.6.1
- .NET Core 3.1
- .NET Standard 2.0

## Affected APIs

The following packages no longer ship old frameworks:

- Microsoft.Extensions.DependencyModel
- Microsoft.Win32.Registry.AccessControl
- Microsoft.Win32.SystemEvents
- System.ComponentModel.Annotations
- System.ComponentModel.Composition
- System.ComponentModel.Composition.Registration
- System.Composition.AttributedModel
- System.Composition.Convention
- System.Composition.Hosting
- System.Composition.Runtime
- System.Composition.TypedParts
- System.Data.Odbc
- System.Diagnostics.DiagnosticSource
- System.Diagnostics.EventLog
- System.Diagnostics.PerformanceCounter
- System.DirectoryServices
- System.DirectoryServices.AccountManagement
- System.DirectoryServices.Protocols
- System.Drawing.Common
- System.IO.Packaging
- System.IO.Pipelines
- System.Management
- System.Net.Http.WinHttpHandler
- System.Reflection.Context
- System.Runtime.Caching
- System.Runtime.CompilerServices.Unsafe
- System.Security.Cryptography.Cng
- System.Security.Cryptography.OpenSsl
- System.Security.Cryptography.Pkcs
- System.Security.Cryptography.ProtectedData
- System.ServiceProcess.ServiceController
- System.Speech
- System.Text.Encoding.CodePages
- System.Text.Encodings.Web
- System.Threading.AccessControl
- System.Threading.Channels

The following packages will no longer be updated because their implementation is now part of the .NET 6 platform:

- Microsoft.Win32.Registry
- System.ComponentModel.Annotations
- System.IO.FileSystem.AccessControl
- System.IO.Pipes.AccessControl
- System.Security.AccessControl
- System.Security.Cryptography.Cng
- System.Security.Cryptography.OpenSsl
- System.Security.Principal.Windows

<!--

### Category

Core .NET libraries

-->
