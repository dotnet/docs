---
title: Entity Framework Core metrics
description: Review the metrics available for Entity Framework Core
ms.topic: reference
ms.date: 10/06/2024
---

# Entity Framework Core metrics

This article describes the metrics built-in for Entity Framework Core produced using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API.

## `Microsoft.EntityFrameworkCore`

The `Microsoft.EntityFrameworkCore` metrics report information about operations done by Entity Framework Core:

- [`microsoft.entityframeworkcore.active_dbcontexts`](#metric-microsoftentityframeworkcoreactive_dbcontexts)
- [`microsoft.entityframeworkcore.queries`](#metric-microsoftentityframeworkcorequeries)
- [`microsoft.entityframeworkcore.savechanges`](#metric-microsoftentityframeworkcoresavechanges)
- [`microsoft.entityframeworkcore.compiled_query_cache_hit_rate`](#metric-)
- [`microsoft.entityframeworkcore.execution_strategy_operation_failures`](#metric-microsoftentityframeworkcoreexecution_strategy_operation_failures)
- [`microsoft.entityframeworkcore.optimistic_concurrency_failures`](#metric-microsoftentityframeworkcoreoptimistic_concurrency_failures)

##### Metric: `microsoft.entityframeworkcore.active_dbcontexts`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `microsoft.entityframeworkcore.active_dbcontexts` | ObservableUpDownCounter | `{dbcontext}` | Number of currently active `DbContext` instances. |

Available starting in: .NET 9.0.

##### Metric: `microsoft.entityframeworkcore.queries`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `microsoft.entityframeworkcore.queries` | ObservableCounter | `{query}` | Cumulative count of queries executed. |

Available starting in: .NET 9.0.

##### Metric: `microsoft.entityframeworkcore.savechanges`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `microsoft.entityframeworkcore.savechanges` | ObservableCounter | `{savechanges}` | Cumulative count of changes saved. |

Available starting in: .NET 9.0.

##### Metric: `microsoft.entityframeworkcore.compiled_query_cache_hit_rate`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `microsoft.entityframeworkcore.compiled_query_cache_hit_rate` | ObservableGauge | `%` | Hit rate for the compiled query cache. |

Available starting in: .NET 9.0.

##### Metric: `microsoft.entityframeworkcore.execution_strategy_operation_failures`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `microsoft.entityframeworkcore.execution_strategy_operation_failures` | ObservableCounter | `{failure}` | Cumulative number of failed operation executed by an `IExecutionStrategy`. |

Available starting in: .NET 9.0.

##### Metric: `microsoft.entityframeworkcore.optimistic_concurrency_failures`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `microsoft.entityframeworkcore.optimistic_concurrency_failures` | ObservableCounter | `{failure}` | Cumulative number of optimistic concurrency failures. |

Available starting in: .NET 9.0.
