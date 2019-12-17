---
title: Sample debug target
description: Introduction to the sample debug target used in the diagnostic tutorials.
author: sdmaclea
ms.author: stmaclea
ms.date: 12/17/2019
---
# Sample debug target

The sample debug target is a simple `webapi` application. The sample triggers undesirable behaviors for the [.NET Core diagnostics tutorials](index.md#net-core-diagnostics-tutorials) to diagnose.

## Sample source

The sample code is in [DiagnosticScenarios](https://github.com/dotnet/samples/blob/master/core/diagnostics/DiagnosticScenarios). The sample is a basic `webapi` with a single added file [DiagnosticScenarios.cs](https://github.com/dotnet/samples/blob/master/core/diagnostics/DiagnosticScenarios/Controllers/DiagnosticScenarios.cs).

The simplest way to acquire the source code is to clone the [dotnet/samples](https://github.com/dotnet/sample) repository.

```console
git clone git@github.com:dotnet/samples.git
```

## Build and run the target

After cloning the source, you can easily create the webapi using:

```console
cd core/diagnostics/DiagnosticScenarios
dotnet build
dotnet run
```

## Target methods

The target triggers undesirable behaviors when hitting specific URLs.

### Deadlock

`http://localhost:5000/api/diagscenario/deadlock`

This method will cause the target to hang and accumulate many threads.

### High CPU usage

`http://localhost:5000/api/diagscenario/highcpu/{milliseconds}`

The method will cause to target to heavily use the CPU for a duration specified by {milliseconds}.

### Memory leak

`http://localhost:5000/api/diagscenario/memleak/{kb}`

This method will cause the target to leak memory (amount specified by {kb}).

### Memory usage spike

`http://localhost:5000/api/diagscenario/memspike/{seconds}`

This method will cause intermittent memory spikes over the specified number of seconds. Memory will go from base line to spike and back to baseline several times.
