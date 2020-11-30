---
title: Get Started - an introduction to the C# language and .NET"
description: Learn the basics of C# and .NET. Get an overview of the C# language and .NET ecosystem.
ms.date: 10/13/2020
---
# Introduction to the C# language and .NET

C# is an elegant and type-safe object-oriented language. C# enables developers to build many types of secure and robust applications that run in the .NET ecosystem.

## C# language

C# syntax is highly expressive, yet it's also simple and easy to learn. The curly brace syntax of C# will be instantly recognizable to anyone familiar with C, C++, Java or JavaScript. Developers who know any of these languages are typically able to work productively in C# within a short time. C# provides powerful features such as nullable types, delegates, lambda expressions, pattern matching, and safe direct memory access. C# supports generic methods and types, which provide increased type safety and performance. C# provides iterators, which enable implementers of collection classes to define custom behaviors for client code. Language-Integrated Query (LINQ) expressions make the strongly typed query a first-class language construct.

As an object-oriented language, C# supports the concepts of encapsulation, inheritance, and polymorphism. A class may inherit directly from one parent class, but it may implement any number of interfaces. Methods that override virtual methods in a parent class require the `override` keyword as a way to avoid accidental redefinition. In C#, a struct is like a lightweight class; it's a stack-allocated type that can implement interfaces but doesn't support inheritance. C# also provides records, which are class types whose purpose is primarily storing data values.

C# makes it easy to develop software components through several innovative language constructs, including:

- Encapsulated method signatures called *delegates*, which enable type-safe event notifications.
- Properties, which serve as accessors for private member variables.
- Attributes, which provide declarative metadata about types at run time.
- Inline XML documentation comments.
- Language-Integrated Query (LINQ), which provides built-in query capabilities across different kinds of data sources.
- Pattern matching, which enables control flow by inspecting data types and values.

You interact with native components through a process called "Interop". Interop enables C# programs to do almost anything that a native C++ application can do. C# even supports pointers and the concept of "unsafe" code for those cases in which direct memory access is critical.

The C# build process is simple compared to C and C++ and more flexible than in Java. There are no separate header files, and no requirement that methods and types be declared in a particular order. A C# source file may define any number of classes, structs, interfaces, and events.

The following are additional C# resources:

- For a good general introduction to the language, see the [Tour of C#](../tour-of-csharp/index.md).
- For detailed information about specific aspects of the C# language, see the [C# Reference](../language-reference/index.md).
- For more information about LINQ, see [LINQ (Language-Integrated Query)](../programming-guide/concepts/linq/index.md).

## .NET Platform Architecture

C# programs run on .NET, a virtual execution system called the common language runtime (CLR) and a unified set of class libraries. The CLR is the commercial implementation by Microsoft of the common language infrastructure (CLI), an international standard. The CLI is the basis for creating execution and development environments in which languages and libraries work together seamlessly.

Source code written in C# is compiled into an [intermediate language (IL)](../../standard/managed-code.md) that conforms to the CLI specification. The IL code and resources, such as bitmaps and strings, are stored in an assembly, typically with an extension of .dll. An assembly contains a manifest that provides information about the assembly's types, version, and culture.

When the C# program is executed, the assembly is loaded into the CLR. The CLR performs Just-In-Time (JIT) compilation to convert the IL code to native machine instructions. The CLR provides other services related to automatic garbage collection, exception handling, and resource management. Code that's executed by the CLR is sometimes referred to as "managed code", in contrast to "unmanaged code", which is compiled into native machine language that targets a specific system.

Language interoperability is a key feature of .NET. IL code produced by the C# compiler conforms to the Common Type Specification (CTS). IL code generated from C# can interact with code that was generated from the .NET versions of F#, Visual Basic, C++, or any of more than 20 other CTS-compliant languages. A single assembly may contain multiple modules written in different .NET languages, and the types can reference each other as if they were written in the same language.

In addition to the run time services, .NET also includes extensive libraries. These libraries support many different workloads. They are organized into namespaces that provide a wide variety of useful functionality for everything from file input and output to string manipulation to XML parsing, to web application frameworks to Windows Forms controls. The typical C# application uses the .NET class library extensively to handle common "plumbing" chores.

For more information about .NET, see [Overview of .NET](../../core/introduction.md).
