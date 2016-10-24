---
title: "new Operator (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "new operator keyword [C#]"
ms.assetid: a212b697-a79b-4105-9923-1f7b108036e8
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
  
 For a complete list of default values, see [Default Values Table](../keywords/default-values-table--csharp-reference-.md).  
  
 Remember that it is an error to declare a default constructor for a [struct](../keywords/struct--csharp-reference-.md) because every value type implicitly has a public default constructor. It is possible to declare parameterized constructors on a struct type to set its initial values, but this is only necessary if values other than the default are required.  
  
 Value-type objects such as structs are created on the stack, while reference-type objects such as classes are created on the heap. Both types of objects are destroyed automatically, but objects based on value types are destroyed when they go out of scope, whereas objects based on reference types are destroyed at an unspecified time after the last reference to them is removed. For reference types that consume fixed resources such as large amounts of memory, file handles, or network connections, it is sometimes desirable to employ deterministic finalization to ensure that the object is destroyed as soon as possible. For more information, see [using Statement](../keywords/using-statement--csharp-reference-.md).  
  
 The `new` operator cannot be overloaded.  
  
 If the `new` operator fails to allocate memory, it throws the exception, <xref:System.OutOfMemoryException>.  
  
## Example  
 In the following example, a `struct` object and a class object are created and initialized by using the `new` operator and then assigned values. The default and the assigned values are displayed.  
  
 [!code[csrefKeywordsOperator#7](../keywords/codesnippet/CSharp/new-operator--csharp-reference-_1.cs)]  
  
 Notice in the example that the default value of a string is `null`. Therefore, it is not displayed.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Operator Keywords](../keywords/operator-keywords--csharp-reference-.md)   
 [new](../keywords/new--csharp-reference-.md)   
 [Anonymous Types](../classes-and-structs/anonymous-types--csharp-programming-guide-.md)