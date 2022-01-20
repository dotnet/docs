---
title: Nullable reference types
description: This article provides an overview of nullable reference types, added in C# 8.0. You'll learn how the feature provides safety against null reference exceptions, for new and existing projects.
ms.technology: csharp-null-safety
ms.date: 09/01/2021
---
# Nullable reference types

Prior to C# 8.0, all reference types were nullable. *Nullable reference types* refers to a group of features introduced in C# 8.0 that you can use to minimize the likelihood that your code causes the runtime to throw <xref:System.NullReferenceException?displayProperty=nameWithType>. *Nullable reference types* includes three features that help you avoid these exceptions, including the ability to explicitly mark a reference type as *nullable*:

- Improved static flow analysis that determines if a variable may be `null` before dereferencing it.
- Attributes that annotate APIs so that the flow analysis determines *null-state*.
- Variable annotations that developers use to explicitly declare the intended *null-state* for a variable.

Null-state analysis and variable annotations are disabled by default for existing projects&mdash;meaning that all reference types continue to be nullable. Starting in .NET 6, they're enabled by default for *new* projects. For information about enabling these features by declaring a *nullable annotation context*, see [Nullable contexts](#nullable-contexts).

The rest of this article describes how those three feature areas work to produce warnings when your code may be **dereferencing** a `null` value. Dereferencing a variable means to access one of its members using the `.` (dot) operator, as shown in the following example:

```csharp
string message = "Hello, World!";
int length = message.Length; // dereferencing "message"
```

When you dereference a variable whose value is `null`, the runtime throws a <xref:System.NullReferenceException?displayProperty=nameWithType>.

## Null state analysis

***Null-state analysis*** tracks the *null-state* of references. This static analysis emits warnings when your code may dereference `null`. You can address these warnings to minimize incidences when the runtime throws a <xref:System.NullReferenceException?displayProperty=nameWithType>. The compiler uses static analysis to determine the *null-state* of a variable. A variable is either *not-null* or *maybe-null*. The compiler determines that a variable is *not-null* in two ways:

1. The variable has been assigned to a value that is known to be *not null*.
1. The variable has been checked against `null` and hasn't been modified since that check.

Any variable that the compiler hasn't determined as *not-null* is considered *maybe-null*. The analysis provides warnings in situations where you may accidentally dereference a `null` value. The compiler produces warnings based on the *null-state*.

- When a variable is *not-null*, that variable may be dereferenced safely.
- When a variable is *maybe-null*, that variable must be checked to ensure that it isn't `null` before dereferencing it.

Consider the following example:

```csharp
string message = null;

// warning: dereference null.
Console.WriteLine($"The length of the message is {message.Length}");

var originalMessage = message;
message = "Hello, World!";

// No warning. Analysis determined "message" is not null.
Console.WriteLine($"The length of the message is {message.Length}");

// warning!
Console.WriteLine(originalMessage.Length);
```

In the preceding example, the compiler determines that `message` is *maybe-null* when the first message is printed. There's no warning for the second message. The final line of code produces a warning because `originalMessage` might be null. The following example shows a more practical use for traversing a tree of nodes to the root, processing each node during the traversal:

```csharp
void FindRoot(Node node, Action<Node> processNode)
{
    for (var current = node; current != null; current = current.Parent)
    {
        processNode(current);
    }
}
```

The previous code doesn't generate any warnings for dereferencing the variable `current`. Static analysis determines that `current` is never dereferenced when it's *maybe-null*. The variable `current` is checked against `null` before `current.Parent` is accessed, and before passing `current` to the `ProcessNode` action. The previous examples show how the compiler determines *null-state* for local variables when initialized, assigned, or compared to `null`.

> [!NOTE]
> A number of improvements to definite assignment and null state analysis were added in C# 10. When you upgrade to C# 10, you may find fewer nullable warnings that are false positives. You can learn more about the improvements in the [features specification for definite assignment improvements](~/_csharplang/proposals/csharp-10.0/improved-definite-assignment.md).

