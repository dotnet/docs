---
title: ".NET docs: What's new for .NET 9"
description: "What's new in the .NET docs for .NET 9."
ms.custom: October-2024
ms.date: 11/11/2024
---

# .NET docs: What's new for .NET 9

This article lists some of the major changes to docs for .NET 9.

## .NET security

### Updated articles

- [Cross-Platform Cryptography in .NET](../standard/security/cross-platform-cryptography.md) - Crypto docs

## .NET breaking changes

### New articles

- [Breaking changes in .NET 9](../core/compatibility/9.0.md)
- [`dotnet workload` commands output change](../core/compatibility/sdk/9.0/dotnet-workload-output.md)
- [`GetXmlNamespaceMaps` type change](../core/compatibility/wpf/9.0/xml-namespace-maps.md)
- [`installer` repo version no longer included in `productcommits` files](../core/compatibility/sdk/9.0/productcommits-versions.md)
- [API obsoletions with non-default diagnostic IDs (.NET 9)](../core/compatibility/core-libraries/9.0/obsolete-apis-with-custom-diagnostics.md)
- [BindingSource.SortDescriptions doesn't return null](../core/compatibility/windows-forms/9.0/sortdescriptions-return-value.md)
- [Breaking changes in .NET 9](../core/compatibility/9.0.md)
- [Changes to nullability annotations (Windows Forms)](../core/compatibility/windows-forms/9.0/nullability-changes.md)
- [ComponentDesigner.Initialize throws ArgumentNullException](../core/compatibility/windows-forms/9.0/componentdesigner-initialize.md)
- [Creating type of array of System.Void not allowed](../core/compatibility/core-libraries/9.0/type-instance.md)
- [DataGridViewRowAccessibleObject.Name starting row index](../core/compatibility/windows-forms/9.0/datagridviewrowaccessibleobject-name-row.md)
- [Default `Equals()` and `GetHashCode()` throw for types marked with `InlineArrayAttribute`](../core/compatibility/core-libraries/9.0/inlinearrayattribute.md)
- [DefaultKeyResolution.ShouldGenerateNewKey has altered meaning](../core/compatibility/aspnet-core/9.0/key-resolution.md)
- [Deprecated desktop Windows/macOS/Linux MonoVM runtime packages](../core/compatibility/deployment/9.0/monovm-packages.md)
- [Floating point-to-integer conversions are saturating](../core/compatibility/jit/9.0/fp-to-integer.md)
- [HttpListenerRequest.UserAgent is nullable](../core/compatibility/networking/9.0/useragent-nullable.md)
- [In-box BinaryFormatter implementation removed and always throws](../core/compatibility/serialization/9.0/binaryformatter-removal.md)
- [Inline array struct size limit is enforced](../core/compatibility/core-libraries/9.0/inlinearray-size.md)
- [InMemoryDirectoryInfo prepends rootDir to files](../core/compatibility/core-libraries/9.0/inmemorydirinfo-prepends-rootdir.md)
- [No exception if DataGridView is null](../core/compatibility/windows-forms/9.0/datagridviewheadercell-nre.md)
- [PictureBox raises HttpClient exceptions](../core/compatibility/windows-forms/9.0/httpclient-exceptions.md)
- [RuntimeHelpers.GetSubArray returns different type](../core/compatibility/core-libraries/9.0/getsubarray-return.md)
- [Support for empty environment variables](../core/compatibility/core-libraries/9.0/empty-env-variable.md)
- [Terminal logger is default](../core/compatibility/sdk/9.0/terminal-logger.md)
- [Warning emitted for .NET Standard 1.x targets](../core/compatibility/sdk/9.0/netstandard-warning.md)

## .NET fundamentals

### New articles

- [CA2022: Avoid inexact read with Stream.Read](../fundamentals/code-analysis/quality-rules/ca2022.md)
- [CA2265: Do not compare `Span<T>` to `null` or `default`](../fundamentals/code-analysis/quality-rules/ca2265.md)
- [Configuration source generator](../core/extensions/configuration-generator.md)

### Updated articles

- [.NET Standard](../standard/net-standard.md)
- [Code quality rules](../fundamentals/code-analysis/quality-rules/index.md)
- [Configuration in .NET](../core/extensions/configuration.md) - Add content for config source gen with interceptors
- [Obsolete features in .NET 5+](../fundamentals/syslib-diagnostics/obsoletions-overview.md) - Update diagnostic docs for SYSLIB0009
- [Overview of .NET source code analysis](../fundamentals/code-analysis/overview.md)
- [Synchronizing data for multithreading](../standard/threading/synchronizing-data-for-multithreading.md) - Add language reference for `lock`
- [SYSLIB0009: AuthenticationManager is not supported](../fundamentals/syslib-diagnostics/syslib0009.md) - Update diagnostic docs for SYSLIB0009
- [What's new in the SDK and tooling for .NET 9](../core/whats-new/dotnet-9/sdk.md)

## C# language

### New articles

- [Errors and warnings associated with `ref struct` types](../csharp/language-reference/compiler-messages/ref-struct-errors.md)
- [Errors and warnings related to `partial` type and `partial` member declarations](../csharp/language-reference/compiler-messages/partial-declarations.md)
- [Errors and warnings related to the `lock` statement and thread synchronization](../csharp/language-reference/compiler-messages/lock-semantics.md)
- [Errors and warnings related to the `params` modifier on method parameters](../csharp/language-reference/compiler-messages/params-arrays.md)
- [Errors and warnings related to the `yield return` statement and iterator methods](../csharp/language-reference/compiler-messages/iterator-yield.md)
- [Partial member (C# Reference)](../csharp/language-reference/keywords/partial-member.md)
- [Resolve errors and warnings that affect overload resolution.](../csharp/language-reference/compiler-messages/overload-resolution.md)
- [What's new in C# 13](../csharp/whats-new/csharp-13.md)

### Updated articles

- [interface (C# Reference)](../csharp/language-reference/keywords/interface.md) - Add reference and conceptual content for `ref struct` allowed in interfaces
- [`ref` structure types (C# reference)](../csharp/language-reference/builtin-types/ref-struct.md)
  - Add reference and conceptual content for `ref struct` allowed in interfaces
  - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
- [Access Modifiers (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/access-modifiers.md) - Add conceptual content for partial properties
- [Arithmetic operators (C# reference)](../csharp/language-reference/operators/arithmetic-operators.md) - Explain better conversion from collection expression
- [Assembly level attributes interpreted by the C# compiler](../csharp/language-reference/attributes/global.md) - Add reference and conceptual content for `ref struct` allowed in interfaces
- [Attributes](../csharp/advanced-topics/reflection-and-attributes/index.md) - Add conceptual content for partial properties
- [Automatically implemented properties](../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md) - Add conceptual content for partial properties
- [await operator - asynchronously await for a task to complete](../csharp/language-reference/operators/await.md) - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
- [C# Compiler Errors](../csharp/language-reference/compiler-messages/index.md) - Add errors and warnings for params arrays
- [C# Keywords](../csharp/language-reference/keywords/index.md)
  - Add conceptual content for partial properties
  - Add reference and conceptual content for `ref struct` allowed in interfaces
- [C# Warning waves](../csharp/language-reference/compiler-messages/warning-waves.md) - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
- [Collection expressions - C# language reference](../csharp/language-reference/operators/collection-expressions.md) - Explain better conversion from collection expression
- [Compiler Error CS0401](../csharp/misc/cs0401.md) - Add, update compiler error and warning messages for `ref struct` interfaces
- [Compiler Error CS1996](../csharp/language-reference/compiler-messages/cs1996.md) - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
- [Compiler Error CS4004](../csharp/language-reference/compiler-messages/cs4004.md) - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
- [Compiler Error CS8177](../csharp/language-reference/compiler-messages/cs8177.md) - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
- [Constraints on type parameters (C# Programming Guide)](../csharp/programming-guide/generics/constraints-on-type-parameters.md) - Add reference and conceptual content for `ref struct` allowed in interfaces
- [default value expressions - produce the default value](../csharp/language-reference/operators/default.md) - Explain better conversion from collection expression
- [Errors and warnings associated with `ref struct` types](../csharp/language-reference/compiler-messages/ref-struct-errors.md)
  - Add new diagnostics
  - Add, update compiler error and warning messages for `ref struct` interfaces
- [Errors and warnings associated with reference parameters, variables, and returns](../csharp/language-reference/compiler-messages/ref-modifiers-errors.md)
  - Add new diagnostics
  - Add, update compiler error and warning messages for `ref struct` interfaces
- [Errors and warnings related to the `yield return` statement and iterator methods](../csharp/language-reference/compiler-messages/iterator-yield.md)
  - Add errors and warnings related to `partial` properties and indexers
  - update and consolidate errors related to iterators and `yield`
- [Expression Trees](../csharp/advanced-topics/expression-trees/index.md) - Add conceptual content for partial properties
- [from clause (C# Reference)](../csharp/language-reference/keywords/from-clause.md) - Add conceptual content for partial properties
- [get (C# Reference)](../csharp/language-reference/keywords/get.md) - Add conceptual content for partial properties
- [How to handle an exception using try/catch](../csharp/fundamentals/exceptions/how-to-handle-an-exception-using-try-catch.md) - Add conceptual content for partial properties
- [How to initialize a dictionary with a collection initializer (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer.md) - Add params collections
- [How to initialize objects by using an object initializer (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer.md) - Add params collections
- [Indexers](../csharp/programming-guide/indexers/index.md) - Add conceptual content for partial properties
- [Indexers in Interfaces (C# Programming Guide)](../csharp/programming-guide/indexers/indexers-in-interfaces.md) - Add conceptual content for partial properties
- [Interface Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/interface-properties.md) - Add conceptual content for partial properties
- [Introduction to classes](../csharp/fundamentals/types/classes.md) - Add conceptual content for partial properties
- [Lambda expressions and anonymous functions](../csharp/language-reference/operators/lambda-expressions.md) - Add params collections
- [Member access operators and expressions - the dot, indexer, and invocation operators.](../csharp/language-reference/operators/member-access-operators.md)
  - Explain better conversion from collection expression
  - Add C# 13 small fixes
- [Method Parameters](../csharp/language-reference/keywords/method-parameters.md)
  - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
  - Add params collections
- [Methods in C\#](../csharp/methods.md) - Add params collections
- [Miscellaneous attributes interpreted by the C# compiler](../csharp/language-reference/attributes/general.md)
  - Add OverloadResolutionPriority conceptual documentation.
  - Add reference and conceptual content for `ref struct` allowed in interfaces
- [nameof expression (C# reference)](../csharp/language-reference/operators/nameof.md) - Explain better conversion from collection expression
- [new operator - The `new` operator creates a new instance of a type](../csharp/language-reference/operators/new-operator.md) - Explain better conversion from collection expression
- [Object and Collection Initializers (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md) - Add params collections
- [Partial Classes and Methods (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/partial-classes-and-methods.md) - Add conceptual content for partial properties
- [Partial type (C# Reference)](../csharp/language-reference/keywords/partial-type.md) - Add conceptual content for partial properties
- [Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/properties.md) - Add conceptual content for partial properties
- [Recommended XML tags for C# documentation comments](../csharp/language-reference/xmldoc/recommended-tags.md) - Add conceptual content for partial properties
- [Resolve errors and warnings generated from expressions prohibited in expression trees](../csharp/language-reference/compiler-messages/expression-tree-restrictions.md)
  - Add conceptual content for partial properties
  - Add errors and warnings for params arrays
- [Resolve errors and warnings in array and collection declarations and initialization expressions](../csharp/language-reference/compiler-messages/array-declaration-errors.md) - Add errors and warnings related to overload resolution
- [Resolve errors and warnings with inline array declarations](../csharp/language-reference/compiler-messages/inline-array-errors.md)
  - Add new diagnostics
  - Add conceptual content for partial properties
- [Resolve warnings related to language features and versions](../csharp/language-reference/compiler-messages/feature-version-errors.md)
  - Add new diagnostics
  - Add, update compiler error and warning messages for `ref struct` interfaces
- [Roadmap for Java developers learning C\#](../csharp/tour-of-csharp/tips-for-java-developers.md) - Add conceptual content for partial properties
- [select clause (C# Reference)](../csharp/language-reference/keywords/select-clause.md) - Add conceptual content for partial properties
- [set (C# Reference)](../csharp/language-reference/keywords/set.md) - Add conceptual content for partial properties
- [Standard .NET event patterns](../csharp/event-pattern.md) - Add conceptual content for partial properties
- [The `ref` keyword](../csharp/language-reference/keywords/ref.md) - Add, update compiler error and warning messages for `ref struct` interfaces
- [The C# type system](../csharp/fundamentals/types/index.md) - Add conceptual content for partial properties
- [The checked and unchecked statements (C# reference)](../csharp/language-reference/statements/checked-and-unchecked.md) - Explain better conversion from collection expression
- [The history of C\#](../csharp/whats-new/csharp-version-history.md) - Add conceptual content for partial properties
- [The lock statement - ensure exclusive access to a shared resource](../csharp/language-reference/statements/lock.md) - Add language reference for `lock`
- [Type-testing operators and cast expressions - `is`, `as`, `typeof` and casts](../csharp/language-reference/operators/type-testing-and-cast.md) - Explain better conversion from collection expression
- [Use string interpolation to construct formatted strings](../csharp/tutorials/exploration/interpolated-strings-local.md) - Add conceptual content for partial properties
- [Using indexers (C# Programming Guide)](../csharp/programming-guide/indexers/using-indexers.md) - Add conceptual content for partial properties
- [Using Properties (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/using-properties.md) - Add conceptual content for partial properties
- [where (generic type constraint) (C# Reference)](../csharp/language-reference/keywords/where-generic-type-constraint.md) - Add reference and conceptual content for `ref struct` allowed in interfaces
- [yield statement - provide the next element](../csharp/language-reference/statements/yield.md) - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
- [Compiler Errors on partial type and member declarations](../csharp/language-reference/compiler-messages/partial-declarations.md) - Add conceptual content for partial properties
- [Errors and warnings for iterator methods and `yield return`](../csharp/language-reference/compiler-messages/iterator-yield.md) - Add information for C# 13 feature `ref` locals and `unsafe` contexts in iterators and `async` methods
- [Errors and warnings related to `params` arrays](../csharp/language-reference/compiler-messages/params-arrays.md) - Add params collections

## .NET Framework

### Updated articles

- [Add Business Logic By Using Partial Methods](../framework/data/adonet/sql/linq/adding-business-logic-by-using-partial-methods.md) - Add conceptual content for partial properties
- [dangerousThreadingAPI MDA](../framework/debug-trace-profile/dangerousthreadingapi-mda.md) - Add language reference for `lock`
