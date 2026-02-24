# Content for everyday C# #

***Everyday C#*** is the next step in learning after the "get started" material. These constructs are used in all workloads, so they apply to everyone learning C#.  Developers familiar with C# can use this material as a refresher or to update their skills.

*Everyday C#* teaches the reader the language constructs that (almost) every C# developer uses (almost) everyday. These are the techniques and constructs that are at your fingertips for many tasks. The purpose is to give the reader enough skills in C# concepts that after finishing, a reader should be ready for an entry level programming role. (Those readers that have previous programming experience would be ready for a more senior role using C#). The reader has made the decision to learn C# and .NET, but doesn't have experience with either yet. This section focuses on concepts that apply to any .NET Workload. The reader should be able to complete this entire section in a month. To achieve these goals, this section adheres to the following guidelines:

- **Use the latest version**: Readers should be using the latest version of C#.
- **Avoid specialized techniques**: Readers may later focus on any given workload. Samples or examples that require significant knowledge of a given workload will lose readers.
- **Prefer recent concepts**: In almost all cases, there are multiple ways to write code for a given scenario. In our docs, we should prefer the modern syntax.
- **Build robust examples**: Readers need to learn how to write code for a professional use. That means these samples should demonstrate resilient coding practices.

Upon finishing this section, the reader is confident reading and writing C#. They should be familiar with the expressions and statements up to and including the latest C# version. This includes areas like query expressions (LINQ), pattern matching expressions, and range and index expressions. They know common types in the BCL and can find others with reasonable searches for assemblies, namespaces and NuGet packages. They should be confident creating types. They should be confident deciding if a new type should be a `record`, `record struct`, `struct` or `class`. They should be able to create interfaces for common contracts. They can continue to explore a single workload, or one of the later "focus" areas of the C# Guide.

## Curriculum

The following is an outline of the *Everyday C#* curriculum. It is not a complete syllabus. It has enough of an abstract for each section to begin writing that section.

- **Intro / hello world**: This section ensures that the reader has the correct tools installed, and can build and run applications locally. This section will use zone pivots to make it easier for readers on different operating systems. We'll gently Visual Studio on both PC and Mac, and VS Code on Linux. If developers prefer VS Code, they can use that pivot.
  - *Objective*: The developer has installed necessary tools, built their first local application, and explored some C# syntax.
- **Code in methods**: This section focuses on the elements of the C# language that developers use when they write the implementation of any method, local function, or property / indexer accessor. This section is the most changed by updating the "inner loop" coding tasks to use newer features. The techniques covered, and the samples will focus on using the latest features to write the most concise, readable code. The modules include:
  - `string` type, and string interpolation.
  - Numeric types, with a focus on `int`, and `decimal`.
  - Working with collections, ranges and indexes. The samples will use Arrays, `List<T>`, and `Dictionary<K, V>`. This module will include using index and range types to access elements and slices of collections. This will include loops to enumerate sequences (`foreach`, `while`, `for` and `do` - `while`).
  - Query expressions and LINQ. Cover query syntax, fluent syntax, enumerating and transforming sequences. Lambda expressions are introduced here.
  - Pattern matching. Introduce pattern matching as a way to write expression- based logic over imperative branching. This won't exhaustively cover all patterns, but instead provide several examples for type checking, property checking, and list patterns.
  - Imperative branching (if, else, switch)
  - async methods, awaiting method calls. This is an introduction to these features: Adding `async` on a method declaration, ensuring the return type is `Task`, `Task<T>`, and using `await` whenever calling an async method. In addition, introduce async enumerables to enumerate asynchronous data sources.
  - While not called out, samples will prefer the following features over alternatives:
    - top level statements and implicit usings
    - target-typed `new`
    - `default` is preferred over `default(type)` or `null` / 0.
    - `using` statements over `using` blocks.
    - `using` directive without `{ }`
    - auto-implemented properties, with initializers
    - `".`, `??=` and `is not null` for null safety.
    - `with` expressions, discards, and deconstruction
    - local functions