## Attributes on API signatures

The null state analysis needs hints from developers to understand the semantics of APIs. Some APIs provide null checks, and should change the *null-state* of a variable from *maybe-null* to *not-null*. Other APIs return expressions that are *not-null* or *maybe-null* depending on the *null-state* of the input arguments. For example, consider the following code that displays a message:

```csharp
public void PrintMessage(string message)
{
    if (!string.IsNullOrWhiteSpace(message))
    {
        Console.WriteLine($"{DateTime.Now}: {message}");
    }
}
```

Based on inspection, any developer would consider this code safe, and shouldn't generate warnings. The compiler doesn't know that `IsNullOrWhiteSpace` provides a null check. You apply attributes to inform the compiler that `message` is *not-null* if and only if `IsNullOrWhiteSpace` returns `false`. In the previous example, the signature includes the [`NotNullWhen`](xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute) to indicate the null state of `message`:

```csharp
public static bool IsNullOrWhiteSpace([NotNullWhen(false)] string message);
```

Attributes provide detailed information about the null state of arguments, return values, and members of the object instance used to invoke a member. The details on each attribute can be found in the language reference article on [nullable reference attributes](language-reference/attributes/nullable-analysis.md). The .NET runtime APIs have all been annotated in .NET 5. You improve the static analysis by annotating your APIs to provide semantic information about the *null-state* of arguments and return values.

## Nullable variable annotations

The *null-state* analysis provides robust analysis for most variables. The compiler needs more information from you for member variables. The compiler can't make assumptions about the order in which public members are accessed. Any public member could be accessed in any order. Any of the accessible constructors could be used to initialize the object. If a member field might ever be set to `null`, the compiler must assume its *null-state* is *maybe-null* at the start of each method.

You use annotations that can declare whether a variable is a **nullable reference type** or a **non-nullable reference type**. These annotations make important statements about the *null-state* for variables:

- **A reference isn't supposed to be null**. The default state of a nonnullable reference variable is *not-null*. The compiler enforces rules that ensure it's safe to dereference these variables without first checking that it isn't null:
  - The variable must be initialized to a non-null value.
  - The variable can never be assigned the value `null`. The compiler issues a warning when code assigns a *maybe-null* expression to a variable that shouldn't be null.
- **A reference may be null**. The default state of a nullable reference variable is *maybe-null*. The compiler enforces rules to ensure that you've correctly checked for a `null` reference:
  - The variable may only be dereferenced when the compiler can guarantee that the value isn't `null`.
  - These variables may be initialized with the default `null` value and may be assigned the value `null` in other code.
  - The compiler doesn't issue warnings when code assigns a *maybe-null* expression to a variable that may be null.

Any reference variable that isn't supposed to be `null` has a *null-state* of *not-null*. Any reference variable that may be `null` initially has the *null-state* of *maybe-null*.

A **nullable reference type** is noted using the same syntax as [nullable value types](language-reference/builtin-types/nullable-value-types.md): a `?` is appended to the type of the variable. For example, the following variable declaration represents a nullable string variable, `name`:

```csharp
string? name;
```

Any variable where the `?` isn't appended to the type name is a **non-nullable reference type**. That includes all reference type variables in existing code when you've enabled this feature. However, any implicitly typed local variables (declared using `var`) are **nullable reference types**. As the preceding sections showed, static analysis determines the *null-state* of local variables to determine if they're *maybe-null*.

Sometimes you must override a warning when you know a variable isn't null, but the compiler determines its *null-state* is *maybe-null*. You use the [null-forgiving operator](language-reference/operators/null-forgiving.md) `!` following a variable name to force the *null-state* to be *not-null*. For example, if you know the `name` variable isn't `null` but the compiler issues a warning, you can write the following code to override the compiler's analysis:

