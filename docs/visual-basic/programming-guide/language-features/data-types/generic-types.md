---
title: "Generic Types in Visual Basic (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "generic interfaces"
  - "data type arguments [Visual Basic], defining"
  - "generic delegates"
  - "arguments [Visual Basic], data types"
  - "Of keyword [Visual Basic], using"
  - "delegates, generic"
  - "constraints, Visual Basic generic types"
  - "generic parameters"
  - "data type parameters"
  - "procedures [Visual Basic], generic"
  - "generic procedures"
  - "data types [Visual Basic], generic"
  - "data types [Visual Basic], as parameters"
  - "generics [Visual Basic], generic types"
  - "data types [Visual Basic], as arguments"
  - "generic classes [Visual Basic], Visual Basic"
  - "parameters [Visual Basic], type"
  - "type arguments"
  - "interfaces [Visual Basic], generic"
  - "generics [Visual Basic]"
  - "types [Visual Basic], generic"
  - "parameters [Visual Basic], generic"
  - "generic structures [Visual Basic]"
  - "generic classes [Visual Basic]"
  - "type parameters"
  - "data type arguments"
  - "structures [Visual Basic], generic"
  - "parameters [Visual Basic], data type"
  - "collections, generic"
  - "classes [Visual Basic], generic"
  - "data type parameters [Visual Basic], defining"
  - "type arguments [Visual Basic], defining"
  - "arguments [Visual Basic], type"
ms.assetid: 89f771d9-ecbb-4737-88b8-116b63c6cf4d
caps.latest.revision: 45
author: dotnet-bot
ms.author: dotnetcontent
---
# Generic Types in Visual Basic (Visual Basic)
A *generic type* is a single programming element that adapts to perform the same functionality for a variety of data types. When you define a generic class or procedure, you do not have to define a separate version for each data type for which you might want to perform that functionality.  
  
 An analogy is a screwdriver set with removable heads. You inspect the screw you need to turn and select the correct head for that screw (slotted, crossed, starred). Once you insert the correct head in the screwdriver handle, you perform the exact same function with the screwdriver, namely turning the screw.  
  
 ![Diagram of a screwdriver set as a generic tool](../../../../visual-basic/programming-guide/language-features/data-types/media/genericscrewdriver.gif "GenericScrewDriver")  
