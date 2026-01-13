---
title: "Breaking change - MailAddress enforces validation for consecutive dots"
description: "Learn about the breaking change in .NET 10 where MailAddress enforces stricter validation of email addresses with consecutive dots."
ms.date: 01/12/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/51018
---

# MailAddress enforces validation for consecutive dots

Starting in .NET 10, the <xref:System.Net.Mail.MailAddress> class enforces stricter validation of email addresses. Email addresses with consecutive dots in the local part (for example, `test..address@example.com`) or domain part (for example, `address@test..example.com`) are now considered invalid. This change aligns the behavior of `MailAddress` with the email address format specified in [RFC 5322](https://www.rfc-editor.org/rfc/rfc5322.html) and [RFC 2822](https://www.rfc-editor.org/rfc/rfc2822.html).

## Version introduced

.NET 10 Preview 1

## Previous behavior

Previously, the <xref:System.Net.Mail.MailAddress> class allowed email addresses with consecutive dots in the local or domain parts, even though such addresses are invalid according to the email address specification.

For example, the following code executed without throwing an exception:

```csharp
using System.Net.Mail;

var email = new MailAddress("test..address@example.com");
Console.WriteLine(email.Address); // Output: test..address@example.com
```

## New behavior

Starting in .NET 10, the <xref:System.Net.Mail.MailAddress> class enforces stricter validation and throws a <xref:System.FormatException> when it parses an email address with consecutive dots in the local or domain parts.

For example, the following code now throws a <xref:System.FormatException>:

```csharp
using System.Net.Mail;

var email = new MailAddress("test..address@example.com"); // Throws FormatException
```

The exception message indicates that the email address is invalid.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change ensures compliance with the email address format specified in [RFC 5322](https://www.rfc-editor.org/rfc/rfc5322.html) and [RFC 2822](https://www.rfc-editor.org/rfc/rfc2822.html). According to these standards, email addresses with consecutive dots in the local or domain parts are invalid. The previous behavior of allowing such addresses was incorrect and could lead to unexpected issues in applications relying on <xref:System.Net.Mail.MailAddress> for email validation.

## Recommended action

If your application relies on the <xref:System.Net.Mail.MailAddress> class to parse email addresses, review your code to ensure that it doesn't pass email addresses with consecutive dots in the local or domain parts. If such addresses are encountered, update your application to handle the <xref:System.FormatException> that's now thrown.

For example, you can use a `try-catch` block to handle invalid email addresses:

```csharp
using System;
using System.Net.Mail;

try
{
    var email = new MailAddress("test..address@example.com");
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid email address: {ex.Message}");
}
```

Alternatively, you can validate email addresses using a regular expression before passing them to the <xref:System.Net.Mail.MailAddress> constructor.

## Affected APIs

- <xref:System.Net.Mail.MailAddress.%23ctor(System.String)> constructor
- <xref:System.Net.Mail.MailAddress.%23ctor(System.String,System.String)> constructor
- <xref:System.Net.Mail.MailAddress.%23ctor(System.String,System.String,System.Text.Encoding)> constructor

## See also

- [Original pull request](https://github.com/dotnet/runtime/pull/109690)
- [Related issue](https://github.com/dotnet/runtime/issues/109590)
