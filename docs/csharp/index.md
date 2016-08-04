---
title: C# Guide
description: C# Guide
keywords: .NET, .NET Core
author: BillWagner
manager: wpickett
ms.date: 08/03/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 52db8280-0e53-40cf-858b-e8eef3997dea
---

# C# Guide

C# (pronounced “See Sharp”) is a simple, modern, object-oriented, and type-safe programming language. C# has its roots in the C family of languages and will be immediately to C, C++, and Java programmers.
C# is an object-oriented language, but C# further includes support for ***component-oriented*** programming. Contemporary software design increasingly relies on software components in the form of self-contained and self-describing packages of functionality. Key to such components is that they present a programming model with properties, methods, and events; they have attributes that provide declarative information about the component; and they incorporate their own documentation. C# provides language constructs to support directly these concepts, making C# a very natural language in which to create and use software components.
Several C# features aid in the construction of robust and durable applications: ***Garbage collection*** automatically reclaims memory occupied by unreachable unused objects; ***exception handling*** provides a structured and extensible approach to error detection and recovery; and the ***type-safe*** design of the language makes it impossible to read from uninitialized variables, to index arrays beyond their bounds, or to perform unchecked type casts.
C# has a ***unified type system***. All C# types, including primitive types such as int and double, inherit from a single root object type. Thus, all types share a set of common operations, and values of any type can be stored, transported, and operated upon in a consistent manner. Furthermore, C# supports both user-defined reference types and value types, allowing dynamic allocation of objects as well as in-line storage of lightweight structures.
To ensure that C# programs and libraries can evolve over time in a compatible manner, much emphasis has been placed on ***versioning*** in C#’s design. Many programming languages pay little attention to this issue, and, as a result, programs written in those languages break more often than necessary when newer versions of dependent libraries are introduced. Aspects of C#’s design that were directly influenced by versioning considerations include the separate virtual and override modifiers, the rules for method overload resolution, and support for explicit interface member declarations.

## Hello world
The “Hello, World” program is traditionally used to introduce a programming language. Here it is in C#:
```csharp
using System;
class Hello
{
    static void Main()
	{
        Console.WriteLine("Hello, World");
	}
}
```
C# source files typically have the file extension `.cs`. Assuming that the “Hello, World” program is stored in the file `hello.cs`, the program might be compiled using the command line:

```
csc hello.cs
```

which produces an executable assembly named hello.exe. The output produced by this application when it is run is:

```
Hello, World
```

The “Hello, World” program starts with a using directive that references the `System` namespace. Namespaces provide a hierarchical means of organizing C# programs and libraries. Namespaces contain types and other namespaces—for example, the `System` namespace contains a number of types, such as the `Console` class referenced in the program, and a number of other namespaces, such as `IO` and `Collections`. A `using` directive that references a given namespace enables unqualified use of the types that are members of that namespace. Because of the `using` directive, the program can use `Console.WriteLine` as shorthand for `System.Console.WriteLine`.
The `Hello` class declared by the “Hello, World” program has a single member, the method named `Main`. The `Main` method is declared with the static modifier. While instance methods can reference a particular enclosing object instance using the keyword `this`, static methods operate without reference to a particular object. By convention, a static method named `Main` serves as the entry point of a program.
The output of the program is produced by the `WriteLine` method of the `Console` class in the `System` namespace. This class is provided by the standard class libraries, which, by default, are automatically referenced by the compiler.

## Program structure
The key organizational concepts in C# are ***programs***, ***namespaces***, ***types***, ***members***, and ***assemblies***. C# programs consist of one or more source files. Programs declare types, which contain members and can be organized into namespaces. Classes and interfaces are examples of types. Fields, methods, properties, and events are examples of members. When C# programs are compiled, they are physically packaged into assemblies. Assemblies typically have the file extension .exe or .dll, depending on whether they implement ***applications*** or ***libraries***, respectively.
The example

```csharp
using System;
namespace Acme.Collections
{
    public class Stack
    {
        Entry top;
        public void Push(object data) 
		{
			top = new Entry(top, data);
		}
		
		public object Pop() 
		{
			if (top == null)
			{
				throw new InvalidOperationException();
			}
			object result = top.data;
			top = top.next;
			return result;
		}

		class Entry
		{
			public Entry next;
			public object data;
			public Entry(Entry next, object data) 
			{
				this.next = next;
				this.data = data;
			}
		}
	}
}
```

declares a class named `Stack` in a namespace called `Acme.Collections`. The fully qualified name of this class is `Acme.Collections.Stack`. The class contains several members: a field named `top`, two methods named `Push` and `Pop`, and a nested class named `Entry`. The `Entry` class further contains three members: a field named `next`, a field named `data`, and a constructor. Assuming that the source code of the example is stored in the file `acme.cs`, the command line

```
csc /t:library acme.cs
```

compiles the example as a library (code without a `Main` entry point) and produces an assembly named `acme.dll`.
Assemblies contain executable code in the form of Intermediate Language (IL) instructions, and symbolic information in the form of metadata. Before it is executed, the IL code in an assembly is automatically converted to processor-specific code by the Just-In-Time (JIT) compiler of .NET Common Language Runtime.
Because an assembly is a self-describing unit of functionality containing both code and metadata, there is no need for `#include` directives and header files in C#. The public types and members contained in a particular assembly are made available in a C# program simply by referencing that assembly when compiling the program. For example, this program uses the `Acme.Collections.Stack` class from the `acme.dll` assembly:

```csharp
using System;
using Acme.Collections;
class Test
{
    static void Main() 
	{
        Stack s = new Stack();
        s.Push(1);
        s.Push(10);
        s.Push(100);
        Console.WriteLine(s.Pop());
        Console.WriteLine(s.Pop());
        Console.WriteLine(s.Pop());
	}
}
```

If the program is stored in the file `example.cs`, when `example.cs` is compiled, the acme.dll assembly can be referenced using the compiler’s /r option:

```
csc /r:acme.dll example.cs
```

This creates an executable assembly named `example.exe`, which, when run, produces the output:

```
100
10
1
```

C# permits the source text of a program to be stored in several source files. When a multi-file C# program is compiled, all of the source files are processed together, and the source files can freely reference each other—conceptually, it is as if all the source files were concatenated into one large file before being processed. Forward declarations are never needed in C# because, with very few exceptions, declaration order is insignificant. C# does not limit a source file to declaring only one public type nor does it require the name of the source file to match a type declared in the source file.






The opening sentence of the C# Specification states:

> C# (pronounced "See Sharp") is a simple, modern, object-oriented, and type-safe programming language.

C# has grown since that was written, but it is still true to its roots.
C# is still a simple, modern, and type-safe language. It's now more
multi-paradigm after adding more and more support for functional concepts.
It is still an expressive, and productive general purpose programming
language.

The C# Guide has content for experienced C# developers that want to learn
more, experienced developers that are new to C#, and people learning to
program. The three recommendations below can help you find the content you
need. Most people won't fit one of these profiles exactly. But, they
can still help you decide which sections will best help you.

## Experienced C# Developers


.. start with "What's new" in recent versions.
.. Search for areas you want to explore more deeply.

## For Developers new to C#

.. Explore the walk throughs
.. Explore C# features of interest

## For new developers

.. Getting Started Section
.. Explore walk throughs
.. examine the guide at your own pace


> Close #608 with this PR
> closes 486 on the PR request

