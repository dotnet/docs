---
title: "dynamic - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "dynamic_CSharpKeyword"
helpviewer_keywords: 
  - "dynamic [C#]"
  - "dynamic keyword [C#]"
ms.assetid: 9e797102-cc83-4964-bf58-afe4f54d16bc
---
# dynamic (C# Reference)

The `dynamic` type enables the operations in which it occurs to bypass compile-time type checking. Instead, these operations are resolved at run time. The `dynamic` type simplifies access to COM APIs such as the Office Automation APIs, and also to dynamic APIs such as IronPython libraries, and to the HTML Document Object Model (DOM).

Type `dynamic` behaves like type `object` in most circumstances. However, operations that contain expressions of type `dynamic` are not resolved or type checked by the compiler. The compiler packages together information about the operation, and that information is later used to evaluate the operation at run time. As part of the process, variables of type `dynamic` are compiled into variables of type `object`. Therefore, type `dynamic` exists only at compile time, not at run time.

The following example contrasts a variable of type `dynamic` to a variable of type `object`. To verify the type of each variable at compile time, place the mouse pointer over `dyn` or `obj` in the `WriteLine` statements. IntelliSense shows **dynamic** for `dyn` and **object** for `obj`.

[!code-csharp[csrefKeywordsTypes#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/dynamic1.cs#21)]

The `WriteLine` statements display the run-time types of `dyn` and `obj`. At that point, both have the same type, integer. The following output is produced:

`System.Int32`

`System.Int32`

To see the difference between `dyn` and `obj` at compile time, add the following two lines between the declarations and the `WriteLine` statements in the previous example.

```csharp
dyn = dyn + 3;
obj = obj + 3;
```

 A compiler error is reported for the attempted addition of an integer and an object in expression `obj + 3`. However, no error is reported for `dyn + 3`. The expression that contains `dyn` is not checked at compile time because the type of `dyn` is `dynamic`.

## Context

The `dynamic` keyword can appear directly or as a component of a constructed type in the following situations:

- In declarations, as the type of a property, field, indexer, parameter, return value, local variable, or type constraint. The following class definition uses `dynamic` in several different declarations.

    [!code-csharp[csrefKeywordsTypes#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/dynamic1.cs#22)]

- In explicit type conversions, as the target type of a conversion.

    [!code-csharp[csrefKeywordsTypes#23](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/dynamic1.cs#23)]

- In any context where types serve as values, such as on the right side of an `is` operator or an `as` operator, or as the argument to `typeof` as part of a constructed type. For example, `dynamic` can be used in the following expressions.

    [!code-csharp[csrefKeywordsTypes#24](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/dynamic1.cs#24)]

## Example

The following example uses `dynamic` in several declarations. The `Main` method also contrasts compile-time type checking with run-time type checking.

[!code-csharp[csrefKeywordsTypes#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/dynamic2.cs#25)]

For more information and examples, see [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md).

## See also

- <xref:System.Dynamic.ExpandoObject?displayProperty=nameWithType>
- <xref:System.Dynamic.DynamicObject?displayProperty=nameWithType>
- [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md)
- [object](../../../csharp/language-reference/keywords/object.md)
- [is](../../../csharp/language-reference/keywords/is.md)
- [as](../../../csharp/language-reference/keywords/as.md)
- [typeof](../../../csharp/language-reference/keywords/typeof.md)
- [How to: Safely cast Using pattern matching, as, and is Operators](../../how-to/safely-cast-using-pattern-matching-is-and-as-operators.md)
- [Walkthrough: Creating and Using Dynamic Objects](../../../csharp/programming-guide/types/walkthrough-creating-and-using-dynamic-objects.md)
