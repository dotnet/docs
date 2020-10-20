---
title: Top-level statements - C# tutorial
description: This tutorial shows how you can use top-level statements to experiment and prove concepts while exploring your ideas
ms.date: 10/21/20209
---
# Tutorial: Explore ideas using top level statements to build code as your learn

Introduction and problem statement

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - yada
> - yada
> - yada

## Prerequisites


You'll need to set up your machine to run .NET 5, which includes the C# 9 compiler. The C# 9 compiler is available starting with [Visual Studio 2019 version 16.9 preview 1](https://visualstudio.microsoft.com/vs/preview/) or [.NET 5.0 SDK](https://dot.net/get-dotnet5).

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET Core CLI.

## Start exploring

Top-level statements enables you to avoid the extra ceremony required by placing your program's entry point in a static method in a class. The typical starting point for a new console application looks like the following code:

```csharp
using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

You can start with something that looks like this:

```csharp
using System;

Console.WriteLine("Hello World!");
```

This simplifies what's needed to begin exploring new ideas. You can use top-level statements for scripting scenarios, or to explore. Once you've got the basics working, you can start refactoring the code and create methods, classes, or other assemblies for reusable components you've built. Top-level statements do enable quick experimentation and beginner tutorials. They also provide a smooth path from experimentation to full programs.

Outline:

- what to build
- array
- random
- args
- wait
- refactor
- summary
-