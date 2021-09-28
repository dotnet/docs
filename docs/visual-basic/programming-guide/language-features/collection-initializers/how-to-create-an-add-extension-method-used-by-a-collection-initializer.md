---
description: "Learn more about: How to: Create an Add Extension Method Used by a Collection Initializer (Visual Basic)"
title: "How to: Create an Add Extension Method Used by a Collection Initializer"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "collection initializers [Visual Basic]"
ms.assetid: f64b52c7-8b11-4410-93a6-cb3aeebcc772
---
# How to: Create an Add Extension Method Used by a Collection Initializer (Visual Basic)

When you use a collection initializer to create a collection, the Visual Basic compiler searches for an `Add` method of the collection type for which the parameters for the `Add` method match the types of the values in the collection initializer. This `Add` method is used to populate the collection with the values from the collection initializer.  
  
 If no matching `Add` method exists and you cannot modify the code for the collection, you can add an extension method called `Add` that takes the parameters that are required by the collection initializer. This is typically what you need to do when you use collection initializers for generic collections.  
  
## Example  

 The following example shows how to add an extension method to the generic <xref:System.Collections.Generic.List%601> type so that a collection initializer can be used to add objects of type `Employee`. The extension method enables you to use the shortened collection initializer syntax.  
  
 [!code-vb[VbVbalrCollectionInitializersHowTo1#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializersHowTo1/VB/Module1.vb#1)]  
  
 [!code-vb[VbVbalrCollectionInitializersHowTo1#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializersHowTo1/VB/Module1.vb#2)]  
  
 [!code-vb[VbVbalrCollectionInitializersHowTo1#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializersHowTo1/VB/Module1.vb#3)]  
  
## See also

- [Collection Initializers](index.md)
- [How to: Create a Collection Used by a Collection Initializer](how-to-create-a-collection-used-by-a-collection-initializer.md)
