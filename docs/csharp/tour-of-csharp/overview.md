---
title: Overview
description: New to C#? Learn the basics of the language. Start with this overview.
ms.date: 04/03/2024
---

# A tour of the C# language

The C# language is the most popular language for the [.NET platform](../index.yml), a free, cross-platform, open source development environment. C# programs can run on many different devices, from Internet of Things (IoT) devices to the cloud and everywhere in between. You can write apps for phone, desktop, and laptop computers and servers.

C# is a cross-platform general purpose language that makes developers productive while writing highly performant code. With millions of developers, C# is the most popular .NET language. C# has broad support in the ecosystem and all .NET [workloads](../../standard/glossary.md#workload). Based on object-oriented principles, it incorporates many features from other paradigms, not least functional programming. Low-level features support high-efficiency scenarios without writing unsafe code. Most of the .NET runtime and libraries are written in C#, and advances in C# often benefit all .NET developers.

## Hello world

The "Hello, World" program is traditionally used to introduce a programming language. Here it is in C#:

```csharp
// This line prints "Hello, World" 
Console.WriteLine("Hello, World");
```

The line starting with `//` is a *single line comment*. C# single line comments start with  `//` and continue to the end of the current line. C# also supports *multi-line comments*. Multi-line comments start with `/*` and end with `*/`. The `WriteLine` method of the `Console` class, which is in the `System` namespace, produces the output of the program. This class is provided by the standard class libraries, which, by default, are automatically referenced in every C# program.

The preceding example shows one form of a "Hello, World" program, using [top-level statements](../fundamentals/program-structure/top-level-statements.md). Earlier versions of C# required you to define the program's entry point in a method. This format is still valid, and you'll see it in many existing C# samples. You should be familiar with this form as well, as shown in the following example:

:::code language="csharp" interactive="try-dotnet" source="./snippets/shared/HelloWorld.cs":::

This version shows the building blocks you use in your programs. The "Hello, World" program starts with a `using` directive that references the `System` namespace. Namespaces provide a hierarchical means of organizing C# programs and libraries. Namespaces contain types and other namespaces—for example, the `System` namespace contains many types, such as the `Console` class referenced in the program, and many other namespaces, such as `IO` and `Collections`. A `using` directive that references a given namespace enables unqualified use of the types that are members of that namespace. Because of the `using` directive, the program can use `Console.WriteLine` as shorthand for `System.Console.WriteLine`. In the earlier example, that namespace was [implicitly](../language-reference/keywords/using-directive.md#the-global-modifier) included.

The `Hello` class declared by the "Hello, World" program has a single member, the method named `Main`. The `Main` method is declared with the `static` modifier. While instance methods can reference a particular enclosing object instance using the keyword `this`, static methods operate without reference to a particular object. By convention, when there are no top-level statements a static method named `Main` serves as the [entry point](../fundamentals/program-structure/main-command-line.md) of a C# program.

Both entry point forms produce equivalent code. When you use top-level statements, the compiler synthesizes the containing class and method for the program's entry point.

> [!TIP]
> The examples in this article give you a first look at C# code. Some samples may show elements of C# that you're not familiar with. When you're ready to learn C#, start with our [beginner tutorials](./tutorials/index.md), or dive into the links in each section. If you're experienced in [Java](./tips-for-java-developers.md), [JavaScript](./tips-for-javascript-developers.md), [TypeScript](./tips-for-javascript-developers.md) or [Python](./tips-for-python-developers.md), read our tips to help you find the information you need to quickly learn C#.

## Familiar C# features

C# is approachable for beginners yet offers advanced features for experienced developers writing specialized applications. You can be productive quickly. You can learn more specialized techniques as you need them for your applications.

C# apps benefit from the .NET Runtime's [automatic memory management](../../standard/automatic-memory-management.md). C# apps also use the extensive [runtime libraries](../../standard/runtime-libraries-overview.md) provided by the .NET SDK. Some components are platform independent, like file system libraries, data collections, and math libraries. Others are specific to a single workload, like the ASP.NET Core web libraries, or the .NET MAUI UI library. A rich Open Source ecosystem on [NuGet](https://nuget.org) augments the libraries that are part of the runtime. These libraries provide even more components you can use.

