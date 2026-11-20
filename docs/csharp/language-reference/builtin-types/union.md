---
title: "Union types"
description: Learn about union types in C#. Unions express values from a closed set of types with exhaustive pattern matching support.
ms.date: 10/19/2026
f1_keywords:
  - "union_CSharpKeyword"
helpviewer_keywords:
  - "union keyword [C#]"
  - "union type [C#]"
  - "case type [C#]"
ai-usage: ai-assisted
---
# Union types (C# reference)

A *union type* represents a value that can be one of several *case types*. Unions provide implicit conversions from each case type, exhaustive pattern matching, and enhanced nullability tracking. Use the `union` keyword to declare a union type:

:::code language="csharp" source="snippets/unions/BasicUnion.cs" id="BasicDeclaration":::

This declaration creates a `Pet` union with three case types: `Cat`, `Dog`, and `Bird`. You can assign any case type value to a `Pet` variable. The compiler ensures that `switch` expressions cover all case types.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Declare a union when a value must be exactly one of a fixed set of types and you want the compiler to enforce that every possibility is handled. Common scenarios include:

- **Result-or-error returns**: A method returns either a success value or an error value, and the caller must handle both. A union like `union Result(Success, Error)` makes the set of outcomes explicit.
- **Message or command dispatching**: A system processes a closed set of message types. A union ensures new message types produce compile-time warnings at every `switch` that doesn't handle them yet.
- **Replacing marker interfaces or abstract base classes**: If you use an interface or abstract class solely to group types for pattern matching, a union gives you exhaustiveness checking without requiring inheritance or shared members.

A union differs from other type declarations in important ways:

- Unlike a `class` or `struct`, a union doesn't define new data members. Instead, it composes existing types into a closed set of alternatives.
- Unlike an `interface`, a union is closed—you define the complete list of case types in the declaration, and the compiler uses that list for exhaustiveness checks.
- Unlike a `record`, a union doesn't add equality, cloning, or deconstruction behavior. A union focuses on "which case is it?" rather than "what fields does it have?"

Union types rely on the <xref:System.Runtime.CompilerServices.UnionAttribute> and <xref:System.Runtime.CompilerServices.IUnion> types in the `System.Runtime.CompilerServices` namespace. The .NET 11 runtime includes these types.

## Union declarations

A union declaration specifies a name and a list of case types:

```csharp
public union Pet(Cat, Dog, Bird);
```

*Case types* can be any type that converts to `object`, including classes, structs, interfaces, type parameters, nullable types, and other unions. The following examples show different case type possibilities:

:::code language="csharp" source="snippets/unions/BasicUnion.cs" id="CaseTypes":::
:::code language="csharp" source="snippets/unions/GenericUnion.cs" id="GenericUnion":::
:::code language="csharp" source="snippets/unions/ValueTypeCases.cs" id="ValueTypeCases":::

