---
description: "out keyword - C# Reference"
title: "out keyword - C# Reference"
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

- As a [parameter modifier](out-parameter-modifier.md), which lets you pass an argument to a method by reference rather than by value.

- In [generic type parameter declarations](out-generic-modifier.md) for interfaces and delegates, which specifies that a type parameter is covariant.

## Example
The out keyword can be especially useful when you want to get 2 values back from a method for 2 local variables, without using a custom object, tuple or class-scoped variable. In the below example, the method `IsDivisibleBy2` takes in an integer, determines if it is divisible by 2, returns the result as a `bool` and outs the division result.

   
    public static bool IsDivisibleBy2(int x, out double dividedBy2)
    {
        dividedBy2 = (x / 2);

        if (x % 2 == 0) { return true; }
        else { return false; }
    }

Calling the method:

    static void Main(string[] args)
    {
        double result;
        int testNumber = 10;

        if (IsDivisibleBy2(testNumber, out result))
        {
            Console.WriteLine($"Number is divisible by 2. {testNumber}/2 = {result}");
        }
        else
        {
            Console.WriteLine("Number is NOT divisible by 2.");
        }
    }


## See also

- [C# Reference](../index.md)