C# is in the C family of languages. [C# syntax](../language-reference/keywords/index.md) is familiar if you've used C, C++, JavaScript, or Java. Like all languages in the C family, semi-colons (`;`) define the end of statements. C# identifiers are case-sensitive. C# has the same use of braces, `{` and `}`, control statements like `if`, `else` and `switch`, and looping constructs like `for`, and `while`. C# also has a `foreach` statement for any collection type.

C# is a *strongly typed* language. Every variable you declare has a type known at compile time. The compiler, or editing tools tell you if you're using that type incorrectly. You can fix those errors before you ever run your program. [Fundamental data types](../fundamentals/types/index.md) are built into the language and runtime: value types like `int`, `double`, `char`, reference types like `string`, arrays, and other collections. As you write your programs, you create your own types. Those types can be `struct` types for values, or `class` types that define object-oriented behavior. You can add the `record` modifier to either `struct` or `class` types so the compiler synthesizes code for equality comparisons. You can also create `interface` definitions, which define a contract, or a set of members, that a type implementing that interface must provide. You can also define generic types and methods. [Generics](../fundamentals/types/generics.md) use *type parameters* to provide a placeholder for an actual type when used.

As you write code, you define functions, also called [methods](../programming-guide/classes-and-structs/methods.md), as members of `struct` and `class` types. These methods define the behavior of your types. Methods can be overloaded, with different number or types of parameters. Methods can optionally return a value. In addition to methods, C# types can have [properties](../programming-guide/classes-and-structs/properties.md), which are data elements backed by functions called *accessors*. C# types can define [events](../events-overview.md), which allow a type to notify subscribers of important actions. C# supports object oriented techniques such as inheritance and polymorphism for `class` types.

C# apps use [exceptions](../fundamentals/exceptions/index.md) to report and handle errors. You'll be familiar with this practice if you've used C++ or Java. Your code throws an exception when it can't do what was intended. Other code, no matter how many levels up the call stack, can optionally recover by using a `try` - `catch` block.

## Distinctive C# features

Some elements of C# might be less familiar. [Language integrated query (LINQ)](../linq/index.md) provides a common pattern-based syntax to query or transform any collection of data. LINQ unifies the syntax for querying in-memory collections, structured data like XML or JSON, database storage, and even cloud based data APIs. You learn one set of syntax and you can search and manipulate data regardless of its storage. The following query finds all students whose grade point average is greater than 3.5:

:::code language="csharp" source="./snippets/shared/LinqExample.cs" id="LinqExampleQuery":::

The preceding query works for many storage types represented by `Students`. It could be a collection of objects, a database table, a cloud storage blob, or an XML structure. The same query syntax works for all storage types.

The [Task based asynchronous programming model](../asynchronous-programming/index.md) enables you to write code that reads as though it runs synchronously, even though it runs asynchronously. It utilizes the `async` and `await` keywords to describe methods that are asynchronous, and when an expression evaluates asynchronously. The following sample awaits an asynchronous web request. When the asynchronous operation completes, the method returns the length of the response:

:::code language="csharp" source="./snippets/shared/AsyncSamples.cs" id="GetPageLengthAsync":::

C# also supports an `await foreach` statement to iterate a collection backed by an asynchronous operation, like a GraphQL paging API. The following sample reads data in chunks, returning an iterator that provides access to each element when it's available:

:::code language="csharp" source="./snippets/shared/AsyncSamples.cs" id="ReadDataAsync":::

Callers can iterate the collection using an `await foreach` statement:

:::code language="csharp" source="./snippets/shared/AsyncSamples.cs" id="UseReadSequence":::

C# provides [pattern matching](../fundamentals/functional/pattern-matching.md). Those expressions enable you to inspect data and make decisions based on its characteristics. Pattern matching provides a great syntax for control flow based on data. The following code shows how methods for the boolean *and*, *or*, and *xor* operations could be expressed using pattern matching syntax:

:::code language="csharp" source="./snippets/shared/PatternMatching.cs" id="PatternExamples":::

Pattern matching expressions can be simplified using `_` as a catch all for any value. The following example shows how you can simplify the *and* method:

:::code language="csharp" source="./snippets/shared/PatternMatching.cs" id="ReducedPattern":::

Finally, as part of the .NET ecosystem, you can use [Visual Studio](https://visualstudio.microsoft.com/vs), or [Visual Studio Code](https://code.visualstudio.com) with the [C# DevKit](https://code.visualstudio.com/docs/csharp/get-started). These tools provide rich understanding of C#, including the code you write. They also provide debugging capabilities.
