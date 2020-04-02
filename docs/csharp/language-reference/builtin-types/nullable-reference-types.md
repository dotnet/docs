title: "Nullable reference types - C# reference"
description: Learn about C# nullable reference types and how to use them
ms.date: 04/01/2020
---
# Nullable reference types (C# reference)

> [!NOTE]
> This article covers nullable reference types. You can also declare [nullable value types](nullable-value-types.md).

Nullable reference types are available beginning with C# 8.0, in code that has opted in to a *nullable aware context*. Nullable reference types, the null static analysis warnings and the null forgiveness operator are optional language features turned off by default. A *nullable context* is controlled at the project level using build settings, or in code using pragmas.

 In a nullable aware context:

- A reference type `T` must be initialized to non-null, and may never be assigned a value that may be `null`.
- A reference type `T?` may be initialized or assigned to `null`, but is required to be checked against `null` before de-referencing.
- A variable `m` of type `T?` is considered to be non-null if the *null forgiveness operator* is appended to the variable name, as in `m!`.

The distinctions between a non-nullable reference type `T` and a nullable reference type `T?` are all in the compiler interpretation of the preceding rules. A variable of type `T` and a variable of type `T?` are represented by the same type. The following example declares a non-nullable string, a nullable string, and the null forgiveness operator to assign a value to a non-nullable string:

```csharp
string notNull = "Hello";
string? nullable = default;
notNull = nullable!; // null forgiveness
```

The variable `notNull` and `nullable` are both represented by the <xref:System.String> type. Because the non-nullable and nullable types are both stored as the same type, there are several locations where the nullable reference type can't be used. In general, a nullable reference cannot be used as a base class or implemented interface, in any object creation or type testing expression, or as the type of a member access expression, as the following examples show:

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

The examples in the previous section illustrate the nature of nullable reference types: Nullable reference types are not new class types, but rather annotations on existing reference types. The compiler uses those annotations to help you find potential null reference errors in your code. There is no runtime difference between a non-nullable reference type and a nullable reference type. The compiler does not add any runtime checking for non-nullable reference types. The benefits are in the compile time analysis and warnings generated that can help you find and fix potential null errors in your code. You declare your intent, and the compiler warns you when your code violates that intent.

In a nullable enabled context, the compiler performs static analysis on variables of reference type, both nullable and non-nullable. The compiler tracks the nullable state of each reference variable as either *not null* or *maybe null*. <<<START HERE>>>

- default state of nullable is "maybe null". Static analysis can determine it's not null.
- default state of non-nullable is "not null". Static analysis warns if could be null.

Examples on warnings for non nullable:

- When a local variable is not initialized to a non-null value.
- When a constructor does not assign a non-null value to all fields of a non-nullable reference type. Note that these may be assigned in the body of the constructor, in a field initializer, or in a chained constructor (called using the `: this(...)` syntax).

Examples on warnings for nullable:

- dereference when maybe-null.
- assign to non-nullable when maybe null.

API instrumentation:

The compiler can use the language rules to catch many nullable warnings. HOwever, many APIs that do null checks aren't known to the language. Attributes can help.

## Setting the nullable context

Using the project setting

Using the pragmas

 ## C# language specification

For more information, see the following proposals for the [C# language specification](~/_csharplang/spec/introduction.md):

- [Nullable reference types](~/_csharplang/proposals/csharp-8.0/nullable-reference-types.md)
- [Draft nullable reference types specification](~/_csharplang/proposals/csharp-8.0/nullable-reference-types-specification.md)

## See also

- [C# reference](../index.md)
- [Nullable value types](nullable-value-types.md)
