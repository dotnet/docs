---
title: Symbol and Operator Reference
description: Learn about the symbols and operators that are used in the F# programming language.
ms.date: 07/26/2021
fl_keywords:
 - "|>_FS"
---
# Symbol and operator reference

This article includes tables describing the symbols and operators that are used in the F# language. Some symbols
and operators have two or more entries when used in multiple roles.

## Comment, compiler directive and attribute symbols

The following table describes symbols related to comments, compiler directives and attributes and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`(*...*)`||<ul><li>Delimits a comment that could span multiple lines.<br /></li></ul>|
|`//`||<ul><li>Indicates the beginning of a single-line comment.<br /></li></ul>|
|`///`|[XML Documentation](../xml-documentation.md)|<ul><li>Indicates an XML comment.<br /></li></ul>|
|`#`|[Compiler Directives](../compiler-directives.md)|<ul><li>Prefixes a preprocessor or compiler directive, such as `#light`.<br /></li></ul>|
|`[<...>]`|[Attributes](../attributes.md)|<ul><li>Delimits an attribute.<br /></li></ul>|

## String and identifier symbols

The following table describes symbols related to strings and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`"`|[Strings](../strings.md)|<ul><li>Delimits a text string.<br /></li></ul>|
|`@"`|[Strings](../strings.md)|Starts a verbatim text string, which may include backslashes and other characters.|
|`"""`|[Strings](../strings.md)|Delimits a triple-quoted text string, which may include backslashes, double quotation marks and other characters.|
|`$"`|[Interpolated Strings](../interpolated-strings.md)|Starts an interpolated string.|
|`'`|[Literals](../literals.md)|<ul><li>Delimits a single-character literal.<br /></li></ul>|
|<code>&#96;&#96;...&#96;&#96;</code>||<ul><li>Delimits an identifier that would otherwise not be a legal identifier, such as a language keyword.<br /></li></ul>|
|`\`|[Strings](../strings.md)|<ul><li>Escapes the next character; used in character and string literals.<br /></li></ul>|

## Arithmetic operators

The following table describes the arithmetic operators in the F# language and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`+`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>When used as a binary operator, adds the left and right sides.<br /></li><li>When used as a unary operator, indicates a positive quantity. (Formally, it produces the same value with the sign unchanged.)<br /></li></ul>|
|`-`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>When used as a binary operator, subtracts the right side from the left side.<br /></li><li>When used as a unary operator, performs a negation operation.<br /></li></ul>|
|`*`|[Arithmetic Operators](arithmetic-operators.md)<br /><br />[Tuples](../tuples.md)<br /><br />[Units of Measure](../units-of-measure.md)|<ul><li>When used as a binary operator, multiplies the left and right sides.<br /></li><li>In types, indicates pairing in a tuple.<br /></li><li>Used in units of measure types.<br /></li></ul>|
|`/`|[Arithmetic Operators](arithmetic-operators.md)<br /><br />[Units of Measure](../units-of-measure.md)|<ul><li>Divides the left side (numerator) by the right side (denominator).<br /></li><li>Used in units of measure types.<br /></li></ul>|
|`%`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>Computes the integer remainder.<br /></li></ul>|
|`**`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>Computes the exponentiation operation (`x ** y` means `x` to the power of `y`).<br /></li></ul>|

## Comparison operators

The following table describes the comparison operators in the F# language and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`<`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>Computes the less-than operation.<br /></li></ul>|
|`<>`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>Returns `true` if the left side is not equal to the right side; otherwise, returns false.<br /></li></ul>|
|`<=`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>Returns `true` if the left side is less than or equal to the right side; otherwise, returns `false`.<br /></li></ul>|
|`=`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>Returns `true` if the left side is equal to the right side; otherwise, returns `false`.<br /></li></ul>|
|`>`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>Returns `true` if the left side is greater than the right side; otherwise, returns `false`.<br /></li></ul>|
|`>=`|[Arithmetic Operators](arithmetic-operators.md)|<ul><li>Returns `true` if the left side is greater than or equal to the right side; otherwise, returns `false`.<br /></li></ul>|

## Boolean operators

The following table describes the arithmetic and boolean operators symbols used in the F# language and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`&&`|[Boolean Operators](boolean-operators.md)|<ul><li>Computes the Boolean AND operation.<br /></li></ul>|
|<code>&#124;&#124;</code>|[Boolean Operators](boolean-operators.md)|<ul><li>Computes the Boolean OR operation.<br /></li></ul>|

## Bitwise operators

The following table describes bitwise operators used in the F# language and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`&&&`|[Bitwise Operators](bitwise-operators.md)|<ul><li>Computes the bitwise AND operation.<br /></li></ul>|
|`<<<`|[Bitwise Operators](bitwise-operators.md)|<ul><li>Shifts bits in the quantity on the left side to the left by the number of bits specified on the right side.<br /></li></ul>|
|`>>>`|[Bitwise Operators](bitwise-operators.md)|<ul><li>Shifts bits in the quantity on the left side to the right by the number of places specified on the right side.<br /></li></ul>|
|`^^^`|[Bitwise Operators](bitwise-operators.md)|<ul><li>Computes the bitwise exclusive OR operation.<br /></li></ul>|
|<code>&#124;&#124;&#124;</code>|[Bitwise Operators](bitwise-operators.md)|<ul><li>Computes the bitwise OR operation.<br /></li></ul>|
|`~~~`|[Bitwise Operators](bitwise-operators.md)|<ul><li>Computes the bitwise NOT operation.<br /></li></ul>|

## Function symbols and operators

The following table describes the operators and symbols related to functions used in the F# language and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`->`|[Functions](../functions/index.md)|<ul><li>In function expressions, separates the input pattern from the output expression.<br /></ul>|
|<code>&#124;></code>|[Functions](../functions/index.md)|<ul><li>Passes the result of the left side to the function on the right side (forward pipe operator).<br /></li></ul>|
|<code>&#124;&#124;></code>|[&#40; &#124;&#124;&#62; &#41;&#60;'T1,'T2,'U&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20%7C%7C%3E%20))|<ul><li>Passes the tuple of two arguments on the left side to the function on the right side.<br /></li></ul>|
|<code>&#124;&#124;&#124;></code>|[&#40; &#124;&#124;&#124;&#62; &#41;&#60;'T1,'T2,'T3,'U&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20%7C%7C%7C%3E%20))|<ul><li>Passes the tuple of three arguments on the left side to the function on the right side.<br /></li></ul>|
|`>>`|[Functions](../functions/index.md)|<ul><li>Composes two functions (forward composition operator).<br /></li></ul>|
|`<<`|[Functions](../functions/index.md)|<ul><li>Composes two functions in reverse order; the second one is executed first (backward composition operator).<br /></li></ul>|
|<code>&lt;&#124;</code>|[Functions](../functions/index.md)|<ul><li>Passes the result of the expression on the right side to the function on left side (backward pipe operator).<br /></li></ul>|
|<code>&lt;&#124;&#124;</code>|[&#40; &#60;&#124;&#124; &#41;&#60;'T1,'T2,'U&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20%3C%7C%7C%20))|<ul><li>Passes the tuple of two arguments on the right side to the function on left side.<br /></li></ul>|
|<code>&lt;&#124;&#124;&#124;</code>|[&#40; &#60;&#124;&#124;&#124; &#41;&#60;'T1,'T2,'T3,'U&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20%3C%7C%7C%7C%20))|<ul><li>Passes the tuple of three arguments on the right side to the function on left side.<br /></li></ul>|

## Type symbols and operators

The following table describes symbols related to type annotation and type tests used in the F# language and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`->`|[Functions](../functions/index.md)|<ul><li>In function types, delimits arguments and return values, also yields a result in sequence expressions.<br /></li></ul>|
|`:`|[Functions](../functions/index.md)|<ul><li>In a type annotation, separates a parameter or member name from its type.<br /></li></ul>|
|`:>`|[Casting and Conversions](../casting-and-conversions.md)|<ul><li>Converts a type to type that is higher in the hierarchy.<br /></li></ul>|
|`:?`|[Match Expressions](../match-expressions.md)|<ul><li>Returns `true` if the value matches the specified type (including if it is a subtype); otherwise, returns `false` (type test operator).<br /></li></ul>|
|`:?>`|[Casting and Conversions](../casting-and-conversions.md)|<ul><li>Converts a type to a type that is lower in the hierarchy.<br /></li></ul>|
|`#`|[Flexible Types](../flexible-types.md)|<ul><li>When used with a type, indicates a *flexible type*, which refers to a type or any one of its derived types.<br /></li></ul>|
|`'`|[Automatic Generalization](../generics/automatic-generalization.md)|<ul><li>Indicates a generic type parameter.<br /></li></ul>|
|`<...>`|[Automatic Generalization](../generics/automatic-generalization.md)|<ul><li>Delimits type parameters.<br /></li></ul>|
|`^`|[Statically Resolved Type Parameters](../generics/statically-resolved-type-parameters.md)<br /><br />[Strings](../strings.md)|<ul><li>Specifies type parameters that must be resolved at compile time, not at runtime.<br /></li><li>Concatenates strings.<br /></li></ul>|

