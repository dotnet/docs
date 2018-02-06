---
title: "where (generic type constraint) (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "whereconstraint"
  - "whereconstraint_CSharpKeyword"
helpviewer_keywords: 
  - "where (generic type constraint) [C#]"
ms.assetid: d7aa871b-0714-416a-bab2-96f87ada4310
caps.latest.revision: 10
author: "BillWagner"
ms.author: "wiwagn"
---
# where (generic type constraint) (C# Reference)
In a generic type definition, the `where` clause is used to specify constraints on the types that can be used as arguments for a type parameter defined in a generic declaration. For example, you can declare a generic class, `MyGenericClass`, such that the type parameter `T` implements the <xref:System.IComparable%601> interface:  
  
```csharp  
public class MyGenericClass<T> where T:IComparable { }  
```  
  
> [!NOTE]
>  For more information on the where clause in a query expression, see [where clause](../../../csharp/language-reference/keywords/where-clause.md).  
  
 In addition to interface constraints, a `where` clause can include a base class constraint, which states that a type must have the specified class as a base class (or be that class itself) in order to be used as a type argument for that generic type. If such a constraint is used, it must appear before any other constraints on that type parameter.  
  
 [!code-csharp[csrefKeywordsContextual#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/where-generic-type-constraint_1.cs)]  
  
 The `where` clause may also include a constructor constraint. It is possible to create an instance of a type parameter using the new operator; however, in order to do so the type parameter must be constrained by the constructor constraint, `new()`. The [new() Constraint](../../../csharp/language-reference/keywords/new-constraint.md) lets the compiler know that any type argument supplied must have an accessible parameterless--or default-- constructor. For example:  
  
 [!code-csharp[csrefKeywordsContextual#7](../../../csharp/language-reference/keywords/codesnippet/CSharp/where-generic-type-constraint_2.cs)]  
  
 The `new()` constraint appears last in the `where` clause.  
  
 With multiple type parameters, use one `where` clause for each type parameter, for example:  
  
 [!code-csharp[csrefKeywordsContextual#8](../../../csharp/language-reference/keywords/codesnippet/CSharp/where-generic-type-constraint_3.cs)]  
  
 You can also attach constraints to type parameters of generic methods, like this:  
  
```csharp  
public bool MyMethod<T>(T t) where T : IMyInterface { }  
```  
  
 Notice that the syntax to describe type parameter constraints on delegates is the same as that of methods:  
  
```csharp  
delegate T MyDelegate<T>() where T : new()  
```  
  
 For information on generic delegates, see [Generic Delegates](../../../csharp/programming-guide/generics/generic-delegates.md).  
  
 For details on the syntax and use of constraints, see [Constraints on Type Parameters](../../../csharp/programming-guide/generics/constraints-on-type-parameters.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)  
 [new Constraint](../../../csharp/language-reference/keywords/new-constraint.md)  
 [Constraints on Type Parameters](../../../csharp/programming-guide/generics/constraints-on-type-parameters.md)
