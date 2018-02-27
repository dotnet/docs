---
title: "How to: Modify String Contents (C# Guide)"
ms.date: 02/26/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "strings [C#], modifying"
author: "BillWagner"
ms.author: "wiwagn"
---

# How to: Modify String Contents (C# Programming Guide)

Because strings are *immutable*, it is not possible (without using unsafe code) to modify the value of a string object after it has been created. However, there are many ways to modify the value of a string and store the result in a new string object. The <xref:System.String?displayProperty=nameWithType> class provides methods that operate on an input string and return a new string object. In many cases, you can assign the new object to the variable that held the original string. The <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class provides additional methods that work in a similar manner. The <xref:System.Text.StringBuilder?displayProperty=nameWithType> class provides a character buffer that you can modify "in-place." You call the <xref:System.Text.StringBuilder.ToString%2A?displayProperty=nameWithType> method to create a new string object that contains the current contents of the buffer.  
  
## Example  

The following example shows various ways to replace or remove substrings in a specified string.  
  
[!code-csharp[csProgGuideStrings#28](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-modify-string-contents_1.cs)]  
  
## Example  

To access the individual characters in a string by using array notation, you can use the <xref:System.Text.StringBuilder> object, which overloads the `[]` operator to provide access to its internal character buffer. You can also convert the string to an array of chars by using the <xref:System.String.ToCharArray%2A> method. The following example uses `ToCharArray` to create the array. Some elements of this array are then modified. A string constructor that takes a char array as an input parameter is then called to create a new string.  
  
[!code-csharp[csProgGuideStrings#24](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-modify-string-contents_2.cs)]  
 
## Example  

The following example is provided for those very rare situations in which you may want to modify a string in-place by using unsafe code in a manner similar to C-style char arrays. The example shows how to access the individual characters "in-place" by using the fixed keyword. It also demonstrates one possible side effect of unsafe operations on strings that results from the way that the C# compiler stores (interns) strings internally. In general, you should not use this technique unless it is absolutely necessary.  
  
[!code-csharp[csProgGuideStrings#29](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-modify-string-contents_3.cs)]  
 
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Strings](../../../csharp/programming-guide/strings/index.md)  