Screwdriver set as a generic tool  
  
 When you define a generic type, you parameterize it with one or more data types. This allows the using code to tailor the data types to its requirements. Your code can declare several different programming elements from the generic element, each one acting on a different set of data types. But the declared elements all perform the identical logic, no matter what data types they are using.  
  
 For example, you might want to create and use a queue class that operates on a specific data type such as `String`. You can declare such a class from <xref:System.Collections.Generic.Queue%601?displayProperty=nameWithType>, as the following example shows.  
  
 [!code-vb[VbVbalrDataTypes#1](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-types_1.vb)]  
  
 You can now use `stringQ` to work exclusively with `String` values. Because `stringQ` is specific for `String` instead of being generalized for `Object` values, you do not have late binding or type conversion. This saves execution time and reduces run-time errors.  
  
 For more information on using a generic type, see [How to: Use a Generic Class](../../../../visual-basic/programming-guide/language-features/data-types/how-to-use-a-generic-class.md).  
  
## Example of a Generic Class  
 The following example shows a skeleton definition of a generic class.  
  
 [!code-vb[VbVbalrDataTypes#2](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-types_2.vb)]  
  
 In the preceding skeleton, `t` is a *type parameter*, that is, a placeholder for a data type that you supply when you declare the class. Elsewhere in your code, you can declare various versions of `classHolder` by supplying various data types for `t`. The following example shows two such declarations.  
  
 [!code-vb[VbVbalrDataTypes#3](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-types_3.vb)]  
  
 The preceding statements declare *constructed classes*, in which a specific type replaces the type parameter. This replacement is propagated throughout the code within the constructed class. The following example shows what the `processNewItem` procedure looks like in `integerClass`.  
  
 [!code-vb[VbVbalrDataTypes#4](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-types_4.vb)]  
  
 For a more complete example, see [How to: Define a Class That Can Provide Identical Functionality on Different Data Types](../../../../visual-basic/programming-guide/language-features/data-types/how-to-define-a-class-that-can-provide-identical-functionality.md).  
  
## Eligible Programming Elements  
 You can define and use generic classes, structures, interfaces, procedures, and delegates. Note that the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] defines several generic classes, structures, and interfaces that represent commonly used generic elements. The <xref:System.Collections.Generic?displayProperty=nameWithType> namespace provides dictionaries, lists, queues, and stacks. Before defining your own generic element, see if it is already available in <xref:System.Collections.Generic?displayProperty=nameWithType>.  
  
 Procedures are not types, but you can define and use generic procedures. See [Generic Procedures in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/generic-procedures.md).  
  
## Advantages of Generic Types  
 A generic type serves as a basis for declaring several different programming elements, each of which operates on a specific data type. The alternatives to a generic type are:  
  
1.  A single type operating on the `Object` data type.  
  
2.  A set of *type-specific* versions of the type, each version individually coded and operating on one specific data type such as `String`, `Integer`, or a user-defined type such as `customer`.  
  
 A generic type has the following advantages over these alternatives:  
  
-   **Type Safety.** Generic types enforce compile-time type checking. Types based on `Object` accept any data type, and you must write code to check whether an input data type is acceptable. With generic types, the compiler can catch type mismatches before run time.  
  
-   **Performance.** Generic types do not have to *box* and *unbox* data, because each one is specialized for one data type. Operations based on `Object` must box input data types to convert them to `Object` and unbox data destined for output. Boxing and unboxing reduce performance.  
  
     Types based on `Object` are also late-bound, which means that accessing their members requires extra code at run time. This also reduces performance.  
  
-   **Code Consolidation.** The code in a generic type has to be defined only once. A set of type-specific versions of a type must replicate the same code in each version, with the only difference being the specific data type for that version. With generic types, the type-specific versions are all generated from the original generic type.  
  
-   **Code Reuse.** Code that does not depend on a particular data type can be reused with various data types if it is generic. You can often reuse it even with a data type that you did not originally predict.  
  
-   **IDE Support.** When you use a constructed type declared from a generic type, the integrated development environment (IDE) can give you more support while you are developing your code. For example, IntelliSense can show you the type-specific options for an argument to a constructor or method.  
  
-   **Generic Algorithms.** Abstract algorithms that are type-independent are good candidates for generic types. For example, a generic procedure that sorts items using the <xref:System.IComparable> interface can be used with any data type that implements <xref:System.IComparable>.  
  
## Constraints  
 Although the code in a generic type definition should be as type-independent as possible, you might need to require a certain capability of any data type supplied to your generic type. For example, if you want to compare two items for the purpose of sorting or collating, their data type must implement the <xref:System.IComparable> interface. You can enforce this requirement by adding a *constraint* to the type parameter.  
  
### Example of a Constraint  
 The following example shows a skeleton definition of a class with a constraint that requires the type argument to implement <xref:System.IComparable>.  
  
 [!code-vb[VbVbalrDataTypes#5](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-types_5.vb)]  
  
 If subsequent code attempts to construct a class from `itemManager` supplying a type that does not implement <xref:System.IComparable>, the compiler signals an error.  
  
### Types of Constraints  
 Your constraint can specify the following requirements in any combination:  
  
-   The type argument must implement one or more interfaces  
  
-   The type argument must be of the type of, or inherit from, at most one class  
  
-   The type argument must expose a parameterless constructor accessible to the code that creates objects from it  
  
-   The type argument must be a *reference type*, or it must be a *value type*  
  
 If you need to impose more than one requirement, you use a comma-separated *constraint list* inside braces (`{ }`). To require an accessible constructor, you include the [New Operator](../../../../visual-basic/language-reference/operators/new-operator.md) keyword in the list. To require a reference type, you include the `Class` keyword; to require a value type, you include the `Structure` keyword.  
  
 For more information on constraints, see [Type List](../../../../visual-basic/language-reference/statements/type-list.md).  
  
### Example of Multiple Constraints  
 The following example shows a skeleton definition of a generic class with a constraint list on the type parameter. In the code that creates an instance of this class, the type argument must implement both the <xref:System.IComparable> and <xref:System.IDisposable> interfaces, be a reference type, and expose an accessible parameterless constructor.  
  
 [!code-vb[VbVbalrDataTypes#6](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-types_6.vb)]  
  
## Important Terms  
 Generic types introduce and use the following terms:  
  
-   *Generic Type*. A definition of a class, structure, interface, procedure, or delegate for which you supply at least one data type when you declare it.  
  
-   *Type Parameter*. In a generic type definition, a placeholder for a data type you supply when you declare the type.  
  
-   *Type Argument*. A specific data type that replaces a type parameter when you declare a constructed type from a generic type.  
  
-   *Constraint*. A condition on a type parameter that restricts the type argument you can supply for it. A constraint can require that the type argument must implement a particular interface, be or inherit from a particular class, have an accessible parameterless constructor, or be a reference type or a value type. You can combine these constraints, but you can specify at most one class.  
  
-   *Constructed Type*. A class, structure, interface, procedure, or delegate declared from a generic type by supplying type arguments for its type parameters.  
  
## See Also  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)  
 [Type Characters](../../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Type Conversions in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Of](../../../../visual-basic/language-reference/statements/of-clause.md)  
 [As](../../../../visual-basic/language-reference/statements/as-clause.md)  
 [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)  
 [Covariance and Contravariance](../../concepts/covariance-contravariance/index.md)  
 [Iterators](http://msdn.microsoft.com/library/f45331db-d595-46ec-9142-551d3d1eb1a7)
