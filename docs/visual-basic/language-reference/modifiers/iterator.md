---
description: "Learn more about: Iterator (Visual Basic)"
title: "Iterator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Iterator"
helpviewer_keywords: 
  - "Iterator keyword [Visual Basic]"
ms.assetid: 69cb0b04-ac87-49d0-bcfe-810c0d60daff
---
# Iterator (Visual Basic)

Specifies that a function or `Get` accessor is an iterator.  
  
## Remarks  

 An *iterator* performs a custom iteration over a collection. An iterator uses the [Yield](../statements/yield-statement.md) statement to return each element in the collection one at a time. When a `Yield` statement is reached, the current location in code is retained. Execution is restarted from that location the next time that the iterator function is called.  
  
 An iterator can be implemented as a function or as a `Get` accessor of a property definition. The `Iterator` modifier appears in the declaration of the iterator function or `Get` accessor.  
  
 You call an iterator from client code by using a [For Each...Next Statement](../statements/for-each-next-statement.md).  
  
 The return type of an iterator function or `Get` accessor can be <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.IEnumerator>, or <xref:System.Collections.Generic.IEnumerator%601>.  
  
 An iterator cannot have any `ByRef` parameters.  
  
 An iterator cannot occur in an event, instance constructor, static constructor, or static destructor.  
  
 An iterator can be an anonymous function. For more information, see [Iterators](../../programming-guide/concepts/iterators.md).  
  
## Usage  

 The `Iterator` modifier can be used in these contexts:  
  
- [Function Statement](../statements/function-statement.md)  
  
- [Property Statement](../statements/property-statement.md)  
  
## Example 1

 The following example demonstrates an iterator function. The iterator function has a `Yield` statement that is inside a [For…Next](../statements/for-next-statement.md) loop. Each iteration of the [For Each](../statements/for-each-next-statement.md) statement body in `Main` creates a call to the `Power` iterator function. Each call to the iterator function proceeds to the next execution of the `Yield` statement, which occurs during the next iteration of the `For…Next` loop.  
  
 [!code-vb[VbVbalrStatements#98](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class2.vb#98)]  
  
## Example 2  

 The following example demonstrates a `Get` accessor that is an iterator. The `Iterator` modifier is in the property declaration.  
  
 [!code-vb[VbVbalrStatements#99](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class2.vb#99)]  
  
 For additional examples, see [Iterators](../../programming-guide/concepts/iterators.md).  
  
## See also

- <xref:System.Runtime.CompilerServices.IteratorStateMachineAttribute>
- [Iterators](../../programming-guide/concepts/iterators.md)
- [Yield Statement](../statements/yield-statement.md)
