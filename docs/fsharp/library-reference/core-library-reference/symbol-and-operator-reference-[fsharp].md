---
title: Symbol and Operator Reference (F#)
description: Symbol and Operator Reference (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ab453800-d4d0-4a11-9d55-2b358d56af27
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/index 
---

# Symbol and Operator Reference (F#)

This topic includes a table of symbols and operators that are used in the F# language.


## Table of Symbols and Operators
The following table describes symbols used in the F# language, provides links to topics that provide more information, and provides a brief description of some of the uses of the symbol. Symbols are ordered according to the ASCII character set ordering.



|Symbol or operator|Links|Description|
|------------------|-----|-----------|
|**!**|[Reference Cells &#40;F&#35;&#41;](Reference-Cells-%5BFSharp%5D.md)<br /><br />[Computation Expressions &#40;F&#35;&#41;](Computation-Expressions-%5BFSharp%5D.md)|<ul><li>Dereferences a reference cell.<br /></li><li>After a keyword, indicates a modified version of the keyword's behavior as controlled by a workflow.<br /></li><ul/>|
|**!=**|Not applicable.|<ul><li>Not used in F#. Use **&lt;&gt;** for inequality operations.<br /></li><ul/>|
|**"**|[Literals &#40;F&#35;&#41;](Literals-%5BFSharp%5D.md)<br /><br />[Strings &#40;F&#35;&#41;](Strings-%5BFSharp%5D.md)|<ul><li>Delimits a text string.<br /></li><ul/>|
|**"""**|[Strings &#40;F&#35;&#41;](Strings-%5BFSharp%5D.md)|Delimits a verbatim text string. Differs from **@"..."** in that a you can indicate a quotation mark character by using a single quote in the string.|
|**#**|[Compiler Directives &#40;F&#35;&#41;](Compiler-Directives-%5BFSharp%5D.md)<br /><br />[Flexible Types &#40;F&#35;&#41;](Flexible-Types-%5BFSharp%5D.md)|<ul><li>Prefixes a preprocessor or compiler directive, such as **#light**.<br /></li><li>When used with a type, indicates a *flexible type*, which refers to a type or any one of its derived types.<br /></li><ul/>|
|**$**|No more information available.|<ul><li>Used internally for certain compiler-generated variable and function names.<br /></li><ul/>|
|**%**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)<br /><br />[Code Quotations &#40;F&#35;&#41;](Code-Quotations-%5BFSharp%5D.md)|<ul><li>Computes the integer modulus.<br /></li><li>Used for splicing expressions into typed code quotations.<br /></li><ul/>|
|**%%**|[Code Quotations &#40;F&#35;&#41;](Code-Quotations-%5BFSharp%5D.md)|<ul><li>Used for splicing expressions into untyped code quotations.<br /></li><ul/>|
|**%?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Computes the integer modulus, when the right side is a nullable type.<br /></li><ol/>|
|**&amp;**|[Match Expressions &#40;F&#35;&#41;](Match-Expressions-%5BFSharp%5D.md)|<ul><li>Computes the address of a mutable value, for use when interoperating with other languages.<br /></li><li>Used in AND patterns.<br /></li><ul/>|
|**&amp;&amp;**|[Boolean Operators &#40;F&#35;&#41;](Boolean-Operators-%5BFSharp%5D.md)|<ul><li>Computes the Boolean AND operation.<br /></li><ul/>|
|**&amp;&amp;&amp;**|[Bitwise Operators &#40;F&#35;&#41;](Bitwise-Operators-%5BFSharp%5D.md)|<ul><li>Computes the bitwise AND operation.<br /></li><ul/>|
|**'**|[Literals &#40;F&#35;&#41;](Literals-%5BFSharp%5D.md)<br /><br />[Automatic Generalization &#40;F&#35;&#41;](Automatic-Generalization-%5BFSharp%5D.md)|<ul><li>Delimits a single-character literal.<br /></li><li>Indicates a generic type parameter.<br /></li><ul/>|
|**&#96;&#96;...&#96;&#96;**|No more information available.|<ul><li>Delimits an identifier that would otherwise not be a legal identifier, such as a language keyword.<br /></li><ul/>|
|**( )**|[Unit Type &#40;F&#35;&#41;](Unit-Type-%5BFSharp%5D.md)|<ul><li>Represents the single value of the unit type.<br /></li><ul/>|
|**(...)**|[Tuples &#40;F&#35;&#41;](Tuples-%5BFSharp%5D.md)<br /><br />[Operator Overloading &#40;F&#35;&#41;](Operator-Overloading-%5BFSharp%5D.md)|<ul><li>Indicates the order in which expressions are evaluated.<br /></li><li>Delimits a tuple.<br /></li><li>Used in operator definitions.<br /></li><ul/>|
|**(&#42;...&#42;)**||<ul><li>Delimits a comment that could span multiple lines.<br /></li><ul/>|
|**(&#124;...&#124;)**|[Active Patterns &#40;F&#35;&#41;](Active-Patterns-%5BFSharp%5D.md)|<ul><li>Delimits an active pattern. Also called *banana clips*.<br /></li><ul/>|
|**&#42;**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)<br /><br />[Tuples &#40;F&#35;&#41;](Tuples-%5BFSharp%5D.md)<br /><br />[Units of Measure &#40;F&#35;&#41;](Units-of-Measure-%5BFSharp%5D.md)|<ul><li>When used as a binary operator, multiplies the left and right sides.<br /></li><li>In types, indicates pairing in a tuple.<br /></li><li>Used in units of measure types.<br /></li><ul/>|
|**&#42;?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Multiplies the left and right sides, when the right side is a nullable type.<br /></li><ol/>|
|**&#42;&#42;**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>Computes the exponentiation operation (x &#42;&#42; y means x to the power of y).<br /></li><ul/>|
|**+**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>When used as a binary operator, adds the left and right sides.<br /></li><li>When used as a unary operator, indicates a positive quantity. (Formally, it produces the same value with the sign unchanged.)<br /></li><ul/>|
|**+?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Adds the left and right sides, when the right side is a nullable type.<br /></li><ol/>|
|**,**|[Tuples &#40;F&#35;&#41;](Tuples-%5BFSharp%5D.md)|<ul><li>Separates the elements of a tuple, or type parameters.<br /></li><ul/>|
|**-**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>When used as a binary operator, subtracts the right side from the left side.<br /></li><li>When used as a unary operator, performs a negation operation.<br /></li><ul/>|
|**-**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Subtracts the right side from the left side, when the right side is a nullable type.<br /></li><ol/>|
|**-&gt;**|[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)<br /><br />[Match Expressions &#40;F&#35;&#41;](Match-Expressions-%5BFSharp%5D.md)|<ul><li>In function types, delimits arguments and return values.<br /></li><li>Yields an expression (in sequence expressions); equivalent to the **yield** keyword.<br /></li><li>Used in match expressions<br /></li><ul/>|
|**.**|[Members &#40;F&#35;&#41;](Members-%5BFSharp%5D.md)<br /><br />[Primitive Types &#40;F&#35;&#41;](Primitive-Types-%5BFSharp%5D.md)|<ul><li>Accesses a member, and separates individual names in a fully qualified name.<br /></li><li>Specifies a decimal point in floating point numbers.<br /></li><ul/>|
|**..**|[Loops: for...in Expression &#40;F&#35;&#41;](Loops-for...in-Expression-%5BFSharp%5D.md)|<ul><li>Specifies a range.<br /></li><ul/>|
|**.. ..**|[Loops: for...in Expression &#40;F&#35;&#41;](Loops-for...in-Expression-%5BFSharp%5D.md)|<ul><li>Specifies a range together with an increment.<br /></li><ul/>|
|**.[...]**|[Arrays &#40;F&#35;&#41;](Arrays-%5BFSharp%5D.md)|<ul><li>Accesses an array element.<br /></li><ul/>|
|**/**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)<br /><br />[Units of Measure &#40;F&#35;&#41;](Units-of-Measure-%5BFSharp%5D.md)|<ul><li>Divides the left side (numerator) by the right side (denominator).<br /></li><li>Used in units of measure types.<br /></li><ul/>|
|**/?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Divides the left side by the right side, when the right side is a nullable type.<br /></li><ol/>|
|**//**||<ul><li>Indicates the beginning of a single-line comment.<br /></li><ul/>|
|**///**|[XML Documentation &#40;F&#35;&#41;](XML-Documentation-%5BFSharp%5D.md)|<ul><li>Indicates an XML comment.<br /></li><ul/>|
|**:**|[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)|<ul><li>In a type annotation, separates a parameter or member name from its type.<br /></li><ul/>|
|**::**|[Lists &#40;F&#35;&#41;](Lists-%5BFSharp%5D.md)<br /><br />[Match Expressions &#40;F&#35;&#41;](Match-Expressions-%5BFSharp%5D.md)|<ul><li>Creates a list. The element on the left side is prepended to the list on the right side.<br /></li><li>Used in pattern matching to separate the parts of a list.<br /></li><ul/>|
|**:=**|[Reference Cells &#40;F&#35;&#41;](Reference-Cells-%5BFSharp%5D.md)|<ul><li>Assigns a value to a reference cell.<br /></li><ul/>|
|**:&gt;**|[Casting and Conversions &#40;F&#35;&#41;](Casting-and-Conversions-%5BFSharp%5D.md)|<ul><li>Converts a type to type that is higher in the hierarchy.<br /></li><ul/>|
|**:?**|[Match Expressions &#40;F&#35;&#41;](Match-Expressions-%5BFSharp%5D.md)|<ul><li>Returns **true** if the value matches the specified type; otherwise, returns **false** (type test operator).<br /></li><ul/>|
|**:?&gt;**|[Casting and Conversions &#40;F&#35;&#41;](Casting-and-Conversions-%5BFSharp%5D.md)|<ul><li>Converts a type to a type that is lower in the hierarchy.<br /></li><ul/>|
|**;**|[Verbose Syntax &#40;F&#35;&#41;](Verbose-Syntax-%5BFSharp%5D.md)<br /><br />[Lists &#40;F&#35;&#41;](Lists-%5BFSharp%5D.md)<br /><br />[Records &#40;F&#35;&#41;](Records-%5BFSharp%5D.md)|<ul><li>Separates expressions (used mostly in verbose syntax).<br /></li><li>Separates elements of a list.<br /></li><li>Separates fields of a record.<br /></li><ul/>|
|**&lt;**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>Computes the less-than operation.<br /></li><ul/>|
|**&lt;?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|Computes the less than operation, when the right side is a nullable type.|
|**&lt;&lt;**|[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)|<ul><li>Composes two functions in reverse order; the second one is executed first (backward composition operator).<br /></li><ul/>|
|**&lt;&lt;&lt;**|[Bitwise Operators &#40;F&#35;&#41;](Bitwise-Operators-%5BFSharp%5D.md)|<ul><li>Shifts bits in the quantity on the left side to the left by the number of bits specified on the right side.<br /></li><ul/>|
|**&lt;-**|[Values &#40;F&#35;&#41;](Values-%5BFSharp%5D.md)|<ul><li>Assigns a value to a variable.<br /></li><ul/>|
|**&lt;...&gt;**|[Automatic Generalization &#40;F&#35;&#41;](Automatic-Generalization-%5BFSharp%5D.md)|<ul><li>Delimits type parameters.<br /></li><ul/>|
|**&lt;&gt;**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>Returns **true** if the left side is not equal to the right side; otherwise, returns false.<br /></li><ul/>|
|**&lt;&gt;?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Computes the "not equal" operation when the right side is a nullable type.<br /></li><ol/>|
|**&lt;=**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>Returns **true** if the left side is less than or equal to the right side; otherwise, returns false.<br /></li><ul/>|
|**&lt;=?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Computes the "less than or equal to" operation when the right side is a nullable type.<br /></li><ol/>|
|**&lt;&#124;**|[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)|<ul><li>Passes the result of the expression on the right side to the function on left side (backward pipe operator).<br /></li><ul/>|
|**&lt;&#124;&#124;**|[Operators.&#40; &#60;&#124;&#124; &#41;&#60;'T1,'T2,'U&#62; Function &#40;F&#35;&#41;](Operators.%5B-%5Bhh-%5D%5B%27T1%2C%27T2%2C%27U%5D-Function-%5BFSharp%5D.md)|<ul><li>Passes the tuple of two arguments on the right side to the function on left side.<br /></li><ul/>|
|**&lt;&#124;&#124;&#124;**|[Operators.&#40; &#60;&#124;&#124;&#124; &#41;&#60;'T1,'T2,'T3,'U&#62; Function &#40;F&#35;&#41;](Operators.%5B-%5Bhhh-%5D%5B%27T1%2C%27T2%2C%27T3%2C%27U%5D-Function-%5BFSharp%5D.md)|<ul><li>Passes the tuple of three arguments on the right side to the function on left side.<br /></li><ul/>|
|**&lt;@...@&gt;**|[Code Quotations &#40;F&#35;&#41;](Code-Quotations-%5BFSharp%5D.md)|<ul><li>Delimits a typed code quotation.<br /></li><ul/>|
|**&lt;@@...@@&gt;**|[Code Quotations &#40;F&#35;&#41;](Code-Quotations-%5BFSharp%5D.md)|<ul><li>Delimits an untyped code quotation.<br /></li><ul/>|
|**=**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>Returns **true** if the left side is equal to the right side; otherwise, returns false.<br /></li><ul/>|
|**=?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Computes the "equal" operation when the right side is a nullable type.<br /></li><ol/>|
|**==**|Not applicable.|<ul><li>Not used in F#. Use **=** for equality operations.<br /></li><ul/>|
|**&gt;**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>Returns **true** if the left side is greater than the right side; otherwise, returns false.<br /></li><ul/>|
|**&gt;?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Computes the "greather than" operation when the right side is a nullable type.<br /></li><ol/>|
|**&gt;&gt;**|[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)|<ul><li>Composes two functions (forward composition operator).<br /></li><ul/>|
|**&gt;&gt;&gt;**|[Bitwise Operators &#40;F&#35;&#41;](Bitwise-Operators-%5BFSharp%5D.md)|<ul><li>Shifts bits in the quantity on the left side to the right by the number of places specified on the right side.<br /></li><ul/>|
|**&gt;=**|[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)|<ul><li>Returns **true** if the right side is greater than or equal to the left side; otherwise, returns false.<br /></li><ul/>|
|**&gt;=?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Computes the "greater than or equal" operation when the right side is a nullable type.<br /></li><ol/>|
|**?**|[Parameters and Arguments &#40;F&#35;&#41;](Parameters-and-Arguments-%5BFSharp%5D.md)|<ul><li>Specifies an optional argument.<br /></li><li>Used as an operator for dynamic method and property calls. You must provide your own implementation.<br /></li><ul/>|
|**? ... &lt;- ...**|No more information available.|<ul><li>Used as an operator for setting dynamic properties. You must provide your own implementation.<br /></li><ul/>|
|**?&gt;=**, **?&gt;**, **?&lt;=**, **?&lt;**, **?=**, **?&lt;&gt;**, **?+**, **?-**, **?&#42;**, **?/**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Equivalent to the corresponding operators without the ? prefix, where a nullable type is on the left.<br /></li><ol/>|
|**&gt;=?**, **&gt;?**, **&lt;=?**, **&lt;?**, **=?**, **&lt;&gt;?**, **+?**, **-?**, **&#42;?**, **/?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Equivalent to the corresponding operators without the ? suffix, where a nullable type is on the right.<br /></li><ol/>|
|**?&gt;=?**, **?&gt;?**, **?&lt;=?**, **?&lt;?**, **?=?**, **?&lt;&gt;?**, **?+?**, **?-?**, **?&#42;?**, **?/?**|[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)|<ol><li>Equivalent to the corresponding operators without the surrounding question marks, where both sides are nullable types.<br /></li><ol/>|
|**@**|[Lists &#40;F&#35;&#41;](Lists-%5BFSharp%5D.md)<br /><br />[Strings &#40;F&#35;&#41;](Strings-%5BFSharp%5D.md)|<ul><li>Concatenates two lists.<br /></li><li>When placed before a string literal, indicates that the string is to be interpreted verbatim, with no interpretation of escape characters.<br /></li><ul/>|
|**[...]**|[Lists &#40;F&#35;&#41;](Lists-%5BFSharp%5D.md)|<ul><li>Delimits the elements of a list.<br /></li><ul/>|
|**[&#124;...&#124;]**|[Arrays &#40;F&#35;&#41;](Arrays-%5BFSharp%5D.md)|<ul><li>Delimits the elements of an array.<br /></li><ul/>|
|**[&lt;...&gt;]**|[Attributes &#40;F&#35;&#41;](Attributes-%5BFSharp%5D.md)|<ul><li>Delimits an attribute.<br /></li><ul/>|
|**\**|[Strings &#40;F&#35;&#41;](Strings-%5BFSharp%5D.md)|<ul><li>Escapes the next character; used in character and string literals.<br /></li><ul/>|
|**^**|[Statically Resolved Type Parameters &#40;F&#35;&#41;](Statically-Resolved-Type-Parameters-%5BFSharp%5D.md)<br /><br />[Strings &#40;F&#35;&#41;](Strings-%5BFSharp%5D.md)|<ul><li>Specifies type parameters that must be resolved at compile time, not at runtime.<br /></li><li>Concatenates strings.<br /></li><ul/>|
|**^^^**|[Bitwise Operators &#40;F&#35;&#41;](Bitwise-Operators-%5BFSharp%5D.md)|<ul><li>Computes the bitwise exclusive OR operation.<br /></li><ul/>|
|**_**|[Match Expressions &#40;F&#35;&#41;](Match-Expressions-%5BFSharp%5D.md)<br /><br />[Generics &#40;F&#35;&#41;](Generics-%5BFSharp%5D.md)|<ul><li>Indicates a wildcard pattern.<br /></li><li>Specifies an anonymous generic parameter.<br /></li><ul/>|
|**&#96;**|[Automatic Generalization &#40;F&#35;&#41;](Automatic-Generalization-%5BFSharp%5D.md)|<ul><li>Used internally to indicate a generic type parameter.<br /></li><ul/>|
|**{...}**|[Sequences &#40;F&#35;&#41;](Sequences-%5BFSharp%5D.md)<br /><br />[Records &#40;F&#35;&#41;](Records-%5BFSharp%5D.md)|<ul><li>Delimits sequence expressions and computation expressions.<br /></li><li>Used in record definitions.<br /></li><ul/>|
|**&#124;**|[Match Expressions &#40;F&#35;&#41;](Match-Expressions-%5BFSharp%5D.md)|<ul><li>Delimits individual match cases, individual discriminated union cases, and enumeration values.<br /></li><ul/>|
|**&#124;&#124;**|[Boolean Operators &#40;F&#35;&#41;](Boolean-Operators-%5BFSharp%5D.md)|<ul><li>Computes the Boolean OR operation.<br /></li><ul/>|
|**&#124;&#124;&#124;**|[Bitwise Operators &#40;F&#35;&#41;](Bitwise-Operators-%5BFSharp%5D.md)|<ul><li>Computes the bitwise OR operation.<br /></li><ul/>|
|**&#124;&gt;**|[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)|<ul><li>Passes the result of the left side to the function on the right side (forward pipe operator).<br /></li><ul/>|
|**&#124;&#124;&gt;**|[Operators.&#40; &#124;&#124;&#62; &#41;&#60;'T1,'T2,'U&#62; Function &#40;F&#35;&#41;](Operators.%5B-hh%5D-%5D%5B%27T1%2C%27T2%2C%27U%5D-Function-%5BFSharp%5D.md)|<ul><li>Passes the tuple of two arguments on the left side to the function on the right side.<br /></li><ul/>|
|**&#124;&#124;&#124;&gt;**|[Operators.&#40; &#124;&#124;&#124;&#62; &#41;&#60;'T1,'T2,'T3,'U&#62; Function &#40;F&#35;&#41;](Operators.%5B-hhh%5D-%5D%5B%27T1%2C%27T2%2C%27T3%2C%27U%5D-Function-%5BFSharp%5D.md)|<ol><li>Passes the tuple of three arguments on the left side to the function on the right side.<br /></li><ol/>|
|**~~**|[Operator Overloading &#40;F&#35;&#41;](Operator-Overloading-%5BFSharp%5D.md)|<ul><li>Used to declare an overload for the unary negation operator.<br /></li><ul/>|
|**~~~**|[Bitwise Operators &#40;F&#35;&#41;](Bitwise-Operators-%5BFSharp%5D.md)|<ul><li>Computes the bitwise NOT operation.<br /></li><ul/>|
|**~-**|[Operator Overloading &#40;F&#35;&#41;](Operator-Overloading-%5BFSharp%5D.md)|<ul><li>Used to declare an overload for the unary minus operator.<br /></li><ul/>|
|**~+**|[Operator Overloading &#40;F&#35;&#41;](Operator-Overloading-%5BFSharp%5D.md)|<ul><li>Used to declare an overload for the unary plus operator.<br /></li><ul/>|

## Operator Precedence
The following table shows the order of precedence of operators and other expression keywords in the F# language, in order from lowest precedence to the highest precedence. Also listed is the associativity, if applicable.



|Operator|Associativity|
|--------|-------------|
|**as**|Right|
|**when**|Right|
|**&#124;** (pipe)|Left|
|**;**|Right|
|**let**|Nonassociative|
|**function**, **fun**, **match**, **try**|Nonassociative|
|**if**|Nonassociative|
|**-&gt;**|Right|
|**:=**|Right|
|**,**|Nonassociative|
|**or**, **&#124;&#124;**|Left|
|**&amp;**, **&amp;&amp;**|Left|
|**:&gt;**, **:?&gt;**|Right|
|**!=***op*, **&lt;***op*, **&gt;***op*, **=**, **&#124;***op*, **&amp;***op*, **&amp;**<br /><br />(including **&lt;&lt;&lt;**, **&gt;&gt;&gt;**, **&#124;&#124;&#124;**, **&amp;&amp;&amp;**)|Left|
|**^***op*<br /><br />(including **^^^**)|Right|
|**::**|Right|
|**:?**|Not associative|
|**-***op*, **+***op*|Applies to infix uses of these symbols|
|**&#42;***op*, **/***op*, **%***op*|Left|
|**&#42;&#42;***op*|Right|
|**f x** (function application)|Left|
|**&#124;** (pattern match)|Right|
|prefix operators (+*op*, -*op*, %, %%, &amp;, &amp;&amp;, !*op*, ~*op*)|Left|
|**.**|Left|
|**f(x)**|Left|
|**f&lt;***types***&gt;**|Left|
F# supports custom operator overloading. This means that you can define your own operators. In the previous table, *op* can be any valid (possibly empty) sequence of operator characters, either built-in or user-defined. Thus, you can use this table to determine what sequence of characters to use for a custom operator to achieve the desired level of precedence. Leading **.** characters are ignored when the compiler determines precedence.

## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[Operator Overloading &#40;F&#35;&#41;](Operator-Overloading-%5BFSharp%5D.md)