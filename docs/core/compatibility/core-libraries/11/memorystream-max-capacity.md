---
title: "Breaking change: MemoryStream maximum capacity updated and exception behavior changed"
description: "Learn about the breaking change in .NET 11 Preview 1 where MemoryStream enforces a maximum capacity and throws ArgumentOutOfRangeException for invalid capacity values."
ms.date: 01/08/2026
ai-usage: ai-assisted
---

# MemoryStream maximum capacity updated and exception behavior changed

Starting in .NET 11 Preview 1, the <xref:System.IO.MemoryStream> class enforces a maximum capacity of `0x7FFFFFC7` bytes, which is the actual maximum length of a byte array supported by the CLR. Additionally, the exception behavior has changed when attempting to set a `MemoryStream`'s capacity or length beyond this maximum. Instead of throwing an <xref:System.OutOfMemoryException>, the `MemoryStream` now throws an <xref:System.ArgumentOutOfRangeException> for invalid capacity or length values.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, `MemoryStream` allowed capacities up to `int.MaxValue` (`0x7FFFFFFF`), which could result in an <xref:System.OutOfMemoryException> when attempting to allocate memory beyond the CLR's supported limit of `0x7FFFFFC7`.

When setting the capacity or length of a `MemoryStream` to a value greater than the supported limit, an `OutOfMemoryException` was thrown.

```csharp
var stream = new MemoryStream();
stream.SetLength(int.MaxValue); // Throws OutOfMemoryException
```

## New behavior

Starting in .NET 11, `MemoryStream` enforces a maximum capacity of `0x7FFFFFC7` bytes. Attempting to set the capacity or length beyond this limit throws an <xref:System.ArgumentOutOfRangeException>.

The exception type for invalid capacity or length values has changed from `OutOfMemoryException` to `ArgumentOutOfRangeException`.

```csharp
var stream = new MemoryStream();
stream.SetLength(int.MaxValue); // Throws ArgumentOutOfRangeException
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was introduced to align `MemoryStream`'s behavior with the actual memory allocation limits of the CLR. The previous behavior allowed developers to specify capacities or lengths that exceeded the supported limit, leading to runtime failures with less descriptive exceptions (`OutOfMemoryException`). By capping the maximum capacity and throwing `ArgumentOutOfRangeException`, the change improves runtime reliability and provides clearer feedback to developers.

## Recommended action

Developers should review any code that sets the capacity or length of a `MemoryStream` to ensure it doesn't exceed the maximum supported capacity.

If your code was catching `OutOfMemoryException` when working with `MemoryStream` capacity or length operations, you should update it to also catch `ArgumentOutOfRangeException`, as both exceptions can still occur:

- `ArgumentOutOfRangeException` is thrown when attempting to set an invalid capacity or length (exceeding the maximum).
- `OutOfMemoryException` can still be thrown if there's insufficient memory available on the machine.

```csharp
var stream = new MemoryStream();
try
{
    stream.SetLength(someLength);
}
catch (ArgumentOutOfRangeException)
{
    // Handle invalid capacity/length scenario
}
catch (OutOfMemoryException)
{
    // Handle out of memory scenario
}
```

You can also add a check before setting the capacity or length to avoid the exception:

```csharp
var stream = new MemoryStream();
long newLength = int.MaxValue;

if (newLength > Array.MaxLength)
{
    throw new ArgumentOutOfRangeException(nameof(newLength), $"Length cannot exceed {Array.MaxLength} bytes.");
}

stream.SetLength(newLength);
```

## Affected APIs

- <xref:System.IO.MemoryStream.Capacity?displayProperty=fullName>
- <xref:System.IO.MemoryStream.SetLength(System.Int64)?displayProperty=fullName>
- <xref:System.IO.MemoryStream.%23ctor(System.Int32)?displayProperty=fullName>
