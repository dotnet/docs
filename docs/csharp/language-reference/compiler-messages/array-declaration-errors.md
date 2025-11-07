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
 - "CS9212"
 - "CS9213"
 - "CS9214"
 - "CS9215"
 - "CS9222"
 - "CS9332"
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
 - "CS9212"
 - "CS9213"
 - "CS9214"
 - "CS9215"
 - "CS9222"
 - "CS9332"
ms.date: 11/07/2025
ai-usage: ai-assisted
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
- [**CS9212**](#invalid-collection-initializer): *Spread operator '`..`' cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'.*
- [**CS9213**](#invalid-collection-initializer): *Collection expression target 'type' has no element type.*
- [**CS9214**](#invalid-collection-initializer): *Collection expression type must have an applicable constructor that can be called with no arguments.*
- [**CS9215**](#invalid-collection-initializer): *Collection expression type 'type' must have an instance or extension method 'Add' that can be called with a single argument.*
- [**CS9222**](#invalid-collection-initializer): *Collection initializer results in an infinite chain of instantiations of collection 'type'.*
- [**CS9332**](#invalid-collection-initializer): *Cannot use '..' spread operator in the filter expression of a catch clause.*

In addition, the following warnings are covered in this article:

- [**CS1062**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer element is obsolete.*
- [**CS1064**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer element is obsolete.*
- [**CS3007**](#common-language-specification-warnings): *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- [**CS3016**](#common-language-specification-warnings): *Arrays as attribute arguments is not CLS-compliant*
- [**CS0251**](#invalid-array-element-access): *Indexing an array with a negative index (array indices always start at zero)*
- [**CS9208**](#invalid-collection-initializer): *Collection expression may incur unexpected heap allocations. Consider explicitly creating an array, then converting to the final type to make the allocation explicit.*
- [**CS9209**](#invalid-collection-initializer): *Collection expression may incur unexpected heap allocations due to use of '`..`' spreads. Consider explicitly creating an array, then converting to the final type to make the allocation explicit.*
- [**CS9332**](#invalid-collection-initializer): *Cannot use '..' spread operator in the filter expression of a catch clause.*

## Invalid array element access

- **CS0022**: *Wrong number of indices inside [], expected 'number'*
- **CS0251**: *Indexing an array with a negative index (array indices always start at zero)*

To access array elements correctly, follow these indexing rules. For more information, see [Arrays](../builtin-types/arrays.md).

- Specify the same number of indices as declared dimensions (**CS0022**). A one-dimensional array needs one index, a three-dimensional array needs three indices.
- Use only non-negative integers for array indices (**CS0251**). Array indices always start at zero.

## Invalid collection initializer

- **CS0747**: *Invalid initializer member declarator.*
- **CS1920**: *Element initializer cannot be empty.*
- **CS1921**: *The best overloaded method match has wrong signature for the initializer element. The initializable `Add` must be an accessible instance method.*
- **CS1922**: *Cannot initialize type 'type' with a collection initializer because 'type' doesn't implement 'System.Collections.IEnumerable'.*
- **CS1925**: *Cannot initialize object of type 'type' with a collection initializer.*
- **CS1927**: *Warning: Ignoring /win32manifest for module because it only applies to assemblies*
- **CS1950**: *The best overloaded Add method for the collection initializer has some invalid arguments.*
- **CS1954**: *The best overloaded method match for the collection initializer element cannot be used. Collection initializer '`Add`' methods cannot have `ref` or `out` parameters.*
- **CS9174**: *Cannot initialize type with a collection literal because the type is not constructible.*
- **CS9176**: *There is no target type for the collection literal.*
- **CS9203**: *A collection expression of this type cannot be used in this context because it may be exposed outside of the current scope.*
- **CS9210**: *This version of <xref:System.Collections.Immutable.ImmutableArray%601?displayProperty=nameWithType> can't be used with collection expressions.*
- **CS9212**: *Spread operator '`..`' cannot operate on variables of type 'type' because 'type' doesn't contain a public instance or extension definition for 'member'.*
- **CS9213**: *Collection expression target 'type' has no element type.*
- **CS9214**: *Collection expression type must have an applicable constructor that can be called with no arguments.*
- **CS9215**: *Collection expression type 'type' must have an instance or extension method 'Add' that can be called with a single argument.*
- **CS9222**: *Collection initializer results in an infinite chain of instantiations of collection 'type'.*
- **CS9332**: *Cannot use '..' spread operator in the filter expression of a catch clause.*

The compiler might also generate the following warnings:

- **CS1062**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS1063**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS1064**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS9208**: *Collection expression may incur unexpected heap allocations. Consider explicitly creating an array, then converting to the final type to make the allocation explicit.*
- **CS9209**: *Collection expression may incur unexpected heap allocations due to use of '`..`' spreads. Consider explicitly creating an array, then converting to the final type to make the allocation explicit.*

To create valid collection initializers, follow these rules. For more information, see [Collection expressions](../operators/collection-expressions.md).

- Don't mix property initialization with element addition in the same initializer (**CS0747**).
- Include at least one element in collection initializers with braces (**CS1920**).
- Ensure the collection type implements `IEnumerable` (**CS1922**).
- Use collection initializers only with collection types (**CS1925**).
- Verify the `Add` method is accessible, takes one parameter matching the element type, and doesn't use `ref` or `out` modifiers (**CS1921**, **CS1954**).
- Resolve ambiguous `Add` method overloads (**CS1950**).
- Provide an explicit target type for collection expressions when the compiler can't infer it (**CS9176**, **CS9213**).
- Ensure the collection type is constructible with a parameterless constructor (**CS9174**, **CS9214**).
- Don't use `ref struct` types in collection expressions that may violate ref safety (**CS9203**).
- Update to a compatible runtime version for `ImmutableArray` collection expressions (**CS9210**).
- Implement enumeration patterns (like `GetEnumerator`) for spread operator support (**CS9212**).
- Avoid circular dependencies in collection initialization (**CS9222**).
- Don't use the spread operator in catch clause filter expressions (**CS9332**).

## Invalid array rank

- **CS0178**: *Invalid rank specifier: expected '`,`' or '`]`'*
- **CS0650**: *Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.*
- **CS1552**: *Array type specifier, `[]`, must appear before parameter name*

To declare arrays correctly, follow the proper syntax order. For more information, see [Arrays](../builtin-types/arrays.md) and the [C# Language Specification](~/_csharpstandard/standard/arrays.md#177-array-initializers) section on array initializers.

An array declaration consists of these tokens in order:

1. The type of array elements (for example, `int`, `string`, or `SomeClassType`)
2. The array brackets, optionally including commas for multiple dimensions
3. The variable name

When specifying array dimensions, you can use:

- A number of elements in braces (`{` and `}`)
- Empty brackets
- One or more commas enclosed in brackets

The following examples show valid array declarations:

:::code language="csharp" source="./snippets/array-warnings/Program.cs" id="ArrayDeclarations":::

## Invalid array length

- **CS0248**: *Cannot create an array with a negative size*
- **CS0270**: *Array size cannot be specified in a variable declaration (try initializing with a 'new' expression)*
- **CS1586**: *Array creation must have array size or array initializer*

To create arrays with valid lengths, specify the size during initialization, not declaration. For more information, see [Arrays](../builtin-types/arrays.md).

- Specify array length as part of initialization, not declaration (**CS0270**).
- Use only positive integers for array dimensions (**CS0248**).
- Provide either a size in a `new` expression or an array initializer (**CS1586**).

The following example shows both mechanisms:

:::code language="csharp" source="./snippets/array-warnings/Program.cs" id="ArrayInitializers":::

## Invalid element type

- **CS0611**: *Array elements cannot be of type 'type'*
- **CS0719**: *Array elements cannot be of static type*
- **CS0820**: *Cannot assign array initializer to an implicitly typed local*
- **CS0826**: *No best type found for implicitly typed array*

To use arrays with correct element types, follow these type restrictions. For more information, see [Implicitly typed local variables](../statements/declarations.md#implicitly-typed-local-variables) and [best common type](~/_csharpstandard/standard/expressions.md#126316-finding-the-best-common-type-of-a-set-of-expressions).

- Don't use restricted types like <xref:System.TypedReference?displayProperty=fullName> and <xref:System.ArgIterator?displayProperty=fullName> as array element types (**CS0611**).
- Don't use `static` classes as array element types because instances can't be created (**CS0719**).
- Initialize implicitly typed arrays with a `new` expression (**CS0820**).
- Ensure all elements in an implicitly typed array initializer have a best common type (**CS0826**).

The following examples show how to declare implicitly typed arrays:

:::code language="csharp" source="./snippets/array-warnings/Program.cs" id="ImplicitInitializer":::

To ensure a best common type, use any of these techniques:

- Give the array an explicit type.
- Give all array elements the same type.
- Provide explicit casts on elements that might be causing the problem.

## Invalid array initializer

- **CS0623**: *Array initializers can only be used in a variable or field initializer. Try using a new expression instead.*
- **CS0846**: *A nested array initializer is expected*
- **CS1925**: *Cannot initialize object of type 'type' with a collection initializer.*

These errors indicate invalid array initializer syntax. For more information, see [Arrays](../builtin-types/arrays.md).

To create valid array initializers:

- Use array initializers only in variable or field declarations (**CS0623**). Use a `new` expression in other contexts.
- Balance braces (`{` and `}`) around elements or child arrays (**CS0846**).
- Ensure the initializing expression matches the number of arrays in a jagged array initialization.
- Use collection initializers only with collection types, not with arrays or other types (**CS1925**).

## Invalid collection builder

- **CS9175**: *An expression tree may not contain a collection expression.*
- **CS9177**: *The 'CollectionBuilderAttribute' builder method return type must match collection type used in 'betterness'.*
- **CS9178**: *There is no target type for the natural type 'type'.*
- **CS9179**: *Collection expression type must have an applicable constructor that can be called with no arguments.*
- **CS9180**: *The 'CollectionBuilderAttribute' builder method must be a static method.*
- **CS9181**: *The 'CollectionBuilderAttribute' builder method parameter type must match parameter 'ReadOnlySpan&lt;{0}&gt;'*
- **CS9182**: *Invalid 'CollectionBuilderAttribute'. No matching '{0}' method found on builder type '{1}'.*
- **CS9183**: *The 'CollectionBuilderAttribute' method return type must be a non-abstract, non-interface type usable as a 'type'*
- **CS9185**: *A *static type* cannot be used as a type argument.*
- **CS9186**: *The `CollectionBuilderAttribute` method name is invalid.*
- **CS9187**: *Could not find an accessible 'Create' method with the expected signature: a static method with a single parameter of type 'ReadOnlySpan&lt;{0}&gt;' and return type '{1}'.*
- **CS9188**: *'scoped' cannot be used as a modifier on a collection expression type parameter.*
- **CS9190**: *The 'CollectionBuilderAttribute' method 'builderMethod' is inapplicable because it's generic.*
- **CS9192**: *Inline array conversions cannot be used with collection expressions.*
- **CS9193**: *Argument 'argument' may not be passed with the 'ref' keyword.*
- **CS9194**: *Argument 'argument' may not be passed with the 'out' keyword*
- **CS9195**: *Argument 'argument' may not be passed with the 'in' keyword*
- **CS9196**: *Feature 'collection expression' is not available in C# 'version'. Please use language version 'requiredVersion' or greater.*
- **CS9197**: *Feature 'inline arrays' is not available in C# 'version'. Please use language version 'requiredVersion' or greater.*
- **CS9198**: *Feature 'ref and unsafe in async and iterator methods' is not available in C# 'version'. Please use language version 'requiredVersion' or greater.*
- **CS9199**: *Feature 'collection expression' is not available in C# 'version'. Please use language version 'requiredVersion' or greater.*
- **CS9202**: *Feature 'ref readonly parameters' is not available in C# 'version'. Please use language version 'requiredVersion' or greater.*
- **CS9208**: *'nameof' operator cannot be used on an inline array access.*
- **CS9209**: *A ref-returning property 'property' cannot be used as a value argument.*
- **CS9211**: *The expression must be of type 'type' because it's being assigned by reference*
- **CS9212**: *Cannot use collection expression as the value in a fixed statement*
- **CS9217**: *A 'ref' local cannot be preserved across 'await' or 'yield' boundary.*
- **CS9218**: *'paramName' is a ref struct and cannot be the type of a parameter*
- **CS9221**: *The type 'type' may not be a ref struct or a type parameter allowing ref structs in order to use it as parameter 'parameter' in the generic type or method 'member'*
- **CS9223**: *A struct that contains 'ref' fields cannot be used in a collection expression.*
- **CS9228**: *Non-variable declaration of a ref struct is not allowed*
- **CS9232**: *Partial method declarations have signature differences.*
- **CS9233**: *The 'file' modifier can be used only on types defined in top level in a compilation unit*

To create collection expressions with collection builder attributes correctly, follow these requirements. For more information, see [Collection expressions](../operators/collection-expressions.md).

- Ensure the target type has an iteration type that supports `foreach` (**CS9188**).
- Don't use generic types as collection builder types (**CS9185**).
- Verify the method name specified in `CollectionBuilderAttribute` is valid (**CS9186**).
- Apply `CollectionBuilderAttribute` only with static methods that match the required signature: return the collection type and take a `ReadOnlySpan<T>` parameter where `T` matches the element type (**CS9180**, **CS9181**, **CS9182**, **CS9183**, **CS9187**, **CS9190**).
- Ensure the return type matches and isn't abstract or an interface (**CS9177**, **CS9183**).
- Don't use ref structs or types with ref fields in collection expressions (**CS9218**, **CS9221**, **CS9223**, **CS9228**).
- Avoid using collection expressions in expression trees (**CS9175**).
- Use the correct language version for collection expressions and related features (**CS9196**, **CS9197**, **CS9198**, **CS9199**, **CS9202**).

## Common language specification warnings

- **CS3007**: *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- **CS3016**: *Arrays as attribute arguments is not CLS-compliant*

To write CLS-compliant code with arrays, follow these guidelines. For more information, see [Language independence](../../../standard/language-independence.md).

- Don't create overloaded methods that differ only in array element types (**CS3007**).
- Don't use arrays as attribute arguments (**CS3016**).

CS3007 occurs if you have an overloaded method that takes a jagged array and the only difference between the method signatures is the element type of the array. To avoid this error, consider using a rectangular array rather than a jagged array or, if CLS Compliance isn't needed, remove the <xref:System.CLSCompliantAttribute> attribute. For more information on CLS Compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).

CS3016 indicates that not compliant with the Common Language Specification (CLS) to pass an array to an attribute. For more information on CLS compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).
