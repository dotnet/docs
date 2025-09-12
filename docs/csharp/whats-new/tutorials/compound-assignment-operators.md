---
title: Explore instance compound assignment operators
description: "C# 14 enables instance compound assignment operators. These can provide better performance by minimizing allocations or copy operations. Learn how to create these operators."
author: billwagner
ms.author: wiwagn
ms.service: dotnet-csharp
ms.topic: tutorial
ms.date: 09/15/2025

#customer intent: As a C# developer, I want implement compound assignment operators so that my algorithms are more efficient.

---

# Tutorial: Create compound assignment operators


[Introduce and explain the purpose of the article.]

<!-- Required: Introductory paragraphs (no heading)

Write a brief introduction that can help the user 
decide whether the article is relevant for them and
to describe how reading the article might benefit
them.

-->

In this tutorial, you:

> [!div class="checklist"]
> * Install prerequisites
> * Analyze the starting sample
> * Implement compound assignment operators
> * Analyze completed sample

## Prerequisites

- The .NET 10 preview SDK. Download it from the [.NET download site](https://dotnet.microsoft.com/download/dotnet/10.0).
- Visual Studio 2026 (preview). Download it from the [Visual Studio insiders page](https://visualstudio.microsoft.com/insiders/).

## Analyze the starting sample

- Run the app: understand what it does.
- Read the `GateAttendance` class closely. Note that the operators allocate new instances of objects.
- (optional) Run the Visual Studio performance profiler to count allocations (134 `GateAttendance` allocations)

## Implement compound assignment operators

## Analyze finished sample

- (Optional) Run the profiler again. Now, only 10 instance of GateAttendance objects are allocated. 
- Try and spot any additional allocations by replacing `+` operations with `+=` where possible.
- Discuss other options, like `struct` types. Point out that compound assignment helps here by avoiding copy operations

## Related content

- What's new.
- Operators in language reference
- [Analyze memory usage by using the .NET Object Allocation tool - Visual Studio](~/visualstudio/profiling/dotnet-alloc-tool.md)
