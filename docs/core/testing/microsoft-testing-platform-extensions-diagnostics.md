---
title: Microsoft.Testing.Platform diagnostics extensions
description: Learn about the various Microsoft.Testing.Platform diagnostics extensions and how to use them.
author: evangelink
ms.author: amauryleve
ms.date: 04/10/2024
---

# Diagnostics extensions

This article list and explains all `Microsoft Testing Platform` extensions related to the diagnostics capability.

## Built-in options

The following [platform options](./microsoft-testing-platform-intro.md#options) provide useful information for troubleshooting your test apps:

- `--info`
- `--diagnostic`
- `⁠-⁠-⁠diagnostic-⁠filelogger-⁠synchronouswrite`
- `--diagnostic-verbosity`
- `--diagnostic-output-fileprefix`
- `--diagnostic-output-directory`

You can also enable the diagnostics logs using the environment variables:

| Environment variable name | Description |
|--|--|
| `TESTINGPLATFORM_DIAGNOSTIC` | If set to `1`, enables the diagnostic logging. |
| `TESTINGPLATFORM_DIAGNOSTIC_VERBOSITY` | Defines the verbosity level. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_DIRECTORY` | The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_FILEPREFIX` | The prefix for the log file name. Defaults to `"log_"`. |
| `TESTINGPLATFORM_DIAGNOSTIC_FILELOGGER_SYNCHRONOUSWRITE` | Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution. |

> [!NOTE]
> Environment variables take precedence over the command line arguments.

## Crash dump

This extension allows you to create a crash dump file if the process crashes. This extension is shipped as part of [Microsoft.Testing.Extensions.CrashDump](https://nuget.org/packages/Microsoft.Testing.Extensions.CrashDump) NuGet package.

> [!IMPORTANT]
> The package is shipped with Microsoft .NET library closed-source free to use licensing model.

To configure the crash dump file generation, use the following options:

| Option | Description |
|--|--|
| `--crashdump` | Generates a dump file when the test host process crashes. Supported in .NET 6.0+. |
| `⁠-⁠-⁠crashdump-⁠filename` | Specifies the file name of the dump. |
| `--crashdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps). |

> [!CAUTION]
> The extension isn't compatible with .NET Framework and will be silently ignored. For .NET Framework support, you enable the postmortem debugging with Sysinternals ProcDump. For more information, see [Enabling Postmortem Debugging: Window Sysinternals ProcDump](/windows-hardware/drivers/debugger/enabling-postmortem-debugging#window-sysinternals-procdump). The postmortem debugging solution will also collect process crash information for .NET so you can avoid the use of the extension if you're targeting both .NET and .NET Framework test applications.

## Hang dump

This extension allows you to create a dump file after a given timeout. This extension is shipped as part of [Microsoft.Testing.Extensions.HangDump](https://nuget.org/packages/Microsoft.Testing.Extensions.HangDump) package.

> [!IMPORTANT]
> The package is shipped with Microsoft .NET library closed-source free to use licensing model.

To configure the hang dump file generation, use the following options:

| Option | Description |
|--|--|
| `--hangdump` | Generates a dump file in case the test host process hangs. |
| `-⁠-⁠hangdump-⁠filename` | Specifies the file name of the dump. |
| `--hangdump-timeout` | Specifies the timeout after which the dump is generated. The timeout value is specified in one of the following formats:<br/>`1.5h`, `1.5hour`, `1.5hours`<br/>`90m`, `90min`, `90minute`, `90minutes`<br/>`5400s`, `5400sec`, `5400second`, `5400seconds`. Defaults to `30m` (30 minutes). |
| `--hangdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps). |
