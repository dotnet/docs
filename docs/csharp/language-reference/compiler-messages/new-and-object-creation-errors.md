---
title: "Resolve errors and warnings related to `new` expressions and object creation expressions"
description: "This article helps you diagnose and correct compiler errors and warnings related to `new` expressions and object creation expressions"
f1_keywords:
  - "CS0144"
  - "CS0712"
  - "CS1526"
  - "CS8181"
  - "CS8386"
  - "CS8752"
  - "CS8753"
  - "CS8754"
helpviewer_keywords:
  - "CS0144"
  - "CS0712"
  - "CS1526"
  - "CS8181"
  - "CS8386"
  - "CS8752"
  - "CS8753"
  - "CS8754"
ms.date: 05/15/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for `new` expressions and object creation

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS0144**](#anchor-tbd): *Cannot create an instance of the abstract type or interface 'type'*
- [**CS0712**](#anchor-tbd): *Cannot create an instance of the static class 'type'*
- [**CS1526**](#anchor-tbd): *A new expression requires an argument list or (), [], or {} after type*
- [**CS8181**](#anchor-tbd): *'new' cannot be used with tuple type. Use a tuple literal expression instead.*
- [**CS8386**](#anchor-tbd): *Invalid object creation*
- [**CS8752**](#anchor-tbd): *The type 'type' may not be used as the target type of new()*
- [**CS8753**](#anchor-tbd): *Use of new() is not valid in this context*
- [**CS8754**](#anchor-tbd): *There is no target type for 'expression'*

## CS0144

Cannot create an instance of the abstract class or interface 'interface'

You cannot create an instance of an [abstract](../keywords/abstract.md) class or an [interface](../keywords/interface.md). For more information, see [Interfaces](../../fundamentals/types/interfaces.md).

The following sample generates CS0144:

```csharp
// CS0144.cs
interface MyInterface
{
}
public class MyClass
{
   public static void Main()
   {
      MyInterface myInterface = new MyInterface ();   // CS0144
   }
}
```

### How to fix violations

You can solve this problem by implementing one of the two following solutions:

1. Change the type declaration so that it's not abstract: Either remove the abstract keyword from the class declaration, or change the type from an interface to a class.

2. Create a type that's derived from the abstract class or that implements the interface.

## CS0712

Cannot create an instance of the static class 'static class'

It is not possible to create instances of static classes. Static classes are designed to contain static fields and methods, but may not be instantiated.

### Example

The following sample generates CS0712:

```csharp
// CS0712.cs
public static class SC
{
}

public class CMain
{
    public static void Main()
    {
        SC sc = new SC();  // CS0712
    }
}
```

## CS1526

A new expression requires (), [], or {} after type

The [new](../operators/new-operator.md) operator, used to dynamically allocate memory for an object, was not specified correctly.

### Example

The following sample shows how to use `new` to allocate space for an array and an object.

```csharp
// CS1526.cs
public class y
{
    public static int globalCounter = 0;
    public int instanceCounter = 0;
}

public class z
{
    public static void Main()
    {
        y yInstance = new y;   // CS1526
        y[] yArray = new y[10];   // Array of Ys

        for (int i = 0; i < yArray.Length; i++)
            yArray[i] = new y();   // an object of type y
    }
}
```
