---
title: Tips for Python Developers
description: New to C#, but know Python? Here's a roadmap of what's familiar, features in C# that aren't in Python, and alternatives for Python features that aren't in C#.
ms.date: 02/06/2026
---
# Roadmap for Python developers learning C\#

If you're moving from Python to C# for a new role or project, this article helps you get productive quickly. It highlights what's familiar from Python and what's different in C#.

C# and Python share similar concepts. These familiar constructs help you learn C# when you already know Python.

1. ***Object oriented***: Both Python and C# are object-oriented languages. All the concepts around classes in Python apply in C#, even if the syntax is different.
1. ***Cross-platform***: Both Python and C# are cross-platform languages. Apps written in either language can run on many platforms.
1. ***Garbage collection***: Both languages employ automatic memory management through garbage collection. The runtime reclaims the memory from objects that aren't referenced.
1. ***Strongly typed***: Both Python and C# are strongly typed languages. Type coercion doesn't occur implicitly. There are differences described later, as C# is statically typed whereas Python is dynamically typed.
1. ***Async / Await***: Python's `async` and `await` feature was directly inspired by C#'s `async` and `await` support.
1. ***Pattern matching***: Python's `match` expression and pattern matching is similar to C#'s [pattern matching](../fundamentals/functional/pattern-matching.md) `switch` expression. You use them to inspect a complex data expression to determine if it matches a pattern.
1. ***Statement keywords***: Python and C# share many keywords, such as `if`, `else`, `while`, `for`, and many others. While not all syntax is the same, there's enough similarity that you can read C# if you know Python.

## Syntax at a glance

The following examples show a few common patterns side by side. These comparisons aren't exhaustive, but they give you a quick feel for the syntax differences.

**Type annotations:**

```python
# Python
name: str = "Hello"
count: int = 5
```

```csharp
// C#
string name = "Hello";
int count = 5;
```

**List filtering (comprehension vs. LINQ):**

```python
# Python
result = [x for x in items if x > 5]
```

```csharp
// C#
var result = items.Where(x => x > 5).ToList();
```

Learn more: [LINQ overview](../linq/index.md)

**Block scope (indentation vs. braces):**

```python
# Python
if count > 0:
    print("positive")
```

```csharp
// C#
if (count > 0)
{
    Console.WriteLine("positive");
}
```

**Class definition:**

```python
# Python
class Point:
    def __init__(self, x: int, y: int):
        self.x = x
        self.y = y
```

```csharp
// C#
record Point(int X, int Y);
```

Learn more: [Records](../fundamentals/types/records.md)

## Key differences

As you learn C#, you discover these important concepts where C# is different from Python:

1. [***Indentation vs. tokens***](./tutorials/branches-and-loops.md): In Python, newlines and indentation are first-class syntactic elements. In C#, whitespace isn't significant. Tokens, like `;` separate statements, and other tokens `{` and `}` control block scope for `if` and other block statements. However, for readability, most coding styles (including the style used in these docs) use indentation to reinforce the block scopes declared by `{` and `}`.
1. [***Static typing***](../fundamentals/types/index.md): In C#, a variable declaration includes its type. Reassigning a variable to an object of a different type generates a compiler error. In Python, the type can change when reassigned.
1. [***Nullable types***](../nullable-references.md): C# variables can be *nullable* or *non-nullable*. A non-nullable type is one that can't be null (or nothing). It always refers to a valid object. By contrast, a nullable type might either refer to a valid object, or null.
1. [***LINQ***](../linq/index.md): The query expression keywords that make up Language Integrated Query (LINQ) aren't keywords in Python. However, Python libraries like `itertools`, `more-itertools`, and `py-linq` provide similar functionality.
1. [***Generics***](../fundamentals/types/generics.md): C# generics use C# static typing to make assertions about the arguments supplied for type parameters. A generic algorithm might need to specify constraints that an argument type must satisfy.

> [!TIP]
> To learn more about C#'s type system—including `class` vs. `struct`, generics, and interfaces—visit the [Type system](../fundamentals/types/index.md) overview in the Fundamentals section.

Finally, some features of Python aren't available in C#:

1. ***Structural (duck) typing***: In C#, types have names and declarations. Except for [tuples](../language-reference/builtin-types/value-tuples.md), types with the same structure aren't interchangeable.
1. ***REPL***: C# doesn't have a Read-Eval-Print Loop (REPL) to quickly prototype solutions.
1. ***Significant whitespace***: You need to correctly use braces `{` and `}` to note block scope.

Learning C# if you know Python is a smooth journey. The languages have similar concepts and similar idioms to use.

## Next steps

- [A tour of C#](./overview.md): Get a high-level overview of all C# features.
- [Beginner tutorials](./tutorials/index.md): Learn C# step by step with interactive lessons.
- [What you can build with C#](./what-you-can-build.md): Explore the application types you can create with C# and .NET.
- [C# fundamentals](../fundamentals/program-structure/index.md): Dive deeper into the type system, object-oriented programming, and more.
