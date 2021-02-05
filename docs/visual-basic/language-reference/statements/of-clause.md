---
description: "Learn more about: Of Clause (Visual Basic)"
title: "Of Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "Of"
  - "vb.Of"
  - "vb.of"
helpviewer_keywords: 
  - "Of keyword [Visual Basic]"
  - "arguments [Visual Basic], data types"
  - "constraints, Visual Basic generic types"
  - "generic parameters"
  - "generics [Visual Basic], constraints"
  - "parameters [Visual Basic], type"
  - "types [Visual Basic], generic"
  - "parameters [Visual Basic], generic"
  - "type parameters"
  - "data type arguments"
ms.assetid: 0db8f65c-65af-4089-ab7f-6fcfecb60444
---
# Of Clause (Visual Basic)

Introduces an `Of` clause, which identifies a *type parameter* on a *generic* class, structure, interface, delegate, or procedure. For information on generic types, see [Generic Types in Visual Basic](../../programming-guide/language-features/data-types/generic-types.md).  
  
## Using the Of Keyword  

 The following code example uses the `Of` keyword to define the outline of a class that takes two type parameters. It *constrains* the `keyType` parameter by the <xref:System.IComparable> interface, which means the consuming code must supply a type argument that implements <xref:System.IComparable>. This is necessary so that the `add` procedure can call the <xref:System.IComparable.CompareTo%2A?displayProperty=nameWithType> method. For more information on constraints, see [Type List](type-list.md).  
  
```vb  
Public Class Dictionary(Of entryType, keyType As IComparable)  
    Public Sub add(ByVal e As entryType, ByVal k As keyType)  
        Dim dk As keyType  
        If k.CompareTo(dk) = 0 Then  
        End If  
    End Sub  
    Public Function find(ByVal k As keyType) As entryType  
    End Function  
End Class  
```  
  
 If you complete the preceding class definition, you can construct a variety of `dictionary` classes from it. The types you supply to `entryType` and `keyType` determine what type of entry the class holds and what type of key it associates with each entry. Because of the constraint, you must supply to `keyType` a type that implements <xref:System.IComparable>.  
  
 The following code example creates an object that holds `String` entries and associates an `Integer` key with each one. `Integer` implements <xref:System.IComparable> and therefore satisfies the constraint on `keyType`.  
  
```vb  
Dim d As New dictionary(Of String, Integer)  
```  
  
 The `Of` keyword can be used in these contexts:  
  
 [Class Statement](class-statement.md)  
  
 [Delegate Statement](delegate-statement.md)  
  
 [Function Statement](function-statement.md)  
  
 [Interface Statement](interface-statement.md)  
  
 [Structure Statement](structure-statement.md)  
  
 [Sub Statement](sub-statement.md)  
  
## See also

- <xref:System.IComparable>
- [Type List](type-list.md)
- [Generic Types in Visual Basic](../../programming-guide/language-features/data-types/generic-types.md)
- [In](../modifiers/in-generic-modifier.md)
- [Out](../modifiers/out-generic-modifier.md)
