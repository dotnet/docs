---
title: Resolve errors and warnings related to array and collection declarations and initializations
description: These compiler errors and warnings indicate errors in the syntax for declaring and initializing array and collection variables. There are multiple valid expressions to declare an array. Combining them incorrectly leads to errors. Collection initializers and collection expressions provide initial values for an array or collection.
f1_keywords:
 - "CS0022"
 - "CS0178"
 - "CS0248"
 - "CS0251"
 - "CS0270"
 - "CS0611"
 - "CS0623"
 - "CS0650"
 - "CS0719"
 - "CS0747"
 - "CS0820"
 - "CS0826"
 - "CS0846"
 - "CS1062"
 - "CS1063"
 - "CS1064"
 - "CS1552"
 - "CS1586"
 - "CS1920"
 - "CS1921"
 - "CS1925"
 - "CS1950"
 - "CS1954"
 - "CS3007"
 - "CS3016"
 - "CS9174"
 - "CS9176"
 - "CS9185"
 - "CS9186"
 - "CS9187"
 - "CS9188"
 - "CS9203"
 - "CS9208"
 - "CS9209"
 - "CS9210"
helpviewer_keywords:
 - "CS0022"
 - "CS0178"
 - "CS0248"
 - "CS0251"
 - "CS0270"
 - "CS0611"
 - "CS0623"
 - "CS0650"
 - "CS0719"
 - "CS0747"
 - "CS0820"
 - "CS0826"
 - "CS0846"
 - "CS1552"
 - "CS1586"
 - "CS1062"
 - "CS1063"
 - "CS1064"
 - "CS1920"
 - "CS1921"
 - "CS1925"
 - "CS1950"
 - "CS1954"
 - "CS3007"
 - "CS3016"
 - "CS9174"
 - "CS9176"
 - "CS9185"
 - "CS9186"
 - "CS9187"
 - "CS9188"
 - "CS9203"
 - "CS9208"
 - "CS9209"
 - "CS9210"
