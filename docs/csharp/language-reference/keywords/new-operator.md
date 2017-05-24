---
title: "new Operator (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "new operator keyword [C#]"
ms.assetid: a212b697-a79b-4105-9923-1f7b108036e8
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# new Operator (C# Reference)
Used to create objects and invoke constructors. For example:  
  
```  
Class1 obj  = new Class1();  
```  
  
 It is also used to create instances of anonymous types:  
  
```  
var query = from cust in customers  
            select new {Name = cust.Name, Address = cust.PrimaryAddress};  
```  
  
 The `new` operator is also used to invoke the default constructor for value types. For example:  
  
```  
int i = new int();  
```  
  
 In the preceding statement, `i` is initialized to `0`, which is the default value for the type `int`. The statement has the same effect as the following:  
  
```  
int i = 0;  
```  
  
 For a complete list of default values, see [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md).  
  
 Remember that it is an error to declare a default constructor for a [struct](../../../csharp/language-reference/keywords/struct.md) because every value type implicitly has a public default constructor. It is possible to declare parameterized constructors on a struct type to set its initial values, but this is only necessary if values other than the default are required.  
  
 Value-type objects such as structs are created on the stack, while reference-type objects such as classes are created on the heap. Both types of objects are destroyed automatically, but objects based on value types are destroyed when they go out of scope, whereas objects based on reference types are destroyed at an unspecified time after the last reference to them is removed. For reference types that consume fixed resources such as large amounts of memory, file handles, or network connections, it is sometimes desirable to employ deterministic finalization to ensure that the object is destroyed as soon as possible. For more information, see [using Statement](../../../csharp/language-reference/keywords/using-statement.md).  
  
 The `new` operator cannot be overloaded.  
  
 If the `new` operator fails to allocate memory, it throws the exception, <xref:System.OutOfMemoryException>.  
  
## Example  
 In the following example, a `struct` object and a class object are created and initialized by using the `new` operator and then assigned values. The default and the assigned values are displayed.  
  
 [!code-cs[csrefKeywordsOperator#7](../../../csharp/language-reference/keywords/codesnippet/CSharp/new-operator_1.cs)]  
  
 Notice in the example that the default value of a string is `null`. Therefore, it is not displayed.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)   
 [new](../../../csharp/language-reference/keywords/new.md)   
 [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md)