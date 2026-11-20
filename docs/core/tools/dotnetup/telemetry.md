---
title: dotnetup telemetry
description: Learn what usage data dotnetup collects, how to opt out, and how to suppress the first-run notice.
ms.topic: concept-article
ms.date: 09/30/2026
ai-usage: ai-generated
---

# dotnetup telemetry

[!INCLUDE [public-preview](includes/public-preview.md)]

`dotnetup` includes a telemetry feature that collects usage data and sends it
to Microsoft when you run `dotnetup` commands. The usage data includes
exception information when `dotnetup` crashes. The .NET team uses this data to
understand how people use the tool and to fix problems.

## How to opt out

Telemetry is on by default. To opt out, set the `DOTNET_CLI_TELEMETRY_OPTOUT`
environment variable to `1` or `true`.

This is the same variable that turns off telemetry for the .NET SDK and CLI.
For more information, see [.NET SDK and .NET CLI telemetry](../telemetry.md).

## First-run notice

The first time that you run `dotnetup`, it shows this message:

```output
dotnetup collects usage data to help improve your experience. You can opt out by setting the DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1'. Learn more: https://aka.ms/dotnetup-telemetry
```

To hide this notice without turning off telemetry, set the `DOTNET_NOLOGO`
environment variable to `1` or `true`.

## Data points

The telemetry feature doesn't collect personal data, such as usernames or
email addresses. It doesn't scan your code, and it doesn't extract
project-level data. `dotnetup` sends the data securely to Microsoft servers
with [Azure Monitor](https://azure.microsoft.com/services/monitor/)
technology.

`dotnetup` collects the following data:

- The timestamp of the invocation.
- The command that you run, such as `install`, `update`, or `list`.
- The `dotnetup` version and commit SHA.
- The operating system and architecture.
- Whether `dotnetup` runs in a continuous integration (CI) environment.
- Whether `dotnetup` runs from an LLM agent, such as GitHub Copilot.
- The exit code, or the success or failure status.
- For failures: the error type, the error category, sanitized error details
  without file paths, and the stack trace without exception messages.

## Crash exception telemetry

If `dotnetup` crashes, it collects the name of the exception and the stack
trace of the `dotnetup` code. It doesn't include exception messages, because
they can contain user input. This approach is the same as the approach that the
.NET SDK uses. For more information, see
[Crash exception telemetry](../telemetry.md#crash-exception-telemetry).

## CI and LLM agent detection

`dotnetup` uses the same CI environment detection and LLM agent detection as
the .NET SDK. For the list of environment variables that it checks, see
[Continuous integration detection](../telemetry.md#continuous-integration-detection)
and [LLM detection](../telemetry.md#llm-detection).

## Related environment variables

| Variable | Description |
| --- | --- |
| `DOTNET_CLI_TELEMETRY_OPTOUT` | Turns off telemetry when set to `1` or `true`. |
| `DOTNET_NOLOGO` | Hides the first-run notice when set to `1` or `true`. Telemetry stays on. |
| `DOTNET_CLI_TELEMETRY_STORAGE_PATH` | Changes the directory where `dotnetup` stores telemetry locally before it uploads the data. |
| `DOTNET_CLI_TELEMETRY_SHUTDOWN_TIMEOUT_MS` | In CI environments, changes the maximum time, in milliseconds, that `dotnetup` waits to send telemetry before it exits. The default is 20,000. |

## Privacy

If you think that the telemetry collects sensitive data, or that Microsoft
handles the data insecurely or inappropriately, file an issue in the
[dotnet/sdk repository](https://github.com/dotnet/sdk/issues).

For more information, see the
[Microsoft Privacy Statement](https://www.microsoft.com/privacy/privacystatement).

## See also

- [.NET SDK and .NET CLI telemetry](../telemetry.md)
- [dotnetup overview](index.md)
