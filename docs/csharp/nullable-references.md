---
title: Nullable reference types
description: This article provides an overview of nullable reference types. Learn how the feature provides safety against null reference exceptions, for new and existing projects.
ms.subservice: null-safety
ms.date: 12/09/2024
---
# Nullable reference types

*Nullable reference types* are a group of features that minimize the likelihood that your code causes the runtime to throw <xref:System.NullReferenceException?displayProperty=nameWithType>. Three features that help you avoid these exceptions, including the ability to explicitly mark a reference type as *nullable*:

- Improved static flow analysis that determines if a variable might be `null` before dereferencing it.
- Attributes that annotate APIs so that the flow analysis determines *null-state*.
- Variable annotations that developers use to explicitly declare the intended *null-state* for a variable.

The compiler tracks the *null-state* of every expression in your code at compile time. The *null-state* has one of two values:

- *not-null*: The expression is known to be not-`null`.
- *maybe-null*: The expression might be `null`.

Variable annotations determine the *nullability* of a reference type variable:

- *non-nullable*: If you assign a `null` value or a *maybe-null* expression to the variable, the compiler issues a warning. Variables that are *non-nullable* have a default null-state of *not-null*.
- *nullable*: You can assign a `null` value or a *maybe-null* expression to the variable. When the variable's null-state is *maybe-null*, the compiler issues a warning if you dereference the variable. The default null-state for the variable is *maybe-null*.

The rest of this article describes how those three feature areas work to produce warnings when your code might **dereference** a `null` value. Dereferencing a variable means to access one of its members using the `.` (dot) operator, as shown in the following example:

```csharp
string message = "Hello, World!";
int length = message.Length; // dereferencing "message"
```

When you dereference a variable whose value is `null`, the runtime throws a <xref:System.NullReferenceException?displayProperty=nameWithType>.

Similarly warnings can be produced when `[]` notation is used to access a member of an object when the object is `null`:

```csharp
using System;

public class Collection<T>
{
    private T[] array = new T[100];
    public T this[int index]
    {
        get => array[index];
        set => array[index] = value;
    }
}

public static void Main()
{
    Collection<int> c = default;
    c[10] = 1;    // CS8602: Possible dereference of null
}
```

You'll learn about:

