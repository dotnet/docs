---
title: "New Operator"
ms.date: 07/20/2015
f1_keywords:
  - "vb.new"
  - "vb.NewConstraint"
helpviewer_keywords:
  - "constraints, Visual Basic generic types"
  - "generics [Visual Basic], constraints"
  - "constraints, New keyword [Visual Basic]"
  - "New constraint"
  - "New keyword [Visual Basic]"
ms.assetid: d7d566d7-fe0e-4336-91f7-641a542de4d0
---
# New Operator (Visual Basic)

Introduces a `New` clause to create a new object instance, specifies a constructor constraint on a type parameter, or identifies a `Sub` procedure as a class constructor.

## Remarks

In a declaration or assignment statement, a `New` clause must specify a defined class from which the instance can be created. This means that the class must expose one or more constructors that the calling code can access.

You can use a `New` clause in a declaration statement or an assignment statement. When the statement runs, it calls the appropriate constructor of the specified class, passing any arguments you have supplied. The following example demonstrates this by creating instances of a `Customer` class that has two constructors, one that takes no parameters and one that takes a string parameter:

[!code-vb[VbVbalrKeywords#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrKeywords/VB/Class6.vb#11)]

Since arrays are classes, `New` can create a new array instance, as shown in the following example:

[!code-vb[VbVbalrKeywords#12](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrKeywords/VB/Class6.vb#12)]

The common language runtime (CLR) throws an <xref:System.OutOfMemoryException> error if there is insufficient memory to create the new instance.

> [!NOTE]
> The `New` keyword is also used in type parameter lists to specify that the supplied type must expose an accessible parameterless constructor. For more information about type parameters and constraints, see [Type List](../statements/type-list.md).

To create a constructor procedure for a class, set the name of a `Sub` procedure to the `New` keyword. For more information, see [Object Lifetime: How Objects Are Created and Destroyed](../../programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md).

The `New` keyword can be used in these contexts:

- [Dim Statement](../statements/dim-statement.md)
- [Of](../statements/of-clause.md)
- [Sub Statement](../statements/sub-statement.md)

## See also

- <xref:System.OutOfMemoryException>
- [Keywords](../keywords/index.md)
- [Type List](../statements/type-list.md)
- [Generic Types in Visual Basic](../../programming-guide/language-features/data-types/generic-types.md)
- [Object Lifetime: How Objects Are Created and Destroyed](../../programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md)
