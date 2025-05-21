---
title: System.Numerics.BigInteger struct
description: Learn about the System.Numerics.BigInteger struct.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Numerics.BigInteger struct

[!INCLUDE [context](includes/context.md)]

The <xref:System.Numerics.BigInteger> type is an immutable type that represents an arbitrarily large integer whose value in theory has no upper or lower bounds. The members of the <xref:System.Numerics.BigInteger> type closely parallel those of other integral types (the <xref:System.Byte>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.SByte>, <xref:System.UInt16>, <xref:System.UInt32>, and <xref:System.UInt64> types). This type differs from the other integral types in .NET, which have a range indicated by their `MinValue` and `MaxValue` properties.

> [!NOTE]
> Because the <xref:System.Numerics.BigInteger> type is immutable (see [Mutability](#mutability)) and because it has no upper or lower bounds, an <xref:System.OutOfMemoryException> can be thrown for any operation that causes a <xref:System.Numerics.BigInteger> value to grow too large.

## Instantiate a BigInteger object

You can instantiate a <xref:System.Numerics.BigInteger> object in several ways:

- You can use the `new` keyword and provide any integral or floating-point value as a parameter to the <xref:System.Numerics.BigInteger> constructor. (Floating-point values are truncated before they are assigned to the <xref:System.Numerics.BigInteger>.) The following example illustrates how to use the `new` keyword to instantiate <xref:System.Numerics.BigInteger> values.

  :::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/BigInteger_Examples.cs" id="Snippet1":::
  :::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/BigInteger_Examples.vb" id="Snippet1":::

- You can declare a <xref:System.Numerics.BigInteger> variable and assign it a value just as you would any numeric type, as long as that value is an integral type. The following example uses assignment to create a <xref:System.Numerics.BigInteger> value from an <xref:System.Int64>.

  :::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/BigInteger_Examples.cs" id="Snippet2":::
  :::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/BigInteger_Examples.vb" id="Snippet2":::

- You can assign a decimal or floating-point value to a <xref:System.Numerics.BigInteger> object if you cast the value or convert it first. The following example explicitly casts (in C#) or converts (in Visual Basic) a <xref:System.Double> and a <xref:System.Decimal> value to a <xref:System.Numerics.BigInteger>.

  :::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/BigInteger_Examples.cs" id="Snippet3":::
  :::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/BigInteger_Examples.vb" id="Snippet3":::

These methods enable you to instantiate a <xref:System.Numerics.BigInteger> object whose value is in the range of one of the existing numeric types only. You can instantiate a <xref:System.Numerics.BigInteger> object whose value can exceed the range of the existing numeric types in one of three ways:

- You can use the `new` keyword and provide a byte array of any size to the <xref:System.Numerics.BigInteger.%23ctor%2A?displayProperty=nameWithType> constructor. For example:

  :::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/BigInteger_Examples.cs" id="Snippet4":::
  :::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/BigInteger_Examples.vb" id="Snippet4":::

- You can call the <xref:System.Numerics.BigInteger.Parse%2A> or <xref:System.Numerics.BigInteger.TryParse%2A> methods to convert the string representation of a number to a <xref:System.Numerics.BigInteger>. For example:

  :::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/BigInteger_Examples.cs" id="Snippet5":::
  :::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/BigInteger_Examples.vb" id="Snippet5":::

- You can call a `static` (`Shared` in Visual Basic) <xref:System.Numerics.BigInteger> method that performs some operation on a numeric expression and returns a calculated <xref:System.Numerics.BigInteger> result. The following example does this by cubing <xref:System.UInt64.MaxValue?displayProperty=nameWithType> and assigning the result to a <xref:System.Numerics.BigInteger>.

  :::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/BigInteger_Examples.cs" id="Snippet6":::
  :::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/BigInteger_Examples.vb" id="Snippet6":::

The uninitialized value of a <xref:System.Numerics.BigInteger> is <xref:System.Numerics.BigInteger.Zero%2A>.

## Perform operations on BigInteger values

You can use a <xref:System.Numerics.BigInteger> instance as you would use any other integral type. <xref:System.Numerics.BigInteger> overloads the standard numeric operators to enable you to perform basic mathematical operations such as addition, subtraction, division, multiplication, and unary negation. You can also use the standard numeric operators to compare two <xref:System.Numerics.BigInteger> values with each other. Like the other integral types, <xref:System.Numerics.BigInteger> also supports the bitwise `And`, `Or`, `XOr`, left shift, and right shift operators. For languages that do not support custom operators, the <xref:System.Numerics.BigInteger> structure also provides equivalent methods for performing mathematical operations. These include <xref:System.Numerics.BigInteger.Add%2A>, <xref:System.Numerics.BigInteger.Divide%2A>, <xref:System.Numerics.BigInteger.Multiply%2A>, <xref:System.Numerics.BigInteger.Negate%2A>, <xref:System.Numerics.BigInteger.Subtract%2A>, and several others.

Many members of the <xref:System.Numerics.BigInteger> structure correspond directly to members of the other integral types. In addition, <xref:System.Numerics.BigInteger> adds members such as the following:

- <xref:System.Numerics.BigInteger.Sign%2A>, which returns a value that indicates the sign of a <xref:System.Numerics.BigInteger> value.

- <xref:System.Numerics.BigInteger.Abs%2A>, which returns the absolute value of a <xref:System.Numerics.BigInteger> value.

- <xref:System.Numerics.BigInteger.DivRem%2A>, which returns both the quotient and remainder of a division operation.

- <xref:System.Numerics.BigInteger.GreatestCommonDivisor%2A>, which returns the greatest common divisor of two <xref:System.Numerics.BigInteger> values.

Many of these additional members correspond to the members of the <xref:System.Math> class, which provides the functionality to work with the primitive numeric types.

## Mutability

The following example instantiates a <xref:System.Numerics.BigInteger> object and then increments its value by one.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/Mutability_Examples.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/Mutability_Examples.vb" id="Snippet1":::

Although this example appears to modify the value of the existing object, this is not the case. <xref:System.Numerics.BigInteger> objects are immutable, which means that internally, the common language runtime actually creates a new <xref:System.Numerics.BigInteger> object and assigns it a value one greater than its previous value. This new object is then returned to the caller.

> [!NOTE]
> The other numeric types in .NET are also immutable. However, because the <xref:System.Numerics.BigInteger> type has no upper or lower bounds, its values can grow extremely large and have a measurable impact on performance.

Although this process is transparent to the caller, it does incur a performance penalty. In some cases, especially when repeated operations are performed in a loop on very large <xref:System.Numerics.BigInteger> values, that performance penalty can be significant. For example, in the following example, an operation is performed repetitively up to a million times, and a <xref:System.Numerics.BigInteger> value is incremented by one every time the operation succeeds.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/Mutability_Examples.cs" id="Snippet12":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/Mutability_Examples.vb" id="Snippet12":::

In such a case, you can improve performance by performing all intermediate assignments to an <xref:System.Int32> variable. The final value of the variable can then be assigned to the <xref:System.Numerics.BigInteger> object when the loop exits. The following example provides an illustration.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/Mutability_Examples.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/Mutability_Examples.vb" id="Snippet3":::

## Byte arrays and hexadecimal strings

If you convert <xref:System.Numerics.BigInteger> values to byte arrays, or if you convert byte arrays to <xref:System.Numerics.BigInteger> values, you must consider the order of bytes. The <xref:System.Numerics.BigInteger> structure expects the individual bytes in a byte array to appear in little-endian order (that is, the lower-order bytes of the value precede the higher-order bytes). You can round-trip a <xref:System.Numerics.BigInteger> value by calling the <xref:System.Numerics.BigInteger.ToByteArray%2A> method and then passing the resulting byte array to the <xref:System.Numerics.BigInteger.%23ctor%28System.Byte%5B%5D%29> constructor, as the following example shows.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/ByteAndHex_Examples.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/ByteAndHex_Examples.vb" id="Snippet1":::

To instantiate a <xref:System.Numerics.BigInteger> value from a byte array that represents a value of some other integral type, you can pass the integral value to the <xref:System.BitConverter.GetBytes%2A?displayProperty=nameWithType> method, and then pass the resulting byte array to the <xref:System.Numerics.BigInteger.%23ctor%28System.Byte%5B%5D%29> constructor. The following example instantiates a <xref:System.Numerics.BigInteger> value from a byte array that represents an <xref:System.Int16> value.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/ByteAndHex_Examples.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/ByteAndHex_Examples.vb" id="Snippet2":::

The <xref:System.Numerics.BigInteger> structure assumes that negative values are stored by using two's complement representation. Because the <xref:System.Numerics.BigInteger> structure represents a numeric value with no fixed length, the <xref:System.Numerics.BigInteger.%23ctor%28System.Byte%5B%5D%29> constructor always interprets the most significant bit of the last byte in the array as a sign bit. To prevent the <xref:System.Numerics.BigInteger.%23ctor%28System.Byte%5B%5D%29> constructor from confusing the two's complement representation of a negative value with the sign and magnitude representation of a positive value, positive values in which the most significant bit of the last byte in the byte array would ordinarily be set should include an additional byte whose value is 0. For example, 0xC0 0xBD 0xF0 0xFF is the little-endian hexadecimal representation of either -1,000,000 or 4,293,967,296. Because the most significant bit of the last byte in this array is on, the value of the byte array would be interpreted by the <xref:System.Numerics.BigInteger.%23ctor%28System.Byte%5B%5D%29> constructor as -1,000,000. To instantiate a <xref:System.Numerics.BigInteger> whose value is positive, a byte array whose elements are 0xC0 0xBD 0xF0 0xFF 0x00 must be passed to the constructor. The following example illustrates this.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/ByteAndHex_Examples.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/ByteAndHex_Examples.vb" id="Snippet3":::

Byte arrays created by the <xref:System.Numerics.BigInteger.ToByteArray%2A> method from positive values include this extra zero-value byte. Therefore, the <xref:System.Numerics.BigInteger> structure can successfully round-trip values by assigning them to, and then restoring them from, byte arrays, as the following example shows.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/ByteAndHex_Examples.cs" id="Snippet4":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/ByteAndHex_Examples.vb" id="Snippet4":::

However, you may need to add this additional zero-value byte to byte arrays that are created dynamically by the developer or that are returned by methods that convert unsigned integers to byte arrays (such as <xref:System.BitConverter.GetBytes%28System.UInt16%29?displayProperty=nameWithType>, <xref:System.BitConverter.GetBytes%28System.UInt32%29?displayProperty=nameWithType>, and <xref:System.BitConverter.GetBytes%28System.UInt64%29?displayProperty=nameWithType>).

When parsing a hexadecimal string, the <xref:System.Numerics.BigInteger.Parse%28System.String%2CSystem.Globalization.NumberStyles%29?displayProperty=nameWithType> and <xref:System.Numerics.BigInteger.Parse%28System.String%2CSystem.Globalization.NumberStyles%2CSystem.IFormatProvider%29?displayProperty=nameWithType> methods assume that if the most significant bit of the first byte in the string is set, or if the first hexadecimal digit of the string represents the lower four bits of a byte value, the value is represented by using two's complement representation. For example, both "FF01" and "F01" represent the decimal value -255. To differentiate positive from negative values, positive values should include a leading zero. The relevant overloads of the <xref:System.Numerics.BigInteger.ToString%2A> method, when they are passed the "X" format string, add a leading zero to the returned hexadecimal string for positive values. This makes it possible to round-trip <xref:System.Numerics.BigInteger> values by using the <xref:System.Numerics.BigInteger.ToString%2A> and <xref:System.Numerics.BigInteger.Parse%2A> methods, as the following example shows.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/ByteAndHex_Examples.cs" id="Snippet5":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/ByteAndHex_Examples.vb" id="Snippet5":::

However, the hexadecimal strings created by calling the `ToString` methods of the other integral types or the overloads of the <xref:System.Convert.ToString%2A> method that include a `toBase` parameter do not indicate the sign of the value or the source data type from which the hexadecimal string was derived. Successfully instantiating a <xref:System.Numerics.BigInteger> value from such a string requires some additional logic. The following example provides one possible implementation.

:::code language="csharp" source="./snippets/System.Numerics/BigInteger/Overview/csharp/ByteAndHex_Examples2.cs" id="Snippet6":::
:::code language="vb" source="./snippets/System.Numerics/BigInteger/Overview/vb/ByteAndHex_Examples2.vb" id="Snippet6":::
