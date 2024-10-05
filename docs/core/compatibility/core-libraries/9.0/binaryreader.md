---
title: "Breaking change:BinaryReader.GetString() returns '\uFFFD' on malformed sequences"
description: Learn about the .NET 9 breaking change in core .NET libraries where BinaryReader.GetString() returns "\uFFFD" on malformed encoded string sequences.
ms.date: 10/03/2024
---
# BinaryReader.GetString() returns "\uFFFD" on malformed sequences

A a minor breaking change was introduced that only affects malformed encoded payloads.

Prior to .NET 9, a malformed encoded string `[0x01, 0xC2]` that was parsed with <xref:System.IO.BinaryReader.ReadString?displayProperty=nameWithType> returned an empty string.

Starting in .NET 9, <xref:System.IO.BinaryReader.ReadString?displayProperty=nameWithType> returns "\uFFFD", which is the `REPLACEMENT CHARACTER` used to replace an unknown, unrecognized, or unrepresentable character. This change only affects malformed payloads and matches Unicode standards.

## Previous behavior

```csharp
var ms = new MemoryStream(new byte[] { 0x01, 0xC2 });
using (var br = new BinaryReader(ms))
{
    string s = br.ReadString();
    Console.WriteLine(s == "\uFFFD"); // false
    Console.WriteLine(s.Length); // 0
}
```

## New behavior

Starting in .NET 9, the same code snippet produces different results for `s == "\uFFFD"` and `s.Length`, as shown in the code comments:

```csharp
var ms = new MemoryStream(new byte[] { 0x01, 0xC2 });
using (var br = new BinaryReader(ms))
{
    string s = br.ReadString();
    Console.WriteLine(s == "\uFFFD"); // true
    Console.WriteLine(s.Length); // 1
}
```

## Version introduced

.NET 9 Preview 7

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made as a performance improvement that affects a rare scenario.

## Recommended action

If you want to keep the previous behavior where incomplete byte sequence were omitted at the end of the string, call `TrimEnd("\uFFFD")` on the result.

## Affected APIs

- <xref:System.IO.BinaryReader.ReadString?displayProperty=fullName>
