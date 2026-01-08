---
title: Microsoft.Testing.Platform diagnostics extensions
description: Learn about the various Microsoft.Testing.Platform diagnostics extensions and how to use them.
author: evangelink
ms.author: amauryleve
ms.date: 04/10/2024
---

# Diagnostics extensions

This article lists and explains all Microsoft.Testing.Platform extensions related to the diagnostics capability.

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

To configure the hang dump file generation, use the following options:

| Option | Description |
|--|--|
| `--hangdump` | Generates a dump file in case the test host process hangs. |
| `-⁠-hangdump-filename` | Specifies the file name of the dump. |
| `--hangdump-timeout` | Specifies the timeout after which the dump is generated. The timeout value is specified in one of the following formats:<br/>`1.5h`, `1.5hour`, `1.5hours`<br/>`90m`, `90min`, `90minute`, `90minutes`<br/>`5400s`, `5400sec`, `5400second`, `5400seconds`. Defaults to `30m` (30 minutes). |
| `--hangdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps). |

### Considerations for macOS

Taking dumps when running on macOS can be problematic. If you found that a dump has started to be taken, but never finishes, in CI environments where you don't have direct access to the machine, this most likely means that macOS showed a popup asking for authentication and is waiting for you to type a password, which is not feasible to do in such environments. The issue might also manifest as an error similar to the following:

```output
[createdump] This failure may be because createdump or the application is not properly signed and entitled.
```

To work around this, there are two options:

- Set `UseAppHost` MSBuild property to false, which will cause the managed assembly to run under `dotnet` instead of the apphost executable. However, this doesn't work for xunit.v3. See [xunit/xunit#3432 GitHub issue](https://github.com/xunit/xunit/issues/3432).
- Apply a workaround similar to the following:

  ```xml
  <Target Name="WorkaroundMacOSDumpIssue" AfterTargets="Build" Condition="$([MSBuild]::IsOSPlatform('OSX')) AND '$(UseAppHost)' != 'false' AND '$(OutputType)' == 'Exe' AND '$(TargetFramework)' != '' AND '$(RunCommand)' != '' AND '$(RunCommand)' != 'dotnet' AND '$(IsTestingPlatformApplication)'=='true'">
    <Exec Command="codesign --sign - --force --entitlements '$(MSBuildThisFileDirectory)mtp-test-entitlements.plist' '$(RunCommand)'" />
  </Target>
  ```

  and the contents of `mtp-test-entitlements.plist` should be:

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
  <plist version="1.0">
      <dict>
      <key>com.apple.security.cs.allow-jit</key>
          <true/>
      <key>com.apple.security.cs.allow-dyld-environment-variables</key>
          <true/>
      <key>com.apple.security.cs.disable-library-validation</key>
          <true/>
      <key>com.apple.security.cs.debugger</key>
          <true/>
      <key>com.apple.security.get-task-allow</key>
          <true/>
      </dict>
  </plist>
  ```

  You can place the `WorkaroundMacOSDumpIssue` MSBuild target in the `Directory.Build.targets` file so that it applies to all projects.
