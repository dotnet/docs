---
description: "Learn more about: MailBnfHelper class"
title: MailBnfHelper class (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.Mime.MailBnfHelper
  - System.Net.Mime.MailBnfHelper.Ascii7bitMaxValue
  - System.Net.Mime.MailBnfHelper.Atext
  - System.Net.Mime.MailBnfHelper.CR
  - System.Net.Mime.MailBnfHelper.Ctext
  - System.Net.Mime.MailBnfHelper.Dot
  - System.Net.Mime.MailBnfHelper.EndComment
  - System.Net.Mime.MailBnfHelper.LF
  - System.Net.Mime.MailBnfHelper.Space
  - System.Net.Mime.MailBnfHelper.StartComment
  - System.Net.Mime.MailBnfHelper.Tab
api_location:
  - System.dll
api_type:
  - Assembly
---
# MailBnfHelper class

Contains utility methods for parsing internet message-formatted strings. This class cannot be inherited.

```csharp
internal static class MailBnfHelper
```

> [!WARNING]
> This class is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this class in a production application under any circumstance.

## Ascii7bitMaxValue field

Represents the maximum 7-bit Ascii value.

```csharp
internal static readonly int Ascii7bitMaxValue
```

## Atext field

Represents the characters allowed in atoms.

```csharp
internal static bool[] Atext
```

## CR field

Represents the carriage-return character.

```csharp
internal static readonly char CR
```

## Ctext field

Represents the characters allowed inside of comments.

```csharp
internal static bool[] Ctext
```

## Dot field

Represents the full-stop character (`.`).

```csharp
internal static readonly char Dot
```

## EndComment field

Represents the character that specifies the end of a comment.

```csharp
internal static readonly char EndComment
```

## LF field

Represents the line-feed character.

```csharp
internal static readonly char LF
```

## Space field

Represents the space character.

```csharp
internal static readonly char Space
```

## StartComment field

Represents the character that specifies the start of a comment.

```csharp
internal static readonly char StartComment
```

## Tab field

Represents the tab character.

```csharp
internal static readonly char Tab
```

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
