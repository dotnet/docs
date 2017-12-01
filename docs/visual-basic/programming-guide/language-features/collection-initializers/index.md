---
title: "Collection Initializers (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.CollectionInitializer"
helpviewer_keywords: 
  - "collection initializers [Visual Basic]"
ms.assetid: a9290329-77b0-4fdf-ae75-8fc17287f469
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
---
# Collection Initializers (Visual Basic)
*Collection initializers* provide a shortened syntax that enables you to create a collection and populate it with an initial set of values. Collection initializers are useful when you are creating a collection from a set of known values, for example, a list of menu options or categories, an initial set of numeric values, a static list of strings such as day or month names, or geographic locations such as a list of states that is used for validation.  
  
 For more information about collections, see [Collections](http://msdn.microsoft.com/library/e76533a9-5033-4a0b-b003-9c2be60d185b).  
  
 You identify a collection initializer by using the `From` keyword followed by braces (`{}`). This is similar to the array literal syntax that is described in [Arrays](../../../../visual-basic/programming-guide/language-features/arrays/index.md). The following examples show various ways to use collection initializers to create collections.  
  
 [!code-vb[VbVbalrCollectionInitializers#1](../../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializers/VB/Module1.vb#1)]  
  
> [!NOTE]
>  C# also provides collection initializers. C# collection initializers provide the same functionality as Visual Basic collection initializers. For more information about C# collection initializers, see [Object and Collection Initializers](../../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md).  
  
## Syntax  
 A collection initializer consists of a list of comma-separated values that are enclosed in braces (`{}`), preceded by the `From` keyword, as shown in the following code.  
  
 [!code-vb[VbVbalrCollectionInitializers#2](../../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializers/VB/Module1.vb#2)]  
  
 When you create a collection, such as a <xref:System.Collections.Generic.List%601> or a <xref:System.Collections.Generic.Dictionary%602>, you must supply the collection type before the collection initializer, as shown in the following code.  
  
 [!code-vb[VbVbalrCollectionInitializers#13](../../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializers/VB/Module1.vb#13)]  
  
> [!NOTE]
>  You cannot combine both a collection initializer and an object initializer to initialize the same collection object. You can use object initializers to initialize objects in a collection initializer.  
  
## Creating a Collection by Using a Collection Intializer  
 When you create a collection by using a collection initializer, each value that is supplied in the collection initializer is passed to the appropriate `Add` method of the collection. For example, if you create a <xref:System.Collections.Generic.List%601> by using a collection initializer, each string value in the collection initializer is passed to the <xref:System.Collections.Generic.List%601.Add%2A> method. If you want to create a collection by using a collection initializer, the specified type must be valid collection type. Examples of valid collection types include classes that implement the <xref:System.Collections.Generic.IEnumerable%601> interface or inherit the <xref:System.Collections.CollectionBase> class. The specified type must also expose an `Add` method that meets the following criteria.  
  
-   The `Add` method must be available from the scope in which the collection initializer is being called. The `Add` method does not have to be public if you are using the collection initializer in a scenario where non-public methods of the collection can be accessed.  
  
-   The `Add` method must be an instance member or `Shared` member of the collection class, or an extension method.  
  
-   An `Add` method must exist that can be matched, based on overload resolution rules, to the types that are supplied in the collection initializer.  
  
 For example, the following code example shows how to create a `List(Of Customer)` collection by using a collection initializer. When the code is run, each `Customer` object is passed to the `Add(Customer)` method of the generic list.  
  
 [!code-vb[VbVbalrCollectionInitializers#9](../../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializers/VB/Module1.vb#9)]  
  
 The following code example shows equivalent code that does not use a collection initializer.  
  
 [!code-vb[VbVbalrCollectionInitializers#10](../../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializers/VB/Module1.vb#10)]  
  
 If the collection has an `Add` method that has parameters that match the constructor for the `Customer` object, you could nest parameter values for the `Add` method within collection initializers, as discussed in the next section. If the collection does not have such an `Add` method, you can create one as an extension method. For an example of how to create an `Add` method as an extension method for a collection, see [How to: Create an Add Extension Method Used by a Collection Initializer](../../../../visual-basic/programming-guide/language-features/collection-initializers/how-to-create-an-add-extension-method-used-by-a-collection-initializer.md). For an example of how to create a custom collection that can be used with a collection initializer, see [How to: Create a Collection Used by a Collection Initializer](../../../../visual-basic/programming-guide/language-features/collection-initializers/how-to-create-a-collection-used-by-a-collection-initializer.md).  
  
## Nesting Collection Initializers  
 You can nest values within a collection initializer to identify a specific overload of an `Add` method for the collection that is being created. The values passed to the `Add` method must be separated by commas and enclosed in braces (`{}`), like you would do in an array literal or collection initializer.  
  
 When you create a collection by using nested values, each element of the nested value list is passed as an argument to the `Add` method that matches the element types. For example, the following code example creates a <xref:System.Collections.Generic.Dictionary%602> in which the keys are of type `Integer` and the values are of type `String`. Each of the nested value lists is matched to the <xref:System.Collections.Generic.Dictionary%602.Add%2A> method for the `Dictionary`.  
  
 [!code-vb[VbVbalrCollectionInitializers#5](../../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializers/VB/Module1.vb#5)]  
  
 The previous code example is equivalent to the following code.  
  
 [!code-vb[VbVbalrCollectionInitializers#6](../../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCollectionInitializers/VB/Module1.vb#6)]  
  
 Only nested value lists from the first level of nesting are sent to the `Add` method for the collection type. Deeper levels of nesting are treated as array literals and the nested value lists are not matched to the `Add` method of any collection.  
  
## Related Topics  
  
|Title|Description|  
|---|---|  
|[How to: Create an Add Extension Method Used by a Collection Initializer](../../../../visual-basic/programming-guide/language-features/collection-initializers/how-to-create-an-add-extension-method-used-by-a-collection-initializer.md)|Shows how to create an extension method called `Add` that can be used to populate a collection with values from a collection initializer.|  
|[How to: Create a Collection Used by a Collection Initializer](../../../../visual-basic/programming-guide/language-features/collection-initializers/how-to-create-a-collection-used-by-a-collection-initializer.md)|Shows how to enable use of a collection initializer by including an `Add` method in a collection class that implements `IEnumerable`.|  
  
## See Also  
 [Collections](http://msdn.microsoft.com/library/e76533a9-5033-4a0b-b003-9c2be60d185b)  
 [Arrays](../../../../visual-basic/programming-guide/language-features/arrays/index.md)  
 [Object Initializers: Named and Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md)  
 [New Operator](../../../../visual-basic/language-reference/operators/new-operator.md)  
 [Auto-Implemented Properties](../../../../visual-basic/programming-guide/language-features/procedures/auto-implemented-properties.md)  
 [How to: Initialize an Array Variable in Visual Basic](../../../../visual-basic/programming-guide/language-features/arrays/how-to-initialize-an-array-variable.md)  
 [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)  
 [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [How to: Create a List of Items](../../../../visual-basic/programming-guide/concepts/linq/how-to-create-a-list-of-items.md)
