---
title: Declare and initialize properties
description: Learn how to declare auto-implemented, computed, and field-backed properties in C#, control accessor access, and use init and required for initialization.
ms.date: 11/25/2026
ms.topic: concept-article
ai-usage: ai-generated
f1_keywords:
  - "cs.properties"
  - "propertyInitializer_CSharpKeyword"
helpviewer_keywords:
  - "properties [C#]"
  - "auto-implemented properties [C#]"
---

# Declare and initialize properties

If you know another programming language and are new to C#, use this article to declare properties, supply initial values, and control later changes. Start with [Class members and instances](index.md) for an introduction to members.

## Declare an auto-implemented property

The following class exposes a title and a duration:

:::code language="csharp" source="snippets/properties/Program.cs" id="AutoDeclaration":::

A *property* is a member that exposes a value through methods called *accessors*. The [`get`](../../language-reference/keywords/get.md) accessor returns the value when you read the property. The [`set`](../../language-reference/keywords/set.md) accessor receives a new value when you assign to the property.

An *auto-implemented property* declares accessors with semicolons instead of bodies. The compiler supplies the accessors and a private *backing field*, a field that stores the property's value. For the complete property rules, see [Properties in the C# specification](~/_csharpstandard/standard/classes.md#157-properties).

Use the property name to read or assign its value, just as you would with a field:

:::code language="csharp" source="snippets/properties/Program.cs" id="AutoUsage":::

A *property initializer* supplies an initial value in the declaration, as `= "Untitled"` does for `Title`. Without an initializer, the backing field starts with its type's [default value](../../language-reference/builtin-types/default-values.md). For example, `DurationSeconds` starts at `0`.

An *object initializer* supplies member values when you create an object, as the braces after `new AudioClip` do. Those assignments run after the constructor and call the property's `set` or `init` accessor. See [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) for more examples.

The final assignment changes an existing object. A property with an accessible `set` accessor permits both initialization and subsequent *mutation*, a change to an object's state.

To add to a property's current value, use `+=`:

:::code language="csharp" source="snippets/properties/Program.cs" id="CompoundUsage":::

