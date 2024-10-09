---
title: "Collection expressions (Collection literals)"
description: Collection expressions convert to many collection types. You can write literal values, expressions, or other collections to create a new collection.
ms.date: 03/07/2024
helpviewer_keywords:
  - "Collection expressions"
---
# Collection expressions - C# language reference

You can use a *collection expression* to create common collection values. A *collection expression* is a terse syntax that, when evaluated, can be assigned to many different collection types. A collection expression contains a sequence of elements between `[` and `]` brackets. The following example declares a <xref:System.Span%601?displayProperty=nameWithType> of `string` elements and initializes them to the days of the week:

:::code language="csharp" source="./snippets/shared/CollectionExpressionExamples.cs" id="FirstCollectionExpression":::

A *collection expression* can be converted to many different collection types. The first example demonstrated how to initialize a variable using a collection expression. The following code shows many of the other locations where you can use a collection expression:

:::code language="csharp" source="./snippets/shared/CollectionExpressionExamples.cs" id="CompileTimeExpressions":::

You can't use a collection expression where a compile-time constant is expected, such as initializing a constant, or as the default value for a method argument.

Both of the previous examples used constants as the elements of a collection expression. You can also use variables for the elements as shown in the following example:

:::code language="csharp" source="./snippets/shared/CollectionExpressionExamples.cs" id="UseVariables":::

## Spread element

You use a *spread element* `..` to inline collection values in a collection expression. The following example creates a collection for the full alphabet by combining a collection of the vowels, a collection of the consonants, and the letter "y", which can be either:

:::code language="csharp" source="./snippets/shared/CollectionExpressionExamples.cs" id="SpreadOperator":::

The spread element `..vowels`, when evaluated, produces five elements: `"a"`, `"e"`, `"i"`, `"o"`, and `"u"`. The spread element `..consonants` produces 20 elements, the number in the `consonants` array. The variable in a spread element must be enumerable using a [`foreach`](../statements/iteration-statements.md#the-foreach-statement) statement. As shown in the previous example, you can combine spread elements with individual elements in a collection expression.

## Conversions

A *collection expression* can be converted to different collection types, including:

- <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.
- [Arrays](../builtin-types/arrays.md).
- Any type with a *create* method whose parameter type is `ReadOnlySpan<T>` where there's an implicit conversion from the collection expression type to `T`.
- Any type that supports a [collection initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md#collection-initializers), such as <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>. Usually, this requirement means the type supports <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> and there's an accessible `Add` method to add items to the collection. There must be an implicit conversion from the collection expression elements' type to the collection's element type. For spread elements, there must be an implicit conversion from the spread element's type to the collection's element type.
- Any of the following interfaces:
  - <xref:System.Collections.Generic.IEnumerable%601?displayProperty=fullName>.
  - <xref:System.Collections.Generic.IReadOnlyCollection%601?displayProperty=fullName>.
  - <xref:System.Collections.Generic.IReadOnlyList%601?displayProperty=fullName>.
  - <xref:System.Collections.Generic.ICollection%601?displayProperty=fullName>.
  - <xref:System.Collections.Generic.IList%601?displayProperty=fullName>.

> [!IMPORTANT]
> A collection expression always creates a collection that includes all elements in the collection expression, regardless of the target type of the conversion. For example, when the target of the conversion is <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType>, the generated code evaluates the collection expression and stores the results in an in-memory collection.
>
> This behavior is distinct from LINQ, where a sequence might not be instantiated until it is enumerated. You can't use collection expressions to generate an infinite sequence that won't be enumerated.

The compiler uses static analysis to determine the most performant way to create the collection declared with a collection expression. For example, the empty collection expression, `[]`, can be realized as <xref:System.Array.Empty%60%601?displayProperty=nameWithType> if the target won't be modified after initialization. When the target is a <xref:System.Span%601?displayProperty=nameWithType> or <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>, the storage might be stack allocated. The [collection expressions feature specification](~/_csharplang/proposals/csharp-12.0/collection-expressions.md) specifies the rules the compiler must follow.

Many APIs are overloaded with multiple collection types as parameters. Because a collection expression can be converted to many different expression types, these APIs might require casts on the collection expression to specify the correct conversion. The following conversion rules resolve some of the ambiguities:

- A better element conversion is preferred over a better collection type conversion. In other words, the type of elements in the collection expression has more importance than the type of the collection. These rules are described in the feature spec for [better conversion from collection expression](~/_csharplang/proposals/csharp-13.0/collection-expressions-better-conversion.md).
- Conversion to <xref:System.Span%601>, <xref:System.ReadOnlySpan%601>, or another [`ref struct`](../builtin-types/ref-struct.md) type is better than a conversion to a non-ref struct type.
- Conversion to a noninterface type is better than a conversion to an interface type.

When a collection expression is converted to a `Span` or `ReadOnlySpan`, the span object's *safe context* is taken from the *safe context* of all elements included in the span. For detailed rules, see the [Collection expression specification](~/_csharplang/proposals/csharp-12.0/collection-expressions.md#ref-safety).

## Collection builder

Collection expressions work with any collection type that's *well-behaved*. A well-behaved collection has the following characteristics:

- The value of `Count` or `Length` on a [countable](./member-access-operators.md#index-from-end-operator-) collection produces the same value as the number of elements when enumerated.
- The types in the <xref:System.Collections.Generic?displayProperty=fullName> namespace are presumed to be side-effect free. As such, the compiler can optimize scenarios where such types might be used as intermediary values, but otherwise not be exposed.
- A call to some applicable `.AddRange(x)` member on a collection will result in the same final value as iterating over `x` and adding all of its enumerated values individually to the collection with `.Add`.

All the collection types in the .NET runtime are well-behaved.

> [!WARNING]
> If a custom collection type isn't well-behaved, the behavior when you use that collection type with collection expressions is undefined.

Your types opt in to collection expression support by writing a `Create()` method and applying the <xref:System.Runtime.CompilerServices.CollectionBuilderAttribute?displayProperty=fullName> on the collection type to indicate the builder method. For example, consider an application that uses fixed length buffers of 80 characters. That class might look something like the following code:

:::code language="csharp" source="./snippets/shared/CollectionExpressionExamples.cs" id="BufferDeclaration":::

You'd like to use it with collection expressions as shown in the following sample:

:::code language="csharp" source="./snippets/shared/CollectionExpressionExamples.cs" id="CustomBuilderUsage":::

The `LineBuffer` type implements `IEnumerable<char>`, so the compiler recognizes it as a collection of `char` items. The type parameter of the implemented <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface indicates the element type. You need to make two additions to your application to be able to assign collection expressions to a `LineBuffer` object. First, you need to create a class that contains a `Create` method:

:::code language="csharp" source="./snippets/shared/CollectionExpressionExamples.cs" id="BuilderClass":::

The `Create` method must return a `LineBuffer` object, and it must take a single parameter of the type `ReadOnlySpan<char>`. The type parameter of the `ReadOnlySpan` must match the element type of the collection. A builder method that returns a generic collection would have the generic `ReadOnlySpan<T>` as its parameter. The method must be accessible and `static`.

Finally, you must add the <xref:System.Runtime.CompilerServices.CollectionBuilderAttribute> to the `LineBuffer` class declaration:

:::code language="csharp" source="./snippets/shared/CollectionExpressionExamples.cs" id="BuilderAttribute":::

The first parameter provides the name of the *Builder* class. The second attribute provides the name of the builder method.
