---
title: What's new in the SDK and tooling for .NET 11
description: Learn about the new .NET SDK features introduced in .NET 11.
titleSuffix: ""
ms.date: 09/08/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in the SDK and tooling for .NET 11

This article describes new features and enhancements in the .NET SDK for .NET 11. It was last updated for release candidate 1 (RC 1). You can [download .NET 11 here](https://dotnet.microsoft.com/download/dotnet/11.0).

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
- [File-based apps reuse Native AOT build outputs](#file-based-apps-reuse-native-aot-build-outputs)
- [Pass environment variables with dotnet run](#pass-environment-variables-with-dotnet-run)
- [dotnet watch improvements](#dotnet-watch-improvements)
- [Fish shell completions](#fish-shell-completions)
- [dotnet reference falls back to current directory](#dotnet-reference-falls-back-to-current-directory)
- [dotnet reference support for file-based apps](#dotnet-reference-support-for-file-based-apps)
- [Launch settings notice moved to stderr](#launch-settings-notice-moved-to-stderr)
- [dotnet format limits configuration discovery to included files](#dotnet-format-limits-configuration-discovery-to-included-files)
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

### File-based apps reuse Native AOT build outputs

The Native AOT command-line path can reuse existing build outputs when it runs an unchanged file-based app. Supported cached launches include `dotnet run --file app.cs`, `dotnet run app.cs`, and `dotnet app.cs`. If the cached output doesn't match the current command arguments, the CLI falls back to the managed path.

`dotnet format` also accepts a file-based app:

```console
dotnet format app.cs
```

When a repository enables the SDK artifacts layout, file-based app outputs are placed under that repository's artifacts directory instead of the default per-user cache.

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

### 'dotnet reference' support for file-based apps

`dotnet reference` now supports file-based apps. Use `dotnet reference add --file app.cs <project-path>` to add `#:project` directives directly to your file-based app, and use `dotnet reference list` and `dotnet reference remove` to manage those references.

### Launch settings notice moved to stderr

The "Using launch settings from..." informational message now writes to `stderr` instead of `stdout`. Scripts that capture the standard output of `dotnet run` no longer need to strip this line out.

### dotnet format limits configuration discovery to included files

In folder mode, `dotnet format` now finds `.editorconfig` files by walking the ancestor directories of files that will actually be formatted. It no longer scans unrelated subtrees, such as large `node_modules` directories:

```console
dotnet format whitespace . --folder --include src/App/Program.cs
```

In one monorepo benchmark, formatting one included file improved from 1.09 seconds to 0.55 seconds. Use `.globalconfig`, rather than an `is_global = true` `.editorconfig` in an unrelated subtree, for configuration that must apply globally.

### Other CLI improvements

- `dotnet format` now accepts `--framework` for multi-targeted projects.
- `dotnet test` in Microsoft Testing Platform (MTP) mode now supports `--artifacts-path`.
- `dotnet tool exec` and `dnx` no longer prompt for an extra approval when running tools.
- `dotnet nuget <subcommand> --help` now correctly forwards to the NuGet CLI's help output instead of falling back to generic help.
- `dotnet publish` no longer removes native DLLs on subsequent runs of single-file publish.
- `dotnet new install --prerelease` selects the latest available version, including prerelease versions, when a template package version isn't specified explicitly. An explicit package version, such as `Contoso.Templates@2.0.0-preview.3`, continues to select that exact version.
- Workload operations and `global.json` now detect versions written in the internal NuGet package format and report the corrected user-facing format instead of a package-not-found error.
- The `Configuration` environment variable now supplies the default value for the shared `--configuration`/`-c` CLI options across commands. An explicit command-line option still takes precedence, and empty or whitespace-only environment values are ignored.
- File-based property directives no longer permit `:` in the property name. Replace syntax such as `#:property Foo:Bar=value` with a valid MSBuild property name.

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
- [MSBuild server enabled by default](#msbuild-server-enabled-by-default)
- [Partial Ready-to-Run for upstack tooling](#partial-ready-to-run-for-upstack-tooling)

### NativeAOT entry point for the dotnet CLI

To enable near-instant startup for common CLI invocations, .NET 11 now enables the NativeAOT-compiled `dotnet` CLI host by default. You can opt out by setting `DOTNET_CLI_ENABLEAOT=false`. The managed and NativeAOT parsers share one implementation, so the AOT path parses, validates, and renders `--help` for every command.

Commands that can run entirely without the managed runtime execute natively. Every other command transparently falls back to the managed CLI. The following commands are fully served from the AOT path:

- `dotnet --version`, `dotnet --info`, `dotnet --help`
- `dotnet <command> --help` for every built-in command
- `dotnet --cli-schema`
- `dotnet sln list`, `dotnet sln migrate`, `dotnet sln remove`

Tool and external-command invocations (global tools, PATH commands, app-base commands) now resolve and launch out-of-process from the AOT path as well, skipping the 600–700 ms managed CLI startup for commands like `dotnet ef` or `dotnet dev-certs`.

OpenTelemetry tracing spans are emitted from the AOT path with correct parent/child relationships to the managed CLI spans, enabling end-to-end distributed trace analysis across both hosts.

### MSBuild server enabled by default

The MSBuild server is now enabled by default. This keeps a warm MSBuild worker between CLI invocations, which reduces startup overhead for repeated build and test commands. To opt out, set `DOTNET_CLI_USE_MSBUILD_SERVER=false` or `MSBUILDUSESERVER=0`.

### Partial Ready-to-Run for upstack tooling

A new MSBuild property lets upstack tooling (for example, `dotnet/macios` and `dotnet/maui`) declare a list of assemblies to be partially R2R-compiled and excluded from the composite image. The motivating scenario is precompiling generated XAML code in Debug builds to speed up F5 without paying the full crossgen cost for the rest of the app. App developers don't set this property directly—it's a hook the mobile workloads use in their targets.

## Test improvements

- [dotnet test improvements](#dotnet-test-improvements)
- [dotnet test support for mobile app testing](#dotnet-test-support-for-mobile-app-testing)
- [dotnet test run-level policy options](#dotnet-test-run-level-policy-options)
- [dotnet test support for traversal projects](#dotnet-test-support-for-traversal-projects)
- [dotnet test reporter and artifacts improvements](#dotnet-test-reporter-and-artifacts-improvements)
- [Test templates support xUnit v3 and NUnit on Microsoft.Testing.Platform](#test-templates-support-xunit-v3-and-nunit-on-microsofttestingplatform)

### dotnet test improvements

.NET 11 adds several capabilities to `dotnet test` when running through Microsoft Testing Platform (MTP):

- **`--no-dependencies`**: Skips building project-to-project references, matching the existing `dotnet build --no-dependencies` behavior.
- **`DOTNET_TEST_RUNNER` environment variable**: Selects the test runner without requiring a `global.json` change. Set it to `VSTest` or `Microsoft.Testing.Platform` to override `global.json` for the current session.
- **`--use-current-runtime` / `--ucr`**: Targets the current runtime during restore and build, matching the option already available on `dotnet build` and `dotnet publish`.
- **`--test-modules` exclusion patterns**: Patterns starting with `!` are now treated as excludes, and whitespace between semicolons is trimmed, making YAML-folded CI expressions work correctly.
- **Per-assembly test counts**: The summary line for multi-assembly runs now includes per-assembly counts.
- **Terminal logger arguments**: `--tl`, `--terminallogger`, and `--tlp` are now forwarded to MSBuild instead of being passed as test application arguments.
- **Live display of in-flight tests**: The progress area shows tests that are running, using a new `TestInProgressMessages` IPC event. The panel keeps per-assembly trimming for large parallel runs and is enabled only for interactive ANSI terminals.
- **Two-stage Ctrl+C cancellation**: The first press stops scheduling new test apps and shows a hint; the second press force-kills all child test processes.
- **Protocol 1.1.0 output forwarding**: When the test host supports protocol 1.1.0, stdout/stderr and `IOutputDevice` messages are streamed live through the terminal reporter instead of being shown only on failure.

### dotnet test support for mobile app testing

The Microsoft Testing Platform path for `dotnet test` supports test projects that target Android, iOS, macOS, and Mac Catalyst. For Android and iOS, it can select connected devices, emulators, or simulators. Use `--device` to select a device per target framework, or let `dotnet test` auto-select when only one is available.

The workloads include test project templates for Android (`dotnet new androidtest`), iOS (`dotnet new iostest`), macOS (`dotnet new macostest`), and Mac Catalyst (`dotnet new maccatalysttest`). They use MSTest by default, but you can configure another framework supported by [Microsoft.Testing.Platform](../../testing/microsoft-testing-platform-intro.md#supported-test-frameworks).

`dotnet test -bl` records device selection, deployment, and run-argument builds in one coherent binary log, and `dotnet test` reports the underlying MSBuild errors when deployment or run-argument discovery fails.

### dotnet test run-level policy options

The Microsoft Testing Platform path for `dotnet test` adds options that apply to the complete run rather than to each test application. Place these options before `--`; options after `--` continue to be forwarded to each application.

```console
# Stop the complete run after 90 seconds.
dotnet test --timeout 90s

# Stop after five failed, errored, timed-out, or cancelled results.
dotnet test --maximum-failed-tests 5
```

`--timeout` accepts `ms`, `s`, and `m` suffixes and counts time only while at least one test application is running. A timeout returns exit code 3, while `--maximum-failed-tests` returns exit code 13 when its limit is reached.

For solution and multi-targeted runs, the `--results-directory-layout per-module` option gives every test application a separate output directory, preventing reports with the same relative file name from overwriting one another. The default remains `flat`.

```console
dotnet test --results-directory-layout per-module
```

```text
TestResults/
  MyTests/
    net11.0_x64/
  OtherTests/
    net11.0_x64/
```

When the SDK's artifacts output layout is enabled, MTP test reports, coverage, and diagnostics default to `<ArtifactsPath>/test/<project>/<pivot>`. An explicit `--results-directory` or `--results-directory-layout` still takes precedence.

`dotnet test --nologo` maps to Microsoft.Testing.Platform's `--no-banner` option, and `--no-banner` appears in the command help.

An experimental affected-test workflow is also available through a separately distributed Microsoft.Testing.Platform extension. It can collect a repository's test map and then run only the tests affected by a change. Collection and affected-test selection are mutually exclusive and can't be combined with device testing, parallel modules, or minimum-test policies.

```powershell
$env:DOTNET_CLI_ENABLE_AFFECTED_TESTS = "1"
dotnet test --collect-test-map
dotnet test --affected-tests
```

### dotnet test support for traversal projects

`dotnet test` now supports `Microsoft.Build.Traversal` projects. The SDK recursively expands nested traversal projects, deduplicates diamond references, and honors `Configuration` and `Platform` metadata on project references before executing tests for the aggregated project set.

```console
dotnet test dirs.proj
```

### dotnet test reporter and artifacts improvements

Reporter and artifact handling has been improved for multi-module runs, including expected-versus-actual rendering in failure output, whole-run zero-test verdict logic, and automatic post-processing of compatible test artifacts.

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
- [Platform-native local container runtime selection](#platform-native-local-container-runtime-selection)
- [Reproducible container publishing](#reproducible-container-publishing)
- [TypeScript outputs integrate with Static Web Assets](#typescript-outputs-integrate-with-static-web-assets)
- [MSBuild server and OpenTelemetry environment variables](#msbuild-server-and-opentelemetry-environment-variables)

### Multi-arch container builds with Podman

The SDK's built-in container publishing now supports building multi-architecture container images when using Podman as the container engine. Previously, multi-arch builds required Docker. This unblocks rootless multi-arch workflows on Linux distributions that ship Podman by default.

### Platform-native local container runtime selection

Container publishing now prefers platform-native local runtimes when available: `wslc` on Windows, and `container` on macOS. Docker and Podman remain fallbacks. To force a runtime, set `LocalRegistry` explicitly in your project or publish profile.

### Reproducible container publishing

Publishing the same application more than once could previously produce different container image digests, because timestamps, archive headers, and directory enumeration order varied between builds. Set `SOURCE_DATE_EPOCH` to a stable Unix timestamp so independent publishes of the same inputs produce the same digest:

```bash
dotnet publish /t:PublishContainer \
  -p:ContainerRegistry=registry.example.com \
  -p:SOURCE_DATE_EPOCH="$(git log -1 --pretty=%ct)"
```

Remote registry publishes also check whether the computed image manifest already exists in the destination repository. When it does, the SDK skips processing the layers and configuration while still applying every requested image tag. This optimization is enabled by default; set `ContainerPushNoCache=true` to bypass the manifest-level check. The SDK still checks each layer and configuration blob and doesn't upload blobs that are already present.

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
