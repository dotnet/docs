---
title: "How to safely cast by using pattern matching and the is and as operators"
description: Learn to use pattern matching techniques to safely cast variables to a different type. You can use pattern matching as well as the is and as operators to safely convert types.
ms.date: 05/14/2021
helpviewer_keywords: 
  - "cast operators [C#], as and is operators"
  - "as operator [C#]"
  - "is operator [C#]"
---
# How to safely cast by using pattern matching and the is and as operators

Because objects are polymorphic, it's possible for a variable of a base class type to hold a derived [type](../types/index.md). To access the derived type's instance members, it's necessary to [cast](../../programming-guide/types/casting-and-type-conversions.md) the value back to the derived type. However, a cast creates the risk of throwing an <xref:System.InvalidCastException>. C# provides [pattern matching](../functional/pattern-matching.md) statements that perform a cast conditionally only when it will succeed. C# also provides the [is](../../language-reference/operators/type-testing-and-cast.md#is-operator) and [as](../../language-reference/operators/type-testing-and-cast.md#as-operator) operators to test if a value is of a certain type.

The following example shows how to use the pattern matching `is` statement:

:::code language="csharp" source="./snippets/safelycast/patternmatching/Program.cs" ID="PatternMatchingIs":::

The preceding sample demonstrates a few features of pattern matching syntax. The `if (a is Mammal m)` statement combines the test with an initialization assignment. The assignment occurs only when the test succeeds. The variable `m` is only in scope in the embedded `if` statement where it has been assigned. You can't access `m` later in the same method. The preceding example also shows how to use the [`as` operator](../../language-reference/operators/type-testing-and-cast.md#as-operator) to convert an object to a specified type.

You can also use the same syntax for testing if a [nullable value type](../../language-reference/builtin-types/nullable-value-types.md) has a value, as shown in the following example:

:::code language="csharp" source="./snippets/safelycast/nullablepatternmatching/Program.cs" ID="PatternMatchingNullable":::

The preceding sample demonstrates other features of pattern matching to use with conversions. You can test a variable for the null pattern by checking specifically for the `null` value. When the runtime value of the variable is `null`, an `is` statement checking for a type always returns `false`. The pattern matching `is` statement doesn't allow a nullable value type, such as `int?` or `Nullable<int>`, but you can test for any other value type. The `is` patterns from the preceding example aren't limited to the nullable value types. You can also use those patterns to test if a variable of a reference type has a value or it's `null`.

The preceding sample also shows how you use the type pattern in a `switch` statement where the variable may be one of many different types.

If you want to test if a variable is a given type, but not assign it to a new variable, you can use the `is` and `as` operators for reference types and nullable value types. The following code shows how to use the `is` and `as` statements that were part of the C# language before pattern matching was introduced to test if a variable is of a given type:

:::code language="csharp" source="./snippets/safelycast/asandis/Program.cs" ID="IsAndAs":::

As you can see by comparing this code with the pattern matching code, the pattern matching syntax provides more robust features by combining the test and the assignment in a single statement. Use the pattern matching syntax whenever possible.
