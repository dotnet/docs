---
description: "Learn more about: QuotedPairReader class"
title: QuotedPairReader class (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.Mail.QuotedPairReader
  - System.Net.Mail.QuotedPairReader.CountQuotedChars
api_location:
  - System.dll
api_type:
  - Assembly
---
# QuotedPairReader class

Determines which characters are quoted (escaped) in a quoted string. This class cannot be inherited.

```csharp
internal static class QuotedPairReader
```

> [!WARNING]
> This class is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this class in a production application under any circumstance.

## CountQuotedChars method

Counts the number of consecutive quoted characters, including multiple preceding quoted backslashes, in the specified string. For example, given the string `a\\\b` and an index of `4`, the method returns `4`, because `b` is quoted and so are the three preceding backslashes.

```csharp
internal static int CountQuotedChars(string data, int index, bool permitUnicodeEscaping)
```

### Parameters

- `data` <xref:System.String>

  The data string in which to count consecutive quoted characters.

- `index` <xref:System.Int32>

  The position in the specified string up to and including which consecutive quoted characters should be counted.

- `permitUnicodeEscaping` <xref:System.Boolean>

  `true` to permit Unicode characters to be escaped; otherwise, `false`.

### Return value

<xref:System.Int32?displayProperty=nameWithType>

`0` if the character at the specified index is not escaped; otherwise, the number of consecutive quoted characters up to and including the character at `index`.

### Exceptions

<xref:System.FormatException?displayProperty=nameWithType>

An escaped Unicode character was found but is not permitted.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
