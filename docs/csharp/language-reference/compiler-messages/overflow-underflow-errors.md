---
title: Resolve errors related to numeric overflow and underflow
description: These compiler errors relate to mathematical operations that may overflow or underflow.
ai-usage: ai-assisted
f1_keywords:
  - "CS0031"
  - "CS8973"
helpviewer_keywords:
  - "CS0031"
  - "CS8973"
ms.date: 03/25/2026
---
# Resolve errors and warnings related to overflow or underflow

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS0031**](#cs0031): *Constant value 'value' cannot be converted to a 'type'*
- [**CS8973**](#overflow-errors): *The operation may overflow at runtime (use 'unchecked' syntax to override)*

## CS0031

Constant value 'value' cannot be converted to a 'type'.

An attempt was made to assign a value to a variable whose type can't store the value. For more information, see [Types](../../fundamentals/types/index.md).

The following sample generates CS0031 in both checked and unchecked contexts:

```csharp
// CS0031.cs
namespace CS0031
{
    public class Program
    {
        public static void Main()
        {
            int num = (int)2147483648M; //CS0031
            // Try using a larger numeric type instead.
            // long num = (long)2147483648M; //CS0031

            const decimal d = -10M; // Decimal literal
            unchecked
            {
                const byte b = (byte)d; // CS0031
                // For small values try using a signed byte instead.
                // const sbyte b = (sbyte)d;
            }
        }
    }
}
```

## Overflow errors

- **CS8973**: *The operation may overflow at runtime (use 'unchecked' syntax to override)*

To correct these errors, follow these rules:

- Use the `unchecked` context to override overflow warnings (**CS8973**).
