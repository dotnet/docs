---
title: What's new in C# 12 - C# Guide
description: Get an overview of the new features in C# 12.
ms.date: 04/04/2023
---
# What's new in C# 12

The following C# 12 features were introduced in [Visual Studio 17.6 preview 2](https://visualstudio.microsoft.com/vs/preview/). You can also use the latest [.NET 8 preview SDK](https://dotnet.microsoft.com/download/dotnet).

- [Primary constructors](#primary-constructors)

## Primary constructors

You can now create primary constructors in classes and structs. Primary constructors are no longer restricted to record types.

Unlike primary constructors in records, primary constructors in classes and structs don't create properties for each primary constructor parameter. Instead, primary constructor parameters are in scope for the entire body of the class. To ensure that all primary constructor parameters are definitely assigned, all constructors in a class must call the primary constructor using `this()` syntax.

## See also

- [What's new in .NET 8](../../core/whats-new/dotnet-8.md)
