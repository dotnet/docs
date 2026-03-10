---
description: "out keyword - C# Reference"
title: "out keyword"
ms.date: 01/22/2026
f1_keywords: 
  - "out_CSharpKeyword"
  - "out"
helpviewer_keywords: 
  - "out [C#]"
  - "out keyword [C#]"
---
# out (C# Reference)

Use the `out` keyword in two contexts:

- As a [parameter modifier](method-parameters.md#out-parameter-modifier), which you use to pass an argument to a method by reference rather than by value.
- In [generic type parameter declarations](out-generic-modifier.md) for interfaces and delegates, which you use to specify that a type parameter is covariant.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The `out` parameter modifier is especially useful when a method needs to return more than one value since you can use more than one `out` parameter. For example,

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

- You can't use `out` parameters in asynchronous methods.
- You can't use `out` parameters in iterator methods.
- You can't pass properties as `out` parameters.
