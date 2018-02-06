---
title: "Type List (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "StructureConstraint"
  - "vb.StructureConstraint"
  - "ClassConstraint"
  - "vb.ClassConstraint"
helpviewer_keywords: 
  - "class constraint"
  - "constraints, Visual Basic generic types"
  - "generic parameters"
  - "generics [Visual Basic], constraints"
  - "generics [Visual Basic], type list"
  - "structure constraint"
  - "constraints, in type parameters"
  - "generics [Visual Basic], generic types"
  - "parameters [Visual Basic], type"
  - "constraints, Structure keyword"
  - "type parameters [Visual Basic], constraints"
  - "types [Visual Basic], generic"
  - "parameters [Visual Basic], generic"
  - "generics [Visual Basic], type parameters"
  - "type parameters"
  - "constraints, Class keyword"
ms.assetid: 56db947a-2ae8-40f2-a70a-960764e9d0db
caps.latest.revision: 33
author: dotnet-bot
ms.author: dotnetcontent
---
# Type List (Visual Basic)
Specifies the *type parameters* for a *generic* programming element. Multiple parameters are separated by commas. Following is the syntax for one type parameter.  
  
## Syntax  
  
```  
[genericmodifier] typename [ As constraintlist ]  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`genericmodifier`|Optional. Can be used only in generic interfaces and delegates. You can declare a type covariant by using the [Out](../../../visual-basic/language-reference/modifiers/out-generic-modifier.md) keyword or contravariant by using the [In](../../../visual-basic/language-reference/modifiers/in-generic-modifier.md) keyword. See [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md).|  
|`typename`|Required. Name of the type parameter. This is a placeholder, to be replaced by a defined type supplied by the corresponding type argument.|  
|`constraintlist`|Optional. List of requirements that constrain the data type that can be supplied for `typename`. If you have multiple constraints, enclose them in curly braces (`{ }`) and separate them with commas. You must introduce the constraint list with the [As](../../../visual-basic/language-reference/statements/as-clause.md) keyword. You use `As` only once, at the beginning of the list.|  
  
## Remarks  
 Every generic programming element must take at least one type parameter. A type parameter is a placeholder for a specific type (a *constructed element*) that client code specifies when it creates an instance of the generic type. You can define a generic class, structure, interface, procedure, or delegate.  
  
 For more information on when to define a generic type, see [Generic Types in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/generic-types.md). For more information on type parameter names, see [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).  
  
## Rules  
  
-   **Parentheses.** If you supply a type parameter list, you must enclose it in parentheses, and you must introduce the list with the [Of](../../../visual-basic/language-reference/statements/of-clause.md) keyword. You use `Of` only once, at the beginning of the list.  
  
-   **Constraints.** A list of *constraints* on a type parameter can include the following items in any combination:  
  
    -   Any number of interfaces. The supplied type must implement every interface in this list.  
  
    -   At most one class. The supplied type must inherit from that class.  
  
    -   The `New` keyword. The supplied type must expose a parameterless constructor that your generic type can access. This is useful if you constrain a type parameter by one or more interfaces. A type that implements interfaces does not necessarily expose a constructor, and depending on the access level of a constructor, the code within the generic type might not be able to access it.  
  
    -   Either the `Class` keyword or the `Structure` keyword. The `Class` keyword constrains a generic type parameter to require that any type argument passed to it be a reference type, for example a string, array, or delegate, or an object created from a class. The `Structure` keyword constrains a generic type parameter to require that any type argument passed to it be a value type, for example a structure, enumeration, or elementary data type. You cannot include both `Class` and `Structure` in the same `constraintlist`.  
  
     The supplied type must satisfy every requirement you include in `constraintlist`.  
  
     Constraints on each type parameter are independent of constraints on other type parameters.  
  
## Behavior  
  
-   **Compile-Time Substitution.** When you create a constructed type from a generic programming element, you supply a defined type for each type parameter. The Visual Basic compiler substitutes that supplied type for every occurrence of `typename` within the generic element.  
  
-   **Absence of Constraints.** If you do not specify any constraints on a type parameter, your code is limited to the operations and members supported by the [Object Data Type](../../../visual-basic/language-reference/data-types/object-data-type.md) for that type parameter.  
  
## Example  
 The following example shows a skeleton definition of a generic dictionary class, including a skeleton function to add a new entry to the dictionary.  
  
 [!code-vb[VbVbalrStatements#3](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/type-list_1.vb)]  
  
## Example  
 Because `dictionary` is generic, the code that uses it can create a variety of objects from it, each having the same functionality but acting on a different data type. The following example shows a line of code that creates a `dictionary` object with `String` entries and `Integer` keys.  
  
 [!code-vb[VbVbalrStatements#4](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/type-list_2.vb)]  
  
## Example  
 The following example shows the equivalent skeleton definition generated by the preceding example.  
  
 [!code-vb[VbVbalrStatements#5](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/type-list_3.vb)]  
  
## See Also  
 [Of](../../../visual-basic/language-reference/statements/of-clause.md)  
 [New Operator](../../../visual-basic/language-reference/operators/new-operator.md)  
 [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)  
 [Object Data Type](../../../visual-basic/language-reference/data-types/object-data-type.md)  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
 [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
 [How to: Use a Generic Class](../../../visual-basic/programming-guide/language-features/data-types/how-to-use-a-generic-class.md)  
 [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md)  
 [In](../../../visual-basic/language-reference/modifiers/in-generic-modifier.md)  
 [Out](../../../visual-basic/language-reference/modifiers/out-generic-modifier.md)
