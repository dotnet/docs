---
title: Concepts and terminology (functional transformation) - LINQ to XML
description: Learn the concepts and terminology of pure functional transformations.
ms.date: 07/20/2015
ms.assetid: 03defb3a-7e17-4ab1-8efa-4dd66621e860
---

# Concepts and terminology (functional transformation) (LINQ to XML)

This article introduces the concepts and terminology of pure functional transformations. The functional transformation approach to transforming data yields code that's often quicker to program, more expressive, and easier to debug and maintain than more traditional, imperative programming.

Note that the articles in this section aren't intended to fully explain functional programming. Instead, these articles identify some of the functional programming capabilities that make it easier to transform XML from one shape to another.

## What is pure functional transformation

In *pure functional transformation*, a set of functions, called *pure functions*, define how to transform a set of structured data from its original form into another form. The word "pure" indicates that the functions are *composable*, which requires that they're:

- *Self-contained*, so that they can be freely ordered and rearranged without entanglement or interdependencies with the rest of the program. Pure transformations have no knowledge of or effect upon their environment. That is, the functions used in the transformation have no *side effects*.
- *Stateless*, so that executing the same function or specific set of functions on the same input will always result in the same output. Pure transformations have no memory of their prior use.

> [!IMPORTANT]
> In the rest of this tutorial, the term "pure function" is used in a general sense to indicate a programming approach, and not a specific language feature.
>
> Note that pure functions must be implemented as methods in C#, and as functions in Visual Basic.
>
> You shouldn't confuse pure functions with pure virtual methods in C++. The latter indicates that the containing class is abstract and that no method body is supplied.

### Functional programming

*Functional programming* is a programming approach that directly supports pure functional transformation.

Historically, general-purpose functional programming languages, such as ML, Scheme, Haskell, and F#, have been primarily of interest to the academic community. Although it has always been possible to write pure functional transformations in C# and Visual Basic, the difficulty of doing so has not made it an attractive option to most programmers. In recent versions of these languages, however, new language constructs such as lambda expressions and type inference make functional programming much easier and more productive.

For more information about functional programming, see [Functional programming vs. imperative programming](functional-vs-imperative-programming.md).

#### Domain-specific functional programming languages

Although general functional programming languages haven't been widely adopted, some domain-specific functional programming languages have had better success. For example, Cascading Style Sheets (CSS) are used to determine the look and feel of many web pages, and Extensible Stylesheet Language Transformations (XSLT) style sheets are used extensively in XML data manipulation. For more information about XSLT, see [XSLT Transformations](../data/xml/xslt-transformations.md).

## Terminology

The following list defines some terms related to functional transformations.

higher-order (first-class) function \
A function that can be treated as a programmatic object. For example, a higher-order function can be passed to or returned from other functions. In C# and Visual Basic, delegates and lambda expressions are language features that support higher-order functions. To write a higher-order function, you declare one or more arguments to take delegates, and you often use lambda expressions when calling it. Many of the standard query operators are higher-order functions.

For more information, see [Standard Query Operators Overview (C#)](../../csharp/programming-guide/concepts/linq/standard-query-operators-overview.md) and [Standard Query Operators Overview (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md).

lambda expression \
Essentially, an inline anonymous function that can be used wherever a delegate type is expected. This is a simplified definition of lambda expressions, but it's adequate for the purposes of this tutorial.

For more information, see [Lambda expressions (C# Programming Guide)](../../csharp/language-reference/operators/lambda-expressions.md) and [Lambda Expressions (Visual Basic))](../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md).

collection \
A structured set of data, usually of a uniform type. To be compatible with LINQ, a collection must implement the <xref:System.Collections.IEnumerable> interface or the <xref:System.Linq.IQueryable> interface (or one of their generic counterparts, <xref:System.Collections.Generic.IEnumerator%601> or <xref:System.Linq.IQueryable%601>).

tuple (anonymous types) \
A mathematical concept, a tuple is a finite sequence of objects, each of a specific type. A tuple is also known as an ordered list. Anonymous types are a language implementation of this concept, which enable an unnamed class type to be declared and an object of that type to be instantiated at the same time.

For more information, see [Anonymous Types (C# Programming Guide)](../../csharp/fundamentals/types/anonymous-types.md) and [Anonymous Types (Visual Basic)](../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md).

type inference (implicit typing) \
The ability of a compiler to determine the type of a variable in the absence of an explicit type declaration.

For more information, see [Implicitly typed local variables (C# Programming Guide)](../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md) and [Local Type Inference (Visual Basic)](../../visual-basic/programming-guide/language-features/variables/local-type-inference.md).

deferred execution and lazy evaluation \
The delaying of evaluation of an expression until its resolved value is actually required. Deferred execution is supported in collections.

For more C# information, see [Introduction to LINQ Queries (C#)](../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md) and [Deferred Execution and Lazy Evaluation in LINQ to XML (C#)](./deferred-execution-lazy-evaluation.md).

For more Visual Basic information, see [Basic Query Operations (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/basic-query-operations.md) and [Deferred Execution and Lazy Evaluation in LINQ to XML (Visual Basic)](./deferred-execution-lazy-evaluation.md).

These language features will be used in code samples throughout this section.

## See also

- [Introduction to pure functional transformations](introduction-pure-functional-transformations.md)
- [Functional programming vs. imperative programming](functional-vs-imperative-programming.md)