- Not every idiom is covered in detail. For the "everyday C#" section, the most common scenarios are covered. There will be links to more in depth coverage of those areas. Second, some idioms aren't covered in everyday C# section at all. Some of those are techniques that aren't use in the most common scenarios. Others are techniques that were more common in earlier versions of C#.
- *Objective*: The developer feels comfortable writing code that implements their algorithms. It may not be the most performant, but is readable, and generally correct.
- **Program structure and types**: As programs grow, all the techniques that organize code become important: assemblies, namespaces, types (classes, structs, interfaces, records), and generics.
  - Organizing programs: Explain the rationale to organize code as your program or library grows. Introduce the concepts to organize data and code into conceptual and physical packages.
  - Defining types: One article to explain why C# programs are organized around creating types that map to concepts. This will introduce the concepts of reference types and value types.
  - Tuples and records: These are the simplest data structures. Introduce them next. This won't cover every feature of records (namely, adding methods and behavior won't be covered).
  - Structs: Slightly more complicated than records, so introduce them here.
  - Classes: Add classes, and tie together the concepts of tuples, `record`, `record struct` and `struct`. Propose guidelines for deciding when to use which.
  - Interfaces: Explain interfaces as a mechanism to build common contracts among distinct types. This doesn't cover more advanced features such as interface members.
  - Generics: The reader will have seen the basics of generics in the examples using `List<T>` and `Dictionary<K, V>`. In this unit, add more of scenarios where developers will use and create generic methods and types.
  - namespaces: The reader will have seen some namespaces in earlier content. Here, explain how you can organize your code using namespaces.
  - lambda expressions for callbacks and events: Introduce the concept of callbacks, raising events, and the syntax behind those concepts. Lambdas were introduced with LINQ. This module will expand on those uses.
  - Encapsulation, composition, Polymorphism: Finish with an introduction to these OO concepts.
  - *Objective*: The developer feels more comfortable working in a larger codebase, understands OO concepts, and can express more larger scale designs in C#.
- **Resilient code**: This unit introduces techniques to create code that's resilient when errors occur. The syntax for throwing and catching exceptions are covered, as are techniques to avoid corrupt data or results due to how exceptions are handled. The following topics are covered:
  - throwing exceptions: How to indicate failures using exceptions.
  - catching exceptions: How to declare and use catch clauses when an exception can be handled.
  - avoiding corrupt data: Finally clauses for memory cleanup, and code structure to minimize data corruption when exceptions occur.
  - *Objective*: The developer can follow the general design guidelines for throwing exceptions, using finally clauses, and catching exceptions when recovery is possible.
- **Coding style**: This article will provide a basic set of coding guidelines. It won't be a complete set of guidelines and will focus on common techniques to write correct code. This will cover some of the most common naming conventions for types, fields, properties, and methods. It will stress guidelines for correctness (prefering braces for if / else in all cases). It will try and avoid more opinionated standards such as when to use `var`.
- *Objective*: The developer can write code that generally conforms to the most common guidelines. Customers can point to these guidelines as a reasonable starting point for their own standards.
- **XML documentation**: The final article provides a first example of using XML comments to generate documentation. It will link to the language reference section for a more complete treatment.
- *Objective*: The developer can annotate their code with reasonable starting documentation comments.

After finishing the content in this section, a developer should be reasonably prepared for an entry level coding position.

## Areas outside of scope

The everyday C# section excludes many C# elements and techniques in order to focus on the most common techniques. This list explains why many areas of the language aren't covered in this section. (They are covered elsewhere in the C# guide.) The everyday C# section will link to the details on these sections for readers that want more depth on those techniques.

- **Techniques with improved alternatives**: As C# grows, there are multiple code constructs for the same results. Rather than explain all alternatives, the everyday C# section will generally exclude the following.
  - Anonymous types: Developers should prefer tuples.
  - Imperative null-checks: In today's world, use `!!`, `?.`, `??=`, and `is null` for as many as possible. All the everyday C# samples will have NRT enabled. Using `if` branches on null checks will be avoided.
  - Non-generic collections.
  - Defining delegate types, `new` delegate object won't be used. Instead, assign lambda expressions to `Func` or `Action` types.
  - Defining methods specifically for delegates. We may assign a delegate to a method group, but wont' encourage creating a method *for* use in a delegate.
  - `as`, casts:  the pattern matching `is` expression is a better solution.
  - `static void Main()`. We want developers to see the new top-level statements feature in more tutorials. The equivalent syntax will be explained because of the history, abundance of code already using the traditional entry point, and some scenarios that require a user-declared entrypoint.
- **Features that aren't in common scenarios**: These features aren't used in the common scenarios that beginners will encounter.
  - default interface members
  - static abstract interface methods
  - pass-by-reference and pass-by-value, `ref` returns: These are less common for most scenarios.
  - `ref struct`, `in` arguments, `readonly ref`: Fundamentals will consume them, but without explanation on the nuances of pass by reference, and readonly references.
  - `stackalloc`, `unsafe` `Span<T>`, `fixed`. These aren't used in many common scenarios.
  - `dynamic`
  - async techniques *other than* `Task`, `async` and `await`. fThis includes adding `ConfigureAwait` to async calls.
  - `lock`: Fundamentals will avoid parallelism.
  - `volatile`.
  - Partial methods and classes: Not as useful for core scenarios.
  - `nint`, `nuint`: These are specialized for native scenarios.
  - `goto`, `continue`, `break` (except in `switch` statements): These are less common, and can be confusing for beginners.
  - operator overloading: The everyday C# section will consume overloaded operators, but won't define them.
  - multi-targeting (.NET standard, etc)
  - Native interop: These aren't common scenarios.
  - The distinctions between `IQueryable` and `IEnumerable`. These become more important for more complicated queries than will be covered in the everyday C# section.
