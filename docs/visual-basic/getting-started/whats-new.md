---
title: "What's new for Visual Basic | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "VB.StartPage.WhatsNew"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "new features, Visual Basic"
  - "what's new [Visual Basic]"
  - "Visual Basic, what's new"
ms.assetid: d7e97396-7f42-4873-a81c-4ebcc4b6ca02
caps.latest.revision: 145
author: "stevehoag"
ms.author: "shoag"

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
# What's new for Visual Basic
This page lists key feature names for each version of Visual Basic with descriptions of the new and enhanced features in the lastest version of the language.  
  
## Previous versions  
 Visual Basic / Visual Studio .NET 2002  
 First release  
  
 Visual Basic / Visual Studio .NET 2003  
 Bit shift operators, loop variable declaration  
  
 Visual Basic / Visual Studio .NET 2005  
 `My` type and helper types (access to app, computer, files system, network  
  
 Visual Basic / Visual Studio .NET 2008  
 Language Integrated Query (LINQ), XML literals, local type inference, object initializers, anonymous types, extension methods, local `var` type inference, lambda expressions, `if` operator, partial methods, nullable value types  
  
 Visual Basic, Visual Studio .NET 2010  
 Auto-implemented properties, collection initializers, implicit line continuation, dynamic, generic co/contra variance, global namespace access  
  
 Visual Basic / Visual Studio .NET 2012  
 `Async` / `await`, iterators, caller info attributes  
  
 Visual Basic / Visual Studio .NET 2013  
 technology previews of .NET Compiler Platform (“Roslyn”)  
  
 Visual Basic / Visual Studio .NET 2015  
 Current version, see below  
  
## Current version  
 [Nameof](../../csharp/language-reference/keywords/nameof.md)  
 You can get the unqualified string name of a type or member for use in an error message without hard coding a string.  This allows your code to remain correct when refactoring.  This feature is also useful for hooking up model-view-controller MVC links and firing property changed events.  
  
 [String Interpolation](../../csharp/language-reference/keywords/interpolated-strings.md)  
 You can use string interpolation expressions to construct strings.  An interpolated string expression looks like a template string that contains expressions.  An interpolated string is easier to understand with respect to arguments than [Composite Formatting](../../standard/base-types/composite-format.md).  
  
 [Null-conditional Member Access and Indexing](../../csharp/language-reference/operators/null-conditional-operators.md)  
 You can test for null in a very light syntactic way before performing a member access (`?.`) or index (`?[]`) operation.  These operators help you write less code to handle null checks, especially for descending into data structures.  If the left operand or object reference is null, the operations returns null.  
  
 [Multi-line String Literals](../../visual-basic/programming-guide/language-features/strings/string-basics.md)  
 String literals can contain newline sequences.  You no longer need the old work around of using `<xml><![CDATA[...text with newlines...]]></xml>.Value`  
  
 Comments  
 You can put comments after implicit line continuations, inside initializer expressions, and amongst LINQ expression terms.  
  
 Smarter Fully-qualified Name Resolution  
 Given code such as `Threading.Thread.Sleep(1000)`, Visual Basic used to look up the namespace "Threading", discover it was ambiguous between System.Threading and System.Windows.Threading, and then report an error.  Visual Basic now considers both possible namespaces together.  If you show the completion list, the Visual Studio editor lists members from both types in the completion list.  
  
 Year-first Date Literals  
 You can have date literals in yyyy-mm-dd format, `#2015-03-17 16:10 PM#`.  
  
 Readonly Interface Properties  
 You can implement readonly interface properties using a readwrite property.  The interface guarantees minimum functionality, and it does not stop an implementing class from allowing the property to be set.  
  
 [TypeOf \<expr> IsNot \<type>](../../visual-basic/language-reference/operators/typeof-operator.md)  
 For more readability of your code, you can now use `TypeOf` with `IsNot`.  
  
 [#Disable Warning \<ID> and #Enable Warning \<ID>](../../visual-basic/language-reference/directives/directives.md)  
 You can disable and enable specific warnings for regions within a source file.  
  
 XML Doc-comment Improvements  
 When writing doc comments, you get smart editor and build support for validating parameter names, proper handling of `crefs` (generics, operators, etc.), colorizing, and refactoring.  
  
 [Partial Module and Interface Definitions](../../visual-basic/language-reference/modifiers/partial.md)  
 In addition to classes and structs, you can declare partial modules and interfaces.  
  
 [#Region Directives inside Method Bodies](../../visual-basic/language-reference/directives/region-directive.md)  
 You can put #Region…#End Region delimiters anywhere in a file, inside functions, and even spanning across function bodies.  
  
 [Overrides Definitions are Implicitly Overloads](../../visual-basic/language-reference/modifiers/overrides.md)  
 If you add the `Overrides` modifier to a definition, the compiler implicitly adds `Overloads` so that you can type less code in common cases.  
  
 CObj Allowed in Attributes Arguments  
 The compiler used to give an error that CObj(…) was not a constant when used in attribute constructions.  
  
 Declaring and Consuming Ambiguous Methods from Different Interfaces  
 Previously the following code yielded errors that prevented you from declaring `IMock` or from calling `GetDetails` (if these had been declared in C#):  
  
```vb  
Interface ICustomer  
  Sub GetDetails(x As Integer)  
End Interface  
  
Interface ITime  
  Sub GetDetails(x As String)  
End Interface  
  
Interface IMock : Inherits ICustomer, ITime  
  Overloads Sub GetDetails(x As Char)  
End Interface  
  
Interface IMock2 : Inherits ICustomer, ITime  
End Interface  
  
```  
  
 Now the compiler will use normal overload resolution rules to choose the most appropriate `GetDetails` to call, and you can declare interface relationships in Visual Basic like those shown in the sample.  
  
## See also  
 [What's New in Visual Studio 2017](https://docs.microsoft.com/en-us/visualstudio/ide/whats-new-in-visual-studio)