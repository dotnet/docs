---
title: "Nullable reference types"
description: Learn about C# nullable reference types and how to use them
ms.date: 01/14/2026
---
# Nullable reference types (C# reference)

> [!NOTE]
> This article covers nullable reference types. You can also declare [nullable value types](nullable-value-types.md).

You can use nullable reference types in code that's in a *nullable aware context*. Nullable reference types, the null static analysis warnings, and the [null-forgiving operator](../operators/null-forgiving.md) are optional language features. All are turned off by default. You control a *nullable context* at the project level by using build settings, or in code by using pragmas.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

> [!IMPORTANT]
> All project templates enable the *nullable context* for the project. Projects created with earlier templates don't include this element, and these features are off unless you enable them in the project file or use pragmas.

In a nullable aware context:

- You must initialize a variable of a reference type `T` with a non-null value, and you can never assign a value that might be `null`.
- You can initialize a variable of a reference type `T?` with `null` or assign `null`, but you must check it against `null` before dereferencing.
- When you apply the null-forgiving operator to a variable `m` of type `T?`, as in `m!`, the variable is considered to be non-null.

The compiler enforces the distinctions between a non-nullable reference type `T` and a nullable reference type `T?` by using the preceding rules. A variable of type `T` and a variable of type `T?` are the same .NET type. The following example declares a non-nullable string and a nullable string, and then uses the null-forgiving operator to assign a value to a non-nullable string:

:::code language="csharp" source="snippets/shared/NullableReferenceTypes.cs" id="SnippetCoreSyntax":::

The variables `notNull` and `nullable` both use the <xref:System.String> type. Because the non-nullable and nullable types both use the same type, you can't use a nullable reference type in several locations. In general, you can't use a nullable reference type as a base class or implemented interface. You can't use a nullable reference type in any object creation or type testing expression. You can't use a nullable reference type as the type of a member access expression. The following examples show these constructs:

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

> [!IMPORTANT]
> Nullable reference annotations don't introduce behavior changes, but other libraries might use reflection to produce different runtime behavior for nullable and non-nullable reference types. Notably, Entity Framework Core reads nullable attributes. It interprets a nullable reference as an optional value, and a non-nullable reference as a required value.

In a nullable enabled context, the compiler performs static analysis on variables of any reference type, both nullable and non-nullable. The compiler tracks the *null-state* of each reference variable as either *not-null* or *maybe-null*. The default state of a non-nullable reference is *not-null*. The default state of a nullable reference is *maybe-null*.

Non-nullable reference types should always be safe to dereference because their *null-state* is *not-null*. To enforce that rule, the compiler issues warnings if a non-nullable reference type isn't initialized to a non-null value. You must assign local variables where you declare them. Every field must be assigned a *not-null* value, in a field initializer or every constructor. The compiler issues warnings when a non-nullable reference is assigned to a reference whose state is *maybe-null*. Generally, a non-nullable reference is *not-null* and no warnings are issued when you dereference those variables.

> [!NOTE]
> If you assign a *maybe-null* expression to a non-nullable reference type, the compiler generates a warning. The compiler then generates warnings for that variable until it's assigned to a *not-null* expression.

You can initialize or assign `null` to nullable reference types. Therefore, static analysis must determine that a variable is *not-null* before it's dereferenced. If a nullable reference is determined to be *maybe-null*, assigning it to a non-nullable reference variable generates a compiler warning. The following class shows examples of these warnings:

:::code language="csharp" source="snippets/shared/NullableReferenceTypes.cs" id="SnippetClassWithNullable":::

The following snippet shows where the compiler emits warnings when using this class:

:::code language="csharp" source="snippets/shared/NullableReferenceTypes.cs" id="SnippetLocalWarnings":::

The preceding examples demonstrate how compiler's static analysis determines the *null-state* of reference variables. The compiler applies language rules for null checks and assignments to inform its analysis. The compiler can't make assumptions about the semantics of methods or properties. If you call methods that perform null checks, the compiler can't know those methods affect a variable's *null-state*. You can add attributes to your APIs to inform the compiler about the semantics of arguments and return values. Many common APIs in the .NET libraries have these attributes. For example, the compiler correctly interprets <xref:System.String.IsNullOrEmpty%2A> as a null check. For more information about the attributes that apply to *null-state* static analysis, see the article on [Nullable attributes](../attributes/nullable-analysis.md).

## Setting the nullable context

You can control the nullable context in two ways. At the project level, add the `<Nullable>enable</Nullable>` project setting. In a single C# source file, add the `#nullable enable` pragma to enable the nullable context. See the article on [setting a nullable strategy](../../nullable-migration-strategies.md). Before .NET 6, new projects use the default, `<Nullable>disable</Nullable>`. Beginning with .NET 6, new projects include the `<Nullable>enable</Nullable>` element in the project file.

## C# language specification

For more information, see the [Nullable reference types](~/_csharpstandard/standard/types.md#89-reference-types-and-nullability) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Nullable value types](nullable-value-types.md)