```csharp
name!.Length;
```

Nullable reference types and nullable value types provide a similar semantic concept: A variable can represent a value or object, or that variable may be `null`. However, nullable reference types and nullable value types are implemented differently: nullable value types are implemented using <xref:System.Nullable%601?displayProperty=nameWithType>, and nullable reference types are implemented by attributes read by the compiler. For example, `string?` and `string` are both represented by the same type: <xref:System.String?displayProperty=nameWithType>. However, `int?` and `int` are represented by `System.Nullable<System.Int32>` and <xref:System.Int32?displayProperty=nameWithType>, respectively.

> [!IMPORTANT]
> Enabling nullable annotations can change how Entity Framework Core determines if a data member is required. You can learn more details in the article on [Entity Framework Core Fundamentals: Working with Nullable Reference Types](/ef/core/miscellaneous/nullable-reference-types).

## Generics

Generics require detailed rules to handle `T?` for any type parameter `T`. The rules are necessarily detailed because of history and the different implementation for a nullable value type and a nullable reference type. [Nullable value types](language-reference/builtin-types/nullable-value-types.md) are implemented using the <xref:System.Nullable%601?displayProperty=nameWithType> struct. [Nullable reference types](language-reference/builtin-types/nullable-reference-types.md) are implemented as type annotations that provide semantic rules to the compiler.

In C# 8.0, using `T?` without constraining `T` to be a `struct` or a `class` did not compile. That enabled the compiler to interpret `T?` clearly. That restriction was removed in C# 9.0, by defining the following rules for an unconstrained type parameter `T`:

- If the type argument for `T` is a reference type, `T?` references the corresponding nullable reference type. For example, if `T` is a `string`, then `T?` is a `string?`.
- If the type argument for `T` is a value type, `T?` references the same value type, `T`. For example, if `T` is an `int`, the `T?` is also an `int`.
- If the type argument for `T` is a nullable reference type, `T?` references that same nullable reference type. For example, if `T` is a `string?`, then `T?` is also a `string?`.
- If the type argument for `T` is a nullable value type, `T?` references that same nullable value type. For example, if `T` is a `int?`, then `T?` is also a `int?`.

For return values, `T?` is equivalent to `[MaybeNull]T`; for argument values, `T?` is equivalent to `[AllowNull]T`. For more information, see the article on [Attributes for null-state analysis](language-reference/attributes/nullable-analysis.md) in the language reference.

You can specify different behavior using [constraints](programming-guide/generics/constraints-on-type-parameters.md):

- The `class` constraint means that `T` must be a non-nullable reference type (for example `string`). The compiler produces a warning if you use a nullable reference type, such as `string?` for `T`.
- The `class?` constraint means that `T` must be a reference type, either non-nullable (`string`) or a nullable reference type (for example `string?`). When the type parameter is a nullable reference type, such as `string?`, an expression of `T?` references that same nullable reference type, such as `string?`.
- The `notnull` constraint means that `T` must be a non-nullable reference type, or a non-nullable value type. If you use a nullable reference type or a nullable value type for the type parameter, the compiler produces a warning. Furthermore, when `T` is a value type, the return value is that value type, not the corresponding nullable value type.

These constraints help provide more information to the compiler on how `T` will be used. That helps when developers choose the type for `T`, and provides better *null-state* analysis when an instance of the generic type is used.

## Nullable contexts

The new features that protect against throwing a <xref:System.NullReferenceException?displayProperty=nameWithType> can be disruptive when turned on in an existing codebase:

- All explicitly typed reference variables are interpreted as non-nullable reference types.
- The meaning of the `class` constraint in generics changed to mean a non-nullable reference type.
- New warnings are generated because of these new rules.

You must explicitly opt in to use these features in your existing projects. That provides a migration path and preserves backwards compatibility. Nullable contexts enable fine-grained control for how the compiler interprets reference type variables. The **nullable annotation context** determines the compiler's behavior. There are four values for the **nullable annotation context**:

