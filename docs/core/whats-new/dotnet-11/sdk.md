---
title: What's new in the SDK and tooling for .NET 11
description: Learn about the new .NET SDK features introduced in .NET 11.
titleSuffix: ""
ms.date: 05/12/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in the SDK and tooling for .NET 11

This article describes new features and enhancements in the .NET SDK for .NET 11. It was last updated for Preview 4.

## Smaller SDK installers on Linux and macOS

The .NET SDK installer size on Linux and macOS has been reduced by deduplicating assemblies using symbolic links. Duplicate `.dll` and `.exe` files are identified by content hash and replaced with symbolic links pointing to a single copy. This affects tarballs, `.pkg`, `.deb`, and `.rpm` installers.

Analysis found that 35% of the SDK directory consists of duplicate files. On Linux x64, that's 816 files totaling 140 MB on disk (53 MB compressed). By replacing duplicates with symbolic links, the Linux x64 archive drops significantly in size:

| Platform | SDK artifact | .NET 10 size (MB) | .NET 11 Preview 2 size (MB) | Reduction |
|---|---|---|---|---|
| linux-x64 | tarball | 230 | 189 | 17.8% |
| linux-x64 | deb | 164 | 122 | 25.6% |
| linux-x64 | rpm | 165 | 122 | 26.0% |
| linux-x64 | containers | Varies | Varies | 8–17% |

Preview 4 trims the SDK further by skipping crossgen for assemblies that only exist under `DotnetTools/`. Assemblies that also exist outside `DotnetTools/` are still crossgen'd—they get the startup benefit and the duplicate is then removed—but assemblies unique to `DotnetTools/` are left as IL-only. On a `linux-x64` build, this reduces the SDK tarball by an additional 23.6 MB.

Windows deduplication is planned for a future preview.

## Code analyzer improvements

### CA1873: Reduced noise and improved messages

Two improvements were made to [CA1873](../../../fundamentals/code-analysis/quality-rules/ca1873.md) (Avoid potentially expensive logging):

**Reduced false positives:** Property accesses, `GetType()`, `GetHashCode()`, and `GetTimestamp()` calls are no longer flagged. Diagnostics now apply only to Information-level logging and below by default, since warning, error, and critical code paths are rarely hot paths.

**Specific reasons in diagnostic messages:** The diagnostic message now includes why an argument was flagged, helping you prioritize which warnings to address:

```text
// Before
warning CA1873: Evaluation of this argument may be expensive and unnecessary if logging is disabled

// After
warning CA1873: Evaluation of this argument may be expensive and unnecessary if logging is disabled (method invocation)
```

The nine specific reasons are:

- Method invocation
- Object creation
- Array creation
- Boxing conversion
- String interpolation
- Collection expression
- Anonymous object creation
- Await expression
- With expression

### Analyzer bug fixes

| Analyzer | Fix |
|----------|-----|
| [CA1515](../../../fundamentals/code-analysis/quality-rules/ca1515.md) | Fixed false positive when C# extension members are present |
| [CA1034](../../../fundamentals/code-analysis/quality-rules/ca1034.md) | Fixed false positive when C# extension members are present |
| [CA1859](../../../fundamentals/code-analysis/quality-rules/ca1859.md) | Fixed improper handling of default interface implementations |

### AnalysisLevel corrected for .NET 11

Projects with `AnalysisLevel=latest` were incorrectly using .NET 9 analyzer rules instead of the expected .NET 11 rules. This is now fixed.

## New SDK warnings

### NETSDK1235: Custom .nuspec with PackAsTool

A new warning is emitted when a project sets `PackAsTool=true` and specifies a custom `NuspecFile` property. Tool packages require specific layout and identifier conventions that custom `.nuspec` files typically violate:

```text
warning NETSDK1235: .NET Tools do not support using a custom .nuspec file, but the nuspec file 'custom.nuspec' was provided. Remove the NuspecFile property from this project to enable packing it as a .NET Tool.
```

