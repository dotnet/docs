---
title: Refactor into pure functions - LINQ to XML
description: Learn about pure functions and how to use them to refactor code.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# Refactor into pure functions (LINQ to XML)

An important aspect of pure functional transformations is learning how to refactor code using pure functions.

> [!NOTE]
> The common nomenclature in functional programming is that you refactor programs using pure functions. In Visual Basic and C++, this aligns with the use of functions in the respective languages. However, in C#, functions are called methods. For the purposes of this discussion, a pure function is implemented as a method in C#.

As noted previously in this section, a pure function has two useful characteristics:

- It has no side effects. The function doesn't change any variables or the data of any type outside of the function.
- It's consistent. Given the same set of input data, it will always return the same output value.

One way of transitioning to functional programming is to refactor existing code to eliminate unnecessary side effects and external dependencies. In this way, you can create pure function versions of existing code.

This article discusses what a pure function is and what it's not. The [Tutorial: Manipulate content in a WordprocessingML document](xml-shape-wordprocessingml-documents.md) tutorial shows how to manipulate a WordprocessingML document, and includes two examples of how to refactor using a pure function.

The following examples contrast two non-pure functions and a pure function.

## Example: Implement a non-pure function that changes a static class member

In the following code, the `HyphenatedConcat` function isn't a pure function, because it modifies the `aMember` static class member:

```csharp
public class Program
{
    private static string aMember = "StringOne";

    public static void HyphenatedConcat(string appendStr)
    {
        aMember += '-' + appendStr;
    }

    public static void Main()
    {
        HyphenatedConcat("StringTwo");
        Console.WriteLine(aMember);
    }
}
```

```vb
Module Module1
    Dim aMember As String = "StringOne"

    Public Sub HyphenatedConcat(ByVal appendStr As String)
        aMember = aMember & "-" & appendStr
    End Sub

    Sub Main()
        HyphenatedConcat("StringTwo")
        Console.WriteLine(aMember)
    End Sub
End Module
```

This example produces the following output:

```output
StringOne-StringTwo
```

Note that it's irrelevant whether the data being modified has `public` or `private` access, or is a `static` member, `shared` member, or instance member. A pure function doesn't change any data outside of the function.

## Example: Implement a non-pure function that changes a parameter

Furthermore, the following version of this same function isn't pure because it modifies the contents of its parameter, `sb`.

```csharp
public class Program
{
    public static void HyphenatedConcat(StringBuilder sb, String appendStr)
    {
        sb.Append('-' + appendStr);
    }

    public static void Main()
    {
        StringBuilder sb1 = new StringBuilder("StringOne");
        HyphenatedConcat(sb1, "StringTwo");
        Console.WriteLine(sb1);
    }
}
```

```vb
Module Module1
    Public Sub HyphenatedConcat(ByVal sb As StringBuilder, ByVal appendStr As String)
        sb.Append("-" & appendStr)
    End Sub

    Sub Main()
        Dim sb1 As StringBuilder = New StringBuilder("StringOne")
        HyphenatedConcat(sb1, "StringTwo")
        Console.WriteLine(sb1)
    End Sub
End Module
```

This version of the program produces the same output as the first version, because the `HyphenatedConcat` function has changed the value (state) of its first parameter by invoking the <xref:System.Text.StringBuilder.Append%2A> member function. Note that this alteration occurs despite the fact that `HyphenatedConcat` uses call-by-value parameter passing.

> [!IMPORTANT]
> For reference types, if you pass a parameter by value, it results in a copy of the reference to an object being passed. This copy is still associated with the same instance data as the original reference (until the reference variable is assigned to a new object). Call-by-reference isn't necessarily required for a function to modify a parameter.

## Example: Implement a pure function

This next version of the program shows how to implement the `HyphenatedConcat` function as a pure function.

```csharp
class Program
{
    public static string HyphenatedConcat(string s, string appendStr)
    {
        return (s + '-' + appendStr);
    }

    public static void Main(string[] args)
    {
        string s1 = "StringOne";
        string s2 = HyphenatedConcat(s1, "StringTwo");
        Console.WriteLine(s2);
    }
}
```

```vb
Module Module1
    Public Function HyphenatedConcat(ByVal s As String, ByVal appendStr As String) As String
        Return (s & "-" & appendStr)
    End Function

    Sub Main()
        Dim s1 As String = "StringOne"
        Dim s2 As String = HyphenatedConcat(s1, "StringTwo")
        Console.WriteLine(s2)
    End Sub
End Module
```

Again, this version produces the same line of output: `StringOne-StringTwo`. Note that to retain the concatenated value, it's stored in the intermediate variable `s2`.

One approach that can be very useful is to write functions that are locally impure (that is, they declare and modify local variables) but are globally pure. Such functions have many of the desirable composability characteristics, but avoid some of the more convoluted functional programming idioms, such as having to use recursion when a simple loop would accomplish the same thing.

## Standard query operators

An important characteristic of the standard query operators is that they're implemented as pure functions.

For more information, see [Standard Query Operators Overview (C#)](../../csharp/programming-guide/concepts/linq/standard-query-operators-overview.md) and [Standard Query Operators Overview (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md).

## See also

- [Introduction to pure functional transformations](introduction-pure-functional-transformations.md)
- [Functional programming vs. imperative programming](functional-vs-imperative-programming.md)
