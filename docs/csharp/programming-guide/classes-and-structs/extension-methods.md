---
title: "Extension members"
description: Extension members in C# enable you to add methods, properties, or operators to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.
ms.date: 04/15/2025
helpviewer_keywords: 
  - "methods [C#], adding to existing types"
  - "extension methods [C#]"
  - "methods [C#], extension"
---

# Extension members (C# Programming Guide)

Extension members enable you to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.

Beginning with C# 14, there are two syntaxes you use to define extension methods. C# 14 adds [`extension`](../../language-reference/keywords/extension.md) containers, where you define multiple extension members for a type or an instance of a type. Before C# 14, you add the [`this`](../../language-reference/keywords/this.md) modifier to the first parameter of a static method to indicate that the method appears as a member of an instance of the parameter type.

Extension methods are static methods, but they're called as if they were instance methods on the extended type. For client code written in C#, F# and Visual Basic, there's no apparent difference between calling an extension method and the methods defined in a type. Both forms of extension methods are compiled to the same IL (Intermediate Language). Consumers of extension members don't need to know which syntax was used to define extension methods.

The most common extension members are the LINQ standard query operators that add query functionality to the existing <xref:System.Collections.IEnumerable?displayProperty=nameWithType> and <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> types. To use the standard query operators, first bring them into scope with a `using System.Linq` directive. Then any type that implements <xref:System.Collections.Generic.IEnumerable%601> appears to have instance methods such as <xref:System.Linq.Enumerable.GroupBy%2A>, <xref:System.Linq.Enumerable.OrderBy%2A>, <xref:System.Linq.Enumerable.Average%2A>, and so on. You can see these extra methods in IntelliSense statement completion when you type "dot" after an instance of an <xref:System.Collections.Generic.IEnumerable%601> type such as <xref:System.Collections.Generic.List%601> or <xref:System.Array>.

### OrderBy example

The following example shows how to call the standard query operator `OrderBy` method on an array of integers. The expression in parentheses is a lambda expression. Many standard query operators take lambda expressions as parameters. For more information, see [Lambda Expressions](../../language-reference/operators/lambda-expressions.md).

:::code language="csharp" source="./snippets/ExtensionMembers/ExtensionMethods.cs" id="UseOrderBy":::

Extension methods are defined as static methods but are called by using instance method syntax. Their first parameter specifies which type the method operates on. The parameter follows the [this](../../language-reference/keywords/this.md) modifier. Extension methods are only in scope when you explicitly import the namespace into your source code with a `using` directive.

### Declare extension members

Beginning with C# 14, you can declare *extension blocks*. An extension block is a block in a non-nested, nongeneric, static class that contains extension members for a type or an instance of that type. The following code example defines an extension block for the `string` type. The extension block contains one member: a method that counts the words in the string:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMembers.cs" id="ExtensionBlock":::

Before C# 14, you declare an extension method by adding the `this` modifier to the first parameter:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="ClassicExtensionMethod":::

Both forms of extensions must be defined inside a non-nested, nongeneric static class.

And it can be called from an application by using the syntax for accessing instance members:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="CallAsInstanceMethod":::

While extension members add new capabilities to an existing type, extension members don't violate the principle of encapsulation. The access declarations for all members of the extended type apply to extension members.

Both the `MyExtensions` class and the `WordCount` method are `static`, and it can be accessed like all other `static` members. The `WordCount` method can be invoked like other `static` methods as follows:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="CallAsStaticMethod":::

The preceding C# code applies to both the extension block and `this` syntax for extension members. The preceding code:

- Declares and assigns a new `string` named `s` with a value of `"Hello Extension Methods"`.
- Calls `MyExtensions.WordCount` given argument `s`.

For more information, see [How to implement and call a custom  extension method](./how-to-implement-and-call-a-custom-extension-method.md).

In general, you probably call extension members far more often than you implement them. Because extension members are called as though they're declared as members of the extended class, no special knowledge is required to use them from client code. To enable extension members for a particular type, just add a `using` directive for the namespace in which the methods are defined. For example, to use the standard query operators, add this `using` directive to your code:

```csharp
using System.Linq;
```

## Binding extension members at compile time

You can use extension members to extend a class or interface, but not to override behavior defined in a class. An extension member with the same name and signature as an interface or class members are never called. At compile time, extension members always have lower priority than instance (or static) members defined in the type itself. In other words, if a type has a method named `Process(int i)`, and you have an extension method with the same signature, the compiler always binds to the member method. When the compiler encounters a member invocation, it first looks for a match in the type's members. If no match is found, it searches for any extension members that are defined for the type. It binds to the first extension member that it finds. The following example demonstrates the rules that the C# compiler follows in determining whether to bind to an instance member on the type, or to an extension member. The static class `Extensions` contains extension members defined for any type that implements `IMyInterface`:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="InterfaceAndExtensions":::

The equivalent extensions can be declared using the C# 14 extension member syntax:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMembers.cs" id="InterfaceAndExtensions":::

Classes `A`, `B`, and `C` all implement the interface:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="Classes":::

