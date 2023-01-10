---
title: Memory Analysis
description: An introduction to memory analysis in .NET
ms.date: 12/13/2022
---

# Memory Analysis

Various behaviors can be manifested by your app as a result of a memory leak. The most common are crashing, possibly with an out of memory exception, decrease of performance, consuming large amounts of cloud storage. The method to verify a memory leak as the problem is to investigate the memory usage of your app. Memory usage can be investigated at one specific point in time, or multiple points of time to show the change in memory use. For more information see [debug memory leak tutorial](debug-memory-leak.md).

## Collecting Information for Memory Analysis

[debug memory leak tutorial](debug-memory-leak.md) shows how to debug a memory leak using the dotnet CLI tools with the dotnet-sos commands dumpheap and gcroot.

An alternative method is to use [dotnet-dump](dotnet-dump.md) to collect a memory (on Windows) or core (on Linux) dump at two different points in time and compare the outputs.

>[!NOTE]
> Windows users can use [dptnet-gcdump](dotnet-gcdump.md) to walk the heap and collect the memory graph (also called gcdump) of the app at two different points in time as explained in the [perfview tutorials](/shows/PerfView-Tutorial/). Additionally, the [Visual Studio Memory Analysis](/visualstudio-docs/docs/profiling/analyze-memory-usage.md) can be used to diagnose a memory leak.
