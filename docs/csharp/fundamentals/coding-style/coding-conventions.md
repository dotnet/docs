---
title: "C# Coding Conventions"
description: Learn about coding conventions in C#. Coding conventions create a consistent look to the code and facilitate copying, changing, and maintaining the code.
ms.date: 07/16/2021
helpviewer_keywords:
  - "coding conventions, C#"
  - "Visual C#, coding conventions"
  - "C# language, coding conventions"
---

# C# Coding Conventions

Coding conventions serve the following purposes:

> [!div class="checklist"]
>
> - They create a consistent look to the code, so that readers can focus on content, not layout.
> - They enable readers to understand the code more quickly by making assumptions based on previous experience.
> - They facilitate copying, changing, and maintaining the code.
> - They demonstrate C# best practices.

> [!IMPORTANT]
> The guidelines in this article are used by Microsoft to develop samples and documentation. They were adopted from the [.NET Runtime, C# Coding Style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md) guidelines. You can use them, or adapt them to your needs. The primary objectives are consistency and readability within your project, team, organization, or company source code.

## Naming conventions

There are several naming conventions to consider when writing C# code.

In the following examples, any of the guidance pertaining to elements marked `public` is also applicable when working with `protected` and `protected internal` elements, all of which are  intended to be visible to external callers.

### Pascal case

Use pascal casing ("PascalCasing") when naming a `class`, `record`, or `struct`.

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

When naming an `interface`, use pascal casing in addition to prefixing the name with an `I`. This clearly indicates to consumers that it's an `interface`.

```csharp
public interface IWorkerQueue
{
}
```

When naming `public` members of types, such as fields, properties, events, methods, and local functions, use pascal casing.

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

For more information on positional records, see [Positional syntax for property definition](../../language-reference/builtin-types/record.md#positional-syntax-for-property-definition).

### Camel case

Use camel casing ("camelCasing") when naming `private` or `internal` fields, and prefix them with `_`.

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

For more information on C# naming conventions, see [C# Coding Style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md).

### Additional naming conventions

- Examples that don't include [using directives](../../language-reference/keywords/using-directive.md), use namespace qualifications. If you know that a namespace is imported by default in a project, you don't have to fully qualify the names from that namespace. Qualified names can be broken after a dot (.) if they are too long for a single line, as shown in the following example.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet1":::

- You don't have to change the names of objects that were created by using the Visual Studio designer tools to make them fit other guidelines.

## Layout conventions

Good layout uses formatting to emphasize the structure of your code and to make the code easier to read. Microsoft examples and samples conform to the following conventions:

- Use the default Code Editor settings (smart indenting, four-character indents, tabs saved as spaces). For more information, see [Options, Text Editor, C#, Formatting](/visualstudio/ide/reference/options-text-editor-csharp-formatting).

- Write only one statement per line.
- Write only one declaration per line.
- If continuation lines are not indented automatically, indent them one tab stop (four spaces).
- Add at least one blank line between method definitions and property definitions.
- Use parentheses to make clauses in an expression apparent, as shown in the following code.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet2":::

## Commenting conventions

- Place the comment on a separate line, not at the end of a line of code.
- Begin comment text with an uppercase letter.
- End comment text with a period.
- Insert one space between the comment delimiter (//) and the comment text, as shown in the following example.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet3":::

- Don't create formatted blocks of asterisks around comments.
- Ensure all public members have the necessary XML comments providing appropriate descriptions about their behavior.

## Language guidelines

The following sections describe practices that the C# team follows to prepare code examples and samples.

### String data type

- Use [string interpolation](../../language-reference/tokens/interpolated.md) to concatenate short strings, as shown in the following code.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet6":::

- To append strings in loops, especially when you're working with large amounts of text, use a <xref:System.Text.StringBuilder> object.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet7":::

### Implicitly typed local variables

- Use [implicit typing](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md) for local variables when the type of the variable is obvious from the right side of the assignment, or when the precise type is not important.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet8":::

- Don't use [var](../../language-reference/keywords/var.md) when the type is not apparent from the right side of the assignment. Don't assume the type is clear from a method name. A variable type is considered clear if it's a `new` operator or an explicit cast.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet9":::

- Don't rely on the variable name to specify the type of the variable. It might not be correct. In the following example, the variable name `inputInt` is misleading. It's a string.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet10":::

- Avoid the use of `var` in place of [dynamic](../../language-reference/builtin-types/reference-types.md). Use `dynamic` when you want run-time type inference. For more information, see [Using type dynamic (C# Programming Guide)](../../programming-guide/types/using-type-dynamic.md).

- Use implicit typing to determine the type of the loop variable in [`for`](../../language-reference/statements/iteration-statements.md#the-for-statement) loops.

  The following example uses implicit typing in a `for` statement.

    :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet7":::

- Don't use implicit typing to determine the type of the loop variable in [`foreach`](../../language-reference/statements/iteration-statements.md#the-foreach-statement) loops.

  The following example uses explicit typing in a `foreach` statement.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet12":::

  > [!NOTE]
  > Be careful not to accidentally change a type of an element of the iterable collection. For example, it is easy to switch from <xref:System.Linq.IQueryable?displayProperty=nameWithType> to <xref:System.Collections.IEnumerable?displayProperty=nameWithType> in a `foreach` statement, which changes the execution of a query.

### Unsigned data types

In general, use `int` rather than unsigned types. The use of `int` is common throughout C#, and it is easier to interact with other libraries when you use `int`.

### Arrays

Use the concise syntax when you initialize arrays on the declaration line. In the following example, note that you can't use `var` instead of `string[]`.

:::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet13a":::

If you use explicit instantiation, you can use `var`.

:::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet13b":::

If you specify an array size, you have to initialize the elements one at a time.

:::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet13c":::

### Delegates

Use [`Func<>` and `Action<>`](../../../standard/delegates-lambdas.md) instead of defining delegate types. In a class, define the delegate method.

:::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet14a":::

Call the method using the signature defined by the `Func<>` or `Action<>` delegate.

:::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet15a":::

If you create instances of a delegate type, use the concise syntax. In a class, define the delegate type and a method that has a matching signature.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet14b":::

Create an instance of the delegate type and call it. The following declaration shows the condensed syntax.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet15b":::

The following declaration uses the full syntax.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet15c":::

### `try`-`catch` and `using` statements in exception handling

- Use a [try-catch](../../language-reference/keywords/try-catch.md) statement for most exception handling.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet16":::

- Simplify your code by using the C# [using statement](../../language-reference/keywords/using-statement.md). If you have a [try-finally](../../language-reference/keywords/try-finally.md) statement in which the only code in the `finally` block is a call to the <xref:System.IDisposable.Dispose%2A> method, use a `using` statement instead.

  In the following example, the `try`-`finally` statement only calls `Dispose` in the `finally` block.

   :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet17a":::

  You can do the same thing with a `using` statement.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet17b":::

  In C# 8 and later versions, use the new [`using` syntax](../../language-reference/keywords/using-statement.md) that doesn't require braces:

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet17c":::

### `&&` and `||` operators

To avoid exceptions and increase performance by skipping unnecessary comparisons, use [`&&`](../../language-reference/operators/boolean-logical-operators.md#conditional-logical-and-operator-) instead of [`&`](../../language-reference/operators/boolean-logical-operators.md#logical-and-operator-) and [`||`](../../language-reference/operators/boolean-logical-operators.md#conditional-logical-or-operator-) instead of [`|`](../../language-reference/operators/boolean-logical-operators.md#logical-or-operator-) when you perform comparisons, as shown in the following example.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet18":::

If the divisor is 0, the second clause in the `if` statement would cause a run-time error. But the && operator short-circuits when the first expression is false. That is, it doesn't evaluate the second expression. The & operator would evaluate both, resulting in a run-time error when `divisor` is 0.

### `new` operator

- Use one of the concise forms of object instantiation, as shown in the following declarations. The second example shows syntax that is available starting in C# 9.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet19":::

  ```csharp
  ExampleClass instance2 = new();
  ```

  The preceding declarations are equivalent to the following declaration.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet20":::

- Use object initializers to simplify object creation, as shown in the following example.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet21a":::

  The following example sets the same properties as the preceding example but doesn't use initializers.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet21b":::

### Event handling

If you're defining an event handler that you don't need to remove later, use a lambda expression.

:::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet22":::

The lambda expression shortens the following traditional definition.

:::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet23":::

### Static members

Call [static](../../language-reference/keywords/static.md) members by using the class name: *ClassName.StaticMember*. This practice makes code more readable by making static access clear.  Don't qualify a static member defined in a base class with the name of a derived class.  While that code compiles, the code readability is misleading, and the code may break in the future if you add a static member with the same name to the derived class.

### LINQ queries

- Use meaningful names for query variables. The following example uses `seattleCustomers` for customers who are located in Seattle.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet25":::

- Use aliases to make sure that property names of anonymous types are correctly capitalized, using Pascal casing.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet26":::

- Rename properties when the property names in the result would be ambiguous. For example, if your query returns a customer name and a distributor ID, instead of leaving them as `Name` and `ID` in the result, rename them to clarify that `Name` is the name of a customer, and `ID` is the ID of a distributor.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet27":::

- Use implicit typing in the declaration of query variables and range variables.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet25":::

- Align query clauses under the [`from`](../../language-reference/keywords/from-clause.md) clause, as shown in the previous examples.

- Use [`where`](../../language-reference/keywords/where-clause.md) clauses before other query clauses to ensure that later query clauses operate on the reduced, filtered set of data.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet29":::

- Use multiple `from` clauses instead of a [`join`](../../language-reference/keywords/join-clause.md) clause to access inner collections. For example, a collection of `Student` objects might each contain a collection of test scores. When the following query is executed, it returns each score that is over 90, along with the last name of the student who received the score.

  :::code language="csharp" source="./snippets/coding-conventions/program.cs" id="Snippet30":::

## Security

Follow the guidelines in [Secure Coding Guidelines](../../../standard/security/secure-coding-guidelines.md).

## See also

- [.NET runtime coding guidelines](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md)
- [Visual Basic Coding Conventions](../../../visual-basic/programming-guide/program-structure/coding-conventions.md)
- [Secure Coding Guidelines](../../../standard/security/secure-coding-guidelines.md)
