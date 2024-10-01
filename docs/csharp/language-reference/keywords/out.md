---
description: "out keyword - C# Reference"
title: "out keyword"
ms.date: 03/01/2017
f1_keywords: 
  - "out_CSharpKeyword"
  - "out"
helpviewer_keywords: 
  - "out [C#]"
  - "out keyword [C#]"
ms.assetid: 7e911a0c-3f98-4536-87be-d539b7536ca8
---
# out (C# Reference)

You can use the `out` keyword in two contexts:

- As a [parameter modifier](method-parameters.md#out-parameter-modifier), which lets you pass an argument to a method by reference rather than by value.

- In [generic type parameter declarations](out-generic-modifier.md) for interfaces and delegates, which specifies that a type parameter is covariant.

The `out` keyword is especially useful when a method needs to return more than one value since more than one `out` parameter can be used e.g.

```csharp
    public void Main()
    {
        double radiusValue = 3.92781;
        //Calculate the circumference and area of a circle, returning the results to Main().
        CalculateCircumferenceAndArea(radiusValue, out double circumferenceResult, out var areaResult);
        System.Console.WriteLine($"Circumference of a circle with a radius of {radiusValue} is {circumferenceResult}.");
        System.Console.WriteLine($"Area of a circle with a radius of {radiusValue} is {areaResult}.");
        Console.ReadLine();
    }

    //The calculation worker method.
    public static void CalculateCircumferenceAndArea(double radius, out double circumference, out double area)
    {
        circumference = 2 * Math.PI * radius;
        area = Math.PI * (radius * radius);
    }
```

The following limitations apply to using the `out` keyword:

- `out` parameters are not allowed in asynchronous methods.
- `out` parameters are not allowed in iterator methods.
- Properties cannot be passed as `out` parameters.
