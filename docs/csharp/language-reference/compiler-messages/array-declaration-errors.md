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
 - "CS1552"
 - "CS1586"
 - "CS1920"
 - "CS1921"
 - "CS1925"
 - "CS1954"
 - "CS3007"
 - "CS3016"
 - "CS9174"
 - "CS9176"
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
 - "CS1920"
 - "CS1921"
 - "CS1925"
 - "CS1954"
 - "CS3007"
 - "CS3016"
 - "CS9174"
 - "CS9176"
ms.date: 08/29/2023
---
# Resolve errors and warnings in array and collection declarations and initialization expressions

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0022**](#invalid-array-element-access) - *Wrong number of indices inside [], expected 'number'*
- [**CS0178**](#invalid-array-rank) - *Invalid rank specifier: expected '`,`' or '`]`'*
- [**CS0248**](#invalid-array-length) - *Cannot create an array with a negative size*
- [**CS0270**](#invalid-array-length) - *Array size cannot be specified in a variable declaration (try initializing with a '`new`' expression)*
- [**CS0611**](#invalid-element-type) - *Array elements cannot be of type*
- [**CS0623**](#invalid-initializer) - *Array initializers can only be used in a variable or field initializer. Try using a new expression instead.*
- [**CS0650**](#invalid-array-rank) - *Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.*
- [**CS0719**](#invalid-element-type) - *Array elements cannot be of static type*
- [**CS0820**](#invalid-element-type) - *Cannot assign array initializer to an implicitly typed local*
- [**CS0826**](#invalid-element-type) - *No best type found for implicitly typed array.*
- [**CS0846**](#invalid-initializer) - *A nested array initializer is expected*
- [**CS1552**](#invalid-array-rank) - *Array type specifier, `[]`, must appear before parameter name*
- [**CS1586**](#invalid-array-length) - *Array creation must have array size or array initializer*
- [**CS1925**](#invalid-initializer) - *Cannot initialize object of type 'type' with a collection initializer.*
- **CS0747** - *Invalid initializer member declarator.*
- **CS1920** - *Element initializer cannot be empty.*
- **CS1921** - *The best overloaded method match has wrong signature for the initializer element. The initializable `Add` must be an accessible instance method.*
- **CS1954** - *The best overloaded method match for the collection initializer element cannot be used. Collection initializer '`Add`' methods cannot have `ref` or `out` parameters.*
- **CS9174** - *Cannot initialize type with a collection literal because the type is not constructible.*
- **CS9176** - *There is no target type for the collection literal.*

In addition, the following warnings are covered in this article:

- [**CS3007**](#common-language-specification-warnings) - *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- [**CS3016**](#common-language-specification-warnings) - *Arrays as attribute arguments is not CLS-compliant*
- [**CS0251**](#invalid-array-element-access) - *Indexing an array with a negative index (array indices always start at zero)*

- [Object and Collection Initializers](../programming-guide/classes-and-structs/object-and-collection-initializers.md)
- [Collection expressions](../operators/collection-expressions.md).

## Invalid array element access

- **CS0022** - *Wrong number of indices inside [], expected 'number'*
- **CS0251** - *Indexing an array with a negative index (array indices always start at zero)*

You access an element of an array by specifying the index for each axis declared in the array. The indices are between `[` and `]` after the array name. There are two rules for the array indices:

1. You must specify the same number of indices as used in the array declaration. If the array has one dimension, you must specify one index. If the array has three dimensions, you must specify three indices.
1. All indices must be non-negative integers.

## Invalid array rank

- **CS0178** - *Invalid rank specifier: expected '`,`' or '`]`'*
- **CS0650** - *Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.*
- **CS1552** - *Array type specifier, [], must appear before parameter name*

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

- **CS0248** - *Cannot create an array with a negative size*
- **CS0270** - *Array size cannot be specified in a variable declaration (try initializing with a 'new' expression*
- **CS1586** - *Array creation must have array size or array initializer*

The length of each dimension of an array must be specified as part of the array initialization, not its declaration. The length of each dimension must be positive. You can specify the length either by using a `new` expression to allocate the array, or using an array initializer to assign all the elements. The following example shows both mechanisms:

:::code language="csharp" source="./snippets/array-warnings/Program.cs" id="ArrayInitializers":::

## Invalid element type

- **CS0611** - *Array elements cannot be of type 'type'*
- **CS0719** - *Array elements cannot be of static type*
- **CS0820** - *Cannot assign array initializer to an implicitly typed local*
- **CS0826** - *No best type found for implicitly typed array.*

There are some types that cannot be used as the type of an array. These types include <xref:System.TypedReference?displayProperty=fullName> and <xref:System.ArgIterator?displayProperty=fullName>. The type of an array can't be a `static` class, because instances of a `static` class can't be created.

You can declare arrays as [implicitly typed local variables](../statements/declarations.md#implicitly-typed-local-variables). The array must be initialized using a `new` expression. In addition, all elements in an array initializer must have a [best common type](~/_csharpstandard/standard/expressions.md#126315-finding-the-best-common-type-of-a-set-of-expressions). The following examples show how to declare an implicitly typed array:

:::code language="csharp" source="./snippets/array-warnings/Program.cs" id="ImplicitInitializer":::

You can ensure the best common type using any of the following techniques:

- Give the array an explicit type.
- Give all array elements the same type.
- Provide explicit casts on those elements that might be causing the problem.

## Invalid initializer

- **CS0623** - *Array initializers can only be used in a variable or field initializer. Try using a new expression instead.*
- **CS0846** - *A nested array initializer is expected*
- **CS1925** - *Cannot initialize object of type 'type' with a collection initializer.*

These errors indicate that you've created an invalid initializer. The likely cause is unbalanced braces `{` and `}` around one or more elements or child arrays. Ensure that the initializing expression matches the number of arrays in a jagged array initialization, and that the braces are balanced.

## Common language specification warnings

- **CS3007** - *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- **CS3016** - *Arrays as attribute arguments is not CLS-compliant*

CS3007 occurs if you have an overloaded method that takes a jagged array and the only difference between the method signatures is the element type of the array. To avoid this error, consider using a rectangular array rather than a jagged array or, if CLS Compliance isn't needed, remove the <xref:System.CLSCompliantAttribute> attribute. For more information on CLS Compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).

CS3016 indicates that not compliant with the Common Language Specification (CLS) to pass an array to an attribute. For more information on CLS compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).

## Compiler Error CS0747

Invalid initializer member declarator.

An object initializer is used to assign values to properties or fields. Any expression which is not an assignment to a property or field is a compile-time error. Ensure that all expressions in the initializer are assignments to properties or fields of the type. In the following example, the second expression is an error because the value `1` is not assigned to any property or field of `List<int>`.

The following code generates CS0747:

```csharp
// cs0747.cs
using System.Collections.Generic;

public class C
{
    public static int Main()
    {
        var t = new List<int> { Capacity = 2, 1 }; // CS0747
        return 1;
    }
}
```

## Compiler Error CS1920

Element initializer cannot be empty.

A collection initializer consists of a sequence of element initializers. The element initializers do not have to be enclosed in braces unless they contain an assignment expression. However, if you do supply braces, they cannot be empty. If the element initializer is an object initializer, the braces may be empty as long as the initializer contains a new object creation expression.

- Add the missing expression between the braces.  
- If the expression is intended to be an object initializer, add the new object creation expression in front of the braces.

The following example generates CS1920:

```csharp
  // cs1920.cs
using System.Collections.Generic;
public class Test
{
    public static int Main()
    {
        // Error. Empty initializer
        // for inner list.
        List<List<int>> collection =
            new List<List<int>>() { { } }; // CS1920

        // OK. No initializer for inner list.
        List<List<int>> collection2 =
            new List<List<int>>() {  };

        // OK. Inner list is initialized
        // to one List<int> with zero elements.
        List<List<int>> collection3 =
            new List<List<int>>() { new List<int> { } };
        return 0;
    }
}
```

## Compiler Error CS1921

The best overloaded method match for 'method' has wrong signature for the initializer element. The initializable Add must be an accessible instance method.

This error is generated when you try to use a collection initializer with a class that has no public non-static `Add` method. If the `Add` method is not accessible because of its protection level (`private`, `protected`, `internal`) then you will get CS0122, so that this error probably means that the method is defined as `static`.

The following example generates CS1921:

```csharp
// cs1921.cs
using System.Collections;
public class C : CollectionBase
{
    public static void Add(int i)
    {
    }
}
public class Test
{
    public static void Main()
    {
        var collection = new C { 1, 2, 3 }; // CS1921
    }
}
```

## Compiler Error CS1954

The best overloaded method match 'method' for the collection initializer element cannot be used. Collection initializer 'Add' methods cannot have ref or out parameters.

For a collection class to be initialized by using a collection initializer, the class must have a public `Add` method that is not a `ref` or `out` parameter.

- If you can modify the source code of the collection class, provide an `Add` method that does not take a `ref` or `out` parameter.
- If you cannot modify the collection class, initialize it with the constructors it provides. You cannot use a collection initializer with it.

The following example produces CS1954 because the only available overload of the `Add` list in `MyList` has a `ref` parameter.

```csharp
// cs1954.cs
using System.Collections.Generic;
class MyList<T> : IEnumerable<T>
{
    List<T> _list;
    public void Add(ref T item)
    {
        _list.Add(item);
    }

    public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    {
        int index = 0;
        T current = _list[index];
        while (current != null)
        {
            yield return _list[index++];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class MyClass
{
    public string tree { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        MyList<MyClass> myList = new MyList<MyClass> { new MyClass { tree = "maple" } }; // CS1954
    }
}
```
