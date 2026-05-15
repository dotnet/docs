---
title: "Nullable reference types"
description: Learn about C# nullable reference types and how to use them
ms.date: 05/15/2026
---
# Nullable reference types (C# reference)

> [!NOTE]
> This article covers nullable reference types. You can also declare [nullable value types](nullable-value-types.md).

Use nullable reference types in code that's in a *nullable aware context*. Nullable reference types, the null static analysis warnings, and the [null-forgiving operator](../operators/null-forgiving.md) are optional language features. All are off by default. You control a *nullable context* at the project level by using build settings, or in code by using pragmas.

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

The preceding examples demonstrate how compiler's static analysis determines the *null-state* of reference variables. The compiler applies language rules for null checks and assignments to inform its analysis. The compiler can't make assumptions about the semantics of methods or properties. If you call methods that perform null checks, the compiler can't know those methods affect a variable's *null-state*. You can add attributes to your APIs to inform the compiler about the semantics of arguments and return values. Many common APIs in the .NET libraries have these attributes. For example, the compiler correctly interprets <xref:System.String.IsNullOrEmpty*> as a null check. For more information about the attributes that apply to *null-state* static analysis, see the article on [Nullable attributes](../attributes/nullable-analysis.md).

## Nullable context

The *nullable context* determines how the compiler handles nullable reference type annotations and what warnings it produces during static null state analysis. The nullable context contains two flags: the *annotation* setting and the *warning* setting.

