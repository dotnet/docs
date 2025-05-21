---
title: Log sampling
description: Learn how to fine-tune the volume of logs emitted by your application using log sampling.
ms.date: 04/29/2025
ms.topic: how-to
---

# Log sampling in .NET

.NET provides log sampling capabilities that allow you to control the volume of logs your application emits without losing important information. The following sampling strategies are available:

- Trace-based sampling: Sample logs based on the sampling decision of the current trace.
- Random probabilistic sampling: Sample logs based on configured probability rules.
- Custom sampling: Implement your own custom sampling strategy. For more information, see [Implement custom sampling](#implement-custom-sampling).

> [!NOTE]
> Only one sampler can be used at a time. If you register multiple samplers, the last one is used.

Log sampling extends [filtering capabilities](logging.md#configure-logging-with-code) by giving you more fine-grained control over which logs are emitted by your application. Instead of simply enabling or disabling logs, you can configure sampling to emit only a fraction of them.

For example, while filtering typically uses probabilities like `0` (emit no logs) or `1` (emit all logs), sampling lets you choose any value in between—such as `0.1` to emit 10% of logs, or `0.25` to emit 25%.

## Get started

To get started, install the [📦 Microsoft.Extensions.Telemetry](https://www.nuget.org/packages/Microsoft.Extensions.Telemetry) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Telemetry
```

### [PackageReference](#tab/package-reference)

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Telemetry"
                    Version="*" />
</ItemGroup>
```

---

For more information, see [dotnet add package](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Configure trace-based sampling

Trace-based sampling ensures that logs are sampled consistently with the underlying <xref:System.Diagnostics.Activity>. This is useful when you want to maintain correlation between traces and logs. You can enable trace sampling (as described in the [guide](../diagnostics/distributed-tracing-concepts.md#sampling)), and then configure trace-based log sampling accordingly:

:::code language="csharp" source="snippets/logging/log-sampling/trace-based/Program.cs" range="20":::

When trace-based sampling is enabled, logs will only be emitted if the underlying <xref:System.Diagnostics.Activity> is sampled. The sampling decision comes from the current <xref:System.Diagnostics.Activity.Recorded> value.

## Configure random probabilistic sampling

Random probabilistic sampling allows you to sample logs based on configured probability rules. You can define rules specific to:

- Log category
- Log level
- Event ID

There are several ways to configure random probabilistic sampling with its rules:

### File-based configuration

Create a configuration section in your _appsettings.json_, for example:

:::code language="json" source="snippets/logging/log-sampling/file-config/appsettings.json" :::

The preceding configuration:

- Samples 10% of logs from categories starting with `System.` of all levels.
- Samples 25% of logs from categories starting with `Microsoft.AspNetCore.` of the <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType>.
- Samples 5% of logs with event ID 1001 of all categories and levels.
- Samples 100% of all other logs.

> [!IMPORTANT]
> The <xref:Microsoft.Extensions.Diagnostics.Sampling.RandomProbabilisticSamplerFilterRule.Probability> value represents probability with values from 0 to 1. For example, 0.25 means 25% of logs will be sampled. 0 means no logs will be sampled, and 1 means all logs will be sampled. Those cases with 0 and 1 can be used to effectively disable or enable all logs for a specific rule. Probability cannot be less than 0 or greater than 1, and if this occurs in the application, an exception is thrown.

To register the sampler with the configuration, consider the following code:

:::code language="csharp" source="snippets/logging/log-sampling/file-config/Program.cs" range="16":::

#### Change sampling rules in a running app

Random probabilistic sampling supports runtime configuration updates via the <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> interface. If you're using a configuration provider that supports reloads—such as the [File Configuration Provider](configuration-providers.md#file-configuration-provider)—you can update sampling rules at runtime without restarting the application.

For example, you can start your application with the following _appsettings.json_, which effectively acts as a no-op:

:::code language="json" source="snippets/logging/log-sampling/appsettings.noop.json" :::

While the app is running, you can update the _appsettings.json_ with the following configuration:

:::code language="json" source="snippets/logging/log-sampling/appsettings.updated.json" :::

The new rules will be applied automatically, for instance, with the preceding configuration, 1% of logs with the <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> are sampled.

#### How sampling rules are applied

The algorithm is very similar to [log filtering](logging.md#how-filtering-rules-are-applied), yet there are some differences.

Log sampling rules evaluation is performed on each log record, however, there are performance optimizations in place, such as caching. The following algorithm is used for each log record for a given category:

- Select rules with `LogLevel` equal to or higher than the log level of the logger.
- Select rules with `EventId` not defined or defined and equal to the log event ID.
- Select rules with longest matching category prefix. If no match is found, select all rules that don't specify a category.
- If multiple rules are selected, take the **last** one.
- If no rules are selected, sampling is not applied, e.g. the log record is emitted as usual.

### Inline code configuration

:::code language="csharp" source="snippets/logging/log-sampling/code-config/Program.cs" range="16-22":::

The preceding configuration:

- Samples 5% of logs with event ID 1001 of all categories and levels.
- Samples 100% of all other logs.

### Simple probability configuration

For basic scenarios, you can configure a single probability value that applies to all logs at or below a specified level:

:::code language="csharp" source="snippets/logging/log-sampling/Program.cs" range="14-15":::

The code above registers the sampler which would sample 10% of <xref:Microsoft.Extensions.Logging.LogLevel.Warning> logs and 1% of <xref:Microsoft.Extensions.Logging.LogLevel.Information> (and below) logs.
If the configuration did not have the rule for <xref:Microsoft.Extensions.Logging.LogLevel.Information>, it would have sampled 10% of <xref:Microsoft.Extensions.Logging.LogLevel.Warning> logs and all levels below, including <xref:Microsoft.Extensions.Logging.LogLevel.Information>.

## Implement custom sampling

You can create a custom sampling strategy by deriving from the <xref:Microsoft.Extensions.Logging.LoggingSampler> abstract class and overriding its abstract members. This allows you to tailor the sampling behavior to your specific requirements. For example, a custom sampler could:

- Make sampling decisions based on the presence and value of specific key/value pairs in the log state.
- Apply rate-limiting logic, such as emitting logs only if the number of logs within a predefined time interval stays below a certain threshold.

To implement a custom sampler, follow these steps:

1. Create a class that inherits from <xref:Microsoft.Extensions.Logging.LoggingSampler>.
1. Override the <xref:Microsoft.Extensions.Logging.LoggingSampler.ShouldSample*?displayProperty=nameWithType> method to define your custom sampling logic.
1. Register your custom sampler in the logging pipeline using the <xref:Microsoft.Extensions.Logging.SamplingLoggerBuilderExtensions.AddSampler%2A> extension method.

For each log record that isn't filtered out, the <xref:Microsoft.Extensions.Logging.LoggingSampler.ShouldSample*?displayProperty=nameWithType> method is called exactly once. Its return value determines whether the log record should be emitted.

## Performance considerations

Log sampling is designed to reduce storage costs, with a trade-off of slightly increased CPU usage. If your application generates a high volume of logs that are expensive to store, sampling can help reduce that volume. When configured appropriately, sampling can lower storage costs without losing information that's critical for diagnosing incidents.

For the built-in sampling, see the benchmarks [here](https://github.com/dotnet/extensions/blob/main/bench/Libraries/Microsoft.Extensions.Telemetry.PerformanceTests/README.md).

## Log level guidance on when to use sampling

| Log level | Recommendation |
|--|--|
| <xref:Microsoft.Extensions.Logging.LogLevel.Trace> | Don't apply sampling, because normally you disable these logs in production |
| <xref:Microsoft.Extensions.Logging.LogLevel.Debug> | Don't apply sampling, because normally you disable these logs in production |
| <xref:Microsoft.Extensions.Logging.LogLevel.Information> | Do apply sampling |
| <xref:Microsoft.Extensions.Logging.LogLevel.Warning> | Consider applying sampling |
| <xref:Microsoft.Extensions.Logging.LogLevel.Error> | Don't apply sampling |
| <xref:Microsoft.Extensions.Logging.LogLevel.Critical> | Don't apply sampling |

## Best practices

- Begin with higher sampling rates and adjust them downwards as necessary.
- Use category-based rules to target specific components.
- If you're using distributed tracing, consider implementing trace-based sampling.
- Monitor the effectiveness of your sampling rules collectively.
- Find the right balance for your application—too low a sampling rate can reduce observability, while too high a rate can increase costs.

## See also

- [Logging in .NET](logging.md)
- [High-performance logging in .NET](high-performance-logging.md)
- [OpenTelemetry Tracing Sampling](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/sdk.md#sampling)
