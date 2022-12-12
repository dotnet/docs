---
title: Memory Analysis
description: An introduction to memory analysis in .NET
ms.date: 12/13/2022
---

# Memory Analysis

If your app references objects it no longer needs to perform a task, a memory leak may occur. It is then necessary to [debug the memory leak](debug-memory-leak.md) to provide space for your app to run properly. The recommended tools to debug a memory leak are [dotnet-sos](debug-memory-leak.md), [perfview](/shows/PerfView-Tutorial/), and [Visual Studio memory analysis](/visualstudio-docs/docs/profiling/analyze-memory-usage.md).

Another tool can be used to gather data to perform the memory analysis is the global CLI tool, [dotnet-gcdump](dotnet-gcdump.md).
