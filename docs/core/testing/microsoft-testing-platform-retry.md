---
title: Microsoft.Testing.Platform retry
description: Learn about retrying failed tests with Microsoft.Testing.Platform.
author: evangelink
ms.author: amauryleve
ms.date: 02/25/2026
ai-usage: ai-assisted
---

# Retry

This feature requires the [Microsoft.Testing.Extensions.Retry](https://nuget.org/packages/Microsoft.Testing.Extensions.Retry) NuGet package.

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), this extension is auto-registered when you install its NuGet package — no code changes needed. The manual registration below is only required if you disabled the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.TestHost.AddRetryProvider();
```

## Retry

A .NET test resilience and transient-fault-handling extension.

This extension is intended for integration tests where the test depends heavily on the state of the environment and could experience transient faults.

> [!NOTE]
> The package is shipped with the restrictive Microsoft.Testing.Platform Tools license.
> The full license is available at <https://www.nuget.org/packages/Microsoft.Testing.Extensions.Retry/1.0.0/License>.

### Options

| Option                                | Description                                                                                      |
|---------------------------------------|--------------------------------------------------------------------------------------------------|
| `--retry-failed-tests`                | Reruns any failed tests until they pass or until the maximum number of attempts is reached. Required to activate the extension. |
| `--retry-failed-tests-max-percentage` | Avoids rerunning tests when the percentage of failed test cases crosses the specified threshold. Can't be combined with `--retry-failed-tests-max-tests`. |
| `--retry-failed-tests-max-tests`      | Avoids rerunning tests when the number of failed test cases crosses the specified limit. Can't be combined with `--retry-failed-tests-max-percentage`. |

Both threshold options (`--retry-failed-tests-max-percentage` and `--retry-failed-tests-max-tests`) require `--retry-failed-tests` to also be set.

### Examples

Retry failed tests up to 3 times:

```dotnetcli
dotnet run --project Contoso.MyTests -- --retry-failed-tests 3
```

Retry failed tests up to 2 times, but stop retrying if more than 50% of tests failed:

```dotnetcli
dotnet run --project Contoso.MyTests -- --retry-failed-tests 2 --retry-failed-tests-max-percentage 50
```

Retry failed tests up to 3 times, but stop retrying if more than 10 tests failed:

```dotnetcli
dotnet run --project Contoso.MyTests -- --retry-failed-tests 3 --retry-failed-tests-max-tests 10
```

### Limitations

- Not supported on browser platforms.
- Not supported in hot reload mode.
