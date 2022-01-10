---
title: "Nullable reference types - C# reference"
description: Learn about C# nullable reference types and how to use them
ms.date: 09/08/2021
---
# Nullable reference types (C# reference)

> [!NOTE]
> This article covers nullable reference types. You can also declare [nullable value types](nullable-value-types.md).

Nullable reference types are available beginning with C# 8.0, in code that has opted in to a *nullable aware context*. Nullable reference types, the null static analysis warnings, and the [null-forgiving operator](../operators/null-forgiving.md) are optional language features. All are turned off by default. A *nullable context* is controlled at the project level using build settings, or in code using pragmas.

 In a nullable aware context:

- A variable of a reference type `T` must be initialized with non-null, and may never be assigned a value that may be `null`.
- A variable of a reference type `T?` may be initialized with `null` or assigned `null`, but is required to be checked against `null` before de-referencing.
- A variable `m` of type `T?` is considered to be non-null when you apply the null-forgiving operator, as in `m!`.

The distinctions between a non-nullable reference type `T` and a nullable reference type `T?` are enforced by the compiler's interpretation of the preceding rules. A variable of type `T` and a variable of type `T?` are represented by the same .NET type. The following example declares a non-nullable string and a nullable string, and then uses the null-forgiving operator to assign a value to a non-nullable string:

:::code language="csharp" source="snippets/shared/NullableReferenceTypes.cs" id="SnippetCoreSyntax":::

The variables `notNull` and `nullable` are both represented by the <xref:System.String> type. Because the non-nullable and nullable types are both stored as the same type, there are several locations where using a nullable reference type isn't allowed. In general, a nullable reference type can't be used as a base class or implemented interface. A nullable reference type can't be used in any object creation or type testing expression. A nullable reference type can't be the type of a member access expression. The following examples show these constructs:

```csharp
public MyClass : System.Object? // not allowed
{
}

var nullEmpty = System.String?.Empty; // Not allowed
var maybeObject = new object?(); // Not allowed
try
{
    if (thing is string? nullableString) // not allowed
        Console.WriteLine(nullableString);
} catch (Exception? e) // Not Allowed
{
    Console.WriteLine("error");
}
```

## Nullable references and static analysis

The examples in the previous section illustrate the nature of nullable reference types. Nullable reference types aren't new class types, but rather annotations on existing reference types. The compiler uses those annotations to help you find potential null reference errors in your code. There's no runtime difference between a non-nullable reference type and a nullable reference type. The compiler doesn't add any runtime checking for non-nullable reference types. The benefits are in the compile-time analysis. The compiler generates warnings that help you find and fix potential null errors in your code. You declare your intent, and the compiler warns you when your code violates that intent.

In a nullable enabled context, the compiler performs static analysis on variables of any reference type, both nullable and non-nullable. The compiler tracks the *null-state* of each reference variable as either *not-null* or *maybe-null*. The default state of a non-nullable reference is *not-null*. The default state of a nullable reference is *maybe-null*.

Non-nullable reference types should always be safe to dereference because their *null-state* is *not-null*. To enforce that rule, the compiler issues warnings if a non-nullable reference type isn't initialized to a non-null value. Local variables must be assigned where they're declared. Every field must be assigned a *not-null* value, in a field initializer or every constructor. The compiler issues warnings when a non-nullable reference is assigned to a reference whose state is *maybe-null*. Generally, a non-nullable reference is *not-null* and no warnings are issued when those variables are dereferenced.

> [!NOTE]
> If you assign a *maybe-null* expression to a non-nullable reference type, the compiler generates a warnings. The compiler then generates warnings for that variable until it's assigned to a *not-null* expression.

Nullable reference types may be initialized or assigned to `null`. Therefore, static analysis must determine that a variable is *not-null* before it's dereferenced. If a nullable reference is determined to be *maybe-null*, assigning to a non-nullable reference variable generates a compiler warning. The following class shows examples of these warnings:

:::code language="csharp" source="snippets/shared/NullableReferenceTypes.cs" id="SnippetClassWithNullable":::

The following snippet shows where the compiler emits warnings when using this class:

:::code language="csharp" source="snippets/shared/NullableReferenceTypes.cs" id="SnippetLocalWarnings":::

The preceding examples demonstrate how compiler's static analysis determines the *null-state* of reference variables. The compiler applies language rules for null checks and assignments to inform its analysis.  The compiler can't make assumptions about the semantics of methods or properties. If you call methods that perform null checks, the compiler can't know those methods affect a variable's *null-state*. There are attributes you can add to your APIs to inform the compiler about the semantics of arguments and return values. These attributes have been applied to many common APIs in the .NET Core libraries. For example, <xref:System.String.IsNullOrEmpty%2A> has been updated, and the compiler correctly interprets that method as a null check. For more information about the attributes that apply to *null-state* static analysis, see the article on [Nullable attributes](../attributes/nullable-analysis.md).

## Setting the nullable context

There are two ways to control the nullable context. At the project level, you can add the `<Nullable>enable</Nullable>` project setting. In a single C# source file, you can add the `#nullable enable` pragma to enable the nullable context. See the article on [setting a nullable strategy](../../nullable-migration-strategies.md). Prior to .NET 6, new projects use the default, `<Nullable>disable</Nullable>`. Beginning with .NET 6, new projects include the `<Nullable>enable</Nullable>` element in the project file.

## C# language specification

For more information, see the following proposals for the [C# language specification](~/_csharpstandard/standard/README.md):

- [Nullable reference types](~/_csharplang/proposals/csharp-8.0/nullable-reference-types.md)
- [Draft nullable reference types specification](~/_csharplang/proposals/csharp-9.0/nullable-reference-types-specification.md)

## See also

- [C# reference](../index.md)
- [Nullable value types](nullable-value-types.md)