- *disabled*: The compiler behaves similarly to C# 7.3 and earlier:
  - Nullable warnings are disabled.
  - All reference type variables are nullable reference types.
  - You can't declare a variable as a nullable reference type using the `?` suffix on the type.
  - You can use the null forgiving operator, `!`, but it has no effect.
- *enabled*: The compiler enables all null reference analysis and all language features.
  - All new nullable warnings are enabled.
  - You can use the `?` suffix to declare a nullable reference type.
  - All other reference type variables are non-nullable reference types.
  - The null forgiving operator suppresses warnings for a possible assignment to `null`.
- *warnings*: The compiler performs all null analysis and emits warnings when code might dereference `null`.
  - All new nullable warnings are enabled.
  - Use of the `?` suffix to declare a nullable reference type produces a warning.
  - All reference type variables are allowed to be null. However, members have the *null-state* of *not-null* at the opening brace of all methods unless declared with the `?` suffix.
  - You can use the null forgiving operator, `!`.
- *annotations*: The compiler doesn't perform null analysis or emit warnings when code might dereference `null`.
  - All new nullable warnings are disabled.
  - You can use the `?` suffix to declare a nullable reference type.
  - All other reference type variables are non-nullable reference types.
  - You can use the null forgiving operator, `!`, but it has no effect.

The nullable annotation context and nullable warning context can be set for a project using the [`<Nullable>` element](language-reference/compiler-options/language.md) in your *.csproj* file. This element configures how the compiler interprets the nullability of types and what warnings are emitted. The following table shows the allowable values and summarizes the contexts they specify.

| Context | Dereference warnings | Assignment warnings | Reference types | `?` suffix | `!` operator |
| - | - | - | - | - |
| `disable` | Disabled | Disabled | All are nullable | Can't be used | Has no effect |
| `enable` | Enabled | Enabled | Non-nullable unless declared with `?` | Declares nullable type | Suppresses warnings for possible `null` assignment |
| `warnings` | Enabled | Not applicable | All are nullable, but members are considered *not null* at opening brace of methods | Produces a warning |  Suppresses warnings for possible `null` assignment |
| `annotations` | Disabled | Disabled | Non-nullable unless declared with `?` | Declares nullable type | Has no effect |

Reference type variables in code compiled before C# 8, or in a *disabled* context is *nullable-oblivious*. You can assign a `null` literal or a *maybe-null* variable to a variable that is *nullable oblivious*. However, the default state of a *nullable-oblivious* variable is *not-null*.

You can choose which setting is best for your project:

- Choose *disable* for legacy projects that you don't want to update based on diagnostics or new features.
- Choose *warnings* to determine where your code may throw <xref:System.NullReferenceException?displayProperty=nameWithType>s. You can address those warnings before modifying code to enable non-nullable reference types.
- Choose *annotations* to express your design intent before enabling warnings.
- Choose *enable* for new projects and active projects where you want to protect against null reference exceptions.

**Example**:

```xml
<Nullable>enable</Nullable>
```

You can also use directives to set these same contexts anywhere in your source code. These are most useful when you're migrating a large codebase.

- `#nullable enable`: Sets the nullable annotation context and nullable warning context to **enable**.
- `#nullable disable`: Sets the nullable annotation context and nullable warning context to **disable**.
- `#nullable restore`: Restores the nullable annotation context and nullable warning context to the project settings.
- `#nullable disable warnings`: Set the nullable warning context to **disable**.
- `#nullable enable warnings`: Set the nullable warning context to **enable**.
- `#nullable restore warnings`: Restores the nullable warning context to the project settings.
- `#nullable disable annotations`: Set the nullable annotation context to **disable**.
- `#nullable enable annotations`: Set the nullable annotation context to **enable**.
- `#nullable restore annotations`: Restores the annotation warning context to the project settings.

