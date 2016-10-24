---
title: "What&#39;s New for Visual C#"
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
ms.assetid: 9f18dc26-27fa-4603-a639-b573f07a117b
caps.latest.revision: 39
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
# What&#39;s New for Visual C#
This page lists key feature names for each version of C# with descriptions of the new and enhanced features in the lastest version of the language.  
  
## Previous Versions  
 C# 1, Visual Studio .NET 2002  
 First release  
  
 C# 1.1, Visual Studio .NET 2003  
 `#line` pragma and xml doc comments  
  
 C# 2, Visual Studio .NET 2005  
 Anonymous methods, generics, nullable types, iterators/yield, `static` classes, co/contra variance for delegates  
  
 C# 3, Visual Studio .NET 2008  
 Object and collection initializers, lambda expressions, extension methods, anonymous types, automatic properties, Language Integrated Query (LINQ), anonymous types, local `var` type inference, LINQ  
  
 C# 4, Visual Studio .NET 2010  
 `Dynamic`, named arguments, optional parameters, generic co/contra variance  
  
 C# 5, Visual Studio .NET 2012  
 `Async` / `await`, caller information attributes  
  
 Visual Studio .NET 2013  
 Bug fixes, performance improvements, and technology previews of .NET Compiler Platform (“Roslyn”)  
  
 C# 6, Visual Studio .NET 2015  
 Current version, see below  
  
## Current Version  
 [nameof](../keywords/nameof--csharp-and-visual-basic-reference-.md)  
 You can get the unqualified string name of a type or member for use in an error message without hard coding a string.  This allows your code to remain correct when refactoring.  This feature is also useful for hooking up model-view-controller MVC links and firing property changed events.  
  
 [String Interpolation](../keywords/interpolated-strings--csharp-and-visual-basic-reference-.md)  
 You can use string interpolation expressions to construct strings.  An interpolated string expression looks like a template string that contains expressions.  C# creates a string by replacing the expressions with the ToString represenations of the expressions’ results.  An interpolated string is easier to understand with respect to arguments than [Composite Formatting](../Topic/Composite%20Formatting.md).  
  
 [Null-conditional Member Access and Indexing](../operators/null-conditional-operators--csharp-and-visual-basic-.md)  
 You can test for null in a very light syntactic way before performing a member access (`?.`) or index (`?[]`) operation.  These operators help you write less code to handle null checks, especially for descending into data structures.  If the left operand or object reference is null, the operations returns null.  
  
 [Index Initializers](../classes-and-structs/object-and-collection-initializers--csharp-programming-guide-.md)  
 You can now initialize specific elements of a collection that supports indexing, such as initializing a dictionary.  
  
 [Collection Initializer and Add Extension Methods](../classes-and-structs/object-and-collection-initializers--csharp-programming-guide-.md)  
 You can use initializers for collections now when the collection has an Add Extension method.  Previously the Add method had to be an instance method.  
  
 **Overload Resolution**  
 The compiler has improved overload resolution that results in more code just working the way you would expect it to behave.  One place where you might stop noticing a problem is when choosing between overloads taking nullable value types, or when passing method groups (instead of lambdas) to overloads that take delegates.  
  
 [Exception Filters](../keywords/try-catch--csharp-reference-.md)  
 You can use exception filers in `catch` clauses to determine whether a catch clause should handle the exception.  Without this feature, you have to rethrow the exception, which clips the call stack reported in the rethrown exception.  
  
 [Await in Catch and Finally Blocks](../keywords/try-catch--csharp-reference-.md)  
 You can use `await` in `catch` and `finally` clauses.  
  
 [Auto-property Initializers](../classes-and-structs/auto-implemented-properties--csharp-programming-guide-.md)  
 You can initialize auto-properties now similarly to how you initialize fields.  
  
 [Getter-only Auto-properites](../classes-and-structs/auto-implemented-properties--csharp-programming-guide-.md)  
 You can define read-only auto-properties now without having to define a property with complete property syntax.  You can initialize the property where you declare it or in the type’s constructor.  
  
 **Function Members with Expression Bodies**  
 You can declare members with expression-bodies of code in the same lightweight syntax you use with lambda expressions.  See [Methods](../classes-and-structs/methods--csharp-programming-guide-.md), [Properties](../classes-and-structs/properties--csharp-programming-guide-.md), [Indexers](../indexers/indexers--csharp-programming-guide-.md), and [Overloadable Operators](../statements-expressions-operators/overloadable-operators--csharp-programming-guide-.md).  
  
 [Using Static](../keywords/using-directive--csharp-reference-.md)  
 You can import accessible static members of static types so that you can refer to the members without qualifying the access with the type’s name.  
  
## See Also  
 [What's New in Visual Studio 2015](../Topic/What's%20New%20in%20Visual%20Studio%202015.md)