---
title: Configure distributed tracing in .NET
description: Learn how to register tracing listeners and configure activity rules in .NET.
ms.date: 08/27/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
---

# Configure distributed tracing in .NET

In .NET 11 and later, the `Microsoft.Extensions.Diagnostics.Tracing` APIs let you register <xref:System.Diagnostics.ActivityListener> instances and use rules to select the <xref:System.Diagnostics.ActivitySource> and <xref:System.Diagnostics.Activity> instances that each listener receives. Define rules in code or load them from <xref:Microsoft.Extensions.Configuration.IConfiguration>.

> [!IMPORTANT]
> Tracing rules affect only listeners registered through this tracing infrastructure. They don't affect unrelated `ActivityListener` instances, including listeners that telemetry exporters create and manage. Configure those listeners or exporters separately.

## Register tracing

The APIs are available in the [`Microsoft.Extensions.Diagnostics`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics) package. Apps that reference the `Microsoft.AspNetCore.App` shared framework already include the assembly.

Call <xref:Microsoft.Extensions.DependencyInjection.TracingServiceExtensions.AddTracing*> on an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. In the callback:

- Call <xref:Microsoft.Extensions.Diagnostics.Tracing.TracingBuilderExtensions.AddListener*> to register each listener. The listener name identifies the listener in configuration rules.
- Configure the listener's sampling and notification delegates through <xref:Microsoft.Extensions.Diagnostics.Tracing.ActivityListenerBuilder>. The tracing infrastructure owns `ShouldListenTo`, source subscriptions, and the listener lifetime.
- Call <xref:Microsoft.Extensions.Diagnostics.Tracing.TracingBuilderConfigurationExtensions.AddConfiguration*> with the configuration section that contains the rules. For a section named `Tracing`, pass `configuration.GetSection("Tracing")`.

