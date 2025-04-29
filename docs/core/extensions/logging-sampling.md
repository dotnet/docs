---
title: Logging sampling
description: Learn how to fine-tune the volume of logs emitted by your application using Logging Sampling.
ms.author: efedorov
ms.date: 04/29/2025
---

# Logging sampling in .NET

.NET provides logging sampling capabilities that allow you to control the volume of logs your application emits without losing important information. The following sampling strategies are available:

- Trace-based sampling - Sample logs based on the sampling decision of the current trace.
- Random probabilistic sampling - Sample logs based on configured probability rules.
- Custom sampling - Implement your own custom sampling strategy. See the [Implement custom sampling](#implement-custom-sampling) section for more details.

However, please note that only one sampler can be used at a time. If you register multiple samplers, only the last one will be used.

Logging sampling extends [filtering capabilities](logging.md#configure-logging-with-code), it allows for more fine-grained control over the logs emitted by your application -
in addition to enabling or completely disabling logs, you can configure it to emit only a certain share of logs.
In other words, from the probabilities 0 (= no logs) and 1 (= all logs) provided by the [filtering](logging.md#configure-logging-with-code),
we can specify any value in between, e.g. 0.1 (= 10% of logs) or 0.25 (= 25% of logs).

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

Trace-based sampling ensures that logs are sampled consistently with the underlying <xref:System.Diagnostics.Activity>. This is useful when you want to maintain correlation between traces and logs. You can enable tracing sampling as per the [guide](../diagnostics//distributed-tracing-concepts.md#sampling) and then enable the trace-based sampling:

:::code language="csharp" source="snippets/logging/logging-sampling/trace-based/Program.cs" range="27":::

When trace-based sampling is enabled, logs will only be emitted if the underlying <xref:System.Diagnostics.Activity> is sampled. The sampling decision comes from the current <xref:System.Diagnostics.Activity.Recorded> value.

## Configure random probabilistic sampling

Random probabilistic sampling allows you to sample logs based on configured probability rules. You can define rules specific to:

- Log category
- Log level
- Event ID

There are several ways to configure random probabilistic sampling with its rules:

### Using file configuration

Create a configuration section in your `appsettings.json`, for example:

:::code language="json" source="snippets/logging/logging-sampling/file-config/appsettings.json" :::

The configuration above:

- Samples 25% of logs from categories starting with `Microsoft.AspNetCore.` of the <xref:Microsoft.Extensions.Logging.LogLevel.Information> level.
- Samples 10% of logs from categories starting with `System.` of all levels.
- Samples 5% of logs with event ID 1001 of all categories and levels.
- Samples 100% of all other logs.

> [!IMPORTANT]
> The <xref:Microsoft.Extensions.Diagnostics.Sampling.RandomProbabilisticSamplerFilterRule.Probability> value represents probability with values from 0 to 1.
> For example, 0.25 means 25% of logs will be sampled. 0 means no logs will be sampled, and 1 means all logs will be sampled.
> Those cases with 0 and 1 can be used to effectively disable or enable all logs for a specific rule.
> Probability cannot be less than 0 or greater than 1, and if this occurs in the application, an exception will be thrown.

Then register the sampler and the configuration:

:::code language="csharp" source="snippets/logging/logging-sampling/file-config/Program.cs" range="23":::

#### Change sampling rules in a running app

Random probabilistic sampling supports runtime configuration updates via the <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> interface. If you use a configuration provider which supports
configuration reload, such as the [File Configuration Provider](configuration-providers.md#file-configuration-provider), you can take advantage of this feature
and change the sampling rules at runtime without restarting the application.
For instance, you can run your application with the following config `appsettings.json` which is effectively no-op:

:::code language="json" source="snippets/logging/logging-sampling/appsettings.noop.json" :::

Then, while the application is running, you can update the `appsettings.json` to this:

:::code language="json" source="snippets/logging/logging-sampling/appsettings.updated.json" :::

and the new rules will be applied automatically, for instance, with the configuration above, 1% of logs of the <xref:Microsoft.Extensions.Logging.LogLevel.Information> level will be sampled.

#### How sampling rules are applied

The algorithm is very similar to [log filtering](logging.md#how-filtering-rules-are-applied),
yet there are some differences.

The log sampling rules evaluation is performed on each log record (however, there are performance optimizations in place, such as caching).
The following algorithm is used for each log record for a given category:

- Select rules with LogLevel equal to or higher than the log level of the logger.
- Select rules with EventId not defined or defined and equal to the log event ID.
- Select rules with longest matching category prefix. If no match is found, select all rules that don't specify a category.
- If multiple rules are selected, take the **last** one.
- If no rules are selected, sampling is not applied, e.g. the log record is emitted as usual.

### Using code configuration

:::code language="csharp" source="snippets/logging/logging-sampling/code-config/Program.cs" range="23-29":::

The configuration above:

- Samples 5% of logs with event ID 1001 of all categories and levels.
- Samples 100% of all other logs.

### Simple probability configuration

For basic scenarios, you can configure a single probability value that applies to all logs below a specified level:

:::code language="csharp" source="snippets/logging/logging-sampling/Program.cs" range="24-25":::

The code above registers the sampler which samples 1% of <xref:Microsoft.Extensions.Logging.LogLevel.Information> logs
and 10% of <xref:Microsoft.Extensions.Logging.LogLevel.Warning> logs.

## Implement custom sampling

You can implement your own custom sampling strategy by inheriting and implementing the <xref:Microsoft.Extensions.Logging.LoggingSampler> abstract class.
This allows you to create a custom sampling strategy that fits your specific needs.
For example, you can create a custom sampler which can do, for instance:

- Make a sampling decision based on whether a certain key/value pair is present in the log state or not, and what values it has.
- Implement a rate-limiting strategy, e.g. only emit logs if the number of logs emitted in the pre-defined time interval is less than a certain threshold.

To implement a custom sampler, follow these steps:

1. Create a class that inherits from <xref:Microsoft.Extensions.Logging.LoggingSampler>.
2. Implement the <<xref:Microsoft.Extensions.Logging.LoggingSampler.ShouldSample%2A?displayProperty=nameWithType> method to define your custom sampling logic.
3. Register your custom sampler in the logging pipeline using the <xref:Microsoft.Extensions.Logging.SamplingLoggerBuilderExtensions.AddSampler%2A> extension method.

For each log record (if it is not filtered out), the <xref:Microsoft.Extensions.Logging.LoggingSampler.ShouldSample%2A?displayProperty=nameWithType>
method will be called exactly once and its return value will be used to determine if the log
records should be emitted or not.

## Performance considerations

Logging sampling is optimized for storage at the cost of slightly increased CPU usage. In case your application produces a lot of logs whose storage costs you a lot of money,
you can use sampling to reduce the volume of logs. If configured correctly, you will not lose information important for incident resolution, but you will reduce the volume of logs and hence the cost of storage.

For the built-in sampling, see the benchmarks [here](https://github.com/dotnet/extensions/blob/main/bench/Libraries/Microsoft.Extensions.Telemetry.PerformanceTests/README.md).

## Per log level guidance on when to use sampling

| Log Level | Recommendation |
| --------- | --------------- |
| <xref:Microsoft.Extensions.Logging.LogLevel.Trace>     | Not applicable because normally these logs are disabled |
| <xref:Microsoft.Extensions.Logging.LogLevel.Debug>     | Not applicable because normally these logs are disabled |
| <xref:Microsoft.Extensions.Logging.LogLevel.Information> | Do apply sampling |
| <xref:Microsoft.Extensions.Logging.LogLevel.Warning>   | Consider applying sampling |
| <xref:Microsoft.Extensions.Logging.LogLevel.Error>     | Do not apply sampling |
| <xref:Microsoft.Extensions.Logging.LogLevel.Critical>  | Do not apply sampling |

## Best practices

- Start with higher sampling rates and adjust downwards as needed.
- Use category-based rules to target specific components.
- Consider using trace-based sampling if you're using distributed tracing.
- Monitor the effectiveness of your sampling rules together.
- Find the balance specific to your application - very low sampling rates can degrade observability, while high sampling rates can increase costs.

## See also

- [Logging in .NET](logging.md)
- [High-performance logging in .NET](high-performance-logging.md)
- [OpenTelemetry Tracing Sampling](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/sdk.md#sampling)
