---
title: Tips for Java Developers
description: Are you new to C#, but experienced in Java? Here's a roadmap of what's familiar, and new features to learn in C#, and features in Java that aren't in C#.
ms.date: 02/09/2026
---
# Roadmap for Java developers learning C\#

If you're starting a new job or joining a team that uses C#, this article helps you get productive quickly. It highlights what's familiar from Java and what's new in C#.

C# and Java have many similarities. As you learn C#, you can apply much of the knowledge you already have from programming in Java:

1. ***Similar syntax***: Both Java and C# are in the C family of languages. That similarity means you can already read and understand C#. There are some differences, but most of the syntax is the same as Java, and C. The curly braces and semicolons are familiar. The control statements like `if`, `else`, `switch` are the same. The looping statements of `for`, `while`, and `do`...`while` are same. The same keywords for `class` and `interface` are in both languages. The access modifiers from `public` to `private` are the same. Even many of the builtin types use the same keywords: `int`, `string`, and `double`.
1. ***Object-oriented paradigm***: Both Java and C# are object-oriented languages. The concepts of polymorphism, abstraction, and encapsulation apply in both languages. Both added new constructs, but the core features are still relevant.
1. ***Strongly typed***: Both Java and C# are strongly typed languages. You declare the data type of variables, either explicitly or implicitly. The compiler enforces type safety. The compiler catches type-related errors in your code, before you run the code.
1. ***Cross-platform***: Both Java and C# are cross-platform. You can run your development tools on your favorite platform. Your application can run on multiple platforms. Your development platform isn't required to match your target platform.
1. ***Exception handling***: Both Java and C# throw exceptions to indicate errors. Both use `try` - `catch` - `finally` blocks to handle exceptions. The Exception classes have similar names and inheritance hierarchies. One difference is that C# doesn't have the concept of *checked exceptions*. Any method might (in theory) throw any exception.
1. ***Standard libraries***: The .NET runtime and the Java Standard Library (JSL) have support for common tasks. Both have extensive ecosystems for other open source packages. In C#, the package manager is [NuGet](https://www.nuget.org). It's analogous to Maven.
1. ***Garbage Collection***: Both languages employ automatic memory management through garbage collection. The runtime reclaims the memory from objects that aren't referenced. One difference is that C# enables you to create value types, as `struct` types.

## Syntax at a glance

The following examples show a few common patterns side by side. These comparisons aren't exhaustive, but they give you a quick feel for the syntax differences.

**Variable declaration and type inference:**

```java
// Java
var name = "Hello";
final int count = 5;
```

```csharp
// C#
var name = "Hello";
const int count = 5;
```

**String interpolation:**

```java
// Java
var message = "Hello, " + name + "! Count: " + count;
```

```csharp
// C#
var message = $"Hello, {name}! Count: {count}";
```

Learn more: [String interpolation](../language-reference/tokens/interpolated.md)

**Lambda expressions:**

```java
// Java
list.stream().filter(x -> x > 5).collect(Collectors.toList());
```

```csharp
// C#
var result = list.Where(x => x > 5).ToList();
```

Learn more: [LINQ overview](../linq/index.md)

**Null handling:**

```java
// Java
String value = optional.orElse("default");
```

```csharp
// C#
string value = input ?? "default";
```

Learn more: [Nullable reference types](../nullable-references.md)

## What's familiar

You can work productively in C# almost immediately because of the similarities. As you progress, learn features and idioms in C# that aren't available in Java:

1. [***Pattern matching***](../fundamentals/functional/pattern-matching.md): Pattern matching enables concise conditional statements and expressions based on the shape of complex data structures. The [`is` statement](../language-reference/operators/is.md) checks if a variable "is" some pattern. The pattern-based [`switch` expression](../language-reference/operators/switch-expression.md) provides a rich syntax to inspect a variable and make decisions based on its characteristics.
1. [***String interpolation***](../language-reference/tokens/interpolated.md) and [***raw string literals***](../language-reference/builtin-types/reference-types.md#string-literals): String interpolation enables you to insert evaluated expressions in a string, rather than using positional identifiers. Raw string literals provide a way to minimize escape sequences in text.
1. [***Nullable and non-nullable types***](../nullable-references.md): C# supports *nullable value types*, and *nullable reference types* by appending the `?` suffix to a type. For nullable types, the compiler warns you if you don't check for `null` before dereferencing the expression. For non-nullable types, the compiler warns you if you might be assigning a `null` value to that variable. Non-nullable reference types minimize programming errors that throw a <xref:System.NullReferenceException?displayProperty=nameWithType>.
1. [***Extensions***](../programming-guide/classes-and-structs/extension-methods.md):  In C#, you can create members that *extend* a class or interface. Extensions provide new behavior for a type from a library, or all types that implement a given interface.
1. [***LINQ***](../linq/index.md): Language integrated query (LINQ) provides a common syntax to query and transform data, regardless of its storage.
1. [***Local functions***](../programming-guide/classes-and-structs/local-functions.md): In C#, you can nest functions inside methods, or other local functions. Local functions provide yet another layer of encapsulation.

> [!TIP]
> To learn more about C#'s type system—including `struct` vs. `class`, records, and interfaces—visit the [Type system](../fundamentals/types/index.md) overview in the Fundamentals section.

There are other features in C# that aren't in Java. Features like [`async` and `await`](../asynchronous-programming/index.md) model asynchronous operations in sequential syntax. The [`using`](../language-reference/statements/using.md) statement automatically free nonmemory resources.

There are also some similar features between C# and Java that have subtle but important differences:

1. [***Properties***](../programming-guide/classes-and-structs/properties.md) and [***Indexers***](/dotnet/csharp/programming-guide/indexers): Both properties and indexers (treating a class like an array or dictionary) have language support. In Java, they're naming conventions for methods starting with `get` and `set`.
1. [***Records***](../fundamentals/types/records.md): In C#, records can be either `class` (reference) or `struct` (value) types. C# records can be immutable, but aren't required to be immutable.
1. [***Tuples***](../language-reference/builtin-types/value-tuples.md) have different syntax in C# and Java.
1. [***Attributes***](../language-reference/attributes/general.md) are similar to Java annotations.

Finally, there are Java language features that aren't available in C#:

1. ***Checked exceptions***: In C#, any method could theoretically throw any exception.
1. ***Checked array covariance***: In C#, arrays aren't safely covariant. You should use the generic collection classes and interfaces if you need covariant structures.

Overall, learning C# for a developer experienced in Java should be smooth. C# has enough familiar idioms for you to be productive as you learn the new idioms.

## Next steps

- [A tour of C#](./overview.md): Get a high-level overview of all C# features.
- [Beginner tutorials](./tutorials/index.md): Learn C# step by step with interactive lessons.
- [What you can build with C#](./what-you-can-build.md): Explore the application types you can create with C# and .NET.
- [C# fundamentals](../fundamentals/program-structure/index.md): Dive deeper into the type system, object-oriented programming, and more.
