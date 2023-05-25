---
title: Declare and use primary constructors in classes and structs
description: "Learn how and when to declare primary constructors in your class and struct types. Primary constructors provide concise syntax to declare constructor parameters available anywhere in your type."
ms.date: 05/26/2023
---
# Tutorial: Explore primary constructors

C# 12 introduces [*primary constructors*](../../programming-guide/classes-and-structs/instance-constructors.md#primary-constructors), a concise syntax to declare constructors whose parameters are avaiable anywhere in the body of the type.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - When to declare a primary constructor on your type
> - How to call call primary constructors from other constructors
> - How to use primary constructor parameters in members of the type
> - Where primary constructor parameters are stored

## Prerequisites

You'll need to set up your machine to run .NET 8 or later, including the C# 12 or later compiler. The C# 12 compiler is available starting with [Visual Studio 2022 version 17.7](https://visualstudio.microsoft.com/vs) or the [.NET 8 SDK](https://dotnet.microsoft.com/download).

Key learning experiences for this tutorial:

1. declare a primary constructor when parameters are needed in one or more members.
    1. initialize properties (same or different type.)
    1. as a service or dependencies.
    1. pass to base class with primary constructor
1. consider when a reasonable can be used in a default ctor.
1. Use primary ctor parameter as you would use a field.

Caveats:

- Watch for double storage.

## Purpose of primary constructor

## Examples

- struct
- class
- class hierarchy

Scenarios

- initialize property of same type
- initialize property / field of different type
- use as dependency

Keys from the discussion:

- modeled as parameters, not fields | properties
- mutable (like all parameters)
- Can't use `this.` (like all parameters)
- "capture" may be a bad term.
- Parameters that can be used for field (or property) initializers!

## Defaults for parameters

## this, base, and parameterless ctor, oh my

## Double storage

## Summary

You can learn more about primary constructors in the [C# programming guide article on instance constructors](../../programming-guide/classes-and-structs/instance-constructors.md#parameterless-constructors) and the [proposed primary constructor specification](~/_csharplang/proposals/primary-constructors.md).
