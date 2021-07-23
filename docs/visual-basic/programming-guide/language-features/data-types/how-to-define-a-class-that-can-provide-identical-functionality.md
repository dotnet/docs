---
description: "Learn more about: How to: Define a Class That Can Provide Identical Functionality on Different Data Types (Visual Basic)"
title: "How to: Define a Class That Can Provide Identical Functionality on Different Data Types"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "data type arguments [Visual Basic], using"
  - "type parameters [Visual Basic], defining"
  - "data type arguments [Visual Basic], defining"
  - "arguments [Visual Basic], data types"
  - "Of keyword [Visual Basic], using"
  - "constraints, Visual Basic generic types"
  - "generic parameters"
  - "data type parameters"
  - "data type parameters [Visual Basic], using"
  - "generics [Visual Basic], defining classes with type parameters"
  - "data types [Visual Basic], as parameters"
  - "data types [Visual Basic], as arguments"
  - "parameters [Visual Basic], type"
  - "type arguments"
  - "types [Visual Basic], generic"
  - "parameters [Visual Basic], generic"
  - "type parameters"
  - "data type arguments"
  - "parameters [Visual Basic], data type"
  - "generics [Visual Basic], defining generic types"
  - "data type parameters [Visual Basic], defining"
  - "type arguments [Visual Basic], defining"
  - "arguments [Visual Basic], type"
ms.assetid: a914adf8-e68f-4819-a6b1-200d1cf1c21c
---
# How to: Define a Class That Can Provide Identical Functionality on Different Data Types (Visual Basic)

You can define a class from which you can create objects that provide identical functionality on different data types. To do this, you specify one or more *type parameters* in the definition. The class can then serve as a template for objects that use various data types. A class defined in this way is called a *generic class*.  
  
 The advantage of defining a generic class is that you define it just once, and your code can use it to create many objects that use a wide variety of data types. This results in better performance than defining the class with the `Object` type.  
  
 In addition to classes, you can also define and use generic structures, interfaces, procedures, and delegates.  
  
### To define a class with a type parameter  
  
1. Define the class in the normal way.  
  
2. Add `(Of` *typeparameter*`)` immediately after the class name to specify a type parameter.  
  
3. If you have more than one type parameter, make a comma-separated list inside the parentheses. Do not repeat the `Of` keyword.  
  
4. If your code performs operations on a type parameter other than simple assignment, follow that type parameter with an `As` clause to add one or more *constraints*. A constraint guarantees that the type supplied for that type parameter satisfies a requirement such as the following:  
  
    - Supports an operation, such as `>`, that your code performs  
  
    - Supports a member, such as a method, that your code accesses  
  
    - Exposes a parameterless constructor  
  
     If you do not specify any constraints, the only operations and members your code can use are those supported by the [Object Data Type](../../../language-reference/data-types/object-data-type.md). For more information, see [Type List](../../../language-reference/statements/type-list.md).  
  
5. Identify every class member that is to be declared with a supplied type, and declare it `As` `typeparameter`. This applies to internal storage, procedure parameters, and return values.  
  
6. Be sure your code uses only operations and methods that are supported by any data type it can supply to `itemType`.  
  
     The following example defines a class that manages a very simple list. It holds the list in the internal array `items`, and the using code can declare the data type of the list elements. A parameterized constructor allows the using code to set the upper bound of `items`, and the parameterless constructor sets this to 9 (for a total of 10 items).  
  
     [!code-vb[VbVbalrDataTypes#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb#7)]  
  
     You can declare a class from `simpleList` to hold a list of `Integer` values, another class to hold a list of `String` values, and another to hold `Date` values. Except for the data type of the list members, objects created from all these classes behave identically.  
  
     The type argument that the using code supplies to `itemType` can be an intrinsic type such as `Boolean` or `Double`, a structure, an enumeration, or any type of class, including one that your application defines.  
  
     You can test the class `simpleList` with the following code.  
  
     [!code-vb[VbVbalrDataTypes#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb#8)]  
  
## See also

- [Data Types](index.md)
- [Generic Types in Visual Basic](generic-types.md)
- [Language Independence and Language-Independent Components](../../../../standard/language-independence.md)
- [Of](../../../language-reference/statements/of-clause.md)
- [Type List](../../../language-reference/statements/type-list.md)
- [How to: Use a Generic Class](how-to-use-a-generic-class.md)
- [Object Data Type](../../../language-reference/data-types/object-data-type.md)
