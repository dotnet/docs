---
title: Resolve errors related to numeric overflow and underflow
description: These compiler errors relate to mathematical operations that may overflow or underflow.
ai-usage: ai-assisted
f1_keywords:
  - "CS0031"
  - "CS0220"
  - "CS0221"
  - "CS0463"
  - "CS0543"
  - "CS0594"
  - "CS0652"
  - "CS1021"
  - "CS8973"
helpviewer_keywords:
  - "CS0031"
  - "CS0220"
  - "CS0221"
  - "CS0463"
  - "CS0543"
  - "CS0594"
  - "CS0652"
  - "CS1021"
  - "CS8973"
ms.date: 03/25/2026
---
# Resolve errors and warnings related to overflow or underflow

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS0031**](#cs0031): *Constant value 'value' cannot be converted to a 'type'*
- [**CS0220**](#cs0220): *The operation overflows at compile time in checked mode*
- [**CS0221**](#cs0221): *Constant value 'value' cannot be converted to a 'type' (use 'unchecked' syntax to override)*
- [**CS0463**](#cs0463): *Evaluation of the decimal constant expression failed with error: 'error'*
- [**CS0543**](#cs0543): *'enumeration' : the enumerator value is too large to fit in its type*
- [**CS0594**](#cs0594): *Floating-point constant is outside the range of type 'type'*
- [**CS0652**](#cs0652): *Comparison to integral constant is useless; the constant is outside the range of type 'type'*
- [**CS1021**](#cs1021): *Integral constant is too large*
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

## CS0220

The operation overflows at compile time in checked mode.

An operation was detected by [checked](../../language-reference/statements/checked-and-unchecked.md), which is the default for constant expressions, and a data loss resulted. Either correct the inputs to the assignment or use [unchecked](../../language-reference/statements/checked-and-unchecked.md) to resolve this error. For more information, see the [checked and unchecked statements](../../language-reference/statements/checked-and-unchecked.md) article.

The following sample generates CS0220:

```csharp
// CS0220.cs
using System;

class TestClass
{
   const int x = 1000000;
   const int y = 1000000;

   public int MethodCh()
   {
      int z = (x * y);   // CS0220
      return z;
   }

   public int MethodUnCh()
   {
      unchecked
      {
         int z = (x * y);
         return z;
      }
   }

   public static void Main()
   {
      TestClass myObject = new TestClass();
      Console.WriteLine("Checked  : {0}", myObject.MethodCh());
      Console.WriteLine("Unchecked: {0}", myObject.MethodUnCh());
   }
}
```

## CS0221

Constant value 'value' cannot be converted to a 'type' (use 'unchecked' syntax to override).

An assignment operation that would result in a data loss was detected by [checked](../../language-reference/statements/checked-and-unchecked.md), which is on by default for constant expressions. Either correct the assignment or use [unchecked](../../language-reference/statements/checked-and-unchecked.md) to resolve this error. For more information, see the [checked and unchecked statements](../../language-reference/statements/checked-and-unchecked.md) article.

The following sample generates CS0221:

```csharp
// CS0221.cs
public class MyClass
{
   public static void Main()
   {
      // unchecked
      // {
         int a = (int)0xFFFFFFFF;   // CS0221
         a++;
      // }
   }
}
```

## CS0463

Evaluation of the decimal constant expression failed with error: 'error'.

This error occurs when a constant decimal expression overflows at compile time.

Typically you get overflow errors at run time. In this case, you defined the constant expression in such a way that the compiler could evaluate the result and know that an overflow would happen.

The following code generates error CS0463.

```csharp
// CS0463.cs
using System;
class MyClass
{
    public static void Main()
    {
        const decimal myDec = 79000000000000000000000000000.0m + 79000000000000000000000000000.0m; // CS0463
        Console.WriteLine(myDec.ToString());
    }
}
```

## CS0543

'enumeration' : the enumerator value is too large to fit in its type.

A value that was assigned to an element in an [enumeration](../../language-reference/builtin-types/enum.md) is outside the range of the data type.

The following sample generates CS0543:

```csharp
// CS0543.cs
namespace x
{
   enum I : byte
   {a = 255, b, c}   // CS0543
   public class clx
   {
      public static int Main()
      {
         return 0;
      }
   }
}
```

## CS0594

Floating-point constant is outside the range of type 'type'.

A value was assigned to a floating-point variable that is too large for the variables of this data type. See [Integral Types Table](../../language-reference/builtin-types/integral-numeric-types.md) for information about the range of values allowed in data types.

The following sample generates CS0594:

```csharp
// CS0594.cs
namespace MyNamespace
{
   public class MyClass
   {
      public static void Main()
      {
         float f = 6.77777777777E400;   // CS0594, value too large
      }
   }
}
```

## CS0652

Comparison to integral constant is useless; the constant is outside the range of type 'type'.

The compiler detected a comparison between a constant and a variable where the constant is out of the range of the variable.

The following sample generates CS0652:

```csharp
// CS0652.cs
// compile with: /W:2
public class Class1
{
   private static byte i = 0;
   public static void Main()
   {
      short j = 256;
      if (i == 256)   // CS0652, 256 is out of range for byte
         i = 0;
   }
}
```

## CS1021

Integral constant is too large.

A value represented by an integer literal is greater than <xref:System.UInt64.MaxValue?displayProperty=nameWithType>.

The following sample generates CS1021:

```csharp
// CS1021.cs
class Program
{
    static void Main(string[] args)
    {
        int a = 18_446_744_073_709_552_000;
    }
}
```

The following code also generates CS1021:

```csharp
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        var a = new BigInteger(18_446_744_073_709_552_000);
    }
}
```

For information about how to instantiate a <xref:System.Numerics.BigInteger?displayProperty=nameWithType> instance whose value exceeds the range of the built-in numeric types, see the [Instantiating a BigInteger Object](/dotnet/api/System.Numerics.BigInteger#instantiating-a-biginteger-object) section of the  <xref:System.Numerics.BigInteger> reference page.

## Overflow errors

- **CS8973**: *The operation may overflow at runtime (use 'unchecked' syntax to override)*

To correct these errors, follow these rules:

- Use the `unchecked` context to override overflow warnings (**CS8973**).
