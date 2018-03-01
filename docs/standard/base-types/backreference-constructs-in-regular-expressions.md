---
title: "Backreference Constructs in Regular Expressions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "backreferences"
  - "constructs, backreference"
  - ".NET Framework regular expressions, backreference constructs"
  - "regular expressions, backreference constructs"
ms.assetid: 567a4b8d-0e79-49dc-8df9-f4b1aa376a2a
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Backreference Constructs in Regular Expressions
Backreferences provide a convenient way to identify a repeated character or substring within a string. For example, if the input string contains multiple occurrences of an arbitrary substring, you can match the first occurrence with a capturing group, and then use a backreference to match subsequent occurrences of the substring.  
  
> [!NOTE]
>  A separate syntax is used to refer to named and numbered capturing groups in replacement strings. For more information, see [Substitutions](substitutions-in-regular-expressions.md).  
  
 .NET defines separate language elements to refer to numbered and named capturing groups. For more information about capturing groups, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
## Numbered Backreferences  
 A numbered backreference uses the following syntax:  
  
 `\` *number*  
  
 where *number* is the ordinal position of the capturing group in the regular expression. For example, `\4` matches the contents of the fourth capturing group. If *number* is not defined in the regular expression pattern, a parsing error occurs, and the regular expression engine throws an <xref:System.ArgumentException>. For example, the regular expression `\b(\w+)\s\1` is valid, because `(\w+)` is the first and only capturing group in the expression. On the other hand, `\b(\w+)\s\2` is invalid and throws an argument exception, because there is no capturing group numbered `\2`. In addition, if *number* identifies a capturing group in a particular ordinal position, but that capturing group has been assigned a numeric name different than its ordinal position, the regular expression parser also throws an <xref:System.ArgumentException>. 
  
 Note the ambiguity between octal escape codes (such as `\16`) and `\`*number* backreferences that use the same notation. This ambiguity is resolved as follows:  
  
-   The expressions `\1` through `\9` are always interpreted as backreferences, and not as octal codes.  
  
-   If the first digit of a multidigit expression is 8 or 9 (such as `\80` or `\91`), the expression as interpreted as a literal.  
  
-   Expressions from `\10` and greater are considered backreferences if there is a backreference corresponding to that number; otherwise, they are interpreted as octal codes.  
  
-   If a regular expression contains a backreference to an undefined group number, a parsing error occurs, and the regular expression engine throws an <xref:System.ArgumentException>.  
  
 If the ambiguity is a problem, you can use the `\k<`*name*`>` notation, which is unambiguous and cannot be confused with octal character codes. Similarly, hexadecimal codes such as `\xdd` are unambiguous and cannot be confused with backreferences.  
  
 The following example finds doubled word characters in a string. It defines a regular expression, `(\w)\1`, which consists of the following elements.  
  
|Element|Description|  
|-------------|-----------------|  
|`(\w)`|Match a word character and assign it to the first capturing group.|  
|`\1`|Match the next character that is the same as the value of the first capturing group.|  
  
 [!code-csharp[RegularExpressions.Language.Backreferences#1](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.backreferences/cs/backreference1.cs#1)]
 [!code-vb[RegularExpressions.Language.Backreferences#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.backreferences/vb/backreference1.vb#1)]  
  
## Named Backreferences  
 A named backreference is defined by using the following syntax:  
  
 `\k<` *name* `>`  
  
 or:  
  
 `\k'` *name* `'`  
  
 where *name* is the name of a capturing group defined in the regular expression pattern. If *name* is not defined in the regular expression pattern, a parsing error occurs, and the regular expression engine throws an <xref:System.ArgumentException>.  
  
 The following example finds doubled word characters in a string. It defines a regular expression, `(?<char>\w)\k<char>`, which consists of the following elements.  
  
|Element|Description|  
|-------------|-----------------|  
|`(?<char>\w)`|Match a word character and assign it to a capturing group named `char`.|  
|`\k<char>`|Match the next character that is the same as the value of the `char` capturing group.|  
  
 [!code-csharp[RegularExpressions.Language.Backreferences#2](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.backreferences/cs/backreference2.cs#2)]
 [!code-vb[RegularExpressions.Language.Backreferences#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.backreferences/vb/backreference2.vb#2)]  

## Named numeric backreferences

In a named backreference with `\k`, *name* can also be the string representation of a number. For example, the following example uses the regular expression `(?<2>\w)\k<2>` to find doubled word characters in a string. In this case, the example defines a capturing group that is explicitly named "2", and the backreference is correspondingly named "2". 
  
 [!code-csharp[RegularExpressions.Language.Backreferences#3](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.backreferences/cs/backreference3.cs#3)]
 [!code-vb[RegularExpressions.Language.Backreferences#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.backreferences/vb/backreference3.vb#3)]  

If *name* is the string representation of a number, and no capturing group has that name, `\k<`*name*`>` is the same as the backreference `\`*number*, where *number* is the ordinal position of the capture. In the following example, there is a single capturing group named `char`. The backreference construct refers to it as `\k<1>`. As the output from the example shows, the call to the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> succeeds because `char` is the first capturing group.

[!code-csharp[Ordinal.Backreference](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.backreferences/cs/backreference6.cs)]
[!code-vb[Ordinal.BackReference](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.backreferences/vb/backreference6.vb)]  

However, if *name* is the string representation of a number and the capturing group in that position has been explicitly assigned a numeric name, the regular expression parser cannot identify the capturing group by its ordinal position. Instead, it throws an <xref:System.ArgumentException>.The only capturing group in the following example is named "2". Because the `\k` construct is used to define a backreference named "1", the regular expression parser is unable to identify the first capturing group and throws an exception.

[!code-csharp[Ordinal.Backreference](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.backreferences/cs/backreference7.cs)]
[!code-vb[Ordinal.BackReference](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.backreferences/vb/backreference7.vb)]  

## What Backreferences Match  
 A backreference refers to the most recent definition of a group (the definition most immediately to the left, when matching left to right). When a group makes multiple captures, a backreference refers to the most recent capture.  
  
 The following example includes a regular expression pattern, `(?<1>a)(?<1>\1b)*`, which redefines the \1 named group. The following table describes each pattern in the regular expression.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`(?<1>a)`|Match the character "a" and assign the result to the capturing group named `1`.|  
|`(?<1>\1b)*`|Match 0 or 1 occurrence of the group named `1` along with a "b", and assign the result to the capturing group named `1`.|  
  
 [!code-csharp[RegularExpressions.Language.Backreferences#4](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.backreferences/cs/backreference4.cs#4)]
 [!code-vb[RegularExpressions.Language.Backreferences#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.backreferences/vb/backreference4.vb#4)]  
  
 In comparing the regular expression with the input string ("aababb"), the regular expression engine performs the following operations:  
  
1.  It starts at the beginning of the string, and successfully matches "a" with the expression `(?<1>a)`. The value of the `1` group is now "a".  
  
2.  It advances to the second character, and successfully matches the string "ab" with the expression `\1b`, or "ab". It then assigns the result, "ab" to `\1`.  
  
3.  It advances to the fourth character. The expression `(?<1>\1b)` is to be matched zero or more times, so it successfully matches the string "abb" with the expression `\1b`. It assigns the result, "abb", back to `\1`.  
  
 In this example, `*` is a looping quantifier -- it is evaluated repeatedly until the regular expression engine cannot match the pattern it defines. Looping quantifiers do not clear group definitions.  
  
 If a group has not captured any substrings, a backreference to that group is undefined and never matches. This is illustrated by the regular expression pattern `\b(\p{Lu}{2})(\d{2})?(\p{Lu}{2})\b`, which is defined as follows:  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match on a word boundary.|  
|`(\p{Lu}{2})`|Match two uppercase letters. This is the first capturing group.|  
|`(\d{2})?`|Match zero or one occurrence of two decimal digits. This is the second capturing group.|  
|`(\p{Lu}{2})`|Match two uppercase letters. This is the third capturing group.|  
|`\b`|End the match on a word boundary.|  
  
 An input string can match this regular expression even if the two decimal digits that are defined by the second capturing group are not present. The following example shows that even though the match is successful, an empty capturing group is found between two successful capturing groups.  
  
 [!code-csharp[RegularExpressions.Language.Backreferences#5](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.backreferences/cs/backreference5.cs#5)]
 [!code-vb[RegularExpressions.Language.Backreferences#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.backreferences/vb/backreference5.vb#5)]  
  
## See Also  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)
