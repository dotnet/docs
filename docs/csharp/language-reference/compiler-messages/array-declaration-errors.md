---
title: Resolve errors and warnings related to array, collection, and stack allocation expressions
description: These compiler errors and warnings indicate errors in array declarations, collection initializers and expressions, and stack allocation expressions.
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
 - "CS1922"
 - "CS1925"
 - "CS1950"
 - "CS1954"
 - "CS3007"
 - "CS3016"
 - "CS8346"
 - "CS8353"
 - "CS8381"
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
 - "CS9221"
 - "CS9222"
 - "CS9332"
 - "CS9354"
 - "CS9355"
 - "CS9356"
 - "CS9357"
 - "CS9358"
 - "CS9359"
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
 - "CS1062"
 - "CS1063"
 - "CS1064"
 - "CS1552"
 - "CS1586"
 - "CS1920"
 - "CS1921"
 - "CS1922"
 - "CS1925"
 - "CS1950"
 - "CS1954"
 - "CS3007"
 - "CS3016"
 - "CS8346"
 - "CS8353"
 - "CS8381"
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
 - "CS9221"
 - "CS9222"
 - "CS9332"
 - "CS9354"
 - "CS9355"
 - "CS9356"
 - "CS9357"
 - "CS9358"
 - "CS9359"
