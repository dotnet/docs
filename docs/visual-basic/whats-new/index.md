---
description: "Learn more about: What's new for Visual Basic"
title: What's new
ms.date: 10/24/2018
f1_keywords:
  - "VB.StartPage.WhatsNew"
helpviewer_keywords:
  - "new features, Visual Basic"
  - "what's new [Visual Basic]"
  - "Visual Basic, what's new"
ms.assetid: d7e97396-7f42-4873-a81c-4ebcc4b6ca02
---
# What's new for Visual Basic

This topic lists key feature names for each version of Visual Basic, with detailed descriptions of the new and enhanced features in the latest versions of the language.

## Current version

Visual Basic 16.9 / Visual Studio 2019 version 16.9\
For new features, see [Visual Basic 16.9](#visual-basic-169).

You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download).

## Previous versions

Visual Basic 16.0 / Visual Studio 2019 version 16.0\
For new features, see [Visual Basic 16.0](#visual-basic-160).

Visual Basic 15.5 / Visual Studio 2017 version 15.5\
For new features, see [Visual Basic 15.5](#visual-basic-155).

Visual Basic 15.3 / Visual Studio 2017 version 15.3\
For new features, see [Visual Basic 15.3](#visual-basic-153).

Visual Basic 15 / Visual Studio 2017\
For new features, see [Visual Basic 2017](#visual-basic-15).

Visual Basic / Visual Studio 2015\
For new features, see [Visual Basic 14](#visual-basic-14).

Visual Basic / Visual Studio 2013\
Technology previews of the .NET Compiler Platform ("Roslyn")

Visual Basic / Visual Studio 2012\
`Async` and `await` keywords, iterators, caller info attributes

Visual Basic, Visual Studio 2010\
Auto-implemented properties, collection initializers, implicit line continuation, dynamic, generic co/contra variance, global namespace access

Visual Basic / Visual Studio 2008\
Language Integrated Query (LINQ), XML literals, local type inference, object initializers, anonymous types, extension methods, local `var` type inference, lambda expressions, `if` operator, partial methods, nullable value types

Visual Basic / Visual Studio 2005\
The `My` type and helper types (access to app, computer, files system, network)

Visual Basic / Visual Studio .NET 2003\
Bit-shift operators, loop variable declaration

Visual Basic / Visual Studio .NET 2002\
The first release of Visual Basic .NET

## Visual Basic 16.9

Visual Basic 16.9 enables consumption of init-only properties.

## Visual Basic 16.0

Visual Basic 16.0 focuses on supplying more of the features of the Visual Basic Runtime (microsoft.visualbasic.dll) to .NET Core and is the first version of Visual Basic focused on .NET Core. Many portions of the Visual Basic Runtime depend on WinForms and these will be added in a later version of Visual Basic.

**Comments allowed in more places within statements**

In Visual Basic 15.8 and earlier versions, comments are only allowed on blank lines, at the end of a statement, or in specific places within a statement where an implicit line continuation is allowed. Starting with Visual Basic 16.0, comments are also allowed after explicit line continuations and within a statement on a line beginning with a space followed by an underscore.

```vb
Public Sub Main()
    cmd.CommandText = ' Comment is allowed here without _
        "SELECT * FROM Titles JOIN Publishers " _ ' This is a comment
        & "ON Publishers.PubId = Titles.PubID " _
 _ ' This is a comment on a line without code
        & "WHERE Publishers.State = 'CA'"
End Sub
```

**Optimized floating-point to integer conversion**

In previous versions of Visual Basic, conversion of [Double](../language-reference/data-types/double-data-type.md) and [Single](../language-reference/data-types/single-data-type.md) values to integers offered relatively poor performance. Visual Basic 15.8 significantly enhances the performance of floating-point conversions to integers when you pass the value returned by any of the following methods to one of the [intrinsic Visual Basic integer conversion functions](../language-reference/functions/type-conversion-functions.md) (CByte, CShort, CInt, CLng, CSByte, CUShort, CUInt, CULng), or when the value returned by any of the following methods is implicitly cast to an integral type when [Option Strict](../language-reference/statements/option-strict-statement.md) is set to `Off`:

- <xref:Microsoft.VisualBasic.Conversion.Fix(System.Double)?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Conversion.Fix(System.Object)?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Conversion.Fix(System.Single)?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Conversion.Int(System.Double)?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Conversion.Int(System.Object)?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Conversion.Int(System.Single)?displayProperty=nameWithType>
- <xref:System.Math.Ceiling(System.Double)?displayProperty=nameWithType>
- <xref:System.Math.Floor(System.Double)?displayProperty=nameWithType>
- <xref:System.Math.Round(System.Double)?displayProperty=nameWithType>
- <xref:System.Math.Truncate(System.Double)?displayProperty=nameWithType>

This optimization allows code to run faster -- up to twice as fast for code that does a large number of conversions to integer types. The following example illustrates some simple method calls that are affected by this optimization:

```vb
Dim s As Single = 173.7619
Dim d As Double = s

Dim i1 As Integer = CInt(Fix(s))               ' Result: 173
Dim b1 As Byte = CByte(Int(d))                 ' Result: 173
Dim s1 AS Short = CShort(Math.Truncate(s))     ' Result: 173
Dim i2 As Integer = CInt(Math.Ceiling(d))      ' Result: 174
Dim i3 As Integer = CInt(Math.Round(s))        ' Result: 174
```

Note that this truncates rather than rounds floating-point values.

## Visual Basic 15.5

[Non-trailing named arguments](../programming-guide/language-features/procedures/passing-arguments-by-position-and-by-name.md#mixing-arguments-by-position-and-by-name)

In Visual Basic 15.3 and earlier versions, when a method call included arguments both by position and by name, positional arguments had to precede named arguments. Starting with Visual Basic 15.5, positional and named arguments can appear in any order as long as all arguments up to the last positional argument are in the correct position. This is particularly useful when named arguments are used to make code more readable.

For example, the following method call has two positional arguments between a named argument. The named argument makes it clear that the value 19 represents an age.

```vb
StudentInfo.Display("Mary", age:=19, #9/21/1998#)
```

[`Private Protected` member access modifier](../language-reference/modifiers/private-protected.md)

This new keyword combination defines a member that is accessible by all members in its containing class as well as by types derived from the containing class, but only if they are also found in the containing assembly. Because structures cannot be inherited, `Private Protected` can only be applied to the members of a class.

**Leading hex/binary/octal separator**

Visual Basic 2017 added support for the underscore character (`_`) as a digit separator. Starting with Visual Basic 15.5, you can use the underscore character as a leading separator between the prefix and hexadecimal, binary, or octal digits. The following example uses a leading digit separator to define 3,271,948,384 as a hexadecimal number:

```vb
Dim number As Integer = &H_C305_F860
```

To use the underscore character as a leading separator, you must add the following element to your Visual Basic project (\*.vbproj) file:

```xml
<PropertyGroup>
  <LangVersion>15.5</LangVersion>
</PropertyGroup>
```

## Visual Basic 15.3

[**Named tuple inference**](../programming-guide/language-features/data-types/tuples.md#inferred-tuple-element-names)

When you assign the value of tuple elements from variables, Visual Basic infers the name of tuple elements from the corresponding variable names; you do not have to explicitly name a tuple element. The following example uses inference to create a tuple with three named elements, `state`, `stateName`, and `capital`.

[!code-vb[Inferred tuple names](../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/named-tuples/Program.vb#2)]

**Additional compiler switches**

The Visual Basic command-line compiler now supports the [**-refout**](../reference/command-line-compiler/refout-compiler-option.md) and [**-refonly**](../reference/command-line-compiler/refonly-compiler-option.md) compiler options to control the output of reference assemblies. **-refout** defines the output directory of the reference assembly, and **-refonly** specifies that only a reference assembly is to be output by compilation.

## Visual Basic 15

[**Tuples**](../programming-guide/language-features/data-types/tuples.md)

Tuples are a lightweight data structure that most commonly is used to return multiple values from a single method call. Ordinarily, to return multiple values from a method, you have to do one of the following:

- Define a custom type (a `Class` or a `Structure`). This is a heavyweight solution.

- Define one or more `ByRef` parameters, in addition to returning a value from the method.

Visual Basic's support for tuples lets you quickly define a tuple, optionally assign semantic names to its values, and quickly retrieve its values. The following example wraps a call to the <xref:System.Int32.TryParse%2A> method and returns a tuple.

[!code-vb[Tuple](../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple-returns.vb#2)]

You can then call the method and handle the returned tuple with code like the following.

[!code-vb[ReturnTuple](../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple-returns.vb#3)]

**Binary literals and digit separators**

You can define a binary literal by using the prefix `&B` or `&b`. In addition, you can use the underscore character, `_`, as a digit separator to enhance readability. The following example uses both features to assign a `Byte` value and to display it as a decimal, hexadecimal, and binary number.

[!code-vb[Binary](../../../samples/snippets/visualbasic/getting-started/bin-example.vb#1)]

For more information, see the "Literal assignments" section of the [Byte](../language-reference/data-types/byte-data-type.md#literal-assignments), [Integer](../language-reference/data-types/integer-data-type.md#literal-assignments), [Long](../language-reference/data-types/long-data-type.md#literal-assignments), [Short](../language-reference/data-types/short-data-type.md#literal-assignments), [SByte](../language-reference/data-types/sbyte-data-type.md#literal-assignments), [UInteger](../language-reference/data-types/uinteger-data-type.md#literal-assignments), [ULong](../language-reference/data-types/ulong-data-type.md#literal-assignments), and [UShort](../language-reference/data-types/ushort-data-type.md#literal-assignments) data types.

[**Support for C# reference return values**](../programming-guide/language-features/procedures/ref-return-values.md)

Starting with C# 7.0, C# supports reference return values. That is, when the calling method receives a value returned by reference, it can change the value of the reference. Visual Basic does not allow you to author methods with reference return values, but it does allow you to consume and modify the reference return values.

For example, the following `Sentence` class written in C# includes a `FindNext` method that finds the next word in a sentence that begins with a specified substring. The string is returned as a reference return value, and a `Boolean` variable passed by reference to the method indicates whether the search was successful. This means that in addition to reading the returned value, the caller can also modify it, and that modification is reflected in the `Sentence` class.

[!code-csharp[Ref-Return](../../../samples/snippets/visualbasic/getting-started/ref-returns.cs)]

In its simplest form, you can modify the word found in the sentence by using code like the following. Note that you are not assigning a value to the method, but rather to the expression that the method returns, which is the reference return value.

[!code-vb[Ref-Return](../../../samples/snippets/visualbasic/getting-started/ref-return.vb#1)]

A problem with this code, though, is that if a match is not found, the method returns the first word. Since the example does not examine the value of the `Boolean` argument to determine whether a match is found, it modifies the first word if there is no match. The following example corrects this by replacing the first word with itself if there is no match.

[!code-vb[Ref-Return](../../../samples/snippets/visualbasic/getting-started/ref-return.vb#2)]

A better solution is to use a helper method to which the reference return value is passed by reference. The helper method can then modify the argument passed to it by reference. The following example does that.

[!code-vb[Ref-Return](../../../samples/snippets/visualbasic/getting-started/ref-return-helper.vb#1)]

For more information, see [Reference Return Values](../programming-guide/language-features/procedures/ref-return-values.md).

## Visual Basic 14

[NameOf](../language-reference/operators/nameof.md)

You can get the unqualified string name of a type or member for use in an error message without hard coding a string.  This allows your code to remain correct when refactoring.  This feature is also useful for hooking up model-view-controller MVC links and firing property changed events.

[String interpolation](../programming-guide/language-features/strings/interpolated-strings.md)

You can use string interpolation expressions to construct strings.  An interpolated string expression looks like a template string that contains expressions.  An interpolated string is easier to understand with respect to arguments than [Composite Formatting](../../standard/base-types/composite-formatting.md).

[Null-conditional member access and indexing](../language-reference/operators/null-conditional-operators.md)

You can test for null in a very light syntactic way before performing a member access (`?.`) or index (`?[]`) operation.  These operators help you write less code to handle null checks, especially for descending into data structures.  If the left operand or object reference is null, the operations returns null.

[Multi-line string literals](../programming-guide/language-features/strings/string-basics.md)

String literals can contain newline sequences.  You no longer need the old work around of using `<xml><![CDATA[...text with newlines...]]></xml>.Value`

**Comments**

You can put comments after implicit line continuations, inside initializer expressions, and among LINQ expression terms.

**Smarter fully-qualified name resolution**

Given code such as `Threading.Thread.Sleep(1000)`, Visual Basic used to look up the namespace "Threading", discover it was ambiguous between System.Threading and System.Windows.Threading, and then report an error.  Visual Basic now considers both possible namespaces together.  If you show the completion list, the Visual Studio editor lists members from both types in the completion list.

**Year-first date literals**

You can have date literals in yyyy-mm-dd format, `#2015-03-17 16:10 PM#`.

**Readonly interface properties**

You can implement readonly interface properties using a readwrite property. The interface guarantees minimum functionality, and it does not stop an implementing class from allowing the property to be set.

[TypeOf \<expr> IsNot \<type>](../language-reference/operators/typeof-operator.md)

For more readability of your code, you can now use `TypeOf` with `IsNot`.

[#Disable Warning \<ID> and #Enable Warning \<ID>](../language-reference/directives/disable-enable.md)

You can disable and enable specific warnings for regions within a source file.

**XML doc comment improvements**

When writing doc comments, you get smart editor and build support for validating parameter names, proper handling of `crefs` (generics, operators, etc.), colorizing, and refactoring.

[Partial module and interface definitions](../language-reference/modifiers/partial.md)

In addition to classes and structs, you can declare partial modules and interfaces.

[#Region directives inside method bodies](../language-reference/directives/region-directive.md)

You can put #Region…#End Region delimiters anywhere in a file, inside functions, and even spanning across function bodies.

[Overrides definitions are implicitly overloads](../language-reference/modifiers/overrides.md)

If you add the `Overrides` modifier to a definition, the compiler implicitly adds `Overloads` so that you can type less code in common cases.

**CObj allowed in attributes arguments**

The compiler used to give an error that CObj(…) was not a constant when used in attribute constructions.

**Declaring and consuming ambiguous methods from different interfaces**

Previously the following code yielded errors that prevented you from declaring `IMock` or from calling `GetDetails` (if these had been declared in C#):

```vb
Interface ICustomer
  Sub GetDetails(x As Integer)
End Interface

Interface ITime
  Sub GetDetails(x As String)
End Interface

Interface IMock : Inherits ICustomer, ITime
  Overloads Sub GetDetails(x As Char)
End Interface

Interface IMock2 : Inherits ICustomer, ITime
End Interface
```

Now the compiler will use normal overload resolution rules to choose the most appropriate `GetDetails` to call, and you can declare interface relationships in Visual Basic like those shown in the sample.

## See also

- [What's New in Visual Studio 2017](/visualstudio/ide/whats-new-visual-studio-2017)
- [What's New in Visual Studio 2019](/visualstudio/ide/whats-new-visual-studio-2019)