Both the *annotation* and *warning* settings are disabled by default for existing projects. Starting in .NET 6 (C# 10), both flags are enabled by default for *new* projects. The reason for two distinct flags for the nullable context is to make it easier to migrate large projects that predate the introduction of nullable reference types.

For small projects, you can enable nullable reference types, fix warnings, and continue. However, for larger projects and multi-project solutions, that process might generate a large number of warnings. You can use pragmas to enable nullable reference types file-by-file as you begin using nullable reference types. The new features that protect against throwing a <xref:System.NullReferenceException?displayProperty=nameWithType> can be disruptive when turned on in an existing codebase:

- All explicitly typed reference variables are interpreted as non-nullable reference types.
- The meaning of the `class` constraint in generics changed to mean a non-nullable reference type.
- New warnings are generated because of these new rules.

The **nullable annotation context** determines the compiler's behavior. There are four combinations for the **nullable context** settings:

- *both disabled*: The code is *nullable-oblivious*. *Disable* matches the behavior before nullable reference types were enabled, except the new syntax produces warnings instead of errors.
  - Nullable warnings are disabled.
  - All reference type variables are nullable reference types.
  - Use of the `?` suffix to declare a nullable reference type produces a warning.
  - You can use the null forgiving operator, `!`, but it has no effect.
- *both enabled*: The compiler enables all null reference analysis and all language features.
  - All new nullable warnings are enabled.
  - You can use the `?` suffix to declare a nullable reference type.
  - Reference type variables without the `?` suffix are non-nullable reference types.
  - The null forgiving operator suppresses warnings for a possible dereference of `null`.
- *warning enabled*: The compiler performs all null analysis and emits warnings when code might dereference `null`.
  - All new nullable warnings are enabled.
  - Use of the `?` suffix to declare a nullable reference type produces a warning.
  - All reference type variables are allowed to be null. However, members have the *null-state* of *not-null* at the opening brace of all methods unless declared with the `?` suffix.
  - You can use the null forgiving operator, `!`.
- *annotations enabled*: The compiler doesn't emit warnings when code might dereference `null`, or when you assign a maybe-null expression to a non-nullable variable.
  - All new nullable warnings are disabled.
  - You can use the `?` suffix to declare a nullable reference type.
  - Reference type variables without the `?` suffix are non-nullable reference types.
  - You can use the null forgiving operator, `!`, but it has no effect.

You can set the nullable annotation context and nullable warning context for a project by using the [`<Nullable>` element](language-reference/compiler-options/language.md) in your *.csproj* file. This element configures how the compiler interprets the nullability of types and what warnings it emits. The following table shows the allowable values and summarizes the contexts they specify.

| Context | Dereference warnings | Assignment warnings | Reference types | `?` suffix | `!` operator |
| - | - | - | - | - |
| `disable` | Disabled | Disabled | All are nullable | Produces a warning | Has no effect |
| `enable` | Enabled | Enabled | Non-nullable unless declared with `?` | Declares nullable type | Suppresses warnings for possible `null` assignment |
| `warnings` | Enabled | Not applicable | All are nullable, but members are considered *not-null* at opening brace of methods | Produces a warning |  Suppresses warnings for possible `null` assignment |
| `annotations` | Disabled | Disabled | Non-nullable unless declared with `?` | Declares nullable type | Has no effect |

Reference type variables in code compiled in a *disabled* context are *nullable-oblivious*. You can assign a `null` literal or a *maybe-null* variable to a variable that is *nullable-oblivious*. However, the default state of a *nullable-oblivious* variable is *not-null*.

Choose the setting that best fits your project:

- Choose *disable* for legacy projects that you don't want to update based on diagnostics or new features.
- Choose *warnings* to determine where your code might throw <xref:System.NullReferenceException?displayProperty=nameWithType>s. You can address those warnings before modifying code to enable non-nullable reference types.
- Choose *annotations* to express your design intent before enabling warnings.
- Choose *enable* for new projects and active projects where you want to protect against null reference exceptions.

**Example**:

```xml
<Nullable>enable</Nullable>
```

You can also use directives to set these same flags anywhere in your source code. These directives are most useful when you're migrating a large codebase.

- `#nullable enable`: Sets the annotation and warning flags to **enable**.
- `#nullable disable`: Sets the annotation and warning flags to **disable**.
- `#nullable restore`: Restores the annotation flag and warning flag to the project settings.
- `#nullable disable warnings`: Sets the warning flag to **disable**.
- `#nullable enable warnings`: Sets the warning flag to **enable**.
- `#nullable restore warnings`: Restores the warning flag to the project settings.
- `#nullable disable annotations`: Sets the annotation flag to **disable**.
- `#nullable enable annotations`: Sets the annotation flag to **enable**.
- `#nullable restore annotations`: Restores the annotation flag to the project settings.

For any line of code, you can set any of the following combinations:

| Warning flag    | Annotation flag    | Use                                    |
|:---------------:|:------------------:|----------------------------------------|
| project default | project default    | Default                                |
| enable          | disable            | Fix analysis warnings                  |
| enable          | project default    | Fix analysis warnings                  |
| project default | enable             | Add type annotations                   |
| enable          | enable             | Code already migrated                  |
| disable         | enable             | Annotate code before fixing warnings   |
| disable         | disable            | Adding legacy code to migrated project |
| project default | disable            | Rarely                                 |
| disable         | project default    | Rarely                                 |

These nine combinations give you fine-grained control over the diagnostics the compiler emits for your code. You can enable more features in any area you're updating, without seeing more warnings you aren't ready to address yet.

> [!IMPORTANT]
> The global nullable context doesn't apply to generated code files. Under either strategy, the nullable context is *disabled* for any source file marked as generated. This condition means the compiler doesn't annotate any APIs in generated files. The compiler doesn't produce nullable warnings for generated files. A file is marked as generated in any of the following four ways:
>
> 1. In the .editorconfig, specify `generated_code = true` in a section that applies to that file.
> 1. Put `<auto-generated>` or `<auto-generated/>` in a comment at the top of the file. It can be on any line in that comment, but the comment block must be the first element in the file.
> 1. Start the file name with *TemporaryGeneratedFile_*
> 1. End the file name with *.designer.cs*, *.generated.cs*, *.g.cs*, or *.g.i.cs*.
>
> Generators can opt-in by using the [`#nullable`](language-reference/preprocessor-directives.md#nullable-context) preprocessor directive.

By default, nullable annotation and warning flags are **disabled**. That default means your existing code compiles without changes and without generating any new warnings. Beginning with .NET 6, new projects include the `<Nullable>enable</Nullable>` element in all project templates, setting these flags to **enabled**.

These options provide two distinct strategies to [update an existing codebase](nullable-migration-strategies.md) to use nullable reference types.

## Setting the nullable context

You can control the nullable context in two ways. At the project level, add the `<Nullable>enable</Nullable>` project setting. In a single C# source file, add the `#nullable enable` pragma to enable the nullable context. For more information, see [setting a nullable strategy](../../advanced-topics/update-applications/nullable-migration-strategies.md). Before .NET 6, new projects use the default, `<Nullable>disable</Nullable>`. Beginning with .NET 6, new projects include the `<Nullable>enable</Nullable>` element in the project file.

## Generics

When you use a type parameter, `T`, as its nullable counterpart, `T?`, the actual type argument determines how the `?` is interpreted. Consider the following generic declaration:

```csharp
public class Box<T>
{
    public T Contents { get; set; }
}
```

Because a type parameter can stand for either a reference type or a value type, the meaning of `T?` depends on which type argument the caller supplies. The following rules describe what `T?` resolves to when `T` has no constraints:

- **The type argument is a non-nullable reference type.** For `Box<string>`, `T` is `string` and `T?` is `string?`—the corresponding nullable reference type.
- **The type argument is a value type.** For `Box<int>`, `T` is `int` and `T?` is also `int`—the same value type. The annotation has no effect on value types unless the type parameter has the `struct` constraint, in which case `T?` means <xref:System.Nullable%601> (`int?`).
- **The type argument is already nullable.** For `Box<string?>`, `T` is `string?` and `T?` is still `string?`. You don't get a "doubly nullable" type.

*Constraints* restrict which type arguments are allowed. They also let the compiler reason about how `T` can be used:

- `where T : class` requires a non-nullable reference type. `Box<string>` is allowed; `Box<string?>` produces a warning.
- `where T : class?` allows either a nullable or a non-nullable reference type. Both `Box<string>` and `Box<string?>` are allowed.
- `where T : struct` requires a non-nullable value type. `Box<int>` is allowed; `Box<int?>` isn't. With this constraint, `T?` inside the generic means <xref:System.Nullable%601>—for `Box<int>`, `T?` is `int?`.
- `where T : notnull` requires a non-nullable reference or value type. `Box<string>` and `Box<int>` are allowed; `Box<string?>` produces a warning.
- `where T : BaseType` requires a non-nullable reference type that derives from `BaseType`. Append `?` (`where T : BaseType?`) to allow nullable derived types as well.

The constraints help the compiler reason about how a generic type parameter is used:

:::code language="csharp" source="snippets/shared/NullableReferenceTypes.cs" id="Generics":::

## C# language specification

For more information, see the [Nullable reference types](~/_csharpstandard/standard/types.md#89-reference-types-and-nullability) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Nullable value types](nullable-value-types.md)
