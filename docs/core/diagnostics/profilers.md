---
title: Profiling tools - .NET Core
description: An overview of .NET Core profiling tools.
ms.date: 08/29/2025
---
# .NET Core Profiling Tools

Profilers allow you to analyze your program's performance. By analyzing data on memory usage, CPU usage, call stacks and other information, you can better understand the performance profile of your program.

Microsoft provides a profiler with Visual Studio as well as through the ```dotnet-trace``` tool.

## Visual Studio profiler

**Visual Studio** is an integrated development environment and an excellent choice for developers working on Windows. There are several tools, guides and tutorials for Visual Studio profiling listed below.

- [Measure app performance in Visual Studio](https://learn.microsoft.com/visualstudio/profiling/)


## dotnet-trace

```dotnet-trace``` is a cross-platform command-line tool that allows the collection of diagnostic traces on Windows, Linux and Mac. These traces can then be viewed in [Visual Studio](/visualstudio/profiling/beginners-guide-to-performance-profiling?#step-2-analyze-cpu-usage-data) or [PerfView](https://github.com/microsoft/perfview).

- [dotnet-trace documentation](dotnet-trace.md)
