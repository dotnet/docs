---
title: "How to verify that strings are in valid email format"
description: Read an example of how a regular expression verifies that strings are in a valid email format in .NET.
ms.date: "08/01/2022"
ms.custom: devdivchpfy22
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "regular expressions, examples"
  - "user input, examples"
  - "Regex.IsMatch method"
  - "regular expressions [.NET], examples"
  - "examples [Visual Basic], strings"
  - "IsValidEmail"
  - "validation, email strings"
  - "input, checking"
  - "strings [.NET], examples [Visual Basic]"
  - "email [.NET], validating"
  - "IsMatch method"
ms.assetid: 7536af08-4e86-4953-98a1-a8298623df92
---
# How to verify that strings are in valid email format

The example in this article uses a regular expression to verify that a string is in valid email format.

This regular expression is comparatively simple to what can actually be used as an email. Using a regular expression to validate an email is useful to ensure that the structure of an email is correct. However, it isn't a substitution for verifying the email actually exists.

✔️ DO use a small regular expression to check for the valid structure of an email.

✔️ DO send a test email to the address provided by a user of your app.

❌ DON'T use a regular expression as the only way you validate an email.

If you try to create the _perfect_ regular expression to validate that the structure of an email is correct, the expression becomes so complex that it's incredibly difficult to debug or improve. Regular expressions can't validate an email exists, even if it's structured correctly. The best way to validate an email is to send a test email to the address.

[!INCLUDE [regex](../../../includes/regex.md)]

## Example

The example defines an `IsValidEmail` method, which returns `true` if the string contains a valid email address and `false` if it doesn't but takes no other action.

To verify that the email address is valid, the `IsValidEmail` method calls the <xref:System.Text.RegularExpressions.Regex.Replace%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.MatchEvaluator%29?displayProperty=nameWithType> method with the `(@)(.+)$` regular expression pattern to separate the domain name from the email address. The third parameter is a <xref:System.Text.RegularExpressions.MatchEvaluator> delegate that represents the method that processes and replaces the matched text. The regular expression pattern is interpreted as follows:

| Pattern | Description                                                                         |
|---------|-------------------------------------------------------------------------------------|
| `(@)`   | Match the @ character. This part is the first capturing group.                           |
| `(.+)`  | Match one or more occurrences of any character. This part is the second capturing group. |
| `$`     | End the match at the end of the string.                                             |

The domain name, along with the @ character, is passed to the `DomainMapper` method. The method uses the <xref:System.Globalization.IdnMapping> class to translate Unicode characters that are outside the US-ASCII character range to Punycode. The method also sets the `invalid` flag to `True` if the <xref:System.Globalization.IdnMapping.GetAscii%2A?displayProperty=nameWithType> method detects any invalid characters in the domain name. The method returns the Punycode domain name preceded by the @ symbol to the `IsValidEmail` method.

> [!TIP]
> It's recommended that you use the simple `(@)(.+)$` regular expression pattern to normalize the domain and then return a value indicating that it passed or failed. However, the example in this article describes how to use a regular expression further to validate the email. Regardless of how you validate an email, you should always send a test email to the address to ensure it exists.

The `IsValidEmail` method then calls the <xref:System.Text.RegularExpressions.Regex.IsMatch%28System.String%2CSystem.String%29?displayProperty=nameWithType> method to verify that the address conforms to a regular expression pattern.

The `IsValidEmail` method merely determines whether the email format is valid for an email address; it doesn't validate that the email exists. Also, the `IsValidEmail` method doesn't verify that the top-level domain name is a valid domain name listed in the [IANA Root Zone Database](https://www.iana.org/domains/root/db), which would require a look-up operation.

:::code language="csharp" source="snippets/how-to-verify-that-strings-are-in-valid-email-format/csharp/RegexUtilities.cs":::

:::code language="vb" source="snippets/how-to-verify-that-strings-are-in-valid-email-format/vb/RegexUtilities.vb":::

In this example, the regular expression pattern `^[^@\s]+@[^@\s]+\.[^@\s]+$` is interpreted as shown in the following table. The regular expression is compiled using the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> flag.

| Pattern   | Description                                                                              |
|-----------|------------------------------------------------------------------------------------------|
| `^`       | Begin the match at the start of the string.                                              |
| `[^@\s]+` | Match one or more occurrences of any character other than the @ character or whitespace. |
| `@`       | Match the @ character.                                                                   |
| `[^@\s]+` | Match one or more occurrences of any character other than the @ character or whitespace. |
| `\.`      | Match a single period character.                                                         |
| `[^@\s]+` | Match one or more occurrences of any character other than the @ character or whitespace. |
| `$`       | End the match at the end of the string.                                                  |

> [!IMPORTANT]
> This regular expression isn't intended to cover every aspect of a valid email address. It's provided as an example for you to extend as needed.

## See also

- [.NET Regular Expressions](regular-expressions.md)
- [How far should one take e-mail address validation?](https://softwareengineering.stackexchange.com/questions/78353/how-far-should-one-take-e-mail-address-validation#78363)