The pack operation still proceeds with a warning to avoid breaking existing projects.

## Solution filter CLI support

`dotnet sln` can now create and edit solution filters (`.slnf`) directly from the CLI. Solution filters let large repositories load or build a subset of projects without changing the main solution. The supported operations mirror the existing `dotnet sln` commands:

```bash
dotnet new slnf --name MyApp.slnf
dotnet sln MyApp.slnf add src/Lib/Lib.csproj
dotnet sln MyApp.slnf list
dotnet sln MyApp.slnf remove src/Lib/Lib.csproj
```

## File-based apps split across files

File-based apps now support an `#:include` directive, so you can move shared helpers into separate files without giving up the file-based workflow:

```csharp
#:include helpers.cs
#:include models/customer.cs

Console.WriteLine(Helpers.FormatOutput(new Customer()));
```

## Pass environment variables with dotnet run

`dotnet run -e KEY=VALUE` passes environment variables to the launched app from the command line, without requiring you to export shell state or edit launch profiles:

```bash
dotnet run -e ASPNETCORE_ENVIRONMENT=Development -e LOG_LEVEL=Debug
```

Environment variables passed this way are available to MSBuild logic as `RuntimeEnvironmentVariable` items.

## dotnet watch improvements

Preview 3 adds several `dotnet watch` improvements for long-running local development loops:

- **Aspire integration:** `dotnet watch` can now integrate with Aspire app hosts, enabling hot-reload workflows across the full Aspire application model.
- **Crash recovery:** When the app crashes, `dotnet watch` automatically relaunches it on the next relevant file change.
- **Windows desktop support:** Ctrl+C handling is improved for Windows desktop apps such as Windows Forms and WPF.

Preview 4 adds device selection for MAUI and mobile projects. After picking a target framework, `dotnet watch` calls the `ComputeAvailableDevices` MSBuild target, auto-selects when there's a single device, and shows an interactive picker with search when there are several. The chosen device flows through to `dotnet build` and the launched `dotnet run` subprocess, including a re-restore when the device requires a `RuntimeIdentifier` not present in the original restore.

To pre-select a device from the command line, use:

```bash
dotnet watch --device <device-id>
```

Preview 4 also fixes several long-standing `dotnet watch` issues:

- The framework selection prompt no longer appears stuck due to two readers both calling `Console.ReadKey()`.
- Ctrl+C and Ctrl+R no longer surface a spurious `WebSocketException` or `ObjectDisposedException` when the WebSocket transport tears down.
- Hot Reload no longer deadlocks on iOS when `UIKitSynchronizationContext` is installed before the startup hook runs.

