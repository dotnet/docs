---
title: Microsoft.Testing.Platform crash and hang dumps
description: Learn about the Microsoft.Testing.Platform extensions for collecting crash dumps and hang dumps during test execution.
author: evangelink
ms.author: amauryleve
ms.date: 02/25/2026
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
| `⁠-⁠-⁠crashdump-⁠filename` | Specifies the file name of the dump. |
| `--crashdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps). |

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
| `-⁠-hangdump-filename` | Specifies the file name of the dump. |
| `--hangdump-timeout` | Specifies the duration of no activity after which the dump is generated. The timeout value is specified in one of the following formats:<br/>`1.5h`, `1.5hour`, `1.5hours`<br/>`90m`, `90min`, `90minute`, `90minutes`<br/>`5400s`, `5400sec`, `5400second`, `5400seconds`. Defaults to `30m` (30 minutes). |
| `--hangdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps). |
