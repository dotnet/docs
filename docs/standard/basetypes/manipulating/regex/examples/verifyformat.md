---
title: How to: Verify that Strings Are in Valid Email Format
description: How to: Verify that Strings Are in Valid Email Format
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: c3361216-4a76-42ce-80fb-0f8c5c325f7b
---

#  How to: Verify that Strings Are in Valid Email Format

The following example uses a regular expression to verify that a string is in valid email format.

## Example

The example defines an `IsValidEmail` method, which returns `true` if the string contains a valid email address and `false` if it does not, but takes no other action. 

To verify that the email address is valid, the `IsValidEmail` method calls the [Regex.Replace(String, String, MatchEvaluator)]( https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex#System_Text_RegularExpressions_Regex_Replace_System_String_System_String_System_Text_RegularExpressions_MatchEvaluator_) method with the `(@)(.+)$` regular expression pattern to separate the domain name from the email address. The third parameter is a [MatchEvaluator]( https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.MatchEvaluator) delegate that represents the method that processes and replaces the matched text. The regular expression pattern is interpreted as follows. 

Pattern | Description
------- | ----------- 
`(@)` | Match the @ character. This is the first capturing group.
`(.+)` | Match one or more occurrences of any character. This is the second capturing group.
`$` | End the match at the end of the string.
 
The domain name along with the @ character is passed to the `DomainMapper` method, which uses the [IdnMapping]( https://docs.microsoft.com/dotnet/core/api/System.Globalization.IdnMapping) class to translate Unicode characters that are outside the US-ASCII character range to Punycode. The method also sets the `invalid` flag to `true` if the [IdnMapping.GetAscii]( https://docs.microsoft.com/dotnet/core/api/System.Globalization.IdnMapping#System_Globalization_IdnMapping_GetAscii_System_String_) method detects any invalid characters in the domain name. The method returns the Punycode domain name preceded by the @ symbol to the `IsValidEmail` method. 

The `IsValidEmail` method then calls the [Regex.IsMatch(String, String)]( https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex#System_Text_RegularExpressions_Regex_IsMatch_System_String_System_String_) method to verify that the address conforms to a regular expression pattern. 

Note that the `IsValidEmail` method does not perform authentication to validate the email address. It merely determines whether its format is valid for an email address. In addition, the `IsValidEmail` method does not verify that the top-level domain name is a valid domain name listed at the [IANA Root Zone Database](https://www.iana.org/domains/root/db), which would require a look-up operation. Instead, the regular expression merely verifies that the top-level domain name consists of between two and twenty-four ASCII characters, with alphanumeric first and last characters and the remaining characters being either alphanumeric or a hyphen (-). 

```csharp
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class RegexUtilities
{
   bool invalid = false;

   public bool IsValidEmail(string strIn)
   {
       invalid = false;
       if (String.IsNullOrEmpty(strIn))
          return false;

       // Use IdnMapping class to convert Unicode domain names.
       try {
          strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                RegexOptions.None, TimeSpan.FromMilliseconds(200));
       }
       catch (RegexMatchTimeoutException) {
         return false;
       }

        if (invalid)
           return false;

       // Return true if strIn is in valid e-mail format.
       try {
          return Regex.IsMatch(strIn,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
       }
       catch (RegexMatchTimeoutException) {
          return false;
       }
   }

   private string DomainMapper(Match match)
   {
      // IdnMapping class with default property values.
      IdnMapping idn = new IdnMapping();

      string domainName = match.Groups[2].Value;
      try {
         domainName = idn.GetAscii(domainName);
      }
      catch (ArgumentException) {
         invalid = true;
      }
      return match.Groups[1].Value + domainName;
   }
}
```

In this example, the regular expression pattern `^(?(")(".+?(?<!\\)"@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$` is interpreted as shown in the following table. Note that the regular expression is compiled using the [RegexOptions.IgnoreCase]( https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.RegexOptions#System_Text_RegularExpressions_RegexOptions_IgnoreCase) flag.

Pattern | Description
------- | ----------- 
`^` | Begin the match at the start of the string.
`(?(")` | Determine whether the first character is a quotation mark. `(?(")` is the beginning of an alternation construct.
`(?("")("".+?(?<!\\)""@)` | If the first character is a quotation mark, match a beginning quotation mark followed by at least one occurrence of any character, followed by an ending quotation mark. The ending quotation mark must not be preceded by a backslash character `(\). (?<!` is the beginning of a zero-width negative lookbehind assertion. The string should conclude with an at sign (@).
`&#124;(([0-9a-z] | If the first character is not a quotation mark, match any alphabetic character from a to z or A to Z (the comparison is case insensitive), or any numeric character from 0 to 9.
`(\.(?!\.))` | If the next character is a period, match it. If it is not a period, look ahead to the next character and continue the match. `(?!\.)` is a zero-width negative lookahead assertion that prevents two consecutive periods from appearing in the local part of an email address.
`&#124;[-!#\$%&'\*\+/=\?\^`\{\}\&#124;~\w] | If the next character is not a period, match any word character or one of the following characters: -!#$%'*+=?^`{}&#124;~. 
`((\.(?!\.))&#124;[-!#\$%'\*\+/=\?\^`\{\}\&#124;~\w])* | Match the alternation pattern (a period followed by a non-period, or one of a number of characters) zero or more times.
`@` | Match the @ character.
`(?<=[0-9a-z])` | Continue the match if the character that precedes the @ character is A through Z, a through z, or 0 through 9. The `(?<=[0-9a-z])` construct defines a zero-width positive lookbehind assertion.
`(?(\[)` | Check whether the character that follows @ is an opening bracket.
`(\[(\d{1,3}\.){3}\d{1,3}\])` | If it is an opening bracket, match the opening bracket followed by an IP address (four sets of one to three digits, with each set separated by a period) and a closing bracket.
`&#124;(([0-9a-z][-\w]*[0-9a-z]*\.)+` | If the character that follows @ is not an opening bracket, match one alphanumeric character with a value of A-Z, a-z, or 0-9, followed by zero or more occurrences of a word character or a hyphen, followed by zero or one alphanumeric character with a value of A-Z, a-z, or 0-9, followed by a period. This pattern can be repeated one or more times, and must be followed by the top-level domain name. 
`[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))` | The top-level domain name must begin and end with an alphanumeric character (a-z, A-Z, and 0-9). It can also include from zero to 22 ASCII characters that are either alphanumeric or hyphens. 
`$` | End the match at the end of the string.
 
You can call the `IsValidEmail` and `DomainMapper` methods by using code such as the following:

```csharp
public class Application
{
   public static void Main()
   {
      RegexUtilities util = new RegexUtilities();
      string[] emailAddresses = { "david.jones@proseware.com", "d.j@server1.proseware.com",
                                  "jones@ms1.proseware.com", "j.@server1.proseware.com",
                                  "j@proseware.com9", "js#internal@proseware.com",
                                  "j_9@[129.126.118.1]", "j..s@proseware.com",
                                  "js*@proseware.com", "js@proseware..com",
                                  "js@proseware.com9", "j.s@server1.proseware.com",
                                   "\"j\\\"s\\\"\"@proseware.com", "js@contoso.中国" };

      foreach (var emailAddress in emailAddresses) {
         if (util.IsValidEmail(emailAddress))
            Console.WriteLine("Valid: {0}", emailAddress);
         else
            Console.WriteLine("Invalid: {0}", emailAddress);
      }                                            
   }
}
// The example displays the following output:
//       Valid: david.jones@proseware.com
//       Valid: d.j@server1.proseware.com
//       Valid: jones@ms1.proseware.com
//       Invalid: j.@server1.proseware.com
//       Valid: j@proseware.com9
//       Valid: js#internal@proseware.com
//       Valid: j_9@[129.126.118.1]
//       Invalid: j..s@proseware.com
//       Invalid: js*@proseware.com
//       Invalid: js@proseware..com
//       Valid: js@proseware.com9
//       Valid: j.s@server1.proseware.com
//       Valid: "j\"s\""@proseware.com
//       Valid: js@contoso.ä¸­å›½
```

## See Also

[Regular Expression Examples](index.md)
