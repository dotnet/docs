---
title: Metrics Overview
description: An overview on using metrics to monitor a .NET application
ms.date: 11/04/2021
---

# .NET Metrics

Metrics are numerical measurements reported over time, most often used to monitor the health of an application
and generate alerts. For example a web service might track how many requests it receives each second, how
many milliseconds it took to respond, and how many of the responses sent an error back to the user. These
metrics can be reported to a monitoring system at regular intervals. If the example web service is
intended to respond to requests within 400ms and then one day the response time slows to 600ms, the monitoring system
can notify engineers that the application is not operating as expected.

## Getting started

There are two parts to using metrics in a .NET app:

1. Instrumentation - Code in .NET libraries takes measurements and associates these measurements with a
metric name.
2. Collection - A .NET app developer configures which named metrics need to be transmitted from the app for
external storage and analysis. Some tools may also let engineers configure this outside the app
using config files or separate UI.

.NET library developers are primarily interested in the instrumentation step. App developers or operational engineers
usually focus on the collection step, leveraging the pre-existing instrumentation within libraries they are using.
However if you are an app developer and none of the existing metrics meet your needs you can always create new ones.

- [Instrumentation tutorial](metrics-instrumentation.md) - How to create new metrics in code
- [Collection tutorial](metrics-collection.md) - How to store and view metric data for your app
- [Built-in metrics](available-counters.md) - Discover metrics that are ready for use in .NET runtime libraries
