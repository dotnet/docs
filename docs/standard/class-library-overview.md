---
title: Overview of core .NET libraries
description: Learn about the core .NET libraries. .NET APIs include classes, interfaces, delegates, and value types to provide access to system functionality.
ms.date: 11/05/2025
---
# Core .NET libraries overview

.NET APIs include classes, interfaces, delegates, and value types that expedite and optimize the development process and provide access to system functionality. To facilitate interoperability between languages, most .NET types are CLS-compliant and can therefore be used from any programming language whose compiler conforms to the common language specification (CLS).

.NET types are the foundation on which .NET applications, components, and controls are built. .NET includes types that perform the following functions:

- Represent base data types and exceptions.
- Encapsulate data structures.
- Perform I/O.
- Access information about loaded types.
- Invoke .NET security checks.
- Provide data access, rich client-side GUI, and server-controlled, client-side GUI.

.NET provides a rich set of interfaces as well as abstract and concrete (non-abstract) classes. You can use the concrete classes as-is or, in many cases, derive your own classes from them. To use the functionality of an interface, you can either create a class that implements the interface or derive a class from one of the .NET classes that implements the interface.

## Naming conventions

 .NET types use a dot syntax naming scheme to represent a hierarchy. Related types are grouped into namespaces so they can be searched and referenced more easily. The first part of the full name is the namespace name. The last part of the name is the type or member name. For example, `System.Collections.Generic.List<T>` represents the <xref:System.Collections.Generic.List`1> type, which belongs to the `System.Collections.Generic` namespace. The types in <xref:System.Collections.Generic> can be used to work with generic collections.

 This naming scheme makes it easy for library developers who extend .NET to create hierarchical groups of types and name them in a consistent, informative manner. It also allows types to be unambiguously identified by their full name (that is, by their namespace and type name), which prevents type name collisions.

 The use of naming patterns to group related types into namespaces is a useful way to build and document class libraries. However, this naming scheme has no effect on visibility, member access, inheritance, security, or binding. A namespace can be partitioned across multiple assemblies and a single assembly can contain types from multiple namespaces. The assembly provides the formal structure for versioning, deployment, security, loading, and visibility in the common language runtime.

 For more information on namespaces and type names, see [Common type system](base-types/common-type-system.md).

## System namespace

The <xref:System> namespace is the root namespace for fundamental types in .NET. This namespace includes classes that represent the base data types used by all applications, for example, <xref:System.Object> (the root of the inheritance hierarchy), <xref:System.Byte>, <xref:System.Char>, <xref:System.Array>, <xref:System.Int32>, and <xref:System.String>.

Many of these types correspond to the primitive data types that a programming language uses. When you write code using .NET types, you can use the corresponding language keyword when a .NET base data type is expected. For more information, see:

- [Built-in types (C# reference)](../csharp/language-reference/builtin-types/built-in-types.md)
- [Primitive types (Visual Basic)](/dotnet/visual-basic/reference/language-specification/types#primitive-types)
-[Basic types (F#)](../fsharp/language-reference/basic-types.md)

In addition to the base data types, the <xref:System> namespace contains over 100 classes, ranging from classes that handle exceptions to classes that deal with core runtime concepts, such as garbage collection. The <xref:System> namespace also contains many second-level namespaces.

The [.NET API reference documentation](../../api/index.md) provides documentation on each namespace, its types, and their members.

## Data structures

.NET includes a set of data structures that are the workhorses of many .NET apps. These are mostly collections, but also include other types.

- <xref:System.Array> - Represents an array of strongly typed objects that can be accessed by index. Has a fixed size, per its construction.
- <xref:System.Collections.Generic.List%601> - Represents a strongly typed list of objects that can be accessed by index. Is automatically resized as needed.
- <xref:System.Collections.Generic.Dictionary%602> - Represents a collection of values that are indexed by a key. Values can be accessed via key. Is automatically resized as needed.
- <xref:System.Uri> - Provides an object representation of a uniform resource identifier (URI) and easy access to the parts of the URI.
- <xref:System.DateTime> - Represents an instant in time, typically expressed as a date and time of day.

## Utility APIs

.NET includes a set of utility APIs that provide functionality for many important tasks.

- <xref:System.Net.Http.HttpClient?displayProperty=fullName> - An API for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
- <xref:System.Diagnostics.Debug?displayProperty=fullName> and <xref:System.Diagnostics.Trace?displayProperty=fullName>: An API for writing logging and debugging information during application execution.
- <xref:System.IO.StreamReader?displayProperty=fullName> and <xref:System.IO.StreamWriter?displayProperty=fullName> - APIs for reading and writing files.
- <xref:System.Text.Json.JsonSerializer?displayProperty=fullName> - An API for serializing objects or value types to JSON and deserializing JSON into objects or value types.

## App-model APIs

There are many app models that can be used with .NET, for example:

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) - A web framework for building web sites and services. Supported on Windows, Linux, and macOS.
- [.NET MAUI](https://dotnet.microsoft.com/apps/maui) - An app platform for building native apps that run on Windows, macOS, iOS, and Android using C#.
- [Windows Desktop](https://www.nuget.org/packages/Microsoft.WindowsDesktop.App.Ref/) - Includes Windows Presentation Foundation (WPF) and Windows Forms.

## See also

- [Runtime libraries overview](runtime-libraries-overview.md)
- [Common type system](base-types/common-type-system.md)
- [.NET API browser](../../api/index.md)
