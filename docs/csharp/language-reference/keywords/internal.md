---
description: "internal - C# Reference"
title: "internal keyword"
ms.date: 01/21/2026
f1_keywords: 
  - "internal_CSharpKeyword"
  - "internal"
helpviewer_keywords: 
  - "internal keyword [C#]"
---
# internal (C# reference)

The `internal` keyword is an [access modifier](./access-modifiers.md) for types and type members.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

> [!NOTE]
> This article covers `internal` access. The `internal` keyword is also part of the [`protected internal`](./protected-internal.md) access modifier.

You can access internal types or members only within files in the same [assembly](../../../standard/assembly/index.md), as shown in the following example:

```csharp
public class BaseClass
{
    // Only accessible within the same assembly.
    internal static int x = 0;
}
```

For a comparison of `internal` with the other access modifiers, see [Accessibility Levels](./accessibility-levels.md) and [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

An `assembly` is an executable or dynamic link library (DLL) produced from compiling one or more source files.

For more information about assemblies, see [Assemblies in .NET](../../../standard/assembly/index.md).

A common use of internal access is in component-based development because it enables a group of components to cooperate in a private manner without being exposed to the rest of the application code. For example, a framework for building graphical user interfaces could provide `Control` and `Form` classes that cooperate by using members with internal access. Since these members are internal, they aren't exposed to code that uses the framework.

It's an error to reference a type or a member with internal access outside the assembly where you defined it.

## Examples

This example contains two files, `Assembly1.cs` and `Assembly1_a.cs`. The first file contains an internal base class, `BaseClass`. In the second file, an attempt to instantiate `BaseClass` produces an error.

```csharp
// Assembly1.cs
// Compile with: /target:library
internal class BaseClass
{
   public static int intM = 0;
}
```

```csharp
// Assembly1_a.cs
// Compile with: /reference:Assembly1.dll
class TestAccess
{
   static void Main()
   {
      var myBase = new BaseClass();   // CS0122
   }
}
```

In this example, use the same files you used in the first example, but change the accessibility level of `BaseClass` to `public`. Also change the accessibility level of the member `intM` to `internal`. In this case, you can instantiate the class, but you can't access the internal member.

```csharp
// Assembly2.cs
// Compile with: /target:library
public class BaseClasS
{
   internal static int intM = 0;
}
```

```csharp
// Assembly2_a.cs
// Compile with: /reference:Assembly2.dll
public class TestAccesS
{
   static void Main()
   {
      var myBase = new BaseClass();   // Ok.
      BaseClass.intM = 444;    // CS0117
   }
}
```

## C# Language Specification

For more information, see [Declared accessibility](~/_csharpstandard/standard/basic-concepts.md#752-declared-accessibility) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Keywords](./index.md)
- [Access Modifiers](./access-modifiers.md)
- [Accessibility Levels](./accessibility-levels.md)
- [Modifiers](index.md)
- [public](./public.md)
- [private](./private.md)
- [protected](./protected.md)