> [!NOTE]
> `dotnet watch` requires `<MtouchLink>None</MtouchLink>` in the `.csproj` file for iOS Simulator projects. See [dotnet/macios #25295](https://github.com/dotnet/macios/issues/25295).

## Fish shell completions

The fish shell provider previously emitted a one-liner that delegated every completion to a dynamic `dotnet complete` call. The generated script now walks the tokenized command line, emits static completions for subcommands, options, and positional arguments, and falls back to dynamic calls only where required. This matches the behavior of the Bash, Zsh, and PowerShell providers.

## dotnet reference falls back to current directory

`dotnet reference add` and `dotnet reference remove` now fall back to the current directory when no `--project` is supplied, matching the long-standing behavior of `dotnet reference list`:

```bash
cd ClassLib2
dotnet reference add ../ClassLib1/ClassLib1.csproj   # now works without --project
dotnet reference remove ../ClassLib1/ClassLib1.csproj
```

Previously, these commands failed with `Could not find project or directory ''` when run from a directory that contained a project file.

## Launch settings notice moved to stderr

The `Using launch settings from ...` informational message now writes to `stderr` instead of `stdout`. Scripts that capture the standard output of `dotnet run` no longer need to strip this line out.

## Asset Groups for Static Web Assets

The Static Web Assets SDK adds support for **Asset Groups**, a way to declare groups of related assets that share publish, fingerprinting, and endpoint metadata. The related `DefineStaticWebAssetEndpoints` task gains an `AdditionalEndpointDefinitions` parameter, and the glob matcher exposes the captured `**` stem so additional endpoints (for example default-document routes like `/` for `**/index.html`) can be defined declaratively.

This is infrastructure for ASP.NET Core component authors and SDK extension authors. Most app developers see the result indirectly as Razor and Blazor component packages ship cleaner static-asset metadata.

## OpenTelemetry replaces Application Insights for CLI telemetry

The `dotnet` CLI now uses OpenTelemetry (OTel) with Azure Monitor and OTLP exporters for its opt-in telemetry, replacing the previous `Microsoft.ApplicationInsights` dependency. The user-facing behavior is unchanged—the same telemetry is collected with the same opt-out via `DOTNET_CLI_TELEMETRY_OPTOUT`. The motivation is to make the CLI NativeAOT-friendly.

## NativeAOT entry point for the dotnet CLI

To enable near-instant startup for common CLI invocations, Preview 4 lays the groundwork for a NativeAOT-compiled `dotnet` CLI host. The work introduces three layers:

- `dn.exe` — a NativeAOT host that resolves `DOTNET_ROOT` and `hostfxr` and marshals arguments into a NativeAOT shared library. This is for SDK-repository dogfooding, not production usage.
- `dotnet-aot.dll` — a NativeAOT shared library that handles simple commands such as `--version` and `--info` directly, and falls back to the full managed CLI for everything else.
- `dotnet.dll` — the existing managed CLI, with `#if CLI_AOT` conditionals so the same source files can be compiled into both paths.

The goal is near-instant startup for the most common CLI invocations while preserving full functionality for the rest. The new entry point isn't the default `dotnet` binary yet.

## Partial Ready-to-Run for upstack tooling

A new MSBuild property lets upstack tooling (for example, `dotnet/macios` and `dotnet/maui`) declare a list of assemblies to be partially R2R-compiled and excluded from the composite image. The motivating scenario is precompiling generated XAML code in Debug builds to speed up F5 without paying the full crossgen cost for the rest of the app. App developers don't set this property directly—it's a hook the mobile workloads use in their targets.

## Other CLI improvements

- `dotnet format` now accepts `--framework` for multi-targeted projects.
- `dotnet test` in Microsoft Testing Platform (MTP) mode now supports `--artifacts-path`.
- `dotnet tool exec` and `dnx` no longer prompt for an extra approval when running tools.
- `dotnet nuget <subcommand> --help` now correctly forwards to the NuGet CLI's help output instead of falling back to generic help.
- `dotnet publish` no longer removes native DLLs on subsequent runs of single-file publish.

## Breaking changes

.NET 11 includes the following breaking changes in the SDK:

### Mono launch target no longer set automatically

Starting in .NET 11, the .NET SDK no longer automatically sets `mono` as the launch target for .NET Framework apps on Linux. If you rely on Mono for execution, update your launch configuration to specify `mono` explicitly.

For more information, see [Mono launch target no longer set automatically](../../compatibility/sdk/11/mono-launch-target-removed.md).

### Template engine drops netstandard2.0

All template engine projects (`Microsoft.TemplateEngine.Abstractions`, `Core`, `Core.Contracts`, `Edge`, `IDE`, `Orchestrator.RunnableProjects`, `Utils`, and `TemplateLocalizer.Core`) now target only the current .NET minimum, current .NET, and .NET Framework tool current versions. Tools that consume the template engine libraries directly need to retarget. The `dotnet new` CLI is unaffected.

## See also

- [What's new in the .NET 11 runtime](runtime.md)
- [What's new in .NET libraries for .NET 11](libraries.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
