---
description: "Learn more about: Visual Basic Features That Support LINQ"
title: "Features That Support LINQ"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Visual Basic, LINQ features"
  - "LINQ [Visual Basic], features supporting LINQ"
ms.assetid: c821bb50-b6f6-4cf9-8aba-2717e465bd3a
---
# Visual Basic Features That Support LINQ

The name Language-Integrated Query (LINQ) refers to technology in Visual Basic that supports query syntax and other language constructs directly in the language. With LINQ, you do not have to learn a new language to query against an external data source. You can query against data in relational databases, XML stores, or objects by using Visual Basic. This integration of query capabilities into the language enables compile-time checking for syntax errors and type safety. This integration also ensures that you already know most of what you have to know to write rich, varied queries in Visual Basic.  
  
 The following sections describe the language constructs that support LINQ in enough detail to enable you to get started in reading the introductory documentation, code examples, and sample applications. You can also click the links to find more detailed explanations of how the language features come together to enable language-integrated query. A good place to start is [Walkthrough: Writing Queries in Visual Basic](walkthrough-writing-queries.md).  
  
## Query Expressions  

 Query expressions in Visual Basic can be expressed in a declarative syntax similar to that of SQL or XQuery. At compile time, query syntax is converted into method calls to a LINQ provider's implementation of the standard query operator extension methods. Applications control which standard query operators are in scope by specifying the appropriate namespace with an `Imports` statement. Syntax for a Visual Basic query expression looks like this:  
  
 [!code-vb[VbLINQVbFeatures#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#1)]  
  
 For more information, see [Introduction to LINQ in Visual Basic](../../language-features/linq/introduction-to-linq.md).  
  
## Implicitly Typed Variables  

 Instead of explicitly specifying a type when you declare and initialize a variable, you can enable the compiler to infer and assign the type. This is referred to as *local type inference*.  
  
 Variables whose types are inferred are strongly typed, just like variables whose type you specify explicitly. Local type inference works only when you are defining a local variable inside a method body. For more information, see [Option Infer Statement](../../../language-reference/statements/option-infer-statement.md) and [Local Type Inference](../../language-features/variables/local-type-inference.md).  
  
 The following example illustrates local type inference. To use this example, you must set `Option Infer` to `On`.  
  
 [!code-vb[VbLINQVbFeatures#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#2)]  
  
 Local type inference also makes it possible to create anonymous types, which are described later in this section and are necessary for LINQ queries.  
  
 In the following LINQ example, type inference occurs if `Option Infer` is either `On` or `Off`. A compile-time error occurs if `Option Infer` is `Off` and `Option Strict` is `On`.  
  
 [!code-vb[VbLINQVbFeatures#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#3)]  
  
## Object Initializers  

 Object initializers are used in query expressions when you have to create an anonymous type to hold the results of a query. They also can be used to initialize objects of named types outside of queries. By using an object initializer, you can initialize an object in a single line without explicitly calling a constructor. Assuming that you have a class named `Customer` that has public `Name` and `Phone` properties, along with other properties, an object initializer can be used in this manner:  
  
 [!code-vb[VbLINQVbFeatures#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#4)]  
  
 For more information, see [Object Initializers: Named and Anonymous Types](../../language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md).  
  
## Anonymous Types  

 Anonymous types provide a convenient way to temporarily group a set of properties into an element that you want to include in a query result. This enables you to choose any combination of available fields in the query, in any order, without defining a named data type for the element.  
  
 An *anonymous type* is constructed dynamically by the compiler. The name of the type is assigned by the compiler, and it might change with each new compilation. Therefore, the name cannot be used directly. Anonymous types are initialized in the following way:  
  
 [!code-vb[VbLINQVbFeatures#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#5)]  
  
 For more information, see [Anonymous Types](../../language-features/objects-and-classes/anonymous-types.md).  
  
## Extension Methods  

 Extension methods enable you to add methods to a data type or interface from outside the definition. This feature enables you to, in effect, add new methods to an existing type without actually modifying the type. The standard query operators are themselves a set of extension methods that provide LINQ query functionality for any type that implements <xref:System.Collections.Generic.IEnumerable%601>. Other extensions to <xref:System.Collections.Generic.IEnumerable%601> include <xref:System.Linq.Enumerable.Count%2A>, <xref:System.Linq.Enumerable.Union%2A>, and <xref:System.Linq.Enumerable.Intersect%2A>.  
  
 The following extension method adds a print method to the <xref:System.String> class.  
  
 [!code-vb[VbLINQVbFeatures#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#6)]  
  
 The method is called like an ordinary instance method of <xref:System.String>:  
  
 [!code-vb[VbLINQVbFeatures#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#7)]  
  
 For more information, see [Extension Methods](../../language-features/procedures/extension-methods.md).  
  
## Lambda Expressions  

 A lambda expression is a function without a name that calculates and returns a single value. Unlike named functions, a lambda expression can be defined and executed at the same time. The following example displays 4.  
  
 [!code-vb[VbLINQVbFeatures#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#8)]  
  
 You can assign the lambda expression definition to a variable name and then use the name to call the function. The following example also displays 4.  
  
 [!code-vb[VbLINQVbFeatures#12](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#12)]  
  
 In LINQ, lambda expressions underlie many of the standard query operators. The compiler creates lambda expressions to capture the calculations that are defined in fundamental query methods such as `Where`, `Select`, `Order By`, `Take While`, and others.  
  
 For example, the following code defines a query that returns all senior students from a list of students.  
  
 [!code-vb[VbLINQVbFeatures#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#9)]  
  
 The query definition is compiled into code that is similar to the following example, which uses two lambda expressions to specify the arguments for `Where` and `Select`.  
  
 [!code-vb[VbLINQVbFeatures#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#10)]  
  
 Either version can be run by using a `For Each` loop:  
  
 [!code-vb[VbLINQVbFeatures#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQVbFeatures/VB/Class1.vb#11)]  
  
 For more information, see [Lambda Expressions](../../language-features/procedures/lambda-expressions.md).  
  
## See also

- [Language-Integrated Query (LINQ) (Visual Basic)](index.md)
- [Getting Started with LINQ in Visual Basic](getting-started-with-linq.md)
- [LINQ and Strings (Visual Basic)](linq-and-strings.md)
- [Option Infer Statement](../../../language-reference/statements/option-infer-statement.md)
- [Option Strict Statement](../../../language-reference/statements/option-strict-statement.md)
