---
title: "new Operator (C# Reference)"
ms.date: 03/15/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "new operator keyword [C#]"
ms.assetid: a212b697-a79b-4105-9923-1f7b108036e8
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# new Operator (C# Reference)
Used to create objects and invoke constructors. For example:  
  
```csharp
Class1 obj  = new Class1();  
```  
  
 It is also used to create instances of anonymous types:  
  
```csharp
var query = from cust in customers  
            select new { Name = cust.Name, Address = cust.PrimaryAddress };  
```  
  
 The `new` operator is also used to invoke the default constructor for value types. For example:  
  
```csharp
int i = new int();  
```  
  
 In the preceding statement, `i` is initialized to `0`, which is the default value for the type `int`. The statement has the same effect as the following:  
  
```csharp
int i = 0;  
```  
  
 For a complete list of default values, see [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md).  
  
 Remember that it is an error to declare a default constructor for a [struct](../../../csharp/language-reference/keywords/struct.md) because every value type implicitly has a public default constructor. It is possible to declare parameterized constructors on a struct type to set its initial values, but this is only necessary if values other than the default are required.  
  
 Both value-type objects such as structs and reference-type objects such as classes are destroyed automatically, but value-type objects are destroyed when their containing context is destroyed, whereas reference-type objects are destroyed by the garbage collector at an unspecified time after the last reference to them is removed. For types that contain resources such as file handles, or network connections, it is desirable to employ deterministic cleanup to ensure that the resources they contain are released as soon as possible. For more information, see [using Statement](../../../csharp/language-reference/keywords/using-statement.md).  
  
 The `new` operator cannot be overloaded.  
  
 If the `new` operator fails to allocate memory, it throws the exception, <xref:System.OutOfMemoryException>.  
  
## Example  
 In the following example, a `struct` object and a class object are created and initialized by using the `new` operator and then assigned values. The default and the assigned values are displayed.  
  
 [!code-csharp[csrefKeywordsOperator#7](codesnippet/CSharp/new-operator_1.cs)]  
  
 Notice in the example that the default value of a string is `null`. Therefore, it is not displayed.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)  
 [new](../../../csharp/language-reference/keywords/new.md)  
 [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md)
