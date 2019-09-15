---
title: Create virtual extension methods with default interface members
description: Using default interface members you can extend interfaces with optional virtual implementations. 
ms.date: 00/12/2019
---
# Tutorial: Update interfaces with default interface members in C# 8.0

Beginning with C# 8.0 on .NET Core 3.0, you can define an implementation when you declare a member of an interface. This provides new capabilities where you can declare if implementors can or must override the default implementation. You can also specify if an implementation from a class can be overriden by more derived classes.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> * Extend interfaces safely by adding methods with implementations.
> * Create parameterized implementations to provide greater flexibility.
> * Enable implementers to provide a more specific implementation in the form of an override.

## Prerequisites

You’ll need to set up your machine to run .NET Core, including the C# 8.0 preview compiler. The C# 8.0 preview compiler is available starting with [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019), or the latest [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0). Default interface members are available beginning with .NET Core 3.0 preview 4.

## Limitations of extension methods

One way provide behavior that appears to be part of an interface is to define [extension methods](../programming-guide/classes-and-structs/extension-methods.md) that provide the default behavior. This enables interfaces to declare a minimum set of members while providing a greater surface area for any class that implements that interface. This works well. The extension methods in <xref:System.Linq.Enumerable> provide the implementation for any sequence to be the source of a LINQ query.

Extension methods are resolved at compile time, using the declared type of the variable. Classes that implement the interface can provide a better implementation for any extension method. Variable declarations must match the implementing type to enable the compiler to chose that implementation. When the compile time type matches the interface, method calls resolve to the extension method.

Starting with C# 8.0, you can use declare the default implementations as interface methods. Then, every class automatically uses the default implementation. Any class that can provide a better implementation can override the interface method definition with a better algorithm. 

## Design the application.

Consider a home automation application. You'd probably have many different types of lights and indicators that could be used throughout the house. Every light must support APIs to turn them on and off, and to report the current state.

-> different kinds of lights mean different implementations.
-> different interfaces with defaults for those functions.
-> better lights can implement their own.

This gives a complicated set of interfaces, some lights with implementations, and avoids the DDOD.

## Overload resolution: extension methods and interface implementation

## Implications for dynamic

## DIM: Understanding "nearest" implementation