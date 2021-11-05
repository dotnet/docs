---
title: Symbol and Operator Reference
description: Learn about the symbols and operators that are used in the F# programming language.
ms.date: 11/04/2021
fl_keywords:
 - "|>_FS"
---
# Symbol and operator reference

This article includes tables describing the symbols and operators that are used in F# and provides a brief description of each. Some symbols
and operators have two or more entries when used in multiple roles.

## Comment, compiler directive and attribute symbols

The following table describes symbols related to comments, compiler directives and attributes.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`(*...*)`||Delimits a comment that could span multiple lines.|
|`//`||Indicates the beginning of a single-line comment.|
|`///`|[XML Documentation](../xml-documentation.md)|Indicates an XML comment.|
|`#`|[Compiler Directives](../compiler-directives.md)|Prefixes a preprocessor or compiler directive.|
|`[<...>]`|[Attributes](../attributes.md)|Delimits an attribute.|

## String and identifier symbols

The following table describes symbols related to strings.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`"`|[Strings](../strings.md)|Delimits a text string.|
|`@"`|[Strings](../strings.md)|Starts a verbatim text string, which may include backslashes and other characters.|
|`"""`|[Strings](../strings.md)|Delimits a triple-quoted text string, which may include backslashes, double quotation marks and other characters.|
|`$"`|[Interpolated Strings](../interpolated-strings.md)|Starts an interpolated string.|
|`'`|[Literals](../literals.md)|Delimits a single-character literal.|
|<code>&#96;&#96;...&#96;&#96;</code>||Delimits an identifier that would otherwise not be a legal identifier, such as a language keyword.|
|`\`|[Strings](../strings.md)|Escapes the next character; used in character and string literals.|

## Arithmetic operators

The following table describes the arithmetic operators.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`+`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>When used as a binary operator, adds the left and right sides.</li><li>When used as a unary operator, indicates a positive quantity. (Formally, it produces the same value with the sign unchanged.)</li></ul>|
|`-`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>When used as a binary operator, subtracts the right side from the left side.</li><li>When used as a unary operator, performs a negation operation.</li></ul>|
|`*`|[Arithmetic Operators](arithmetic-operators.md)<br /><br />[Tuples](../tuples.md)<br /><br />[Units of Measure](../units-of-measure.md)|<ul><li>When used as a binary operator, multiplies the left and right sides.</li><li>In types, indicates pairing in a tuple.</li><li>Used in units of measure types.</li></ul>|
|`/`|[Arithmetic Operators](arithmetic-operators.md)<br /><br />[Units of Measure](../units-of-measure.md)|<ul><li>Divides the left side (numerator) by the right side (denominator).</li><li>Used in units of measure types.</li></ul>|
|`%`|[Arithmetic Operators](arithmetic-operators.md)|Computes the integer remainder.|
|`**`|[Arithmetic Operators](arithmetic-operators.md)|Computes the exponentiation operation (`x ** y` means `x` to the power of `y`).|

## Comparison operators

The following table describes the comparison operators.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`<`|[Arithmetic Operators](arithmetic-operators.md)|Computes the less-than operation.|
|`<>`|[Arithmetic Operators](arithmetic-operators.md)|Returns `true` if the left side is not equal to the right side; otherwise, returns false.|
|`<=`|[Arithmetic Operators](arithmetic-operators.md)|Returns `true` if the left side is less than or equal to the right side; otherwise, returns `false`.|
|`=`|[Arithmetic Operators](arithmetic-operators.md)|Returns `true` if the left side is equal to the right side; otherwise, returns `false`.|
|`>`|[Arithmetic Operators](arithmetic-operators.md)|Returns `true` if the left side is greater than the right side; otherwise, returns `false`.|
|`>=`|[Arithmetic Operators](arithmetic-operators.md)|Returns `true` if the left side is greater than or equal to the right side; otherwise, returns `false`.|

## Boolean operators

The following table describes the arithmetic and boolean operators symbols.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`&&`|[Boolean Operators](boolean-operators.md)|Computes the Boolean AND operation.|
|<code>&#124;&#124;</code>|[Boolean Operators](boolean-operators.md)|Computes the Boolean OR operation.|

## Bitwise operators

The following table describes bitwise operators.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`&&&`|[Bitwise Operators](bitwise-operators.md)|Computes the bitwise AND operation.|
|`<<<`|[Bitwise Operators](bitwise-operators.md)|Shifts bits in the quantity on the left side to the left by the number of bits specified on the right side.|
|`>>>`|[Bitwise Operators](bitwise-operators.md)|Shifts bits in the quantity on the left side to the right by the number of places specified on the right side.|
|`^^^`|[Bitwise Operators](bitwise-operators.md)|Computes the bitwise exclusive OR operation.|
|<code>&#124;&#124;&#124;</code>|[Bitwise Operators](bitwise-operators.md)|Computes the bitwise OR operation.|
|`~~~`|[Bitwise Operators](bitwise-operators.md)|Computes the bitwise NOT operation.|

## Function symbols and operators

The following table describes the operators and symbols related to functions.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`->`|[Functions](../functions/index.md)|In function expressions, separates the input pattern from the output expression.|
|<code>&#124;></code>|[Functions](../functions/index.md#pipelines)|Passes the result of the left side to the function on the right side (forward pipe operator).|
|<code>&#124;&#124;></code>|[&#40; &#124;&#124;&#62; &#41;&#60;'T1,'T2,'U&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20%7C%7C%3E%20))|Passes the tuple of two arguments on the left side to the function on the right side.|
|<code>&#124;&#124;&#124;></code>|[&#40; &#124;&#124;&#124;&#62; &#41;&#60;'T1,'T2,'T3,'U&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20%7C%7C%7C%3E%20))|Passes the tuple of three arguments on the left side to the function on the right side.|
|`>>`|[Functions](../functions/index.md)|Composes two functions (forward composition operator).|
|`<<`|[Functions](../functions/index.md)|Composes two functions in reverse order; the second one is executed first (backward composition operator).|
|<code>&lt;&#124;</code>|[Functions](../functions/index.md)|Passes the result of the expression on the right side to the function on left side (backward pipe operator).|
|<code>&lt;&#124;&#124;</code>|[&#40; &#60;&#124;&#124; &#41;&#60;'T1,'T2,'U&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20%3C%7C%7C%20))|Passes the tuple of two arguments on the right side to the function on left side.|
|<code>&lt;&#124;&#124;&#124;</code>|[&#40; &#60;&#124;&#124;&#124; &#41;&#60;'T1,'T2,'T3,'U&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20%3C%7C%7C%7C%20))|Passes the tuple of three arguments on the right side to the function on left side.|

## Type symbols and operators

The following table describes symbols related to type annotation and type tests.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`->`|[Functions](../functions/index.md)|In function types, delimits arguments and return values, also yields a result in sequence expressions.|
|`:`|[Functions](../functions/index.md)|In a type annotation, separates a parameter or member name from its type.|
|`:>`|[Casting and Conversions](../casting-and-conversions.md)|Converts a type to type that is higher in the hierarchy.|
|`:?`|[Match Expressions](../match-expressions.md)|Returns `true` if the value matches the specified type (including if it is a subtype); otherwise, returns `false` (type test operator).|
|`:?>`|[Casting and Conversions](../casting-and-conversions.md)|Converts a type to a type that is lower in the hierarchy.|
|`#`|[Flexible Types](../flexible-types.md)|When used with a type, indicates a *flexible type*, which refers to a type or any one of its derived types.|
|`'`|[Automatic Generalization](../generics/automatic-generalization.md)|Indicates a generic type parameter.|
|`<...>`|[Automatic Generalization](../generics/automatic-generalization.md)|Delimits type parameters.|
|`^`|[Statically Resolved Type Parameters](../generics/statically-resolved-type-parameters.md)<br /><br />[Strings](../strings.md)|<ul><li>Specifies type parameters that must be resolved at compile time, not at run time.</li><li>Concatenates strings.</li></ul>|

