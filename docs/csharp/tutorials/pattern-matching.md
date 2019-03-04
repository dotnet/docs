title: Use pattern matching features to extend data types
description: This advanced tutorial demonstrates how to use pattern matching techniques to extend data types that .
ms.date: 02/19/2019
ms.custom: mvc
---
# Tutorial: Using pattern matching features to extend data types

C# 7 introduced basic pattern matching features. Those are extended in C# 8 with new expressions and patterns you can use to write functionality that behaves as though you extended types that may be in other libraries. Another use for patterns is to create functionality that your application requires but isn't a fundamental feature of the type being extended.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Do awesome pattern things
> * understand pattern things
> * be awesome

## Prerequisites

You'll need to set up your machine to run .NET Core, including the C# 8.0 beta compiler. The C# 8 beta compiler is available with [Visual Studio 2019 preview 4](https://visualstudio.microsoft.com/vs/preview/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019+preview), or [.NET Core 3.0 preview 2](https://dotnet.microsoft.com/download/dotnet-core/3.0).

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET Core CLI.

## Introduction or more...

Modern development often includes pulling data from multiple sources and presenting information and insights from that data in a cohesive application. You and your team won't have control or access for all the types that represent the incoming data.

The classic object oriented design would call for creating types in your application that represent each data type from those multiple data sources. Then, your application would work with those new types, building inheritance hierarchies, creating virtual methods, and implementing abstractions. Those techniques work, and sometimes they are the best tools. Other times you can write less code, and write more clear code using other techniques.

In this tutorial, you'll explore an application that grows as it continues to accept data from multiple sources. 

- Us grades.
- introduce SAT and ACT
- Add a couple other countries
- harry potter grades




## Dispatch using patterns

## The output of a pattern can be the input to another pattern

