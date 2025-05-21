---
title: System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode method
description: Learn about the System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode method

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> method always calls the <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> method non-virtually, even if the object's type has overridden the <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> method. Therefore, using <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> might differ from calling `GetHashCode` directly on the object with the <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> method.

> [!WARNING]
> Although the <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> method returns identical hash codes for identical object references, you should not use this method to test for object identity, because this hash code does not uniquely identify an object reference. To test for object identity (that is, to test that two objects reference the same object in memory), call the <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType> method. Nor should you use <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A> to test whether two strings represent equal object references, because the string is interned. To test for string interning, call the <xref:System.String.IsInterned%2A?displayProperty=nameWithType> method.

The <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> and <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> methods differ as follows:

- <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> returns a hash code that is based on the object's definition of equality. For example, two strings with identical contents will return the same value for <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType>.
- <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> returns a hash code that indicates object identity. That is, two string variables whose contents are identical and that represent a string that is interned (see the [String Interning](#string-interning) section) or that represent a single string in memory return identical hash codes.

> [!IMPORTANT]
> Note that <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A> always returns identical hash codes for equal object references. However, the reverse is not true: equal hash codes do not indicate equal object references. A particular hash code value is not unique to a particular object reference; different object references can generate identical hash codes.

This method is used by compilers.

## String interning

The common language runtime (CLR) maintains an internal pool of strings and stores literals in the pool. If two strings (for example, `str1` and `str2`) are formed from an identical string literal, the CLR will set `str1` and `str2` to point to the same location on the managed heap to conserve memory. Calling <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> on these two string objects will produce the same hash code, contrary to the second bulleted item in the previous section.

The CLR adds only literals to the pool. Results of string operations such as concatenation are not added to the pool, unless the compiler resolves the string concatenation as a single string literal. Therefore, if `str2` was created as the result of a concatenation operation, and `str2` is identical to `str1`, using <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> on these two string objects will not produce the same hash code.

If you want to add a concatenated string to the pool explicitly, use the <xref:System.String.Intern%2A?displayProperty=nameWithType> method.

You can also use the <xref:System.String.IsInterned%2A?displayProperty=nameWithType> method to check whether a string has an interned reference.

## Examples

The following example demonstrates the difference between the <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> and <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> methods. The output from the example illustrates the following:

- Both sets of hash codes for the first set of strings passed to the `ShowHashCodes` method are different, because the strings are completely different.

- <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> generates the same hash code for the second set of strings passed to the `ShowHashCodes` method, because the strings are equal. However, the <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType> method does not. The first string is defined by using a string literal and so is interned. Although the value of the second string is the same, it is not interned, because it is returned by a call to the <xref:System.String.Format%2A?displayProperty=nameWithType> method.

- In the case of the third string, the hash codes produced by <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> for both strings are identical, as are the hash codes produced by <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType>. This is because the compiler has treated the value assigned to both strings as a single string literal, and so the string variables refer to the same interned string.

:::code language="csharp" source="./snippets/System.Runtime.CompilerServices/RuntimeHelpers/GetHashCode/csharp/gethashcodeex1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Runtime.CompilerServices/RuntimeHelpers/GetHashCode/vb/gethashcodeex1.vb" id="Snippet1":::
