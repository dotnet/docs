---
title: "C# Features That Support LINQ"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "LINQ [C#], features supporting LINQ"
ms.assetid: 524b0078-ebfd-45a7-b390-f2ceb9d84797
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
---
# C# Features That Support LINQ
The following section introduces new language constructs introduced in C# 3.0. Although these new features are all used to a degree with [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] queries, they are not limited to [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] and can be used in any context where you find them useful.  
  
## Query Expressions  
 Queries expressions use a declarative syntax similar to SQL or XQuery to query over IEnumerable collections. At compile time query syntax is converted to method calls to a [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] provider's implementation of the standard query operator extension methods. Applications control the standard query operators that are in scope by specifying the appropriate namespace with a `using` directive. The following query expression takes an array of strings, groups them according to the first character in the string, and orders the groups.  
  
```  
var query = from str in stringArray  
            group str by str[0] into stringGroup  
            orderby stringGroup.Key  
            select stringGroup;  
```  
  
 For more information, see [LINQ Query Expressions](../../../../csharp/programming-guide/linq-query-expressions/index.md).  
  
## Implicitly Typed Variables (var)  
 Instead of explicitly specifying a type when you declare and initialize a variable, you can use the [var](../../../../csharp/language-reference/keywords/var.md) modifier to instruct the compiler to infer and assign the type, as shown here:  
  
```  
var number = 5;  
var name = "Virginia";  
var query = from str in stringArray  
            where str[0] == 'm'  
            select str;  
```  
  
 Variables declared as `var` are just as strongly-typed as variables whose type you specify explicitly. The use of `var` makes it possible to create anonymous types, but it can be used for any local variable. Arrays can also be declared with implicit typing.  
  
 For more information, see [Implicitly Typed Local Variables](../../../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md).  
  
## Object and Collection Initializers  
 Object and collection initializers make it possible to initialize objects without explicitly calling a constructor for the object. Initializers are typically used in query expressions when they project the source data into a new data type. Assuming a class named `Customer` with public `Name` and `Phone` properties, the object initializer can be used as in the following code:  
  
```  
Customer cust = new Customer { Name = "Mike", Phone = "555-1212" };  
```  
  
 For more information, see [Object and Collection Initializers](../../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md).  
  
## Anonymous Types  
 An anonymous type is constructed by the compiler and the type name is only available to the compiler. Anonymous types provide a convenient way to group a set of properties temporarily in a query result without having to define a separate named type. Anonymous types are initialized with a new expression and an object initializer, as shown here:  
  
```  
select new {name = cust.Name, phone = cust.Phone};  
```  
  
 For more information, see [Anonymous Types](../../../../csharp/programming-guide/classes-and-structs/anonymous-types.md).  
  
## Extension Methods  
 An extension method is a static method that can be associated with a type, so that it can be called as if it were an instance method on the type. This feature enables you to, in effect, "add" new methods to existing types without actually modifying them. The standard query operators are a set of extension methods that provide [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query functionality for any type that implements <xref:System.Collections.Generic.IEnumerable%601>.  
  
 For more information, see [Extension Methods](../../../../csharp/programming-guide/classes-and-structs/extension-methods.md).  
  
## Lambda Expressions  
 A lambda expression is an inline function that uses the => operator to separate input parameters from the function body and can be converted at compile time to a delegate or an expression tree. In [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] programming, you will encounter lambda expressions when you make direct method calls to the standard query operators.  
  
 For more information, see:  
  
-   [Anonymous Functions](../../../../csharp/programming-guide/statements-expressions-operators/anonymous-functions.md)  
  
-   [Lambda Expressions](../../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md)  
  
-   [Expression Trees (C#)](../../../../csharp/programming-guide/concepts/expression-trees/index.md)  
  
## Auto-Implemented Properties  
 Auto-implemented properties make property-declaration more concise. When you declare a property as shown in the following example, the compiler will create a private, anonymous backing field that is not accessible except through the property getter and setter.  
  
```  
public string Name {get; set;}  
```  
  
 For more information, see [Auto-Implemented Properties](../../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md).  
  
## See Also  
 [Language-Integrated Query (LINQ) (C#)](../../../../csharp/programming-guide/concepts/linq/index.md)
