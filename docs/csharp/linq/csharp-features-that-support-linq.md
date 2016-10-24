---
title: "C# Features That Support LINQ"
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
  - "LINQ [C#], features supporting LINQ"
ms.assetid: 524b0078-ebfd-45a7-b390-f2ceb9d84797
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# C# Features That Support LINQ
The following section introduces new language constructs introduced in C# 3.0. Although these new features are all used to a degree with [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] queries, they are not limited to [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] and can be used in any context where you find them useful.  
  
## Query Expressions  
 Queries expressions use a declarative syntax similar to SQL or XQuery to query over IEnumerable collections. At compile time query syntax is converted to method calls to a [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] provider's implementation of the standard query operator extension methods. Applications control the standard query operators that are in scope by specifying the appropriate namespace with a `using` directive. The following query expression takes an array of strings, groups them according to the first character in the string, and orders the groups.  
  
```  
var query = from str in stringArray  
            group str by str[0] into stringGroup  
            orderby stringGroup.Key  
            select stringGroup;  
```  
  
 For more information, see [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md).  
  
## Implicitly Typed Variables (var)  
 Instead of explicitly specifying a type when you declare and initialize a variable, you can use the [var](../keywords/var--csharp-reference-.md) modifier to instruct the compiler to infer and assign the type, as shown here:  
  
```  
var number = 5;  
var name = "Virginia";  
var query = from str in stringArray  
            where str[0] == 'm'  
            select str;  
```  
  
 Variables declared as `var` are just as strongly-typed as variables whose type you specify explicitly. The use of `var` makes it possible to create anonymous types, but it can be used for any local variable. Arrays can also be declared with implicit typing.  
  
 For more information, see [Implicitly Typed Local Variables](../classes-and-structs/implicitly-typed-local-variables--csharp-programming-guide-.md).  
  
## Object and Collection Initializers  
 Object and collection initializers make it possible to initialize objects without explicitly calling a constructor for the object. Initializers are typically used in query expressions when they project the source data into a new data type. Assuming a class named `Customer` with public `Name` and `Phone` properties, the object initializer can be used as in the following code:  
  
```  
Customer cust = new Customer { Name = "Mike", Phone = "555-1212" };  
```  
  
 For more information, see [Object and Collection Initializers](../classes-and-structs/object-and-collection-initializers--csharp-programming-guide-.md).  
  
## Anonymous Types  
 An anonymous type is constructed by the compiler and the type name is only available to the compiler. Anonymous types provide a convenient way to group a set of properties temporarily in a query result without having to define a separate named type. Anonymous types are initialized with a new expression and an object initializer, as shown here:  
  
```  
select new {name = cust.Name, phone = cust.Phone};  
```  
  
 For more information, see [Anonymous Types](../classes-and-structs/anonymous-types--csharp-programming-guide-.md).  
  
## Extension Methods  
 An extension method is a static method that can be associated with a type, so that it can be called as if it were an instance method on the type. This feature enables you to, in effect, "add" new methods to existing types without actually modifying them. The standard query operators are a set of extension methods that provide [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] query functionality for any type that implements <xref:System.Collections.Generic.IEnumerable`1>.  
  
 For more information, see [Extension Methods](../classes-and-structs/extension-methods--csharp-programming-guide-.md).  
  
## Lambda Expressions  
 A lambda expression is an inline function that uses the => operator to separate input parameters from the function body and can be converted at compile time to a delegate or an expression tree. In [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] programming, you will encounter lambda expressions when you make direct method calls to the standard query operators.  
  
 For more information, see:  
  
-   [Anonymous Functions](../statements-expressions-operators/anonymous-functions--csharp-programming-guide-.md)  
  
-   [Lambda Expressions](../statements-expressions-operators/lambda-expressions--csharp-programming-guide-.md)  
  
-   [Expression Trees (C#)](../expression-trees/expression-trees--csharp-.md)  
  
## Auto-Implemented Properties  
 Auto-implemented properties make property-declaration more concise. When you declare a property as shown in the following example, the compiler will create a private, anonymous backing field that is not accessible except through the property getter and setter.  
  
```  
public string Name {get; set;}  
```  
  
 For more information, see [Auto-Implemented Properties](../classes-and-structs/auto-implemented-properties--csharp-programming-guide-.md).  
  
## See Also  
 [Language-Integrated Query (LINQ) (C#)](../linq/language-integrated-query--linq---csharp-.md)