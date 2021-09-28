---
description: "Learn more about: Anonymous Type Definition (Visual Basic)"
title: "Anonymous Type Definition"
ms.date: 07/20/2015
helpviewer_keywords:
  - "anonymous types [Visual Basic], type definition"
ms.assetid: 7a8a0ddc-55ba-4d67-869e-87a84d938bac
---
# Anonymous Type Definition (Visual Basic)

In response to the declaration of an instance of an anonymous type, the compiler creates a new class definition that contains the specified properties for the type.

## Compiler-Generated Code

For the following definition of `product`, the compiler creates a new class definition that contains properties `Name`, `Price`, and `OnHand`.

[!code-vb[VbVbalrAnonymousTypes#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#25)]

The class definition contains property definitions similar to the following. Notice that there is no `Set` method for the key properties. The values of key properties are read-only.

```vb
Public Class $Anonymous1
    Private _name As String
    Private _price As Double
    Private _onHand As Integer
     Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Price() As Double
        Get
            Return _price
        End Get
    End Property

    Public Property OnHand() As Integer
        Get
            Return _onHand
        End Get
        Set(ByVal Value As Integer)
            _onHand = Value
        End Set
    End Property

End Class
```

In addition, anonymous type definitions contain a parameterless constructor. Constructors that require parameters are not permitted.

If an anonymous type declaration contains at least one key property, the type definition overrides three members inherited from <xref:System.Object>: <xref:System.Object.Equals%2A>, <xref:System.Object.GetHashCode%2A>, and <xref:System.Object.ToString%2A>. If no key properties are declared, only <xref:System.Object.ToString%2A> is overridden. The overrides provide the following functionality:

- `Equals` returns `True` if two anonymous type instances are the same instance, or if they meet the following conditions:

  - They have the same number of properties.

  - The properties are declared in the same order, with the same names and the same inferred types. Name comparisons are not case-sensitive.

  - At least one of the properties is a key property, and the `Key` keyword is applied to the same properties.

  - Comparison of each corresponding pair of key properties returns `True`.

    For example, in the following examples, `Equals` returns `True` only for `employee01` and `employee08`. The comment before each line specifies the reason why the new instance does not match `employee01`.

    [!code-vb[VbVbalrAnonymousTypes#24](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#24)]

- `GetHashcode` provides an appropriately unique GetHashCode algorithm. The algorithm uses only the key properties to compute the hash code.

- `ToString` returns a string of concatenated property values, as shown in the following example. Both key and non-key properties are included.

  [!code-vb[VbVbalrAnonymousTypes#29](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#29)]

Explicitly named properties of an anonymous type cannot conflict with these generated methods. That is, you cannot use `.Equals`, `.GetHashCode`, or `.ToString` to name a property.

Anonymous type definitions that include at least one key property also implement the <xref:System.IEquatable%601?displayProperty=nameWithType> interface, where `T` is the type of the anonymous type.

> [!NOTE]
> Anonymous type declarations create the same anonymous type only if they occur in the same assembly, their properties have the same names and the same inferred types, the properties are declared in the same order, and the same properties are marked as key properties.

## See also

- [Anonymous Types](anonymous-types.md)
- [How to: Infer Property Names and Types in Anonymous Type Declarations](how-to-infer-property-names-and-types-in-anonymous-type-declarations.md)
