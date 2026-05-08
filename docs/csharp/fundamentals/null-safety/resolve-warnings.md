---
title: Resolve nullable warnings
description: Learn the five techniques you use to address nullable warnings in C# and make your code resilient to null reference exceptions.
ms.date: 05/04/2026
ms.topic: concept-article
ms.subservice: null-safety
ai-usage: ai-assisted
---
# Resolve nullable warnings

> [!TIP]
> **New to nullable reference types?** Read [Nullable reference types](nullable-reference-types.md) first to understand annotations and null-state analysis. This article assumes you're seeing warnings in a project where the feature is enabled.
>
> **Looking for a specific compiler error code?** The [Resolve nullable warnings](../../language-reference/compiler-messages/nullable-warnings.md) reference article catalogs every CS86xx warning with the matching technique.

When you enable nullable reference types, the compiler issues warnings everywhere your code's behavior doesn't match its annotations. Most warnings fall into a small set of patterns. Once you recognize the pattern, the fix is usually one of five techniques:

- Configure the nullable context.
- Add a null check.
- Add or remove a `?` or `!` annotation.
- Add an attribute that describes the null contract.
- Initialize variables correctly.

This article walks through each technique with a representative example. The goal isn't to silence warnings; it's to make the code's null-handling intent explicit so the compiler reaches the same conclusions you do.

## Configure the nullable context

The first warnings you see in an existing project often have nothing to do with your code's logic. They're about the nullable context itself:

- The annotation `?` is used while annotations are disabled.
- A `<Nullable>` value isn't recognized.
- A `#nullable` directive is malformed.

Enable the feature project-wide in your `.csproj`:

:::code language="xml" source="snippets/resolve-warnings/project-snippet.xml":::

Or scope it to part of a file with a [preprocessor directive](../../language-reference/preprocessor-directives.md) (a line starting with `#` that gives instructions to the compiler instead of producing executable code):

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="NullableDirective":::

The context has two independent flags. The *annotation* flag controls whether `?` and `!` are meaningful in declarations. The *warning* flag controls whether the compiler emits diagnostics. You can enable each independently. Enabling warnings while leaving annotations off lets you address null-handling bugs before you take on annotating types. Enabling annotations while leaving warnings off lets you express your design intent in the API surface without producing diagnostics in implementation code that isn't ready yet. Either combination can be the right choice for a project at a given stage. For the migration trade-offs, see [Nullable migration strategies](migration-strategies.md).

## Add a null check

The most common warning is *possible dereference of null*. The compiler tracked a variable's null-state to *maybe-null* and saw the variable used without a check:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="DereferenceWarning":::

The fix is usually a *guard clause*. A *guard clause* is a check at the top of a method or block that returns or throws when an input is invalid, leaving only the safe path to continue. Once the check runs, the compiler updates the variable's null state to *not-null* on the safe path:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="DereferenceFixed":::

[Pattern matching](../../language-reference/operators/patterns.md) (expressions such as `is null` or `is { } value` that test the shape of a value), `??`, and `??=` produce the same effect:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="NullOperatorsFix":::

The property pattern `{ Length: > 0 }` matches only when `message` is non-null *and* its `Length` property is greater than zero, so the compiler treats `nonEmpty` as *not-null* inside the `if` block. A simpler `is not null` test produces the same null-state narrowing without inspecting any properties.

For an in-depth tour of the operators, see [Null operators](null-operators.md).

## Adjust annotations

The compiler also warns you when your code assigns a *maybe-null* expression to a non-nullable variable. That warning means one of two things:

- The variable shouldn't be non-nullable. Add a `?` to the type.
- The expression shouldn't be maybe-null. Annotate the API that produced it.

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="AssignmentWarning":::

If `Lookup` legitimately returns nothing, change the call site to accept the missing value:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="AssignmentFixed":::

Use the null-forgiving operator `!` only when you can guarantee a value isn't null but can't express that guarantee in the type system. Each `!` is a place the compiler can no longer protect you, so prefer adding a check or annotating the source API.

## Add a null-analysis attribute

Sometimes the right fix isn't at the call site. A method's signature doesn't capture the relationship between its inputs and outputs precisely enough, and the compiler issues warnings inside otherwise-safe code:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="MissingAttribute":::

The body of `IsPresent` proves the argument isn't null when the method returns `true`, but the signature doesn't say so. Add a [nullable analysis attribute](../../language-reference/attributes/nullable-analysis.md) to make the contract part of the API:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="WithAttribute":::

Common attributes include:

- <xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute> — the argument is *not-null* when the method returns the specified Boolean.
- <xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute> — the return value is *not-null* whenever the named argument is *not-null*.
- <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute> — the listed members are *not-null* after the method returns.
- <xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute> — the method never returns normally (for example, it always throws).

The full list is in [Nullable static analysis attributes](../../language-reference/attributes/nullable-analysis.md).

## Initialize non-nullable members

A constructor warning means a non-nullable field, property, or [auto-property](../../programming-guide/classes-and-structs/auto-implemented-properties.md) (a property that uses the compiler-generated backing field, such as `public string Name { get; set; }`) exits the constructor without being assigned a non-null value:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="UninitializedMember":::

You have several ways to address it. Pick the one that best matches your design intent.

**Require the value as a constructor argument.** Use a [primary constructor](../../whats-new/tutorials/primary-constructors.md) (parameters declared on the type itself, available throughout the body) or a regular constructor that initializes the property:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="ConstructorInjected":::

**Make the property `required`.** The caller must initialize it through an [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) (the `{ Property = value }` syntax that follows `new`):

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="RequiredMember":::

**Initialize with a default.** When the type has a meaningful empty value, initialize at the declaration:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="InitializedMember":::

> [!TIP]
> Choose this technique only when the type has a genuinely good default value: one that's a valid, fully-functional instance for callers to consume. Examples include <xref:System.String.Empty?displayProperty=nameWithType> or an empty collection. Don't invent a *sentinel* (a placeholder value such as `"N/A"`, `"unknown"`, or `-1` that you treat as "no value") to stand in for `null`: it silences the warning, but every caller has to know about and check for the sentinel, and the type system can't help. When no good default exists, make the property nullable instead.

**Make the property nullable.** When the value really might be missing, change the type to nullable:

:::code language="csharp" source="snippets/resolve-warnings/Program.cs" id="NullableMember":::

If a helper method initializes the member, annotate the helper with <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute> so the compiler can credit calls to it.

## Where to go next

When a warning doesn't fit any of these patterns, the [Resolve nullable warnings](../../language-reference/compiler-messages/nullable-warnings.md) reference article lists the technique for every CS86xx warning the compiler emits.

To plan a migration that progressively enables nullable reference types in an existing codebase, see [Nullable migration strategies](migration-strategies.md).

## Related content

- [Nullable reference types](nullable-reference-types.md)
- [Null operators](null-operators.md)
- [Nullable migration strategies](migration-strategies.md)
- [Nullable static analysis attributes](../../language-reference/attributes/nullable-analysis.md)
- [Resolve nullable warnings (compiler reference)](../../language-reference/compiler-messages/nullable-warnings.md)
