---
title: "NameOf operator"
description: "Learn how to use the NameOf operator in Visual Basic"
ms.date: 10/27/2019
f1_keywords:
  - "NameOf"
  - "vb.NameOf"
helpviewer_keywords:
  - "NameOf operator [Visual Basic]"
---
# NameOf operator - Visual Basic

The `NameOf` operator obtains the name of a variable, type, or member as the string constant:

```vb
Console.WriteLine(NameOf(System.Collections.Generic))  ' output: Generic
Console.WriteLine(NameOf(List(Of Integer)))  ' output: List
Console.WriteLine(NameOf(List(Of Integer).Count))  ' output: Count
Console.WriteLine(NameOf(List(Of Integer).Add))  ' output: Add

Dim numbers As New List(Of Integer) From { 1, 2, 3 }
Console.WriteLine(NameOf(numbers))  ' output: numbers
Console.WriteLine(NameOf(numbers.Count))  ' output: Count
Console.WriteLine(NameOf(numbers.Add))  ' output: Add
```

As the preceding example shows, in the case of a type and a namespace, the produced name is usually not [fully qualified](~/_csharpstandard/standard/basic-concepts.md#883-fully-qualified-names).

The `NameOf` operator is evaluated at compile time, and has no effect at run time.

You can use the `NameOf` operator to make the argument-checking code more maintainable:

```vb
Private _name As String

Public Property Name As String
    Get
        Return _name
    End Get
    Set
        If value Is Nothing Then
            Throw New ArgumentNullException(NameOf(value), $"{NameOf(name)} cannot be null.")
        End If
    End Set
End Property
```

The `NameOf` operator is available in Visual Basic 14 and later.

## See also

- [Visual Basic Language Reference](../index.md)
- [Operators (Visual Basic)](index.md)