## Symbols used in member lookup and slice expressions

The following table describes additional symbols used in member lookup and slice expressions.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`.`|[Members](../members/index.md)|Accesses a member, and separates individual names in a fully qualified name.|
|`[...]` or `.[...]`|[Arrays](../arrays.md)<br /><br />[Indexed Properties](../members/indexed-properties.md)<br /><br />[Slice Expressions](../slices.md)|Indexes into an array, string or collection, or takes a slice of a collection.|

## Symbols used in tuple, list, array, unit expressions and patterns

The following table describes symbols related to tuples, lists, unit values and arrays.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`( )`|[Unit Type](../unit-type.md)|Represents the single value of the unit type.|
|`,`|[Tuples](../tuples.md)|Separates the elements of a tuple, or type parameters.|
|`::`|[Lists](../lists.md)<br /><br />[Match Expressions](../match-expressions.md)|<ul><li>Creates a list. The element on the left side is prepended to the list on the right side.</li><li>Used in pattern matching to separate the parts of a list.</li></ul>|
|`@`|[Lists](../lists.md)|Concatenates two lists.|
|`[...]`|[Lists](../lists.md)|Delimits the elements of a list.|
|<code>[&#124;...&#124;]</code>|[Arrays](../arrays.md)|Delimits the elements of an array.|

## Symbols used in imperative expressions

The following table describes additional symbols used in expressions.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`<-`|[Values](../values/index.md)|Assigns a value to a variable.|
|`;`|[Verbose Syntax](../verbose-syntax.md)<br /><br />|Separates expressions (used mostly in verbose syntax). Also separates elements of a list or fields of a record.|

## Additional symbols used in sequences and computation expressions

The following table describes additional symbols used in [Sequences](../sequences.md) and [Computation Expressions](../computation-expressions.md).

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`->`|[Sequences](../sequences.md)|Yields an expression (in sequence expressions); equivalent to the `do yield` keywords.|
|`!`|[Computation Expressions](../computation-expressions.md)|After a keyword, indicates a modified version of the keyword's behavior as controlled by a computation expression.|

## Additional symbols used in match patterns

The following table describes symbols related to pattern matching.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`->`|[Match Expressions](../match-expressions.md)|Used in match expressions.|
|`&`|[Match Expressions](../match-expressions.md)|<ul><li>Computes the address of a mutable value, for use when interoperating with other languages.</li><li>Used in AND patterns.</li></ul>|
|`_`|[Match Expressions](../match-expressions.md)<br /><br />[Generics](../generics/index.md)|<ul><li>Indicates a wildcard pattern.</li><li>Specifies an anonymous generic parameter.</li></ul>|
|<code>&#124;</code>|[Match Expressions](../match-expressions.md)|Delimits individual match cases, individual discriminated union cases, and enumeration values.|

## Additional symbols used in declarations

The following table describes symbols related to declarations.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|<code>(&#124;...&#124;)</code>|[Active Patterns](../active-patterns.md)|Delimits an active pattern name. Also called *banana clips*.|
|`?`|[Parameters and Arguments](../parameters-and-arguments.md)|Specifies an optional argument.|
|`~~`|[Operator Overloading](../operator-overloading.md)|Used to declare an overload for the unary negation operator.|
|`~-`|[Operator Overloading](../operator-overloading.md)|Used to declare an overload for the unary minus operator.|
|`~+`|[Operator Overloading](../operator-overloading.md)|Used to declare an overload for the unary plus operator.|

## Additional symbols used in quotations

The following table describes symbols related to [Code Quotations](../code-quotations.md).

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`<@...@>`|[Code Quotations](../code-quotations.md)|Delimits a typed code quotation.|
|`<@@...@@>`|[Code Quotations](../code-quotations.md)|Delimits an untyped code quotation.|
|`%`|[Code Quotations](../code-quotations.md)|Used for splicing expressions into typed code quotations.|
|`%%`|[Code Quotations](../code-quotations.md)|Used for splicing expressions into untyped code quotations.|

## Dynamic lookup operators

The following table describes additional symbols used in dynamic lookup expressions. They are not generally used in routine F# programming
and no implementations of these operator are provided in the F# core library.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`?`||Used as an operator for dynamic method and property calls.|
|`? ... <- ...`||Used as an operator for setting dynamic properties.|

## Nullable operators in queries

[Nullable Operators](nullable-operators.md) are defined for use in [Query Expressions](../query-expressions.md). The following table shows these operators.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`%?`|[Nullable Operators](nullable-operators.md)|Computes the integer remainder, when the right side is a nullable type.|
|`*?`|[Nullable Operators](nullable-operators.md)|Multiplies the left and right sides, when the right side is a nullable type.|
|`+?`|[Nullable Operators](nullable-operators.md)|Adds the left and right sides, when the right side is a nullable type.|
|`-?`|[Nullable Operators](nullable-operators.md)|Subtracts the right side from the left side, when the right side is a nullable type.|
|`/?`|[Nullable Operators](nullable-operators.md)|Divides the left side by the right side, when the right side is a nullable type.|
|`<?`|[Nullable Operators](nullable-operators.md)|Computes the less than operation, when the right side is a nullable type.|
|`<>?`|[Nullable Operators](nullable-operators.md)|Computes the "not equal" operation when the right side is a nullable type.|
|`<=?`|[Nullable Operators](nullable-operators.md)|Computes the "less than or equal to" operation when the right side is a nullable type.|
|`=?`|[Nullable Operators](nullable-operators.md)|Computes the "equal" operation when the right side is a nullable type.|
|`>?`|[Nullable Operators](nullable-operators.md)|Computes the "greater than" operation when the right side is a nullable type.|
|`>=?`|[Nullable Operators](nullable-operators.md)|Computes the "greater than or equal" operation when the right side is a nullable type.|
|`?>=`, `?>`, `?<=`, `?<`, `?=`, `?<>`, `?+`, `?-`, `?*`, `?/`|[Nullable Operators](nullable-operators.md)|Equivalent to the corresponding operators without the ? prefix, where a nullable type is on the left.|
|`>=?`, `>?`, `<=?`, `<?`, `=?`, `<>?`, `+?`, `-?`, `*?`, `/?`|[Nullable Operators](nullable-operators.md)|Equivalent to the corresponding operators without the ? suffix, where a nullable type is on the right.|
|`?>=?`, `?>?`, `?<=?`, `?<?`, `?=?`, `?<>?`, `?+?`, `?-?`, `?*?`, `?/?`|[Nullable Operators](nullable-operators.md)|Equivalent to the corresponding operators without the surrounding question marks, where both sides are nullable types.|

## Reference cell operators (deprecated)

The following table describes symbols related to [Reference Cells](../reference-cells.md). The use of these operators generates advisory messages as of F# 6. For more information, see [Reference cell operation advisory messages](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1111-refcell-op-information-messages.md#summary).

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`!`|[Reference Cells](../reference-cells.md)|Dereferences a reference cell.|
|`:=`|[Reference Cells](../reference-cells.md)|Assigns a value to a reference cell.|

## Operator precedence

The following table shows the order of precedence of operators and other expression keywords in F#, in order from lowest precedence to the highest precedence. Also listed is the associativity, if applicable.

|Operator|Associativity|
|--------|-------------|
|`as`|Right|
|`when`|Right|
|<code>&#124;</code> (pipe)|Left|
|`;`|Right|
|`let`|Nonassociative|
|`function`, `fun`, `match`, `try`|Nonassociative|
|`if`|Nonassociative|
|`not`|Right|
|`->`|Right|
|`:=`|Right|
|`,`|Nonassociative|
|`or`, <code>&#124;&#124;</code>|Left|
|`&`, `&&`|Left|
|`:>`, `:?>`|Right|
|`<`*op*, `>`*op*, `=`, <code>&#124;</code>*op*, `&`*op*, `&`, `$`<br /><br />(including `<<<`, `>>>`, <code>&#124;&#124;&#124;</code>, `&&&`)|Left|
|`^`*op*<br /><br />(including `^^^`)|Right|
|`::`|Right|
|`:?`|Not associative|
|`-`*op*, `+`*op*|Applies to infix uses of these symbols|
|`*`*op*, `/`*op*, `%`*op*|Left|
|`**`*op*|Right|
|`f x` (function application)<br /><br />(including `lazy x`, `assert x`)|Left|
|<code>&#124;</code> (pattern match)|Right|
|prefix operators (`+`*op*, `-`*op*, `%`, `%%`, `&`, `&&`, `!`*op*, `~`*op*)|Left|
|`.`|Left|
|`f(x)`|Left|
|`f<`*types*`>`|Left|

F# supports custom operator overloading. This means that you can define your own operators. In the previous table, *op* can be any valid (possibly empty) sequence of operator characters, either built-in or user-defined. Thus, you can use this table to determine what sequence of characters to use for a custom operator to achieve the desired level of precedence. Leading `.` characters are ignored when the compiler determines precedence.

## See also

- [F# Language Reference](../index.md)
- [Operator Overloading](../operator-overloading.md)
