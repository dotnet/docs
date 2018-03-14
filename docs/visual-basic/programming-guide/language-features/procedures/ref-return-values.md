---
title: "Ref Return Values (Visual Basic)"
ms.custom: ""
ms.date: 04/28/2017
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "variables [Visual Basic]"
  - "ref return values [Visual Basic]"
  - "ref returns [Visual Basic]"
ms.assetid: 5ef0cc69-eb3a-4a67-92a2-78585f223cb5
author: rpetrusha
ms.author: ronpet
---
# Support for reference return values (Visual Basic)

Starting with C# 7, the C# language supports *reference return values*. One way to understand reference return values is that they are the opposite of arguments that are passed by reference to a method. When an argument passed by reference is modified, the changes are reflected in value of the variable on the caller. When an method provides a reference return value to a caller, modifications made to the reference return value by the caller are reflected in the called method's data.

Visual Basic does not allow you to author methods with reference return values, but it does allow you to consume reference return values. In other words, you can call a method with a reference return value and modify that return value, and changes to the reference return value are reflected in the called method's data.

## Modifying the ref return value directly

For methods that always succeed and have no `ByRef` parameters, you can modify the reference return value directly. You do this by assigning the new value to the expressions that returns the reference return value. 

The following C# example defines a `NumericValue.IncrementValue` method that increments an internal value and returns it as a reference return value. 

[!code-csharp[Ref-Return](../../../../../samples/snippets/visualbasic/programming-guide/language-features/procedures/ref-returns1.cs)]

The reference return value is then modified by the caller in the following Visual Basic example. Note that the line with the `NumericValue.IncrementValue` method call does not assign a value to the method. Instead, it assigns a value to the reference return value returned by the method.

[!code-vb[Ref-Return](../../../../../samples/snippets/visualbasic/programming-guide/language-features/procedures/use-ref-returns1.vb)]

## Using a helper method

In other cases, modifying the reference return value of a method call directly may not always be desirable. For example, a search method that returns a string may not always find a match. In that case, you want to modify the reference return value only if the search is successful.

The following C# example illustrates this scenario. It defines a `Sentence` class written in C# includes a `FindNext` method that finds the next word in a sentence that begins with a specified substring. The string is returned as a reference return value, and a `Boolean` variable passed by reference to the method indicates whether the search was successful. The reference return value indicates that the caller can not only read the returned value; he or she can also modify it, and that modification is reflected in the data contained internally in the `Sentence` class.

[!code-csharp[Ref-Return](../../../../../samples/snippets/visualbasic/getting-started/ref-returns.cs)]

Directly modifying the reference return value in this case is not reliable, since the method call may fail to find a match and return the first word in the sentence. In that case, the caller will inadvertently modify the first word of the sentence. This could be prevented by the caller returning a `null` (or `Nothing` in Visual Basic). But in that case, attempting to modify a string whose value is `Nothing` throws a <xref:System.NullReferenceException>. If could also be prevented by the caller returning <xref:System.String.Empty?displayProperty=nameWithType>, but this requires that the caller define a string variable whose value is <xref:System.String.Empty?displayProperty=nameWithType>. While the caller can modify that string, the modification itself serves no purpose, since the modified string has no relationship to the words in the sentence stored by the `Sentence` class.

The best way to handle this scenario is to pass the reference return value by reference to a helper method. The helper method then contains the logic to determine whether the method call succeeded and, if it did, to modify the reference return value. The following example provides a possible implementation.

[!code-vb[Ref-Return](../../../../../samples/snippets/visualbasic/getting-started/ref-return-helper.vb#1)]

## See also

[Passing arguments by value and by reference](passing-arguments-by-value-and-by-reference.md)   
[Procedures in Visual Basic](index.md)   


