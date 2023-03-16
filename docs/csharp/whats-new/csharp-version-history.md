---
title: The history of C# - C# Guide
description: What did the language look like in its earliest versions, and how has it evolved since?
author: erikdietrich
ms.date: 06/18/2021
ms.custom: "updateeachrelease, UpdateFrequency1"
---

# The history of C\#

This article provides a history of each major release of the C# language. The C# team is continuing to innovate and add new features. Detailed language feature status, including features considered for upcoming releases can be found [on the dotnet/roslyn repository](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md) on GitHub.

> [!IMPORTANT]
> The C# language relies on types and methods in what the C# specification defines as a *standard library* for some of the features. The .NET platform delivers those types and methods in a number of packages. One example is exception processing. Every `throw` statement or expression is checked to ensure the object being thrown is derived from <xref:System.Exception>. Similarly, every `catch` is checked to ensure that the type being caught is derived from <xref:System.Exception>. Each version may add new requirements. To use the latest language features in older environments, you may need to install specific libraries. These dependencies are documented in the page for each specific version. You can learn more about the [relationships between language and library](relationships-between-language-and-library.md) for background on this dependency.

## C# version 11

*Released November, 2022*

The following features were added in C# 11:

- [Raw string literals](./csharp-11.md#raw-string-literals)
- [Generic math support](./csharp-11.md#generic-math-support)
- [Generic attributes](./csharp-11.md#generic-attributes)
- [UTF-8 string literals](./csharp-11.md#utf-8-string-literals)
- [Newlines in string interpolation expressions](./csharp-11.md#newlines-in-string-interpolations)
- [List patterns](./csharp-11.md#list-patterns)
- [File-local types](./csharp-11.md#file-local-types)
- [Required members](./csharp-11.md#required-members)
- [Auto-default structs](./csharp-11.md#auto-default-struct)
- [Pattern match `Span<char>` on a constant `string`](./csharp-11.md#pattern-match-spanchar-or-readonlyspanchar-on-a-constant-string)
- [Extended `nameof` scope](./csharp-11.md#extended-nameof-scope)
- [Numeric IntPtr](./csharp-11.md#numeric-intptr-and-uintptr)
- [`ref` fields and `scoped ref`](./csharp-11.md#ref-fields-and-ref-scoped-variables)
- [Improved method group conversion to delegate](./csharp-11.md#improved-method-group-conversion-to-delegate)
- [Warning wave 7](../language-reference/compiler-messages/warning-waves.md#cs8981---the-type-name-only-contains-lower-cased-ascii-characters)

C# 11 introduces *generic math* and several features that support that goal. You can write numeric algorithms once for all number types. There's more features to make working with `struct` types easier, like required members and auto-default structs. Working with strings gets easier with Raw string literals, newline in string interpolations, and UTF-8 string literals. Features like file local types enable source generators to be simpler. Finally, list patterns add more support for pattern matching.

## C# version 10

*Released November, 2021*

C# 10 adds the following features and enhancements to the C# language:

- [Record structs](./csharp-10.md#record-structs)
- [Improvements of structure types](./csharp-10.md#improvements-of-structure-types)
- [Interpolated string handlers](./csharp-10.md#interpolated-string-handler)
- [`global using` directives](./csharp-10.md#global-using-directives)
- [File-scoped namespace declaration](./csharp-10.md#file-scoped-namespace-declaration)
- [Extended property patterns](./csharp-10.md#extended-property-patterns)
- [Improvements on lambda expressions](./csharp-10.md#lambda-expression-improvements)
- [Allow `const` interpolated strings](./csharp-10.md#constant-interpolated-strings)
- [Record types can seal `ToString()`](./csharp-10.md#record-types-can-seal-tostring)
- [Improved definite assignment](./csharp-10.md#improved-definite-assignment)
- [Allow both assignment and declaration in the same deconstruction](./csharp-10.md#assignment-and-declaration-in-same-deconstruction)
- [Allow `AsyncMethodBuilder` attribute on methods](./csharp-10.md#allow-asyncmethodbuilder-attribute-on-methods)
- [CallerArgumentExpression attribute](./csharp-10.md#callerargumentexpression-attribute-diagnostics)
- [Enhanced `#line` pragma](./csharp-10.md#enhanced-line-pragma)

More features were available in *preview* mode. In order to use these features, you must [set `<LangVersion>` to `Preview`](../language-reference/compiler-options/language.md#langversion) in your project:

- [Generic attributes](./csharp-11.md#generic-attributes) later in this article.
- [static abstract members in interfaces](./csharp-11.md#generic-math-support)

C# 10 continues work on themes of removing ceremony, separating data from algorithms, and improved performance for the .NET Runtime.

Many of the features mean you'll type less code to express the same concepts. *Record structs* synthesize many of the same methods that *record classes* do. Structs and anonymous types support *with expressions*. *Global using directives* and *file scoped namespace declarations* mean you express dependencies and namespace organization more clearly. *Lambda improvements* makes it easier to declare lambda expressions where they're used. New property patterns and deconstruction improvements create more concise code.

The new interpolated string handlers and `AsyncMethodBuilder` behavior can improve performance. These language features were applied in the .NET Runtime to achieve performance improvements in .NET 6.

C# 10 also marks more of a shift to the yearly cadence for .NET releases. Because not every feature can be completed in a yearly timeframe, you can try a couple of "preview" features in C# 10. Both *generic attributes* and *static abstract members in interfaces* can be used, but these preview features may change before their final release.

## C# version 9

*Released November, 2020*

C# 9 was released with .NET 5. It's the default language version for any assembly that targets the .NET 5 release. It contains the following new and enhanced features:

- [Records](./csharp-9.md#record-types)
- [Init only setters](./csharp-9.md#init-only-setters)
- [Top-level statements](./csharp-9.md#top-level-statements)
- [Pattern matching enhancements](./csharp-9.md#pattern-matching-enhancements)
- [Performance and interop](./csharp-9.md#performance-and-interop)
  - [Native sized integers](~/_csharplang/proposals/csharp-9.0/native-integers.md)
  - [Function pointers](~/_csharplang/proposals/csharp-9.0/function-pointers.md)
  - [Suppress emitting localsinit flag](~/_csharplang/proposals/csharp-9.0/skip-localsinit.md)
- [Fit and finish features](./csharp-9.md#fit-and-finish-features)
  - [Target-typed `new` expressions](~/_csharplang/proposals/csharp-9.0/target-typed-new.md)
  - [`static` anonymous functions](~/_csharplang/proposals/csharp-9.0/static-anonymous-functions.md)
  - [Target-typed conditional expressions](~/_csharplang/proposals/csharp-9.0/target-typed-conditional-expression.md)
  - [Covariant return types](~/_csharplang/proposals/csharp-9.0/covariant-returns.md)
  - [Extension `GetEnumerator` support for `foreach` loops](~/_csharplang/proposals/csharp-9.0/extension-getenumerator.md)
  - [Lambda discard parameters](~/_csharplang/proposals/csharp-9.0/lambda-discard-parameters.md)
  - [Attributes on local functions](~/_csharplang/proposals/csharp-9.0/local-function-attributes.md)
- [Support for code generators](./csharp-9.md#support-for-code-generators)
  - [Module initializers](~/_csharplang/proposals/csharp-9.0/module-initializers.md)
  - [New features for partial methods](~/_csharplang/proposals/csharp-9.0/extending-partial-methods.md)

C# 9 continues three of the themes from previous releases: removing ceremony, separating data from algorithms, and providing more patterns in more places.

[Top level statements](../fundamentals/program-structure/top-level-statements.md) means your main program is simpler to read. There's less need for ceremony: a namespace, a `Program` class, and `static void Main()` are all unnecessary.

The introduction of [`records`](../language-reference/builtin-types/record.md) provides a concise syntax for reference types that follow value semantics for equality. You'll use these types to define data containers that typically define minimal behavior. [Init-only setters](./csharp-9.md#init-only-setters) provide the capability for non-destructive mutation (`with` expressions) in records. C# 9 also adds [covariant return types](~/_csharplang/proposals/csharp-9.0/covariant-returns.md) so that derived records can override virtual methods and return a type derived from the base method's return type.

The [pattern matching](../fundamentals/functional/pattern-matching.md) capabilities have been expanded in several ways. Numeric types now support *range patterns*. Patterns can be combined using `and`, `or`, and `not` patterns. Parentheses can be added to clarify more complex patterns.

Another set of features supports high-performance computing in C#:

- The `nint` and `nuint` types model the native-size integer types on the target CPU.
- [Function pointers](../language-reference/unsafe-code.md#function-pointers) provide delegate-like functionality while avoiding the allocations necessary to create a delegate object.
- The `localsinit` instruction can be omitted to save instructions.

Another set of improvements supports scenarios where *code generators* add functionality:

- [Module initializers](../language-reference/attributes/general.md#moduleinitializer-attribute) are methods that the runtime calls when an assembly loads.
- [Partial methods](../language-reference/keywords/partial-method.md) support new accessibly modifiers and non-void return types. In those cases, an implementation must be provided.

C# 9 adds many other small features that improve developer productivity, both writing and reading code:

- Target-type `new` expressions
- `static` anonymous functions
- Target-type conditional expressions
- Extension `GetEnumerator()` support for `foreach` loops
- Lambda expressions can declare discard parameters
- Attributes can be applied to local functions

The C# 9 release continues the work to keep C# a modern, general-purpose programming language. Features continue to support modern workloads and application types.

## C# version 8.0

*Released September, 2019*

C# 8.0 is the first major C# release that specifically targets .NET Core. Some features rely on new CLR capabilities, others on library types added only in .NET Core. C# 8.0 adds the following features and enhancements to the C# language:

- [Readonly members](../language-reference/builtin-types/struct.md#readonly-instance-members)
- [Default interface methods](../language-reference/keywords/interface.md#default-interface-members)
- [Pattern matching enhancements](../language-reference/operators/patterns.md):
  - Switch expressions
  - Property patterns
  - Tuple patterns
  - Positional patterns
- [Using declarations](../language-reference/keywords/using-directive.md)
- [Static local functions](../programming-guide/classes-and-structs/local-functions.md)
- [Disposable ref structs](../language-reference/builtin-types/ref-struct.md)
- [Nullable reference types](../language-reference/builtin-types/nullable-reference-types.md)
- [Asynchronous streams](../language-reference/statements/iteration-statements.md#await-foreach)
- [Indices and ranges](../language-reference/operators/member-access-operators.md#range-operator-)
- [Null-coalescing assignment](../language-reference/operators/assignment-operator.md#null-coalescing-assignment)
- [Unmanaged constructed types](../language-reference/keywords/where-generic-type-constraint.md)
- [Stackalloc in nested expressions](../language-reference/operators/stackalloc.md)
- [Enhancement of interpolated verbatim strings](../language-reference/tokens/interpolated.md)

Default interface members require enhancements in the CLR. Those features were added in the CLR for .NET Core 3.0. Ranges and indexes, and asynchronous streams require new types in the .NET Core 3.0 libraries. Nullable reference types, while implemented in the compiler, is much more useful when libraries are annotated to provide semantic information regarding the null state of arguments and return values. Those annotations are being added in the .NET Core libraries.

## C# version 7.3

*Released May, 2018*

There are two main themes to the C# 7.3 release. One theme provides features that enable safe code to be as performant as unsafe code. The second theme provides incremental improvements to existing features. New compiler options were also added in this release.

The following new features support the theme of better performance for safe code:

- You can access fixed fields without pinning.
- You can reassign `ref` local variables.
- You can use initializers on `stackalloc` arrays.
- You can use `fixed` statements with any type that supports a pattern.
- You can use more generic constraints.

The following enhancements were made to existing features:

- You can test `==` and `!=` with tuple types.
- You can use expression variables in more locations.
- You may attach attributes to the backing field of auto-implemented properties.
- Method resolution when arguments differ by `in` has been improved.
- Overload resolution now has fewer ambiguous cases.

The new compiler options are:

- [`-publicsign`](../language-reference/compiler-options/security.md#publicsign) to enable Open Source Software (OSS) signing of assemblies.
- [`-pathmap`](../language-reference/compiler-options/advanced.md#pathmap) to provide a mapping for source directories.

## C# version 7.2

*Released November, 2017*

C# 7.2 added several small language features:

- Initializers on `stackalloc` arrays.
- Use `fixed` statements with any type that supports a pattern.
- Access fixed fields without pinning.
- Reassign `ref` local variables.
- Declare `readonly struct` types, to indicate that a struct is immutable and should be passed as an `in` parameter to its member methods.
- Add the `in` modifier on parameters, to specify that an argument is passed by reference but not modified by the called method.
- Use the `ref readonly` modifier on method returns, to indicate that a method returns its value by reference but doesn't allow writes to that object.
- Declare `ref struct` types, to indicate that a struct type accesses managed memory directly and must always be stack allocated.
- Use additional generic constraints.
- [Non-trailing named arguments](../programming-guide/classes-and-structs/named-and-optional-arguments.md)
  - Named arguments can be followed by positional arguments.
- Leading underscores in numeric literals
  - Numeric literals can now have leading underscores before any printed digits.
- [`private protected` access modifier](../language-reference/keywords/access-modifiers.md)
  - The `private protected` access modifier enables access for derived classes in the same assembly.
- Conditional `ref` expressions
  - The result of a conditional expression (`?:`) can now be a reference.

## C# version 7.1

*Released August, 2017*

C# started releasing *point releases* with C# 7.1. This version added the [language version selection](../language-reference/configure-language-version.md) configuration element, three new language features, and new compiler behavior.

The new language features in this release are:

- [`async` `Main` method](../fundamentals/program-structure/main-command-line.md)
  - The entry point for an application can have the `async` modifier.
- [`default` literal expressions](../language-reference/operators/default.md#default-literal)
  - You can use default literal expressions in default value expressions when the target type can be inferred.
- Inferred tuple element names
  - The names of tuple elements can be inferred from tuple initialization in many cases.
- Pattern matching on generic type parameters
  - You can use pattern match expressions on variables whose type is a generic type parameter.

Finally, the compiler has two options [`-refout`](../language-reference/compiler-options/output.md#producereferenceassembly) and [`-refonly`](../language-reference/compiler-options/code-generation.md#produceonlyreferenceassembly) that
control reference assembly generation

## C# version 7.0

*Released March, 2017*

C# version 7.0 was released with Visual Studio 2017. This version has some evolutionary and cool stuff in the vein of C# 6.0. Here are some of the new features:

- Out variables
- [Tuples and deconstruction](../language-reference/builtin-types/value-tuples.md)
- [Pattern matching](../fundamentals/functional/pattern-matching.md)
- [Local functions](../programming-guide/classes-and-structs/local-functions.md)
- [Expanded expression bodied members](../programming-guide/statements-expressions-operators/expression-bodied-members.md)
- [Ref locals](../language-reference/statements/declarations.md#ref-locals)
- [Ref returns](../language-reference/statements/jump-statements.md#ref-returns)

Other features included:

- [Discards](../fundamentals/functional/discards.md)
- Binary Literals and Digit Separators
- [Throw expressions](../language-reference/keywords/throw.md#the-throw-expression)

All of these features offer new capabilities for developers and the opportunity to write cleaner code than ever. A highlight is condensing the declaration of variables to use with the `out` keyword and by allowing multiple return values via tuple. .NET Core now targets any operating system and has its eyes firmly on the cloud and on portability. These new capabilities certainly occupy the language designers' thoughts and time, in addition to coming up with new features.

## C# version 6.0

*Released July, 2015*

Version 6.0, released with Visual Studio 2015, released many smaller features that made C# programming more productive. Here are some of them:

- [Static imports](../language-reference/keywords/using-directive.md)
- [Exception filters](../language-reference/keywords/when.md)
- [Auto-property initializers](../properties.md)
- [Expression bodied members](../language-reference/operators/lambda-operator.md#expression-body-definition)
- [Null propagator](../language-reference/operators/member-access-operators.md#null-conditional-operators--and-)
- [String interpolation](../language-reference/tokens/interpolated.md)
- [nameof operator](../language-reference/operators/nameof.md)

Other new features include:

- Index initializers
- Await in catch/finally blocks
- Default values for getter-only properties

Each of these features is interesting in its own right. But if you look at them altogether, you see an interesting pattern. In this version, C# started to eliminate language boilerplate to make code more terse and readable. So for fans of clean, simple code, this language version was a huge win.

They did one other thing along with this version, though it's not a traditional language feature in itself. They released [Roslyn the compiler as a service](https://github.com/dotnet/roslyn). The C# compiler is now written in C#, and you can use the compiler as part of your programming efforts.

## C# version 5.0

*Released August, 2012*

C# version 5.0, released with Visual Studio 2012, was a focused version of the language. Nearly all of the effort for that version went into another groundbreaking language concept: the `async` and `await` model for asynchronous programming.  Here's the major features list:

- [Asynchronous members](../asynchronous-programming/index.md)
- [Caller info attributes](../language-reference/attributes/caller-information.md)
- [Code Project: Caller Info Attributes in C# 5.0](https://www.codeproject.com/Tips/606379/Caller-Info-Attributes-in-Csharp)

The caller info attribute lets you easily retrieve information about the context in which you're running without resorting to a ton of boilerplate reflection code. It has many uses in diagnostics and logging tasks.

But `async` and `await` are the real stars of this release. When these features came out in 2012, C# changed the game again by baking asynchrony into the language as a first-class participant. If you've ever dealt with long running operations and the implementation of webs of callbacks, you probably loved this language feature.

## C# version 4.0

*Released April, 2010*

C# version 4.0, released with Visual Studio 2010, would have had a difficult time living up to the groundbreaking status of version 3.0. This version introduced some interesting new features:

- [Dynamic binding](../language-reference/builtin-types/reference-types.md)
- [Named/optional arguments](../programming-guide/classes-and-structs/named-and-optional-arguments.md)
- [Generic covariant and contravariant](../../standard/generics/covariance-and-contravariance.md)
- [Embedded interop types](../../framework/interop/type-equivalence-and-embedded-interop-types.md)

Embedded interop types eased the deployment pain of creating COM interop assemblies for your application. Generic covariance and contravariance give you more power to use generics, but they're a bit academic and probably most appreciated by framework and library authors. Named and optional parameters let you eliminate many method overloads and provide convenience. But none of those features are exactly paradigm altering.

The major feature was the introduction of the `dynamic` keyword. The `dynamic` keyword introduced into C# version 4.0 the ability to override the compiler on compile-time typing. By using the dynamic keyword, you can create constructs similar to dynamically typed languages like JavaScript. You can create a `dynamic x = "a string"` and then add six to it, leaving it up to the runtime to sort out what should happen next.

Dynamic binding gives you the potential for errors but also great power within the language.

## C# version 3.0

*Released November, 2007*

C# version 3.0 came in late 2007, along with Visual Studio 2008, though the full boat of language features would actually come with .NET Framework version 3.5. This version marked a major change in the growth of C#. It established C# as a truly formidable programming language. Let's take a look at some major features in this version:

- [Auto-implemented properties](../programming-guide/classes-and-structs/auto-implemented-properties.md)
- [Anonymous types](../fundamentals/types/anonymous-types.md)
- [Query expressions](../linq/query-expression-basics.md)
- [Lambda expressions](../language-reference/operators/lambda-expressions.md)
- [Expression trees](/dotnet/csharp/advanced-topics/expression-trees)
- [Extension methods](../programming-guide/classes-and-structs/extension-methods.md)
- [Implicitly typed local variables](../language-reference/statements/declarations.md#implicitly-typed-local-variables)
- [Partial methods](../language-reference/keywords/partial-method.md)
- [Object and collection initializers](../programming-guide/classes-and-structs/object-and-collection-initializers.md)

In retrospect, many of these features seem both inevitable and inseparable. They all fit together strategically. It's thought that C# version's killer feature was the query expression, also known as Language-Integrated Query (LINQ).

A more nuanced view examines expression trees, lambda expressions, and anonymous types as the foundation upon which LINQ is constructed. But, in either case, C# 3.0 presented a revolutionary concept. C# 3.0 had begun to lay the groundwork for turning C# into a hybrid Object-Oriented / Functional language.

Specifically, you could now write SQL-style, declarative queries to perform operations on collections, among other things. Instead of writing a `for` loop to compute the average of a list of integers, you could now do that as simply as `list.Average()`. The combination of query expressions and extension methods made a list of integers a whole lot smarter.

## C# version 2.0

*Released November, 2005*

Let's take a look at some major features of C# 2.0, released in 2005, along with Visual Studio 2005:

- [Generics](../fundamentals/types/generics.md)
- [Partial types](../programming-guide/classes-and-structs/partial-classes-and-methods.md#partial-classes)
- [Anonymous methods](../language-reference/operators/delegate-operator.md)
- [Nullable value types](../language-reference/builtin-types/nullable-value-types.md)
- [Iterators](../programming-guide/concepts/iterators.md)
- [Covariance and contravariance](../programming-guide/concepts/covariance-contravariance/index.md)

Other C# 2.0 features added capabilities to existing features:

- Getter/setter separate accessibility
- Method group conversions (delegates)
- Static classes
- Delegate inference

While C# may have started as a generic Object-Oriented (OO) language, C# version 2.0 changed that in a hurry. With generics, types and methods can operate on an arbitrary type while still retaining type safety. For instance, having a <xref:System.Collections.Generic.List%601> lets you have `List<string>` or `List<int>` and perform type-safe operations on those strings or integers while you iterate through them. Using generics is better than creating a `ListInt` type that derives from `ArrayList`  or casting from `Object` for every operation.

C# version 2.0 brought iterators. To put it succinctly, iterators let you examine all the items in a `List` (or other Enumerable types) with a `foreach` loop. Having iterators as a first-class part of the language dramatically enhanced readability of the language and people's ability to reason about the code.

And yet, C# continued to play a bit of catch-up with Java. Java had already released versions that included generics and iterators. But that would soon change as the languages continued to evolve apart.

## C# version 1.2

*Released April, 2003*

C# version 1.2 shipped with Visual Studio .NET 2003. It contained a few small enhancements to the language. Most notable is that starting with this version, the code generated in a `foreach` loop called <xref:System.IDisposable.Dispose%2A> on an <xref:System.Collections.IEnumerator> when that <xref:System.Collections.IEnumerator> implemented <xref:System.IDisposable>.

## C# version 1.0

*Released January, 2002*

When you go back and look, C# version 1.0, released with Visual Studio .NET 2002, looked a lot like Java. As [part of its stated design goals for ECMA](https://feeldotneteasy.blogspot.com/2011/01/c-design-goals.html), it sought to be a "simple, modern, general-purpose object-oriented language."  At the time, looking like Java meant it achieved those early design goals.

But if you look back on C# 1.0 now, you'd find yourself a little dizzy. It lacked the built-in async capabilities and some of the slick functionality around generics you take for granted. As a matter of fact, it lacked generics altogether.  And [LINQ](../linq/index.md)? Not available yet. Those additions would take some years to come out.

C# version 1.0 looked stripped of features, compared to today. You'd find yourself writing some verbose code. But yet, you have to start somewhere. C# version 1.0 was a viable alternative to Java on the Windows platform.

The major features of C# 1.0 included:

- [Classes](../fundamentals/types/classes.md)
- [Structs](../language-reference/builtin-types/struct.md)
- [Interfaces](../fundamentals/types/interfaces.md)
- [Events](../events-overview.md)
- [Properties](../properties.md)
- [Delegates](../delegates-overview.md)
- [Operators and expressions](../language-reference/operators/index.md)
- [Statements](../programming-guide/statements-expressions-operators/statements.md)
- [Attributes](/dotnet/csharp/advanced-topics/reflection-and-attributes)

_Article_ [_originally published on the NDepend blog_](https://blog.ndepend.com/c-versions-look-language-history/)_, courtesy of Erik Dietrich and Patrick Smacchia._
