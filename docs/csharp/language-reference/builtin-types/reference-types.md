---
title: "Built-in reference types - C# reference"
description: "Learn about reference types that have C# keywords you can use to declare them."
ms.date: 06/25/2019
f1_keywords: 
  - "object_CSharpKeyword"
  - "object"
  - "delegate_CSharpKeyword"
  - "delegate"
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
# Built-in reference types (C# reference)

C# has a number of built-in reference types. They have keywords or operators that are synonyms for a type in the .NET library. 

## The object type

The `object` type is an alias for <xref:System.Object?displayProperty=nameWithType> in .NET. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from <xref:System.Object?displayProperty=nameWithType>. You can assign values of any type to variables of type `object`. Any `object` variable can be assigned to its default value using the literal `null`. When a variable of a value type is converted to object, it is said to be *boxed*. When a variable of type object is converted to a value type, it is said to be *unboxed*. For more information, see [Boxing and Unboxing](../../programming-guide/types/boxing-and-unboxing.md). 

## The string type

The `string` type represents a sequence of zero or more Unicode characters. `string` is an alias for <xref:System.String?displayProperty=nameWithType> in .NET.

Although `string` is a reference type, the [equality operators `==` and `!=`](../operators/equality-operators.md#string-equality) are defined to compare the values of `string` objects, not references. This makes testing for string equality more intuitive. For example:

```csharp-interactive
string a = "hello";
string b = "h";
// Append to contents of 'b'
b += "ello";
Console.WriteLine(a == b);
Console.WriteLine(object.ReferenceEquals(a, b));
```

This displays "True" and then "False" because the content of the strings are equivalent, but `a` and `b` do not refer to the same string instance.

The [+ operator](../operators/addition-operator.md#string-concatenation) concatenates strings:

```csharp
string a = "good " + "morning";
```

This creates a string object that contains "good morning".

Strings are *immutable*--the contents of a string object cannot be changed after the object is created, although the syntax makes it appear as if you can do this. For example, when you write this code, the compiler actually creates a new string object to hold the new sequence of characters, and that new object is assigned to `b`. The memory that had been allocated for `b` (when it contained the string "h") is then eligible for garbage collection.

```csharp
string b = "h";
b += "ello";
```

The `[]` [operator](../operators/member-access-operators.md#indexer-operator-) can be used for readonly access to individual characters of a `string`. Valid values start at `0` and must be less than the length of the `string`:

```csharp
string str = "test";
char x = str[2];  // x = 's';
```

In similar fashion, the `[]` operator can also be used for iterating over each character in a `string`:

```csharp-interactive
string str = "test";

for (int i = 0; i < str.Length; i++)
{
  Console.Write(str[i] + " ");
}
// Output: t e s t
``` 

String literals are of type `string` and can be written in two forms, quoted and `@`-quoted. Quoted string literals are enclosed in double quotation marks ("):

```csharp
"good morning"  // a string literal
```

String literals can contain any character literal. Escape sequences are included. The following example uses escape sequence `\\` for backslash, `\u0066` for the letter f, and `\n` for newline.

```csharp-interactive
string a = "\\\u0066\n F";
Console.WriteLine(a);
\\ Output:
\\ \f
\\  F
```

> [!NOTE]
> The escape code `\udddd` (where `dddd` is a four-digit number) represents the Unicode character U+`dddd`. Eight-digit Unicode escape codes are also recognized: `\Udddddddd`.

[Verbatim string literals](../tokens/verbatim.md) start with `@` and are also enclosed in double quotation marks. For example:

```csharp
@"good morning"  // a string literal
```

The advantage of verbatim strings is that escape sequences are *not* processed, which makes it easy to write, for example, a fully qualified Windows file name:

```csharp
@"c:\Docs\Source\a.txt"  // rather than "c:\\Docs\\Source\\a.txt"
```

To include a double quotation mark in an @-quoted string, double it:

```csharp
@"""Ahoy!"" cried the captain." // "Ahoy!" cried the captain.
```

## The delegate type

The declaration of a delegate type is similar to a method signature. It has a return value and any number of parameters of any type:

```csharp
public delegate void MessageDelegate(string message);
public delegate int AnotherDelegate(MyType m, long num);
```

In .NET, `System.Action` and `System.Func` types provide generic definitions for many common delegates. You likely don't need to define new custom delegate types. Instead, you can create instantiations of the provided generic types.

A `delegate` is a reference type that can be used to encapsulate a named or an anonymous method. Delegates are similar to function pointers in C++; however, delegates are type-safe and secure. For applications of delegates, see [Delegates](../../programming-guide/delegates/index.md) and [Generic Delegates](../../programming-guide/generics/generic-delegates.md). Delegates are the basis for [Events](../../programming-guide/events/index.md). A delegate can be instantiated by associating it either with a named or anonymous method.

The delegate must be instantiated with a method or lambda expression that has a compatible return type and input parameters. For more information on the degree of variance that is allowed in the method signature, see [Variance in Delegates](../../programming-guide/concepts/covariance-contravariance/using-variance-in-delegates.md). For use with anonymous methods, the delegate and the code to be associated with it are declared together. 

## The dynamic type

The `dynamic` type indicates that use of the variable and references to its members bypass compile-time type checking. Instead, these operations are resolved at run time. The `dynamic` type simplifies access to COM APIs such as the Office Automation APIs, to dynamic APIs such as IronPython libraries, and to the HTML Document Object Model (DOM).

Type `dynamic` behaves like type `object` in most circumstances. In particular, any non-null expression can be converted to the `dynamic` type. The `dynamic` type differs from `object` in that operations that contain expressions of type `dynamic` are not resolved or type checked by the compiler. The compiler packages together information about the operation, and that information is later used to evaluate the operation at run time. As part of the process, variables of type `dynamic` are compiled into variables of type `object`. Therefore, type `dynamic` exists only at compile time, not at run time.

The following example contrasts a variable of type `dynamic` to a variable of type `object`. To verify the type of each variable at compile time, place the mouse pointer over `dyn` or `obj` in the `WriteLine` statements. Copy the following code into an editor where IntelliSense is available. IntelliSense shows **dynamic** for `dyn` and **object** for `obj`.

[!code-csharp[csrefKeywordsTypes#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/dynamic1.cs#21)]

The <xref:System.Console.WriteLine%2A> statements display the run-time types of `dyn` and `obj`. At that point, both have the same type, integer. The following output is produced:

```console
System.Int32
System.Int32
```

To see the difference between `dyn` and `obj` at compile time, add the following two lines between the declarations and the `WriteLine` statements in the previous example.

```csharp
dyn = dyn + 3;
obj = obj + 3;
```

 A compiler error is reported for the attempted addition of an integer and an object in expression `obj + 3`. However, no error is reported for `dyn + 3`. The expression that contains `dyn` is not checked at compile time because the type of `dyn` is `dynamic`.

The following example uses `dynamic` in several declarations. The `Main` method also contrasts compile-time type checking with run-time type checking.

[!code-csharp[csrefKeywordsTypes#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/dynamic2.cs#25)]

### See also

- [C# Reference](../index.md)
- [C# Keywords](../keywords/index.md)
- [Events](../../programming-guide/events/index.md)
- [Using Type dynamic](../../programming-guide/types/using-type-dynamic.md)
- [Best Practices for Using Strings](../../../standard/base-types/best-practices-strings.md)
- [Basic String Operations](../../../standard/base-types/basic-string-operations.md)
- [Creating New Strings](../../../standard/base-types/creating-new.md)
- [Type-testing and cast operators](../operators/type-testing-and-cast.md)
- [How to: Safely cast using pattern matching and the as and is operators](../../how-to/safely-cast-using-pattern-matching-is-and-as-operators.md)
- [Walkthrough: creating and using dynamic objects](../../programming-guide/types/walkthrough-creating-and-using-dynamic-objects.md)
- <xref:System.Object?displayProperty=nameWithType>
- <xref:System.String?displayProperty=nameWithType>
- <xref:System.Dynamic.DynamicObject?displayProperty=nameWithType>