The [complete sample](#run-the-sample) shows all three calls. A .NET host activates tracing subscriptions when the host starts. If you use dependency injection without a host, resolve the registered <xref:System.Diagnostics.ActivitySourceFactory> to construct the listeners and activate their subscriptions. The complete sample resolves the factory directly.

## Configure tracing

Set tracing rules through configuration or in code. If no rule matches a listener, source, operation, and scope, tracing remains disabled for that combination.

### Configure tracing without code

For apps that use configuration, add a `Tracing` section to *appsettings.json* or another [configuration provider](../extensions/configuration-providers.md). Then pass that section to `AddConfiguration`:

```csharp
tracing.AddConfiguration(configuration.GetSection("Tracing"));
```

The following example shows the supported rule sections and rule levels:

:::code language="json" source="./snippets/distributed-tracing-configuration/appsettings.json":::

Add rules directly under an `EnabledTracing`, `EnabledGlobalTracing`, or `EnabledLocalTracing` section. Don't add a `Rules` level.

#### Rule sections

Choose a rule section based on the source scope and whether the rule targets one listener:

| Section | Matching listeners | Matching activity sources |
|---|---|---|
| `EnabledTracing` | All registered listeners. | Global and local sources. |
| `EnabledGlobalTracing` | All registered listeners. | Global sources only. |
| `EnabledLocalTracing` | All registered listeners. | Local sources only. |
| `{Listener}:EnabledTracing` | The named listener. | Global and local sources. |
| `{Listener}:EnabledGlobalTracing` | The named listener. | Global sources only. |
| `{Listener}:EnabledLocalTracing` | The named listener. | Local sources only. |

Listener names match the names passed to `AddListener`. Section names and listener names aren't case-sensitive.

#### Rule levels

Under any rule section, use one of the following key forms:

| Key form | Rule level | Match |
|---|---|---|
| `Default` | Default. | Every source and operation. |
| `{SourceName}` | Activity source. | Every operation from matching sources. |
| `{SourceName}:Default` | Activity source. | Every operation from matching sources. This form lets a source also contain operation rules. |
| `{SourceName}:{OperationName}` | Operation. | The named operation from matching sources. |

Set each leaf value to `true` to enable the match or `false` to disable it. For example, the preceding configuration:

- Disables tracing by default.
- Enables sources whose names start with `Contoso`.
- Enables `Contoso.Orders`, but disables its `HealthCheck` operation.
- Enables a source pattern that starts with `Contoso.` and ends with `.Storage`.
- Adds rules that apply only to global sources, local sources, or the listener named `Console`.

Use `Default` as a Boolean leaf. If `Default` contains operation children, the configuration treats `Default` as a literal activity-source name.

### Configure tracing with code

Call <xref:Microsoft.Extensions.Diagnostics.Tracing.TracingBuilderExtensions.EnableTracing*> and <xref:Microsoft.Extensions.Diagnostics.Tracing.TracingBuilderExtensions.DisableTracing*> on the <xref:Microsoft.Extensions.Diagnostics.Tracing.ITracingBuilder> passed to `AddTracing`.

## [C#](#tab/csharp)

```csharp
tracing.EnableTracing(sourceName: "Contoso");
tracing.DisableTracing(
    sourceName: "Contoso.Orders",
    operationName: "HealthCheck");
```

## [Visual Basic](#tab/visual-basic)

```vb
tracing.EnableTracing(sourceName:="Contoso")
tracing.DisableTracing(
    sourceName:="Contoso.Orders",
    operationName:="HealthCheck")
```

---

Omit `sourceName`, `operationName`, or `listenerName` to match all values at that level. By default, a programmatic rule applies to both global and local sources. Pass <xref:Microsoft.Extensions.Diagnostics.Tracing.ActivitySourceScopes.Global>, <xref:Microsoft.Extensions.Diagnostics.Tracing.ActivitySourceScopes.Local>, or both through the `scopes` argument to narrow the rule.

Configuration rules and programmatic rules form one ordered rule set. If equally specific rules conflict, the rule added last wins. The order of calls in the `AddTracing` callback therefore matters when `AddConfiguration`, `EnableTracing`, and `DisableTracing` add equally specific rules.

## Match activity-source names

Source names, operation names, and listener names use case-insensitive ordinal comparison. Source-name rules support these match forms:

- An empty source name matches every source.
- A source name without a wildcard matches by prefix. For example, `Contoso` matches `Contoso.Orders` and `ContosoPayments`; the matcher doesn't require a separator after the prefix.
- A source name with one `*` wildcard matches a prefix and suffix. For example, `Contoso.*.Storage` matches `Contoso.Orders.Storage`, but not `Contoso.Orders.Api`.
- A source name of `*` matches every source.

Operation names match exactly. They don't use prefix or wildcard matching.

## Apply rule precedence

For each listener, source, operation, and scope combination, the tracing infrastructure chooses one matching rule. It compares matching rules in this order:

- A listener-specific rule takes precedence over a rule for all listeners.
- A source rule takes precedence over a default rule. If two source expressions match, the longer expression takes precedence. The comparison uses the expression length, including a `*` wildcard.
- An operation rule takes precedence over a source-level rule.
- A global-only or local-only rule takes precedence over a rule that covers both scopes.
- The last rule takes precedence when all preceding factors are equal.

The comparison stops at the first difference. For example, a listener-specific default rule takes precedence over a source-specific rule that applies to all listeners because listener specificity is evaluated first.

Operation rules also control source subscriptions. A listener subscribes to a source that's disabled by default when an operation rule enables at least one operation from that source. The listener then returns <xref:System.Diagnostics.ActivitySamplingResult.None> and skips its callbacks for disabled operations.

## Choose global or local activity sources

The tracing infrastructure distinguishes two activity-source scopes:

- A *global* source is an `ActivitySource` created through its constructor. `EnabledGlobalTracing` rules apply to these sources.
- A *local* source is an `ActivitySource` created by the `ActivitySourceFactory` resolved from dependency injection. `EnabledLocalTracing` rules apply to sources created by that factory.

Use <xref:System.Diagnostics.ActivitySourceFactory.Create*> when you want the dependency injection container to manage the source and its tracing listeners. A factory's listeners ignore local sources created by a different factory. Rules in `EnabledTracing` apply to both source types.

These scopes restrict only the listeners that `AddTracing` registers. An independent `ActivityListener` uses its own `ShouldListenTo` and sampling callbacks, even for an activity source created by `ActivitySourceFactory`.

## Reload tracing configuration

`AddConfiguration` subscribes to the change token from the supplied configuration. When a [configuration provider](../extensions/configuration-providers.md) supports reload and reports a change, the tracing infrastructure:

- Rebuilds the rule set.
- Refreshes each registered listener's source subscriptions.
- Applies the updated rules to subsequent activities.

The app can keep using the same `ActivitySource` instances after a reload. Subsequent activities use the updated rules.

For a mutable provider that doesn't report changes automatically, update the configuration and call <xref:Microsoft.Extensions.Configuration.IConfigurationRoot.Reload*>. The complete sample uses this approach with the in-memory configuration provider.

## Handle invalid configuration

Tracing configuration parses values with <xref:System.Boolean.TryParse*>. It accepts `true` and `false` without regard to case and permits surrounding whitespace. It doesn't accept `1`, `0`, `yes`, or `on`.

The configuration loader silently ignores a leaf value that isn't a valid Boolean. It also ignores unknown or malformed sections that don't match the supported schema. Check key names carefully because these cases don't produce an exception.

A source expression can contain at most one `*` wildcard. A rule with more than one wildcard throws an <xref:System.ArgumentException> when the rule is materialised, either during app startup or after configuration reload. For programmatic rules, <xref:Microsoft.Extensions.Diagnostics.Tracing.ActivitySourceScopes.None> also causes an <xref:System.ArgumentOutOfRangeException>.

## Run the sample

The following .NET 11 console app creates one enabled operation and one disabled operation. It then updates the disabled operation's rule, calls `Reload`, and starts the operation again through the same local `ActivitySource`.

:::code language="csharp" source="./snippets/distributed-tracing-configuration/csharp/Program.cs" id="TracingConfiguration":::
:::code language="vb" source="./snippets/distributed-tracing-configuration/vb/Program.vb" id="TracingConfiguration":::

The C# and Visual Basic samples produce the same result:

```console
Before reload:
Listener started: EnabledOperation
EnabledOperation: enabled
DisabledOperation: disabled
After reload:
Listener started: DisabledOperation
DisabledOperation: enabled
```

## See also

- [Distributed tracing overview](distributed-tracing.md)
- [Configuration in .NET](../extensions/configuration.md)
- [Activity tracing configuration in What's new in .NET 11](../whats-new/dotnet-11/libraries.md#activity-tracing-configuration)
