---
title: "How to: Verify that Strings Are in Valid Email Format"
ms.date: "12/10/2018"
ms.technology: dotnet-standard
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "regular expressions, examples"
  - "user input, examples"
  - "Regex.IsMatch method"
  - "regular expressions [.NET Framework], examples"
  - "examples [Visual Basic], strings"
  - "IsValidEmail"
  - "validation, email strings"
  - "input, checking"
  - "strings [.NET Framework], examples [Visual Basic]"
  - "email [.NET Framework], validating"
  - "IsMatch method"
ms.assetid: 7536af08-4e86-4953-98a1-a8298623df92
author: "rpetrusha"
ms.author: "ronpet"
---
# How to: Verify that strings are in valid email format

The following example uses a regular expression to verify that a string is in valid email format.

## Example

The example defines an `IsValidEmail` method, which returns `true` if the string contains a valid email address and `false` if it does not, but takes no other action.

To verify that the email address is valid, the `IsValidEmail` method calls the <xref:System.Text.RegularExpressions.Regex.Replace%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.MatchEvaluator%29?displayProperty=nameWithType> method with the `(@)(.+)$` regular expression pattern to separate the domain name from the email address. The third parameter is a <xref:System.Text.RegularExpressions.MatchEvaluator> delegate that represents the method that processes and replaces the matched text. The regular expression pattern is interpreted as follows.

|Pattern|Description|
|-------------|-----------------|
|`(@)`|Match the @ character. This is the first capturing group.|
|`(.+)`|Match one or more occurrences of any character. This is the second capturing group.|
|`$`|End the match at the end of the string.|

The domain name along with the @ character is passed to the `DomainMapper` method, which uses the <xref:System.Globalization.IdnMapping> class to translate Unicode characters that are outside the US-ASCII character range to Punycode. The method also sets the `invalid` flag to `True` if the <xref:System.Globalization.IdnMapping.GetAscii%2A?displayProperty=nameWithType> method detects any invalid characters in the domain name. The method returns the Punycode domain name preceded by the @ symbol to the `IsValidEmail` method.

The `IsValidEmail` method then calls the <xref:System.Text.RegularExpressions.Regex.IsMatch%28System.String%2CSystem.String%29?displayProperty=nameWithType> method to verify that the address conforms to a regular expression pattern.

Note that the `IsValidEmail` method does not perform authentication to validate the email address. It merely determines whether its format is valid for an email address. In addition, the `IsValidEmail` method does not verify that the top-level domain name is a valid domain name listed at the [IANA Root Zone Database](https://www.iana.org/domains/root/db), which would require a look-up operation. Instead, the regular expression merely verifies that the top-level domain name consists of between two and twenty-four ASCII characters, with alphanumeric first and last characters and the remaining characters being either alphanumeric or a hyphen (-).

[!code-csharp[RegularExpressions.Examples.Email#7](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Examples.Email/cs/example4.cs#7)]
[!code-vb[RegularExpressions.Examples.Email#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Examples.Email/vb/example4.vb#7)]

In this example, the regular expression pattern ``^(?(")(".+?(?<!\\)"@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`{}|~\w])*)(?<=[0-9a-z])@))(?([)([(\d{1,3}.){3}\d{1,3}])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][-a-z0-9]{0,22}[a-z0-9]))$`` is interpreted as shown in the following legend. The regular expression is compiled using the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> flag.

Pattern `^`: Begin the match at the start of the string.

Pattern `(?(")`: Determine whether the first character is a quotation mark. `(?(")` is the beginning of an alternation construct.

Pattern `(?(")(".+?(?<!\\)"@)`: If the first character is a quotation mark, match a beginning quotation mark followed by at least one occurrence of any character, followed by an ending quotation mark. The ending quotation mark must not be preceded by a backslash character (\\). `(?<!` is the beginning of a zero-width negative lookbehind assertion. The string should conclude with an at sign (@).

Pattern `|(([0-9a-z]`: If the first character is not a quotation mark, match any alphabetic character from a to z or A to Z (the comparison is case insensitive), or any numeric character from 0 to 9.

Pattern `(\.(?!\.))`: If the next character is a period, match it. If it is not a period, look ahead to the next character and continue the match. `(?!\.)` is a zero-width negative lookahead assertion that prevents two consecutive periods from appearing in the local part of an email address.

Pattern ``|[-!#\$%&'\*\+/=\?\^`{}|~\w]``: If the next character is not a period, match any word character or one of the following characters: -!#$%&'*+/=?^`{}|~

Pattern ``((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`{}|~\w])*``: Match the alternation pattern (a period followed by a non-period, or one of a number of characters) zero or more times.

Pattern `@`: Match the @ character.

Pattern `(?<=[0-9a-z])`: Continue the match if the character that precedes the @ character is A through Z, a through z, or 0 through 9. This pattern defines a zero-width positive lookbehind assertion.

Pattern `(?(\[)`: Check whether the character that follows @ is an opening bracket.

Pattern `(\[(\d{1,3}\.){3}\d{1,3}\])`: If it is an opening bracket, match the opening bracket followed by an IP address (four sets of one to three digits, with each set separated by a period) and a closing bracket.

Pattern `|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+`: If the character that follows @ is not an opening bracket, match one alphanumeric character with a value of A-Z, a-z, or 0-9, followed by zero or more occurrences of a hyphen, followed by zero or one alphanumeric character with a value of A-Z, a-z, or 0-9, followed by a period. This pattern can be repeated one or more times, and must be followed by the top-level domain name.

Pattern `[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))`: The top-level domain name must begin and end with an alphanumeric character (a-z, A-Z, and 0-9). It can also include from zero to 22 ASCII characters that are either alphanumeric or hyphens.

Pattern `$`: End the match at the end of the string.

## Compile the code

The `IsValidEmail` and `DomainMapper` methods can be included in a library of regular expression utility methods, or they can be included as private static or instance methods in the application class.

You can also use the <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> method to include this regular expression in a regular expression library.

If they are used in a regular expression library, you can call them by using code such as the following:

[!code-csharp[RegularExpressions.Examples.Email#8](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Examples.Email/cs/example4.cs#8)]
[!code-vb[RegularExpressions.Examples.Email#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Examples.Email/vb/example4.vb#8)]

## See also

- [.NET Framework Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)
