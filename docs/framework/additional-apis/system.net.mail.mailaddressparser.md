---
description: "Learn more about: MailAddressParser class"
title: MailAddressParser class (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.Mail.MailAddressParser
  - System.Net.Mail.MailAddressParser.ParseAddress
api_location:
  - System.dll
api_type:
  - Assembly
---
# MailAddressParser class

Parses email addresses as described in RFC 2822. This class cannot be inherited.

```csharp
internal static class MailAddressParser
```

> [!WARNING]
> This class is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this class in a production application under any circumstance.

## ParseAddress method

Parses a single email address from the specified string.

```csharp
internal static MailAddress ParseAddress(string data)
```

### Parameters

`data` <xref:System.String>

The string that contains an email address to be parsed.

### Return value

<xref:System.Net.Mail.MailAddress>

A valid email address.

### Exceptions

<xref:System.FormatException?displayProperty=nameWithType>

The email address is invalid.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
