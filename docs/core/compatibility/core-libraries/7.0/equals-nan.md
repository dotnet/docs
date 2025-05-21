---
title: ".NET 7 breaking change: Equals method behavior change for NaN"
description: Learn about the .NET 7 breaking change in core .NET libraries where the behavior of some Equals(T other) instance methods changed for NaN values.
ms.date: 05/18/2022
ms.topic: article
---
# Equals method behavior change for NaN

The `Equals(T other)` instance method for the following types was updated to meet the <xref:System.IEquatable%601> implementation requirements. As a result, the method now correctly handles NaN. This change ensures the types can correctly be used alongside `GetHashCode`, <xref:System.Collections.Generic.Dictionary%602>, and other hash sets.

- <xref:System.Numerics.Matrix3x2?displayProperty=fullName>
- <xref:System.Numerics.Matrix4x4?displayProperty=fullName>
- <xref:System.Numerics.Plane?displayProperty=fullName>
- <xref:System.Numerics.Quaternion?displayProperty=fullName>
- <xref:System.Numerics.Vector2?displayProperty=fullName>
- <xref:System.Numerics.Vector3?displayProperty=fullName>
- <xref:System.Numerics.Vector4?displayProperty=fullName>
- <xref:System.Numerics.Vector%601?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Vector64%601?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Vector128%601?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Vector256%601?displayProperty=fullName>

## Previous behavior

Previously, the `Equals(T other)` instance method followed the IEEE 754 requirements and deferred to the `==` implementation. This meant that `NaN != NaN`, even when the two NaN are bitwise identical.

For example:

```csharp
float f = float.NaN;
Console.WriteLine(f == f);         // False
Console.WriteLine(f.Equals(f));   // True
```

While for several of the listed types:

```csharp
Vector2 v = new Vector2(float.NaN);
Console.WriteLine(v == v);        // False
Console.WriteLine(v.Equals(v));   // False
```

This is problematic because using one of these types as a key in a dictionary meant that the key could never be resolved:

```csharp
Vector2 v = new Vector2(float.NaN);
var s = new HashSet<Vector2>();
s.Add(v);
Console.WriteLine(s.Contains(v)); // False
```

## New behavior

The behavior is now the same as for the primitive floating-point types, which is that the `==` and `!=` methods continue to follow the IEEE 754 requirements where `NaN != NaN`. But the `Equals(T other)` instance methods follow the <xref:System.IEquatable%601> requirements so that `NaN.Equals(NaN)`.

For example (no change):

```csharp
float f = float.NaN;
Console.WriteLine(f == f);         // False
Console.WriteLine(f.Equals(f));   // True
```

While for several of the listed types (the second line now prints `True`):

```csharp
Vector2 v = new Vector2(float.NaN);
Console.WriteLine(v == v);        // False
Console.WriteLine(v.Equals(v));   // True
```

And when used in some hash set (the output now prints `True`):

```csharp
Vector2 v = new Vector2(float.NaN);
var s = new HashSet<Vector2>();
s.Add(v);
Console.WriteLine(s.Contains(v)); // True
```

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The previous implementation did not meet the implementation requirements of <xref:System.IEquatable%601> or `object.Equals(object obj)`. This resulted in the affected types not being usable in hash sets or with `GetHashCode`.

## Recommended action

If you prefer the previous behavior, switch to using `==` or `!=` instead of `Equals(T other)`.

## Affected APIs

- <xref:System.Numerics.Matrix3x2.Equals%2A?displayProperty=fullName>
- <xref:System.Numerics.Matrix4x4.Equals%2A?displayProperty=fullName>
- <xref:System.Numerics.Plane.Equals%2A?displayProperty=fullName>
- <xref:System.Numerics.Quaternion.Equals%2A?displayProperty=fullName>
- <xref:System.Numerics.Vector2.Equals%2A?displayProperty=fullName>
- <xref:System.Numerics.Vector3.Equals%2A?displayProperty=fullName>
- <xref:System.Numerics.Vector4.Equals%2A?displayProperty=fullName>
- <xref:System.Numerics.Vector%601.Equals%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Vector64%601.Equals%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Vector128%601.Equals%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Vector256%601.Equals%2A?displayProperty=fullName>
