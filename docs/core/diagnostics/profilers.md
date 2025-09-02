---
title: Profiling tools in .NET
description: An overview of .NET profiling tools.
ms.date: 08/29/2025
---
# .NET profiling tools

Profilers allow you to analyze your program's performance. By analyzing data on memory usage, CPU usage, call stacks and other information, you can better understand the performance profile of your program.

Microsoft provides a profiler with [Visual Studio](/visualstudio/profiling/beginners-guide-to-performance-profiling) and through the [dotnet-trace](dotnet-trace.md) tool.

## Visual Studio profiler

**Visual Studio** is an integrated development environment and an excellent choice for developers working on Windows.

- [Measure app performance in Visual Studio](/visualstudio/profiling/)

## dotnet-trace

[`dotnet-trace`](dotnet-trace.md) is a cross-platform command-line tool that collects diagnostic traces on Windows, Linux, and Mac. You can view these traces in [Visual Studio](/visualstudio/profiling/beginners-guide-to-performance-profiling?#step-2-analyze-cpu-usage-data) or [PerfView](https://github.com/microsoft/perfview).