ms.date: 11/02/2023
---
# Resolve errors and warnings in array and collection declarations and initialization expressions

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0022**](#invalid-array-element-access): *Wrong number of indices inside [], expected 'number'*
- [**CS0178**](#invalid-array-rank): *Invalid rank specifier: expected '`,`' or '`]`'*
- [**CS0248**](#invalid-array-length): *Cannot create an array with a negative size*
- [**CS0270**](#invalid-array-length): *Array size cannot be specified in a variable declaration (try initializing with a '`new`' expression)*
- [**CS0611**](#invalid-element-type): *Array elements cannot be of type*
- [**CS0623**](#invalid-array-initializer): *Array initializers can only be used in a variable or field initializer. Try using a new expression instead.*
- [**CS0650**](#invalid-array-rank): *Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.*
- [**CS0719**](#invalid-element-type): *Array elements cannot be of static type*
- [**CS0747**](#invalid-collection-initializer): *Invalid initializer member declarator.*
- [**CS0820**](#invalid-element-type): *Cannot assign array initializer to an implicitly typed local*
- [**CS0826**](#invalid-element-type): *No best type found for implicitly typed array.*
- [**CS0846**](#invalid-array-initializer): *A nested array initializer is expected*
- [**CS1063**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer element is obsolete.*
- [**CS1552**](#invalid-array-rank): *Array type specifier, `[]`, must appear before parameter name*
- [**CS1586**](#invalid-array-length): *Array creation must have array size or array initializer*
- [**CS1920**](#invalid-collection-initializer): *Element initializer cannot be empty.*
- [**CS1921**](#invalid-collection-initializer): *The best overloaded method match has wrong signature for the initializer element. The initializable `Add` must be an accessible instance method.*
- [**CS1925**](#invalid-array-initializer): *Cannot initialize object of type 'type' with a collection initializer.*
- [**CS1950**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer has some invalid arguments.*
- [**CS1954**](#invalid-collection-initializer): *The best overloaded method match for the collection initializer element cannot be used. Collection initializer '`Add`' methods cannot have `ref` or `out` parameters.*
- [**CS9174**](#invalid-collection-initializer): *Cannot initialize type with a collection literal because the type is not constructible.*
- [**CS9176**](#invalid-collection-initializer): *There is no target type for the collection literal.*
- [**CS9185**](#invalid-collection-builder): *The CollectionBuilderAttribute builder type must be a non-generic class or struct.*
- [**CS9186**](#invalid-collection-builder): *The CollectionBuilderAttribute method name is invalid.*
- [**CS9187**](#invalid-collection-builder): *Could not find an accessible method with the expected signature: a static method with a single parameter of type `ReadOnlySpan<T>`; and correct return type*
- [**CS9188**](#invalid-collection-builder): *Type has a CollectionBuilderAttribute but no element type.*
- [**CS9203**](#invalid-collection-initializer): *A collection expression of this type cannot be used in this context because it may be exposed outside of the current scope.*
- [**CS9210**](#invalid-collection-initializer): *This version of <xref:System.Collections.Immutable.ImmutableArray%601?displayProperty=nameWithType>cannot be used with collection expressions.*

In addition, the following warnings are covered in this article:

- [**CS1062**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer element is obsolete.*
- [**CS1064**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer element is obsolete.*
- [**CS3007**](#common-language-specification-warnings): *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- [**CS3016**](#common-language-specification-warnings): *Arrays as attribute arguments is not CLS-compliant*
- [**CS0251**](#invalid-array-element-access): *Indexing an array with a negative index (array indices always start at zero)*
- [**CS9208**](#invalid-collection-initializer): *Collection expression may incur unexpected heap allocations. Consider explicitly creating an array, then converting to the final type to make the allocation explicit.*
- [**CS9209**](#invalid-collection-initializer): *Collection expression may incur unexpected heap allocations due to use of '`..`' spreads. Consider explicitly creating an array, then converting to the final type to make the allocation explicit.*

You can learn more about arrays, collection initializers and collection expressions in the following articles:

- [Arrays](../builtin-types/arrays.md)
- [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md)
- [Collection expressions](../operators/collection-expressions.md).

## Invalid collection initializer

The following errors indicate that the code generated by the compiler for a collection initializer is invalid:

- **CS0747**: *Invalid initializer member declarator.*
- **CS1063**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS1920**: *Element initializer cannot be empty.*
- **CS1921**: *The best overloaded method match has wrong signature for the initializer element. The initializable `Add` must be an accessible instance method.*
- **CS1950**: *The best overloaded Add method for the collection initializer has some invalid arguments.*
- **CS1954**: *The best overloaded method match for the collection initializer element cannot be used. Collection initializer '`Add`' methods cannot have `ref` or `out` parameters.*
- **CS9174**: *Cannot initialize type with a collection literal because the type is not constructible.*
- **CS9176**: *There is no target type for the collection literal.*
- **CS9203**: *A collection expression of this type cannot be used in this context because it may be exposed outside of the current scope.*
- **CS9210**: *This version of <xref:System.Collections.Immutable.ImmutableArray%601?displayProperty=nameWithType>cannot be used with collection expressions.*

The compiler might also generate the following warning:

- **CS1062**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS1064**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS9208**: *Collection expression may incur unexpected heap allocations. Consider explicitly creating an array, then converting to the final type to make the allocation explicit.*
- **CS9209**: *Collection expression may incur unexpected heap allocations due to use of '`..`' spreads. Consider explicitly creating an array, then converting to the final type to make the allocation explicit.*

The errors all indicate that the code generated by the compiler for a collection initializer is invalid. Check the following:

- A collection initializer contains a sequence of elements. You can't mix setting properties on the collection instance with adding elements in the same initializer.
- A collection initializer that includes braces (`{` and `}`) can't be empty.
- The class must implement IEnumerable and have a public `Add` method.
- A conforming `Add` method must be accessible and take one parameter that is the same type as the collection elements. The parameter can't include the `ref` or `out` modifier.
- Overload resolution must pick one `Add` method as a better match. There can't be multiple matching methods that are equally good.
- Collection expressions can initialize explicitly typed variables of a collection type. If the variable isn't a collection or array type, or is implicitly typed (using `var`), a collection initializer can't be used.
- A `ref struct` type, like <xref:System.Span%601?displayProperty=nameWithType> can't be initialized with a collection expression that may violate ref safety.
- A collection expression can't correctly initialize an <xref:System.Collections.Immutable.ImmutableArray%601?displayProperty=nameWithType> using the current version. Use a different version of the runtime, or change the initialization expression.

The warnings indicates that the collection expression, including any [spread elements](../operators/collection-expressions.md#spread-element) might allocate memory. Creating different storage and converting might be more efficient.

## Invalid array initializer

- **CS0623**: *Array initializers can only be used in a variable or field initializer. Try using a new expression instead.*
- **CS0846**: *A nested array initializer is expected*
- **CS1925**: *Cannot initialize object of type 'type' with a collection initializer.*

These errors indicate that you've created an invalid initializer. The likely cause is unbalanced braces `{` and `}` around one or more elements or child arrays. Ensure that the initializing expression matches the number of arrays in a jagged array initialization, and that the braces are balanced.

## Invalid array element access

- **CS0022**: *Wrong number of indices inside [], expected 'number'*
- **CS0251**: *Indexing an array with a negative index (array indices always start at zero)*

You access an element of an array by specifying the index for each axis declared in the array. The indices are between `[` and `]` after the array name. There are two rules for the array indices:

1. You must specify the same number of indices as used in the array declaration. If the array has one dimension, you must specify one index. If the array has three dimensions, you must specify three indices.
1. All indices must be non-negative integers.

## Invalid array rank

- **CS0178**: *Invalid rank specifier: expected '`,`' or '`]`'*
- **CS0650**: *Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.*
- **CS1552**: *Array type specifier, `[]`, must appear before parameter name*

An array declaration consists of the following tokens, in order:

1. The type of the array elements. For example, `int`, `string`, or `SomeClassType`.
1. The array brackets, optionally including commas to represent multi dimensions.
1. The variable name.

When an array initialization specifies the array dimensions, you can specify the following properties:

- A number of elements in braces (`{` and `}`)
- Empty brackets
- One or more commas enclosed in brackets

For example, the following are valid array declarations:

:::code language="csharp" source="./snippets/array-warnings/Program.cs" id="ArrayDeclarations":::

For more information, see the C# specification ([C# Language Specification](~/_csharpstandard/standard/arrays.md#177-array-initializers)) section on array initializers.

## Invalid array length

- **CS0248**: *Cannot create an array with a negative size*
- **CS0270**: *Array size cannot be specified in a variable declaration (try initializing with a 'new' expression*
- **CS1586**: *Array creation must have array size or array initializer*

The length of each dimension of an array must be specified as part of the array initialization, not its declaration. The length of each dimension must be positive. You can specify the length either by using a `new` expression to allocate the array, or using an array initializer to assign all the elements. The following example shows both mechanisms:

:::code language="csharp" source="./snippets/array-warnings/Program.cs" id="ArrayInitializers":::

## Invalid element type

- **CS0611**: *Array elements cannot be of type 'type'*
- **CS0719**: *Array elements cannot be of static type*
- **CS0820**: *Cannot assign array initializer to an implicitly typed local*
- **CS0826**: *No best type found for implicitly typed array.*

There are some types that cannot be used as the type of an array. These types include <xref:System.TypedReference?displayProperty=fullName> and <xref:System.ArgIterator?displayProperty=fullName>. The type of an array can't be a `static` class, because instances of a `static` class can't be created.

You can declare arrays as [implicitly typed local variables](../statements/declarations.md#implicitly-typed-local-variables). The array must be initialized using a `new` expression. In addition, all elements in an array initializer must have a [best common type](~/_csharpstandard/standard/expressions.md#126315-finding-the-best-common-type-of-a-set-of-expressions). The following examples show how to declare an implicitly typed array:

:::code language="csharp" source="./snippets/array-warnings/Program.cs" id="ImplicitInitializer":::

You can ensure the best common type using any of the following techniques:

- Give the array an explicit type.
- Give all array elements the same type.
- Provide explicit casts on those elements that might be causing the problem.

## Invalid collection builder

The following errors indicate errors in your collection builder type:

- **CS9185**: *The `CollectionBuilderAttribute` builder type must be a non-generic class or struct.*
- **CS9186**: *The `CollectionBuilderAttribute` method name is invalid.*
- **CS9187**: *Could not find an accessible method with the expected signature: a static method with a single parameter of type `ReadOnlySpan<T>`; and correct return type.*
- **CS9188**: *Type has a `CollectionBuilderAttribute` but no element type.*

These errors indicate that your collection builder type needs modification. Remember the following rules:

- The collection type must have an iteration type. In other words, you can [`foreach`](~/_csharpstandard/standard/statements.md#1395-the-foreach-statement) the type as a collection.
- The collection builder type can't be a generic type.
- The method name specified on the <xref:System.Runtime.CompilerServices.CollectionBuilderAttribute?displayProperty=fullName> must be a valid method name. For example, it can't be finalizer, or other name that contains invalid identifier characters.
- The collection builder method must be an accessible static method. It must return the collection type, and it must take a parameter of `ReadOnlySpan<T>` where `T` matches the element type of the collection.

## Common language specification warnings

- **CS3007**: *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- **CS3016**: *Arrays as attribute arguments is not CLS-compliant*

CS3007 occurs if you have an overloaded method that takes a jagged array and the only difference between the method signatures is the element type of the array. To avoid this error, consider using a rectangular array rather than a jagged array or, if CLS Compliance isn't needed, remove the <xref:System.CLSCompliantAttribute> attribute. For more information on CLS Compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).

CS3016 indicates that not compliant with the Common Language Specification (CLS) to pass an array to an attribute. For more information on CLS compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).
