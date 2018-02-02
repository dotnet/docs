---
title: "Anonymous Types (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.AnonymousType"
helpviewer_keywords: 
  - "anonymous types [Visual Basic], about anonymous types"
  - "anonymous types [Visual Basic]"
  - "types [Visual Basic], anonymous"
ms.assetid: 7b87532c-4b3e-4398-8503-6ea9d67574a4
caps.latest.revision: 46
author: dotnet-bot
ms.author: dotnetcontent
---
# Anonymous Types (Visual Basic)
Visual Basic supports anonymous types, which enable you to create objects without writing a class definition for the data type. Instead, the compiler generates a class for you. The class has no usable name, inherits directly from <xref:System.Object>, and contains the properties you specify in declaring the object. Because the name of the data type is not specified, it is referred to as an *anonymous type*.  
  
 The following example declares and creates variable `product` as an instance of an anonymous type that has two properties, `Name` and `Price`.  
  
 [!code-vb[VbVbalrAnonymousTypes#1](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_1.vb)]  
  
 A *query expression* uses anonymous types to combine columns of data selected by a query. You cannot define the type of the result in advance, because you cannot predict the columns a particular query might select. Anonymous types enable you to write a query that selects any number of columns, in any order. The compiler creates a data type that matches the specified properties and the specified order.  
  
 In the following examples, `products` is a list of product objects, each of which has many properties. Variable `namePriceQuery` holds the definition of a query that, when it is executed, returns a collection of instances of an anonymous type that has two properties, `Name` and `Price`.  
  
 [!code-vb[VbVbalrAnonymousTypes#2](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_2.vb)]  
  
 Variable `nameQuantityQuery` holds the definition of a query that, when it is executed, returns a collection of instances of an anonymous type that has two properties, `Name` and `OnHand`.  
  
 [!code-vb[VbVbalrAnonymousTypes#3](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_3.vb)]  
  
 For more information about the code created by the compiler for an anonymous type, see [Anonymous Type Definition](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-type-definition.md).  
  
> [!CAUTION]
>  The name of the anonymous type is compiler generated and may vary from compilation to compilation. Your code should not use or rely on the name of an anonymous type because the name might change when a project is recompiled.  
  
## Declaring an Anonymous Type  
 The declaration of an instance of an anonymous type uses an initializer list to specify the properties of the type. You can specify only properties when you declare an anonymous type, not other class elements such as methods or events. In the following example, `product1` is an instance of an anonymous type that has two properties: `Name` and `Price`.  
  
 [!code-vb[VbVbalrAnonymousTypes#4](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_4.vb)]  
  
 If you designate properties as key properties, you can use them to compare two anonymous type instances for equality. However, the values of key properties cannot be changed. See the Key Properties section later in this topic for more information.  
  
 Notice that declaring an instance of an anonymous type is like declaring an instance of a named type by using an object initializer:  
  
 [!code-vb[VbVbalrAnonymousTypes#5](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_5.vb)]  
  
 For more information about other ways to specify anonymous type properties, see [How to: Infer Property Names and Types in Anonymous Type Declarations](../../../../visual-basic/programming-guide/language-features/objects-and-classes/how-to-infer-property-names-and-types-in-anonymous-type-declarations.md).  
  
## Key Properties  
 Key properties differ from non-key properties in several fundamental ways:  
  
-   Only the values of key properties are compared in order to determine whether two instances are equal.  
  
-   The values of key properties are read-only and cannot be changed.  
  
-   Only key property values are included in the compiler-generated hash code algorithm for an anonymous type.  
  
### Equality  
 Instances of anonymous types can be equal only if they are instances of the same anonymous type. The compiler treats two instances as instances of the same type if they meet the following conditions:  
  
-   They are declared in the same assembly.  
  
-   Their properties have the same names, the same inferred types, and are declared in the same order. Name comparisons are not case-sensitive.  
  
-   The same properties in each are marked as key properties.  
  
-   At least one property in each declaration is a key property.  
  
 An instance of an anonymous types that has no key properties is equal only to itself.  
  
 [!code-vb[VbVbalrAnonymousTypes#6](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_6.vb)]  
  
 Two instances of the same anonymous type are equal if the values of their key properties are equal. The following examples illustrate how equality is tested.  
  
 [!code-vb[VbVbalrAnonymousTypes#7](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_7.vb)]  
  
### Read-Only Values  
 The values of key properties cannot be changed. For example, in `prod8` in the previous example, the `Name` and `Price` fields are `read-only`, but `OnHand` can be changed.  
  
 [!code-vb[VbVbalrAnonymousTypes#8](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_8.vb)]  
  
## Anonymous Types from Query Expressions  
 Query expressions do not always require the creation of anonymous types. When possible, they use an existing type to hold the column data. This occurs when the query returns either whole records from the data source, or only one field from each record. In the following code examples, `customers` is a collection of objects of a `Customer` class. The class has many properties, and you can include one or more of them in the query result, in any order. In the first two examples, no anonymous types are required because the queries select elements of named types:  
  
-   `custs1` contains a collection of strings, because `cust.Name` is a string.  
  
     [!code-vb[VbVbalrAnonymousTypes#30](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_9.vb)]  
  
-   `custs2` contains a collection of `Customer` objects, because each element of `customers` is a `Customer` object, and the whole element is selected by the query.  
  
     [!code-vb[VbVbalrAnonymousTypes#31](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_10.vb)]  
  
 However, appropriate named types are not always available. You might want to select customer names and addresses for one purpose, customer ID numbers and locations for another, and customer names, addresses, and order histories for a third. Anonymous types enable you to select any combination of properties, in any order, without first declaring a new named type to hold the result. Instead, the compiler creates an anonymous type for each compilation of properties. The following query selects only the customer's name and ID number from each `Customer` object in `customers`. Therefore, the compiler creates an anonymous type that contains only those two properties.  
  
 [!code-vb[VbVbalrAnonymousTYpes#32](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_11.vb)]  
  
 Both the names and the data types of the properties in the anonymous type are taken from the arguments to `Select`, `cust.Name` and `cust.ID`. The properties in an anonymous type that is created by a query are always key properties. When `custs3` is executed in the following `For Each` loop, the result is a collection of instances of an anonymous type with two key properties, `Name` and `ID`.  
  
 [!code-vb[VbVbalrAnonymousTypes#33](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_12.vb)]  
  
 The elements in the collection represented by `custs3` are strongly typed, and you can use IntelliSense to navigate through the available properties and to verify their types.  
  
 For more information, see [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md).  
  
## Deciding Whether to Use Anonymous Types  
 Before you create an object as an instance of an anonymous class, consider whether that is the best option. For example, if you want to create a temporary object to contain related data, and you have no need for other fields and methods that a complete class might contain, an anonymous type is a good solution. Anonymous types are also convenient if you want a different selection of properties for each declaration, or if you want to change the order of the properties. However, if your project includes several objects that have the same properties, in a fixed order, you can declare them more easily by using a named type with a class constructor. For example, with an appropriate constructor, it is easier to declare several instances of a `Product` class than it is to declare several instances of an anonymous type.  
  
 [!code-vb[VbVbalrAnonymousTypes#9](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_13.vb)]  
  
 Another advantage of named types is that the compiler can catch an accidental mistyping of a property name. In the previous examples, `firstProd2`, `secondProd2`, and `thirdProd2` are intended to be instances of the same anonymous type. However, if you were to accidentally declare `thirdProd2` in one of the following ways, its type would be different from that of `firstProd2` and `secondProd2`.  
  
 [!code-vb[VbVbalrAnonymousTypes#10](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/anonymous-types_14.vb)]  
  
 More importantly, there are limitations on the use of anonymous types that do not apply to instances of named types. `firstProd2`, `secondProd2`, and `thirdProd2` are instances of the same anonymous type. However, the name for the shared anonymous type is not available and cannot appear where a type name is expected in your code. For example, an anonymous type cannot be used to define a method signature, to declare another variable or field, or in any type declaration. As a result, anonymous types are not appropriate when you have to share information across methods.  
  
## An Anonymous Type Definition  
 In response to the declaration of an instance of an anonymous type, the compiler creates a new class definition that contains the specified properties.  
  
 If the anonymous type contains at least one key property, the definition overrides three members inherited from <xref:System.Object>: <xref:System.Object.Equals%2A>, <xref:System.Object.GetHashCode%2A>, and <xref:System.Object.ToString%2A>. The code produced for testing equality and determining the hash code value considers only the key properties. If the anonymous type contains no key properties, only <xref:System.Object.ToString%2A> is overridden. Explicitly named properties of an anonymous type cannot conflict with these generated methods. That is, you cannot use `.Equals`, `.GetHashCode`, or `.ToString` to name a property.  
  
 Anonymous type definitions that have at least one key property also implement the <xref:System.IEquatable%601?displayProperty=nameWithType> interface, where `T` is the type of the anonymous type.  
  
 For more information about the code created by the compiler and the functionality of the overridden methods, see [Anonymous Type Definition](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-type-definition.md).  
  
## See Also  
 [Object Initializers: Named and Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md)  
 [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [How to: Infer Property Names and Types in Anonymous Type Declarations](../../../../visual-basic/programming-guide/language-features/objects-and-classes/how-to-infer-property-names-and-types-in-anonymous-type-declarations.md)  
 [Anonymous Type Definition](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-type-definition.md)  
 [Key](../../../../visual-basic/language-reference/modifiers/key.md)
