---
title: Microsoft.Testing.Platform (MTP) crash and hang dumps
description: Learn about the MTP extensions for collecting crash dumps and hang dumps during test execution.
author: evangelink
ms.author: amauryleve
ms.date: 06/01/2026
ai-usage: ai-assisted
---

# Crash and hang dumps

These features require installing additional NuGet packages, as described in each section.

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), these extensions are auto-registered when you install their NuGet packages — no code changes needed. The manual registration specified in this article is only required if you disabled the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`.

## Crash dump

This extension allows you to create a crash dump file if the process crashes. This extension requires the [Microsoft.Testing.Extensions.CrashDump](https://nuget.org/packages/Microsoft.Testing.Extensions.CrashDump) NuGet package.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.TestHostControllers.AddCrashDumpProvider();
```

### Options

| Option | Description |
|--|--|
| `--crashdump` | Generates a dump file when the test host process crashes. Supported in .NET 6.0+. |
| `--crashdump-filename` | Specifies the file name of the dump. |
| `--crashdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps). |
| `--crash-report` | [Linux/macOS only] Generates a JSON crash report when the test process crashes. Combine with `--crashdump` to also generate a dump file. Requires .NET 7+ when used alone or .NET 6+ when combined with `--crashdump`. Not supported on Windows because the .NET runtime ignores the underlying `DOTNET_EnableCrashReport` and `DOTNET_EnableCrashReportOnly` environment variables on Windows ([dotnet/runtime#80191](https://github.com/dotnet/runtime/issues/80191)). Available in MTP starting with version 2.3.0. |
| `--crash-report-if-supported` | Same as `--crash-report` but silently ignored (with an informational message) on platforms where crash report generation isn't supported. Use this option to keep the same command line across CI matrices that include Windows. Mutually exclusive with `--crash-report`. Available in MTP starting with version 2.3.0. |
| `--crash-sequence` | Controls whether a sequence file listing the tests that started and ended during the test session is generated alongside the crash dump or crash report. The file makes it possible to identify the tests that were running at the time of the crash without inspecting the dump. Valid values are `on` (default; also accepts `true`, `enable`, `1`) or `off` (also accepts `false`, `disable`, `0`). Available in MTP starting with version 2.3.0. |

> [!CAUTION]
> The extension isn't compatible with .NET Framework and will be silently ignored. For .NET Framework support, you enable the postmortem debugging with Sysinternals ProcDump. For more information, see [Enabling Postmortem Debugging: Window Sysinternals ProcDump](/windows-hardware/drivers/debugger/enabling-postmortem-debugging#window-sysinternals-procdump). The postmortem debugging solution will also collect process crash information for .NET so you can avoid the use of the extension if you're targeting both .NET and .NET Framework test applications.

## Hang dump

This extension allows you to create a dump file after a given timeout. This extension requires the [Microsoft.Testing.Extensions.HangDump](https://nuget.org/packages/Microsoft.Testing.Extensions.HangDump) NuGet package.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.TestHostControllers.AddHangDumpProvider();
```

### Options

| Option | Description |
|--|--|
| `--hangdump` | Generates a dump file in case the test host process hangs. |
| `--hangdump-filename` | Specifies the file name of the dump. Supports the following placeholders: `{pname}` (test application name), `{pid}` (process ID), `{asm}` (entry assembly name), `{tfm}` (target framework moniker), `{time}` (timestamp). The legacy `%p` token (process ID) is also supported for backward compatibility. |
| `--hangdump-timeout` | Specifies the duration of no activity after which the dump is generated. The timeout value is specified in one of the following formats:<br/>`1.5h`, `1.5hour`, `1.5hours`<br/>`90m`, `90min`, `90minute`, `90minutes`<br/>`5400s`, `5400sec`, `5400second`, `5400seconds`<br/>`500ms`, `500mil`, `500millisecond`, `500milliseconds`<br/>`1d`, `1day`, `1days`. A bare number (with no suffix) is interpreted as milliseconds. Defaults to `30m` (30 minutes). |
| `--hangdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Full`, `Triage` (not available on .NET Framework), `None`. Defaults to `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps). The `None` value is available in MTP starting with version 2.1.0. |
| `--hangdump-type-if-supported` | Same as `--hangdump-type` but silently falls back (with an informational message) to the closest supported dump type when the requested type isn't available on the current runtime. For example, `Triage` is only supported on .NET (Core) and falls back to `Mini` on .NET Framework. Use this option to keep the same command line across CI matrices that mix .NET (Core) and .NET Framework. Valid values are `Mini`, `Heap`, `Full`, `Triage`, `None`. Mutually exclusive with `--hangdump-type`. Available in MTP starting with version 2.3.0. |
