---
title: "Concepts and Terminology (Functional Transformation) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 03defb3a-7e17-4ab1-8efa-4dd66621e860
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# Concepts and Terminology (Functional Transformation) (C#)
This topic introduces the concepts and terminology of pure functional transformations. The functional transformation approach to transforming data yields code that is often quicker to program, more expressive, and easier to debug and maintain than more traditional, imperative programming.  
  
 Note that the topics in this section are not intended to fully explain functional programming. Instead, these topics identify some of the functional programming capabilities that make it easier to transform XML from one shape to another.  
  
## What Is Pure Functional Transformation?  
 In *pure functional transformation*, a set of functions, called *pure functions*, define how to transform a set of structured data from its original form into another form. The word "pure" indicates that the functions are *composable*, which requires that they are:  
  
-   *Self-contained*, so that they can be freely ordered and rearranged without entanglement or interdependencies with the rest of the program. Pure transformations have no knowledge of or effect upon their environment. That is, the functions used in the transformation have no *side effects*.  
  
-   *Stateless*, so that executing the same function or specific set of functions on the same input will always result in the same output. Pure transformations have no memory of their prior use.  
  
> [!IMPORTANT]
>  In the rest of this tutorial, the term "pure function" is used in a general sense to indicate a programming approach, and not a specific language feature.  
>   
>  Note that pure functions must be implemented as methods in C#.  
>   
>  Also, you should not confuse pure functions with pure virtual methods in C++. The latter indicates that the containing class is abstract and that no method body is supplied.  
  
### Functional Programming  
 *Functional programming* is a programming approach that directly supports pure functional transformation.  
  
 Historically, general-purpose functional programming languages, such as ML, Scheme, Haskell, and F#, have been primarily of interest to the academic community. Although it has always been possible to write pure functional transformations in C#, the difficulty of doing so has not made it an attractive option to most programmers. In recent versions of C#, however, new language constructs such as lambda expressions and type inference make it functional programming much easier and more productive.  
  
 For more information about functional programming, see [Functional Programming vs. Imperative Programming (C#)](../../../../csharp/programming-guide/concepts/linq/functional-programming-vs-imperative-programming.md).  
  
#### Domain-Specific FP Languages  
 Although general functional programming languages have not been widely adopted, specific domain-specific functional programming languages have had better success. For example, Cascading Style Sheets (CSS) are used to determine the look and feel of many Web pages, and Extensible Stylesheet Language Transformations (XSLT) style sheets are used extensively in XML data manipulation. For more information about XSLT, see [XSLT Transformations](../../../../standard/data/xml/xslt-transformations.md).  
  
## Terminology  
 The following table defines some terms related to functional transformations.  
  
 higher-order (first-class) function  
 A function that can be treated as a programmatic object. For example, a higher-order function can be passed to or returned from other functions. In C#c, delegates and lambda expressions are language features that support higher-order functions. To write a higher-order function, you declare one or more arguments to take delegates, and you often use lambda expressions when calling it. Many of the standard query operators are higher-order functions.  
  
 For more information, see [Standard Query Operators Overview (C#)](../../../../csharp/programming-guide/concepts/linq/standard-query-operators-overview.md).  
  
 lambda expression  
 Essentially, an inline anonymous function that can be used wherever a delegate type is expected. This is a simplified definition of lambda expressions, but it is adequate for the purposes of this tutorial.  
  
 For more information about, see [Lambda Expressions](../../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md).  
  
 collection  
 A structured set of data, usually of a uniform type. To be compatible with LINQ, a collection must implement the <xref:System.Collections.IEnumerable> interface or the <xref:System.Linq.IQueryable> interface (or one of their generic counterparts, <xref:System.Collections.Generic.IEnumerator%601> or <xref:System.Linq.IQueryable%601>).  
  
 tuple (anonymous types)  
 A mathematical concept, a tuple is a finite sequence of objects, each of a specific type. A tuple is also known as an ordered list. Anonymous types are a language implementation of this concept, which enable an unnamed class type to be declared and an object of that type to be instantiated at the same time.  
  
 For more information, see [Anonymous Types](../../../../csharp/programming-guide/classes-and-structs/anonymous-types.md).  
  
 type inference (implicit typing)  
 The ability of a compiler to determine the type of a variable in the absence of an explicit type declaration.  
  
 For more information, see [Implicitly Typed Local Variables](../../../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md).  
  
 deferred execution and lazy evaluation  
 The delaying of evaluation of an expression until its resolved value is actually required. Deferred execution is supported in collections.  
  
 For more information, see [Introduction to LINQ Queries (C#)](../../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md) and [Deferred Execution and Lazy Evaluation in LINQ to XML (C#)](../../../../csharp/programming-guide/concepts/linq/deferred-execution-and-lazy-evaluation-in-linq-to-xml.md).  
  
 These language features will be used in code samples throughout this section.  
  
## See Also  
 [Introduction to Pure Functional Transformations (C#)](../../../../csharp/programming-guide/concepts/linq/introduction-to-pure-functional-transformations.md)  
 [Functional Programming vs. Imperative Programming (C#)](../../../../csharp/programming-guide/concepts/linq/functional-programming-vs-imperative-programming.md)
