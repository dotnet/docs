---
title: Resolve errors related to constructor declarations
description: These compiler errors and warnings indicate violations when declaring constructors in classes or structs, including records. This article provides guidance on resolving those errors.
f1_keywords:
 - "CS0028"
 - "CS8937"
helpviewer_keywords:
 - "CS0028"
 - "CS8937"
ms.date: 03/23/2026
---
# Resolve errors and warnings related to a program entry poin

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0028**](#wrong-signature-for-entry-point): *'function declaration' has the wrong signature to be an entry point*
- [**CS8937**](#static-constructors): *At least one top-level statement must be non-empty.*

## Wrong signature for entry point

- **CS0028**: *'function declaration' has the wrong signature to be an entry point*

The method declaration for `Main` was invalid: it was declared with an invalid signature. `Main` must be declared as static and it must return either [int](../builtin-types/integral-numeric-types.md) or [void](../builtin-types/void.md). For more information, see [Main() and Command-Line Arguments](../../fundamentals/program-structure/main-command-line.md).

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

The following sample generates CS0028:

```csharp
// CS0028.cs
// compile with: /W:4 /warnaserror
public class a
{
    public static double Main(int i)   // CS0028
    // Try the following line instead:
    // public static void Main()
    {
    }
}
```

## Invalid top level statements

- **CS8937**: *At least one top-level statement must be non-empty.*

To correct these errors, ensure your static constructor declaration follows these rules:

- Add an executable statement to your app. (**CS8937**)
