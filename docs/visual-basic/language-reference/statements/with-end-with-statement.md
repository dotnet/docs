---
title: "With...End With Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.With"
helpviewer_keywords: 
  - "With keyword [Visual Basic]"
  - "loop structures [Visual Basic], and With...End With statements"
  - "execution [Visual Basic], on object"
  - "instructions, repeating"
  - "With...End With statements [Visual Basic]"
  - "With statement [Visual Basic]"
  - "With statement [Visual Basic], nesting"
  - "objects [Visual Basic], accessing"
  - "With block"
  - "End keyword [Visual Basic], With...End With statements"
ms.assetid: 340d5fbb-4f43-48ec-a024-80843c137817
caps.latest.revision: 34
author: dotnet-bot
ms.author: dotnetcontent
---
# With...End With Statement (Visual Basic)
Executes a series of statements that repeatedly refer to a single object or structure so that the statements can use a simplified syntax when accessing members of the object or structure.  When using a structure, you can only read the values of members or invoke methods, and you get an error if you try to assign values to members of a structure used in a `With...End With` statement.  
  
## Syntax  
  
```  
With objectExpression  
    [ statements ]  
End With  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`objectExpression`|Required. An expression that evaluates to an object. The expression may be arbitrarily complex and is evaluated only once. The expression can evaluate to any data type, including elementary types.|  
|`statements`|Optional. One or more statements between `With` and `End With` that may refer to members of an object that's produced by the evaluation of `objectExpression`.|  
|`End With`|Required. Terminates the definition of the `With` block.|  
  
## Remarks  
 By using `With...End With`, you can perform a series of statements on a specified object without specifying the name of the object multiple times. Within a `With` statement block, you can specify a member of the object starting with a period, as if the `With` statement object preceded it.  
  
 For example, to change multiple properties on a single object, place the property assignment statements inside the `With...End With` block, referring to the object only once instead of once for each property assignment.  
  
 If your code accesses the same object in multiple statements, you gain the following benefits by using the `With` statement:  
  
-   You don't need to evaluate a complex expression multiple times or assign the result to a temporary variable to refer to its members multiple times.  
  
-   You make your code more readable by eliminating repetitive qualifying expressions.  
  
 The data type of `objectExpression` can be any class or structure type or even a Visual Basic elementary type such as `Integer`.  If `objectExpression` results in anything other than an object, you can only read the values of its members or invoke methods, and you get an error if you try to assign values to members of a structure used in a `With...End With` statement.  This is the same error you would get if you invoked a method that returned a structure and immediately accessed and assigned a value to a member of the function’s result, such as `GetAPoint().x = 1`.  The problem in both cases is that the structure exists only on the call stack, and there is no way a modified structure member in these situations can write to  a location such that any other code in the program can observe the change.  
  
 The `objectExpression` is evaluated once, upon entry into the block. You can't reassign the `objectExpression` from within the `With` block.  
  
 Within a `With` block, you can access the methods and properties of only the specified object without qualifying them. You can use methods and properties of other objects, but you must qualify them with their object names.  
  
 You can place one `With...End With` statement within another. Nested `With...End With` statements may be confusing if the objects that are being referred to aren't clear from context. You must provide a fully qualified reference to an object that's in an outer `With` block when the object is referenced from within an inner `With` block.  
  
 You can't branch into a `With` statement block from outside the block.  
  
 Unless the block contains a loop, the statements run only once. You can nest different kinds of control structures. For more information, see [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md).  
  
> [!NOTE]
>  You can use the `With` keyword in object initializers also. For more information and examples, see [Object Initializers: Named and Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md) and [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md).  
>   
>  If you're using a `With` block only to initialize the properties or fields of an object that you've just instantiated, consider using an object initializer instead.  
  
## Example  
 In the following example, each `With` block executes a series of statements on a single object.  
  
 [!code-vb[VbVbalrWithStatement#2](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/with-end-with-statement_1.vb)]  
  
## Example  
 The following example nests `With…End With` statements. Within the nested `With` statement, the syntax refers to the inner object.  
  
 [!code-vb[VbVbalrWithStatement#1](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/with-end-with-statement_2.vb)]  
  
## See Also  
 <xref:System.Collections.Generic.List%601>  
 [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md)  
 [Object Initializers: Named and Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md)  
 [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)
