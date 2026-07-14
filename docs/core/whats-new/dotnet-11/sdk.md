---
title: What's new in the SDK and tooling for .NET 11
description: Learn about the new .NET SDK features introduced in .NET 11.
titleSuffix: ""
ms.date: 07/14/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in the SDK and tooling for .NET 11

This article describes new features and enhancements in the .NET SDK for .NET 11. It was last updated for Preview 6.

## SDK footprint

The .NET SDK installer size on Linux and macOS has been reduced by deduplicating assemblies using symbolic links. Duplicate `.dll` and `.exe` files are identified by content hash and replaced with symbolic links pointing to a single copy. This affects tarballs, `.pkg`, `.deb`, and `.rpm` installers.

Analysis found that 35% of the SDK directory consists of duplicate files. On Linux x64, that's 816 files totaling 140 MB on disk (53 MB compressed). By replacing duplicates with symbolic links, the Linux x64 archive drops significantly in size:

| Platform  | SDK artifact | .NET 10 size (MB) | .NET 11 Preview 2 size (MB) | Reduction |
|-----------|--------------|-------------------|-----------------------------|-----------|
| linux-x64 | tarball      | 230               | 189                         | 17.8%     |
| linux-x64 | deb          | 164               | 122                         | 25.6%     |
| linux-x64 | rpm          | 165               | 122                         | 26.0%     |
| linux-x64 | containers   | Varies            | Varies                      | 8–17%     |

The SDK is further trimmed because crossgen is skipped for assemblies that only exist under `DotnetTools/`. Assemblies that also exist outside `DotnetTools/` are still crossgen'd—they get the startup benefit and the duplicate is then removed—but assemblies unique to `DotnetTools/` are left as IL-only. On a `linux-x64` build, this reduces the SDK tarball by an additional 23.6 MB.

Windows deduplication is planned for a future preview.

## Code analysis and warnings

