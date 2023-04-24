---
title: Resolve errors using directives and using alias directives
description: These errors and warnings indicate problems with using directives and using directive aliases. Your code violates rules governing using directives.
f1_keywords:
  - "CS9130"
  - "CS9131"
  - "CS9132"
 helpviewer_keywords:
  - "CS9130"
  - "CS9131"
  - "CS9132"
ms.date: 04/25/2023
---
# Resolve warnings related using namespaces

This article covers the following compiler warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS9130** - *Error: Using alias cannot be a `ref` type.*
- **CS9131** - *Error: Only a using alias can be `unsafe`.*
- **CS9132** - *Error: Using alias cannot be a nullable reference type.*

These errors and warnings indicate you're `using` directive isn't formed correctly.

## Restrictions on using aliases

Prior to C# 12, the language imposed these restrictions on `using` directives that create an alias for a type declaration:

Beginning with C# 12, these restrictions are introduced:

- You can't use the `in`, `ref`, or `out` modifiers in a using alias:

   ```csharp
   // All these are invalid
   using RefInt = ref int;
   using OutInt = out int;
   using InInt = in int;
   ```

- An `unsafe` using directive must specify an alias, or a `static using`:

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

For these rules, you can't use the `using` alias feature.
