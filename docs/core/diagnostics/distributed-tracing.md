---
title: Distributed tracing - .NET
description: An introduction to .NET distributed tracing.
ms.date: 03/15/2021
---
# .NET Distributed Tracing

Distributed tracing is a diagnostic technique that helps engineers localize failures and
performance issues within applications, especially those that may be distributed across
multiple machines or processes. This technique tracks requests through an application
correlating together work done by different application components and separating it from
other work the application may be doing for concurrent requests. For example a request to a
typical web service might be first received by a load balancer, then forwarded to a web server
process, which then makes several queries to a database. Using distributed tracing allows
engineers to distinguish if any of those steps failed, how long each step took, and potentially
logging messages produced by each step as it ran.

## Getting started for .NET app developers

Key .NET libraries are instrumented to produce distributed tracing information automatically
but this information needs to be collected and stored so that it will be available for review later.
Typically app developers will select a telemetry service that stores this trace information for them and
then use a corresponding library to transmit the distributed tracing telemetry to their chosen
service. [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/docs/trace/getting-started/README.md)
is a vendor neutral library that supports several services,
[Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/distributed-tracing)
is a full featured service provided by Microsoft, and there are many high quality 3rd party APM vendors
that offer integrated .NET solutions.

- [Understand distributed tracing concepts](distributed-tracing-concepts.md)
- Guides
  - [Collect distributed traces with Application Insights](distributed-tracing-collection-walkthroughs.md#collect-traces-using-application-insights)
  - [Collect distributed traces with OpenTelemetry](distributed-tracing-collection-walkthroughs.md#collect-traces-using-opentelemetry)
  - [Collect distributed traces with custom logic](distributed-tracing-collection-walkthroughs.md#collect-traces-using-custom-logic)
  - [Adding custom distributed trace instrumentation](distributed-tracing-instrumentation-walkthroughs.md)

For 3rd party telemetry collection services follow the setup instructions provided by the vendor.

## Getting started for .NET library developers

.NET libraries don't need to be concerned with how telemetry is ultimately collected, only
with how it is produced. If you believe .NET app developers that use your library would
appreciate seeing the work that it does detailed in a distributed trace then you should add
distributed tracing instrumentation to support it.

- [Understand distributed tracing concepts](distributed-tracing-concepts.md)
- Guides
  - [Adding custom distributed trace instrumentation](distributed-tracing-instrumentation-walkthroughs.md)
