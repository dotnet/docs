---
title: "Identifier names - rules and conventions"
description: "Learn the rules for valid identifier names in the C# programming language. In addition, learn the common naming conventions used by the .NET runtime team and the .NET docs team."
ms.date: 11/27/2023
---
# C# identifier naming rules and conventions

An **identifier** is the name you assign to a type (class, interface, struct, delegate, or enum), member, variable, or namespace.

## Naming rules

Valid identifiers must follow these rules. The C# compiler produces an error for any identifier that doesn't follow these rules:

- Identifiers must start with a letter or underscore (`_`).
- Identifiers can contain Unicode letter characters, decimal digit characters, Unicode connecting characters, Unicode combining characters, or Unicode formatting characters. For more information on Unicode categories, see the [Unicode Category Database](https://www.unicode.org/reports/tr44/).

You can declare identifiers that match C# keywords by using the `@` prefix on the identifier. The `@` isn't part of the identifier name. For example, `@if` declares an identifier named `if`. These [verbatim identifiers](../../language-reference/tokens/verbatim.md) are primarily for interoperability with identifiers declared in other languages.

For a complete definition of valid identifiers, see the [Identifiers article in the C# Language Specification](~/_csharpstandard/standard/lexical-structure.md#643-identifiers).

> [!IMPORTANT]
> [The C# language specification](~/_csharpstandard/standard/lexical-structure.md#643-identifiers) only allows letter (Lu, Ll, Lt, Lm, or Nl), digit (Nd), connecting (Pc), combining (Mn or Mc), and formatting (Cf) categories. Anything outside that is automatically replaced using `_`. This might impact certain Unicode characters.

## Naming conventions

In addition to the rules, conventions for identifier names are used throughout the .NET APIs. These conventions provide consistency for names, but the compiler doesn't enforce them. You're free to use different conventions in your projects.

By convention, C# programs use `PascalCase` for type names, namespaces, and all public members. In addition, the `dotnet/docs` team uses the following conventions, adopted from the [.NET Runtime team's coding style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md):

- Interface names start with a capital `I`.
- Attribute types end with the word `Attribute`.
- Enum types use a singular noun for nonflags, and a plural noun for flags.
- Identifiers shouldn't contain two consecutive underscore (`_`) characters. Those names are reserved for compiler-generated identifiers.
- Use meaningful and descriptive names for variables, methods, and classes.
- Prefer clarity over brevity.
- Use PascalCase for class names and method names.
- Use camelCase for method arguments, local variables, and private fields.
- Use PascalCase for constant names, both fields and local constants.
- Private instance fields start with an underscore (`_`).
- Static fields start with `s_`. This convention isn't the default Visual Studio behavior, nor part of the [Framework design guidelines](../../../standard/design-guidelines/names-of-type-members.md#names-of-fields), but is [configurable in editorconfig](../../../fundamentals/code-analysis/style-rules/naming-rules.md).
- Avoid using abbreviations or acronyms in names, except for widely known and accepted abbreviations.
- Use meaningful and descriptive namespaces that follow the reverse domain name notation.
- Choose assembly names that represent the primary purpose of the assembly.
- Avoid using single-letter names, except for simple loop counters. Also, syntax examples that describe the syntax of C# constructs often use the following single-letter names that match the convention used in the [C# language specification](~/_csharpstandard/standard/readme.md). Syntax examples are an exception to the rule.

  - Use `S` for structs, `C` for classes.
  - Use `M` for methods.
  - Use `v` for variables, `p` for parameters.
  - Use `r` for `ref` parameters.

> [!TIP]
> You can enforce naming conventions that concern capitalization, prefixes, suffixes, and word separators by using [code-style naming rules](../../../fundamentals/code-analysis/style-rules/naming-rules.md).

In the following examples, guidance pertaining to elements marked `public` is also applicable when working with `protected` and `protected internal` elements, all of which are intended to be visible to external callers.

### Pascal case

Use pascal casing ("PascalCasing") when naming a `class`, `interface`, `struct`, or `delegate` type.

```csharp
public class DataService
{
}
```

```csharp
public record PhysicalAddress(
    string Street,
    string City,
    string StateOrProvince,
    string ZipCode);
```

```csharp
public struct ValueCoordinate
{
}
```

```csharp
public delegate void DelegateType(string message);
```

When naming an `interface`, use pascal casing in addition to prefixing the name with an `I`. This prefix clearly indicates to consumers that it's an `interface`.

```csharp
public interface IWorkerQueue
{
}
```

When naming `public` members of types, such as fields, properties, events, use pascal casing. Also, use pascal casing for all methods and local functions.

```csharp
public class ExampleEvents
{
    // A public field, these should be used sparingly
    public bool IsValid;

    // An init-only property
    public IWorkerQueue WorkerQueue { get; init; }

    // An event
    public event Action EventProcessing;

    // Method
    public void StartEventProcessing()
    {
        // Local function
        static int CountQueueItems() => WorkerQueue.Count;
        // ...
    }
}
```

When writing positional records, use pascal casing for parameters as they're the public properties of the record.

```csharp
public record PhysicalAddress(
    string Street,
    string City,
    string StateOrProvince,
    string ZipCode);
```

For more information on positional records, see [Positional syntax for property definition](../../language-reference/builtin-types/record.md#positional-syntax-for-property-and-field-definition).

### Camel case

Use camel casing ("camelCasing") when naming `private` or `internal` fields and prefix them with `_`. Use camel casing when naming local variables, including instances of a delegate type.

```csharp
public class DataService
{
    private IWorkerQueue _workerQueue;
}
```

> [!TIP]
> When editing C# code that follows these naming conventions in an IDE that supports statement completion, typing `_` will show all of the object-scoped members.

When working with `static` fields that are `private` or `internal`, use the `s_` prefix and for thread static use `t_`.

```csharp
public class DataService
{
    private static IWorkerQueue s_workerQueue;

    [ThreadStatic]
    private static TimeSpan t_timeSpan;
}
```

When writing method parameters, use camel casing.

```csharp
public T SomeMethod<T>(int someNumber, bool isValid)
{
}
```

For more information on C# naming conventions, see the [.NET Runtime team's coding style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md).

### Type parameter naming guidelines

The following guidelines apply to type parameters on generic type parameters. Type parameters are the placeholders for arguments in a generic type or a generic method. You can read more about [generic type parameters](../../programming-guide/generics/generic-type-parameters.md) in the C# programming guide.

- **Do** name generic type parameters with descriptive names, unless a single letter name is completely self explanatory and a descriptive name wouldn't add value.

   :::code language="./snippets/coding-conventions" source="./snippets/coding-conventions/Program.cs" id="TypeParametersOne":::

- **Consider** using `T` as the type parameter name for types with one single letter type parameter.

   :::code language="./snippets/coding-conventions" source="./snippets/coding-conventions/Program.cs" id="TypeParametersTwo":::

- **Do** prefix descriptive type parameter names with "T".

   :::code language="./snippets/coding-conventions" source="./snippets/coding-conventions/Program.cs" id="TypeParametersThree":::

- **Consider** indicating constraints placed on a type parameter in the name of parameter. For example, a parameter constrained to `ISession` might be called `TSession`.

The code analysis rule [CA1715](/visualstudio/code-quality/ca1715) can be used to ensure that type parameters are named appropriately.

### Extra naming conventions

- Examples that don't include [using directives](../../language-reference/keywords/using-directive.md), use namespace qualifications. If you know that a namespace is imported by default in a project, you don't have to fully qualify the names from that namespace. Qualified names can be broken after a dot (.) if they're too long for a single line, as shown in the following example.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet1":::

- You don't have to change the names of objects that were created by using the Visual Studio designer tools to make them fit other guidelines.
