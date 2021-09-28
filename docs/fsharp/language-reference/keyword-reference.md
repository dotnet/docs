---
title: Keyword Reference
description: Find links to information about all of the F# language keywords.
f1_keywords:
- new_FS
- use_FS
- end_FS
- lsl_FS
- exception_FS
- asr_FS
- if_FS
- internal_FS
- default_FS
- in_FS
- lsr_FS
- open_FS
- static_FS
- assert_FS
- match_FS
- land_FS
- with_FS
- inherit_FS
- mutable_FS
- downto_FS
- false_FS
- sig_FS
- and_FS
- true_FS
- namespace_FS
- public_FS
- lxor_FS
- val_FS
- void_FS
- downcast_FS
- function_FS
- while_FS
- for_FS
- class_FS
- done_FS
- to_FS
- module_FS
- let_FS
- delegate_FS
- abstract_FS
- then_FS
- when_FS
- lazy_FS
- try_FS
- inline_FS
- do_FS
- upcast_FS
- begin_FS
- base_FS
- fun_FS
- struct_FS
- as_FS
- extern_FS
- null_FS
- lor_FS
- return_FS
- mod_FS
- private_FS
- of_FS
- or_FS
- member_FS
- type_FS
- rec_FS
- elif_FS
- override_FS
- interface_FS
- yield_FS
- else_FS
- finally_FS
- global_FS
- select_FS
- use!_FS
- const_FS
dev_langs:
- FSharp
ms.date: 08/15/2020
---
# Keyword Reference

This topic contains links to information about all F# language keywords.

## F# Keyword Table

The following table shows all F# keywords in alphabetical order, together with brief descriptions and links to relevant topics that contain more information.