For any line of code, you can set any of the following combinations:

| Warning context | Annotation context | Use                                    |
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

Those nine combinations provide you with fine-grained control over the diagnostics the compiler emits for your code. You can enable more features in any area you're updating, without seeing additional warnings you aren't ready to address yet.

> [!IMPORTANT]
> The global nullable context does not apply for generated code files. Under either strategy, the nullable context is *disabled* for any source file marked as generated. This means any APIs in generated files are not annotated. There are four ways a file is marked as generated:
>
> 1. In the .editorconfig, specify `generated_code = true` in a section that applies to that file.
> 1. Put `<auto-generated>` or `<auto-generated/>` in a comment at the top of the file. It can be on any line in that comment, but the comment block must be the first element in the file.
> 1. Start the file name with *TemporaryGeneratedFile_*
> 1. End the file name with *.designer.cs*, *.generated.cs*, *.g.cs*, or *.g.i.cs*.
>
> Generators can opt-in using the [`#nullable`](language-reference/preprocessor-directives.md#nullable-context) preprocessor directive.

By default, nullable annotation and warning contexts are **disabled**. That means that your existing code compiles without changes and without generating any new warnings. Beginning with .NET 6, new projects include the `<Nullable>enable</Nullable>` element in all project templates.

These options provide two distinct strategies to [update an existing codebase](nullable-migration-strategies.md) to use nullable reference types.

## Known pitfalls

Arrays and structs that contain reference types are known pitfalls in nullable references and the static analysis that determines null safety. In both situations, a non-nullable reference may be initialized to `null`, without generating warnings.

### Structs

A struct that contains non-nullable reference types allows assigning `default` for it without any warnings. Consider the following example:

```csharp
using System;

#nullable enable

public struct Student
{
    public string FirstName;
    public string? MiddleName;
    public string LastName;
}

public static class Program
{
    public static void PrintStudent(Student student)
    {
        Console.WriteLine($"First name: {student.FirstName.ToUpper()}");
        Console.WriteLine($"Middle name: {student.MiddleName?.ToUpper()}");
        Console.WriteLine($"Last name: {student.LastName.ToUpper()}");
    }

    public static void Main() => PrintStudent(default);
}
```

In the preceding example, there's no warning in `PrintStudent(default)` while the non-nullable reference types `FirstName` and `LastName` are null.

Another more common case is when you deal with generic structs. Consider the following example:

```csharp
#nullable enable

public struct Foo<T>
{
    public T Bar { get; set; }
}

public static class Program
{
    public static void Main()
    {
        string s = default(Foo<string>).Bar;
    }
}
```

In the preceding example, the property `Bar` is going to be `null` at run time, and it's assigned to non-nullable string without any warnings.

### Arrays

Arrays are also a known pitfall in nullable reference types. Consider the following example that doesn't produce any warnings:

```csharp
using System;

#nullable enable

public static class Program
{
    public static void Main()
    {
        string[] values = new string[10];
        string s = values[0];
        Console.WriteLine(s.ToUpper());
    }
}
```

In the preceding example, the declaration of the array shows it holds non-nullable strings, while its elements are all initialized to `null`. Then, the variable `s` is assigned a `null` value (the first element of the array). Finally, the variable `s` is dereferenced causing a runtime exception.

## See also

- [Nullable reference types proposal](~/_csharplang/proposals/csharp-8.0/nullable-reference-types.md)
- [Draft nullable reference types specification](~/_csharplang/proposals/csharp-9.0/nullable-reference-types-specification.md)
- [Unconstrained type parameter annotations](~/_csharplang/proposals/csharp-9.0/unconstrained-type-parameter-annotations.md)
- [Intro to nullable references tutorial](whats-new/tutorials/nullable-reference-types.md)
- [**Nullable** (C# Compiler option)](language-reference/compiler-options/language.md#nullable)