- The compiler's [null-state analysis](#null-state-analysis): how the compiler determines if an expression is not-null, or maybe-null.
- [Attributes](#attributes-on-api-signatures) that are applied to APIs that provide more context for the compiler's null-state analysis.
- [Nullable variable annotations](#nullable-variable-annotations) that provide information about your intent for variables. Annotations are useful for fields, parameters, and return values to set the default null-state.
- The rules governing [generic type arguments](#generics). New constraints were added because type parameters can be reference types or value types. The `?` suffix is implemented differently for nullable value types and nullable reference types.
- The [Nullable context](#nullable-context) help you migrate large projects. You can enable warnings and annotations in the nullable context in parts of your app as you migrate. After you address more warnings, you can enable both settings for the entire project.

Finally, you learn known pitfalls for null-state analysis in `struct` types and arrays.

You can also explore these concepts in our Learn module on [Nullable safety in C#](/training/modules/csharp-null-safety).

## Null-state analysis

***Null-state analysis*** tracks the *null-state* of references. An expression is either *not-null* or *maybe-null*. The compiler determines that a variable is *not-null* in two ways:

1. The variable was assigned a value that is known to be *not-null*.
1. The variable was checked against `null` and wasn't assigned since that check.

Any variable that the compiler can't determined as *not-null* is considered *maybe-null*. The analysis provides warnings in situations where you might accidentally dereference a `null` value. The compiler produces warnings based on the *null-state*.

- When a variable is *not-null*, that variable can be dereferenced safely.
- When a variable is *maybe-null*, that variable must be checked to ensure that it isn't `null` before dereferencing it.

Consider the following example:

```csharp
string? message = null;

// warning: dereference null.
Console.WriteLine($"The length of the message is {message.Length}");

var originalMessage = message;
message = "Hello, World!";

// No warning. Analysis determined "message" is not-null.
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

The null-state analysis doesn't trace into called methods. As a result, fields initialized in a common helper method called by all constructors might generate a warning with the following message:

> Non-nullable property '*name*' must contain a non-null value when exiting constructor.

You can address these warnings in one of two ways: *Constructor chaining*, or *nullable attributes* on the helper method. The following code shows an example of each. The `Person` class uses a common constructor called by all other constructors. The `Student` class has a helper method annotated with the <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute?displayProperty=nameWithType> attribute:

:::code language="csharp" source="./language-reference/compiler-messages/snippets/null-warnings/PersonExamples.cs" id="ConstructorChainingAndMemberNotNull":::

Nullable state analysis and the warnings the compiler generates help you avoid program errors by dereferencing `null`. The article on [resolving nullable warnings](language-reference/compiler-messages/nullable-warnings.md) provides techniques for correcting the warnings most likely seen in your code. The diagnostics produced from null state analysis are warnings only.

## Attributes on API signatures

The null-state analysis needs hints from developers to understand the semantics of APIs. Some APIs provide null checks, and should change the *null-state* of a variable from *maybe-null* to *not-null*. Other APIs return expressions that are *not-null* or *maybe-null* depending on the *null-state* of the input arguments. For example, consider the following code that displays a message in upper case:

```csharp
void PrintMessageUpper(string? message)
{
    if (!IsNull(message))
    {
        Console.WriteLine($"{DateTime.Now}: {message.ToUpper()}");
    }
}

bool IsNull(string? s) => s == null;
```

Based on inspection, any developer would consider this code safe, and shouldn't generate warnings. However the compiler doesn't know that `IsNull` provides a null check and issues a warning for the `message.ToUpper()` statement, considering `message` to be a *maybe-null* variable. Use the [`NotNullWhen`](xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute) attribute to fix this warning:

```csharp
bool IsNull([NotNullWhen(false)] string? s) => s == null;
```

This attribute informs the compiler, that, if `IsNull` returns `false`, the parameter `s` isn't null. The compiler changes the *null-state* of `message` to *not-null* inside the `if (!IsNull(message)) {...}` block. No warnings are issued.

Attributes provide detailed information about the null-state of arguments, return values, and members of the object instance used to invoke a member. The details on each attribute can be found in the language reference article on [nullable reference attributes](language-reference/attributes/nullable-analysis.md). As of .NET 5, all .NET runtime APIs are annotated. You improve the static analysis by annotating your APIs to provide semantic information about the *null-state* of arguments and return values.

## Nullable variable annotations

The *null-state* analysis provides robust analysis for local variables. The compiler needs more information from you for member variables. The compiler needs more information to set the *null-state* of all fields at the opening bracket of a member. Any of the accessible constructors could be used to initialize the object. If a member field might ever be set to `null`, the compiler must assume its *null-state* is *maybe-null* at the start of each method.

You use annotations that can declare whether a variable is a **nullable reference type** or a **non-nullable reference type**. These annotations make important statements about the *null-state* for variables:

- **A reference isn't supposed to be null**. The default state of a non-nullable reference variable is *not-null*. The compiler enforces rules that ensure it's safe to dereference these variables without first checking that it isn't null:
  - The variable must be initialized to a non-null value.
  - The variable can never be assigned the value `null`. The compiler issues a warning when code assigns a *maybe-null* expression to a variable that shouldn't be null.
- **A reference might be null**. The default state of a nullable reference variable is *maybe-null*. The compiler enforces rules to ensure that you correctly check for a `null` reference:
  - The variable can only be dereferenced when the compiler can guarantee that the value isn't `null`.
  - These variables can be initialized with the default `null` value and can be assigned the value `null` in other code.
  - The compiler doesn't issue warnings when code assigns a *maybe-null* expression to a variable that might be null.

Any non-nullable reference variable has the initial *null-state* of *not-null*. Any nullable reference variable has the initial *null-state* of *maybe-null*.

A **nullable reference type** is noted using the same syntax as [nullable value types](language-reference/builtin-types/nullable-value-types.md): a `?` is appended to the type of the variable. For example, the following variable declaration represents a nullable string variable, `name`:

```csharp
string? name;
```

When nullable reference types are enabled, any variable where the `?` isn't appended to the type name is a **non-nullable reference type**. That includes all reference type variables in existing code once you enable this feature. However, any implicitly typed local variables (declared using `var`) are **nullable reference types**. As the preceding sections showed, static analysis determines the *null-state* of local variables to determine if they're *maybe-null* before dereferencing it.

Sometimes you must override a warning when you know a variable isn't null, but the compiler determines its *null-state* is *maybe-null*. You use the [null-forgiving operator](language-reference/operators/null-forgiving.md) `!` following a variable name to force the *null-state* to be *not-null*. For example, if you know the `name` variable isn't `null` but the compiler issues a warning, you can write the following code to override the compiler's analysis:

```csharp
name!.Length;
```

Nullable reference types and nullable value types provide a similar semantic concept: A variable can represent a value or object, or that variable might be `null`. However, nullable reference types and nullable value types are implemented differently: nullable value types are implemented using <xref:System.Nullable%601?displayProperty=nameWithType>, and nullable reference types are implemented by attributes read by the compiler. For example, `string?` and `string` are both represented by the same type: <xref:System.String?displayProperty=nameWithType>. However, `int?` and `int` are represented by `System.Nullable<System.Int32>` and <xref:System.Int32?displayProperty=nameWithType>, respectively.

Nullable reference types are a compile time feature. That means it's possible for callers to ignore warnings, intentionally use `null` as an argument to a method expecting a non nullable reference. Library authors should include run-time checks against null argument values. The <xref:System.ArgumentNullException.ThrowIfNull%2A?displayProperty=nameWithType> is the preferred option for checking a parameter against null at run time. Furthermore, the runtime behavior of a program making use of nullable annotations is the same if all the nullable annotations, (`?` and `!`), are removed. Their only purpose is expressing design intent and providing information for null state analysis.

> [!IMPORTANT]
> Enabling nullable annotations can change how Entity Framework Core determines if a data member is required. You can learn more details in the article on [Entity Framework Core Fundamentals: Working with Nullable Reference Types](/ef/core/miscellaneous/nullable-reference-types).

## Generics

Generics require detailed rules to handle `T?` for any type parameter `T`. The rules are necessarily detailed because of history and the different implementation for a nullable value type and a nullable reference type. [Nullable value types](language-reference/builtin-types/nullable-value-types.md) are implemented using the <xref:System.Nullable%601?displayProperty=nameWithType> struct. [Nullable reference types](language-reference/builtin-types/nullable-reference-types.md) are implemented as type annotations that provide semantic rules to the compiler.

- If the type argument for `T` is a reference type, `T?` references the corresponding nullable reference type. For example, if `T` is a `string`, then `T?` is a `string?`.
- If the type argument for `T` is a value type, `T?` references the same value type, `T`. For example, if `T` is an `int`, the `T?` is also an `int`.
- If the type argument for `T` is a nullable reference type, `T?` references that same nullable reference type. For example, if `T` is a `string?`, then `T?` is also a `string?`.
- If the type argument for `T` is a nullable value type, `T?` references that same nullable value type. For example, if `T` is a `int?`, then `T?` is also a `int?`.

For return values, `T?` is equivalent to `[MaybeNull]T`; for argument values, `T?` is equivalent to `[AllowNull]T`. For more information, see the article on [Attributes for null-state analysis](language-reference/attributes/nullable-analysis.md) in the language reference.

You can specify different behavior using [constraints](programming-guide/generics/constraints-on-type-parameters.md):

- The `class` constraint means that `T` must be a non-nullable reference type (for example `string`). The compiler produces a warning if you use a nullable reference type, such as `string?` for `T`.
- The `class?` constraint means that `T` must be a reference type, either non-nullable (`string`) or a nullable reference type (for example `string?`). When the type parameter is a nullable reference type, such as `string?`, an expression of `T?` references that same nullable reference type, such as `string?`.
- The `notnull` constraint means that `T` must be a non-nullable reference type, or a non-nullable value type. If you use a nullable reference type or a nullable value type for the type parameter, the compiler produces a warning. Furthermore, when `T` is a value type, the return value is that value type, not the corresponding nullable value type.

These constraints help provide more information to the compiler on how `T` is used. That helps when developers choose the type for `T` and provides better *null-state* analysis when an instance of the generic type is used.

## Nullable context

The *nullable context* determines how nullable reference type annotations are handled and what warnings are produced by static null state analysis. The nullable context contains two flags: the *annotation* setting and the *warning* setting.

Both the *annotation* and *warning* settings are disabled by default for existing projects. Starting in .NET 6 (C# 10), both flags are enabled by default for *new* projects. The reason for two distinct flags for the nullable context is to make it easier to migrate large projects that predate the introduction of nullable reference types.

For small projects, you can enable nullable reference types, fix warnings, and continue. However, for larger projects and multi-project solutions, that might generate a large number of warnings. You can use pragmas to enable nullable reference types file-by-file as you begin using nullable reference types. The new features that protect against throwing a <xref:System.NullReferenceException?displayProperty=nameWithType> can be disruptive when turned on in an existing codebase:

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

The nullable annotation context and nullable warning context can be set for a project using the [`<Nullable>` element](language-reference/compiler-options/language.md) in your *.csproj* file. This element configures how the compiler interprets the nullability of types and what warnings are emitted. The following table shows the allowable values and summarizes the contexts they specify.

| Context | Dereference warnings | Assignment warnings | Reference types | `?` suffix | `!` operator |
| - | - | - | - | - |
| `disable` | Disabled | Disabled | All are nullable | Produces a warning | Has no effect |
| `enable` | Enabled | Enabled | Non-nullable unless declared with `?` | Declares nullable type | Suppresses warnings for possible `null` assignment |
| `warnings` | Enabled | Not applicable | All are nullable, but members are considered *not-null* at opening brace of methods | Produces a warning |  Suppresses warnings for possible `null` assignment |
| `annotations` | Disabled | Disabled | Non-nullable unless declared with `?` | Declares nullable type | Has no effect |

Reference type variables in code compiled in a *disabled* context are *nullable-oblivious*. You can assign a `null` literal or a *maybe-null* variable to a variable that is *nullable-oblivious*. However, the default state of a *nullable-oblivious* variable is *not-null*.

You can choose which setting is best for your project:

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
- `#nullable disable warnings`: Set the warning flag to **disable**.
- `#nullable enable warnings`: Set the warning flag to **enable**.
- `#nullable restore warnings`: Restores the warning flag to the project settings.
- `#nullable disable annotations`: Set the annotation flag to **disable**.
- `#nullable enable annotations`: Set the annotation flag to **enable**.
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

Those nine combinations provide you with fine-grained control over the diagnostics the compiler emits for your code. You can enable more features in any area you're updating, without seeing more warnings you aren't ready to address yet.

> [!IMPORTANT]
> The global nullable context does not apply for generated code files. Under either strategy, the nullable context is *disabled* for any source file marked as generated. This means any APIs in generated files are not annotated. No nullable warnings are produced for generated files. There are four ways a file is marked as generated:
>
> 1. In the .editorconfig, specify `generated_code = true` in a section that applies to that file.
> 1. Put `<auto-generated>` or `<auto-generated/>` in a comment at the top of the file. It can be on any line in that comment, but the comment block must be the first element in the file.
> 1. Start the file name with *TemporaryGeneratedFile_*
> 1. End the file name with *.designer.cs*, *.generated.cs*, *.g.cs*, or *.g.i.cs*.
>
> Generators can opt-in using the [`#nullable`](language-reference/preprocessor-directives.md#nullable-context) preprocessor directive.

By default, nullable annotation and warning flags are **disabled**. That means that your existing code compiles without changes and without generating any new warnings. Beginning with .NET 6, new projects include the `<Nullable>enable</Nullable>` element in all project templates, setting these flags to **enabled**.

These options provide two distinct strategies to [update an existing codebase](nullable-migration-strategies.md) to use nullable reference types.

## Known pitfalls

Arrays and structs that contain reference types are known pitfalls in nullable references and the static analysis that determines null safety. In both situations, a non-nullable reference might be initialized to `null`, without generating warnings.

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

public struct S<T>
{
    public T Prop { get; set; }
}

public static class Program
{
    public static void Main()
    {
        string s = default(S<string>).Prop;
    }
}
```

In the preceding example, the property `Prop` is `null` at run time. It's assigned to non-nullable string without any warnings.

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

- [Nullable reference types specification](~/_csharpstandard/standard/types.md#893-nullable-reference-types)
- [Unconstrained type parameter annotations](~/_csharplang/proposals/csharp-9.0/unconstrained-type-parameter-annotations.md)
- [Intro to nullable references tutorial](tutorials/nullable-reference-types.md)
- [**Nullable** (C# Compiler option)](language-reference/compiler-options/language.md#nullable)
- [CS8602: Possible dereference of null warning](language-reference/compiler-messages/nullable-warnings.md#possible-dereference-of-null)
