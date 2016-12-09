---
title: "How to: Modify String Contents (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "strings [C#], modifying"
ms.assetid: b6c20bba-ce22-43d7-ad1b-5ce65f714055
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Modify String Contents (C# Programming Guide)
Because strings are *immutable*, it is not possible (without using unsafe code) to modify the value of a string object after it has been created. However, there are many ways to modify the value of a string and store the result in a new string object. The <xref:System.String?displayProperty=fullName> class provides methods that operate on an input string and return a new string object. In many cases, you can assign the new object to the variable that held the original string. The <xref:System.Text.RegularExpressions.Regex?displayProperty=fullName> class provides additional methods that work in a similar manner. The <xref:System.Text.StringBuilder?displayProperty=fullName> class provides a character buffer that you can modify "in-place." You call the <xref:System.Text.StringBuilder.ToString%2A?displayProperty=fullName> method to create a new string object that contains the current contents of the buffer.  
  
## Example  
 The following example shows various ways to replace or remove substrings in a specified string.  
  
 [!code-cs[csProgGuideStrings#28](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-modify-string-contents_1.cs)]  
  
## Example  
 To access the individual characters in a string by using array notation, you can use the <xref:System.Text.StringBuilder> object, which overloads the `[]` operator to provide access to its internal character buffer. You can also convert the string to an array of chars by using the <xref:System.String.ToCharArray%2A> method. The following example uses `ToCharArray` to create the array. Some elements of this array are then modified. A string constructor that takes a char array as an input parameter is then called to create a new string.  
  
 [!code-cs[csProgGuideStrings#24](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-modify-string-contents_2.cs)]  
  
## Example  
 The following example is provided for those very rare situations in which you may want to modify a string in-place by using unsafe code in a manner similar to C-style char arrays. The example shows how to access the individual characters "in-place" by using the fixed keyword. It also demonstrates one possible side effect of unsafe operations on strings that results from the way that the C# compiler stores (interns) strings internally. In general, you should not use this technique unless it is absolutely necessary.  
  
 [!code-cs[csProgGuideStrings#29](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-modify-string-contents_3.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Strings](../../../csharp/programming-guide/strings/index.md)