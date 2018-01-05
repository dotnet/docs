---
title: "How to: Parse Strings Using String.Split (C# Guide)"
ms.date: 01/03/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "splitting strings [C#]"
  - "Split method [C#]"
  - "strings [C#], splitting"
  - "parse strings"
ms.assetid: 729c2923-4169-41c6-9c90-ef176c1e2953
author: "BillWagner"
ms.author: "wiwagn"
ms.custom: mvc
---
# How to: Parse Strings Using String.Split (C# Guide)

The <xref:System.String.Split%2A?displayProperty=nameWithType> method creates an
array of substrings by splitting the input string based on one or more delimiters.

It is often the easiest way to separate a string on word boundaries. It is also used
to split strings on other specific characters or strings.

The following code splits a common phrase into an array of strings for each word.
Try it yourself by pressing the *Run* button.

[!code-csharp-interactive[csProgGuideStrings#16](../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs#1)]

.. Think of repeated delimiters.
The following code example demonstrates how a string can be parsed using the <xref:System.String.Split%2A?displayProperty=nameWithType> method. As input, <xref:System.String.Split%2A> takes an array of characters that indicate which characters separate interesting sub strings of the target string.  The function returns an array of the sub strings.  
  
 This example uses spaces, commas, periods, colons, and tabs, all passed in an array containing these separating characters to <xref:System.String.Split%2A>.  Each word in the target string's sentence displays separately from the resulting array of strings.  
  
## Example  
 [!code-csharp[csProgGuideStrings#16](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-parse-strings-using-string-split_1.cs)]  
  
## Example  
 By default, String.Split returns empty strings when two separating characters appear contiguously in the target string.  You can pass an optional StringSplitOptions.RemoveEmptyEntries parameter to exclude any empty strings in the output.  
  
 String.Split can take an array of strings (character sequences that act as separators for parsing the target string, instead of single characters).  
  
```csharp  
class TestStringSplit  
{  
    static void Main()  
    {  
        string[] separatingChars = { "<<", "..." };  
  
        string text = "one<<two......three<four";  
        System.Console.WriteLine("Original text: '{0}'", text);  
  
        string[] words = text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries );  
        System.Console.WriteLine("{0} substrings in text:", words.Length);  
  
        foreach (string s in words)  
        {  
            System.Console.WriteLine(s);  
        }  
  
        // Keep the console window open in debug mode.  
        System.Console.WriteLine("Press any key to exit.");  
        System.Console.ReadKey();  
    }  
}  
/* Output:  
    Original text: 'one<<two......three<four'  
    3 words in text:  
    one  
    two  
    three<four  
*/  
```  
  
## See Also  
 [C# Programming Guide](../programming-guide/index.md)  
 [Strings](../programming-guide/strings/index.md)  
 [.NET Framework Regular Expressions](https://msdn.microsoft.com/library/hs600312)