## Tuple, list, array, unit value symbols and operators

The following table describes symbols related to tuples, lists, unit values and arrays and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`( )`|[Unit Type](../unit-type.md)|<ul><li>Represents the single value of the unit type.<br /></li></ul>|
|`(...)`|[Tuples](../tuples.md)<br /><br />[Operator Overloading](../operator-overloading.md)|<ul><li>Indicates the order in which expressions are evaluated.<br /></li><li>Delimits a tuple.<br /></li><li>Used in operator definitions.<br /></li></ul>|
|<code>(&#124;...&#124;)</code>|[Active Patterns](../active-patterns.md)|<ul><li>Delimits an active pattern name. Also called *banana clips*.<br /></li></ul>|
|`,`|[Tuples](../tuples.md)|<ul><li>Separates the elements of a tuple, or type parameters.<br /></li></ul>|
|`::`|[Lists](../lists.md)<br /><br />[Match Expressions](../match-expressions.md)|<ul><li>Creates a list. The element on the left side is prepended to the list on the right side.<br /></li><li>Used in pattern matching to separate the parts of a list.<br /></li></ul>|
|`@`|[Lists](../lists.md)<br /><br />[Strings](../strings.md)|<ul><li>Concatenates two lists.<br /></li><li>When placed before a string literal, indicates that the string is to be interpreted verbatim, with no interpretation of escape characters.<br /></li></ul>|
|`[...]`|[Lists](../lists.md)|<ul><li>Delimits the elements of a list.<br /></li></ul>|
|<code>[&#124;...&#124;]</code>|[Arrays](../arrays.md)|<ul><li>Delimits the elements of an array.<br /></li></ul>|

## Reference cell operators

The following table describes symbols related to reference cells and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`!`|[Reference Cells](../reference-cells.md)|<ul><li>Dereferences a reference cell.<br /></li></ul>|
|`:=`|[Reference Cells](../reference-cells.md)|<ul><li>Assigns a value to a reference cell.<br /></li></ul>|

## Symbols used in quotations

The following table describes symbols related to quotations.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`<@...@>`|[Code Quotations](../code-quotations.md)|<ul><li>Delimits a typed code quotation.<br /></li></ul>|
|`<@@...@@>`|[Code Quotations](../code-quotations.md)|<ul><li>Delimits an untyped code quotation.<br /></li></ul>|
|`%`|[Code Quotations](../code-quotations.md)|<ul><li>Used for splicing expressions into typed code quotations.<br /></li></ul>|
|`%%`|[Code Quotations](../code-quotations.md)|<ul><li>Used for splicing expressions into untyped code quotations.<br /></li></ul>|

## Additional symbols used in expressions

The following table describes additional symbols used in expressions

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`.`|[Members](../members/index.md)<br /><br />[Primitive Types](../basic-types.md)|<ul><li>Accesses a member, and separates individual names in a fully qualified name.<br /></li><li>Specifies a decimal point in floating point numbers.<br /></li></ul>|
|`.[...]`|[Arrays](../arrays.md)|<ul><li>Accesses an array element.<br /></li></ul>|
|`<-`|[Values](../values/index.md)|<ul><li>Assigns a value to a variable.<br /></li></ul>|
|`?`||<ul><li>Used as an operator for dynamic method and property calls. You must provide your own implementation.<br /></li></ul>|
|`? ... <- ...`||<ul><li>Used as an operator for setting dynamic properties. You must provide your own implementation.<br /></li></ul>|
|`;`|[Verbose Syntax](../verbose-syntax.md)<br /><br />[Lists](../lists.md)<br /><br />[Records](../records.md)|<ul><li>Separates expressions (used mostly in verbose syntax).<br /></li><li>Separates elements of a list.<br /></li><li>Separates fields of a record.<br /></li></ul>|
|`->`|[Sequences](../sequences.md)|<ul><li>Yields an expression (in sequence expressions); equivalent to the `do yield` keywords.<br /></li></ul>|
|`!`|[Computation Expressions](../computation-expressions.md)|<ul><li>After a keyword, indicates a modified version of the keyword's behavior as controlled by a workflow.<br /></li></ul>|

## Additional symbols used in match patterns

The following table describes symbols related to pattern matching and provides a brief description of each.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`->`|[Match Expressions](../match-expressions.md)|<ul><li>Used in match expressions<br /></li></ul>|
|`&`|[Match Expressions](../match-expressions.md)|<ul><li>Computes the address of a mutable value, for use when interoperating with other languages.<br /></li><li>Used in AND patterns.<br /></li></ul>|
|`_`|[Match Expressions](../match-expressions.md)<br /><br />[Generics](../generics/index.md)|<ul><li>Indicates a wildcard pattern.<br /></li><li>Specifies an anonymous generic parameter.<br /></li></ul>|
|<code>&#124;</code>|[Match Expressions](../match-expressions.md)|<ul><li>Delimits individual match cases, individual discriminated union cases, and enumeration values.<br /></li></ul>|

## Additional symbols used in declarations

The following table describes symbols related to declarations.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`?`|[Parameters and Arguments](../parameters-and-arguments.md)|<ul><li>Specifies an optional argument.<br /></li></ul>|
|`~~`|[Operator Overloading](../operator-overloading.md)|<ul><li>Used to declare an overload for the unary negation operator.<br /></li></ul>|
|`~-`|[Operator Overloading](../operator-overloading.md)|<ul><li>Used to declare an overload for the unary minus operator.<br /></li></ul>|
|`~+`|[Operator Overloading](../operator-overloading.md)|<ul><li>Used to declare an overload for the unary plus operator.<br /></li></ul>|

## Nullable operators

[Nullable Operators](nullable-operators.md) are defined for use in F# queries. The following table shows these operators.

|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|`%?`|[Nullable Operators](nullable-operators.md)|<ul><li>Computes the integer remainder, when the right side is a nullable type.<br /></li></ul>|
|`*?`|[Nullable Operators](nullable-operators.md)|<ul><li>Multiplies the left and right sides, when the right side is a nullable type.<br /></li></ul>|
|`+?`|[Nullable Operators](nullable-operators.md)|<ul><li>Adds the left and right sides, when the right side is a nullable type.<br /></li></ul>|
|`-?`|[Nullable Operators](nullable-operators.md)|<ul><li>Subtracts the right side from the left side, when the right side is a nullable type.<br /></li></ul>|
|`/?`|[Nullable Operators](nullable-operators.md)|<ul><li>Divides the left side by the right side, when the right side is a nullable type.<br /></li></ul>|
|`<?`|[Nullable Operators](nullable-operators.md)|Computes the less than operation, when the right side is a nullable type.|
|`<>?`|[Nullable Operators](nullable-operators.md)|<ul><li>Computes the "not equal" operation when the right side is a nullable type.<br /></li></ul>|
|`<=?`|[Nullable Operators](nullable-operators.md)|<ul><li>Computes the "less than or equal to" operation when the right side is a nullable type.<br /></li></ul>|
|`=?`|[Nullable Operators](nullable-operators.md)|<ul><li>Computes the "equal" operation when the right side is a nullable type.<br /></li></ul>|
|`>?`|[Nullable Operators](nullable-operators.md)|<ul><li>Computes the "greater than" operation when the right side is a nullable type.<br /></li></ul>|
|`>=?`|[Nullable Operators](nullable-operators.md)|<ul><li>Computes the "greater than or equal" operation when the right side is a nullable type.<br /></li></ul>|
|`?>=`, `?>`, `?<=`, `?<`, `?=`, `?<>`, `?+`, `?-`, `?*`, `?/`|[Nullable Operators](nullable-operators.md)|<ul><li>Equivalent to the corresponding operators without the ? prefix, where a nullable type is on the left.<br /></li></ul>|
|`>=?`, `>?`, `<=?`, `<?`, `=?`, `<>?`, `+?`, `-?`, `*?`, `/?`|[Nullable Operators](nullable-operators.md)|<ul><li>Equivalent to the corresponding operators without the ? suffix, where a nullable type is on the right.<br /></li></ul>|
|`?>=?`, `?>?`, `?<=?`, `?<?`, `?=?`, `?<>?`, `?+?`, `?-?`, `?*?`, `?/?`|[Nullable Operators](nullable-operators.md)|<ul><li>Equivalent to the corresponding operators without the surrounding question marks, where both sides are nullable types.<br /></li></ul>|

## Operator precedence

The following table shows the order of precedence of operators and other expression keywords in the F# language, in order from lowest precedence to the highest precedence. Also listed is the associativity, if applicable.

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
