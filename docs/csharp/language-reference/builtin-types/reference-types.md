---
title: "Builtin reference types - C# reference"
description: "Learn about reference types that have C# keywords you can use to declare them."
ms.date: 06/25/2019
f1_keywords: 
  - "object_CSharpKeyword"
  - "object"
  - "delegate_CSharpKeyword"
  - "delegate"
  - "CS0123"
  - "dynamic_CSharpKeyword"
  - "string"
  - "string_CSharpKeyword"
helpviewer_keywords: 
  - "object keyword [C#]"
  - "delegate keyword [C#]"
  - "function pointers [C#]"
  - "dynamic [C#]"
  - "dynamic keyword [C#]"
  - "strings [C#], reference"
  - "@ string literal"
  - "string literals [C#]"
  - "string keyword [C#]"
---

# Built-in reference types

A number of reference types are built-in in C#. They have keywords or operators that are synonyms for a type in the .NET library. 

## object (C# Reference)

The `object` type is an alias for <xref:System.Object> in .NET. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from <xref:System.Object>. You can assign values of any type to variables of type `object`. When a variable of a value type is converted to object, it is said to be *boxed*. When a variable of type object is converted to a value type, it is said to be *unboxed*. For more information, see [Boxing and Unboxing](../../../csharp/programming-guide/types/boxing-and-unboxing.md).

### Example

The following sample shows how variables of type `object` can accept values of any data type and how variables of type `object` can use methods on <xref:System.Object> from the .NET Framework.

[!code-csharp[csrefKeywordsTypes#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#16)]

### See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Reference Types](reference-types.md)
- [Value Types](value-types.md)

## delegate (C# Reference)

The declaration of a delegate type is similar to a method signature. It has a return value and any number of parameters of any type:

```csharp
public delegate void TestDelegate(string message);
public delegate int TestDelegate(MyType m, long num);
```

A `delegate` is a reference type that can be used to encapsulate a named or an anonymous method. Delegates are similar to function pointers in C++; however, delegates are type-safe and secure. For applications of delegates, see [Delegates](../../../csharp/programming-guide/delegates/index.md) and [Generic Delegates](../../../csharp/programming-guide/generics/generic-delegates.md).

### Remarks

Delegates are the basis for [Events](../../../csharp/programming-guide/events/index.md).

A delegate can be instantiated by associating it either with a named or anonymous method. For more information, see [Named Methods](../../../csharp/programming-guide/delegates/delegates-with-named-vs-anonymous-methods.md) and [Anonymous Methods](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md).

The delegate must be instantiated with a method or lambda expression that has a compatible return type and input parameters. For more information on the degree of variance that is allowed in the method signature, see [Variance in Delegates](../../programming-guide/concepts/covariance-contravariance/using-variance-in-delegates.md). For use with anonymous methods, the delegate and the code to be associated with it are declared together. Both ways of instantiating delegates are discussed in this section.

### Example

[!code-csharp[csrefKeywordsTypes#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#8)]

### See also

- [C# Reference](../../../csharp/language-reference/index.md)
- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [C# Keywords](../../../csharp/language-reference/keywords/index.md)
- [Reference Types](../../../csharp/language-reference/keywords/reference-types.md)
- [Delegates](../../../csharp/programming-guide/delegates/index.md)
- [Events](../../../csharp/programming-guide/events/index.md)
- [Delegates with Named vs. Anonymous Methods](../../../csharp/programming-guide/delegates/delegates-with-named-vs-anonymous-methods.md)
- [Anonymous Methods](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md)
- [Lambda Expressions](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md)

## dynamic (C# Reference)

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
- [Using Type dynamic](../../programming-guide/types/using-type-dynamic.md)
- [object](object.md)
- [is](../operators/type-testing-and-conversion-operators.md#is-operator)
- [as](../operators/type-testing-and-conversion-operators.md#as-operator)
- [typeof](../operators/type-testing-and-conversion-operators.md#typeof-operator)
- [How to: safely cast using pattern matching and the as and is operators](../../how-to/safely-cast-using-pattern-matching-is-and-as-operators.md)
- [Walkthrough: creating and using dynamic objects](../../programming-guide/types/walkthrough-creating-and-using-dynamic-objects.md)


## string (C# Reference)

The `string` type represents a sequence of zero or more Unicode characters. `string` is an alias for <xref:System.String> in .NET.

Although `string` is a reference type, the equality operators (`==` and `!=`) are defined to compare the values of `string` objects, not references. This makes testing for string equality more intuitive. For example:

```csharp
string a = "hello";
string b = "h";
// Append to contents of 'b'
b += "ello";
Console.WriteLine(a == b);
Console.WriteLine((object)a == (object)b);
```

This displays "True" and then "False" because the content of the strings are equivalent, but `a` and `b` do not refer to the same string instance.

The + operator concatenates strings:

```csharp
string a = "good " + "morning";
```

This creates a string object that contains "good morning".

Strings are *immutable*--the contents of a string object cannot be changed after the object is created, although the syntax makes it appear as if you can do this. For example, when you write this code, the compiler actually creates a new string object to hold the new sequence of characters, and that new object is assigned to b. The string "h" is then eligible for garbage collection.

```csharp
string b = "h";
b += "ello";
```

The [] operator can be used for readonly access to individual characters of a `string`:

```csharp
string str = "test";
char x = str[2];  // x = 's';
```

In similar fashion, the [] operator can also be used for iterating over each character in a `string`:

```csharp
string str = "test";

for (int i = 0; i < str.Length; i++)
{
  Console.Write(str[i] + " ");
}
// Output: t e s t
``` 

String literals are of type `string` and can be written in two forms, quoted and @-quoted. Quoted string literals are enclosed in double quotation marks ("):

```csharp
"good morning"  // a string literal
```

String literals can contain any character literal. Escape sequences are included. The following example uses escape sequence `\\` for backslash, `\u0066` for the letter f, and `\n` for newline.

```csharp
string a = "\\\u0066\n";
Console.WriteLine(a);
```

> [!NOTE]
> The escape code `\udddd` (where `dddd` is a four-digit number) represents the Unicode character U+`dddd`. Eight-digit Unicode escape codes are also recognized: `\Udddddddd`.

Verbatim string literals start with `@` and are also enclosed in double quotation marks. For example:

```csharp
@"good morning"  // a string literal
```

The advantage of verbatim strings is that escape sequences are *not* processed, which makes it easy to write, for example, a fully qualified file name:

```csharp
@"c:\Docs\Source\a.txt"  // rather than "c:\\Docs\\Source\\a.txt"
```

To include a double quotation mark in an @-quoted string, double it:

```csharp
@"""Ahoy!"" cried the captain." // "Ahoy!" cried the captain.
```

For other uses of the `@` special character, see [@ -- verbatim identifier](../tokens/verbatim.md).

For more information about strings in C#, see [Strings](../../programming-guide/strings/index.md).

### Example

[!code-csharp[csrefKeywordsTypes#17](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#17)]  

### See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Best Practices for Using Strings](../../../standard/base-types/best-practices-strings.md)
- [C# Keywords](index.md)
- [Reference Types](reference-types.md)
- [Value Types](value-types.md)
- [Basic String Operations](../../../standard/base-types/basic-string-operations.md)
- [Creating New Strings](../../../standard/base-types/creating-new.md)
- [Formatting Numeric Results Table](formatting-numeric-results-table.md)

## A new page for arrays that doesn't seem to be here.

