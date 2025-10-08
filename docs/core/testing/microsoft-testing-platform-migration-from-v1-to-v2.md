---
title: Microsoft.Testing.Platform migration from v1 to v2
description: Learn about migrating to Microsoft.Testing.Platform v2.
author: Youssef1313
ms.author: ygerges
ms.date: 09/23/2025
---

# Migrate from Microsoft.Testing.Platform v1 to Microsoft.Testing.Platform v2

The preview version Microsoft.Testing.Platform v2 is now available. This migration guide explores what's changed in Microsoft.Testing.Platform v2 and how you can migrate to this version.

## Source breaking changes

These are breaking changes that might cause build errors after migration.

### Dropped unsupported target frameworks

Support for target frameworks .NET Core 3.1 to .NET 7 is dropped. The minimum supported .NET version is .NET 8.
This change doesn't affect .NET Framework. .NET Framework 4.6.2 continues to be the minimum supported .NET Framework target.

### Removed obsolete types

The following types were marked obsolete in MTP v1. In MTP v2, they are now removed:

- `ITestApplicationLifecycleCallbacks`: use `ITestHostApplicationLifetime` instead.
- `TestNodeFileArtifact`: use `FileArtifactProperty` instead.
- `KeyValuePairStringProperty`: use `TestMetadataProperty` instead.
- `TestSessionContext.Client`: use `IClientInfo` instead.

This breaking change doesn't affect typical users of test frameworks. It only affects test framework authors and extension authors.

### API signature changes

- A `CancellationToken` parameter was added to `IOutputDevice.DisplayAsync`.
- Methods in `ITestSessionLifetimeHandler` interface are changed to have a `ITestSessionContext` parameter instead of both `SessionUid` and `CancellationToken` parameters.
- `IDataConsumer` is moved from `Microsoft.Testing.Platform.Extensions.TestHost` namespace to `Microsoft.Testing.Platform.Extensions`.

This breaking change doesn't affect typical users of test frameworks. It only affects test framework authors and extension authors.

## Behavior breaking changes

These are breaking changes that might affect the behavior at run time.

### Compatibility with VSTest-based `dotnet test`

The `dotnet test` command has two implementations:

1. VSTest-based implementation: this was the only implementation up to .NET 9 SDK.
2. MTP-based implementation: this was added starting in .NET 10 SDK.

Running MTP test projects with .NET 10 SDK now requires opting-in to the MTP-based `dotnet test` and can no longer be run with the VSTest-based implementation, which was previously enabled by `TestingPlatformDotnetTestSupport` MSBuild property in MTP v1.

### Rename of command-line options

- The `--diagnostic-output-fileprefix` command-line option was renamed to `--diagnostic-file-prefix`.
- The `--diagnostic-filelogger-synchronouswrite` command-line option was renamed to `--diagnostic-synchronous-write`.