ms.date: 09/23/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings in array, collection, and stack allocation expressions

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS0022**](#invalid-array-element-access): *Wrong number of indices inside [], expected 'number'*
- [**CS0178**](#invalid-array-rank): *Invalid rank specifier: expected '`,`' or '`]`'*
- [**CS0248**](#invalid-array-length): *Cannot create an array with a negative size*
- [**CS0251**](#invalid-array-element-access): *Indexing an array with a negative index (array indices always start at zero)*
- [**CS0270**](#invalid-array-length): *Array size cannot be specified in a variable declaration (try initializing with a '`new`' expression)*
- [**CS0611**](#invalid-element-type): *Array elements cannot be of type*
- [**CS0623**](#invalid-array-initializer): *Array initializers can only be used in a variable or field initializer. Try using a new expression instead.*
- [**CS0650**](#invalid-array-rank): *Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.*
- [**CS0719**](#invalid-element-type): *Array elements cannot be of static type*
- [**CS0747**](#invalid-collection-initializer): *Invalid initializer member declarator.*
- [**CS0820**](#invalid-element-type): *Cannot assign array initializer to an implicitly typed local*
- [**CS0826**](#invalid-element-type): *No best type found for implicitly typed array.*
- [**CS0846**](#invalid-array-initializer): *A nested array initializer is expected*
- [**CS1062**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer element is obsolete.*
- [**CS1063**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer element is obsolete.*
- [**CS1064**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer element is obsolete.*
- [**CS1552**](#invalid-array-rank): *Array type specifier, `[]`, must appear before parameter name*
- [**CS1586**](#invalid-array-length): *Array creation must have array size or array initializer*
- [**CS1920**](#invalid-collection-initializer): *Element initializer cannot be empty.*
- [**CS1921**](#invalid-collection-initializer): *The best overloaded method match has wrong signature for the initializer element. The initializable `Add` must be an accessible instance method.*
- [**CS1922**](#invalid-collection-initializer): *Cannot initialize type 'type' with a collection initializer because it does not implement 'System.Collections.IEnumerable'*
- [**CS1925**](#invalid-array-initializer): *Cannot initialize object of type 'type' with a collection initializer.*
- [**CS1950**](#invalid-collection-initializer): *The best overloaded Add method for the collection initializer has some invalid arguments.*
- [**CS1954**](#invalid-collection-initializer): *The best overloaded method match for the collection initializer element cannot be used. Collection initializer '`Add`' methods cannot have `ref` or `out` parameters.*
- [**CS3007**](#common-language-specification-warnings): *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- [**CS3016**](#common-language-specification-warnings): *Arrays as attribute arguments is not CLS-compliant*
- [**CS8346**](#stack-allocation-errors): *Conversion of a stackalloc expression of type 'element type' to type 'target type' is not possible.*
- [**CS8353**](#stack-allocation-errors): *A result of a stackalloc expression of type 'span type' cannot be used in this context because it may be exposed outside of the containing method*
- [**CS8381**](#stack-allocation-errors): *"Invalid rank specifier: expected ']'*
- [**CS9174**](#invalid-collection-initializer): *Cannot initialize type with a collection literal because the type is not constructible.*
- [**CS9176**](#invalid-collection-initializer): *There is no target type for the collection literal.*
- [**CS9185**](#invalid-collection-builder): *The CollectionBuilderAttribute builder type must be a non-generic class or struct.*
- [**CS9186**](#invalid-collection-builder): *The CollectionBuilderAttribute method name is invalid.*
- [**CS9187**](#invalid-collection-builder): *Could not find an accessible 'method-name' method with the expected signature: a static method whose last parameter is a `ReadOnlySpan<T>` for 'element type' and return type 'collection-type'.*
- [**CS9188**](#invalid-collection-builder): *'collection-type' has a CollectionBuilderAttribute but no element type.*
- [**CS9203**](#invalid-collection-initializer): *A collection expression of this type cannot be used in this context because it may be exposed outside of the current scope.*
- [**CS9208**](#invalid-collection-initializer): *Collection expression of type 'collection-type' may incur unexpected heap allocations. Consider explicitly creating an array, then converting to 'collection-type' to make the allocation explicit.*
- [**CS9209**](#invalid-collection-initializer): *Collection expression of type 'collection-type' may incur unexpected heap allocations due to the use of '`..`' spreads. Consider explicitly creating an array, then converting to 'collection-type' to make the allocation explicit.*
- [**CS9210**](#invalid-collection-initializer): *This version of <xref:System.Collections.Immutable.ImmutableArray`1?displayProperty=nameWithType>cannot be used with collection expressions.*
- [**CS9212**](#invalid-collection-initializer): *Spread operator '`..`' cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'*
- [**CS9213**](#invalid-collection-initializer): *Collection expression target 'type' has no element type.*
- [**CS9214**](#invalid-collection-initializer): *Collection expression type must have an applicable constructor that can be called with no arguments.*
- [**CS9215**](#invalid-collection-initializer): *Collection expression type 'type' must have an instance or extension method 'Add' that can be called with a single argument.*
- [**CS9221**](#invalid-collection-builder): *The type 'type' may not be a ref struct or a type parameter allowing ref structs in order to use it as parameter 'parameter' in the generic type or method 'member'*
- [**CS9222**](#invalid-collection-initializer): *Collection initializer results in an infinite chain of instantiations of collection 'type'.*
- [**CS9332**](#invalid-collection-initializer): *Cannot use '..' spread operator in the filter expression of a catch clause.*
- [**CS9354**](#invalid-collection-expression-arguments): *'with(...)' element must be the first element*
- [**CS9355**](#invalid-collection-expression-arguments): *'with(...)' elements are not supported for type 'type'*
- [**CS9356**](#invalid-collection-expression-arguments): *'with(...)' element arguments cannot be dynamic*
- [**CS9357**](#invalid-collection-expression-arguments): *'with(...)' element for a read-only interface must be empty if present*
- [**CS9358**](#invalid-collection-expression-element-type): *Element type of this collection may not be a ref struct or a type parameter allowing ref structs*
- [**CS9359**](#invalid-collection-expression-arguments): *No overload for method 'method' takes number 'with(...)' element arguments*

## Invalid array element access

- **CS0022**: *Wrong number of indices inside [], expected 'number'*
- **CS0251**: *Indexing an array with a negative index (array indices always start at zero)*

To access array elements correctly, follow these indexing rules. For more information, see [Arrays](../builtin-types/arrays.md).

- Specify the same number of indices as declared dimensions (**CS0022**). A one-dimensional array needs one index; a three-dimensional array needs three indices.
- Use only non-negative integers for array indices (**CS0251**). Array indices always start at zero.

## Invalid collection initializer

- **CS0747**: *Invalid initializer member declarator.*
- **CS1062**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS1063**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS1064**: *The best overloaded Add method for the collection initializer element is obsolete.*
- **CS1920**: *Element initializer cannot be empty.*
- **CS1921**: *The best overloaded method match has wrong signature for the initializer element. The initializable `Add` must be an accessible instance method.*
- **CS1922**: *Cannot initialize type 'type' with a collection initializer because it does not implement 'System.Collections.IEnumerable'*
- **CS1950**: *The best overloaded Add method for the collection initializer has some invalid arguments.*
- **CS1954**: *The best overloaded method match for the collection initializer element cannot be used. Collection initializer '`Add`' methods cannot have `ref` or `out` parameters.*
- **CS9174**: *Cannot initialize type with a collection literal because the type is not constructible.*
- **CS9176**: *There is no target type for the collection literal.*
- **CS9203**: *A collection expression of this type cannot be used in this context because it may be exposed outside of the current scope.*
- **CS9208**: *Collection expression of type 'collection-type' may incur unexpected heap allocations. Consider explicitly creating an array, then converting to 'collection-type' to make the allocation explicit.*
- **CS9209**: *Collection expression of type 'collection-type' may incur unexpected heap allocations due to the use of '`..`' spreads. Consider explicitly creating an array, then converting to 'collection-type' to make the allocation explicit.*
- **CS9210**: *This version of <xref:System.Collections.Immutable.ImmutableArray`1?displayProperty=nameWithType> can't be used with collection expressions.*
- **CS9212**: *Spread operator '`..`' cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'*
- **CS9213**: *Collection expression target 'type' has no element type.*
- **CS9214**: *Collection expression type must have an applicable constructor that can be called with no arguments.*
- **CS9215**: *Collection expression type 'type' must have an instance or extension method 'Add' that can be called with a single argument.*
- **CS9222**: *Collection initializer results in an infinite chain of instantiations of collection 'type'.*
- **CS9332**: *Cannot use '..' spread operator in the filter expression of a catch clause.*

To create valid collection initializers, follow these rules. For more information, see [Collection expressions](../operators/collection-expressions.md).

- Don't mix property initialization with element addition in the same initializer (**CS0747**).
- Include at least one element in collection initializers with braces (**CS1920**).
- If the type represents a collection, ensure it implements <xref:System.Collections.IEnumerable> (**CS1922**).
- If the type doesn't represent a collection, use an object initializer instead of a collection initializer (**CS1922**).
- If you can't modify a collection type that doesn't implement <xref:System.Collections.IEnumerable>, initialize its elements by using constructors or other methods (**CS1922**).
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

The following example produces CS1922 because `TestClass` doesn't implement <xref:System.Collections.IEnumerable>. The object initializer assigns properties instead of trying to add collection elements:

```csharp
public class Test
{
    public static void Main()
    {
        var invalid = new TestClass { 1, "hello" }; // CS1922
        var valid = new TestClass { MemberA = 1, MemberB = "hello" };
    }
}

public class TestClass
{
    public int MemberA { get; set; }
    public string MemberB { get; set; } = "";
}
```

## Invalid collection expression element type

- **CS9358**: *Element type of this collection may not be a ref struct or a type parameter allowing ref structs*

The collection target doesn't support a `ref struct` element type or a type parameter that allows ref-like types. Use a non-ref-like element type. For generic code, use a type parameter that doesn't allow ref-like types.

## Invalid collection expression arguments

- **CS9354**: *'with(...)' element must be the first element*
- **CS9355**: *'with(...)' elements are not supported for type 'type'*
- **CS9356**: *'with(...)' element arguments cannot be dynamic*
- **CS9357**: *'with(...)' element for a read-only interface must be empty if present*
- **CS9359**: *No overload for method 'method' takes number 'with(...)' element arguments*

For the supported targets and syntax, see [Collection expression arguments](../operators/collection-expressions.md#collection-expression-arguments).

- **CS9354**: The `with(...)` element follows another collection element, or the expression contains more than one `with(...)` element. Move the single `with(...)` element to the first position.
- **CS9355**: The target type doesn't support collection expression arguments, as with arrays and span types. Remove the `with(...)` element, or change the target to a type that supports collection expression arguments.
- **CS9356**: An argument in the `with(...)` element has the compile-time type `dynamic`. Cast or convert each dynamic argument to the intended non-dynamic type.
- **CS9357**: A read-only interface target supports only an empty `with()` element. Remove the arguments, remove the `with()` element, or use a target type that accepts those arguments.
- **CS9359**: No accessible constructor, collection builder method, or supported interface signature accepts the supplied number of `with(...)` arguments. Match the arguments to an applicable constructor or interface signature. For a collection builder, match them to parameters before the final `ReadOnlySpan<T>` parameter, or add a matching overload.

## Invalid array rank

- **CS0178**: *Invalid rank specifier: expected '`,`' or '`]`'*
- **CS0650**: *Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.*
- **CS1552**: *Array type specifier, `[]`, must appear before parameter name*

To declare arrays correctly, follow the proper syntax order. For more information, see [Arrays](../builtin-types/arrays.md) and the [C# Language Specification](~/_csharpstandard/standard/arrays.md#177-array-initializers) section on array initializers.

An array declaration consists of these tokens in order:

1. The type of array elements (for example, `int`, `string`, or `SomeClassType`).
2. The array brackets, optionally including commas for multiple dimensions.
3. The variable name.

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

## Stack allocation errors

These errors indicate an invalid target conversion, lifetime, or rank and size syntax for a [`stackalloc`](../operators/stackalloc.md) expression.

### Invalid stack allocation target conversion

- **CS8346**: *Conversion of a stackalloc expression of type 'element type' to type 'target type' is not possible.*

A `stackalloc` expression has built-in conversions to a compatible `Span<T>` or `ReadOnlySpan<T>`. Its built-in pointer conversion is available when the expression directly initializes a local variable whose type is a pointer type or `var`. A later assignment to a pointer, or a pointer cast around the expression, produces CS8346. These restrictions apply to the built-in conversions; an applicable user-defined conversion from the pointer form can make another target type valid. The diagnostic also occurs when the span element type isn't compatible, the target is a scalar or another impermissible type, or the expression is used in a nonlocal context.

The following examples generate CS8346:

```csharp
unsafe class Example
{
    private static int* field = stackalloc int[3];

    public static void Main()
    {
        Span<int> wrongElementType = stackalloc short[3];
        double scalar = stackalloc int[3];
        Span<int> explicitCast = (Span<int>)stackalloc short[3];
        Span<int> pointerCastToSpan = (int*)stackalloc int[3];
        int* pointerCastToPointer = (int*)stackalloc int[3];
        var pointerCastWithVar = (int*)stackalloc int[3];
    }
}
```

Select a compatible `Span<T>`, `ReadOnlySpan<T>`, or pointer target. A compatible span cast is permitted; remove or change only casts whose target isn't compatible with the stack allocation element type. For a pointer result, put the `stackalloc` expression directly in the local variable declaration initializer. Keep the allocation local instead of using it in a field, property, or another invalid nonlocal context. In stable C#, the pointer declaration requires an unsafe context. In C# 15 preview, the pointer conversion can be permitted outside an unsafe context; see the [updated memory safety model](../unsafe-code.md#the-updated-memory-safety-model-preview) for current preview guidance. Operations that access memory through the pointer remain unsafe.

```csharp
unsafe class Example
{
    public static void Main()
    {
        Span<int> stackSpan = stackalloc int[3];
        short* stackPointer = stackalloc short[3];
        var inferredPointer = stackalloc int[3];
    }
}
```

An applicable user-defined conversion from the pointer form is a separate conversion path from the built-in pointer conversions. The following example compiles in C# 14 with unsafe code enabled:

```csharp
unsafe struct Example
{
    public static implicit operator Example(int* value) => new();
}

unsafe class Program
{
    public static void Main()
    {
        Example value = stackalloc int[3];
    }
}
```

### Escape and lifetime restrictions

- **CS8353**: *A result of a stackalloc expression of type 'span type' cannot be used in this context because it may be exposed outside of the containing method*

Stack-allocated memory is valid only while the containing method is running. Keep the resulting pointer or span within that method. Don't store it in a field, return it, or use it in another context where it can outlive the method.

For more information about escape scopes and related diagnostics, see [Errors and warnings related to ref safety](ref-safety-errors.md#escape-scope-violations-and-conditional-operators).

### Invalid rank or size syntax

- **CS8381**: *"Invalid rank specifier: expected ']'*

A `stackalloc` expression allocates a one-dimensional block of memory. When you omit the element type, use empty brackets followed by an initializer, such as `stackalloc[] { 1, 2, 3 }`. To specify a size, put the element type before the size, such as `stackalloc int[3]`. Remove commas, extra rank specifiers, and other invalid tokens before the closing `]`.

## Invalid element type

- **CS0611**: *Array elements cannot be of type 'type'*
- **CS0719**: *Array elements cannot be of static type*
- **CS0820**: *Cannot assign array initializer to an implicitly typed local*
- **CS0826**: *No best type found for implicitly typed array*

To use arrays with correct element types, follow these type restrictions. For more information, see [Implicitly typed local variables](../statements/declarations.md#implicitly-typed-local-variables) and [best common type](~/_csharpstandard/standard/expressions.md#126317-finding-the-best-common-type-of-a-set-of-expressions).

- Don't use restricted types like <xref:System.TypedReference?displayProperty=fullName> and <xref:System.ArgIterator?displayProperty=fullName> as array element types (**CS0611**).
- Don't use `static` classes as array element types because you can't create instances (**CS0719**).
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
- **CS0846**: *A nested array initializer is expected.*
- **CS1925**: *Cannot initialize object of type 'type' with a collection initializer.*

These errors indicate invalid array initializer syntax. For more information, see [Arrays](../builtin-types/arrays.md).

To create valid array initializers:

- Use array initializers only in variable or field declarations (**CS0623**). Use a `new` expression in other contexts.
- Balance braces (`{` and `}`) around elements or child arrays (**CS0846**).
- Ensure the initializing expression matches the number of arrays in a jagged array initialization.
- Use collection initializers only with collection types, not with arrays or other types (**CS1925**).

## Invalid collection builder

- **CS9185**: *The CollectionBuilderAttribute builder type must be a non-generic class or struct.*
- **CS9186**: *The `CollectionBuilderAttribute` method name is invalid.*
- **CS9187**: *Could not find an accessible 'method-name' method with the expected signature: a static method whose last parameter is a `ReadOnlySpan<T>` for 'element type' and return type 'collection-type'.*
- **CS9188**: *'collection-type' has a CollectionBuilderAttribute but no element type.*
- **CS9221**: *The type 'type' may not be a ref struct or a type parameter allowing ref structs in order to use it as parameter 'parameter' in the generic type or method 'member'*

To create collection expressions with collection builder attributes correctly, follow these requirements. For more information, see [Collection expressions](../operators/collection-expressions.md).

- Ensure the target type has an iteration type that supports `foreach` (**CS9188**).
- Don't use generic types as collection builder types (**CS9185**).
- Verify the method name specified in `CollectionBuilderAttribute` is valid (**CS9186**).
- Apply `CollectionBuilderAttribute` only with methods that match the required signature: return the collection type and take a final `ReadOnlySpan<T>` parameter where `T` matches the element type (**CS9187**).
- Use an eligible element type for the builder's `ReadOnlySpan<T>` parameter. It can't be a ref struct or a type parameter that allows ref structs (**CS9221**).

## Common Language Specification warnings

- **CS3007**: *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- **CS3016**: *Arrays as attribute arguments is not CLS-compliant*

To write CLS-compliant code with arrays, follow these guidelines. For more information, see [Language independence](../../../standard/language-independence.md).

- Don't create overloaded methods that differ only in array element types (**CS3007**).
- Don't use arrays as attribute arguments (**CS3016**).

CS3007 occurs if you have an overloaded method that takes a jagged array and the only difference between the method signatures is the element type of the array. To avoid this error, consider using a rectangular array rather than a jagged array or, if CLS compliance isn't needed, remove the <xref:System.CLSCompliantAttribute> attribute. For more information about CLS compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).

CS3016 indicates that passing an array to an attribute isn't compliant with the Common Language Specification (CLS). For more information about CLS compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).
