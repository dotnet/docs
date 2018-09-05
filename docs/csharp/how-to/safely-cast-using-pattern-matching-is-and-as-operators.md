---
title: "How to: safely cast by using pattern matching is and as operators"
description: Learn to use pattern matching techniques to safely cast variables to a different type. You can use pattern matching as well as the is and as operators to safely convert types.
ms.date: 09/05/2018
helpviewer_keywords: 
  - "cast operators [C#], as and is operators"
  - "as operator [C#]"
  - "is operator [C#]"
---
# How to: safely cast by using pattern matching is and as operators

Because objects are polymorphic, it's possible for a variable of a base class type to hold a derived [type](../programming-guide/types/index.md). To access the derived type's instance methods, it's necessary to [cast](../programming-guide/types/casting-and-type-conversions.md) the value back to the derived type. However, to attempt a cast creates the risk of throwing an <xref:System.InvalidCastException>. C# provides [pattern matching](../pattern-matching.md) statements that perform a cast conditionally only when it will succeed. C# also provides the [is](../../language-reference/keywords/is.md) and [as](../../language-reference/keywords/as.md) operators to test if a value is of a certain type.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

The following code demonstrates the pattern matching `is` statement. It contains methods that test a method argument to determine if it is one of a possible set of derived types:

[!code-csharp-interactive[Pattern matching is statement](../../../samples/snippets/csharp/how-to/safelycast/patternmatching/Program.cs#PatternMatchingIs)]

The preceding sample demonstrate a few features of pattern matching syntax. It combines the test  with an initialization assignment. The assignment is only performed if the test succeeds. The variable `m` is only in scope in the embedded if statement, where it has been assigned. You cannot access `m` later in the same method. Try it in the interactive window.

You can also use the same syntax for testing if a [nullable type](../programming-guide/nullable-types/index.md) has a value, as shown in the following sample code:

[!code-csharp-interactive[Pattern matching with nullable types](../../../samples/snippets/csharp/how-to/safelycast/patternmatching/Program.cs#PatternMatchingNullable)]

The preceding sample demonstrates other features of pattern matching to use with conversions. You can test a variable for the null pattern. Also, regardless of the compile-time type of a variable, the `is` test returns `false` if the value of the variable is the null value. Also, you cannot use the pattern matching `is` statement with a nullable value type, such as `int?` or `Nullable<int>`, but you can test for any other value type.

The preceding sample also shows how you use the pattern matching `is` expression in a `switch` statement where the variable may be one of many different types.

If you want to test if a variable is a given type, but you do not want to assign it to a new variable, you can use the `is` and `as` operators for reference types and nullable types, as shown in the following code:

[!code-csharp-interactive[testing varaible types with the is and as statements](../../../samples/snippets/csharp/how-to/safelycast/patternmatching/Program.cs#IsAndAs)]

The preceding code shows how to use the `is` and `as` statements that were part of the C# language before pattern matching was introduced.

The pattern matching syntax provides more robust features by combining the test and the assignment in a single statement. You should use that syntax whenever possible.
