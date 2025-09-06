---
title: "Breaking change - FilePatternMatch.Stem changed to non-nullable"
description: "Learn about the breaking change in .NET 10 where FilePatternMatch.Stem property was changed from nullable to non-nullable."
ms.date: 01/27/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47914
---

# FilePatternMatch.Stem changed to non-nullable

The <xref:Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.Stem?displayProperty=fullName> property was previously annotated as nullable purely because the `PatternTestResult.Stem` property it gets its value from is nullable. While the `PatternTestResult` can indeed be null if the result is not successful, the `FilePatternMatch` never is because it is only ever constructed when `PatternTestResult` is successful. To accurately reflect nullability, the `FilePatternMatch.Stem` property is now non-nullable and the constructor parameter has been changed accordingly.

## Version introduced

.NET 10 RC 1

## Previous behavior

The <xref:Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch> constructor would accept a `null` for the `stem` parameter without any compile-time or run-time warnings or errors. The <xref:Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.Stem?displayProperty=fullName> property was also annotated as being nullable (`string?`).

```csharp
// This was allowed in previous versions
var match = new FilePatternMatch("path/to/file.txt", null);
string? stem = match.Stem; // Could be null
```

## New behavior

Passing a `null` or possibly-null value to the `stem` argument in the <xref:Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch> constructor will yield a compile-time warning, and if `null` is passed in, a run-time <xref:System.ArgumentNullException> will be thrown. The <xref:Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.Stem?displayProperty=fullName> property is now annotated as non-nullable (`string`).

```csharp
// This now throws ArgumentNullException at runtime
var match = new FilePatternMatch("path/to/file.txt", null); // Throws!

// The Stem property is now non-nullable
string stem = match.Stem; // No null check needed
```

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous nullability annotations were inaccurate, and a `null` value for the `stem` argument was unexpected but not properly guarded against. This change reflects the expected behavior of the API and guards against unpredictable behavior while also producing design-time guidance around usage. The `[MemberNotNullWhen()]` attribute is applied to the `PatternTestResult.Stem` property to tell the compiler it will not be null if it is successful.

## Recommended action

If a possibly-null value was passed in for the `stem` argument, review usage and update the call site to ensure `stem` cannot be passed in as `null`. If nullability warning suppressions were applied when consuming the `FilePatternMatch.Stem` property, such suppressions can be removed.

```csharp
// Before: Check for null
string? stem = match.Stem;
if (stem != null)
{
    // Use stem
}

// After: No null check needed
string stem = match.Stem;
// Use stem directly
```

## Affected APIs

- <xref:Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.%23ctor(System.String,System.String)?displayProperty=fullName>
- <xref:Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.Stem?displayProperty=fullName>