When a case type is a value type (like `int`), a union declaration boxes the value and stores it as a single `object?` reference. [Custom union types](#custom-union-types) can use a different storage strategy.

A union declaration can include a body with additional members, just like a struct, subject to some restrictions. Union declarations can't include instance fields, auto-properties, or field-like events. You also can't declare public constructors with a single parameter, because the compiler generates those constructors as union creation members. Any constructor you declare must use a `this(...)` initializer to delegate, directly or indirectly, to a generated constructor. The following `Length` union adds a `TotalMeters` property that uses pattern matching to handle every case type, along with an `Add` method that combines two lengths:

:::code language="csharp" source="snippets/unions/BodyMembers.cs" id="BodyMembers":::

## Union conversions

An implicit *union conversion* exists from each case type to the union type:

:::code language="csharp" source="snippets/unions/BasicUnion.cs" id="BasicConversion":::

Union conversions work by calling the corresponding generated constructor. If a user-defined implicit conversion operator exists for the same type, the user-defined operator takes priority over the union conversion. If more than one case type is equally applicable to the source value, the union conversion is ambiguous, and the compiler reports an error. For details on conversion priority, see the [feature specification](~/_csharplang/proposals/csharp-15.0/unions.md).

A union conversion to a nullable union struct (`T?`) also works when `T` is a union type:

:::code language="csharp" source="snippets/unions/NullHandling.cs" id="NullableUnionExample":::

## Union pattern matching

When you use a type or declaration pattern on a union expression, the pattern tests the union's contents, not the union instance. For example, a `Dog` pattern tests whether `Value` is a `Dog`:

:::code language="csharp" source="snippets/unions/BasicUnion.cs" id="PatternMatching":::

The pattern's form determines which value it tests:

| Pattern | Behavior on a union expression |
|---|---|
| Type or declaration pattern, such as `Dog` or `Dog dog` | Tests the contents against the specified type. |
| Property or positional pattern with a type, such as `Dog { Breed: "Labrador" }` | Tests the contents against the type, then applies the nested patterns to that case value. |
| Property or positional pattern without a type, such as `{ Name: "Rex" }` | Uses the union instance's properties or `Deconstruct` method. |
| List pattern | Uses the union instance's count and indexing members, not those of its contents. |
| `var` or discard `_` pattern | Captures or matches the incoming union instance without unwrapping it. |
| Constant or relational pattern | Tests the contents. The `null` pattern also handles a null union reference or nullable wrapper. |

For example, define a `Pet` union with a read-only `Name` property that delegates to the contained `Cat` or `Dog`. The type patterns in the property's `switch` expression test the contents:

:::code language="csharp" source="snippets/unions/UnionPatternMatching.cs" id="UnionWithProperty":::

The typed pattern `Dog { Breed: "Labrador" }` tests the contents and reads the dog's `Breed`, a property the union doesn't have. The untyped pattern `{ Name: "Rex" }` reads the union's `Name` property instead, so it also matches a cat named Rex:

:::code language="csharp" source="snippets/unions/UnionPatternMatching.cs" id="PropertyMatching":::

The `not` pattern negates its nested pattern. In `pet is not null`, the nested `null` pattern checks the contents, so `not null` is a useful has-a-value test. In contrast, an empty untyped property pattern, `{ }`, checks the union instance. It always matches a nonnullable struct union, even when `Value` is null:

:::code language="csharp" source="snippets/unions/UnionPatternMatching.cs" id="NullAndCapture":::

Logical patterns preserve these distinctions. In `var pet and not null`, `var pet` captures the incoming union, and `not null` tests whether it has non-null contents. In `not null and var pet`, the `var` pattern still captures the incoming union: `not` doesn't change the value passed to the right-hand pattern. By contrast, in `Dog and { Breed: "Labrador" }`, the type pattern passes the matched `Dog` to the property pattern.

> [!NOTE]
> A type pattern must be compatible with at least one case type. For the `Pet` declarations in this article, `pet is Pet` produces compiler error CS8121: none of their case types can match `Pet`. It isn't a runtime test of the union instance. To check for contents, use `pet is not null` or `pet.Value is not null`; to capture the union itself, use a `var` pattern.

In short, type and declaration patterns test the contents. Recursive patterns with a type test the contents too; recursive patterns without a type use the union's own members. These rules are the same in an `is` expression and a `switch` expression.

### Null matching

For struct unions, the `null` pattern checks whether `Value` is null:

:::code language="csharp" source="snippets/unions/NullHandling.cs" id="NullHandling":::

For class-based unions, `null` succeeds when either the union reference itself is null or its `Value` property is null:

```csharp
Result<string>? result = null;
if (result is null) { /* true — the reference is null */ }

Result<string> empty = new Result<string>((string?)null);
if (empty is null) { /* true — Value is null */ }
```

For nullable union struct types (`Pet?`), `null` succeeds when the nullable wrapper has no value or when the underlying union's `Value` is null.

## Union exhaustiveness

A `switch` expression is exhaustive over a union's case types when it handles each case type. If nullability analysis also considers the contents non-null, you don't need a discard (`_`) or `var` arm:

:::code language="csharp" source="snippets/unions/BasicUnion.cs" id="PatternMatching":::

To handle null contents, prefer a `null` arm over a `var` or discard (`_`) arm. The `null` pattern states your intent and preserves warnings when you add a new case type without a matching arm. A `var` or discard arm also accepts any new case, so the compiler can't warn you about that missing case.

When the tracked null state of `Value` is "maybe null," the compiler also warns if you omit a `null` arm. For example, `NullablePet` has a nullable case type, so its parameter's contents might be null:

:::code language="csharp" source="snippets/unions/NullHandling.cs" id="MaybeNullContents":::

Removing the `null` arm from this switch produces warning CS8655.

Nullable analysis doesn't guarantee that a generated union has non-null contents at runtime. A default union contains null, including when it's a default-initialized field or array element. If all case types are nonnullable, the default tracked state of `Value` is nevertheless "not null," so the compiler doesn't necessarily warn about an omitted `null` arm. Handle `null` for correctness whenever default contents can reach your switch:

:::code language="csharp" source="snippets/unions/NullHandling.cs" id="NullHandling":::

For this `Pet` example, removing the `null` arm produces no missing-null-arm warning unless earlier code changes the tracked null state, but the switch throws <xref:System.Runtime.CompilerServices.SwitchExpressionException> when it receives the default value. An earlier `is null` test can change the tracked state and cause a warning. This behavior is separate from definite assignment: the compiler rejects a read of an unassigned local variable.

## Nullability

The compiler tracks the null state of a union's `Value` property through the following rules:

- The default null state of a union's `Value` property is "maybe null" if the default null state of any case type is "maybe null." Otherwise, the default null state is "not null."
- When you create a union value from a case type (through a constructor or union conversion), `Value` gets the null state of the incoming value.
- When the non-boxing access pattern's `HasValue` or `TryGetValue(...)` members query the union's contents, the null state of `Value` becomes "not null" on the `true` branch.

## Custom union types

The compiler converts a `union` declaration to a `struct` declaration. The struct is marked with the `[System.Runtime.CompilerServices.Union]` attribute and implements the `IUnion` interface. It includes a public constructor for each case type and a `Value` property. The language provides implicit union conversions that call those constructors. That generated form is opinionated. It's always a struct, always boxes value-type cases, and always stores contents as `object?`.

You might need different behavior if you want to adapt an existing type, create a class-based union, or use a custom storage strategy, or if you need interop support. You can create a union type manually.

Any class or struct with a `[Union]` attribute is a *union type* if it follows the *basic union pattern*. The basic union pattern requires:

- A `[Union]` <!--<xref:System.Runtime.CompilerServices.UnionAttribute>--> attribute on the type.
- One or more public constructors, each with a single by-value or `in` parameter. The parameter type of each constructor defines a *case type*.
- A public `Value` property of type `object?` (or `object`) with a `get` accessor.

All the preceding union members must be public. The compiler uses these members to implement union conversions, pattern matching, and exhaustiveness checks. You can also implement the [non-boxing access pattern](#non-boxing-access-pattern) or create a [class-based union type](#class-based-union-types). Your custom union type can add more members.

The compiler assumes that custom union types satisfy these behavioral rules:

- **Soundness**: `Value` always returns `null` or a value of one of the case types, including for a default struct value. A custom union can represent its default value as a non-null case, unlike the null contents of a default generated union.
- **Stability**: If you create a union value from a case type, `Value` matches that case type (or is `null` if the input was `null`).
- **Creation equivalence**: If a value is implicitly convertible to two different case types, both creation members produce the same observable behavior.
- **Access pattern consistency**: The `HasValue` and `TryGetValue` members, if present, behave equivalently to checking `Value` directly.

The following example shows a custom union type:

:::code language="csharp" source="snippets/unions/ManualUnion.cs" id="ManualBasicPattern":::

:::code language="csharp" source="snippets/unions/ManualUnion.cs" id="ManualUnionExample":::

### Non-boxing access pattern

A custom union type can optionally implement the *non-boxing access pattern* to enable strongly typed access to value-type cases without boxing during pattern matching. This pattern requires:

- A `HasValue` property of type `bool` that returns `true` when `Value` isn't `null`.
- A `TryGetValue` method for each case type that returns `bool` and delivers the value through an `out` parameter. `TryGetValue` returns `true` only when `Value` is a non-null value of that case type. The `out` parameter's type is identity-convertible to the case type, or to the underlying value type when the case type is a nullable value type.

:::code language="csharp" source="snippets/unions/NonBoxingAccess.cs" id="NonBoxingAccessPattern":::

:::code language="csharp" source="snippets/unions/NonBoxingAccess.cs" id="NonBoxingExample":::

For pattern matching, the compiler calls `TryGetValue` for type-pattern checks (such as `union is T`) and `HasValue` for null-pattern checks (such as `union is null`), avoiding boxing for value-type cases. Each member applies to its own pattern kind—neither is a fallback for the other. When a member is missing, the compiler checks the `Value` property for that pattern instead. For more information, see [How the compiler generates code for pattern matching](#union-member-providers).

### Union member providers

A union type can delegate its union members to a public nested `IUnionMembers` interface that it directly contains and implements. That interface is the *union member provider*. The compiler finds union members only on the provider interface, including inherited members. Members declared only on the union type itself aren't used as union members.

When using a union member provider, the interface must declare these required members:

- **Static `Create` methods**: One for each case type, with a single parameter and a return type identity-convertible to the union type. These methods establish your case types.
- **`Value` property**: A public `object` or `object?` property with a `get` accessor that returns the contained value.

You can optionally declare these members on the interface so the compiler generates more efficient pattern matching code:

- **`TryGetValue` methods**: One for each case type, returning `bool` with an `out` parameter of the case type.
- **`HasValue` property**: A public `bool` property with a `get` accessor returning `true` when `Value` isn't `null`.

**How the compiler generates code for pattern matching**: `TryGetValue` and `HasValue` apply to different kinds of patterns—neither is a fallback for the other:

- For a *type pattern*, such as `union is T`, the compiler calls `TryGetValue(out T value)` when declared, extracting the value and applying the pattern to it without boxing. Otherwise, the compiler applies the pattern to the `Value` property, which performs a runtime type check against `T` and can box the value when `T` is a value type.
- For a *null pattern*, such as `union is null`, the compiler calls `HasValue` when declared to test whether the union contains a value. Otherwise, the compiler applies the null pattern to the `Value` property directly.

Each member is independently optional: without `TryGetValue`, type patterns use `Value`; without `HasValue`, null patterns use `Value`. Declaring either member lets the compiler generate more efficient, strongly typed code for that pattern kind:

:::code language="csharp" source="snippets/unions/MemberProvider.cs" id="MemberProvider":::

Union member providers are useful when the union type needs a private constructor or when the creation logic requires a factory pattern, such as with `record class` union types.

### Class-based union types

A class can also be a union type. This type of union is useful when you need reference semantics or inheritance:

:::code language="csharp" source="snippets/unions/ClassUnion.cs" id="ClassUnion":::

:::code language="csharp" source="snippets/unions/ClassUnion.cs" id="ClassUnionExample":::

For class-based unions, the `null` pattern matches both a null reference and a null `Value`.

## C# language specification

For more information, see the [Unions](~/_csharplang/proposals/csharp-15.0/unions.md) feature specification.

## See also

- [The C# type system](../../fundamentals/types/index.md)
- [Pattern matching](../operators/patterns.md)
- [Switch expression](../operators/switch-expression.md)
- [Value types](value-types.md)
- [Records](record.md)
