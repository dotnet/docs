---
title: "Resolve compiler errors and warnings related to using directives and using alias directives"
description: "These errors and warnings indicate problems with using directives and using directive aliases. This information helps diagnose and fix those issues."
ms.date: 11/02/2023
f1_keywords:
  - "CS0105"
  - "CS0138"
  - "CS0431"
  - "CS0432"
  - "CS0440"
  - "CS0576"
  - "CS0687"
  - "CS1529"
  - "CS1537"
  - "CS7000"
  - "CS7007"
  - "CS8019"
  - "CS8083"
  - "CS8085"
  - "CS8914"
  - "CS8915"
  - "CS8933"
  - "CS9055"
  - "CS9130"
  - "CS9131"
  - "CS9132"
  - "CS9133"
  - "CS9162"
  - "CS9163"
helpviewer_keywords:
  - "CS0105"
  - "CS0138"
  - "CS0431"
  - "CS0432"
  - "CS0440"
  - "CS0576"
  - "CS0687"
  - "CS1529"
  - "CS1537"
  - "CS7000"
  - "CS7007"
  - "CS8019"
  - "CS8083"
  - "CS8085"
  - "CS8914"
  - "CS8915"
  - "CS8933"
  - "CS9055"
  - "CS9130"
  - "CS9131"
  - "CS9132"
  - "CS9133"
  - "CS9162"
  - "CS9163"