The `MethodB` extension method is never called because its name and signature exactly match methods already implemented by the classes. When the compiler can't find an instance method with a matching signature, it binds to a matching extension method if one exists.

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="CallExtensionMethods":::

## Common usage patterns

### Collection Functionality

In the past, it was common to create "Collection Classes" that implemented the <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface for a given type and contained functionality that acted on collections of that type. While there's nothing wrong with creating this type of collection object, the same functionality can be achieved by using an extension on the <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType>. Extensions have the advantage of allowing the functionality to be called from any collection such as an <xref:System.Array?displayProperty=nameWithType> or <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> that implements <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> on that type. An example of this using an Array of Int32 can be found [earlier in this article](#orderby-example).

### Layer-Specific Functionality

When using an Onion Architecture or other layered application design, it's common to have a set of Domain Entities or Data Transfer Objects that can be used to communicate across application boundaries. These objects generally contain no functionality, or only minimal functionality that applies to all layers of the application. Extension methods can be used to add functionality that is specific to each application layer.

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="DomainEntity":::

You can declare an equivalent `FullName` property in C# 14 and later using the new extension block syntax:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMembers.cs" id="DomainEntity":::

### Extending Predefined Types

Rather than creating new objects when reusable functionality needs to be created, you can often extend an existing type, such as a .NET or CLR type. As an example, if you don't use extension methods, you might create an `Engine` or `Query` class to do the work of executing a query on a SQL Server that might be called from multiple places in our code. However you can instead extend the <xref:System.Data.SqlClient.SqlConnection?displayProperty=nameWithType> class using extension methods to perform that query from anywhere you have a connection to a SQL Server. Other examples might be to add common functionality to the <xref:System.String?displayProperty=nameWithType> class, extend the data processing capabilities of the <xref:System.IO.Stream?displayProperty=nameWithType> object, and <xref:System.Exception?displayProperty=nameWithType> objects for specific error handling functionality. These types of use-cases are limited only by your imagination and good sense.

Extending predefined types can be difficult with `struct` types because they're passed by value to methods. That means any changes to the struct are made to a copy of the struct. Those changes aren't visible once the extension method exits. You can add the `ref` modifier to the first argument making it a `ref` extension method. The `ref` keyword can appear before or after the `this` keyword without any semantic differences. Adding the `ref` modifier indicates that the first argument is passed by reference. This technique enables you to write extension methods that change the state of the struct being extended (note that private members aren't accessible). Only value types or generic types constrained to struct (For more information about these rules, see [`struct` constraint](../../language-reference/builtin-types/struct.md#struct-constraint) for more information) are allowed as the first parameter of a `ref` extension method or as the receiver of an extension block. The following example shows how to use a `ref` extension method to directly modify a built-in type without the need to reassign the result or pass it through a function with the `ref` keyword:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="RefExtensions":::

The equivalent extension blocks are shown in the following code:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMembers.cs" id="RefExtensions":::

Different extension blocks are required to distinguish by-value and by-ref parameter modes for the receiver.

You can see the difference applying `ref` to the receiver has in the following example:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="UseRefExtension":::

You can apply the same technique by adding `ref` extension members to user-defined struct types:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="UserDefinedRef":::

The preceding sample can also be created using extension blocks in C# 14:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMembers.cs" id="UserDefinedRef":::

You can access these extension methods as follows:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="TestUserDefinedRef":::

## General Guidelines

It's preferable to add functionality by modifying an object's code or deriving a new type whenever it's reasonable and possible to do so. Extension methods are a crucial option for creating reusable functionality throughout the .NET ecosystem. Extension members are preferable when the original source isn't under your control, when a derived object is inappropriate or impossible, or when the functionality has limited scope.

For more information on derived types, see [Inheritance](../../fundamentals/object-oriented/inheritance.md).

If you do implement extension methods for a given type, remember the following points:

- An extension method isn't called if it has the same signature as a method defined in the type.
- Extension methods are brought into scope at the namespace level. For example, if you have multiple static classes that contain extension methods in a single namespace named `Extensions`, all of them are brought into scope by the `using Extensions;` directive.

For a class library that you implemented, you shouldn't use extension methods to avoid incrementing the version number of an assembly. If you want to add significant functionality to a library for which you own the source code, follow the .NET guidelines for assembly versioning. For more information, see [Assembly Versioning](../../../standard/assembly/versioning.md).

## See also

- [Parallel Programming Samples (many examples demonstrate extension methods)](/samples/browse/?products=dotnet&term=parallel)
- [Lambda Expressions](../../language-reference/operators/lambda-expressions.md)
- [Standard Query Operators Overview](../../linq/standard-query-operators/index.md)
- [Conversion rules for Instance parameters and their impact](/archive/blogs/sreekarc/conversion-rules-for-instance-parameters-and-their-impact)
- [Extension methods Interoperability between languages](/archive/blogs/sreekarc/extension-methods-interoperability-between-languages)
- [Extension methods and Curried Delegates](/archive/blogs/sreekarc/extension-methods-and-curried-delegates)
- [Extension method Binding and Error reporting](/archive/blogs/sreekarc/extension-method-binding-and-error-reporting)
