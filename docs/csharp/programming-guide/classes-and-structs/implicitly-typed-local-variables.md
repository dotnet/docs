---
title: "Implicitly Typed Local Variables (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "implicitly-typed local variables [C#]"
  - "var [C#]"
ms.assetid: b9218fb2-ef5d-4814-8a8e-2bc29b0bbc9b
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
---
# Implicitly Typed Local Variables (C# Programming Guide)
Local variables can be declared without giving an explicit type. The `var` keyword instructs the compiler to infer the type of the variable from the expression on the right side of the initialization statement. The inferred type may be a built-in type, an anonymous type, a user-defined type, or a type defined in the .NET Framework class library. For more information about how to initialize arrays with `var`, see [Implicitly Typed Arrays](../../../csharp/programming-guide/arrays/implicitly-typed-arrays.md).  
  
 The following examples show various ways in which local variables can be declared with `var`:  
  
 [!code-csharp[csProgGuideLINQ#43](../../../csharp/programming-guide/arrays/codesnippet/CSharp/implicitly-typed-local-variables_1.cs)]  
  
 It is important to understand that the `var` keyword does not mean "variant" and does not indicate that the variable is loosely typed, or late-bound. It just means that the compiler determines and assigns the most appropriate type.  
  
 The `var` keyword may be used in the following contexts:  
  
-   On local variables (variables declared at method scope) as shown in the previous example.  
  
-   In a [for](../../../csharp/language-reference/keywords/for.md) initialization statement.  
  
    ```  
    for(var x = 1; x < 10; x++)  
    ```  
  
-   In a [foreach](../../../csharp/language-reference/keywords/foreach-in.md) initialization statement.  
  
    ```  
    foreach(var item in list){...}  
    ```  
  
-   In a [using](../../../csharp/language-reference/keywords/using-statement.md) statement.  
  
    ```  
    using (var file = new StreamReader("C:\\myfile.txt")) {...}  
    ```  
  
 For more information, see [How to: Use Implicitly Typed Local Variables and Arrays in a Query Expression](../../../csharp/programming-guide/classes-and-structs/how-to-use-implicitly-typed-local-variables-and-arrays-in-a-query-expression.md).  
  
## var and Anonymous Types  
 In many cases the use of `var` is optional and is just a syntactic convenience. However, when a variable is initialized with an anonymous type you must declare the variable as `var` if you need to access the properties of the object at a later point. This is a common scenario in [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query expressions. For more information, see [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md).  
  
 From the perspective of your source code, an anonymous type has no name. Therefore, if a query variable has been initialized with `var`, then the only way to access the properties in the returned sequence of objects is to use `var` as the type of the iteration variable in the `foreach` statement.  
  
 [!code-csharp[csProgGuideLINQ#44](../../../csharp/programming-guide/arrays/codesnippet/CSharp/implicitly-typed-local-variables_2.cs)]  
  
## Remarks  
 The following restrictions apply to implicitly-typed variable declarations:  
  
-   `var` can only be used when a local variable is declared and initialized in the same statement; the variable cannot be initialized to null, or to a method group or an anonymous function.  
  
-   `var` cannot be used on fields at class scope.  
  
-   Variables declared by using `var` cannot be used in the initialization expression. In other words, this expression is legal`: int i = (i = 20);` but this expression produces a compile-time error: `var i = (i = 20);`  
  
-   Multiple implicitly-typed variables cannot be initialized in the same statement.  
  
-   If a type named `var` is in scope, then the `var` keyword will resolve to that type name and will not be treated as part of an implicitly typed local variable declaration.  
  
 You may find that `var` can also be useful with query expressions in which the exact constructed type of the query variable is difficult to determine. This can occur with grouping and ordering operations.  
  
 The `var` keyword can also be useful when the specific type of the variable is tedious to type on the keyboard, or is obvious, or does not add to the readability of the code. One example where `var` is helpful in this manner is with nested generic types such as those used with group operations. In the following query, the type of the query variable is `IEnumerable<IGrouping<string, Student>>`. As long as you and others who must maintain your code understand this, there is no problem with using implicit typing for convenience and brevity.  
  
 [!code-csharp[cscsrefQueryKeywords#13](../../../csharp/language-reference/keywords/codesnippet/CSharp/implicitly-typed-local-variables_3.cs)]  
  
 However, the use of `var` does have at least the potential to make your code more difficult to understand for other developers. For that reason, the C# documentation generally uses `var` only when it is required.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [Implicitly Typed Arrays](../../../csharp/programming-guide/arrays/implicitly-typed-arrays.md)  
 [How to: Use Implicitly Typed Local Variables and Arrays in a Query Expression](../../../csharp/programming-guide/classes-and-structs/how-to-use-implicitly-typed-local-variables-and-arrays-in-a-query-expression.md)  
 [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md)  
 [Object and Collection Initializers](../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md)  
 [var](../../../csharp/language-reference/keywords/var.md)  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)  
 [LINQ (Language-Integrated Query)](http://msdn.microsoft.com/library/a73c4aec-5d15-4e98-b962-1274021ea93d)  
 [for](../../../csharp/language-reference/keywords/for.md)  
 [foreach, in](../../../csharp/language-reference/keywords/foreach-in.md)  
 [using Statement](../../../csharp/language-reference/keywords/using-statement.md)