---
# Resolve warnings related using namespaces

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0138**](#using-static-directive): *Error: A using namespace directive can only be applied to namespaces; 'type' is a type not a namespace.*
- [**CS0431**](#alias-qualifier): *Error: Cannot use alias 'identifier' with `::` since the alias references a type. Use `.` instead*.
- [**CS0432**](#alias-qualifier): *Error: Alias 'identifier' not found.*
- [**CS0576**](#alias-name-conflicts): *Error: Namespace 'namespace' contains a definition conflicting with alias 'identifier'.*
- [**CS0687**](#alias-qualifier): *Error: The namespace alias qualifier `::` always resolves to a type or namespace so is illegal here. Consider using `.` instead.*
- [**CS1529**](#using-directive): *Error: A using clause must precede all other elements defined in the namespace except extern alias declarations.*
- [**CS1537**](#alias-name-conflicts): *Error: The using alias 'alias' appeared previously in this namespace.*
- [**CS7000**](#alias-qualifier): *Error: Unexpected use of an aliased name.*
- [**CS7007**](#using-static-directive): *Error: A `using static` directive can only be applied to types. Consider a `using namespace` directive instead*
- [**CS8083**](#alias-qualifier): *Error: An alias-qualified name is not an expression.*
- [**CS8085**](#restrictions-on-using-aliases): *Error: A 'using static' directive cannot be used to declare an alias.*
- [**CS8914**](#global-using-directive): *Error: A global using directive cannot be used in a namespace declaration.*
- [**CS8915**](#global-using-directive): *Error: A global using directive must precede all non-global using directives.*
- [**CS9055**](#global-using-directive): *Error: A file-local type cannot be used in a 'global using static' directive.*
- [**CS9130**](#restrictions-on-using-aliases): *Error: Using alias cannot be a `ref` type.*
- [**CS9131**](#restrictions-on-using-aliases): *Error: Only a using alias can be `unsafe`.*
- [**CS9132**](#restrictions-on-using-aliases): *Error: Using alias cannot be a nullable reference type.*
- [**CS9133**](#using-static-directive): *Error: `static` modifier must precede `unsafe` modifier.*
- [**CS9162**](#using-static-directive): *Type is not valid for 'using static'. Only a class, struct, interface, enum, delegate, or namespace can be used.*

And the following compiler warnings:

- [**CS0105**](#using-directive): *Warning: The using directive for 'namespace' appeared previously in this namespace.*
- [**CS0440**](#alias-qualifier): *Warning: Defining an alias named `global` is ill-advised since `global::` always references the global namespace and not an alias.*
- [**CS8019**](#using-directive): *Info: Unnecessary using directive.*
- [**CS8933**](#using-directive): *Info: The using directive appeared previously as global using.*

These errors and warnings indicate you're `using` directive isn't formed correctly. The following sections cover these errors and how to correct them.

## Using directive

The `using` directive must precede any other elements in a `namespace` declaration, or before any `namespace` declarations in the file. Putting a `using` directive later in the file causes the compiler to produce error **CS1529**:

```csharp
namespace UsingDirective;
public class MyClass
{
}

using System.Text.Json; // CS1529
```

To fix this issue, move any `using` declarations to the top of the file or the top of the namespace:

:::code language="csharp" source="./snippets/UsingDirectives/MyClass.cs" id="UsingExample":::

The compiler produces warning **CS8933**, **CS0105** or diagnostic **CS8019** for a duplicate `using` directive from a `using` or `global using` directive. You can remove any duplicates.

Incorrectly combining a `using` directive with the `static`, `global`, or `unsafe` modifiers on a `using` directive are covered later in this article.

## Using static directive

The `using static` directive imports one type's members into the current namespace. The following example imports the methods from `System.Console`, such as `WriteLine` into the current namespace:

:::code language="csharp" source="./snippets/UsingDirectives/Program.cs" id="UsingStatic":::

The compiler generates **CS0138** if you omit the `static` modifier:

```csharp
using System.Console; // CS0138
```

The compiler generates **CS7007** if you include the `static` modifier importing namespace instead of a type:

```csharp
using static System; // CS7007
```

The compiler emits CS9162 if the symbol isn't one of the proper types.

If you combine the `static` modifier with the `unsafe` modifier in a `using` directive, the `static` modifier must come first:

:::code language="csharp" source="./snippets/UsingDirectives/Program.cs" id="UsingUnsafeStatic":::

## Global using directive

A `global using` directive imports the namespace or type in all source files in the current project:

:::code language="csharp" source="./snippets/UsingDirectives/Program.cs" id="GlobalUsing":::

Any `global using` directives must precede any non-global `using` directives in that source file, and must not be placed in a `namespace`. Doing so results in **CS8915** and **CS8914**, respectively.

Furthermore, a `static global using` directive can't reference a [file-local](../keywords/file.md) type.

## Alias qualifier

The alias qualifier, [`::`](../operators/namespace-alias-qualifier.md), precedes a namespace alias, or follows the `global` alias. If you use `::` where `.` should be used to separate elements of a fully qualified name, the compiler emits one of **CS0431**, **CS0432**, **CS0687**, **CS7000*, or **CS8083**.

In all cases, replace the `::` with the `.` separator.

In addition, if you define an alias named `global`, the compiler issues **CS0440**. The `global` alias always refers to the global namespace. Declaring an alias for it doesn't work, and you should pick a different name for your alias.

## Alias name conflicts

You can declare an [alias](../keywords/using-directive.md#the-using-alias) to a namespace or a type with a `using` directive:

:::code language="csharp" source="./snippets/UsingDirectives/Program.cs" id="UsingAlias":::

You should try to create a unique name for the alias, the name on the left of the `=` sign in the preceding examples. Using a name that already maps to a Type (for example `Object`) or a namespace (`System`) can cause **CS0576** or **CS1537**.

## Restrictions on using aliases

Prior to C# 12, the language imposed these restrictions on `using` directives that create an alias for a type declaration:

- You can't create an alias with a `using static` directive:

   ```csharp
   using static con = System.Console;
   using static unsafe ip = int*;
   ```

Beginning with C# 12, these restrictions are introduced:

- You can't use the `in`, `ref`, or `out` modifiers in a using alias:

   ```csharp
   // All these are invalid
   using RefInt = ref int;
   using OutInt = out int;
   using InInt = in int;
   ```

- An `unsafe using` directive must specify an alias, or a `static using`:

   ```csharp
   // Elsewhere:
   public namespace UnsafeExamples
   {
      public unsafe static class UnsafeType
      {
          // ...
      }
   }

   // Using directives:
   using unsafe IntPointer = int*;
   using static unsafe UnsafeExamples.UnsafeType;
   using unsafe UnsafeExamples; // not allowed
   ```

- You can't create an alias to a nullable reference type:

   ```csharp
   using NullableInt = System.Int32?; // Allowed
   using NullableString = System.String?; // Not allowed
   ```