|Keyword|Link|Description|
|-------|----|-----------|
|`abstract`|[Members](./members/index.md)<br /><br />[Abstract Classes](abstract-classes.md)|Indicates a method that either has no implementation in the type in which it is declared or that is virtual and has a default implementation.|
|`and`|[`let` Bindings](./functions/let-bindings.md)<br /><br />[Records](records.md)<br /><br />[Members](./members/index.md)<br /><br />[Constraints](./generics/constraints.md)|Used in mutually recursive bindings and records, in property declarations, and with multiple constraints on generic parameters.|
|`as`|[Classes](classes.md)<br /><br />[Pattern Matching](pattern-matching.md)|Used to give the current class object an object name. Also used to give a name to a whole pattern within a pattern match.|
|`assert`|[Assertions](assertions.md)|Used to verify code during debugging.|
|`base`|[Classes](classes.md)<br /><br />[Inheritance](inheritance.md)|Used as the name of the base class object.|
|`begin`|[Verbose Syntax](verbose-syntax.md)|In verbose syntax, indicates the start of a code block.|
|`class`|[Classes](classes.md)|In verbose syntax, indicates the start of a class definition.|
|`default`|[Members](./members/index.md)|Indicates an implementation of an abstract method; used together with an abstract method declaration to create a virtual method.|
|`delegate`|[Delegates](delegates.md)|Used to declare a delegate.|
|`do`|[do Bindings](./functions/do-bindings.md)<br /><br />[Loops: `for...to` Expression](loops-for-to-expression.md)<br /><br />[Loops: `for...in` Expression](loops-for-in-expression.md)<br /><br />[Loops: `while...do` Expression](loops-while-do-expression.md)|Used in looping constructs or to execute imperative code.|
|`done`|[Verbose Syntax](verbose-syntax.md)|In verbose syntax, indicates the end of a block of code in a looping expression.|
|`downcast`|[Casting and Conversions](casting-and-conversions.md)|Used to convert to a type that is lower in the inheritance chain.|
|`downto`|[Loops: `for...to` Expression](loops-for-to-expression.md)|In a `for` expression, used when counting in reverse.|
|`elif`|[Conditional Expressions: `if...then...else`](conditional-expressions-if-then-else.md)|Used in conditional branching. A short form of `else if`.|
|`else`|[Conditional Expressions: `if...then...else`](conditional-expressions-if-then-else.md)|Used in conditional branching.|
|`end`|[Structures](structures.md)<br /><br />[Discriminated Unions](discriminated-unions.md)<br /><br />[Records](records.md)<br /><br />[Type Extensions](type-extensions.md)<br /><br />[Verbose Syntax](verbose-syntax.md)|In type definitions and type extensions, indicates the end of a section of member definitions.<br /><br />In verbose syntax, used to specify the end of a code block that starts with the `begin` keyword.|
|`exception`|[Exception Handling](./exception-handling/index.md)<br /><br />[Exception Types](./exception-handling/exception-types.md)|Used to declare an exception type.|
|`extern`|[External Functions](./functions/external-functions.md)|Indicates that a declared program element is defined in another binary or assembly.|
|`false`|[Primitive Types](basic-types.md)|Used as a Boolean literal.|
|`finally`|[Exceptions: The `try...finally` Expression](./exception-handling/the-try-finally-expression.md)|Used together with `try` to introduce a block of code that executes regardless of whether an exception occurs.|
|`fixed`|[Fixed](fixed.md)|Used to "pin" a pointer on the stack to prevent it from being garbage collected.|
|`for`|[Loops: `for...to` Expression](loops-for-to-expression.md)<br /><br />[Loops: for...in Expression](loops-for-in-expression.md)|Used in looping constructs.|
|`fun`|[Lambda Expressions: The `fun` Keyword](./functions/lambda-expressions-the-fun-keyword.md)|Used in lambda expressions, also known as anonymous functions.|
|`function`|[Match Expressions](match-expressions.md)<br /><br />[Lambda Expressions: The fun Keyword](./functions/lambda-expressions-the-fun-keyword.md)|Used as a shorter alternative to the `fun` keyword and a `match` expression in a lambda expression that has pattern matching on a single argument.|
|`global`|[Namespaces](namespaces.md)|Used to reference the top-level .NET namespace.|
|`if`|[Conditional Expressions: `if...then...else`](conditional-expressions-if-then-else.md)|Used in conditional branching constructs.|
|`in`|[Loops: for...in Expression](loops-for-in-expression.md)<br /><br />[Verbose Syntax](verbose-syntax.md)|Used for sequence expressions and, in verbose syntax, to separate expressions from bindings.|
|`inherit`|[Inheritance](inheritance.md)|Used to specify a base class or base interface.|
|`inline`|[Functions](./functions/index.md)<br /><br />[Inline Functions](./functions/inline-functions.md)|Used to indicate a function that should be integrated directly into the caller's code.|
|`interface`|[Interfaces](interfaces.md)|Used to declare and implement interfaces.|
|`internal`|[Access Control](access-control.md)|Used to specify that a member is visible inside an assembly but not outside it.|
|`lazy`|[Lazy Expressions](lazy-expressions.md)|Used to specify an expression that is to be performed only when a result is needed.|
|`let`|[`let` Bindings](./functions/let-bindings.md)|Used to associate, or bind, a name to a value or function.|
|`let!`|[Asynchronous Workflows](asynchronous-workflows.md)<br /><br />[Computation Expressions](computation-expressions.md)|Used in asynchronous workflows to bind a name to the result of an asynchronous computation, or, in other computation expressions, used to bind a name to a result, which is of the computation type.|
|`match`|[Match Expressions](match-expressions.md)|Used to branch by comparing a value to a pattern.|
|`match!`|[Computation Expressions](computation-expressions.md#match)|Used to inline a call to a computation expression and pattern match on its result.|
|`member`|[Members](./members/index.md)|Used to declare a property or method in an object type.|
|`module`|[Modules](modules.md)|Used to associate a name with a group of related types, values, and functions, to logically separate it from other code.|
|`mutable`|[let Bindings](./functions/let-bindings.md)|Used to declare a variable, that is, a value that can be changed.|
|`namespace`|[Namespaces](namespaces.md)|Used to associate a name with a group of related types and modules, to logically separate it from other code.|
|`new`|[Constructors](./members/constructors.md)<br /><br />[Constraints](./generics/constraints.md)|Used to declare, define, or invoke a constructor that creates or that can create an object.<br /><br />Also used in generic parameter constraints to indicate that a type must have a certain constructor.|
|`not`|[Symbol and Operator Reference](./symbol-and-operator-reference/index.md)<br /><br />[Constraints](./generics/constraints.md)|Not actually a keyword. However, `not struct` in combination is used as a generic parameter constraint.|
|`null`|[Null Values](./values/null-values.md)<br /><br />[Constraints](./generics/constraints.md)|Indicates the absence of an object.<br /><br />Also used in generic parameter constraints.|
|`of`|[Discriminated Unions](discriminated-unions.md)<br /><br />[Delegates](delegates.md)<br /><br />[Exception Types](./exception-handling/exception-types.md)|Used in discriminated unions to indicate the type of categories of values, and in delegate and exception declarations.|
|`open`|[Import Declarations: The `open` Keyword](import-declarations-the-open-keyword.md)|Used to make the contents of a namespace or module available without qualification.|
|`or`|[Symbol and Operator Reference](./symbol-and-operator-reference/index.md)<br /><br />[Constraints](./generics/constraints.md)|Used with Boolean conditions as a Boolean `or` operator. Equivalent to `||`.<br /><br />Also used in member constraints.|
|`override`|[Members](./members/index.md)|Used to implement a version of an abstract or virtual method that differs from the base version.|
|`private`|[Access Control](access-control.md)|Restricts access to a member to code in the same type or module.|
|`public`|[Access Control](access-control.md)|Allows access to a member from outside the type.|
|`rec`|[Functions](./functions/index.md)|Used to indicate that a function is recursive.|
|`return`|[Asynchronous Workflows](asynchronous-workflows.md)<br /><br />[Computation Expressions](computation-expressions.md)|Used to indicate a value to provide as the result of a computation expression.|
|`return!`|[Computation Expressions](computation-expressions.md)<br /><br />[Asynchronous Workflows](asynchronous-workflows.md)|Used to indicate a computation expression that, when evaluated, provides the result of the containing computation expression.|
|`select`|[Query Expressions](query-expressions.md)|Used in query expressions to specify what fields or columns to extract. Note that this is a contextual keyword, which means that it is not actually a reserved word and it only acts like a keyword in appropriate context.|
|`static`|[Members](./members/index.md)|Used to indicate a method or property that can be called without an instance of a type, or a value member that is shared among all instances of a type.|
|`struct`|[Structures](structures.md)<br /><br /> [Tuples](tuples.md)<br/><br/>[Constraints](./generics/constraints.md)|Used to declare a structure type.<br /><br/>Used to specify a struct tuple.<br/><br />Also used in generic parameter constraints.<br /><br />Used for OCaml compatibility in module definitions.|
|`then`|[Conditional Expressions: `if...then...else`](conditional-expressions-if-then-else.md)<br /><br />[Constructors](./members/constructors.md)|Used in conditional expressions.<br /><br />Also used to perform side effects after object construction.|
|`to`|[Loops: `for...to` Expression](loops-for-to-expression.md)|Used in `for` loops to indicate a range.|
|`true`|[Primitive Types](basic-types.md)|Used as a Boolean literal.|
|`try`|[Exceptions: The try...with Expression](./exception-handling/the-try-with-expression.md)<br /><br />[Exceptions: The try...finally Expression](./exception-handling/the-try-finally-expression.md)|Used to introduce a block of code that might generate an exception. Used together with `with` or `finally`.|
|`type`|[F# Types](fsharp-types.md)<br /><br />[Classes](classes.md)<br /><br />[Records](records.md)<br /><br />[Structures](structures.md)<br /><br />[Enumerations](enumerations.md)<br /><br />[Discriminated Unions](discriminated-unions.md)<br /><br />[Type Abbreviations](type-abbreviations.md)<br /><br />[Units of Measure](units-of-measure.md)|Used to declare a class, record, structure, discriminated union, enumeration type, unit of measure, or type abbreviation.|
|`upcast`|[Casting and Conversions](casting-and-conversions.md)|Used to convert to a type that is higher in the inheritance chain.|
|`use`|[Resource Management: The `use` Keyword](resource-management-the-use-keyword.md)|Used instead of `let` for values that require `Dispose` to be called to free resources.|
|`use!`|[Computation Expressions](computation-expressions.md)<br /><br />[Asynchronous Workflows](asynchronous-workflows.md)|Used instead of `let!` in asynchronous workflows and other computation expressions for values that require `Dispose` to be called to free resources.|
|`val`|[Explicit Fields: The `val` Keyword](./members/explicit-fields-the-val-keyword.md)<br /><br />[Signatures](signature-files.md)<br /><br />[Members](./members/index.md)|Used in a signature to indicate a value, or in a type to declare a member, in limited situations.|
|`void`|[Primitive Types](basic-types.md)|Indicates the .NET `void` type. Used when interoperating with other .NET languages.|
|`when`|[Constraints](./generics/constraints.md)|Used for Boolean conditions (*when guards*) on pattern matches and to introduce a constraint clause for a generic type parameter.|
|`while`|[Loops: `while...do` Expression](loops-while-do-expression.md)|Introduces a looping construct.|
|`with`|[Match Expressions](match-expressions.md)<br /><br />[Object Expressions](object-expressions.md)<br /><br />[Copy and Update Record Expressions](copy-and-update-record-expressions.md)<br /><br />[Type Extensions](type-extensions.md)<br /><br />[Exceptions: The `try...with` Expression](./exception-handling/the-try-with-expression.md)|Used together with the `match` keyword in pattern matching expressions. Also used in object expressions, record copying expressions, and type extensions to introduce member definitions, and to introduce exception handlers.|
|`yield`|[Lists](lists.md), [Arrays](arrays.md), [Sequences](sequences.md)|Used in a list, array, or sequence expression to produce a value for a sequence. Typically can be omitted, as it is implicit in most situations.|
|`yield!`|[Computation Expressions](computation-expressions.md)<br /><br />[Asynchronous Workflows](asynchronous-workflows.md)|Used in a computation expression to append the result of a given computation expression to a collection of results for the containing computation expression.|
|`const`|[Type Providers](../tutorials/type-providers/index.md)| Type Providers allow the use of `const` as a keyword to specify a constant literal as a type parameter argument.|

The following tokens are reserved in F# because they are keywords in the OCaml language:

- `asr`
- `land`
- `lor`
- `lsl`
- `lsr`
- `lxor`
- `mod`
- `sig`

If you use the `--mlcompatibility` compiler option, the above keywords are available for use as identifiers.

The following tokens are reserved as keywords for future expansion of the F# language:

- `break`
- `checked`
- `component`
- `const`
- `constraint`
- `continue`
- `event`
- `external`
- `include`
- `mixin`
- `parallel`
- `process`
- `protected`
- `pure`
- `sealed`
- `tailcall`
- `trait`
- `virtual`

The following tokens were once reserved as keywords but were [released](https://github.com/fsharp/fslang-design/blob/main/FSharp-4.1/FS-1016-unreserve-keywords.md) in F# 4.1, so now you can use them as identifiers:

Keyword | Reason
-|-
`method` | the F# commmunity are happy with `member` to introduce methods
`constructor` | the F# commmunity are happy with `new` to introduce constructors
`atomic` | this was related to the fad for transactional memory circa 2006. In F# this would now be a library-defined computation expression
`eager` | this is no longer needed, it was initially designed to be `let eager` to match a potential `let lazy`
`object` | there is no need to reserve this
`recursive` | F# is happy using `rec`
`functor` | If F# added parametereized modules, we would use `module M(args) = ...`
`measure` | There is no specific reason to reserve this these days, the `[<Measure>]` attribute suffices
`volatile` | There is no specific reason to reserve this these days, the `[<Volatile>]` attribute suffices

## See also

- [F# Language Reference](index.md)
- [Symbol and Operator Reference](./symbol-and-operator-reference/index.md)
- [Compiler Options](compiler-options.md)