A *compound assignment* combines an operation with assignment. For the integer property in this example, `+=` reads the current value through `get`, adds `3`, and writes the result through `set`. See [Compound assignment](../../language-reference/operators/assignment-operator.md#compound-assignment) for the complete rules.

## Compute a value with get

To return a value calculated from other members, write a `get` accessor rather than store another value:

:::code language="csharp" source="snippets/properties/Program.cs" id="ComputedDeclaration":::

A *computed property* calculates its value when you read it. `Area` has no backing field. Its *expression body*, the `=>` followed by an expression, is shorthand for `get { return Width * Height; }`. See [Expression body definitions](../../language-reference/operators/lambda-operator.md#expression-body-definition).

Each read uses the current width and height:

:::code language="csharp" source="snippets/properties/Program.cs" id="ComputedUsage":::

`Area` is *read-only*: it has a `get` accessor and no `set` or `init` accessor. Assign to `Width` or `Height` to change the result. A read-only computed property can return different values as the object's other state changes.

## Add logic with a field-backed property

To check a value before you store it, give the `set` accessor a body:

:::code language="csharp" source="snippets/properties/Program.cs" id="FieldDeclaration":::

A *field-backed property* uses the [`field`](../../language-reference/keywords/field.md) keyword to access its compiler-generated backing field. This syntax is available in C# 14 and later. The compiler implements `get;`, and the custom `set` accessor checks the supplied value before it updates `field`.

Inside a `set` or `init` accessor, the [`value`](../../language-reference/keywords/value.md) keyword names the value the caller supplied. In this example, a value outside the range 0 through 100 causes an <xref:System.ArgumentOutOfRangeException>. Because the checks precede the assignment to `field`, a rejected assignment leaves the stored value unchanged:

:::code language="csharp" source="snippets/properties/Program.cs" id="FieldUsage":::

A declaration initializer such as `= 50` writes the backing field directly, without calling the `set` accessor. Choose an initial value that meets the same rules as later assignments.

For a field-backed property, you can implement `get`, `set`, or `init`, or combine an implemented accessor with a semicolon accessor. You can also declare a separate private backing field when your implementation needs one. Callers use the same property syntax regardless of how you store or calculate the value.

## Restrict accessor access

To let callers read a property while your class controls updates, give the `set` accessor a more restrictive access level:

:::code language="csharp" source="snippets/properties/Program.cs" id="PrivateSetDeclaration":::

The `public` property makes `get` accessible to callers. The `private set` accessor allows assignments only inside `Counter`. The `Increment` method can update `Count` after construction:

:::code language="csharp" source="snippets/properties/Program.cs" id="PrivateSetUsage":::

By default, an accessor has the accessibility of its property. When a property has both `get` and `set` (or `get` and `init`), you can restrict one accessor. That accessor must be more restrictive than the property. For example, a `public` property can have `private set`, but a `private` property can't have `public set`. See [Class accessibility](access-modifiers.md) for access levels.

An auto-implemented property can also declare only `get`. Assign its initial value in the declaration or in the containing type's constructor. Unlike `private set`, a get-only auto-implemented property doesn't permit assignment in other methods. See [Constructors](../../programming-guide/classes-and-structs/constructors.md) for constructor initialization.

## Allow initialization with init

To let callers supply a value when they create an object while preventing later assignments, replace `set` with `init`:

:::code language="csharp" source="snippets/properties/Program.cs" id="InitDeclaration":::

An [`init`](../../language-reference/keywords/init.md) accessor permits assignment during object construction, including an object initializer:

:::code language="csharp" source="snippets/properties/Program.cs" id="InitUsage":::

After initialization, `export.Format = "pdf";` is a compile-time error. In contrast, a `private set` accessor lets the containing class change the property later. `init` is an accessor, not an access modifier.

An `init` accessor permits an initial assignment; it doesn't require one. The final line creates options without an object initializer, so `Format` keeps its declaration initializer value, `"png"`.

An init-only property prevents reassignment of the property. If the property holds a reference to a mutable object, that object can still change. For example, an init-only list property doesn't prevent callers from adding list items.

## Require an initial assignment

To require callers to supply a value, add `required` to the property declaration:

:::code language="csharp" source="snippets/properties/Program.cs" id="RequiredDeclaration":::

The [`required`](../../language-reference/keywords/required.md) modifier makes initialization a compile-time requirement. Callers ordinarily satisfy that requirement with an object initializer:

:::code language="csharp" source="snippets/properties/Program.cs" id="RequiredUsage":::

`required` and `init` serve different purposes. `required` requires initialization, while `init` restricts when assignments are allowed. A `required` property with `set` instead of `init` still permits later mutation.

The following **separate, intentionally invalid example** omits the required assignment. It produces compiler error **CS9035** and is excluded from the runnable examples:

:::code language="csharp" source="snippets/properties/expected-errors/MissingRequired.cs" id="MissingRequired":::

`required` doesn't check whether the supplied value is useful. The earlier `new Playlist { Title = "" }` satisfies the requirement with an empty string.

`required` also doesn't mean non-null. A *nullable reference type*, such as `string?`, expresses that a reference can be `null`. See [Nullable reference types](../null-safety/nullable-reference-types.md). A required nullable property accepts an explicit `null`:

:::code language="csharp" source="snippets/properties/Program.cs" id="RequiredNullableDeclaration":::

:::code language="csharp" source="snippets/properties/Program.cs" id="RequiredNullable":::

With [nullable warnings enabled](../null-safety/nullable-reference-types.md#nullable-context), `new Playlist { Title = null }` satisfies `required` but produces warning **CS8625** because `Title` is a non-nullable `string`. Neither `required` nor nullable annotations add a runtime check.

To enforce a rule at runtime, write validation in the accessor. The following field-backed `init` accessor rejects null, empty, or whitespace-only text and trims accepted text:

:::code language="csharp" source="snippets/properties/Program.cs" id="ValidatedInitDeclaration":::

:::code language="csharp" source="snippets/properties/Program.cs" id="ValidatedInitUsage":::

For constructors that take responsibility for required members through <xref:System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute>, see the [`required` reference](../../language-reference/keywords/required.md). That attribute tells the compiler that the constructor initializes all required members; the compiler doesn't verify the assertion.

## Next steps

- [Fields and constants](fields-constants.md) explains the storage that your type manages.
- [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) covers more ways to supply initial values.
- [Using properties](../../programming-guide/classes-and-structs/using-properties.md) contains applied and inheritance examples.
- [Records](../types/records.md) introduces data-focused types with compiler-generated members.
