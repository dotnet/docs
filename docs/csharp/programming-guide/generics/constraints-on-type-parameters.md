---
title: "Constraints on Type Parameters (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "generics [C#], type constraints"
  - "type constraints [C#]"
  - "type parameters [C#], constraints"
  - "unbound type parameter [C#]"
ms.assetid: 141b003e-1ddb-4e1c-bcb2-e1c3870e6a51
caps.latest.revision: 41
author: "BillWagner"
ms.author: "wiwagn"
---
# Constraints on Type Parameters (C# Programming Guide)
When you define a generic class, you can apply restrictions to the kinds of types that client code can use for type arguments when it instantiates your class. If client code tries to instantiate your class by using a type that is not allowed by a constraint, the result is a compile-time error. These restrictions are called constraints. Constraints are specified by using the `where` contextual keyword. The following table lists the six types of constraints:  
  
|Constraint|Description|  
|----------------|-----------------|  
|`where T: struct`|The type argument must be a value type. Any value type except <xref:System.Nullable> can be specified. See [Using Nullable Types](../../../csharp/programming-guide/nullable-types/using-nullable-types.md) for more information.|  
|`where T : class`|The type argument must be a reference type; this applies also to any class, interface, delegate, or array type.|  
|`where T : new()`|The type argument must have a public parameterless constructor. When used together with other constraints, the `new()` constraint must be specified last.|  
|`where T : `*\<base class name>*|The type argument must be or derive from the specified base class.|  
|`where T : `*\<interface name>*|The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic.|  
|`where T : U`|The type argument supplied for T must be or derive from the argument supplied for U.|  
  
## Why Use Constraints  
 If you want to examine an item in a generic list to determine whether it is valid or to compare it to some other item, the compiler must have some guarantee that the operator or method it has to call will be supported by any type argument that might be specified by client code. This guarantee is obtained by applying one or more constraints to your generic class definition. For example, the base class constraint tells the compiler that only objects of this type or derived from this type will be used as type arguments. Once the compiler has this guarantee, it can allow methods of that type to be called in the generic class. Constraints are applied by using the contextual keyword `where`. The following code example demonstrates the functionality we can add to the `GenericList<T>` class (in [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)) by applying a base class constraint.  
  
 [!code-csharp[csProgGuideGenerics#11](../../../csharp/programming-guide/generics/codesnippet/CSharp/constraints-on-type-parameters_1.cs)]  
  
 The constraint enables the generic class to use the `Employee.Name` property because all items of type T are guaranteed to be either an `Employee` object or an object that inherits from `Employee`.  
  
 Multiple constraints can be applied to the same type parameter, and the constraints themselves can be generic types, as follows:  
  
 [!code-csharp[csProgGuideGenerics#12](../../../csharp/programming-guide/generics/codesnippet/CSharp/constraints-on-type-parameters_2.cs)]  
  
 By constraining the type parameter, you increase the number of allowable operations and method calls to those supported by the constraining type and all types in its inheritance hierarchy. Therefore, when you design generic classes or methods, if you will be performing any operation on the generic members beyond simple assignment or calling any methods not supported by `System.Object`, you will have to apply constraints to the type parameter.  
  
 When applying the `where T : class` constraint, avoid the `==` and `!=` operators on the type parameter because these operators will test for reference identity only, not for value equality. This is the case even if these operators are overloaded in a type that is used as an argument. The following code illustrates this point; the output is false even though the <xref:System.String> class overloads the `==` operator.  
  
 [!code-csharp[csProgGuideGenerics#13](../../../csharp/programming-guide/generics/codesnippet/CSharp/constraints-on-type-parameters_3.cs)]  
  
 The reason for this behavior is that, at compile time, the compiler only knows that T is a reference type, and therefore must use the default operators that are valid for all reference types. If you must test for value equality, the recommended way is to also apply the `where T : IComparable<T>` constraint and implement that interface in any class that will be used to construct the generic class.  
  
## Constraining Multiple Parameters  
 You can apply constraints to multiple parameters, and multiple constraints to a single parameter, as shown in the following example:  
  
 [!code-csharp[csProgGuideGenerics#64](../../../csharp/programming-guide/generics/codesnippet/CSharp/constraints-on-type-parameters_4.cs)]  
  
## Unbounded Type Parameters  
 Type parameters that have no constraints, such as T in public class `SampleClass<T>{}`, are called unbounded type parameters. Unbounded type parameters have the following rules:  
  
-   The `!=` and `==` operators cannot be used because there is no guarantee that the concrete type argument will support these operators.  
  
-   They can be converted to and from `System.Object` or explicitly converted to any interface type.  
  
-   You can compare to [null](../../../csharp/language-reference/keywords/null.md). If an unbounded parameter is compared to `null`, the comparison will always return false if the type argument is a value type.  
  
## Type Parameters as Constraints  
 The use of a generic type parameter as a constraint is useful when a member function with its own type parameter has to constrain that parameter to the type parameter of the containing type, as shown in the following example:  
  
 [!code-csharp[csProgGuideGenerics#14](../../../csharp/programming-guide/generics/codesnippet/CSharp/constraints-on-type-parameters_5.cs)]  
  
 In the previous example, `T` is a type constraint in the context of the `Add` method, and an unbounded type parameter in the context of the `List` class.  
  
 Type parameters can also be used as constraints in generic class definitions. Note that the type parameter must be declared within the angle brackets together with any other type parameters:  
  
 [!code-csharp[csProgGuideGenerics#15](../../../csharp/programming-guide/generics/codesnippet/CSharp/constraints-on-type-parameters_6.cs)]  
  
 The usefulness of type parameters as constraints with generic classes is very limited because the compiler can assume nothing about the type parameter except that it derives from `System.Object`. Use type parameters as constraints on generic classes in scenarios in which you want to enforce an inheritance relationship between two type parameters.  
  
## See Also  
 <xref:System.Collections.Generic>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)  
 [Generic Classes](../../../csharp/programming-guide/generics/generic-classes.md)  
 [new Constraint](../../../csharp/language-reference/keywords/new-constraint.md)