- [Code analyzer improvements](#code-analyzer-improvements)
- [New SDK warnings](#new-sdk-warnings)

### Code analyzer improvements

#### CA1873: Reduced noise and improved messages

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

#### Analyzer bug fixes

| Analyzer                                                              | Fix                                                          |
|-----------------------------------------------------------------------|--------------------------------------------------------------|
| [CA1515](../../../fundamentals/code-analysis/quality-rules/ca1515.md) | Fixed false positive when C# extension members are present   |
| [CA1034](../../../fundamentals/code-analysis/quality-rules/ca1034.md) | Fixed false positive when C# extension members are present   |
| [CA1859](../../../fundamentals/code-analysis/quality-rules/ca1859.md) | Fixed improper handling of default interface implementations |

#### AnalysisLevel corrected for .NET 11

Projects with `AnalysisLevel=latest` were incorrectly using .NET 9 analyzer rules instead of the expected .NET 11 rules. This is now fixed.

### New SDK warnings

#### NETSDK1235: Custom .nuspec with PackAsTool

A new warning is emitted when a project sets `PackAsTool=true` and specifies a custom `NuspecFile` property. Tool packages require specific layout and identifier conventions that custom `.nuspec` files typically violate:

```text
warning NETSDK1235: .NET Tools do not support using a custom .nuspec file, but the nuspec file 'custom.nuspec' was provided. Remove the NuspecFile property from this project to enable packing it as a .NET Tool.
```

The pack operation still proceeds with a warning to avoid breaking existing projects.

## CLI workflow and developer productivity

- [Solution filter CLI support](#solution-filter-cli-support)
- [File-based apps split across files](#file-based-apps-split-across-files)
- [Pass environment variables with dotnet run](#pass-environment-variables-with-dotnet-run)
- [dotnet watch improvements](#dotnet-watch-improvements)
- [Fish shell completions](#fish-shell-completions)
- [dotnet reference falls back to current directory](#dotnet-reference-falls-back-to-current-directory)
- [Launch settings notice moved to stderr](#launch-settings-notice-moved-to-stderr)
- [Other CLI improvements](#other-cli-improvements)

### Solution filter CLI support

`dotnet sln` can now create and edit solution filters (`.slnf`) directly from the CLI. Solution filters let large repositories load or build a subset of projects without changing the main solution. The supported operations mirror the existing `dotnet sln` commands:

```bash
dotnet new slnf --name MyApp.slnf
dotnet sln MyApp.slnf add src/Lib/Lib.csproj
dotnet sln MyApp.slnf list
dotnet sln MyApp.slnf remove src/Lib/Lib.csproj
```

### File-based apps split across files

File-based apps now support an `#:include` directive, so you can move shared helpers into separate files without giving up the file-based workflow:

```csharp
#:include helpers.cs
#:include models/customer.cs

Console.WriteLine(Helpers.FormatOutput(new Customer()));
```

### Pass environment variables with dotnet run

`dotnet run -e KEY=VALUE` passes environment variables to the launched app from the command line, without requiring you to export shell state or edit launch profiles:

```bash
dotnet run -e ASPNETCORE_ENVIRONMENT=Development -e LOG_LEVEL=Debug
```

Environment variables passed this way are available to MSBuild logic as `RuntimeEnvironmentVariable` items.

### dotnet watch improvements

.NET 11 adds several `dotnet watch` improvements for long-running local development loops:

- **Aspire integration:** `dotnet watch` can now integrate with Aspire app hosts, enabling hot-reload workflows across the full Aspire application model.
- **Crash recovery:** When the app crashes, `dotnet watch` automatically relaunches it on the next relevant file change.
- **Windows desktop support:** Ctrl+C handling is improved for Windows desktop apps such as Windows Forms and WPF.

.NET 11 also adds device selection for MAUI and mobile projects. After picking a target framework, `dotnet watch` calls the `ComputeAvailableDevices` MSBuild target, auto-selects when there's a single device, and shows an interactive picker with search when there are several. The chosen device flows through to `dotnet build` and the launched `dotnet run` subprocess, including a re-restore when the device requires a `RuntimeIdentifier` not present in the original restore.

To pre-select a device from the command line, use:

```bash
dotnet watch --device <device-id>
```

The following long-standing `dotnet watch` issues are fixed:

- The framework selection prompt no longer appears stuck due to two readers both calling `Console.ReadKey()`.
- <kbd>Ctrl+C</kbd> and <kbd>Ctrl+R</kbd> no longer surface a spurious `WebSocketException` or `ObjectDisposedException` when the WebSocket transport tears down.
- Hot Reload no longer deadlocks on iOS when `UIKitSynchronizationContext` is installed before the startup hook runs.

> [!NOTE]
> `dotnet watch` requires `<MtouchLink>None</MtouchLink>` in the `.csproj` file for iOS Simulator projects. See [dotnet/macios #25295](https://github.com/dotnet/macios/issues/25295).

### Fish shell completions

The fish shell provider previously emitted a one-liner that delegated every completion to a dynamic `dotnet complete` call. The generated script now walks the tokenized command line, emits static completions for subcommands, options, and positional arguments, and falls back to dynamic calls only where required. This matches the behavior of the Bash, Zsh, and PowerShell providers.

### dotnet reference falls back to current directory

`dotnet reference add` and `dotnet reference remove` now fall back to the current directory when no `--project` is supplied, matching the long-standing behavior of `dotnet reference list`:

```bash
cd ClassLib2
dotnet reference add ../ClassLib1/ClassLib1.csproj   # now works without --project
dotnet reference remove ../ClassLib1/ClassLib1.csproj
```

Previously, these commands failed with `Could not find project or directory ''` when run from a directory that contained a project file.

### Launch settings notice moved to stderr

The "Using launch settings from..." informational message now writes to `stderr` instead of `stdout`. Scripts that capture the standard output of `dotnet run` no longer need to strip this line out.

### Other CLI improvements

- `dotnet format` now accepts `--framework` for multi-targeted projects.
- `dotnet test` in Microsoft Testing Platform (MTP) mode now supports `--artifacts-path`.
- `dotnet tool exec` and `dnx` no longer prompt for an extra approval when running tools.
- `dotnet nuget <subcommand> --help` now correctly forwards to the NuGet CLI's help output instead of falling back to generic help.
- `dotnet publish` no longer removes native DLLs on subsequent runs of single-file publish.

## Web assets and telemetry

- [Asset groups for static web assets](#asset-groups-for-static-web-assets)
- [OpenTelemetry replaces Application Insights for CLI telemetry](#opentelemetry-replaces-application-insights-for-cli-telemetry)

### Asset groups for static web assets

The Static Web Assets SDK adds support for **Asset Groups**, a way to declare groups of related assets that share publish, fingerprinting, and endpoint metadata. The related `DefineStaticWebAssetEndpoints` task gains an `AdditionalEndpointDefinitions` parameter, and the glob matcher exposes the captured `**` stem so additional endpoints (for example default-document routes like `/` for `**/index.html`) can be defined declaratively.

This is infrastructure for ASP.NET Core component authors and SDK extension authors. Most app developers see the result indirectly as Razor and Blazor component packages ship cleaner static-asset metadata.

### OpenTelemetry replaces Application Insights for CLI telemetry

The `dotnet` CLI now uses OpenTelemetry (OTel) with Azure Monitor and OTLP exporters for its opt-in telemetry, replacing the previous `Microsoft.ApplicationInsights` dependency. The user-facing behavior is unchanged—the same telemetry is collected with the same opt-out via `DOTNET_CLI_TELEMETRY_OPTOUT`. The motivation is to make the CLI NativeAOT-friendly.

## CLI architecture

- [NativeAOT entry point for the dotnet CLI](#nativeaot-entry-point-for-the-dotnet-cli)
- [Partial Ready-to-Run for upstack tooling](#partial-ready-to-run-for-upstack-tooling)

### NativeAOT entry point for the dotnet CLI

To enable near-instant startup for common CLI invocations, .NET 11 is laying the groundwork for a NativeAOT-compiled `dotnet` CLI host. Earlier previews packaged the NativeAOT `dotnet-aot` library and gated it behind `DOTNET_CLI_ENABLEAOT=true`. Preview 6 keeps the off-by-default behavior, but unifies the managed and NativeAOT CLI parsers into a single shared implementation, so the AOT fast path now parses, validates, and renders `--help` for every command—not just the small subset it previously handled.

Commands that can run entirely without the managed runtime execute natively. Every other command transparently falls back to the managed CLI. In Preview 6, the following commands are fully served from the AOT path:

- `dotnet --version`, `dotnet --info`, `dotnet --help`
- `dotnet <command> --help` for every built-in command
- `dotnet --cli-schema`
- `dotnet sln list`, `dotnet sln migrate`, `dotnet sln remove`

Tool and external-command invocations (global tools, PATH commands, app-base commands) now resolve and launch out-of-process from the AOT path as well, skipping the 600–700 ms managed CLI startup for commands like `dotnet ef` or `dotnet dev-certs`.

OpenTelemetry tracing spans are emitted from the AOT path with correct parent/child relationships to the managed CLI spans, enabling end-to-end distributed trace analysis across both hosts.

### Partial Ready-to-Run for upstack tooling

A new MSBuild property lets upstack tooling (for example, `dotnet/macios` and `dotnet/maui`) declare a list of assemblies to be partially R2R-compiled and excluded from the composite image. The motivating scenario is precompiling generated XAML code in Debug builds to speed up F5 without paying the full crossgen cost for the rest of the app. App developers don't set this property directly—it's a hook the mobile workloads use in their targets.

## Test improvements

- [dotnet test improvements](#dotnet-test-improvements)
- [Test templates support xUnit v3 and NUnit on Microsoft.Testing.Platform](#test-templates-support-xunit-v3-and-nunit-on-microsofttestingplatform)

### dotnet test improvements

Preview 6 adds several capabilities to `dotnet test` when running through Microsoft Testing Platform (MTP):

- **`--no-dependencies`**: Skips building project-to-project references, matching the existing `dotnet build --no-dependencies` behavior.
- **`DOTNET_TEST_RUNNER` environment variable**: Selects the test runner without requiring a `global.json` change. Set it to `VSTest` or `Microsoft.Testing.Platform` to override `global.json` for the current session.
- **`--use-current-runtime` / `--ucr`**: Targets the current runtime during restore and build, matching the option already available on `dotnet build` and `dotnet publish`.
- **`--test-modules` exclusion patterns**: Patterns starting with `!` are now treated as excludes, and whitespace between semicolons is trimmed, making YAML-folded CI expressions work correctly.
- **Per-assembly test counts**: The summary line for multi-assembly runs now includes per-assembly counts.
- **Terminal logger arguments**: `--tl`, `--terminallogger`, and `--tlp` are now forwarded to MSBuild instead of being passed as test application arguments.
- **Live display of in-flight tests**: The progress area shows tests that are running, using a new `TestInProgressMessages` IPC event. The panel keeps per-assembly trimming for large parallel runs and is enabled only for interactive ANSI terminals.
- **Two-stage Ctrl+C cancellation**: The first press stops scheduling new test apps and shows a hint; the second press force-kills all child test processes.
- **`--device` for MAUI**: Select a device per target framework when running tests for .NET MAUI projects.
- **Protocol 1.1.0 output forwarding**: When the test host supports protocol 1.1.0, stdout/stderr and `IOutputDevice` messages are streamed live through the terminal reporter instead of being shown only on failure.

### Test templates support xUnit v3 and NUnit on Microsoft.Testing.Platform

The built-in `xunit` template adds a `--xunit-version` option. Use `v3` to generate an xUnit v3 project that defaults to Microsoft.Testing.Platform as the runner:

```bash
dotnet new xunit --xunit-version v3
dotnet new xunit --xunit-version v3 --test-runner VSTest
```

The `nunit` template similarly adds a `--test-runner` option to opt in to Microsoft.Testing.Platform:

```bash
dotnet new nunit --test-runner Microsoft.Testing.Platform
```

Both options are available for C#, F#, and VB templates.

## Container and tooling updates

- [Multi-arch container builds with Podman](#multi-arch-container-builds-with-podman)
- [TypeScript outputs integrate with Static Web Assets](#typescript-outputs-integrate-with-static-web-assets)
- [MSBuild server and OpenTelemetry environment variables](#msbuild-server-and-opentelemetry-environment-variables)

### Multi-arch container builds with Podman

The SDK's built-in container publishing now supports building multi-architecture container images when using Podman as the container engine. Previously, multi-arch builds required Docker. This unblocks rootless multi-arch workflows on Linux distributions that ship Podman by default.

### TypeScript outputs integrate with Static Web Assets

Projects that use `Microsoft.TypeScript.MSBuild` in Razor Class Libraries now properly integrate TypeScript compilation outputs with ASP.NET Core Static Web Assets. The new integration hooks TypeScript outputs into the Static Web Assets pipeline after compilation, enabling compression, fingerprinting, and correct rebuild behavior. Previously, rebuild operations could fail because TypeScript outputs were discovered before compilation or stale references persisted after clean.

### MSBuild server and OpenTelemetry environment variables

The `dotnet` CLI no longer suppresses the MSBuild build server when `DOTNET_CLI_USE_MSBUILD_SERVER` is unset. Previously the CLI unconditionally wrote `MSBUILDUSESERVER=0`, overriding any user-set value. Now, if `DOTNET_CLI_USE_MSBUILD_SERVER` is not set, the CLI leaves `MSBUILDUSESERVER` untouched so you can enable the MSBuild server directly.

The OTLP telemetry exporter is now also enabled when any standard OpenTelemetry `OTEL_EXPORTER_OTLP_*` environment variable is present (endpoint, protocol, headers, or timeout—including signal-specific `_TRACES_*` and `_METRICS_*` variants), in addition to the existing `DOTNET_CLI_TELEMETRY_ENABLE_EXPORTER` flag.

## Include DLLs in file-based apps

File-based apps can now include compiled DLL references using `#:include` without a feature flag. The default item-type mapping treats `.dll` files as `Reference` items, so you can reference prebuilt libraries directly:

```csharp
#:include ./libs/MyLibrary.dll

MyLibrary.Helper.DoWork();
```

Additionally, more `#:` directives are now allowed to appear as duplicates across included files when their values match (`#:sdk`, `#:property`, `#:package`), enabling self-contained library files that declare their own dependencies without conflicting when multiple entry points include them.

## See also

- [What's new in the .NET 11 runtime](runtime.md)
- [What's new in .NET libraries for .NET 11](libraries.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
